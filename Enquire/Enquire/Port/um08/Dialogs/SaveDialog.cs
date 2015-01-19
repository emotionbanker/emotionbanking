using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
    public class SaveDialog : DialogTemplate
    {
        private Label label2;
        private TextBox PathBox;
        private Button BrowseButton;
        private Label label3;
        private Button SaveButton;
        private Button EndButton;
        private FolderBrowserDialog Browser;
        private TextBox NameBox;
        private IContainer components = null;
        private GroupBox targetBox;

        private Output.Output output;
        private Button AlleAbwaehlen;
        private Button Alleauswählen;
        private Button button1;
        private Button button2;

        private ChooseTargetControl TargetSelector;


        public SaveDialog(Output.Output output)
        {
            this.output = output;

            InitializeComponent();

            this.NameBox.Text = output.Name;
            this.CancelButton = EndButton;

            TargetSelector = new ChooseTargetControl(output.eval);
            TargetSelector.Dock = DockStyle.Fill;

            targetBox.Controls.Add(TargetSelector);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new Label();
            this.PathBox = new TextBox();
            this.BrowseButton = new Button();
            this.NameBox = new TextBox();
            this.label3 = new Label();
            this.SaveButton = new Button();
            this.EndButton = new Button();
            this.Browser = new FolderBrowserDialog();
            this.targetBox = new GroupBox();
            this.AlleAbwaehlen = new Button();
            this.Alleauswählen = new Button();
            this.button1 = new Button();
            this.button2 = new Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = Color.Transparent;
            this.label2.Location = new Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(94, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ordner:";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PathBox
            // 
            this.PathBox.BorderStyle = BorderStyle.FixedSingle;
            this.PathBox.Location = new Point(109, 20);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new Size(300, 20);
            this.PathBox.TabIndex = 6;
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = Color.White;
            this.BrowseButton.FlatStyle = FlatStyle.Popup;
            this.BrowseButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0005_0409;
            this.BrowseButton.Location = new Point(414, 15);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new Size(27, 26);
            this.BrowseButton.TabIndex = 11;
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new EventHandler(this.BrowseButton_Click);
            // 
            // NameBox
            // 
            this.NameBox.BorderStyle = BorderStyle.FixedSingle;
            this.NameBox.Location = new Point(109, 52);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new Size(300, 20);
            this.NameBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.BackColor = Color.Transparent;
            this.label3.Location = new Point(10, 50);
            this.label3.Name = "label3";
            this.label3.Size = new Size(94, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Bezeichnung:";
            this.label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = Color.White;
            this.SaveButton.FlatStyle = FlatStyle.Popup;
            this.SaveButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I4179_0409;
            this.SaveButton.ImageAlign = ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new Point(446, 231);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(140, 30);
            this.SaveButton.TabIndex = 17;
            this.SaveButton.Text = "       Speichern";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.BackColor = Color.White;
            this.EndButton.FlatStyle = FlatStyle.Popup;
            this.EndButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00f0_0409;
            this.EndButton.ImageAlign = ContentAlignment.MiddleLeft;
            this.EndButton.Location = new Point(446, 267);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new Size(140, 30);
            this.EndButton.TabIndex = 18;
            this.EndButton.Text = "       Abbrechen";
            this.EndButton.UseVisualStyleBackColor = false;
            // 
            // targetBox
            // 
            this.targetBox.Location = new Point(109, 86);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new Size(300, 211);
            this.targetBox.TabIndex = 19;
            this.targetBox.TabStop = false;
            this.targetBox.Text = "Zielauswahl";
            // 
            // button1
            // 
            this.button1.BackColor = Color.White;
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.ImageAlign = ContentAlignment.MiddleLeft;
            this.button1.Location = new Point(446, 131);
            this.button1.Name = "button1";
            this.button1.Size = new Size(140, 30);
            this.button1.TabIndex = 20;
            this.button1.Text = "alle abwählen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = Color.White;
            this.button2.FlatStyle = FlatStyle.Popup;
            this.button2.ImageAlign = ContentAlignment.MiddleLeft;
            this.button2.Location = new Point(446, 95);
            this.button2.Name = "button2";
            this.button2.Size = new Size(140, 30);
            this.button2.TabIndex = 21;
            this.button2.Text = "alle auswählen";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new EventHandler(this.button2_Click);
            // 
            // SaveDialog
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.White;
            this.ClientSize = new Size(715, 315);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.targetBox);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.label2);
            this.Name = "SaveDialog";
            this.Text = "Speichern...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle sizeNow = new Rectangle(0, 0, this.Width, this.Height);

            if (Enabled)
            {
                Graphics g = e.Graphics;

                Brush b = new LinearGradientBrush(sizeNow, Color.FromArgb(242, 248, 254), Color.FromArgb(194, 211, 255), 0, true);

                g.FillRectangle(b, 0, 0, this.Width, this.Height);
            }

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (Browser.ShowDialog() == DialogResult.OK)
            {
                PathBox.Text = Browser.SelectedPath;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameBox.Text == "")
            {
                MessageBox.Show("Bitte geben Sie eine Bezeichnung an!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Directory.Exists(PathBox.Text))
            {
                MessageBox.Show("Der ausgewählte Ordner existiert nicht!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Enabled = false;

            DialogShortmessage saving = new DialogShortmessage("werte aus/speichere...");
            saving.Location = new Point(this.Location.X + this.Size.Width / 2 - saving.Width / 2, this.Location.Y + this.Size.Height / 2 - saving.Height / 2);
            saving.Show();
            Refresh();
            saving.Refresh();

            //MessageBox.Show("NameBox.Text: " + NameBox.Text + "\nPathBox.Text: " + PathBox.Text);
            //NameBox.Text = NameBox.Text.Substring(0, NameBox.Text.LastIndexOf('.'));
            //NameBox.Text += ".xlsx";
            output.Save(NameBox.Text, PathBox.Text);

            this.Enabled = true;
            saving.Close();

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TargetData[] t = output.eval.CombinedTargets;

            for (int i = 0; i < output.eval.CombinedTargets.Length; i++)
            {
                t[i].Included = true;
            }
            output.eval.targetCombosChanged(this);

            TargetSelector = new ChooseTargetControl(output.eval);
            TargetSelector.Dock = DockStyle.Fill;

            targetBox.Controls.Add(TargetSelector);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TargetData[] t = output.eval.CombinedTargets;

            for (int i = 0; i < output.eval.CombinedTargets.Length; i++)
            {
                t[i].Included = false;
            }
            output.eval.targetCombosChanged(this);

            TargetSelector = new ChooseTargetControl(output.eval);
            TargetSelector.Dock = DockStyle.Fill;

            targetBox.Controls.Add(TargetSelector);
        }
    }
}

