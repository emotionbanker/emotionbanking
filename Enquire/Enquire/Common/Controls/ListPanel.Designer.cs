namespace Compucare.Enquire.Common.Controls
{
    partial class ListPanel
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
            this._headerPanel = new System.Windows.Forms.Panel();
            this._headerLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._imageBox = new System.Windows.Forms.PictureBox();
            this._headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _headerPanel
            // 
            this._headerPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._headerPanel.Controls.Add(this._imageBox);
            this._headerPanel.Controls.Add(this._headerLabel);
            this._headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._headerPanel.Location = new System.Drawing.Point(0, 0);
            this._headerPanel.Name = "_headerPanel";
            this._headerPanel.Size = new System.Drawing.Size(265, 24);
            this._headerPanel.TabIndex = 0;
            // 
            // _headerLabel
            // 
            this._headerLabel.AutoSize = true;
            this._headerLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._headerLabel.Location = new System.Drawing.Point(22, 6);
            this._headerLabel.Name = "_headerLabel";
            this._headerLabel.Size = new System.Drawing.Size(42, 13);
            this._headerLabel.TabIndex = 0;
            this._headerLabel.Text = "Header";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 266);
            this.panel1.TabIndex = 1;
            // 
            // _imageBox
            // 
            this._imageBox.Location = new System.Drawing.Point(3, 5);
            this._imageBox.Name = "_imageBox";
            this._imageBox.Size = new System.Drawing.Size(16, 16);
            this._imageBox.TabIndex = 0;
            this._imageBox.TabStop = false;
            // 
            // ListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._headerPanel);
            this.Name = "ListPanel";
            this.Size = new System.Drawing.Size(265, 290);
            this._headerPanel.ResumeLayout(false);
            this._headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._imageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel _headerPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _headerLabel;
        private System.Windows.Forms.PictureBox _imageBox;
    }
}
