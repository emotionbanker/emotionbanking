namespace Compucare.Enquire.Common.Calculation.Texts.CsvExport.Wizard.WizardPages
{
    partial class CsvWizardPageControl
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
            this._chooseTargetPanel = new System.Windows.Forms.GroupBox();
            this._questionSelector = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorControl();
            this.SuspendLayout();
            // 
            // _chooseTargetPanel
            // 
            this._chooseTargetPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._chooseTargetPanel.Location = new System.Drawing.Point(3, 65);
            this._chooseTargetPanel.Name = "_chooseTargetPanel";
            this._chooseTargetPanel.Size = new System.Drawing.Size(394, 154);
            this._chooseTargetPanel.TabIndex = 1;
            this._chooseTargetPanel.TabStop = false;
            this._chooseTargetPanel.Text = "Bank";
            // 
            // _questionSelector
            // 
            this._questionSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._questionSelector.Header = "Select splitter and user group";
            this._questionSelector.Location = new System.Drawing.Point(3, 3);
            this._questionSelector.Name = "_questionSelector";
            this._questionSelector.Size = new System.Drawing.Size(394, 56);
            this._questionSelector.TabIndex = 2;
            // 
            // CsvWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._questionSelector);
            this.Controls.Add(this._chooseTargetPanel);
            this.Name = "CsvWizardPageControl";
            this.Size = new System.Drawing.Size(400, 222);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox _chooseTargetPanel;
        internal Controls.DataItems.SingleQuestionSelectorControl _questionSelector;

    }
}
