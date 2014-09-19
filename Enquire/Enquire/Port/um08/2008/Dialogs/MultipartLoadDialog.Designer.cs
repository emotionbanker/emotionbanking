namespace umfrage2._2008.Dialogs
{
    partial class MultipartLoadDialog
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
            this.EndButton = new System.Windows.Forms.Button();
            this.DoneLabel = new System.Windows.Forms.Label();
            this.status = new umfrage2._2008.MultipartStatus();
            this.SuspendLayout();
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(345, 211);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(101, 24);
            this.EndButton.TabIndex = 1;
            this.EndButton.Text = "Weiter";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // DoneLabel
            // 
            this.DoneLabel.AutoSize = true;
            this.DoneLabel.Location = new System.Drawing.Point(21, 217);
            this.DoneLabel.Name = "DoneLabel";
            this.DoneLabel.Size = new System.Drawing.Size(189, 13);
            this.DoneLabel.TabIndex = 2;
            this.DoneLabel.Text = "Die Daten wurden erfolgreich geladen.";
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.Location = new System.Drawing.Point(12, 12);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(434, 188);
            this.status.TabIndex = 0;
            this.status.Load += new System.EventHandler(this.status_Load);
            // 
            // MultipartLoadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 260);
            this.Controls.Add(this.DoneLabel);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MultipartLoadDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Umfrageverwaltung 2008";
            this.Load += new System.EventHandler(this.MultipartLoadDialog_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MultipartSaveDialog_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MultipartStatus status;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Label DoneLabel;
    }
}