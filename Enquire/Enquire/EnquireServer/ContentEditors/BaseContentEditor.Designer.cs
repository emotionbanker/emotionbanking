namespace Compucare.Enquire.EnquireServer.ContentEditors
{
    partial class BaseContentEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._headPicture = new System.Windows.Forms.PictureBox();
            this._headLabel = new System.Windows.Forms.Label();
            this._contentPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._headPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._headLabel);
            this.panel1.Controls.Add(this._headPicture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 57);
            this.panel1.TabIndex = 0;
            // 
            // _headPicture
            // 
            this._headPicture.Location = new System.Drawing.Point(3, 3);
            this._headPicture.Name = "_headPicture";
            this._headPicture.Size = new System.Drawing.Size(48, 48);
            this._headPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._headPicture.TabIndex = 0;
            this._headPicture.TabStop = false;
            // 
            // _headLabel
            // 
            this._headLabel.AutoSize = true;
            this._headLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._headLabel.Location = new System.Drawing.Point(57, 16);
            this._headLabel.Name = "_headLabel";
            this._headLabel.Size = new System.Drawing.Size(0, 24);
            this._headLabel.TabIndex = 1;
            // 
            // _contentPanel
            // 
            this._contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._contentPanel.Location = new System.Drawing.Point(0, 63);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Size = new System.Drawing.Size(511, 299);
            this._contentPanel.TabIndex = 1;
            // 
            // BaseContentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._contentPanel);
            this.Controls.Add(this.panel1);
            this.Name = "BaseContentEditor";
            this.Size = new System.Drawing.Size(511, 362);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._headPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.PictureBox _headPicture;
        internal System.Windows.Forms.Label _headLabel;
        internal System.Windows.Forms.Panel _contentPanel;
    }
}
