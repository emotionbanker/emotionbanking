namespace Compucare.Enquire.Common.Calculation.Texts.TopFlop.Wizard.WizardPages
{
    partial class TopFlopSettingsWizardPageControl
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
            this.label1 = new System.Windows.Forms.Label();
            this._numSpinner = new System.Windows.Forms.NumericUpDown();
            this._radioTop = new System.Windows.Forms.RadioButton();
            this._radioFlop = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._radioAvg = new System.Windows.Forms.RadioButton();
            this._radioGap = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._radioChange = new System.Windows.Forms.RadioButton();
            this._radioHistoric = new System.Windows.Forms.RadioButton();
            this._radioCurrent = new System.Windows.Forms.RadioButton();
            this._radioCurrentOnly = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this._historySelector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._gapLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSelectQuestion = new System.Windows.Forms.Button();
            this._radioSelectQuestion = new System.Windows.Forms.RadioButton();
            this._radioAllQuestion = new System.Windows.Forms.RadioButton();
            this._gapPersonBox = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            this._personBox = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            ((System.ComponentModel.ISupportInitialize)(this._numSpinner)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of results:";
            // 
            // _numSpinner
            // 
            this._numSpinner.Location = new System.Drawing.Point(101, 3);
            this._numSpinner.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._numSpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numSpinner.Name = "_numSpinner";
            this._numSpinner.Size = new System.Drawing.Size(75, 20);
            this._numSpinner.TabIndex = 1;
            this._numSpinner.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // _radioTop
            // 
            this._radioTop.AutoSize = true;
            this._radioTop.Checked = true;
            this._radioTop.Cursor = System.Windows.Forms.Cursors.Default;
            this._radioTop.Location = new System.Drawing.Point(6, 19);
            this._radioTop.Name = "_radioTop";
            this._radioTop.Size = new System.Drawing.Size(148, 17);
            this._radioTop.TabIndex = 2;
            this._radioTop.TabStop = true;
            this._radioTop.Text = "Show best (lowest) values";
            this._radioTop.UseVisualStyleBackColor = true;
            // 
            // _radioFlop
            // 
            this._radioFlop.AutoSize = true;
            this._radioFlop.Location = new System.Drawing.Point(6, 42);
            this._radioFlop.Name = "_radioFlop";
            this._radioFlop.Size = new System.Drawing.Size(157, 17);
            this._radioFlop.TabIndex = 4;
            this._radioFlop.Text = "Show worst (highest) values";
            this._radioFlop.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._radioTop);
            this.groupBox1.Controls.Add(this._radioFlop);
            this.groupBox1.Location = new System.Drawing.Point(6, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 68);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result ordering";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._radioAvg);
            this.groupBox2.Controls.Add(this._radioGap);
            this.groupBox2.Location = new System.Drawing.Point(272, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 68);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result type";
            // 
            // _radioAvg
            // 
            this._radioAvg.AutoSize = true;
            this._radioAvg.Checked = true;
            this._radioAvg.Cursor = System.Windows.Forms.Cursors.Default;
            this._radioAvg.Location = new System.Drawing.Point(6, 19);
            this._radioAvg.Name = "_radioAvg";
            this._radioAvg.Size = new System.Drawing.Size(70, 17);
            this._radioAvg.TabIndex = 2;
            this._radioAvg.TabStop = true;
            this._radioAvg.Text = "Averages";
            this._radioAvg.UseVisualStyleBackColor = true;
            // 
            // _radioGap
            // 
            this._radioGap.AutoSize = true;
            this._radioGap.Location = new System.Drawing.Point(6, 42);
            this._radioGap.Name = "_radioGap";
            this._radioGap.Size = new System.Drawing.Size(52, 17);
            this._radioGap.TabIndex = 4;
            this._radioGap.Text = "GAPs";
            this._radioGap.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._radioChange);
            this.groupBox3.Controls.Add(this._radioHistoric);
            this.groupBox3.Controls.Add(this._radioCurrent);
            this.groupBox3.Controls.Add(this._radioCurrentOnly);
            this.groupBox3.Location = new System.Drawing.Point(6, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 106);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result sorting";
            // 
            // _radioChange
            // 
            this._radioChange.AutoSize = true;
            this._radioChange.Location = new System.Drawing.Point(6, 61);
            this._radioChange.Name = "_radioChange";
            this._radioChange.Size = new System.Drawing.Size(97, 17);
            this._radioChange.TabIndex = 3;
            this._radioChange.TabStop = true;
            this._radioChange.Text = "Sort by change";
            this._radioChange.UseVisualStyleBackColor = true;
            // 
            // _radioHistoric
            // 
            this._radioHistoric.AutoSize = true;
            this._radioHistoric.Location = new System.Drawing.Point(6, 40);
            this._radioHistoric.Name = "_radioHistoric";
            this._radioHistoric.Size = new System.Drawing.Size(123, 17);
            this._radioHistoric.TabIndex = 2;
            this._radioHistoric.TabStop = true;
            this._radioHistoric.Text = "Sort by historic value";
            this._radioHistoric.UseVisualStyleBackColor = true;
            // 
            // _radioCurrent
            // 
            this._radioCurrent.AutoSize = true;
            this._radioCurrent.Location = new System.Drawing.Point(6, 82);
            this._radioCurrent.Name = "_radioCurrent";
            this._radioCurrent.Size = new System.Drawing.Size(123, 17);
            this._radioCurrent.TabIndex = 1;
            this._radioCurrent.TabStop = true;
            this._radioCurrent.Text = "Sort by current value";
            this._radioCurrent.UseVisualStyleBackColor = true;
            // 
            // _radioCurrentOnly
            // 
            this._radioCurrentOnly.AutoSize = true;
            this._radioCurrentOnly.Checked = true;
            this._radioCurrentOnly.Location = new System.Drawing.Point(6, 19);
            this._radioCurrentOnly.Name = "_radioCurrentOnly";
            this._radioCurrentOnly.Size = new System.Drawing.Size(144, 17);
            this._radioCurrentOnly.TabIndex = 0;
            this._radioCurrentOnly.TabStop = true;
            this._radioCurrentOnly.Text = "Show current values only";
            this._radioCurrentOnly.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Historic value:";
            // 
            // _historySelector
            // 
            this._historySelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._historySelector.FormattingEnabled = true;
            this._historySelector.Location = new System.Drawing.Point(272, 2);
            this._historySelector.Name = "_historySelector";
            this._historySelector.Size = new System.Drawing.Size(246, 21);
            this._historySelector.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "User group:";
            // 
            // _gapLabel
            // 
            this._gapLabel.AutoSize = true;
            this._gapLabel.Location = new System.Drawing.Point(275, 152);
            this._gapLabel.Name = "_gapLabel";
            this._gapLabel.Size = new System.Drawing.Size(52, 13);
            this._gapLabel.TabIndex = 12;
            this._gapLabel.Text = "Gap with:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSelectQuestion);
            this.groupBox4.Controls.Add(this._radioSelectQuestion);
            this.groupBox4.Controls.Add(this._radioAllQuestion);
            this.groupBox4.Location = new System.Drawing.Point(272, 221);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(246, 75);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Questions";
            // 
            // buttonSelectQuestion
            // 
            this.buttonSelectQuestion.Location = new System.Drawing.Point(85, 39);
            this.buttonSelectQuestion.Name = "buttonSelectQuestion";
            this.buttonSelectQuestion.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectQuestion.TabIndex = 2;
            this.buttonSelectQuestion.Text = "Select";
            this.buttonSelectQuestion.UseVisualStyleBackColor = true;
           // this.buttonSelectQuestion.Click += new System.EventHandler(this.buttonSelectQuestion_Click);
            // 
            // _radioSelectQuestion
            // 
            this._radioSelectQuestion.AutoSize = true;
            this._radioSelectQuestion.Location = new System.Drawing.Point(6, 42);
            this._radioSelectQuestion.Name = "_radioSelectQuestion";
            this._radioSelectQuestion.Size = new System.Drawing.Size(55, 17);
            this._radioSelectQuestion.TabIndex = 1;
            this._radioSelectQuestion.Text = "Select";
            this._radioSelectQuestion.UseVisualStyleBackColor = true;
            // 
            // _radioAllQuestion
            // 
            this._radioAllQuestion.AutoSize = true;
            this._radioAllQuestion.Checked = true;
            this._radioAllQuestion.Location = new System.Drawing.Point(6, 19);
            this._radioAllQuestion.Name = "_radioAllQuestion";
            this._radioAllQuestion.Size = new System.Drawing.Size(36, 17);
            this._radioAllQuestion.TabIndex = 0;
            this._radioAllQuestion.TabStop = true;
            this._radioAllQuestion.Text = "All";
            this._radioAllQuestion.UseVisualStyleBackColor = true;
            // 
            // _gapPersonBox
            // 
            this._gapPersonBox.InitString = null;
            this._gapPersonBox.Location = new System.Drawing.Point(278, 173);
            this._gapPersonBox.Name = "_gapPersonBox";
            this._gapPersonBox.Size = new System.Drawing.Size(240, 19);
            this._gapPersonBox.TabIndex = 13;
            // 
            // _personBox
            // 
            this._personBox.InitString = null;
            this._personBox.Location = new System.Drawing.Point(278, 126);
            this._personBox.Name = "_personBox";
            this._personBox.Size = new System.Drawing.Size(240, 19);
            this._personBox.TabIndex = 11;
            // 
            // TopFlopSettingsWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this._gapPersonBox);
            this.Controls.Add(this._gapLabel);
            this.Controls.Add(this._personBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._historySelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._numSpinner);
            this.Controls.Add(this.label1);
            this.Name = "TopFlopSettingsWizardPageControl";
            this.Size = new System.Drawing.Size(529, 334);
            ((System.ComponentModel.ISupportInitialize)(this._numSpinner)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NumericUpDown _numSpinner;
        internal System.Windows.Forms.RadioButton _radioTop;
        internal System.Windows.Forms.RadioButton _radioFlop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton _radioAvg;
        internal System.Windows.Forms.RadioButton _radioGap;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.RadioButton _radioCurrentOnly;
        internal System.Windows.Forms.RadioButton _radioChange;
        internal System.Windows.Forms.RadioButton _radioHistoric;
        internal System.Windows.Forms.RadioButton _radioCurrent;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox _historySelector;
        internal Controls.Utils.DropDownTextbox _personBox;
        private System.Windows.Forms.Label label3;
        internal Controls.Utils.DropDownTextbox _gapPersonBox;
        internal System.Windows.Forms.Label _gapLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.RadioButton _radioSelectQuestion;
        internal System.Windows.Forms.RadioButton _radioAllQuestion;
        internal System.Windows.Forms.Button buttonSelectQuestion;
    }
}
