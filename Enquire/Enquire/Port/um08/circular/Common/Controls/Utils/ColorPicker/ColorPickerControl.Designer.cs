namespace Compucare.Enquire.Common.Controls.Utils.ColorPickerUtil
{
    partial class ColorPickerControl
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
            this._textLabel = new System.Windows.Forms.Label();
            this._colorButton = new System.Windows.Forms.Button();
            this._colorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // _textLabel
            // 
            this._textLabel.AutoSize = true;
            this._textLabel.Location = new System.Drawing.Point(3, 3);
            this._textLabel.Name = "_textLabel";
            this._textLabel.Size = new System.Drawing.Size(31, 13);
            this._textLabel.TabIndex = 0;
            this._textLabel.Text = "Color";
            // 
            // _colorButton
            // 
            this._colorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._colorButton.Location = new System.Drawing.Point(141, 1);
            this._colorButton.Name = "_colorButton";
            this._colorButton.Size = new System.Drawing.Size(49, 18);
            this._colorButton.TabIndex = 1;
            this._colorButton.UseVisualStyleBackColor = true;
            // 
            // ColorPickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._colorButton);
            this.Controls.Add(this._textLabel);
            this.Name = "ColorPickerControl";
            this.Size = new System.Drawing.Size(191, 20);
            this.Load += new System.EventHandler(this.ColorPickerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _textLabel;
        internal System.Windows.Forms.Button _colorButton;
        private System.Windows.Forms.ColorDialog _colorDialog;
    }
}
