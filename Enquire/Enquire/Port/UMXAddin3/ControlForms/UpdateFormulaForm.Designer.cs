namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    partial class UpdateFormulaForm
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
            this.CButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.lblReplace = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.btnSelectNext = new System.Windows.Forms.Button();
            this.btnSelectPrevious = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.txtFormulas = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CButton
            // 
            this.CButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CButton.Location = new System.Drawing.Point(512, 525);
            this.CButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CButton.Name = "CButton";
            this.CButton.Size = new System.Drawing.Size(110, 27);
            this.CButton.TabIndex = 1;
            this.CButton.Text = "Abbrechen";
            this.CButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(626, 525);
            this.OKButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(110, 27);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "Save";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // lblFind
            // 
            this.lblFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(7, 505);
            this.lblFind.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(44, 13);
            this.lblFind.TabIndex = 3;
            this.lblFind.Text = "Suchen";
            // 
            // lblReplace
            // 
            this.lblReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(236, 506);
            this.lblReplace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(48, 13);
            this.lblReplace.TabIndex = 4;
            this.lblReplace.Text = "Ersetzen";
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFind.Location = new System.Drawing.Point(56, 502);
            this.txtFind.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(114, 20);
            this.txtFind.TabIndex = 5;
            // 
            // txtReplace
            // 
            this.txtReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReplace.Location = new System.Drawing.Point(289, 502);
            this.txtReplace.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(114, 20);
            this.txtReplace.TabIndex = 6;
            // 
            // btnSelectNext
            // 
            this.btnSelectNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectNext.Location = new System.Drawing.Point(124, 525);
            this.btnSelectNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelectNext.Name = "btnSelectNext";
            this.btnSelectNext.Size = new System.Drawing.Size(110, 27);
            this.btnSelectNext.TabIndex = 7;
            this.btnSelectNext.Text = "Nächster Eintrag";
            this.btnSelectNext.UseVisualStyleBackColor = true;
            this.btnSelectNext.Click += new System.EventHandler(this.btnSelectNext_Click);
            // 
            // btnSelectPrevious
            // 
            this.btnSelectPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectPrevious.Location = new System.Drawing.Point(9, 525);
            this.btnSelectPrevious.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelectPrevious.Name = "btnSelectPrevious";
            this.btnSelectPrevious.Size = new System.Drawing.Size(110, 27);
            this.btnSelectPrevious.TabIndex = 8;
            this.btnSelectPrevious.Text = "Voriger Eintrag";
            this.btnSelectPrevious.UseVisualStyleBackColor = true;
            this.btnSelectPrevious.Click += new System.EventHandler(this.btnSelectPrevious_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReplace.Location = new System.Drawing.Point(238, 525);
            this.btnReplace.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(110, 27);
            this.btnReplace.TabIndex = 9;
            this.btnReplace.Text = " Auswahl Ersetzen";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReplaceAll.Location = new System.Drawing.Point(353, 525);
            this.btnReplaceAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(110, 27);
            this.btnReplaceAll.TabIndex = 10;
            this.btnReplaceAll.Text = "Alle Ersetzen";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // txtFormulas
            // 
            this.txtFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormulas.HideSelection = false;
            this.txtFormulas.Location = new System.Drawing.Point(9, 10);
            this.txtFormulas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFormulas.Name = "txtFormulas";
            this.txtFormulas.Size = new System.Drawing.Size(728, 488);
            this.txtFormulas.TabIndex = 11;
            this.txtFormulas.Text = "";
            // 
            // UpdateFormulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CButton;
            this.ClientSize = new System.Drawing.Size(746, 561);
            this.Controls.Add(this.txtFormulas);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnSelectPrevious);
            this.Controls.Add(this.btnSelectNext);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UpdateFormulaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Berechnung Aktualisieren";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Button btnSelectNext;
        private System.Windows.Forms.Button btnSelectPrevious;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.RichTextBox txtFormulas;
    }
}