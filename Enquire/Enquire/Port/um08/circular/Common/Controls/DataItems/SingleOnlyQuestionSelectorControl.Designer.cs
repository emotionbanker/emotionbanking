namespace Compucare.Enquire.Common.Controls.DataItems
{
    partial class SingleOnlyQuestionSelectorControl
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
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._headGroup = new System.Windows.Forms.GroupBox();
            this._questionSelect = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            this._headGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolTip
            // 
            this._toolTip.BackColor = System.Drawing.Color.White;
            this._toolTip.ForeColor = System.Drawing.Color.Black;
            // 
            // _headGroup
            // 
            this._headGroup.Controls.Add(this._questionSelect);
            this._headGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this._headGroup.Location = new System.Drawing.Point(0, 0);
            this._headGroup.Name = "_headGroup";
            this._headGroup.Size = new System.Drawing.Size(442, 53);
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
            this._questionSelect.Size = new System.Drawing.Size(430, 20);
            this._questionSelect.TabIndex = 1;
            // 
            // SingleOnlyQuestionSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._headGroup);
            this.Name = "SingleOnlyQuestionSelectorControl";
            this.Size = new System.Drawing.Size(442, 53);
            this._headGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolTip _toolTip;
        protected System.Windows.Forms.GroupBox _headGroup;
        internal Utils.DropDownTextbox _questionSelect;

    }
}
