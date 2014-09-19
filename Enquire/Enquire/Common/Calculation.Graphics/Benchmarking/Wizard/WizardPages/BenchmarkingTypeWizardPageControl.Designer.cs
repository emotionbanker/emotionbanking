namespace Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard.WizardPages
{
    partial class BenchmarkingTypeWizardPageControl
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
            this._radioSimple = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this._radioComparative = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Creates a simple benchmarking bar based on one question, compared to all targets." +
                "";
            // 
            // _radioSimple
            // 
            this._radioSimple.AutoSize = true;
            this._radioSimple.Checked = true;
            this._radioSimple.Location = new System.Drawing.Point(41, 3);
            this._radioSimple.Name = "_radioSimple";
            this._radioSimple.Size = new System.Drawing.Size(127, 17);
            this._radioSimple.TabIndex = 21;
            this._radioSimple.TabStop = true;
            this._radioSimple.Text = "Simple Benchmarking";
            this._radioSimple.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(38, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Creates a benchmarking bar for one question, based on other data and a separator." +
                "";
            // 
            // _radioComparative
            // 
            this._radioComparative.AutoSize = true;
            this._radioComparative.Location = new System.Drawing.Point(41, 41);
            this._radioComparative.Name = "_radioComparative";
            this._radioComparative.Size = new System.Drawing.Size(155, 17);
            this._radioComparative.TabIndex = 24;
            this._radioComparative.TabStop = true;
            this._radioComparative.Text = "Comparative Benchmarking";
            this._radioComparative.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Compucare.Enquire.Common.Calculation.Graphics.Pictures.page_3sides;
            this.pictureBox2.Location = new System.Drawing.Point(3, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Compucare.Enquire.Common.Calculation.Graphics.Pictures.page_2sides;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // BenchmarkingTypeWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this._radioComparative);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._radioSimple);
            this.Name = "BenchmarkingTypeWizardPageControl";
            this.Size = new System.Drawing.Size(464, 238);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.RadioButton _radioSimple;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.RadioButton _radioComparative;
    }
}
