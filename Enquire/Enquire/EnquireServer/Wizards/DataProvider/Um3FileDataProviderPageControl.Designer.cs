namespace Compucare.Enquire.EnquireServer.Wizards.DataProvider
{
    partial class Um3FileDataProviderPageControl
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
            this._textBoxFile = new System.Windows.Forms.TextBox();
            this._selectFileButton = new System.Windows.Forms.Button();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._namingControl = new Compucare.Enquire.EnquireServer.Controls.StandardNamingControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filename:";
            // 
            // _textBoxFile
            // 
            this._textBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxFile.Location = new System.Drawing.Point(80, 6);
            this._textBoxFile.Name = "_textBoxFile";
            this._textBoxFile.Size = new System.Drawing.Size(255, 20);
            this._textBoxFile.TabIndex = 1;
            // 
            // _selectFileButton
            // 
            this._selectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._selectFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectFileButton.Location = new System.Drawing.Point(334, 5);
            this._selectFileButton.Name = "_selectFileButton";
            this._selectFileButton.Size = new System.Drawing.Size(32, 20);
            this._selectFileButton.TabIndex = 2;
            this._selectFileButton.Text = "...";
            this._selectFileButton.UseVisualStyleBackColor = true;
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "UMV 2008 Type Files (*.um3)|*.um3|UMV 2008 Type File (Old Format) (*.um2)|*.um2";
            // 
            // _namingControl
            // 
            this._namingControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._namingControl.Description = "";
            this._namingControl.DisplayName = "";
            this._namingControl.Location = new System.Drawing.Point(0, 32);
            this._namingControl.Name = "_namingControl";
            this._namingControl.Size = new System.Drawing.Size(368, 107);
            this._namingControl.TabIndex = 3;
            // 
            // Um3FileDataProviderPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._namingControl);
            this.Controls.Add(this._selectFileButton);
            this.Controls.Add(this._textBoxFile);
            this.Controls.Add(this.label1);
            this.Name = "Um3FileDataProviderPageControl";
            this.Size = new System.Drawing.Size(380, 216);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.OpenFileDialog _openFileDialog;
        internal System.Windows.Forms.Button _selectFileButton;
        internal System.Windows.Forms.TextBox _textBoxFile;
        internal Controls.StandardNamingControl _namingControl;
    }
}
