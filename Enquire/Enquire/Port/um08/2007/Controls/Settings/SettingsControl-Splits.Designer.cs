namespace umfrage2._2007.Controls
{
    partial class SettingsControl_Splits
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
            this.ChooseTargetPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ChooseQuestion = new System.Windows.Forms.Button();
            this.Split = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._btn_rename = new System.Windows.Forms.Button();
            this._txt_rename = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ChooseTargetPanel
            // 
            this.ChooseTargetPanel.Location = new System.Drawing.Point(25, 22);
            this.ChooseTargetPanel.Name = "ChooseTargetPanel";
            this.ChooseTargetPanel.Size = new System.Drawing.Size(307, 389);
            this.ChooseTargetPanel.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Ausgewähltes Ziel Teilen nach:";
            // 
            // ChooseQuestion
            // 
            this.ChooseQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseQuestion.Location = new System.Drawing.Point(348, 48);
            this.ChooseQuestion.Name = "ChooseQuestion";
            this.ChooseQuestion.Size = new System.Drawing.Size(186, 33);
            this.ChooseQuestion.TabIndex = 33;
            this.ChooseQuestion.Text = "Frage auswählen";
            this.ChooseQuestion.UseVisualStyleBackColor = true;
            this.ChooseQuestion.Click += new System.EventHandler(this.ChooseQuestion_Click);
            // 
            // Split
            // 
            this.Split.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Split.Location = new System.Drawing.Point(348, 87);
            this.Split.Name = "Split";
            this.Split.Size = new System.Drawing.Size(186, 33);
            this.Split.TabIndex = 34;
            this.Split.Text = "Ziel teilen!";
            this.Split.UseVisualStyleBackColor = true;
            this.Split.Click += new System.EventHandler(this.Split_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(348, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 33);
            this.button1.TabIndex = 35;
            this.button1.Text = "Zielteilungen löschen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _btn_rename
            // 
            this._btn_rename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btn_rename.Location = new System.Drawing.Point(348, 311);
            this._btn_rename.Name = "_btn_rename";
            this._btn_rename.Size = new System.Drawing.Size(186, 33);
            this._btn_rename.TabIndex = 36;
            this._btn_rename.Text = "Zielteilung unbenennen";
            this._btn_rename.UseVisualStyleBackColor = true;
            this._btn_rename.Click += new System.EventHandler(this._btn_rename_Click);
            // 
            // _txt_rename
            // 
            this._txt_rename.Location = new System.Drawing.Point(348, 285);
            this._txt_rename.Name = "_txt_rename";
            this._txt_rename.Size = new System.Drawing.Size(186, 20);
            this._txt_rename.TabIndex = 37;
            // 
            // SettingsControl_Splits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._txt_rename);
            this.Controls.Add(this._btn_rename);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Split);
            this.Controls.Add(this.ChooseQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChooseTargetPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SettingsControl_Splits";
            this.Size = new System.Drawing.Size(835, 527);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ChooseTargetPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChooseQuestion;
        private System.Windows.Forms.Button Split;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button _btn_rename;
        private System.Windows.Forms.TextBox _txt_rename;
    }
}
