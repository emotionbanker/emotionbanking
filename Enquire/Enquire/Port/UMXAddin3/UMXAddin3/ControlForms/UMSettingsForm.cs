using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using umfrage2;
using umfrage2._2008.Dialogs;
using umfrage2._2008.Tools;
using umfrage2._2008.Controls;

namespace UMXAddin3
{
    public partial class UMSettingsForm : Form
    {
        public static string VERSION_DATE = "25.03.2010";
        public Evaluation[] multiEvals;
        public string[] multiTargets;
        public Evaluation eval;
        public Microsoft.Office.Interop.Word.Document doc = null;
        public Microsoft.Office.Interop.PowerPoint.Presentation pres = null;

        public AppType AType
        {
            get
            {
                if (doc != null) return AppType.Word;
                else return AppType.PowerPoint;
            }
        }

        public UMSettingsForm()
        {
            InitializeComponent();

            eval = null;
            multiEvals = new Evaluation[5];
            multiTargets = new string[5];

            SetInfo();
        }

        public UMSettingsForm(Evaluation eval, Evaluation[] mEvals, string[] mtargets, Microsoft.Office.Interop.Word.Document doc)
        {
            InitializeComponent();

            multiEvals = mEvals;
            multiTargets = mtargets;
            this.eval = eval;
            this.doc = doc;

            SetInfo();
        }

        public UMSettingsForm(Evaluation eval, Evaluation[] mEvals, string[] mtargets, Microsoft.Office.Interop.PowerPoint.Presentation pres)
        {
            InitializeComponent();

            this.eval = eval;
            this.pres = pres;
            multiEvals = mEvals;
            multiTargets = mtargets;

            SetInfo();
        }

        private void setProp(string prop, string val)
        {
            if (AType == AppType.PowerPoint)
                Tools.SetPPtDocumentPropertyValue(pres, prop, val);
            else if (AType == AppType.Word)
                Tools.SetWordDocumentPropertyValue(doc, prop, val);
        }

        private string getProp(string prop)
        {
            string target = "";

            if (AType == AppType.PowerPoint)
            {
                target = Tools.GetPPtDocumentPropertyValue(pres, prop);
            }
            else if (AType == AppType.Word)
            {
                target = (string)Tools.GetWordDocumentPropertyValue(doc, prop);
            }

            return target;
        }


        private void SetInfo()
        {
            
            if (eval == null) SourceLabel.Text = "Keine Umfragedaten geladen";
            else SourceLabel.Text = eval.DatabaseName + "/" + eval.lastResultUpdate.ToShortDateString();

            if (eval != null)
            {
                if (AType == AppType.PowerPoint)
                    Tools.SetPPtDocumentPropertyValue(pres, "umo:filename", eval.FileName);
                else if (AType == AppType.Word)
                    Tools.SetWordDocumentPropertyValue(doc, "umo:filename", eval.FileName);


                string target = null;

                if (AType == AppType.PowerPoint)
                {
                    target = Tools.GetPPtDocumentPropertyValue(pres, "umo:target");
                }
                else if (AType == AppType.Word)
                {
                    target = (string)Tools.GetWordDocumentPropertyValue(doc, "umo:target");
                }

                foreach (TargetData td in eval.CombinedTargets)
                {

                    td.ComputeSplits(eval);

                    TargetBox.Items.Add(td);

                    if (target != null && target.Equals(td.Name))
                        TargetBox.SelectedItem = td;
                }
            }

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            label4.Text = VERSION_DATE + " build " + version.Build;

            label2.Text = umfrage2.SystemTools.GetAppPath();


            //multis
            if (multiEvals[0] != null)
            {
                srcLabel1.Text = multiEvals[0].DatabaseName + "/" + multiEvals[0].lastResultUpdate.ToShortDateString();
                setProp("umo:file0", multiEvals[0].FileName);
                string target = getProp("umo:mtarget0");
                foreach (TargetData td in multiEvals[0].CombinedTargets)
                {
                    td.ComputeSplits(eval);
                    tBox1.Items.Add(td);
                    if (target != null && target.Equals(td.Name))
                        tBox1.SelectedItem = td;
                }
            }
            else
            {
                srcLabel1.Text = "keine Daten geladen";
            }

            if (multiEvals[1] != null)
            {
                srcLabel2.Text = multiEvals[1].DatabaseName + "/" + multiEvals[1].lastResultUpdate.ToShortDateString();
                setProp("umo:file1", multiEvals[1].FileName);
                string target = getProp("umo:mtarget1");
                foreach (TargetData td in multiEvals[1].CombinedTargets)
                {
                    td.ComputeSplits(eval);
                    tBox2.Items.Add(td);
                    if (target != null && target.Equals(td.Name))
                        tBox2.SelectedItem = td;
                }
            }
            else
            {
                srcLabel2.Text = "keine Daten geladen";
            }

            if (multiEvals[2] != null)
            {
                srcLabel3.Text = multiEvals[2].DatabaseName + "/" + multiEvals[2].lastResultUpdate.ToShortDateString();
                setProp("umo:file2", multiEvals[2].FileName);
                string target = getProp("umo:mtarget2");
                foreach (TargetData td in multiEvals[2].CombinedTargets)
                {
                    td.ComputeSplits(eval);
                    tBox3.Items.Add(td);
                    if (target != null && target.Equals(td.Name))
                        tBox3.SelectedItem = td;
                }
            }
            else
            {
                srcLabel3.Text = "keine Daten geladen";
            }

            if (multiEvals[3] != null)
            {
                srcLabel4.Text = multiEvals[3].DatabaseName + "/" + multiEvals[3].lastResultUpdate.ToShortDateString();
                setProp("umo:file3", multiEvals[3].FileName);
                string target = getProp("umo:mtarget3");
                foreach (TargetData td in multiEvals[3].CombinedTargets)
                {
                    td.ComputeSplits(eval);
                    tBox4.Items.Add(td);
                    if (target != null && target.Equals(td.Name))
                        tBox4.SelectedItem = td;
                }
            }
            else
            {
                srcLabel4.Text = "keine Daten geladen";
            }

            if (multiEvals[4] != null)
            {
                srcLabel5.Text = multiEvals[4].DatabaseName + "/" + multiEvals[40].lastResultUpdate.ToShortDateString();
                setProp("umo:file4", multiEvals[4].FileName);
                string target = getProp("umo:mtarget4");
                foreach (TargetData td in multiEvals[4].CombinedTargets)
                {
                    td.ComputeSplits(eval);
                    tBox5.Items.Add(td);
                    if (target != null && target.Equals(td.Name))
                        tBox5.SelectedItem = td;
                }
            }
            else
            {
                srcLabel5.Text = "keine Daten geladen";
            }
        }

        private void UMSettingsForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            Brush b = new LinearGradientBrush(r, Color.FromArgb(242, 248, 254), Color.FromArgb(194, 211, 255), 0, true);

            g.FillRectangle(b, r);
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (openMultipartDialog.ShowDialog() == DialogResult.OK)
            {
                eval = Tools.LoadEval(openMultipartDialog.FileName);
                SetInfo();
            }
        }

        private void ReComp_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            Close();
        }

        private void setTargetProps(string prop, TargetData sel)
        {
            if (sel != null)
            {
                if (AType == AppType.PowerPoint)
                {
                    Tools.SetPPtDocumentPropertyValue(pres, prop, sel.Name);
                }
                else if (AType == AppType.Word)
                {
                    Tools.SetWordDocumentPropertyValue(doc, prop, sel.Name);
                }
            }
        }

        private void TargetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TargetData sel = (TargetData) TargetBox.SelectedItem;

            if (sel != null) 
            {
                if (AType == AppType.PowerPoint)
                {
                    Tools.SetPPtDocumentPropertyValue(pres, "umo:target", sel.Name);
                }
                else if (AType == AppType.Word)
                {
                    Tools.SetWordDocumentPropertyValue(doc, "umo:target", sel.Name);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openMultipartDialog.ShowDialog() == DialogResult.OK)
            {
                multiEvals[0] = Tools.LoadEval(openMultipartDialog.FileName);
                SetInfo();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openMultipartDialog.ShowDialog() == DialogResult.OK)
            {
                multiEvals[1] = Tools.LoadEval(openMultipartDialog.FileName);
                SetInfo();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openMultipartDialog.ShowDialog() == DialogResult.OK)
            {
                multiEvals[2] = Tools.LoadEval(openMultipartDialog.FileName);
                SetInfo();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openMultipartDialog.ShowDialog() == DialogResult.OK)
            {
                multiEvals[3] = Tools.LoadEval(openMultipartDialog.FileName);
                SetInfo();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openMultipartDialog.ShowDialog() == DialogResult.OK)
            {
                multiEvals[4] = Tools.LoadEval(openMultipartDialog.FileName);
                SetInfo();
            }
        }

        private void tBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTargetProps("umo:mtarget0", (TargetData)tBox1.SelectedItem);
        }

        private void tBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTargetProps("umo:mtarget1", (TargetData)tBox2.SelectedItem);
        }

        private void tBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTargetProps("umo:mtarget2", (TargetData)tBox3.SelectedItem);
        }

        private void tBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTargetProps("umo:mtarget3", (TargetData)tBox4.SelectedItem);
        }

        private void tBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTargetProps("umo:mtarget4", (TargetData)tBox5.SelectedItem);
        }

        private void SetPlaceholders_Click(object sender, EventArgs e)
        {
            if (eval != null)
            {
                ControlForms.SetPlaceholderForm spf = new UMXAddin3.ControlForms.SetPlaceholderForm(eval);
                spf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bitte zuerst die Umfragedaten laden", "Keine Umfragedaten", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}