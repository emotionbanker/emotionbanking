namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    partial class UMSettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EndButton = new System.Windows.Forms.Button();
            this.TargetBox = new System.Windows.Forms.ComboBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.openMultipartDialog = new System.Windows.Forms.OpenFileDialog();
            this.ReComp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tBox5 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.srcLabel5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tBox4 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.srcLabel4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tBox3 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.srcLabel3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.srcLabel2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.srcLabel1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SetPlaceholders = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(203, 190);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(147, 31);
            this.EndButton.TabIndex = 2;
            this.EndButton.Text = "OK";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // TargetBox
            // 
            this.TargetBox.FormattingEnabled = true;
            this.TargetBox.Location = new System.Drawing.Point(6, 19);
            this.TargetBox.Name = "TargetBox";
            this.TargetBox.Size = new System.Drawing.Size(310, 21);
            this.TargetBox.TabIndex = 4;
            this.TargetBox.SelectedIndexChanged += new System.EventHandler(this.TargetBox_SelectedIndexChanged);
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.SystemColors.Control;
            this.LoadButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoadButton.Location = new System.Drawing.Point(204, 21);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(112, 33);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "laden...";
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.BackColor = System.Drawing.Color.Transparent;
            this.SourceLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SourceLabel.Location = new System.Drawing.Point(16, 31);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(65, 13);
            this.SourceLabel.TabIndex = 1;
            this.SourceLabel.Text = "SourceLabel";
            // 
            // openMultipartDialog
            // 
            this.openMultipartDialog.DefaultExt = "um3";
            this.openMultipartDialog.Filter = "Umfragedaten|*.um2;*.um3";
            // 
            // ReComp
            // 
            this.ReComp.Location = new System.Drawing.Point(203, 227);
            this.ReComp.Name = "ReComp";
            this.ReComp.Size = new System.Drawing.Size(147, 31);
            this.ReComp.TabIndex = 3;
            this.ReComp.Text = "Dokument neu berechnen";
            this.ReComp.UseVisualStyleBackColor = true;
            this.ReComp.Click += new System.EventHandler(this.ReComp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(21, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Version:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(73, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "20090826-A";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 168);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Primäre Datenquelle";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SourceLabel);
            this.groupBox3.Controls.Add(this.LoadButton);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 68);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Umfragedaten";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.TargetBox);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(6, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 59);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bank";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(33, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pfad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(73, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "20090826-A";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.tBox5);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.srcLabel5);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.tBox4);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.srcLabel4);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.tBox3);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.srcLabel3);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.tBox2);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.srcLabel2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tBox1);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.srcLabel1);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox4.Location = new System.Drawing.Point(361, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(370, 299);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Zusätzliche Datenquellen (Vergleiche)";
            // 
            // tBox5
            // 
            this.tBox5.FormattingEnabled = true;
            this.tBox5.Location = new System.Drawing.Point(111, 265);
            this.tBox5.Name = "tBox5";
            this.tBox5.Size = new System.Drawing.Size(252, 21);
            this.tBox5.TabIndex = 25;
            this.tBox5.SelectedIndexChanged += new System.EventHandler(this.tBox5_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(259, 240);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 22);
            this.button5.TabIndex = 24;
            this.button5.Text = "laden...";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // srcLabel5
            // 
            this.srcLabel5.AutoSize = true;
            this.srcLabel5.BackColor = System.Drawing.Color.Transparent;
            this.srcLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.srcLabel5.Location = new System.Drawing.Point(108, 245);
            this.srcLabel5.Name = "srcLabel5";
            this.srcLabel5.Size = new System.Drawing.Size(105, 13);
            this.srcLabel5.TabIndex = 23;
            this.srcLabel5.Text = "keine Daten geladen";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(6, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Vergleichsdaten 5:";
            // 
            // tBox4
            // 
            this.tBox4.FormattingEnabled = true;
            this.tBox4.Location = new System.Drawing.Point(111, 212);
            this.tBox4.Name = "tBox4";
            this.tBox4.Size = new System.Drawing.Size(252, 21);
            this.tBox4.TabIndex = 21;
            this.tBox4.SelectedIndexChanged += new System.EventHandler(this.tBox4_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(259, 187);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 22);
            this.button4.TabIndex = 20;
            this.button4.Text = "laden...";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // srcLabel4
            // 
            this.srcLabel4.AutoSize = true;
            this.srcLabel4.BackColor = System.Drawing.Color.Transparent;
            this.srcLabel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.srcLabel4.Location = new System.Drawing.Point(108, 192);
            this.srcLabel4.Name = "srcLabel4";
            this.srcLabel4.Size = new System.Drawing.Size(105, 13);
            this.srcLabel4.TabIndex = 19;
            this.srcLabel4.Text = "keine Daten geladen";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(6, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Vergleichsdaten 4:";
            // 
            // tBox3
            // 
            this.tBox3.FormattingEnabled = true;
            this.tBox3.Location = new System.Drawing.Point(111, 159);
            this.tBox3.Name = "tBox3";
            this.tBox3.Size = new System.Drawing.Size(252, 21);
            this.tBox3.TabIndex = 17;
            this.tBox3.SelectedIndexChanged += new System.EventHandler(this.tBox3_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(259, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 22);
            this.button3.TabIndex = 16;
            this.button3.Text = "laden...";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // srcLabel3
            // 
            this.srcLabel3.AutoSize = true;
            this.srcLabel3.BackColor = System.Drawing.Color.Transparent;
            this.srcLabel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.srcLabel3.Location = new System.Drawing.Point(108, 139);
            this.srcLabel3.Name = "srcLabel3";
            this.srcLabel3.Size = new System.Drawing.Size(105, 13);
            this.srcLabel3.TabIndex = 15;
            this.srcLabel3.Text = "keine Daten geladen";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(6, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Vergleichsdaten 3:";
            // 
            // tBox2
            // 
            this.tBox2.FormattingEnabled = true;
            this.tBox2.Location = new System.Drawing.Point(111, 103);
            this.tBox2.Name = "tBox2";
            this.tBox2.Size = new System.Drawing.Size(252, 21);
            this.tBox2.TabIndex = 13;
            this.tBox2.SelectedIndexChanged += new System.EventHandler(this.tBox2_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(259, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 22);
            this.button2.TabIndex = 12;
            this.button2.Text = "laden...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // srcLabel2
            // 
            this.srcLabel2.AutoSize = true;
            this.srcLabel2.BackColor = System.Drawing.Color.Transparent;
            this.srcLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.srcLabel2.Location = new System.Drawing.Point(108, 83);
            this.srcLabel2.Name = "srcLabel2";
            this.srcLabel2.Size = new System.Drawing.Size(105, 13);
            this.srcLabel2.TabIndex = 11;
            this.srcLabel2.Text = "keine Daten geladen";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(6, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Vergleichsdaten 2:";
            // 
            // tBox1
            // 
            this.tBox1.FormattingEnabled = true;
            this.tBox1.Location = new System.Drawing.Point(111, 50);
            this.tBox1.Name = "tBox1";
            this.tBox1.Size = new System.Drawing.Size(252, 21);
            this.tBox1.TabIndex = 9;
            this.tBox1.SelectedIndexChanged += new System.EventHandler(this.tBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(259, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 22);
            this.button1.TabIndex = 8;
            this.button1.Text = "laden...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // srcLabel1
            // 
            this.srcLabel1.AutoSize = true;
            this.srcLabel1.BackColor = System.Drawing.Color.Transparent;
            this.srcLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.srcLabel1.Location = new System.Drawing.Point(108, 30);
            this.srcLabel1.Name = "srcLabel1";
            this.srcLabel1.Size = new System.Drawing.Size(105, 13);
            this.srcLabel1.TabIndex = 7;
            this.srcLabel1.Text = "keine Daten geladen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Vergleichsdaten 1:";
            // 
            // SetPlaceholders
            // 
            this.SetPlaceholders.Location = new System.Drawing.Point(12, 190);
            this.SetPlaceholders.Name = "SetPlaceholders";
            this.SetPlaceholders.Size = new System.Drawing.Size(185, 31);
            this.SetPlaceholders.TabIndex = 12;
            this.SetPlaceholders.Text = "Platzhalter setzen...";
            this.SetPlaceholders.UseVisualStyleBackColor = true;
            this.SetPlaceholders.Click += new System.EventHandler(this.SetPlaceholders_Click);
            // 
            // UMSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 317);
            this.Controls.Add(this.SetPlaceholders);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ReComp);
            this.Controls.Add(this.EndButton);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UMSettingsForm";
            this.ShowInTaskbar = false;
            this.Text = "Umfrageverwaltung - AddIn Einstellungen";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UMSettingsForm_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.OpenFileDialog openMultipartDialog;
        private System.Windows.Forms.Button ReComp;
        private System.Windows.Forms.ComboBox TargetBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label srcLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox tBox5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label srcLabel5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox tBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label srcLabel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox tBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label srcLabel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox tBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label srcLabel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tBox1;
        private System.Windows.Forms.Button SetPlaceholders;
    }
}