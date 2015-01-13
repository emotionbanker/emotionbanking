using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class InsertForm : Form
    {
        public string FieldCode;
        private Evaluation eval;
        private Microsoft.Office.Interop.Word.Document doc;

        public ChoosePersonControl cpp;

        private Question q;

        private Question tcq; //temp cross

        private ArrayList crosses;

        public Table tableset;

        public string pottable;

        public ControlForms.PercentBaseForm pbf;

        public decimal Prec
        {
            get { return Precision.Value; }
        }

        private int qid
        {
            get { if (q != null) return q.ID; else return 0; }
        }

        private int tqid
        {
            get { return tcq.ID; }
        }

        public string CrossList
        {
            get 
            {
                string l = string.Empty;

                int i = 0;
                foreach (Cross c in crosses)
                {
                    l += c.q.ID.ToString() + "." + c.a;
                    if (i++ < crosses.Count - 1) l += "#";
                }

                return l;
            }
        }

        public InsertForm(Evaluation eval, Microsoft.Office.Interop.Word.Document doc)
        {
            this.eval = eval;
            this.doc = doc;

            InitializeComponent();

            pbf = new UMXAddin3.ControlForms.PercentBaseForm(eval);

            if (eval == null)
            {
                MessageBox.Show("Sollte eine Verknüpfung eingestellt sein, speichern und laden Sie das Word- Dokument neu.", "Keine Datenverknьpfung eingestellt");
                this.DialogResult = DialogResult.None;
                this.Close();
                return;
            }
            cpp = new ChoosePersonControl(eval);
            //cpp.SelectionChanged += new CppEventHandler(cpp_SelectionChanged);
            cpp.Dock = DockStyle.Fill;

            q = null;
            tcq = null;

            crosses = new ArrayList();

            PersonPanel.Controls.Add(cpp);

            tableset = new Table();


            compVal.Items.Add("Vergleichsdaten 1");
            compVal.Items.Add("Vergleichsdaten 2");
            compVal.Items.Add("Vergleichsdaten 3");
            compVal.Items.Add("Vergleichsdaten 4");
            compVal.Items.Add("Vergleichsdaten 5");

            SetColPanel();
        }

        private void GetFieldCode(string code)
        {
            int max = 0;
            try
            {
                foreach (Microsoft.Office.Interop.Word.Field f in doc.Fields)
                {
                    if (f.Code.Text.StartsWith(" ADDIN umo:"))
                    {
                        string[] master = f.Code.Text.Split(new char[] { '|' });

                        if (master.Length > 1 && Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                    }
                }
                foreach (Microsoft.Office.Interop.Word.Shape s in doc.Shapes)
                {
                    try
                    {
                        foreach (Microsoft.Office.Interop.Word.Field sf in s.TextFrame.TextRange.Fields)
                        {
                            string[] master = sf.Code.Text.Split(new char[] { '|' });

                            if (master.Length > 1 && Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                //powerpoint
                max = 0;
            }
            FieldCode = " ADDIN umo:" + code + "|" + (max + 1) + "|" + CrossList + "|" + pbf.IString;

        }

        private void Code(string code)
        {
            GetFieldCode(code);
            //MessageBox.Show(FieldCode);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

       

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SelectQButton_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                q = qs.SelectedQuestion;
                SelectQButton.Text = qid.ToString();
            }
        }

        private bool CheckQ()
        {
            return (q != null);
        }

        private bool CheckCQ()
        {
            return (tcq != null);
        }


        public int countPersons()
        {
            ArrayList sel = new ArrayList();

            if (cpp.SelectedPersons.Length > 0) foreach (Person p in cpp.SelectedPersons) { sel.Add(p); }
            if (cpp.SelectedCombos.Length > 0) foreach (PersonCombo p in cpp.SelectedCombos) { sel.Add(p); }

            return sel.Count;
        }

        public string getPersons()
        {
            ArrayList sel = new ArrayList();

            if (cpp.SelectedPersons.Length > 0) foreach (Person p in cpp.SelectedPersons) { sel.Add(p); }
            if (cpp.SelectedCombos.Length > 0) foreach (PersonCombo p in cpp.SelectedCombos) { sel.Add(p); }

            string list = string.Empty;

            
            int j = 0;
            foreach (PersonSetting id in sel)
            {
                if (sel == null) continue;

                int pos = 0;

                for (int i = 0; i < eval.CombinedPersons.Length; i++)
                {
                    if (eval.CombinedPersons[i] == id) pos = i;
                }

                list += pos.ToString();

                if (j < sel.Count - 1) list += "#";
            }

            return list;
        }

        public int getPerson()
        {
            PersonSetting id = null;

            if (cpp.SelectedPersons.Length > 0) foreach (Person p in cpp.SelectedPersons) { id = p; break; }
            if (cpp.SelectedCombos.Length > 0) foreach (PersonCombo p in cpp.SelectedCombos) { id = p; break; }

            int pos = 0;

            for (int i = 0; i < eval.CombinedPersons.Length; i++)
            {
                if (eval.CombinedPersons[i] == id) pos = i;
            }

            return pos;
        }

        private void OSel_Click(object sender, EventArgs e)
        {
            OutputSelect os = new OutputSelect(eval);

            if (os.ShowDialog() == DialogResult.OK)
            {
                Code("op:" + os.report.Name + ":" + os.output.Name + ":" + os.output.width + ":" + os.output.height);
            }
        }

        private void med_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("md:" + qid + ":" + Precision.Value + ":" + getPerson());
            }
        }

        private void mw_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("mw:" + qid + ":" + Precision.Value + ":" + getPerson());
            }
        }

        private void pcnt_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("pc:" + qid + ":" + Precision.Value + ":" + getPerson());
            }
        }

        private void awpcnt_Click(object sender, EventArgs e)
        {
            ContextMenu asel = new ContextMenu();

            if (CheckQ())
            {
                foreach (string a in q.AnswerList)
                {
                    MenuItem mi = new MenuItem();
                    mi.Text = a;
                    mi.Click += new EventHandler(mi_Click);

                    asel.MenuItems.Add(mi);
                }
            }

            asel.Show(awpcnt, new Point(awpcnt.Width, awpcnt.Height));
        }

        void mi_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Code("apc:" + qid + ":" + Precision.Value + ":" + getPerson() + ":" + mi.Text);
        }

        private void qBox_TextChanged(object sender, EventArgs e)
        {
            Question f = null;
            try
            {
                int id = Int32.Parse(qBox.Text);

                foreach (Question gq in eval.Global.Questions)
                {
                    if (gq.ID == id) f = gq;
                }
            }
            catch
            {
                f = null;
            }

            if (f != null)
            {
                q = f;
                SelectQButton.Text = qid.ToString();
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Question f = null;
            try
            {
                int id = Int32.Parse(cBox.Text);

                foreach (Question gq in eval.Global.Questions)
                {
                    if (gq.ID == id) f = gq;
                }
            }
            catch
            {
                f = null;
            }

            if (f != null)
            {
                tcq = f;
                SelCrossButton.Text = f.SID.ToString();
            }
        }

        private void AddCross_Click(object sender, EventArgs e)
        {
            try
            {
                ContextMenu asel = new ContextMenu();

                if (CheckCQ())
                {
                    foreach (string a in tcq.AnswerList)
                    {
                        MenuItem mi = new MenuItem();
                        mi.Text = a;
                        mi.Click += new EventHandler(mi_ClickCross);

                        asel.MenuItems.Add(mi);
                    }
                }

                asel.Show(AddCross, new Point(AddCross.Width, AddCross.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "addcross");
            }
        }

        void mi_ClickCross(object sender, EventArgs e)
        {
            Cross c = new Cross();
            MenuItem mi = (MenuItem)sender;

            c.q = tcq;
            c.a = tcq.GetAnswerId(mi.Text);

            crosses.Add(c);
            CrossView.Items.Add(c);
        }

        private void RemoveCross_Click(object sender, EventArgs e)
        {
            Cross c = (Cross)CrossView.SelectedItem;

            if (c != null)
            {
                crosses.Remove(c);
                CrossView.Items.Remove(c);
            }
        }

        private void gap_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("gap:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void SelCrossButton_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                tcq = qs.SelectedQuestion;
                cBox.Text = tqid.ToString();
            }
        }

        private void tqlist_TextChanged(object sender, EventArgs e)
        {
            tableset.ResetQ(tqlist.Text);
        }

        private void SetColPanel()
        {
            int y = 0;
            ColPanel.Controls.Clear();

            foreach (Col c in tableset.Items)
            {
                ColControl cc = new ColControl();
                cc.Set(c);
                cc.Location = new Point(0, y);
                y += cc.Height;
                cc.SelfDelete += new ColControl.SelfDeleteDelegate(cc_SelfDelete);
                ColPanel.Controls.Add(cc);
            }


        }

        void cc_SelfDelete(ColControl sender)
        {
            tableset.Items.Remove((Col)sender.Tag);
            SetColPanel();
        }

        private void NewCol_Click(object sender, EventArgs e)
        {
            tableset.Items.Add(new Col());
            SetColPanel();
        }

        private void table_Click(object sender, EventArgs e)
        {
            MessageBox.Show("table:0:" + Precision.Value + ":" + getPersons());
            GetFieldCode("table:0:" + Precision.Value + ":" + getPersons());
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void NPSButton_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("nps:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void addN_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("n:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void tl_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("tl:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void pbar_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("pbar:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void aas_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("aas:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void absaas_Click(object sender, EventArgs e)
        {
            ContextMenu asel = new ContextMenu();

            if (CheckQ())
            {
                foreach (string a in q.AnswerList)
                {
                    MenuItem mi = new MenuItem();
                    mi.Text = a;
                    mi.Click += new EventHandler(mi_Click_Abs);

                    asel.MenuItems.Add(mi);
                }
            }

            asel.Show(absaas, new Point(absaas.Width, absaas.Height));
        }

        void mi_Click_Abs(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Code("aabs:" + qid + ":" + Precision.Value + ":" + getPerson() + ":" + mi.Text);
        }

        private void potVal_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("potval:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void potPcnt_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("potpcnt:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void potPic_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                Code("potpic:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void potTable_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                GetFieldCode("pottbl:" + qid + ":" + Precision.Value + ":" + getPersons());
                this.DialogResult = DialogResult.Retry;
                Close();
            }
        }

        private void indivAG_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                IndivTLForm tlf = new IndivTLForm();

                if (tlf.ShowDialog() == DialogResult.OK)
                {
                    Code("idivtl:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + tlf.IString);
                }

                //TODO
                //Code("potpic:" + qid + ":" + Precision.Value + ":" + getPersons());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else 
            if (CheckQ())
            {
                Code("bcont-value:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex);
                
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else 
            if (CheckQ())
            {
                BControlForm bcf = new BControlForm();

                if (bcf.ShowDialog() == DialogResult.OK)
                {
                    Code("bcont-light:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else 
            if (CheckQ())
            {
                BControlTrendForm bcf = new BControlTrendForm(0);

                if (bcf.ShowDialog() == DialogResult.OK)
                {
                    Code("bcont-trend:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                 BControlForm bcf = new BControlForm();

                 if (bcf.ShowDialog() == DialogResult.OK)
                 {
                     BControlTrendForm btf = new BControlTrendForm(0);

                     if (btf.ShowDialog() == DialogResult.OK)
                     {
                         Code("bcont-combo:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString + ":" + btf.IString);
                     }
                 }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else 
            if (CheckQ())
                Code("bcont-comp-mw:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex);
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else 
            if (CheckQ())
            {
                ContextMenu asel = new ContextMenu();
                foreach (string a in q.AnswerList)
                {
                    MenuItem bci = new MenuItem();
                    bci.Text = a;
                    bci.Click += new EventHandler(bci_Click);

                    asel.MenuItems.Add(bci);
                }
                asel.Show(button5, new Point(button5.Width, button5.Height));
            }

          
        }

        void bci_Click(object sender, EventArgs e)
        {           
            MenuItem mi = (MenuItem)sender;
            Code("bcont-comp-apc:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + mi.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                {
                    ContextMenu asel = new ContextMenu();
                    foreach (string a in q.AnswerList)
                    {
                        MenuItem bci = new MenuItem();
                        bci.Text = a;
                        bci.Click += new EventHandler(bcidiff_Click);

                        asel.MenuItems.Add(bci);
                    }
                    asel.Show(button5, new Point(button5.Width, button5.Height));
                }
        }


        void bcidiff_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Code("bcont-value-apc:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + mi.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                {
                    ContextMenu asel = new ContextMenu();
                    foreach (string a in q.AnswerList)
                    {
                        MenuItem bci = new MenuItem();
                        bci.Text = a;
                        bci.Click += new EventHandler(bcitrend_Click);

                        asel.MenuItems.Add(bci);
                    }
                    asel.Show(button5, new Point(button5.Width, button5.Height));
                }
        }

        void bcitrend_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            BControlTrendForm bcf = new BControlTrendForm(1);

            if (bcf.ShowDialog() == DialogResult.OK)
            {
                Code("bcont-trend-apc:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString + ":" + mi.Text);
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                {
                    ContextMenu asel = new ContextMenu();
                    foreach (string a in q.AnswerList)
                    {
                        MenuItem bci = new MenuItem();
                        bci.Text = a;
                        bci.Click += new EventHandler(bcitlb_Click);

                        asel.MenuItems.Add(bci);
                    }
                    asel.Show(button5, new Point(button5.Width, button5.Height));
                }
        }

        void bcitlb_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            BControlForm bcf = new BControlForm();
            bcf.setPercent();

            if (bcf.ShowDialog() == DialogResult.OK)
            {
                Code("bcont-light-apc:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString + ":" + mi.Text);
            }
        }

        private void InsertForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(r, Color.FromArgb(242, 248, 254), Color.FromArgb(194, 211, 255), 0, true);

            g.FillRectangle(b, r);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (getPersons().Trim().Equals("")) MessageBox.Show("Bitte eine Personengruppe auswählen!", "Reifegradmodell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ControlForms.MaturityModel mm = new UMXAddin3.ControlForms.MaturityModel();

                if (mm.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Ignore;
                    GetFieldCode("maturity:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + mm.IString);
                    Close();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!CheckQ()) MessageBox.Show("Bitte eine Frage auswählen!", "Begriffswolke", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ControlForms.TagCloud mm = new UMXAddin3.ControlForms.TagCloud();

                if (mm.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.No;
                    GetFieldCode("tagcloud:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + mm.IString);
                    Close();
                }
            }
        }

        private void percentBaseButton_Click(object sender, EventArgs e)
        {
            pbf.ShowDialog();

            if (pbf.Set) percentBaseButton.BackColor = Color.Green;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                ContextMenu asel = new ContextMenu();
                foreach (string a in q.AnswerList)
                {
                    MenuItem bci = new MenuItem();
                    bci.Text = a;
                    bci.Click += new EventHandler(idivtlbpcnt_Click);

                    asel.MenuItems.Add(bci);
                }
                asel.Show(button11, new Point(button11.Width, button11.Height));
            }
        }

        private void idivtlbpcnt_Click(object sender, EventArgs e)
        {
            IndivTLForm tlf = new IndivTLForm();
            tlf.setPercent();

            MenuItem mi = (MenuItem)sender;

            if (tlf.ShowDialog() == DialogResult.OK)
            {
                Code("idivtlpcnt:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + tlf.IString + ":" + mi.Text);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            IndivTLForm tlf = new IndivTLForm();
            tlf.setNum();

            if (tlf.ShowDialog() == DialogResult.OK)
            {
                Code("idivtlnum:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + tlf.IString);
            }
        }

        private void OriginalAnswerButton_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                ContextMenu asel = new ContextMenu();

                if (CheckQ())
                {
                    foreach (string a in q.AnswerList)
                    {
                        MenuItem mi = new MenuItem();
                        mi.Text = a;
                        mi.Click += new EventHandler(omi_Click);

                        asel.MenuItems.Add(mi);
                    }
                }

                asel.Show(OriginalAnswerButton, new Point(OriginalAnswerButton.Width, OriginalAnswerButton.Height));
            }
        }

        void omi_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            Code("origaw:" + qid + ":" + Precision.Value + ":" + getPerson() + ":" + mi.Text);
        }

        private void CompareTlButton_Click(object sender, EventArgs e)
        {
            CompareTlForm ctl = new CompareTlForm(eval);
            if (ctl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Code("comparetl:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + ctl.IString);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                IndivTLForm tlf = new IndivTLForm();
                tlf.setPercentDiff("NPS");

                if (tlf.ShowDialog() == DialogResult.OK)
                {
                    Code("idivtlnps:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + tlf.IString);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CompareTlForm ctl = new CompareTlForm(eval);
            ctl._itl.setPercentDiff("Vergleichsampel (NPS)");
            if (ctl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Code("comparetlnps:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + ctl.IString);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (CheckQ())
            {
                ContextMenu asel = new ContextMenu();
                foreach (string a in q.AnswerList)
                {
                    MenuItem bci = new MenuItem();
                    bci.Text = a;
                    bci.Click += new EventHandler(compareidivtlbpcnt_Click);

                    asel.MenuItems.Add(bci);
                }
                asel.Show(button15, new Point(button15.Width, button15.Height));
            }
        }

        private void compareidivtlbpcnt_Click(object sender, EventArgs e)
        {
            CompareTlForm tlf = new CompareTlForm(eval);
            tlf._itl.setPercentDiff("Vergleich (Prozente)");

            MenuItem mi = (MenuItem)sender;

            if (tlf.ShowDialog() == DialogResult.OK)
            {
                Code("compareidivtlpcnt:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + tlf.IString + ":" + mi.Text);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                    Code("bcont-nps-value:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                    Code("bcont-nps-diff:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                {
                    BControlTrendForm bcf = new BControlTrendForm(1);

                    if (bcf.ShowDialog() == DialogResult.OK)
                    {
                        Code("bcont-nps-trend:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString);
                    }
                }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                {
                    BControlForm bcf = new BControlForm();
                    bcf.setPercent();

                    if (bcf.ShowDialog() == DialogResult.OK)
                    {
                        Code("bcont-nps-tlb:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString);
                    }
                }
        }

      

        private void XmlCode(String type, Decimal precision, String range, List<QuestionDataItem> questions)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("DataItem"));
            root.SetAttribute("type", type);

            root.AppendChild(doc.CreateElement("Precision")).InnerText = precision.ToString();
            root.AppendChild(doc.CreateElement("Range")).InnerText = range;

            root.AppendChild(doc.CreateElement("Question1")).InnerXml = questions[0].ToXml();
            root.AppendChild(doc.CreateElement("Question2")).InnerXml = questions[1].ToXml();

            Code("xmlGraphic:" + doc.OuterXml);
        }

        private void OSelComp_Click(object sender, EventArgs e)
        {
            OutputSelect os = new OutputSelect(eval);

            if (os.ShowDialog() == DialogResult.OK)
            {
                Code("op-c:" + os.report.Name + ":" + os.output.Name + ":" + os.output.width + ":" + os.output.height + ":" + compVal.SelectedIndex);
            }
        }

        private void compVal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                {
                    BControlForm bcf = new BControlForm();

                    if (bcf.ShowDialog() == DialogResult.OK)
                    {
                        Code("bcont-Exclamation:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString);
                    }
                }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                {
                    ContextMenu asel = new ContextMenu();
                    foreach (string a in q.AnswerList)
                    {
                        MenuItem bci = new MenuItem();
                        bci.Text = a;
                        bci.Click += new EventHandler(bciPercentExclamation_Click);

                        asel.MenuItems.Add(bci);
                    }
                    asel.Show(button5, new Point(button5.Width, button5.Height));
                }
        }

        void bciPercentExclamation_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            BControlForm bcf = new BControlForm();
            bcf.setPercent();

            if (bcf.ShowDialog() == DialogResult.OK)
            {
                Code("bcont-Exclamation-apc:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString + ":" + mi.Text);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (compVal.SelectedItem == null) MessageBox.Show("Bitte einen Vergleichwert auswählen!");
            else
                if (CheckQ())
                {
                    BControlForm bcf = new BControlForm();
                    bcf.setPercent();

                    if (bcf.ShowDialog() == DialogResult.OK)
                    {
                        Code("bcont-Exclamation-nps:" + qid + ":" + Precision.Value + ":" + getPersons() + ":" + compVal.SelectedIndex + ":" + bcf.IString);
                    }
                }
        }
    }
}