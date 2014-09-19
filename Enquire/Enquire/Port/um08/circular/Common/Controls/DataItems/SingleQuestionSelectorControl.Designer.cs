namespace Compucare.Enquire.Common.Controls.DataItems
{
    partial class SingleQuestionSelectorControl
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
            this._validityIndicator = new System.Windows.Forms.PictureBox();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._headGroup = new System.Windows.Forms.GroupBox();
            this._questionSelect = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            this._usergSelect = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            ((System.ComponentModel.ISupportInitialize)(this._validityIndicator)).BeginInit();
            this._headGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // _validityIndicator
            // 
            this._validityIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._validityIndicator.Cursor = System.Windows.Forms.Cursors.Help;
            this._validityIndicator.Location = new System.Drawing.Point(416, 19);
            this._validityIndicator.Name = "_validityIndicator";
            this._validityIndicator.Size = new System.Drawing.Size(17, 20);
            this._validityIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._validityIndicator.TabIndex = 1;
            this._validityIndicator.TabStop = false;
            // 
            // _toolTip
            // 
            this._toolTip.BackColor = System.Drawing.Color.White;
            this._toolTip.ForeColor = System.Drawing.Color.Black;
            // 
            // _headGroup
            // 
            this._headGroup.Controls.Add(this._questionSelect);
            this._headGroup.Controls.Add(this._validityIndicator);
            this._headGroup.Controls.Add(this._usergSelect);
            this._headGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this._headGroup.Location = new System.Drawing.Point(0, 0);
            this._headGroup.Name = "_headGroup";
            this._headGroup.Size = new System.Drawing.Size(439, 51);
            this._headGroup.TabIndex = 3;
            this._headGroup.TabStop = false;
            this._headGroup.Text = "Select Question";
            // 
            // _questionSelect
            // 
            this._questionSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._questionSelect.InitString = "choose question...";
            this._questionSelect.Location = new System.Drawing.Point(6, 19);
            this._questionSelect.Name = "_questionSelect";
            this._questionSelect.Size = new System.Drawing.Size(206, 20);
            this._questionSelect.TabIndex = 0;
            // 
            // _usergSelect
            // 
            this._usergSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._usergSelect.InitString = "choose user group...";
            this._usergSelect.Location = new System.Drawing.Point(218, 19);
            this._usergSelect.Name = "_usergSelect";
            this._usergSelect.Size = new System.Drawing.Size(192, 20);
            this._usergSelect.TabIndex = 2;
            // 
            // SingleQuestionSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._headGroup);
            this.Name = "SingleQuestionSelectorControl";
            this.Size = new System.Drawing.Size(439, 51);
            ((System.ComponentModel.ISupportInitialize)(this._validityIndicator)).EndInit();
            this._headGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Utils.DropDownTextbox _questionSelect;
        internal System.Windows.Forms.PictureBox _validityIndicator;
        internal System.Windows.Forms.ToolTip _toolTip;
        internal Utils.DropDownTextbox _usergSelect;
        protected System.Windows.Forms.GroupBox _headGroup;

    }
}
