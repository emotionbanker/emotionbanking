namespace Compucare.Frontends.Common.Controls
{
    partial class ColorSelector
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
            this._colorPanel = new System.Windows.Forms.Panel();
            this._colorDialog = new System.Windows.Forms.ColorDialog();
            this._selectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _colorPanel
            // 
            this._colorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._colorPanel.Location = new System.Drawing.Point(3, 4);
            this._colorPanel.Name = "_colorPanel";
            this._colorPanel.Size = new System.Drawing.Size(40, 16);
            this._colorPanel.TabIndex = 0;
            // 
            // _selectButton
            // 
            this._selectButton.Location = new System.Drawing.Point(46, 0);
            this._selectButton.Name = "_selectButton";
            this._selectButton.Size = new System.Drawing.Size(75, 23);
            this._selectButton.TabIndex = 1;
            this._selectButton.Text = "choose...";
            this._selectButton.UseVisualStyleBackColor = true;
            this._selectButton.Click += new System.EventHandler(this._selectButton_Click);
            // 
            // ColorSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._selectButton);
            this.Controls.Add(this._colorPanel);
            this.Name = "ColorSelector";
            this.Size = new System.Drawing.Size(123, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _colorPanel;
        private System.Windows.Forms.ColorDialog _colorDialog;
        private System.Windows.Forms.Button _selectButton;
    }
}
