namespace Compucare.Frontends.Common.Forms
{
    partial class ExceptionVisualisationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionVisualisationForm));
            this._okButton = new System.Windows.Forms.Button();
            this._messageBox = new System.Windows.Forms.TextBox();
            this._stacktraceBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._sendMail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Location = new System.Drawing.Point(592, 295);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _messageBox
            // 
            this._messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._messageBox.Location = new System.Drawing.Point(67, 12);
            this._messageBox.Multiline = true;
            this._messageBox.Name = "_messageBox";
            this._messageBox.ReadOnly = true;
            this._messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._messageBox.Size = new System.Drawing.Size(600, 45);
            this._messageBox.TabIndex = 1;
            // 
            // _stacktraceBox
            // 
            this._stacktraceBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._stacktraceBox.Location = new System.Drawing.Point(12, 63);
            this._stacktraceBox.Multiline = true;
            this._stacktraceBox.Name = "_stacktraceBox";
            this._stacktraceBox.ReadOnly = true;
            this._stacktraceBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._stacktraceBox.Size = new System.Drawing.Size(655, 226);
            this._stacktraceBox.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Compucare.Frontends.Common.Icons.dialog_error_4_48;
            this.pictureBox1.Location = new System.Drawing.Point(13, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // _sendMail
            // 
            this._sendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._sendMail.Location = new System.Drawing.Point(12, 295);
            this._sendMail.Name = "_sendMail";
            this._sendMail.Size = new System.Drawing.Size(195, 23);
            this._sendMail.TabIndex = 5;
            this._sendMail.Text = "Send as mail to support";
            this._sendMail.UseVisualStyleBackColor = true;
            // 
            // ExceptionVisualisationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 330);
            this.Controls.Add(this._sendMail);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._stacktraceBox);
            this.Controls.Add(this._messageBox);
            this.Controls.Add(this._okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExceptionVisualisationForm";
            this.Text = "Exception";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox _messageBox;
        internal System.Windows.Forms.Button _okButton;
        internal System.Windows.Forms.TextBox _stacktraceBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Button _sendMail;
    }
}