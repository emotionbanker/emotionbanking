namespace Compucare.Enquire.EnquireServer.Controls
{
    partial class DataSourceManagementControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSourceManagementControl));
            this._tree = new System.Windows.Forms.TreeView();
            this._folderImages = new System.Windows.Forms.ImageList();
            this.panel1 = new System.Windows.Forms.Panel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._listPanel = new Compucare.Enquire.Common.Controls.ListPanel();
            this._contextMenuLeaf = new System.Windows.Forms.ContextMenuStrip();
            this._addDataSourceButton = new System.Windows.Forms.ToolStripButton();
            this._removeDataSourceButton = new System.Windows.Forms.ToolStripButton();
            this._leafGetData = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this._contextMenuLeaf.SuspendLayout();
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
            this._tree.Size = new System.Drawing.Size(190, 195);
            this._tree.TabIndex = 6;
            // 
            // _folderImages
            // 
            this._folderImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_folderImages.ImageStream")));
            this._folderImages.TransparentColor = System.Drawing.Color.Transparent;
            this._folderImages.Images.SetKeyName(0, "folder.png");
            this._folderImages.Images.SetKeyName(1, "file-doc.png");
            this._folderImages.Images.SetKeyName(2, "insert-chart-bar.png");
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
            this._addDataSourceButton,
            this._removeDataSourceButton});
            this._toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(189, 23);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _listPanel
            // 
            this._listPanel.BackColor = System.Drawing.SystemColors.Control;
            this._listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listPanel.Header = "Data Sources";
            this._listPanel.HeaderColor = System.Drawing.SystemColors.ActiveCaption;
            this._listPanel.HeadImage = null;
            this._listPanel.Location = new System.Drawing.Point(0, 0);
            this._listPanel.Name = "_listPanel";
            this._listPanel.Size = new System.Drawing.Size(185, 243);
            this._listPanel.TabIndex = 4;
            // 
            // _contextMenuLeaf
            // 
            this._contextMenuLeaf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._leafGetData});
            this._contextMenuLeaf.Name = "_contextMenu";
            this._contextMenuLeaf.Size = new System.Drawing.Size(120, 26);
            // 
            // _addDataSourceButton
            // 
            this._addDataSourceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addDataSourceButton.Image = ((System.Drawing.Image)(resources.GetObject("_addDataSourceButton.Image")));
            this._addDataSourceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addDataSourceButton.Name = "_addDataSourceButton";
            this._addDataSourceButton.Size = new System.Drawing.Size(23, 20);
            this._addDataSourceButton.Text = "Add User";
            // 
            // _removeDataSourceButton
            // 
            this._removeDataSourceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._removeDataSourceButton.Image = ((System.Drawing.Image)(resources.GetObject("_removeDataSourceButton.Image")));
            this._removeDataSourceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._removeDataSourceButton.Name = "_removeDataSourceButton";
            this._removeDataSourceButton.Size = new System.Drawing.Size(23, 20);
            this._removeDataSourceButton.Text = "Remove User";
            // 
            // _leafGetData
            // 
            this._leafGetData.Image = ((System.Drawing.Image)(resources.GetObject("_leafGetData.Image")));
            this._leafGetData.Name = "_leafGetData";
            this._leafGetData.Size = new System.Drawing.Size(119, 22);
            this._leafGetData.Text = "Get Data";
            // 
            // DataSourceManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tree);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._listPanel);
            this.Name = "DataSourceManagementControl";
            this.Size = new System.Drawing.Size(185, 243);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._contextMenuLeaf.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView _tree;
        private System.Windows.Forms.ImageList _folderImages;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ToolStrip _toolStrip;
        internal System.Windows.Forms.ToolStripButton _addDataSourceButton;
        internal System.Windows.Forms.ToolStripButton _removeDataSourceButton;
        internal Common.Controls.ListPanel _listPanel;
        internal System.Windows.Forms.ContextMenuStrip _contextMenuLeaf;
        internal System.Windows.Forms.ToolStripMenuItem _leafGetData;

    }
}
