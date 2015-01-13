namespace umfrage2
{
    partial class UGSplitDialog
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
            this.UGBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SplitName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupSelector = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AnswerBox = new System.Windows.Forms.ComboBox();
            this.SelectQButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Col1Button = new System.Windows.Forms.Button();
            this.Col2Button = new System.Windows.Forms.Button();
            this.cd = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.GroupSelector)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(411, 218);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(121, 31);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // UGBox
            // 
            this.UGBox.BackColor = System.Drawing.Color.Transparent;
            this.UGBox.Location = new System.Drawing.Point(16, 16);
            this.UGBox.Name = "UGBox";
            this.UGBox.Size = new System.Drawing.Size(233, 162);
            this.UGBox.TabIndex = 1;
            this.UGBox.TabStop = false;
            this.UGBox.Text = "Personengruppe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(255, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Spaltenname:";
            // 
            // SplitName
            // 
            this.SplitName.Location = new System.Drawing.Point(360, 21);
            this.SplitName.Name = "SplitName";
            this.SplitName.Size = new System.Drawing.Size(100, 20);
            this.SplitName.TabIndex = 3;
            this.SplitName.TextChanged += new System.EventHandler(this.SplitName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(255, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gruppieren unter:";
            // 
            // GroupSelector
            // 
            this.GroupSelector.Location = new System.Drawing.Point(360, 51);
            this.GroupSelector.Name = "GroupSelector";
            this.GroupSelector.Size = new System.Drawing.Size(35, 20);
            this.GroupSelector.TabIndex = 5;
            this.GroupSelector.ValueChanged += new System.EventHandler(this.GroupSelector_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(410, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "(0 = keine Gruppierung)";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.AnswerBox);
            this.groupBox1.Controls.Add(this.SelectQButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(255, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teilung";
            // 
            // AnswerBox
            // 
            this.AnswerBox.FormattingEnabled = true;
            this.AnswerBox.Location = new System.Drawing.Point(70, 56);
            this.AnswerBox.Name = "AnswerBox";
            this.AnswerBox.Size = new System.Drawing.Size(148, 21);
            this.AnswerBox.TabIndex = 1;
            this.AnswerBox.SelectedIndexChanged += new System.EventHandler(this.AnswerBox_SelectedIndexChanged);
            // 
            // SelectQButton
            // 
            this.SelectQButton.Location = new System.Drawing.Point(17, 24);
            this.SelectQButton.Name = "SelectQButton";
            this.SelectQButton.Size = new System.Drawing.Size(201, 26);
            this.SelectQButton.TabIndex = 0;
            this.SelectQButton.Text = "Frage auswählen...";
            this.SelectQButton.UseVisualStyleBackColor = true;
            this.SelectQButton.Click += new System.EventHandler(this.SelectQButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(14, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Antwort:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.Col2Button);
            this.groupBox2.Controls.Add(this.Col1Button);
            this.groupBox2.Location = new System.Drawing.Point(16, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 65);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Farben";
            // 
            // Col1Button
            // 
            this.Col1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Col1Button.Location = new System.Drawing.Point(12, 23);
            this.Col1Button.Name = "Col1Button";
            this.Col1Button.Size = new System.Drawing.Size(61, 26);
            this.Col1Button.TabIndex = 0;
            this.Col1Button.UseVisualStyleBackColor = true;
            this.Col1Button.Click += new System.EventHandler(this.Col1Button_Click);
            // 
            // Col2Button
            // 
            this.Col2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Col2Button.Location = new System.Drawing.Point(89, 23);
            this.Col2Button.Name = "Col2Button";
            this.Col2Button.Size = new System.Drawing.Size(61, 26);
            this.Col2Button.TabIndex = 1;
            this.Col2Button.UseVisualStyleBackColor = true;
            this.Col2Button.Click += new System.EventHandler(this.Col2Button_Click);
            // 
            // UGSplitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GroupSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SplitName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UGBox);
            this.Controls.Add(this.OKButton);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UGSplitDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Polaritätenprofil - Spalteneinstellung";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MultipartSaveDialog_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.GroupSelector)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.GroupBox UGBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SplitName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown GroupSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SelectQButton;
        private System.Windows.Forms.ComboBox AnswerBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Col2Button;
        private System.Windows.Forms.Button Col1Button;
        private System.Windows.Forms.ColorDialog cd;

    }
}