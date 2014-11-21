using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Frontends.Common.Wizards;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using compucare.Enquire.Legacy.Umfrage2Lib.circular;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using Compucare.Frontends.Common.Forms;
using System.Threading;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using Microsoft.SqlServer;
using MySql.Data.MySqlClient;
using umfrage2._2008;
using Compucare.Enquire.Legacy.Umfrage2Lib;
using Compucare.Enquire.Common.Controls.Utils;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.DataModule.Settings;

namespace Compucare.Enquire.Common.Calculation.Texts.Sokd.Wizard
{
    class SokdWizardPage : BaseWizardPage
    {
        private readonly SokdWizardPageControl _control;
        //private readonly SingleOnlyQuestionSelector _questionSelector;
        private DropDownTextBoxController _questionController;
        private readonly Evaluation _eval;
        private readonly SokdValues _sokd;
        private readonly Datenbank _db;
        private MySqlCommand cmd;
        private MySqlDataReader d;
        public MySqlConnection sql;
        private String frage = "";
        private Question question;
        private Dictionary<string, string> map2012andUnder; 

        public SokdWizardPage(Evaluation eval)
        {
            
            this.map2012andUnder = new Dictionary<string, string>();
            
            _eval = eval;
            
            _db = new Datenbank();
            _sokd = new SokdValues();
            _control = new SokdWizardPageControl();
            //_questionSelector = new SingleOnlyQuestionSelector(_control._selectQuestion);
            PageControl = _control;
            Header = "SOKD Erhebungsvergleich";
            Description = "Frage, Blz, Vergleichsjahre auswählen und anschließend auf Finish klicken.";
            _questionController = new DropDownTextBoxController(_control._questionSelect);

            _questionController.Images = new ImageList();
            _questionController.Images.Images.Add(Pictures.emblem_question_yellow);
            AddListeners();
            AllowNext = true;
            AllowBack = true;
            AllowFinish = true;
            openDB();
            loadYears();
            LoadItems(_eval);
        }

        public virtual void LoadItems(Evaluation eval)
        {
            _questionController.StartWait();

            _questionController.ClearItems();

            foreach (Question q in eval.Global.Questions)
            {
                _questionController.AddItem(new DropDownTextBoxQuestion(q));
            }
            foreach (QuestionCombo combo in eval.QuestionCombos)
            {
                _questionController.AddItem(new DropDownTextBoxQuestionCombo(combo));
            }
            foreach (QuestionPlaceholder ph in eval.QuestionPlaceholders)
            {
                _questionController.AddItem(new DropDownTextBoxQuestionPlaceholder(ph));
            }
            foreach (Question q in eval.QuestionConvert)
            {
                _questionController.AddItem(new DropDownTextBoxQuestion(q));
            }


            _questionController.StopWait();
        }


        private void loadYears(){
            try
            {
                cmd = new MySqlCommand("select distinct jahr FROM sokd_teilnehmer", sql);
                d = cmd.ExecuteReader();
                while (d.Read() && d != null)
                {
                    _control._comboBox_Jahr.Items.Add(d.GetString(0));
                    _control._comboBox_Jahr2.Items.Add(d.GetString(0));
                }
            }
            catch(Exception e)
            {
                e.Message.ToString();
            }
        }

        private void openDB()
        {
            sql = _db.openDatabase();
            try
            {
                sql.Open();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
          
        }

        void AddListeners()
        {
            //_control._comboBox_Fragen.SelectedValueChanged += fragen_SelectedValueChanged;
            _control._comboBox_Jahr.SelectedValueChanged += comboboxJahrSelectedValueChanged;
            _control._comboBox_Jahr2.SelectedValueChanged += comboboxJahr2SelectedValueChanged;
            _control._comboBox_Blz.SelectedValueChanged += blzSelectedValueChanged;
            _control._comboBox_Blz2.SelectedValueChanged += blz2SelectedValueChanged;
            _control._rbValue.CheckedChanged += rbValueCheckedChanged;
            _control._rbGraphic.CheckedChanged += rbGraphicsCheckedChanged;
            _control._rb_GraphicValue.CheckedChanged += rbGraphics2CheckedChanged;
            _control._rbPercentNo.CheckedChanged += rbPercentNoCheckedChanged;
            _control._rbPercentYes.CheckedChanged += rbPercentYesCheckedChanged;
            _questionController.SelectionChanged += QuestionControllerSelectionChanged;
            _control._btnSpaltenId.Click += btnSpaltenIdClick;
       
        }

        public void setSokd()
        {
            _eval.SetSokdValues(_sokd);
        }

        public bool GetTypeofSokd()
        {
            return _sokd.getIsGrafik();
        }

        void btnSpaltenIdClick(object sender, EventArgs e){
            try
            {
                ContextMenu asel = new ContextMenu();
                Question q = null;

                if (_sokd.getFrage() != 0)
                {
                    if (_sokd.getFrage() <= -100 && _sokd.getFrage() > -5000)
                    {
                        //QuestionCombo

                        foreach (QuestionCombo combo in _eval.QuestionCombos)
                        {
                           if(combo.ID == ((_sokd.getFrage()*-1)-100)){
                               q =combo.GetQuestion(_eval.Global);
                               //MessageBox.Show(combo.Type.ToString());
                               break;
                           }
                        }
                    }
                    else
                    {
                        q = _eval.Global.GetQuestionById(_sokd.getFrage()); 
                    }
                    foreach (string a in q.AnswerList)
                        {
                            MenuItem bci = new MenuItem();
                            bci.Text = a;
                            bci.Click += new EventHandler(bcitrend_Click);

                            asel.MenuItems.Add(bci);
                        }
                }
                else
                {
                    MessageBox.Show("Frage auswählen!");
                }
                asel.Show(_control._btnSpaltenId, new Point(_control._btnSpaltenId.Width, _control._btnSpaltenId.Height));
            }
            catch
            {

            }
        }

        void bcitrend_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItem mi = (MenuItem)sender;
                _sokd.setSpaltenId(mi.Index);
                //MessageBox.Show(mi.Index.ToString()+"\n"+mi.Text+"\n"+mi.ToString());
                _sokd.setSpaltenText(mi.Text);
            }
            catch
            {

            }
        }

        void rbPercentNoCheckedChanged(object sender, EventArgs e)
        {
            _sokd.setIsPercent(false);
            _control._rbValue.Text = "Eigene Mittelwert";
            _control._btnSpaltenId.Visible = false; 
            setSokd();
        }

        void QuestionControllerSelectionChanged(object arg1)
        {
            Int32 q=0;
            try
            {
                q = (Int32)_questionController.SelectedItem.Value;
                //MessageBox.Show(q.ToString());
                _sokd.setFrage(q);
                setSokd();
            }
            catch
            {
                
            }
            
        }

        void rbPercentYesCheckedChanged(object sender, EventArgs e)
        {
            _sokd.setIsPercent(true);
            _control._rbValue.Text = "Eigene Prozentwert";
            _control._btnSpaltenId.Visible = true;
            setSokd();
        }

        void comboboxJahrSelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _sokd.setJahr(Convert.ToInt32(_control._comboBox_Jahr.SelectedItem));
                setSokd();
            }
            catch
            {
                MessageBox.Show("Sokwizardpages fehler");
            }
            update_combobox(_control._comboBox_Jahr.SelectedItem.ToString(), "combo1");
        }

        void comboboxJahr2SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                _sokd.setJahr2(Convert.ToInt32(_control._comboBox_Jahr2.SelectedItem));
                setSokd();
            }
            catch
            {
                MessageBox.Show("Sokwizardpages fehler");
            }
            update_combobox(_control._comboBox_Jahr2.SelectedItem.ToString(),"combo2");
        }

        void rbValueCheckedChanged(object sender, EventArgs e)
        {
            _control._bindestrich.Visible = false;
            _control._comboBox_Jahr2.Visible = false;
            _control._comboBox_Blz2.Visible = false;
            _control._lb_bankName2.Visible = false;
            _sokd.setIsGrafik(false);
            _sokd.setIsGrafik2(false);
            setSokd();
        }

        void rbGraphicsCheckedChanged(object sender, EventArgs e)
        {
            _control._bindestrich.Visible = true;
            _control._comboBox_Jahr2.Visible = true;
            _control._comboBox_Blz2.Visible = true;
            _control._lb_bankName2.Visible = true;
            _sokd.setIsGrafik(true);
            _sokd.setIsGrafik2(false);
            setSokd();
        }

        void rbGraphics2CheckedChanged(object sender, EventArgs e)
        {
            _control._bindestrich.Visible = true;
            _control._comboBox_Jahr2.Visible = true;
            _control._comboBox_Blz2.Visible = true;
            _control._lb_bankName2.Visible = true;
            _sokd.setIsGrafik(false);
            _sokd.setIsGrafik2(true);
            setSokd();
        }

        void fragen_SelectedValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                frage = _control._comboBox_Fragen.SelectedItem.ToString();
                string[] array_fragen = frage.Split(' ');
                frage = array_fragen[0];
                _sokd.setFrage(Convert.ToInt32(frage));
                setSokd();
            }
            catch
            {
                MessageBox.Show("SokdWizardPage - Convert to Integer Exception");
            }*/
        }

        void blzSelectedValueChanged(object sender, EventArgs e)
        {
            _sokd.setBlz(Convert.ToInt32(_control._comboBox_Blz.SelectedItem));

            if (_sokd.getBlz() == 99999)
                _control._lb_bankName1.Text = "OSV Gesamt";
            else if (_sokd.getBlz() == 99998)
                _control._lb_bankName1.Text = "Schleswig-Holstein Gesamt";
            else
                _control._lb_bankName1.Text = returnBankName(_sokd.getBlz(), _sokd.getJahr()); 

            
            setSokd();
        }

        void blz2SelectedValueChanged(object sender, EventArgs e)
        {
            _sokd.setBlz2(Convert.ToInt32(_control._comboBox_Blz2.SelectedItem));
           
            if (_sokd.getBlz2() == 99999)
                _control._lb_bankName2.Text = "OSV Gesamt";
            else if (_sokd.getBlz2() == 99998)
                _control._lb_bankName2.Text = "Schleswig-Holstein Gesamt";
            else
                _control._lb_bankName2.Text = returnBankName(_sokd.getBlz2(), _sokd.getJahr2());

            
            setSokd();
        }

        string returnBankName(int blz, int jahr)
        {
            string bName = ""; 
             cmd = new MySqlCommand("select name from sokd_teilnehmer where blz = "+blz+" and jahr = "+jahr, sql);
             d = cmd.ExecuteReader();
             while (d.Read() && d != null)
             {
                 bName += d.GetString(0) + "\n";
             }
             return bName;
        }

        void update_combobox(string jahr, string type)
        {
            if (type.Equals("combo1"))
                _control._comboBox_Blz.Items.Clear();
            else
                _control._comboBox_Blz2.Items.Clear();
            try
            {
                cmd = new MySqlCommand("select distinct blz from sokd_teilnehmer where jahr = " + jahr + " order by blz asc", sql);
                d = cmd.ExecuteReader();

                while (d.Read() && d != null)
                {
                    if (type.Equals("combo1"))
                        _control._comboBox_Blz.Items.Add(d.GetString(0));
                    else
                        _control._comboBox_Blz2.Items.Add(d.GetString(0));    
                }

                if (type.Equals("combo1"))
                {
                    if (Int32.Parse(jahr) > 2012)
                    {
                        _control._comboBox_Blz.Items.Add("99999");
                        _control._comboBox_Blz.Items.Add("99998");
                    }
                    else
                    {
                        _control._comboBox_Blz.Items.Add("99999");
                    }
                }
                else
                {
                    if (Int32.Parse(jahr) > 2012)
                    {
                        _control._comboBox_Blz2.Items.Add("99999");
                        _control._comboBox_Blz2.Items.Add("99998");
                    }
                    else
                    {
                        _control._comboBox_Blz2.Items.Add("99999");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sql Command Exception");
            }
        }


        public string GetItem()
        {
            return _sokd.ToXml();
        }

    }
}