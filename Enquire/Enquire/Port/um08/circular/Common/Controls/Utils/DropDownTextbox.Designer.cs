namespace Compucare.Enquire.Common.Controls.Utils
{
    partial class DropDownTextbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropDownTextbox));
            this._textbox = new System.Windows.Forms.TextBox();
            this._dropButton = new System.Windows.Forms.Button();
            this._tree = new System.Windows.Forms.TreeView();
            this._activityIndicator = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._activityIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // _textbox
            // 
            this._textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textbox.Location = new System.Drawing.Point(0, 0);
            this._textbox.Name = "_textbox";
            this._textbox.Size = new System.Drawing.Size(217, 20);
            this._textbox.TabIndex = 1;
            // 
            // _dropButton
            // 
            this._dropButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dropButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_dropButton.BackgroundImage")));
            this._dropButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._dropButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._dropButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._dropButton.Location = new System.Drawing.Point(216, 0);
            this._dropButton.Name = "_dropButton";
            this._dropButton.Size = new System.Drawing.Size(18, 20);
            this._dropButton.TabIndex = 2;
            this._dropButton.TabStop = false;
            this._dropButton.UseVisualStyleBackColor = true;
            // 
            // _tree
            // 
            this._tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tree.Location = new System.Drawing.Point(0, 35);
            this._tree.Name = "_tree";
            this._tree.ShowLines = false;
            this._tree.ShowRootLines = false;
            this._tree.Size = new System.Drawing.Size(234, 155);
            this._tree.TabIndex = 4;
            // 
            // _activityIndicator
            // 
            this._activityIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this._activityIndicator.Image = ((System.Drawing.Image)(resources.GetObject("_activityIndicator.Image")));
            this._activityIndicator.Location = new System.Drawing.Point(0, 0);
            this._activityIndicator.Name = "_activityIndicator";
            this._activityIndicator.Size = new System.Drawing.Size(234, 20);
            this._activityIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._activityIndicator.TabIndex = 5;
            this._activityIndicator.TabStop = false;
            this._activityIndicator.Visible = false;
            // 
            // DropDownTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._activityIndicator);
            this.Controls.Add(this._tree);
            this.Controls.Add(this._dropButton);
            this.Controls.Add(this._textbox);
            this.Name = "DropDownTextbox";
            this.Size = new System.Drawing.Size(234, 20);
            ((System.ComponentModel.ISupportInitialize)(this._activityIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox _textbox;
        internal System.Windows.Forms.Button _dropButton;
        internal System.Windows.Forms.TreeView _tree;
        internal System.Windows.Forms.PictureBox _activityIndicator;
    }
}
