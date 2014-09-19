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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btn_averageValue = new System.Windows.Forms.RadioButton();
            this._btn_downValue = new System.Windows.Forms.RadioButton();
            this._btn_worstValue = new System.Windows.Forms.RadioButton();
            this._btn_bestValue = new System.Windows.Forms.RadioButton();
            this._crossingControl = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorCrossingControl();
            this._selectQ = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorControl();
            this._comparativePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _comparativePanel
            // 
            this._comparativePanel.Controls.Add(this.groupBox1);
            this._comparativePanel.Controls.Add(this._crossingControl);
            this._comparativePanel.Location = new System.Drawing.Point(0, 3);
            this._comparativePanel.Name = "_comparativePanel";
            this._comparativePanel.Size = new System.Drawing.Size(464, 232);
            this._comparativePanel.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btn_averageValue);
            this.groupBox1.Controls.Add(this._btn_downValue);
            this.groupBox1.Controls.Add(this._btn_worstValue);
            this.groupBox1.Controls.Add(this._btn_bestValue);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historic Values";
            // 
            // _btn_averageValue
            // 
            this._btn_averageValue.AutoSize = true;
            this._btn_averageValue.Location = new System.Drawing.Point(6, 88);
            this._btn_averageValue.Name = "_btn_averageValue";
            this._btn_averageValue.Size = new System.Drawing.Size(65, 17);
            this._btn_averageValue.TabIndex = 5;
            this._btn_averageValue.Text = "Average";
            this._btn_averageValue.UseVisualStyleBackColor = true;
            // 
            // _btn_downValue
            // 
            this._btn_downValue.AutoSize = true;
            this._btn_downValue.Location = new System.Drawing.Point(6, 65);
            this._btn_downValue.Name = "_btn_downValue";
            this._btn_downValue.Size = new System.Drawing.Size(47, 17);
            this._btn_downValue.TabIndex = 4;
            this._btn_downValue.Text = "Own";
            this._btn_downValue.UseVisualStyleBackColor = true;
            // 
            // _btn_worstValue
            // 
            this._btn_worstValue.AutoSize = true;
            this._btn_worstValue.Location = new System.Drawing.Point(6, 42);
            this._btn_worstValue.Name = "_btn_worstValue";
            this._btn_worstValue.Size = new System.Drawing.Size(53, 17);
            this._btn_worstValue.TabIndex = 3;
            this._btn_worstValue.Text = "Worst";
            this._btn_worstValue.UseVisualStyleBackColor = true;
            // 
            // _btn_bestValue
            // 
            this._btn_bestValue.AutoSize = true;
            this._btn_bestValue.Location = new System.Drawing.Point(6, 19);
            this._btn_bestValue.Name = "_btn_bestValue";
            this._btn_bestValue.Size = new System.Drawing.Size(46, 17);
            this._btn_bestValue.TabIndex = 2;
            this._btn_bestValue.Text = "Best";
            this._btn_bestValue.UseVisualStyleBackColor = true;
            // 
            // _crossingControl
            // 
            this._crossingControl.CrossHeader = "Cross:";
            this._crossingControl.Header = "Select Question:";
            this._crossingControl.Location = new System.Drawing.Point(3, 3);
            this._crossingControl.Name = "_crossingControl";
            this._crossingControl.Size = new System.Drawing.Size(458, 214);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.DataItems.SingleQuestionSelectorControl _selectQ;
        internal System.Windows.Forms.Panel _comparativePanel;
        internal Controls.DataItems.SingleQuestionSelectorCrossingControl _crossingControl;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton _btn_averageValue;
        public System.Windows.Forms.RadioButton _btn_downValue;
        public System.Windows.Forms.RadioButton _btn_worstValue;
        public System.Windows.Forms.RadioButton _btn_bestValue;

    }
}
