namespace Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard.WizardPages
{
    partial class BenchmarkWizardPageControl
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
            this._comparativePanel = new System.Windows.Forms.Panel();
            this._crossingControl = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorCrossingControl();
            this._selectQ = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorControl();
            this._comparativePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _comparativePanel
            // 
            this._comparativePanel.Controls.Add(this._crossingControl);
            this._comparativePanel.Location = new System.Drawing.Point(0, 3);
            this._comparativePanel.Name = "_comparativePanel";
            this._comparativePanel.Size = new System.Drawing.Size(464, 232);
            this._comparativePanel.TabIndex = 3;
            // 
            // _crossingControl
            // 
            this._crossingControl.CrossHeader = "Cross:";
            this._crossingControl.Header = "Select Question:";
            this._crossingControl.Location = new System.Drawing.Point(3, 3);
            this._crossingControl.Name = "_crossingControl";
            this._crossingControl.Size = new System.Drawing.Size(458, 157);
            this._crossingControl.TabIndex = 0;
            // 
            // _selectQ
            // 
            this._selectQ.Header = "Select Question";
            this._selectQ.Location = new System.Drawing.Point(3, 3);
            this._selectQ.Name = "_selectQ";
            this._selectQ.Size = new System.Drawing.Size(458, 51);
            this._selectQ.TabIndex = 2;
            // 
            // BenchmarkWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._comparativePanel);
            this.Controls.Add(this._selectQ);
            this.Name = "BenchmarkWizardPageControl";
            this.Size = new System.Drawing.Size(464, 238);
            this._comparativePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.DataItems.SingleQuestionSelectorControl _selectQ;
        internal System.Windows.Forms.Panel _comparativePanel;
        internal Controls.DataItems.SingleQuestionSelectorCrossingControl _crossingControl;

    }
}
