namespace Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard.WizardPages
{
    partial class TrafficLightRangeWizardPageControl
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
            this.colorSelector1 = new Compucare.Frontends.Common.Controls.ColorSelector();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._colorRangeControl = new Compucare.Enquire.Common.Calculation.Graphics.Common.Controls.ColorRanges.TripleColorRangeControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._textSize = new Compucare.Frontends.Common.Controls.IntegerTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorSelector1
            // 
            this.colorSelector1.Color = System.Drawing.SystemColors.Control;
            this.colorSelector1.Location = new System.Drawing.Point(239, 62);
            this.colorSelector1.Name = "colorSelector1";
            this.colorSelector1.Size = new System.Drawing.Size(123, 23);
            this.colorSelector1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._colorRangeControl);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 108);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ranges and Colors";
            // 
            // _colorRangeControl
            // 
            this._colorRangeControl.ColorHigh = System.Drawing.SystemColors.Control;
            this._colorRangeControl.ColorLow = System.Drawing.SystemColors.Control;
            this._colorRangeControl.ColorMid = System.Drawing.SystemColors.Control;
            this._colorRangeControl.Location = new System.Drawing.Point(13, 17);
            this._colorRangeControl.MaxValue = 0D;
            this._colorRangeControl.MinValue = 0D;
            this._colorRangeControl.Name = "_colorRangeControl";
            this._colorRangeControl.RangeHigh = 0D;
            this._colorRangeControl.RangeMid = 0D;
            this._colorRangeControl.Size = new System.Drawing.Size(406, 85);
            this._colorRangeControl.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._textSize);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(0, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 53);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Size";
            // 
            // _textSize
            // 
            this._textSize.Int32Value = 0;
            this._textSize.Location = new System.Drawing.Point(84, 19);
            this._textSize.Name = "_textSize";
            this._textSize.Size = new System.Drawing.Size(116, 20);
            this._textSize.TabIndex = 2;
            this._textSize.Text = "0";
            this._textSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Radius/Size:";
            // 
            // TrafficLightRangeWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TrafficLightRangeWizardPageControl";
            this.Size = new System.Drawing.Size(533, 266);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Frontends.Common.Controls.ColorSelector colorSelector1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        internal Frontends.Common.Controls.IntegerTextBox _textSize;
        internal Common.Controls.ColorRanges.TripleColorRangeControl _colorRangeControl;
    }
}
