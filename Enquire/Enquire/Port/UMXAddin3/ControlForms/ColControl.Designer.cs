namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    partial class ColControl
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
            this.ColType = new System.Windows.Forms.ComboBox();
            this.XButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ColType
            // 
            this.ColType.FormattingEnabled = true;
            this.ColType.Location = new System.Drawing.Point(0, 0);
            this.ColType.Name = "ColType";
            this.ColType.Size = new System.Drawing.Size(127, 21);
            this.ColType.TabIndex = 0;
            this.ColType.SelectedIndexChanged += new System.EventHandler(this.ColType_SelectedIndexChanged);
            // 
            // XButton
            // 
            this.XButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.XButton.Font = new System.Drawing.Font("Arial", 7F);
            this.XButton.Location = new System.Drawing.Point(209, 2);
            this.XButton.Name = "XButton";
            this.XButton.Size = new System.Drawing.Size(24, 18);
            this.XButton.TabIndex = 1;
            this.XButton.Text = "X";
            this.XButton.UseVisualStyleBackColor = true;
            this.XButton.Click += new System.EventHandler(this.XButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SettingsButton.Font = new System.Drawing.Font("Arial", 7F);
            this.SettingsButton.Location = new System.Drawing.Point(128, 2);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(80, 18);
            this.SettingsButton.TabIndex = 2;
            this.SettingsButton.Text = "einstellungen";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ColControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.XButton);
            this.Controls.Add(this.ColType);
            this.Name = "ColControl";
            this.Size = new System.Drawing.Size(236, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ColType;
        private System.Windows.Forms.Button XButton;
        private System.Windows.Forms.Button SettingsButton;
    }
}
