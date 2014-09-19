namespace Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard.WizardPages
{
    partial class AdvancedComparisonWizardPageControl
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
            this._selectQ1 = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorCrossingControl();
            this._selectQ2 = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorCrossingControl();
            this.label1 = new System.Windows.Forms.Label();
            this._precision = new System.Windows.Forms.NumericUpDown();
            this._precisionPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._precision)).BeginInit();
            this._precisionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _selectQ1
            // 
            this._selectQ1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._selectQ1.Header = "Question 1";
            this._selectQ1.Location = new System.Drawing.Point(0, 3);
            this._selectQ1.Name = "_selectQ1";
            this._selectQ1.Size = new System.Drawing.Size(461, 83);
            this._selectQ1.TabIndex = 0;
            // 
            // _selectQ2
            // 
            this._selectQ2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._selectQ2.Header = "Question 2";
            this._selectQ2.Location = new System.Drawing.Point(0, 92);
            this._selectQ2.Name = "_selectQ2";
            this._selectQ2.Size = new System.Drawing.Size(461, 83);
            this._selectQ2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Precision:";
            // 
            // _precision
            // 
            this._precision.Location = new System.Drawing.Point(62, 7);
            this._precision.Name = "_precision";
            this._precision.Size = new System.Drawing.Size(44, 20);
            this._precision.TabIndex = 5;
            this._precision.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _precisionPanel
            // 
            this._precisionPanel.Controls.Add(this.label1);
            this._precisionPanel.Controls.Add(this._precision);
            this._precisionPanel.Location = new System.Drawing.Point(3, 180);
            this._precisionPanel.Name = "_precisionPanel";
            this._precisionPanel.Size = new System.Drawing.Size(126, 46);
            this._precisionPanel.TabIndex = 7;
            this._precisionPanel.Visible = false;
            // 
            // AdvancedComparisonWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._precisionPanel);
            this.Controls.Add(this._selectQ2);
            this.Controls.Add(this._selectQ1);
            this.Name = "AdvancedComparisonWizardPageControl";
            this.Size = new System.Drawing.Size(464, 238);
            ((System.ComponentModel.ISupportInitialize)(this._precision)).EndInit();
            this._precisionPanel.ResumeLayout(false);
            this._precisionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.DataItems.SingleQuestionSelectorCrossingControl _selectQ1;
        internal Controls.DataItems.SingleQuestionSelectorCrossingControl _selectQ2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NumericUpDown _precision;
        internal System.Windows.Forms.Panel _precisionPanel;

    }
}
