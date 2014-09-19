namespace Compucare.Enquire.EnquireServer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this._contentPanel = new System.Windows.Forms.Panel();
            this.listPanel3 = new Compucare.Enquire.Common.Controls.ListPanel();
            this._dataSourceManagementControl = new Compucare.Enquire.EnquireServer.Controls.DataSourceManagementControl();
            this._userManagementControl = new Compucare.Enquire.EnquireServer.Controls.UserManagementControl();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this._statusStrip.Location = new System.Drawing.Point(0, 455);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._statusStrip.Size = new System.Drawing.Size(926, 22);
            this._statusStrip.TabIndex = 0;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _statusLabel
            // 
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(39, 17);
            this._statusLabel.Text = "Status";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(770, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // _contentPanel
            // 
            this._contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._contentPanel.BackColor = System.Drawing.SystemColors.Control;
            this._contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._contentPanel.Location = new System.Drawing.Point(252, 0);
            this._contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Size = new System.Drawing.Size(468, 452);
            this._contentPanel.TabIndex = 5;
            // 
            // listPanel3
            // 
            this.listPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.listPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listPanel3.Header = "Tasks";
            this.listPanel3.HeaderColor = System.Drawing.SystemColors.ActiveCaption;
            this.listPanel3.HeadImage = null;
            this.listPanel3.Location = new System.Drawing.Point(723, 240);
            this.listPanel3.Name = "listPanel3";
            this.listPanel3.Size = new System.Drawing.Size(203, 212);
            this.listPanel3.TabIndex = 6;
            // 
            // _dataSourceManagementControl
            // 
            this._dataSourceManagementControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._dataSourceManagementControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._dataSourceManagementControl.Location = new System.Drawing.Point(0, 0);
            this._dataSourceManagementControl.Name = "_dataSourceManagementControl";
            this._dataSourceManagementControl.Size = new System.Drawing.Size(249, 452);
            this._dataSourceManagementControl.TabIndex = 8;
            // 
            // _userManagementControl
            // 
            this._userManagementControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._userManagementControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._userManagementControl.Location = new System.Drawing.Point(723, 0);
            this._userManagementControl.Name = "_userManagementControl";
            this._userManagementControl.Size = new System.Drawing.Size(203, 241);
            this._userManagementControl.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 477);
            this.Controls.Add(this._dataSourceManagementControl);
            this.Controls.Add(this._userManagementControl);
            this.Controls.Add(this.listPanel3);
            this.Controls.Add(this._contentPanel);
            this.Controls.Add(this._statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(942, 515);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enquire 2011 Server";
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        internal System.Windows.Forms.ToolStripStatusLabel _statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        internal System.Windows.Forms.Panel _contentPanel;
        private Common.Controls.ListPanel listPanel3;
        internal Controls.UserManagementControl _userManagementControl;
        internal Controls.DataSourceManagementControl _dataSourceManagementControl;

    }
}

