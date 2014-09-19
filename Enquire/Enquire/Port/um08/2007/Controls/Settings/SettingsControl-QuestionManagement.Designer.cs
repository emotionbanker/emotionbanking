namespace Compucare.Enquire.Legacy.Umfrage2Lib._2007.Controls.Settings
{
    partial class SettingsControl_QuestionManagement
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuestionButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.removeColumn = new System.Windows.Forms.Button();
            this.addColumn = new System.Windows.Forms.Button();
            this.Step2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Step2_1 = new System.Windows.Forms.GroupBox();
            this.Step1 = new System.Windows.Forms.GroupBox();
            this.Step3 = new System.Windows.Forms.GroupBox();
            this.createQuestion = new System.Windows.Forms.Button();
            this.QuestionList = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxColumnName = new System.Windows.Forms.TextBox();
            this.Step2_2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.Step2.SuspendLayout();
            this.Step1.SuspendLayout();
            this.Step3.SuspendLayout();
            this.Step2_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionButton
            // 
            this.QuestionButton.Location = new System.Drawing.Point(22, 28);
            this.QuestionButton.Name = "QuestionButton";
            this.QuestionButton.Size = new System.Drawing.Size(138, 24);
            this.QuestionButton.TabIndex = 23;
            this.QuestionButton.Text = "?";
            this.QuestionButton.UseVisualStyleBackColor = true;
            this.QuestionButton.Click += new System.EventHandler(this.QuestionButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 55);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(411, 23);
            this.progressBar1.TabIndex = 24;
            // 
            // removeColumn
            // 
            this.removeColumn.Location = new System.Drawing.Point(22, 30);
            this.removeColumn.Name = "removeColumn";
            this.removeColumn.Size = new System.Drawing.Size(130, 24);
            this.removeColumn.TabIndex = 28;
            this.removeColumn.Text = "Spalte löschen";
            this.removeColumn.UseVisualStyleBackColor = true;
            this.removeColumn.Click += new System.EventHandler(this.removeColumn_Click);
            // 
            // addColumn
            // 
            this.addColumn.Location = new System.Drawing.Point(22, 60);
            this.addColumn.Name = "addColumn";
            this.addColumn.Size = new System.Drawing.Size(130, 24);
            this.addColumn.TabIndex = 29;
            this.addColumn.Text = "Spalte einfügen";
            this.addColumn.UseVisualStyleBackColor = true;
            this.addColumn.Click += new System.EventHandler(this.addColumn_Click);
            // 
            // Step2
            // 
            this.Step2.Controls.Add(this.button3);
            this.Step2.Controls.Add(this.Step2_1);
            this.Step2.Controls.Add(this.removeColumn);
            this.Step2.Controls.Add(this.addColumn);
            this.Step2.Enabled = false;
            this.Step2.Location = new System.Drawing.Point(46, 156);
            this.Step2.Name = "Step2";
            this.Step2.Size = new System.Drawing.Size(577, 193);
            this.Step2.TabIndex = 30;
            this.Step2.TabStop = false;
            this.Step2.Text = "Schritt 2: Spalten definieren";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 158);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 24);
            this.button3.TabIndex = 32;
            this.button3.Text = "Weiter";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Step2_1
            // 
            this.Step2_1.Location = new System.Drawing.Point(177, 19);
            this.Step2_1.Name = "Step2_1";
            this.Step2_1.Size = new System.Drawing.Size(381, 163);
            this.Step2_1.TabIndex = 31;
            this.Step2_1.TabStop = false;
            // 
            // Step1
            // 
            this.Step1.Controls.Add(this.QuestionButton);
            this.Step1.Location = new System.Drawing.Point(46, 69);
            this.Step1.Name = "Step1";
            this.Step1.Size = new System.Drawing.Size(577, 72);
            this.Step1.TabIndex = 31;
            this.Step1.TabStop = false;
            this.Step1.Text = "Schritt1: Frage auswählen";
            // 
            // Step3
            // 
            this.Step3.Controls.Add(this.createQuestion);
            this.Step3.Controls.Add(this.progressBar1);
            this.Step3.Enabled = false;
            this.Step3.Location = new System.Drawing.Point(46, 440);
            this.Step3.Name = "Step3";
            this.Step3.Size = new System.Drawing.Size(577, 99);
            this.Step3.TabIndex = 32;
            this.Step3.TabStop = false;
            this.Step3.Text = "Schritt 4: Frage erstellen/Ergebnisse konvertieren";
            // 
            // createQuestion
            // 
            this.createQuestion.Location = new System.Drawing.Point(441, 54);
            this.createQuestion.Name = "createQuestion";
            this.createQuestion.Size = new System.Drawing.Size(106, 24);
            this.createQuestion.TabIndex = 29;
            this.createQuestion.Text = "erstellen";
            this.createQuestion.UseVisualStyleBackColor = true;
            this.createQuestion.Click += new System.EventHandler(this.createQuestion_Click);
            // 
            // QuestionList
            // 
            this.QuestionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionList.FormattingEnabled = true;
            this.QuestionList.Location = new System.Drawing.Point(655, 69);
            this.QuestionList.Name = "QuestionList";
            this.QuestionList.Size = new System.Drawing.Size(251, 210);
            this.QuestionList.TabIndex = 33;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(655, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 24);
            this.button2.TabIndex = 34;
            this.button2.Text = "Frage löschen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 24);
            this.button1.TabIndex = 35;
            this.button1.Text = "Statistik anzeigen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxColumnName
            // 
            this.textBoxColumnName.Location = new System.Drawing.Point(177, 19);
            this.textBoxColumnName.Name = "textBoxColumnName";
            this.textBoxColumnName.Size = new System.Drawing.Size(381, 20);
            this.textBoxColumnName.TabIndex = 32;
            // 
            // Step2_2
            // 
            this.Step2_2.Controls.Add(this.button4);
            this.Step2_2.Controls.Add(this.textBoxColumnName);
            this.Step2_2.Enabled = false;
            this.Step2_2.Location = new System.Drawing.Point(46, 355);
            this.Step2_2.Name = "Step2_2";
            this.Step2_2.Size = new System.Drawing.Size(577, 79);
            this.Step2_2.TabIndex = 36;
            this.Step2_2.TabStop = false;
            this.Step2_2.Text = "Schritt 3: Spalten unbenennen";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(428, 49);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 24);
            this.button4.TabIndex = 33;
            this.button4.Text = "Weiter";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SettingsControl_QuestionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Step2_2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.QuestionList);
            this.Controls.Add(this.Step3);
            this.Controls.Add(this.Step1);
            this.Controls.Add(this.Step2);
            this.Name = "SettingsControl_QuestionManagement";
            this.Size = new System.Drawing.Size(935, 547);
            this.Step2.ResumeLayout(false);
            this.Step1.ResumeLayout(false);
            this.Step3.ResumeLayout(false);
            this.Step2_2.ResumeLayout(false);
            this.Step2_2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button QuestionButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button removeColumn;
        private System.Windows.Forms.Button addColumn;
        private System.Windows.Forms.GroupBox Step2;
        private System.Windows.Forms.GroupBox Step1;
        private System.Windows.Forms.GroupBox Step3;
        private System.Windows.Forms.Button createQuestion;
        private System.Windows.Forms.ListBox QuestionList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox Step2_1;
        private System.Windows.Forms.TextBox textBoxColumnName;
        private System.Windows.Forms.GroupBox Step2_2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
