namespace UMXAddin3.ControlForms
{
    partial class PercentBaseForm
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
            this.OKButton = new System.Windows.Forms.Button();
            this.CButton = new System.Windows.Forms.Button();
            this.qBox = new System.Windows.Forms.TextBox();
            this.SelectQButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SelCrossButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cBox = new System.Windows.Forms.TextBox();
            this.RemoveCross = new System.Windows.Forms.Button();
            this.AddCross = new System.Windows.Forms.Button();
            this.CrossView = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(261, 225);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(110, 27);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CButton
            // 
            this.CButton.Location = new System.Drawing.Point(145, 225);
            this.CButton.Name = "CButton";
            this.CButton.Size = new System.Drawing.Size(110, 27);
            this.CButton.TabIndex = 4;
            this.CButton.Text = "Abbrechen";
            this.CButton.UseVisualStyleBackColor = true;
            this.CButton.Click += new System.EventHandler(this.CButton_Click);
            // 
            // qBox
            // 
            this.qBox.Location = new System.Drawing.Point(77, 23);
            this.qBox.Name = "qBox";
            this.qBox.Size = new System.Drawing.Size(107, 20);
            this.qBox.TabIndex = 55;
            this.qBox.TextChanged += new System.EventHandler(this.qBox_TextChanged);
            // 
            // SelectQButton
            // 
            this.SelectQButton.BackColor = System.Drawing.SystemColors.Control;
            this.SelectQButton.Location = new System.Drawing.Point(190, 19);
            this.SelectQButton.Name = "SelectQButton";
            this.SelectQButton.Size = new System.Drawing.Size(107, 27);
            this.SelectQButton.TabIndex = 54;
            this.SelectQButton.Text = "auswählen";
            this.SelectQButton.UseVisualStyleBackColor = false;
            this.SelectQButton.Click += new System.EventHandler(this.SelectQButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Basisfrage:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SelectQButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.qBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 63);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basis";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.SelCrossButton);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cBox);
            this.groupBox3.Controls.Add(this.RemoveCross);
            this.groupBox3.Controls.Add(this.AddCross);
            this.groupBox3.Controls.Add(this.CrossView);
            this.groupBox3.Location = new System.Drawing.Point(12, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 114);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kreuzungen";
            // 
            // SelCrossButton
            // 
            this.SelCrossButton.BackColor = System.Drawing.SystemColors.Control;
            this.SelCrossButton.Location = new System.Drawing.Point(234, 18);
            this.SelCrossButton.Name = "SelCrossButton";
            this.SelCrossButton.Size = new System.Drawing.Size(42, 21);
            this.SelCrossButton.TabIndex = 56;
            this.SelCrossButton.Text = "...";
            this.SelCrossButton.UseVisualStyleBackColor = false;
            this.SelCrossButton.Click += new System.EventHandler(this.SelCrossButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "mit Frage:";
            // 
            // cBox
            // 
            this.cBox.Location = new System.Drawing.Point(187, 19);
            this.cBox.Name = "cBox";
            this.cBox.Size = new System.Drawing.Size(44, 20);
            this.cBox.TabIndex = 54;
            this.cBox.TextChanged += new System.EventHandler(this.cBox_TextChanged);
            // 
            // RemoveCross
            // 
            this.RemoveCross.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveCross.Location = new System.Drawing.Point(131, 77);
            this.RemoveCross.Name = "RemoveCross";
            this.RemoveCross.Size = new System.Drawing.Size(107, 27);
            this.RemoveCross.TabIndex = 52;
            this.RemoveCross.Text = "Entfernen";
            this.RemoveCross.UseVisualStyleBackColor = false;
            this.RemoveCross.Click += new System.EventHandler(this.RemoveCross_Click);
            // 
            // AddCross
            // 
            this.AddCross.BackColor = System.Drawing.SystemColors.Control;
            this.AddCross.Location = new System.Drawing.Point(131, 44);
            this.AddCross.Name = "AddCross";
            this.AddCross.Size = new System.Drawing.Size(107, 27);
            this.AddCross.TabIndex = 51;
            this.AddCross.Text = "Hinzufügen...";
            this.AddCross.UseVisualStyleBackColor = false;
            this.AddCross.Click += new System.EventHandler(this.AddCross_Click);
            // 
            // CrossView
            // 
            this.CrossView.FormattingEnabled = true;
            this.CrossView.Location = new System.Drawing.Point(13, 22);
            this.CrossView.Name = "CrossView";
            this.CrossView.Size = new System.Drawing.Size(112, 82);
            this.CrossView.TabIndex = 0;
            // 
            // PercentBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 264);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PercentBaseForm";
            this.Text = "Basis für Prozentwerte einstellen...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CButton;
        private System.Windows.Forms.TextBox qBox;
        private System.Windows.Forms.Button SelectQButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button SelCrossButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cBox;
        private System.Windows.Forms.Button RemoveCross;
        private System.Windows.Forms.Button AddCross;
        private System.Windows.Forms.ListBox CrossView;
    }
}