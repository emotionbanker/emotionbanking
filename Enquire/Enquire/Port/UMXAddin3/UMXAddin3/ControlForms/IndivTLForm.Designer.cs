namespace UMXAddin3
{
    partial class IndivTLForm
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
            this.cancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.x1Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.C1Select = new System.Windows.Forms.Button();
            this.cdialog = new System.Windows.Forms.ColorDialog();
            this.C2Select = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.x2Box = new System.Windows.Forms.TextBox();
            this.c2Label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.C3Select = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.c3Label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(79, 162);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(84, 29);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Abbrechen";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Einfügen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Farbe 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "von 5 bis";
            // 
            // x1Box
            // 
            this.x1Box.Location = new System.Drawing.Point(133, 21);
            this.x1Box.Name = "x1Box";
            this.x1Box.Size = new System.Drawing.Size(29, 20);
            this.x1Box.TabIndex = 6;
            this.x1Box.Text = "3.5";
            this.x1Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.x1Box.TextChanged += new System.EventHandler(this.x1Box_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Zahlenformat: Komma wird mit \".\" (Punkt) dargestellt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Farbe:";
            // 
            // C1Select
            // 
            this.C1Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C1Select.Location = new System.Drawing.Point(220, 21);
            this.C1Select.Name = "C1Select";
            this.C1Select.Size = new System.Drawing.Size(35, 19);
            this.C1Select.TabIndex = 9;
            this.C1Select.UseVisualStyleBackColor = true;
            this.C1Select.Click += new System.EventHandler(this.C1Select_Click);
            // 
            // C2Select
            // 
            this.C2Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C2Select.Location = new System.Drawing.Point(220, 44);
            this.C2Select.Name = "C2Select";
            this.C2Select.Size = new System.Drawing.Size(35, 19);
            this.C2Select.TabIndex = 14;
            this.C2Select.UseVisualStyleBackColor = true;
            this.C2Select.Click += new System.EventHandler(this.C2Select_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Farbe:";
            // 
            // x2Box
            // 
            this.x2Box.Location = new System.Drawing.Point(133, 44);
            this.x2Box.Name = "x2Box";
            this.x2Box.Size = new System.Drawing.Size(29, 20);
            this.x2Box.TabIndex = 12;
            this.x2Box.Text = "2";
            this.x2Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.x2Box.TextChanged += new System.EventHandler(this.x2Box_TextChanged);
            // 
            // c2Label
            // 
            this.c2Label.AutoSize = true;
            this.c2Label.Location = new System.Drawing.Point(66, 47);
            this.c2Label.Name = "c2Label";
            this.c2Label.Size = new System.Drawing.Size(60, 13);
            this.c2Label.TabIndex = 11;
            this.c2Label.Text = "von 3.5 bis";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Farbe 2:";
            // 
            // C3Select
            // 
            this.C3Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.C3Select.Location = new System.Drawing.Point(220, 68);
            this.C3Select.Name = "C3Select";
            this.C3Select.Size = new System.Drawing.Size(35, 19);
            this.C3Select.TabIndex = 19;
            this.C3Select.UseVisualStyleBackColor = true;
            this.C3Select.Click += new System.EventHandler(this.C3Select_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Farbe:";
            // 
            // c3Label
            // 
            this.c3Label.AutoSize = true;
            this.c3Label.Location = new System.Drawing.Point(66, 71);
            this.c3Label.Name = "c3Label";
            this.c3Label.Size = new System.Drawing.Size(59, 13);
            this.c3Label.TabIndex = 16;
            this.c3Label.Text = "von 2 bis 1";
            this.c3Label.Click += new System.EventHandler(this.c3Label_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Farbe 3:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Radius:";
            // 
            // radBox
            // 
            this.radBox.Location = new System.Drawing.Point(69, 101);
            this.radBox.Name = "radBox";
            this.radBox.Size = new System.Drawing.Size(29, 20);
            this.radBox.TabIndex = 21;
            this.radBox.Text = "8";
            this.radBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.radBox.TextChanged += new System.EventHandler(this.radBox_TextChanged);
            // 
            // IndivTLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 213);
            this.Controls.Add(this.radBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.C3Select);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.c3Label);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.C2Select);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.x2Box);
            this.Controls.Add(this.c2Label);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.C1Select);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.x1Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cancel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IndivTLForm";
            this.ShowInTaskbar = false;
            this.Text = "Individuelle Ampelgraphik";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox x1Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog cdialog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox x2Box;
        private System.Windows.Forms.Label c2Label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label c3Label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox radBox;
        public System.Windows.Forms.Button C1Select;
        public System.Windows.Forms.Button C2Select;
        public System.Windows.Forms.Button C3Select;
    }
}