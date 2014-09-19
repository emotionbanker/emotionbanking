namespace UMXAddin3
{
    partial class BControlForm
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
            this.radBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.C3Select = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.c3Label = new System.Windows.Forms.Label();
            this.C2Select = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.x2Box = new System.Windows.Forms.TextBox();
            this.c2Label = new System.Windows.Forms.Label();
            this.C1Select = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.x1Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // radBox
            // 
            this.radBox.Location = new System.Drawing.Point(69, 100);
            this.radBox.Name = "radBox";
            this.radBox.Size = new System.Drawing.Size(29, 20);
            this.radBox.TabIndex = 40;
            this.radBox.Text = "8";
            this.radBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.radBox.TextChanged += new System.EventHandler(this.radBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Radius:";
            // 
            // C3Select
            // 
            this.C3Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C3Select.Location = new System.Drawing.Point(297, 70);
            this.C3Select.Name = "C3Select";
            this.C3Select.Size = new System.Drawing.Size(35, 19);
            this.C3Select.TabIndex = 38;
            this.C3Select.UseVisualStyleBackColor = true;
            this.C3Select.Click += new System.EventHandler(this.C3Select_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Farbe:";
            // 
            // c3Label
            // 
            this.c3Label.AutoSize = true;
            this.c3Label.Location = new System.Drawing.Point(105, 73);
            this.c3Label.Name = "c3Label";
            this.c3Label.Size = new System.Drawing.Size(65, 13);
            this.c3Label.TabIndex = 36;
            this.c3Label.Text = "von -1 bis -4";
            // 
            // C2Select
            // 
            this.C2Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C2Select.Location = new System.Drawing.Point(297, 43);
            this.C2Select.Name = "C2Select";
            this.C2Select.Size = new System.Drawing.Size(35, 19);
            this.C2Select.TabIndex = 34;
            this.C2Select.UseVisualStyleBackColor = true;
            this.C2Select.Click += new System.EventHandler(this.C2Select_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Farbe:";
            // 
            // x2Box
            // 
            this.x2Box.Location = new System.Drawing.Point(177, 43);
            this.x2Box.Name = "x2Box";
            this.x2Box.Size = new System.Drawing.Size(46, 20);
            this.x2Box.TabIndex = 32;
            this.x2Box.Text = "-1";
            this.x2Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.x2Box.TextChanged += new System.EventHandler(this.x2Box_TextChanged);
            // 
            // c2Label
            // 
            this.c2Label.AutoSize = true;
            this.c2Label.Location = new System.Drawing.Point(105, 46);
            this.c2Label.Name = "c2Label";
            this.c2Label.Size = new System.Drawing.Size(50, 13);
            this.c2Label.TabIndex = 31;
            this.c2Label.Text = "von 1 bis";
            // 
            // C1Select
            // 
            this.C1Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C1Select.Location = new System.Drawing.Point(297, 16);
            this.C1Select.Name = "C1Select";
            this.C1Select.Size = new System.Drawing.Size(35, 19);
            this.C1Select.TabIndex = 29;
            this.C1Select.UseVisualStyleBackColor = true;
            this.C1Select.Click += new System.EventHandler(this.C1Select_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Farbe:";
            // 
            // x1Box
            // 
            this.x1Box.Location = new System.Drawing.Point(177, 16);
            this.x1Box.Name = "x1Box";
            this.x1Box.Size = new System.Drawing.Size(46, 20);
            this.x1Box.TabIndex = 26;
            this.x1Box.Text = "1";
            this.x1Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.x1Box.TextChanged += new System.EventHandler(this.x1Box_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "von 4 bis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Wertebereich 1:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 29);
            this.button1.TabIndex = 23;
            this.button1.Text = "Einfügen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(158, 137);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(84, 29);
            this.cancel.TabIndex = 22;
            this.cancel.Text = "Abbrechen";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Wertebereich 2:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Wertebereich 3:";
            // 
            // BControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 178);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.C3Select);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.c3Label);
            this.Controls.Add(this.C2Select);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.x2Box);
            this.Controls.Add(this.c2Label);
            this.Controls.Add(this.C1Select);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.x1Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Banksteuerungsbericht";
            this.Load += new System.EventHandler(this.BControlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox radBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label c3Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox x2Box;
        private System.Windows.Forms.Label c2Label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox x1Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColorDialog cDialog;
        public System.Windows.Forms.Button C3Select;
        public System.Windows.Forms.Button C2Select;
        public System.Windows.Forms.Button C1Select;

    }
}