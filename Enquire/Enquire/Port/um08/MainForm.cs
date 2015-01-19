using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using Compucare.Enquire.Common.Calculation.Texts.CsvExport.Wizard;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Misc;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Controls;
using System.Threading;

namespace Compucare.Enquire.Legacy.Umfrage2Lib
{
    public partial class MainForm
    {
        
        Evaluation eval;  


        /***
         * 
         * 
         **/
        private string lz(int i)
        {
            if (i >= 10) return i.ToString();
            else return "0" + i;
        }


        /***
        * 
        * 
        **/
        public MainForm()
        {
            InitializeComponent();


            //alle 3 Elemente auf true setzen um das Flimmern zu verringern, Zeichenvorgang wird im Buffer durchgefьhrt
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);  
            
            
            //set file association
            FileAssociation.Register("um2");
            FileAssociation.Register("um3");


            //setzt die Auswertung auf null
            eval = null;

            String architecture = "";

            //IntPtr.Size liefert System Byte zurьck
            if (IntPtr.Size == 4)
            {
                architecture = "32bit";
            }
            else if (IntPtr.Size == 8)
            {
                architecture = "64bit";
            }

            this.Text = "Umfrageverwaltung " + architecture + " - ";

            FileInfo fi = new FileInfo(Application.StartupPath);

            this.Text += lz(fi.LastWriteTime.Day) + "." + lz(fi.LastWriteTime.Month) + "." + lz(fi.LastWriteTime.Year) + " " + lz(fi.LastWriteTime.Hour) + ":" + lz(fi.LastWriteTime.Minute) + ":" + lz(fi.LastWriteTime.Second);

            this.Width = 1024;
            this.Height = 768;
            
            
            Refresh(); // aktualisiert
            
            ControlAccess(); //falls Auswertung = null einige Steuerelemente sind grauhintergelegt
                             //sonst alle Steuerelemente freigegeben

            NothingStatus(); //status = keine Auswertung
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //BackPanel.Refresh();
        }

        private void dateiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void schliessenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            
            //base.OnPaint(e);

            Rectangle sizeNow = new Rectangle(0, 0, this.Width, this.Height);

            if (Enabled)
            {
                Graphics g = e.Graphics;

                Brush b = new LinearGradientBrush(sizeNow, Color.FromArgb(242,248,254), Color.FromArgb(194,211,255), 0, true);

                g.FillRectangle(b, 0, 0, this.Width, this.Height);
            }
            
        }

        /***
        * 
        * 
        **/
        private void NothingStatus()
        {
            Label l = new Label();
            l.Text = "Keine Umfrage geladen";
            l.Width = 200;
            l.TextAlign = ContentAlignment.BottomRight;
            l.Font = Font;
            l.Location = new Point(10,10);

            LoadControl(l, false);
        }

        /***
        * 
        * 
        **/
        private void LoadingStatus(string filename)
        {
            FadeLabel l = new FadeLabel();

            l.Text = "Daten werden geladen...";
            l.Font = Font;

            l.Location = new Point(10,10);

            Label l2 = new Label();
            l2.Text = filename;
            l2.Font = Font;

            l2.Location = new Point(10,40);

            Panel statP = new Panel();
            statP.Controls.Add(l);
            statP.Controls.Add(l2);

            statP.Dock = DockStyle.Fill;

            
            LoadControl(statP, false);

            
        }


        private void toolStrip1_Resize(object sender, EventArgs e)
        {
            //Refresh();
        }

        private void toolStrip1_SizeChanged(object sender, EventArgs e)
        {
            //Refresh();
        }

        /***
        * 
        * 
        **/
        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //this.Enabled = false;
                LoadingStatus(Path.GetFileNameWithoutExtension(openFileDialog1.FileName));

                Thread t = new Thread(new ThreadStart(LoadFile));
                t.Start();
                //Refresh();
             }
        }

        private delegate void LoadSettingsControlDelegate();
        private delegate void SaveSettingsControlDelegate();

        /***
        * 
        * 
        **/
        public void LoadSettingsControl()
        {
            //SettingsControl sc = new SettingsControl(eval);

            string name = eval.DatabaseName;
            if (!eval.DatabasePrefix.Trim().Equals(string.Empty))
                name += "/" + eval.DatabasePrefix;
            
            TitleLabel.Text = name + " (" + eval.LastResultUpdate + ")";
           
            //LoadControl(sc);

            LoadControl(new Panel());

            ControlAccess();
        }

        /***
        * 
        * 
        **/
        private void LoadFile()
        {
            eval = Evaluation.Deserialize(this.openFileDialog1.FileName);

            Invoke(new LoadSettingsControlDelegate(LoadSettingsControl));

            
        }

        /***
        * 
        * 
        **/
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Falls die Auswertung keinen Namen hat d.h. neue Auswertung/keine geöffnete Datei/wurde davor nicht einmal gespeichert
            if (eval.FileName.Equals(string.Empty)){ 
                saveMultipartToolStripMenuItem_Click(this, e); //ruft die Multi-Save Dialog auf
                 //speichernUnterToolStripMenuItem_Click(this, e);
            }else
            {
                //Save();
                umfrage2._2008.Dialogs.MultipartSaveDialog mpsd = new umfrage2._2008.Dialogs.MultipartSaveDialog();
                mpsd.Save(eval, eval.FileName);
            }
        }

        private Control prev;

        /***
        * 
        * 
        **/
        private void Save()
        {
            prev = null;

            try { prev = ContentPanel.Controls[0]; }
            catch {}

            SavingStatus(Path.GetFileNameWithoutExtension(eval.FileName));

            Thread t = new Thread(new ThreadStart(SaveFile));
            t.Start();
        }

        /***
        * 
        * 
        **/
        private void SaveSettingsControl()
        {
            LoadControl(prev);
        }

        /***
        * 
        * 
        **/
        private void SaveFile()
        {
            eval.Serialize();

            Invoke(new SaveSettingsControlDelegate(SaveSettingsControl));
        }


        /***
        * 
        * 
        **/  
        private void SavingStatus(string filename)
        {
            FadeLabel l = new FadeLabel();

            l.Text = "Daten werden gespeichert...";
            l.Font = Font;

            l.Location = new Point((int)(this.Width / 2 - l.Width / 2), (int)(this.Height / 2 - l.Height / 2 - 40));

            Label l2 = new Label();
            l2.Text = filename;
            l2.Font = Font;

            l2.Location = new Point((int)(this.Width / 2 - l2.Width / 2), (int)(this.Height / 2 - l2.Height / 2 - 40) - l.Height);

            Panel statP = new Panel();
            statP.Controls.Add(l);
            statP.Controls.Add(l2);

            statP.Dock = DockStyle.Fill;

            
            LoadControl(statP, false);           
        }

        /***
        * 
        * 
        **/
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl(eval));
        }

        /***
        * 
        * 
        **/
        private void SingleOutputButton_Click(object sender, EventArgs e)
        {
            LoadControl(new SingleControl(eval));
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            LoadControl(new umfrage2._2007.Controls.ReportControl(eval));
        }

        /***
        * 
        * 
        **/
        private void BenchmarkingButton_Click(object sender, EventArgs e)
        {
            LoadControl(new umfrage2._2007.Controls.BenchmarkingControl(eval));
        }

        /***
        * 
        * 
        **/
        private void ScoringButton_Click(object sender, EventArgs e)
        {
            LoadControl(new umfrage2._2007.Controls.ScoringControl(eval));
        }

        /***
        * 
        * 
        **/
        private void HelpButton_Click(object sender, EventArgs e)
        {
            DialogAbout da = new DialogAbout();
            da.ShowDialog();
        }

        /***
        * 
        * 
        **/
        private void NewButton_Click(object sender, EventArgs e)
        {
            eval = new Evaluation();  //neue Auswertung wird erstellt
            TitleLabel.Text = "Neue Auswertung";
            ControlAccess();  //alle Befehle werden sichtbar 
            LoadControl(new Panel());  //LoadControl wird mit neuem Panel erstellt
        }

        /***
        * 
        * 
        **/
        private void LoadControl(Control c)
        {
            LoadControl(c, true);   //
        }

        /***
        * 
        * 
        **/
        private void LoadControl(Control c, bool dock)
        {
            if (dock)
            {
               c.Dock = DockStyle.Fill;
            }

            ContentPanel.Controls.Clear();  // Panel wird cleart
            ContentPanel.Controls.Add(c);   // Label auf Panel positionieren
        }

        private void ContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void ControlAccess()
        {
            bool e = false;

            if (eval != null)
            {
              e = true;
            }

                SettingsButton.Enabled =
                SingleOutputButton.Enabled =
                ReportButton.Enabled =
                BenchmarkingButton.Enabled =
                ScoringButton.Enabled =
                SaveButton.Enabled =
                auswertungToolStripMenuItem.Enabled =
                LoadDataButton.Enabled =
                speichernToolStripMenuItem.Enabled = 
                speichernUnterToolStripMenuItem.Enabled =
                exportImportToolStripMenuItem.Enabled = 
                extrasToolStripMenuItem.Enabled = e;
        }

        /***
        * 
        * 
        **/
        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            LoadControl(new umfrage2._2007.Controls.LoadDataControl(eval));

        }

        private void speichernUnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                eval.FileName = saveFileDialog.FileName;
                Save();
            }
        }

        private void anonymisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eval.Anonymise();
            Refresh();
            InfoBox.Show("Anonymisieren", "Die Zielnamen wurden anonymisiert");
        }

        private void excelDateiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogImport di = new DialogImport(eval, false);
            di.ShowDialog();
        }

        private void ordnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogImport di = new DialogImport(eval, true);
            di.ShowDialog();
        }

        private void textantwortenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveXlsDialog.ShowDialog() == DialogResult.OK)
            {
                DialogExport de = new DialogExport(eval, saveXlsDialog.FileName, false);
                de.ShowDialog();
            }
        }

        private void antwortnummernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveXlsDialog.ShowDialog() == DialogResult.OK)
            {
                DialogExport de = new DialogExport(eval, saveXlsDialog.FileName, true);
                de.ShowDialog();
            }
        }

        private void fragenlisteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogQuestionList dql = new DialogQuestionList(eval);
            dql.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*
            umfrage2._2008.Dialogs.MultipartLoadDialog mpld = new umfrage2._2008.Dialogs.MultipartLoadDialog();
            mpld.LoadFile("C:\\Users\\lukas\\Desktop\\2bsorted\\bb08all.um3");

            this.eval = mpld.eval;
            LoadSettingsControl();
            */
            //LoadControl(new SingleControl(eval));
        }

        private void saveMultipartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveMultipartDialog.ShowDialog() == DialogResult.OK) //Wenn auf ok geklcikt wird
            {
                //-----------speicherOrt von File
                umfrage2._2008.Dialogs.MultipartSaveDialog mpsd = new umfrage2._2008.Dialogs.MultipartSaveDialog();
                mpsd.Save(eval, saveMultipartDialog.FileName);
            }
        }

        private void loadMultipartToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openMultipartToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (openMultipartDialog.ShowDialog() == DialogResult.OK)
            {
                umfrage2._2008.Dialogs.MultipartLoadDialog mpld = new umfrage2._2008.Dialogs.MultipartLoadDialog();
                mpld.LoadFile(openMultipartDialog.FileName);
                this.eval = mpld.eval;
                eval.LoadConvertQuestions();
                LoadSettingsControl();
            }
        }

        private void RemoveDataButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sind Sie sicher dass sie alle Ergebnisdaten löschen wollen?", "Ergebnisse löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (eval != null)
                {
                    eval.RemoveData();
                    MessageBox.Show("Ergebnisdaten wurden gelöscht", "Ergebnisse löschen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void resultStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eval.DebugResultStats();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Question q = eval.global.GetQuestion(1492, eval);

            Console.WriteLine(q.Answers);
        }

        private void user117ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Question q in eval.Global.Questions)
            {
                Console.WriteLine(q.ID + ":\t" + q.GetResultByUserID(117).SelectedAnswer + "\t" + q.GetResultByUserID(117).TextAnswer);
            }
        }

        private void metadatenUndStatistikenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ausfülldauerSplitHalfReliabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MetaData.Compute(eval, sfd.FileName, "splithalf");
            }
        }

        private void antwortverteilungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MetaData.Compute(eval, sfd.FileName, "vert");
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (TargetData td in eval.Targets)
            {
                Console.WriteLine(td.ID + "\t" + td.Name);
                Console.WriteLine();
                if (td.Name.Equals("Sparkasse Kremstal Pyhrn"))
                {
                    Question q = td.GetQuestionById(211);

                    Console.WriteLine(q.Answers);
                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (Result r in q.Results)
                    {
                        if (r.TextAnswer.Contains("Pension")) Console.WriteLine( (i++) + "\t" + r.TextAnswer);
                    }
                }
            }
        }

        private void placeholdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (QuestionPlaceholder ph in eval.QuestionPlaceholders)
            {
                Console.WriteLine(ph.ToString());
                Console.WriteLine("\t" + ph.GetQuestion(eval.Global, eval));
            }
        }

        private void cSVExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsvWizard wiz = new CsvWizard(eval);

            if (wiz.ShowDialog() == DialogResult.OK)
            {
                //do something
            }
        }

        private void Gauge_h056_Click(object sender, EventArgs e)
        {
            LoadControl(new umfrage2._2007.Controls.OutputControl_Gauge_h056(eval));
        }

        private void gaugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadControl(new umfrage2._2007.Controls.OutputControl_Gauge_h056(eval));
        }
    }

}