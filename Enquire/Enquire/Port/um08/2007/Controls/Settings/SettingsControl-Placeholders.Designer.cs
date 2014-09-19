namespace umfrage2._2007.Controls
{
    partial class SettingsControl_Placeholders
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
            this.QuestionList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StatsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.QView = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PHTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // QuestionList
            // 
            this.QuestionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionList.FormattingEnabled = true;
            this.QuestionList.Location = new System.Drawing.Point(14, 27);
            this.QuestionList.Name = "QuestionList";
            this.QuestionList.Size = new System.Drawing.Size(219, 314);
            this.QuestionList.TabIndex = 16;
            this.QuestionList.SelectedIndexChanged += new System.EventHandler(this.QuestionList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(239, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "ist Platzhalter für (Default):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // StatsButton
            // 
            this.StatsButton.Location = new System.Drawing.Point(440, 316);
            this.StatsButton.Name = "StatsButton";
            this.StatsButton.Size = new System.Drawing.Size(138, 24);
            this.StatsButton.TabIndex = 22;
            this.StatsButton.Text = "Frage auswählen...";
            this.StatsButton.UseVisualStyleBackColor = true;
            this.StatsButton.Click += new System.EventHandler(this.StatsButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 24);
            this.button1.TabIndex = 23;
            this.button1.Text = "Neuer Platzhalter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QView
            // 
            this.QView.AutoSize = true;
            this.QView.Location = new System.Drawing.Point(385, 322);
            this.QView.Name = "QView";
            this.QView.Size = new System.Drawing.Size(37, 13);
            this.QView.TabIndex = 24;
            this.QView.Text = "QView";
            this.QView.Click += new System.EventHandler(this.QView_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 24);
            this.button2.TabIndex = 25;
            this.button2.Text = "Platzhalter löschen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(239, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "Platzhalter XYZ: Bezeichnung:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PHTextBox
            // 
            this.PHTextBox.Location = new System.Drawing.Point(407, 289);
            this.PHTextBox.Name = "PHTextBox";
            this.PHTextBox.Size = new System.Drawing.Size(171, 20);
            this.PHTextBox.TabIndex = 27;
            this.PHTextBox.TextChanged += new System.EventHandler(this.PHTextBox_TextChanged);
            // 
            // SettingsControl_Placeholders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PHTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.QView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StatsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuestionList);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SettingsControl_Placeholders";
            this.Size = new System.Drawing.Size(935, 442);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox QuestionList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StatsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label QView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PHTextBox;
    }
}
