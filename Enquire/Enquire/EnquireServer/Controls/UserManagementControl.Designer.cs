namespace Compucare.Enquire.EnquireServer.Controls
{
    partial class UserManagementControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagementControl));
            this._tree = new System.Windows.Forms.TreeView();
            this._folderImages = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._addUserButton = new System.Windows.Forms.ToolStripButton();
            this._removeUserButton = new System.Windows.Forms.ToolStripButton();
            this._listPanel = new Compucare.Enquire.Common.Controls.ListPanel();
            this.panel1.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tree
            // 
            this._tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tree.ImageIndex = 0;
            this._tree.ImageList = this._folderImages;
            this._tree.ItemHeight = 16;
            this._tree.Location = new System.Drawing.Point(-1, 49);
            this._tree.Name = "_tree";
            this._tree.SelectedImageIndex = 0;
            this._tree.ShowRootLines = false;
            this._tree.Size = new System.Drawing.Size(190, 195);
            this._tree.TabIndex = 6;
            // 
            // _folderImages
            // 
            this._folderImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_folderImages.ImageStream")));
            this._folderImages.TransparentColor = System.Drawing.Color.Transparent;
            this._folderImages.Images.SetKeyName(0, "preferences-desktop-user-2.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this._toolStrip);
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 26);
            this.panel1.TabIndex = 5;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addUserButton,
            this._removeUserButton});
            this._toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(189, 23);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _addUserButton
            // 
            this._addUserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addUserButton.Image = global::Compucare.Enquire.EnquireServer.Pictures.user_new_3;
            this._addUserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addUserButton.Name = "_addUserButton";
            this._addUserButton.Size = new System.Drawing.Size(23, 20);
            this._addUserButton.Text = "Add User";
            // 
            // _removeUserButton
            // 
            this._removeUserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._removeUserButton.Image = global::Compucare.Enquire.EnquireServer.Pictures.user_delete_2;
            this._removeUserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._removeUserButton.Name = "_removeUserButton";
            this._removeUserButton.Size = new System.Drawing.Size(23, 20);
            this._removeUserButton.Text = "Remove User";
            // 
            // _listPanel
            // 
            this._listPanel.BackColor = System.Drawing.SystemColors.Control;
            this._listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listPanel.Header = "User Management";
            this._listPanel.HeaderColor = System.Drawing.SystemColors.ActiveCaption;
            this._listPanel.Location = new System.Drawing.Point(0, 0);
            this._listPanel.Name = "_listPanel";
            this._listPanel.Size = new System.Drawing.Size(185, 243);
            this._listPanel.TabIndex = 4;
            // 
            // UserManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tree);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._listPanel);
            this.Name = "UserManagementControl";
            this.Size = new System.Drawing.Size(185, 243);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView _tree;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ToolStrip _toolStrip;
        internal System.Windows.Forms.ToolStripButton _addUserButton;
        internal System.Windows.Forms.ToolStripButton _removeUserButton;
        private System.Windows.Forms.ImageList _folderImages;
        internal Common.Controls.ListPanel _listPanel;

    }
}
