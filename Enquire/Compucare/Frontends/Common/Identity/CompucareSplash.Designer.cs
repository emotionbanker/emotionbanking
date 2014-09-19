namespace Compucare.Frontends.Common.Identity
{
    partial class CompucareSplash
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._productSuiteLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._currentOperationLabel = new System.Windows.Forms.Label();
            this._productNameLabel = new System.Windows.Forms.Label();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._partnerPic1 = new System.Windows.Forms.PictureBox();
            this._loadingBar = new System.Windows.Forms.ProgressBar();
            this._copyrightLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._partnerPic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _productSuiteLabel
            // 
            this._productSuiteLabel.AutoSize = true;
            this._productSuiteLabel.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Italic);
            this._productSuiteLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this._productSuiteLabel.Location = new System.Drawing.Point(186, 124);
            this._productSuiteLabel.Name = "_productSuiteLabel";
            this._productSuiteLabel.Size = new System.Drawing.Size(170, 37);
            this._productSuiteLabel.TabIndex = 1;
            this._productSuiteLabel.Text = "ProductSuite";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._currentOperationLabel);
            this.panel1.Controls.Add(this._productNameLabel);
            this.panel1.Controls.Add(this._descriptionLabel);
            this.panel1.Controls.Add(this._partnerPic1);
            this.panel1.Controls.Add(this._loadingBar);
            this.panel1.Controls.Add(this._copyrightLabel);
            this.panel1.Controls.Add(this._productSuiteLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 253);
            this.panel1.TabIndex = 2;
            // 
            // _currentOperationLabel
            // 
            this._currentOperationLabel.AutoSize = true;
            this._currentOperationLabel.Location = new System.Drawing.Point(7, 190);
            this._currentOperationLabel.Name = "_currentOperationLabel";
            this._currentOperationLabel.Size = new System.Drawing.Size(92, 13);
            this._currentOperationLabel.TabIndex = 9;
            this._currentOperationLabel.Text = "Current Operation";
            // 
            // _productNameLabel
            // 
            this._productNameLabel.AutoSize = true;
            this._productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this._productNameLabel.Location = new System.Drawing.Point(7, 149);
            this._productNameLabel.Name = "_productNameLabel";
            this._productNameLabel.Size = new System.Drawing.Size(117, 20);
            this._productNameLabel.TabIndex = 8;
            this._productNameLabel.Text = "ProductName";
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(7, 174);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(61, 13);
            this._descriptionLabel.TabIndex = 7;
            this._descriptionLabel.Text = "Description";
            // 
            // _partnerPic1
            // 
            this._partnerPic1.Location = new System.Drawing.Point(265, 11);
            this._partnerPic1.Name = "_partnerPic1";
            this._partnerPic1.Size = new System.Drawing.Size(159, 56);
            this._partnerPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._partnerPic1.TabIndex = 6;
            this._partnerPic1.TabStop = false;
            // 
            // _loadingBar
            // 
            this._loadingBar.Location = new System.Drawing.Point(309, 222);
            this._loadingBar.Name = "_loadingBar";
            this._loadingBar.Size = new System.Drawing.Size(113, 13);
            this._loadingBar.TabIndex = 4;
            // 
            // _copyrightLabel
            // 
            this._copyrightLabel.AutoSize = true;
            this._copyrightLabel.Location = new System.Drawing.Point(6, 222);
            this._copyrightLabel.Name = "_copyrightLabel";
            this._copyrightLabel.Size = new System.Drawing.Size(177, 13);
            this._copyrightLabel.TabIndex = 2;
            this._copyrightLabel.Text = "© COMPUCARE Dr. Maczejka && CO KG";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Compucare.Frontends.Common.Pictures.logo_120;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 135);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CompucareSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 253);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CompucareSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompucareSplash";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._partnerPic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label _productSuiteLabel;
        internal System.Windows.Forms.ProgressBar _loadingBar;
        internal System.Windows.Forms.Label _copyrightLabel;
        internal System.Windows.Forms.PictureBox _partnerPic1;
        public System.Windows.Forms.Label _descriptionLabel;
        internal System.Windows.Forms.Label _productNameLabel;
        internal System.Windows.Forms.Label _currentOperationLabel;
    }
}