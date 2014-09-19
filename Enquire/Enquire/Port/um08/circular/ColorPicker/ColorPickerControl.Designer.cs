namespace Compucare.Enquire.Common.Controls.Utils.ColorPicker
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
            this._colorButton = new System.Windows.Forms.Button();
            this._colorDialog = new System.Windows.Forms.ColorDialog();
            this._textName = new System.Windows.Forms.TextBox();
            this._textWidth = new System.Windows.Forms.TextBox();
            this._comboBoxDashStyles = new System.Windows.Forms.ComboBox();
            this._lb_ChangeProperties = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _colorButton
            // 
            this._colorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._colorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._colorButton.Location = new System.Drawing.Point(56, 0);
            this._colorButton.Name = "_colorButton";
            this._colorButton.Size = new System.Drawing.Size(43, 20);
            this._colorButton.TabIndex = 1;
            this._colorButton.UseVisualStyleBackColor = true;
            // 
            // _textName
            // 
            this._textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textName.Location = new System.Drawing.Point(0, 0);
            this._textName.Name = "_textName";
            this._textName.Size = new System.Drawing.Size(60, 20);
            this._textName.TabIndex = 2;
            // 
            // _textWidth
            // 
            this._textWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._textWidth.Location = new System.Drawing.Point(96, 0);
            this._textWidth.Name = "_textWidth";
            this._textWidth.Size = new System.Drawing.Size(35, 20);
            this._textWidth.TabIndex = 3;
            // 
            // _comboBoxDashStyles
            // 
            this._comboBoxDashStyles.FormattingEnabled = true;
            this._comboBoxDashStyles.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this._comboBoxDashStyles.Location = new System.Drawing.Point(157, -1);
            this._comboBoxDashStyles.Name = "_comboBoxDashStyles";
            this._comboBoxDashStyles.Size = new System.Drawing.Size(86, 21);
            this._comboBoxDashStyles.TabIndex = 4;
            // 
            // _lb_ChangeProperties
            // 
            this._lb_ChangeProperties.AutoSize = true;
            this._lb_ChangeProperties.Location = new System.Drawing.Point(242, 2);
            this._lb_ChangeProperties.Name = "_lb_ChangeProperties";
            this._lb_ChangeProperties.Size = new System.Drawing.Size(17, 13);
            this._lb_ChangeProperties.TabIndex = 5;
            this._lb_ChangeProperties.Text = "  *";
            this._lb_ChangeProperties.Visible = false;
            // 
            // ColorPickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._lb_ChangeProperties);
            this.Controls.Add(this._comboBoxDashStyles);
            this.Controls.Add(this._textWidth);
            this.Controls.Add(this._textName);
            this.Controls.Add(this._colorButton);
            this.Name = "ColorPickerControl";
            this.Size = new System.Drawing.Size(260, 20);
            this.Load += new System.EventHandler(this.ColorPickerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button _colorButton;
        private System.Windows.Forms.ColorDialog _colorDialog;
        internal System.Windows.Forms.TextBox _textName;
        internal System.Windows.Forms.TextBox _textWidth;
        internal System.Windows.Forms.ComboBox _comboBoxDashStyles;
        private System.Windows.Forms.Label _lb_ChangeProperties;
    }
}
