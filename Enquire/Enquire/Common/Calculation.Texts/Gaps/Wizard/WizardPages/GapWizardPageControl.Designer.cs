namespace Compucare.Enquire.Common.Calculation.Texts.Gaps.Wizard.WizardPages
{
    partial class GapWizardPageControl
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
            this._precision = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._resultTypeSelector = new System.Windows.Forms.ComboBox();
            this._qSelect2 = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorCrossingControl();
            this._qSelect1 = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorCrossingControl();
            ((System.ComponentModel.ISupportInitialize)(this._precision)).BeginInit();
            this.SuspendLayout();
            // 
            // _precision
            // 
            this._precision.Location = new System.Drawing.Point(62, 178);
            this._precision.Name = "_precision";
            this._precision.Size = new System.Drawing.Size(44, 20);
            this._precision.TabIndex = 3;
            this._precision.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Precision:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Result Type:";
            // 
            // _resultTypeSelector
            // 
            this._resultTypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._resultTypeSelector.FormattingEnabled = true;
            this._resultTypeSelector.Items.AddRange(new object[] {
            "Average",
            "Percent"});
            this._resultTypeSelector.Location = new System.Drawing.Point(77, 216);
            this._resultTypeSelector.Name = "_resultTypeSelector";
            this._resultTypeSelector.Size = new System.Drawing.Size(148, 21);
            this._resultTypeSelector.TabIndex = 23;
            // 
            // _qSelect2
            // 
            this._qSelect2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._qSelect2.CrossHeader = "Cross:";
            this._qSelect2.Header = "Question 2";
            this._qSelect2.Location = new System.Drawing.Point(0, 85);
            this._qSelect2.Name = "_qSelect2";
            this._qSelect2.Size = new System.Drawing.Size(461, 79);
            this._qSelect2.TabIndex = 6;
            // 
            // _qSelect1
            // 
            this._qSelect1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._qSelect1.CrossHeader = "Cross:";
            this._qSelect1.Header = "Question 1";
            this._qSelect1.Location = new System.Drawing.Point(0, 0);
            this._qSelect1.Name = "_qSelect1";
            this._qSelect1.Size = new System.Drawing.Size(461, 79);
            this._qSelect1.TabIndex = 5;
            // 
            // GapWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this._resultTypeSelector);
            this.Controls.Add(this._qSelect2);
            this.Controls.Add(this._qSelect1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._precision);
            this.Name = "GapWizardPageControl";
            this.Size = new System.Drawing.Size(464, 258);
            ((System.ComponentModel.ISupportInitialize)(this._precision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.NumericUpDown _precision;
        private System.Windows.Forms.Label label1;
        internal Controls.DataItems.SingleQuestionSelectorCrossingControl _qSelect1;
        internal Controls.DataItems.SingleQuestionSelectorCrossingControl _qSelect2;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox _resultTypeSelector;
    }
}
