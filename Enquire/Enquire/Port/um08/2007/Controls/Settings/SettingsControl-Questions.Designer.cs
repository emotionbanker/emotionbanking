namespace umfrage2._2007.Controls
{
    partial class SettingsControl_Questions
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
            this.IValButton = new System.Windows.Forms.RadioButton();
            this.ComboButton = new System.Windows.Forms.RadioButton();
            this.IVal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboTextBox = new System.Windows.Forms.TextBox();
            this.RemoveQuestionButton = new System.Windows.Forms.Button();
            this.AddQuestionButton = new System.Windows.Forms.Button();
            this.DeleteComboButton = new System.Windows.Forms.Button();
            this.NewComboButton = new System.Windows.Forms.Button();
            this.ComboView = new System.Windows.Forms.ListBox();
            this.QuestionComboList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AComboButton = new System.Windows.Forms.RadioButton();
            this.AnswerBox = new System.Windows.Forms.ListBox();
            this.NewAnswer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ACPanel = new System.Windows.Forms.Panel();
            this._buttonASum = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.IVal)).BeginInit();
            this.ACPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // IValButton
            // 
            this.IValButton.Location = new System.Drawing.Point(21, 421);
            this.IValButton.Name = "IValButton";
            this.IValButton.Size = new System.Drawing.Size(91, 24);
            this.IValButton.TabIndex = 46;
            this.IValButton.Text = "Aufteilung";
            this.IValButton.CheckedChanged += new System.EventHandler(this.IValButton_CheckedChanged);
            // 
            // ComboButton
            // 
            this.ComboButton.Location = new System.Drawing.Point(21, 402);
            this.ComboButton.Name = "ComboButton";
            this.ComboButton.Size = new System.Drawing.Size(104, 24);
            this.ComboButton.TabIndex = 45;
            this.ComboButton.Text = "Kombination";
            this.ComboButton.CheckedChanged += new System.EventHandler(this.ComboButton_CheckedChanged);
            // 
            // IVal
            // 
            this.IVal.Location = new System.Drawing.Point(178, 420);
            this.IVal.Name = "IVal";
            this.IVal.Size = new System.Drawing.Size(40, 20);
            this.IVal.TabIndex = 44;
            this.IVal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IVal.ValueChanged += new System.EventHandler(this.IVal_ValueChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(118, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 43;
            this.label5.Text = "Intervall:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 23);
            this.label4.TabIndex = 42;
            this.label4.Text = "Text:";
            // 
            // ComboTextBox
            // 
            this.ComboTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComboTextBox.Location = new System.Drawing.Point(76, 371);
            this.ComboTextBox.Name = "ComboTextBox";
            this.ComboTextBox.Size = new System.Drawing.Size(252, 20);
            this.ComboTextBox.TabIndex = 41;
            this.ComboTextBox.TextChanged += new System.EventHandler(this.ComboTextBox_TextChanged);
            // 
            // RemoveQuestionButton
            // 
            this.RemoveQuestionButton.BackColor = System.Drawing.Color.White;
            this.RemoveQuestionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveQuestionButton.Location = new System.Drawing.Point(334, 310);
            this.RemoveQuestionButton.Name = "RemoveQuestionButton";
            this.RemoveQuestionButton.Size = new System.Drawing.Size(160, 29);
            this.RemoveQuestionButton.TabIndex = 40;
            this.RemoveQuestionButton.Text = "Frage löschen";
            this.RemoveQuestionButton.UseVisualStyleBackColor = false;
            this.RemoveQuestionButton.Click += new System.EventHandler(this.RemoveQuestionButton_Click);
            // 
            // AddQuestionButton
            // 
            this.AddQuestionButton.BackColor = System.Drawing.Color.White;
            this.AddQuestionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddQuestionButton.Location = new System.Drawing.Point(334, 275);
            this.AddQuestionButton.Name = "AddQuestionButton";
            this.AddQuestionButton.Size = new System.Drawing.Size(160, 29);
            this.AddQuestionButton.TabIndex = 39;
            this.AddQuestionButton.Text = "Frage hinzufügen";
            this.AddQuestionButton.UseVisualStyleBackColor = false;
            this.AddQuestionButton.Click += new System.EventHandler(this.AddQuestionButton_Click);
            // 
            // DeleteComboButton
            // 
            this.DeleteComboButton.BackColor = System.Drawing.Color.White;
            this.DeleteComboButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteComboButton.Location = new System.Drawing.Point(187, 215);
            this.DeleteComboButton.Name = "DeleteComboButton";
            this.DeleteComboButton.Size = new System.Drawing.Size(160, 29);
            this.DeleteComboButton.TabIndex = 38;
            this.DeleteComboButton.Text = "Kombination löschen";
            this.DeleteComboButton.UseVisualStyleBackColor = false;
            this.DeleteComboButton.Click += new System.EventHandler(this.DeleteComboButton_Click);
            // 
            // NewComboButton
            // 
            this.NewComboButton.BackColor = System.Drawing.Color.White;
            this.NewComboButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NewComboButton.Location = new System.Drawing.Point(21, 215);
            this.NewComboButton.Name = "NewComboButton";
            this.NewComboButton.Size = new System.Drawing.Size(160, 29);
            this.NewComboButton.TabIndex = 37;
            this.NewComboButton.Text = "Neue Kombination";
            this.NewComboButton.UseVisualStyleBackColor = false;
            this.NewComboButton.Click += new System.EventHandler(this.NewComboButton_Click);
            // 
            // ComboView
            // 
            this.ComboView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComboView.HorizontalScrollbar = true;
            this.ComboView.Location = new System.Drawing.Point(21, 275);
            this.ComboView.Name = "ComboView";
            this.ComboView.Size = new System.Drawing.Size(307, 80);
            this.ComboView.TabIndex = 36;
            // 
            // QuestionComboList
            // 
            this.QuestionComboList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionComboList.HorizontalScrollbar = true;
            this.QuestionComboList.Location = new System.Drawing.Point(21, 27);
            this.QuestionComboList.Name = "QuestionComboList";
            this.QuestionComboList.Size = new System.Drawing.Size(473, 171);
            this.QuestionComboList.TabIndex = 35;
            this.QuestionComboList.SelectedIndexChanged += new System.EventHandler(this.QuestionComboList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Kombinationen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Einstellungen:";
            // 
            // AComboButton
            // 
            this.AComboButton.Location = new System.Drawing.Point(21, 440);
            this.AComboButton.Name = "AComboButton";
            this.AComboButton.Size = new System.Drawing.Size(197, 24);
            this.AComboButton.TabIndex = 49;
            this.AComboButton.Text = "Antwortkombination";
            this.AComboButton.CheckedChanged += new System.EventHandler(this.AComboButton_CheckedChanged);
            // 
            // AnswerBox
            // 
            this.AnswerBox.FormattingEnabled = true;
            this.AnswerBox.HorizontalScrollbar = true;
            this.AnswerBox.Location = new System.Drawing.Point(3, 3);
            this.AnswerBox.Name = "AnswerBox";
            this.AnswerBox.Size = new System.Drawing.Size(304, 95);
            this.AnswerBox.TabIndex = 50;
            this.AnswerBox.SelectedIndexChanged += new System.EventHandler(this.AnswerBox_SelectedIndexChanged);
            // 
            // NewAnswer
            // 
            this.NewAnswer.Location = new System.Drawing.Point(340, 19);
            this.NewAnswer.Name = "NewAnswer";
            this.NewAnswer.Size = new System.Drawing.Size(122, 20);
            this.NewAnswer.TabIndex = 51;
            this.NewAnswer.TextChanged += new System.EventHandler(this.NewAnswer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "zusammenfassen unter:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ACPanel
            // 
            this.ACPanel.Controls.Add(this.AnswerBox);
            this.ACPanel.Controls.Add(this.label3);
            this.ACPanel.Controls.Add(this.NewAnswer);
            this.ACPanel.Location = new System.Drawing.Point(21, 488);
            this.ACPanel.Name = "ACPanel";
            this.ACPanel.Size = new System.Drawing.Size(533, 101);
            this.ACPanel.TabIndex = 53;
            // 
            // _buttonASum
            // 
            this._buttonASum.Location = new System.Drawing.Point(21, 458);
            this._buttonASum.Name = "_buttonASum";
            this._buttonASum.Size = new System.Drawing.Size(197, 24);
            this._buttonASum.TabIndex = 54;
            this._buttonASum.Text = "Summe";
            this._buttonASum.CheckedChanged += new System.EventHandler(this._buttonASum_CheckedChanged);
            // 
            // SettingsControl_Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._buttonASum);
            this.Controls.Add(this.ACPanel);
            this.Controls.Add(this.AComboButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IValButton);
            this.Controls.Add(this.ComboButton);
            this.Controls.Add(this.IVal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ComboTextBox);
            this.Controls.Add(this.RemoveQuestionButton);
            this.Controls.Add(this.AddQuestionButton);
            this.Controls.Add(this.DeleteComboButton);
            this.Controls.Add(this.NewComboButton);
            this.Controls.Add(this.ComboView);
            this.Controls.Add(this.QuestionComboList);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SettingsControl_Questions";
            this.Size = new System.Drawing.Size(649, 619);
            this.Load += new System.EventHandler(this.SettingsControl_Questions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IVal)).EndInit();
            this.ACPanel.ResumeLayout(false);
            this.ACPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton IValButton;
        private System.Windows.Forms.RadioButton ComboButton;
        private System.Windows.Forms.NumericUpDown IVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ComboTextBox;
        private System.Windows.Forms.Button RemoveQuestionButton;
        private System.Windows.Forms.Button AddQuestionButton;
        private System.Windows.Forms.Button DeleteComboButton;
        private System.Windows.Forms.Button NewComboButton;
        private System.Windows.Forms.ListBox ComboView;
        private System.Windows.Forms.ListBox QuestionComboList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton AComboButton;
        private System.Windows.Forms.ListBox AnswerBox;
        private System.Windows.Forms.TextBox NewAnswer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel ACPanel;
        private System.Windows.Forms.RadioButton _buttonASum;
    }
}
