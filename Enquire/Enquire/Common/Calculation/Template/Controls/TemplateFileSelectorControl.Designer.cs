namespace Compucare.Enquire.Common.Calculation.Template.Controls
{
    partial class TemplateFileSelectorControl
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
            this._dialogButton = new System.Windows.Forms.Button();
            this._textLocation = new System.Windows.Forms.TextBox();
            this._openTemplateDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveTemplateDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // _dialogButton
            // 
            this._dialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dialogButton.Image = global::Compucare.Enquire.Common.Calculation.Properties.Resources.folder_saved_search;
            this._dialogButton.Location = new System.Drawing.Point(233, 3);
            this._dialogButton.Name = "_dialogButton";
            this._dialogButton.Size = new System.Drawing.Size(43, 41);
            this._dialogButton.TabIndex = 0;
            this._dialogButton.UseVisualStyleBackColor = true;
            // 
            // _textLocation
            // 
            this._textLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textLocation.Location = new System.Drawing.Point(3, 14);
            this._textLocation.Name = "_textLocation";
            this._textLocation.ReadOnly = true;
            this._textLocation.Size = new System.Drawing.Size(224, 20);
            this._textLocation.TabIndex = 1;
            // 
            // _openTemplateDialog
            // 
            this._openTemplateDialog.Filter = "Template files|*.template";
            // 
            // _saveTemplateDialog
            // 
            this._saveTemplateDialog.Filter = "Template files|*.template";
            // 
            // TemplateFileSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._textLocation);
            this.Controls.Add(this._dialogButton);
            this.Name = "TemplateFileSelectorControl";
            this.Size = new System.Drawing.Size(279, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.SaveFileDialog _saveTemplateDialog;
        internal System.Windows.Forms.OpenFileDialog _openTemplateDialog;
        internal System.Windows.Forms.Button _dialogButton;
        internal System.Windows.Forms.TextBox _textLocation;
    }
}
