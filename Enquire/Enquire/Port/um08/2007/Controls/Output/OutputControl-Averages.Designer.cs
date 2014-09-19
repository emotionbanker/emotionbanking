using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_Averages
    {

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.QRemove = new System.Windows.Forms.Button();
            this.QAdd = new System.Windows.Forms.Button();
            this.QBox = new System.Windows.Forms.ListBox();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.precControl = new System.Windows.Forms.NumericUpDown();
            this.AvgBox = new System.Windows.Forms.CheckBox();
            this.AvgMedian = new System.Windows.Forms.CheckBox();
            this.PcntBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GoButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.precControl)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Personengruppen.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(11, 161);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(250, 64);
            this.crossPanel.TabIndex = 48;
            this.crossPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.crossPanel_Paint);
            // 
            // PersonPanel
            // 
            this.PersonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPanel.Location = new System.Drawing.Point(3, 16);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Padding = new System.Windows.Forms.Padding(15);
            this.PersonPanel.Size = new System.Drawing.Size(269, 186);
            this.PersonPanel.TabIndex = 47;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.Transparent;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(222, 70);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(39, 37);
            this.QRemove.TabIndex = 43;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new System.EventHandler(this.QRemove_Click);
            // 
            // QAdd
            // 
            this.QAdd.BackColor = System.Drawing.Color.Transparent;
            this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QAdd.Location = new System.Drawing.Point(222, 25);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new System.Drawing.Size(39, 39);
            this.QAdd.TabIndex = 42;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            this.QAdd.Click += new System.EventHandler(this.QAdd_Click);
            // 
            // QBox
            // 
            this.QBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.Location = new System.Drawing.Point(11, 25);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(206, 119);
            this.QBox.TabIndex = 41;
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.SystemColors.Window;
            this.resultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultBox.Location = new System.Drawing.Point(10, 10);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(481, 530);
            this.resultBox.TabIndex = 49;
            this.resultBox.Text = "";
            this.resultBox.WordWrap = false;
            this.resultBox.TextChanged += new System.EventHandler(this.resultBox_TextChanged_1);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(117, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 50;
            this.label3.Text = "Genauigkeit";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // precControl
            // 
            this.precControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.precControl.Location = new System.Drawing.Point(221, 32);
            this.precControl.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.precControl.Name = "precControl";
            this.precControl.Size = new System.Drawing.Size(33, 20);
            this.precControl.TabIndex = 51;
            this.precControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.precControl.ValueChanged += new System.EventHandler(this.precControl_ValueChanged);
            // 
            // AvgBox
            // 
            this.AvgBox.Checked = true;
            this.AvgBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AvgBox.Location = new System.Drawing.Point(18, 32);
            this.AvgBox.Name = "AvgBox";
            this.AvgBox.Size = new System.Drawing.Size(117, 20);
            this.AvgBox.TabIndex = 52;
            this.AvgBox.Text = "Mittelwerte";
            this.AvgBox.CheckedChanged += new System.EventHandler(this.AvgBox_CheckedChanged);
            // 
            // AvgMedian
            // 
            this.AvgMedian.Location = new System.Drawing.Point(18, 58);
            this.AvgMedian.Name = "AvgMedian";
            this.AvgMedian.Size = new System.Drawing.Size(92, 20);
            this.AvgMedian.TabIndex = 53;
            this.AvgMedian.Text = "Mediane";
            this.AvgMedian.CheckedChanged += new System.EventHandler(this.AvgMedian_CheckedChanged);
            // 
            // PcntBox
            // 
            this.PcntBox.Location = new System.Drawing.Point(18, 83);
            this.PcntBox.Name = "PcntBox";
            this.PcntBox.Size = new System.Drawing.Size(104, 20);
            this.PcntBox.TabIndex = 54;
            this.PcntBox.Text = "Prozente";
            this.PcntBox.CheckedChanged += new System.EventHandler(this.PcntBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.GoButton);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Personengruppen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(491, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 530);
            this.panel1.TabIndex = 55;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.White;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoButton.Image = Resources.shell32_dll_I00f6_0409;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(11, 15);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(275, 42);
            this.GoButton.TabIndex = 58;
            this.GoButton.Text = "Auswerten";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QBox);
            this.groupBox1.Controls.Add(this.crossPanel);
            this.groupBox1.Controls.Add(this.QRemove);
            this.groupBox1.Controls.Add(this.QAdd);
            this.groupBox1.Location = new System.Drawing.Point(11, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 231);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daten";
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.PersonPanel);
            this.Personengruppen.Location = new System.Drawing.Point(11, 309);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Size = new System.Drawing.Size(275, 205);
            this.Personengruppen.TabIndex = 57;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Personengruppen";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 540);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel2.Size = new System.Drawing.Size(780, 150);
            this.panel2.TabIndex = 56;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.AvgBox);
            this.groupBox2.Controls.Add(this.precControl);
            this.groupBox2.Controls.Add(this.AvgMedian);
            this.groupBox2.Controls.Add(this.PcntBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 140);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Einstellungen";
            // 
            // NBox
            // 
            this.NBox.Location = new System.Drawing.Point(141, 83);
            this.NBox.Name = "NBox";
            this.NBox.Size = new System.Drawing.Size(151, 20);
            this.NBox.TabIndex = 55;
            this.NBox.Text = "Stichprobengröße";
            this.NBox.CheckedChanged += new System.EventHandler(this.NBox_CheckedChanged);
            // 
            // OutputControl_Averages
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "OutputControl_Averages";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(800, 700);
            this.Load += new System.EventHandler(this.OutputControl_Averages_Load_4);
            ((System.ComponentModel.ISupportInitialize)(this.precControl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox PcntBox;
        private System.Windows.Forms.CheckBox AvgMedian;
        private System.Windows.Forms.CheckBox AvgBox;
        private System.Windows.Forms.NumericUpDown precControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Panel PersonPanel;
        private System.Windows.Forms.Button QRemove;
        private System.Windows.Forms.Button QAdd;
        private System.Windows.Forms.ListBox QBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox Personengruppen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.CheckBox NBox;

    }
}
