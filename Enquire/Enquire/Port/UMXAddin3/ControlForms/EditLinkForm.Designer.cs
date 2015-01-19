namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    partial class EditLinkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLinkForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LinkList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ReplaceString = new System.Windows.Forms.TextBox();
            this.ReplaceeButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.WordSetButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(481, 348);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(116, 31);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Schliessen";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.LinkList);
            this.groupBox1.Location = new System.Drawing.Point(13, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 316);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ausgewählte Verknüpfungen";
            // 
            // LinkList
            // 
            this.LinkList.FormattingEnabled = true;
            this.LinkList.Location = new System.Drawing.Point(12, 20);
            this.LinkList.Name = "LinkList";
            this.LinkList.Size = new System.Drawing.Size(171, 238);
            this.LinkList.TabIndex = 0;
            this.LinkList.DoubleClick += new System.EventHandler(this.LinkList_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.ReplaceeButton);
            this.groupBox2.Controls.Add(this.ReplaceString);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.SearchString);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(218, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 316);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Suchen und ersetzen...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suchen nach:";
            // 
            // SearchString
            // 
            this.SearchString.Location = new System.Drawing.Point(104, 28);
            this.SearchString.Name = "SearchString";
            this.SearchString.Size = new System.Drawing.Size(261, 20);
            this.SearchString.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ersetzen durch:";
            // 
            // ReplaceString
            // 
            this.ReplaceString.Location = new System.Drawing.Point(104, 54);
            this.ReplaceString.Name = "ReplaceString";
            this.ReplaceString.Size = new System.Drawing.Size(261, 20);
            this.ReplaceString.TabIndex = 3;
            // 
            // ReplaceeButton
            // 
            this.ReplaceeButton.Location = new System.Drawing.Point(206, 87);
            this.ReplaceeButton.Name = "ReplaceeButton";
            this.ReplaceeButton.Size = new System.Drawing.Size(158, 27);
            this.ReplaceeButton.TabIndex = 4;
            this.ReplaceeButton.Text = "Ersetzen";
            this.ReplaceeButton.UseVisualStyleBackColor = true;
            this.ReplaceeButton.Click += new System.EventHandler(this.ReplaceeButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(12, 118);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(352, 182);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WordSetButton
            // 
            this.WordSetButton.Location = new System.Drawing.Point(25, 350);
            this.WordSetButton.Name = "WordSetButton";
            this.WordSetButton.Size = new System.Drawing.Size(171, 27);
            this.WordSetButton.TabIndex = 6;
            this.WordSetButton.Text = "Interne IDs Anpassen (Word)";
            this.WordSetButton.UseVisualStyleBackColor = true;
            this.WordSetButton.Click += new System.EventHandler(this.WordSetButton_Click);
            // 
            // EditLinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 395);
            this.Controls.Add(this.WordSetButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditLinkForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verknüpfungen bearbeiten";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox LinkList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ReplaceString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ReplaceeButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button WordSetButton;
    }
}