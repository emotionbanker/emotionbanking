namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    partial class MaturityModel
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
            this.CButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.List4 = new System.Windows.Forms.TextBox();
            this.List3 = new System.Windows.Forms.TextBox();
            this.List2 = new System.Windows.Forms.TextBox();
            this.List1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CButton
            // 
            this.CButton.Location = new System.Drawing.Point(218, 163);
            this.CButton.Name = "CButton";
            this.CButton.Size = new System.Drawing.Size(110, 27);
            this.CButton.TabIndex = 0;
            this.CButton.Text = "Abbrechen";
            this.CButton.UseVisualStyleBackColor = true;
            this.CButton.Click += new System.EventHandler(this.CButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(334, 163);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(110, 27);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "Einfügen";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Aufgabenrelevantes Wissen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Leistungsmotivation:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mitarbeiterorientierung:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Aufgabenorientierung:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.List4);
            this.groupBox1.Controls.Add(this.List3);
            this.groupBox1.Controls.Add(this.List2);
            this.groupBox1.Controls.Add(this.List1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 145);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fragenlisten";
            // 
            // List4
            // 
            this.List4.Location = new System.Drawing.Point(166, 97);
            this.List4.Name = "List4";
            this.List4.Size = new System.Drawing.Size(255, 20);
            this.List4.TabIndex = 58;
            this.List4.Text = "2321,2322,2323";
            // 
            // List3
            // 
            this.List3.Location = new System.Drawing.Point(166, 73);
            this.List3.Name = "List3";
            this.List3.Size = new System.Drawing.Size(255, 20);
            this.List3.TabIndex = 57;
            this.List3.Text = "1518,2313,1522";
            // 
            // List2
            // 
            this.List2.Location = new System.Drawing.Point(166, 49);
            this.List2.Name = "List2";
            this.List2.Size = new System.Drawing.Size(255, 20);
            this.List2.TabIndex = 56;
            this.List2.Text = "2325,2326,2327";
            // 
            // List1
            // 
            this.List1.Location = new System.Drawing.Point(166, 24);
            this.List1.Name = "List1";
            this.List1.Size = new System.Drawing.Size(255, 20);
            this.List1.TabIndex = 55;
            this.List1.Text = "2324,384,386";
            // 
            // MaturityModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 205);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaturityModel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reifegradmodell einfügen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox List4;
        private System.Windows.Forms.TextBox List3;
        private System.Windows.Forms.TextBox List2;
        private System.Windows.Forms.TextBox List1;
    }
}