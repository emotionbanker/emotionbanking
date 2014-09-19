namespace umfrage2._2007.Controls
{
    partial class SettingsControl_Vis
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
            this.label2 = new System.Windows.Forms.Label();
            this.PersonSettingsPanel = new System.Windows.Forms.Panel();
            this.PersonBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Personengruppe:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonSettingsPanel
            // 
            this.PersonSettingsPanel.Location = new System.Drawing.Point(19, 63);
            this.PersonSettingsPanel.Name = "PersonSettingsPanel";
            this.PersonSettingsPanel.Size = new System.Drawing.Size(513, 251);
            this.PersonSettingsPanel.TabIndex = 5;
            // 
            // PersonBox
            // 
            this.PersonBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PersonBox.Location = new System.Drawing.Point(147, 23);
            this.PersonBox.Name = "PersonBox";
            this.PersonBox.Size = new System.Drawing.Size(385, 24);
            this.PersonBox.TabIndex = 4;
            this.PersonBox.SelectedIndexChanged += new System.EventHandler(this.PersonBox_SelectedIndexChanged);
            // 
            // SettingsControl_Vis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PersonSettingsPanel);
            this.Controls.Add(this.PersonBox);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SettingsControl_Vis";
            this.Size = new System.Drawing.Size(778, 501);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PersonSettingsPanel;
        private System.Windows.Forms.ComboBox PersonBox;
    }
}
