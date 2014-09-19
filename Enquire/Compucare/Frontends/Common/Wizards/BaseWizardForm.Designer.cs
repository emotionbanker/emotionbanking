namespace Compucare.Frontends.Common.Wizards
{
    partial class BaseWizardForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._labelStepDesc = new System.Windows.Forms.Label();
            this._labelStepHeader = new System.Windows.Forms.Label();
            this._headPicture = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._errorLabel = new System.Windows.Forms.Label();
            this._buttonBack = new System.Windows.Forms.Button();
            this._buttonNext = new System.Windows.Forms.Button();
            this._buttonFinish = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._contentPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._headPicture)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._labelStepDesc);
            this.panel1.Controls.Add(this._labelStepHeader);
            this.panel1.Controls.Add(this._headPicture);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 65);
            this.panel1.TabIndex = 0;
            // 
            // _labelStepDesc
            // 
            this._labelStepDesc.AutoSize = true;
            this._labelStepDesc.Location = new System.Drawing.Point(65, 40);
            this._labelStepDesc.Name = "_labelStepDesc";
            this._labelStepDesc.Size = new System.Drawing.Size(85, 13);
            this._labelStepDesc.TabIndex = 3;
            this._labelStepDesc.Text = "Step Description";
            // 
            // _labelStepHeader
            // 
            this._labelStepHeader.AutoSize = true;
            this._labelStepHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelStepHeader.Location = new System.Drawing.Point(62, 8);
            this._labelStepHeader.Name = "_labelStepHeader";
            this._labelStepHeader.Size = new System.Drawing.Size(179, 24);
            this._labelStepHeader.TabIndex = 2;
            this._labelStepHeader.Text = "Step 0: Step Header";
            // 
            // _headPicture
            // 
            this._headPicture.Location = new System.Drawing.Point(8, 7);
            this._headPicture.Name = "_headPicture";
            this._headPicture.Size = new System.Drawing.Size(48, 48);
            this._headPicture.TabIndex = 1;
            this._headPicture.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this._errorLabel);
            this.panel2.Controls.Add(this._buttonBack);
            this.panel2.Controls.Add(this._buttonNext);
            this.panel2.Controls.Add(this._buttonFinish);
            this.panel2.Controls.Add(this._buttonCancel);
            this.panel2.Location = new System.Drawing.Point(-1, 371);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 35);
            this.panel2.TabIndex = 1;
            // 
            // _errorLabel
            // 
            this._errorLabel.AutoSize = true;
            this._errorLabel.ForeColor = System.Drawing.Color.Red;
            this._errorLabel.Location = new System.Drawing.Point(92, 10);
            this._errorLabel.Name = "_errorLabel";
            this._errorLabel.Size = new System.Drawing.Size(0, 13);
            this._errorLabel.TabIndex = 4;
            // 
            // _buttonBack
            // 
            this._buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonBack.Location = new System.Drawing.Point(312, 5);
            this._buttonBack.Name = "_buttonBack";
            this._buttonBack.Size = new System.Drawing.Size(75, 23);
            this._buttonBack.TabIndex = 3;
            this._buttonBack.Text = "< Back";
            this._buttonBack.UseVisualStyleBackColor = true;
            // 
            // _buttonNext
            // 
            this._buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonNext.Location = new System.Drawing.Point(393, 5);
            this._buttonNext.Name = "_buttonNext";
            this._buttonNext.Size = new System.Drawing.Size(75, 23);
            this._buttonNext.TabIndex = 2;
            this._buttonNext.Text = "Next >";
            this._buttonNext.UseVisualStyleBackColor = true;
            // 
            // _buttonFinish
            // 
            this._buttonFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonFinish.Location = new System.Drawing.Point(474, 5);
            this._buttonFinish.Name = "_buttonFinish";
            this._buttonFinish.Size = new System.Drawing.Size(75, 23);
            this._buttonFinish.TabIndex = 1;
            this._buttonFinish.Text = "Finish";
            this._buttonFinish.UseVisualStyleBackColor = true;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonCancel.Location = new System.Drawing.Point(11, 5);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 0;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _contentPanel
            // 
            this._contentPanel.Location = new System.Drawing.Point(-1, 64);
            this._contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Size = new System.Drawing.Size(562, 304);
            this._contentPanel.TabIndex = 2;
            // 
            // BaseWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 405);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._contentPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BaseWizardForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BaseWizardForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._headPicture)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.PictureBox _headPicture;
        internal System.Windows.Forms.Label _labelStepDesc;
        internal System.Windows.Forms.Label _labelStepHeader;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Panel _contentPanel;
        internal System.Windows.Forms.Button _buttonCancel;
        internal System.Windows.Forms.Button _buttonFinish;
        internal System.Windows.Forms.Button _buttonNext;
        internal System.Windows.Forms.Button _buttonBack;
        internal System.Windows.Forms.Label _errorLabel;
    }
}