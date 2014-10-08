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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(970, 600);
            this.textBox1.TabIndex = 0;
            // 
            // CButton
            // 
            this.CButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CButton.Location = new System.Drawing.Point(682, 646);
            this.CButton.Name = "CButton";
            this.CButton.Size = new System.Drawing.Size(147, 33);
            this.CButton.TabIndex = 1;
            this.CButton.Text = "Abbrechen";
            this.CButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(835, 646);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(147, 33);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "Save";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(12, 621);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(56, 17);
            this.lblFind.TabIndex = 3;
            this.lblFind.Text = "Suchen";
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(230, 621);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(64, 17);
            this.lblReplace.TabIndex = 4;
            this.lblReplace.Text = "Ersetzen";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(74, 618);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(150, 22);
            this.txtFind.TabIndex = 5;
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(300, 618);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(150, 22);
            this.txtReplace.TabIndex = 6;
            // 
            // btnSelectNext
            // 
            this.btnSelectNext.Location = new System.Drawing.Point(156, 646);
            this.btnSelectNext.Name = "btnSelectNext";
            this.btnSelectNext.Size = new System.Drawing.Size(147, 33);
            this.btnSelectNext.TabIndex = 7;
            this.btnSelectNext.Text = "Nächster Eintrag";
            this.btnSelectNext.UseVisualStyleBackColor = true;
            // 
            // btnSelectPrevious
            // 
            this.btnSelectPrevious.Location = new System.Drawing.Point(3, 646);
            this.btnSelectPrevious.Name = "btnSelectPrevious";
            this.btnSelectPrevious.Size = new System.Drawing.Size(147, 33);
            this.btnSelectPrevious.TabIndex = 8;
            this.btnSelectPrevious.Text = "Voriger Eintrag";
            this.btnSelectPrevious.UseVisualStyleBackColor = true;
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(309, 646);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(147, 33);
            this.btnReplace.TabIndex = 9;
            this.btnReplace.Text = " Auswahl Ersetzen";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(462, 646);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(147, 33);
            this.btnReplaceAll.TabIndex = 10;
            this.btnReplaceAll.Text = "Alle Ersetzen";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // UpdateFormulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CButton;
            this.ClientSize = new System.Drawing.Size(994, 691);
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
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateFormulaForm";
            this.Text = "Berechnung Aktualisieren";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
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
    }
}