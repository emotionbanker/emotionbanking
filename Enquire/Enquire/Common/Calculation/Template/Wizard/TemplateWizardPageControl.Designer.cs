namespace Compucare.Enquire.Common.Calculation.Template.Wizard
{
    partial class TemplateWizardPageControl
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
            this.label1 = new System.Windows.Forms.Label();
            this._radioNone = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this._radioFile = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this._saveToFile = new System.Windows.Forms.CheckBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._loadTemplateSelector = new Compucare.Enquire.Common.Calculation.Template.Controls.TemplateFileSelectorControl();
            this._saveTemplateSelector = new Compucare.Enquire.Common.Calculation.Template.Controls.TemplateFileSelectorControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(38, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Start from scratch.";
            // 
            // _radioNone
            // 
            this._radioNone.AutoSize = true;
            this._radioNone.Checked = true;
            this._radioNone.Location = new System.Drawing.Point(41, 3);
            this._radioNone.Name = "_radioNone";
            this._radioNone.Size = new System.Drawing.Size(86, 17);
            this._radioNone.TabIndex = 27;
            this._radioNone.TabStop = true;
            this._radioNone.Text = "No Template";
            this._radioNone.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(38, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Load a template from a file.";
            // 
            // _radioFile
            // 
            this._radioFile.AutoSize = true;
            this._radioFile.Location = new System.Drawing.Point(41, 50);
            this._radioFile.Name = "_radioFile";
            this._radioFile.Size = new System.Drawing.Size(88, 17);
            this._radioFile.TabIndex = 30;
            this._radioFile.TabStop = true;
            this._radioFile.Text = "File Template";
            this._radioFile.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(38, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Save template to file after finishing the wizard.";
            // 
            // _saveToFile
            // 
            this._saveToFile.AutoSize = true;
            this._saveToFile.Location = new System.Drawing.Point(41, 171);
            this._saveToFile.Name = "_saveToFile";
            this._saveToFile.Size = new System.Drawing.Size(124, 17);
            this._saveToFile.TabIndex = 36;
            this._saveToFile.Text = "Save as file template";
            this._saveToFile.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Compucare.Enquire.Common.Calculation.Properties.Resources.folder_downloads;
            this.pictureBox3.Location = new System.Drawing.Point(3, 171);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Compucare.Enquire.Common.Calculation.Properties.Resources.folder_document;
            this.pictureBox2.Location = new System.Drawing.Point(3, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Compucare.Enquire.Common.Calculation.Properties.Resources.edit_add_2;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // _loadTemplateSelector
            // 
            this._loadTemplateSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._loadTemplateSelector.Location = new System.Drawing.Point(273, 43);
            this._loadTemplateSelector.Name = "_loadTemplateSelector";
            this._loadTemplateSelector.Size = new System.Drawing.Size(246, 47);
            this._loadTemplateSelector.TabIndex = 38;
            // 
            // _saveTemplateSelector
            // 
            this._saveTemplateSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._saveTemplateSelector.Location = new System.Drawing.Point(268, 166);
            this._saveTemplateSelector.Name = "_saveTemplateSelector";
            this._saveTemplateSelector.Size = new System.Drawing.Size(246, 47);
            this._saveTemplateSelector.TabIndex = 39;
            // 
            // TemplateWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._saveTemplateSelector);
            this.Controls.Add(this._loadTemplateSelector);
            this.Controls.Add(this._saveToFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this._radioFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._radioNone);
            this.Name = "TemplateWizardPageControl";
            this.Size = new System.Drawing.Size(522, 252);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.RadioButton _radioNone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.RadioButton _radioFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        internal System.Windows.Forms.CheckBox _saveToFile;
        internal Controls.TemplateFileSelectorControl _loadTemplateSelector;
        internal Controls.TemplateFileSelectorControl _saveTemplateSelector;
    }
}
