using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_Potential
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.QFontDialog = new System.Windows.Forms.FontDialog();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChooseSub = new System.Windows.Forms.Button();
            this.ChooseMaster = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RefBox = new System.Windows.Forms.ComboBox();
            this.ReferenceBox = new System.Windows.Forms.CheckBox();
            this.MinSlider = new System.Windows.Forms.NumericUpDown();
            this.EnableMin = new System.Windows.Forms.CheckBox();
            this.CheckPercent = new System.Windows.Forms.CheckBox();
            this.InvertBox = new System.Windows.Forms.CheckBox();
            this.SortBox = new System.Windows.Forms.ComboBox();
            this.DesignButton = new System.Windows.Forms.Button();
            this.sizeControl = new SizeControl();
            this.previewBox = new PreviewControl();
            this.panel1.SuspendLayout();
            this.Personengruppen.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(6, 95);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(188, 52);
            this.crossPanel.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Personengruppen);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.GoButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(368, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 403);
            this.panel1.TabIndex = 68;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.panel3);
            this.Personengruppen.Location = new System.Drawing.Point(10, 221);
            this.Personengruppen.Margin = new System.Windows.Forms.Padding(2);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Padding = new System.Windows.Forms.Padding(2);
            this.Personengruppen.Size = new System.Drawing.Size(206, 148);
            this.Personengruppen.TabIndex = 90;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Personengruppen";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 15);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panel3.Size = new System.Drawing.Size(202, 131);
            this.panel3.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChooseSub);
            this.groupBox1.Controls.Add(this.ChooseMaster);
            this.groupBox1.Controls.Add(this.crossPanel);
            this.groupBox1.Location = new System.Drawing.Point(10, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 161);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daten";
            // 
            // ChooseSub
            // 
            this.ChooseSub.BackColor = System.Drawing.Color.Transparent;
            this.ChooseSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChooseSub.Location = new System.Drawing.Point(6, 19);
            this.ChooseSub.Name = "ChooseSub";
            this.ChooseSub.Size = new System.Drawing.Size(188, 32);
            this.ChooseSub.TabIndex = 60;
            this.ChooseSub.Text = "Wertungsfrage: Keine";
            this.ChooseSub.UseVisualStyleBackColor = false;
            this.ChooseSub.Click += new System.EventHandler(this.ChooseSub_Click);
            // 
            // ChooseMaster
            // 
            this.ChooseMaster.BackColor = System.Drawing.Color.Transparent;
            this.ChooseMaster.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChooseMaster.Location = new System.Drawing.Point(6, 57);
            this.ChooseMaster.Name = "ChooseMaster";
            this.ChooseMaster.Size = new System.Drawing.Size(188, 32);
            this.ChooseMaster.TabIndex = 59;
            this.ChooseMaster.Text = "Teilungsfrage: Keine";
            this.ChooseMaster.UseVisualStyleBackColor = false;
            this.ChooseMaster.Click += new System.EventHandler(this.ChooseMaster_Click);
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.White;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoButton.Image = Resources.shell32_dll_I00f6_0409;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(10, 14);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(206, 34);
            this.GoButton.TabIndex = 89;
            this.GoButton.Text = "Auswerten";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(8, 411);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 150);
            this.panel2.TabIndex = 69;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RefBox);
            this.groupBox2.Controls.Add(this.ReferenceBox);
            this.groupBox2.Controls.Add(this.MinSlider);
            this.groupBox2.Controls.Add(this.EnableMin);
            this.groupBox2.Controls.Add(this.CheckPercent);
            this.groupBox2.Controls.Add(this.InvertBox);
            this.groupBox2.Controls.Add(this.SortBox);
            this.groupBox2.Controls.Add(this.DesignButton);
            this.groupBox2.Controls.Add(this.sizeControl);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 150);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Einstellungen";
            // 
            // RefBox
            // 
            this.RefBox.FormattingEnabled = true;
            this.RefBox.Location = new System.Drawing.Point(370, 49);
            this.RefBox.Name = "RefBox";
            this.RefBox.Size = new System.Drawing.Size(142, 21);
            this.RefBox.TabIndex = 77;
            this.RefBox.SelectedIndexChanged += new System.EventHandler(this.RefBox_SelectedIndexChanged);
            // 
            // ReferenceBox
            // 
            this.ReferenceBox.AutoSize = true;
            this.ReferenceBox.Location = new System.Drawing.Point(347, 26);
            this.ReferenceBox.Name = "ReferenceBox";
            this.ReferenceBox.Size = new System.Drawing.Size(183, 17);
            this.ReferenceBox.TabIndex = 76;
            this.ReferenceBox.Text = "Referenzwert (Aus Teilungsfrage)";
            this.ReferenceBox.UseVisualStyleBackColor = true;
            this.ReferenceBox.CheckedChanged += new System.EventHandler(this.ReferenceBox_CheckedChanged);
            // 
            // MinSlider
            // 
            this.MinSlider.Location = new System.Drawing.Point(221, 109);
            this.MinSlider.Name = "MinSlider";
            this.MinSlider.Size = new System.Drawing.Size(57, 20);
            this.MinSlider.TabIndex = 75;
            this.MinSlider.ValueChanged += new System.EventHandler(this.MinSlider_ValueChanged);
            this.MinSlider.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MinSlider_KeyUp);
            // 
            // EnableMin
            // 
            this.EnableMin.AutoSize = true;
            this.EnableMin.Location = new System.Drawing.Point(114, 110);
            this.EnableMin.Name = "EnableMin";
            this.EnableMin.Size = new System.Drawing.Size(101, 17);
            this.EnableMin.TabIndex = 74;
            this.EnableMin.Text = "Untergrenze (N)";
            this.EnableMin.UseVisualStyleBackColor = true;
            this.EnableMin.CheckedChanged += new System.EventHandler(this.EnableMin_CheckedChanged);
            // 
            // CheckPercent
            // 
            this.CheckPercent.AutoSize = true;
            this.CheckPercent.Location = new System.Drawing.Point(14, 110);
            this.CheckPercent.Margin = new System.Windows.Forms.Padding(2);
            this.CheckPercent.Name = "CheckPercent";
            this.CheckPercent.Size = new System.Drawing.Size(88, 17);
            this.CheckPercent.TabIndex = 73;
            this.CheckPercent.Text = "Prozentwerte";
            this.CheckPercent.UseVisualStyleBackColor = true;
            this.CheckPercent.CheckedChanged += new System.EventHandler(this.CheckPercent_CheckedChanged);
            // 
            // InvertBox
            // 
            this.InvertBox.AutoSize = true;
            this.InvertBox.Location = new System.Drawing.Point(14, 89);
            this.InvertBox.Margin = new System.Windows.Forms.Padding(2);
            this.InvertBox.Name = "InvertBox";
            this.InvertBox.Size = new System.Drawing.Size(67, 17);
            this.InvertBox.TabIndex = 73;
            this.InvertBox.Text = "Invertiert";
            this.InvertBox.UseVisualStyleBackColor = true;
            this.InvertBox.CheckedChanged += new System.EventHandler(this.InvertBox_CheckedChanged);
            // 
            // SortBox
            // 
            this.SortBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SortBox.Location = new System.Drawing.Point(14, 63);
            this.SortBox.Name = "SortBox";
            this.SortBox.Size = new System.Drawing.Size(180, 21);
            this.SortBox.TabIndex = 72;
            this.SortBox.SelectedIndexChanged += new System.EventHandler(this.SortBox_SelectedIndexChanged);
            // 
            // DesignButton
            // 
            this.DesignButton.BackColor = System.Drawing.Color.White;
            this.DesignButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DesignButton.Image = Resources.shell32_dll_I010e_0409;
            this.DesignButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignButton.Location = new System.Drawing.Point(14, 26);
            this.DesignButton.Name = "DesignButton";
            this.DesignButton.Size = new System.Drawing.Size(179, 31);
            this.DesignButton.TabIndex = 70;
            this.DesignButton.Text = "     Einstellungen...";
            this.DesignButton.UseVisualStyleBackColor = true;
            this.DesignButton.Click += new System.EventHandler(this.DesignButton_Click);
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Transparent;
            this.sizeControl.Location = new System.Drawing.Point(225, 26);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(127, 59);
            this.sizeControl.TabIndex = 53;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Transparent;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(8, 8);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(360, 403);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 50;
            this.previewBox.Load += new System.EventHandler(this.previewBox_Load);
            // 
            // OutputControl_Potential
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OutputControl_Potential";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(600, 569);
            this.panel1.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FontDialog QFontDialog;
        private PreviewControl previewBox;
        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Personengruppen;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DesignButton;
        private SizeControl sizeControl;
        private System.Windows.Forms.Button ChooseMaster;
        private System.Windows.Forms.Button ChooseSub;
        private System.Windows.Forms.ComboBox SortBox;
        private System.Windows.Forms.CheckBox InvertBox;
        private System.Windows.Forms.CheckBox CheckPercent;
        private System.Windows.Forms.CheckBox EnableMin;
        private System.Windows.Forms.NumericUpDown MinSlider;
        private System.Windows.Forms.CheckBox ReferenceBox;
        private System.Windows.Forms.ComboBox RefBox;
    }
}
