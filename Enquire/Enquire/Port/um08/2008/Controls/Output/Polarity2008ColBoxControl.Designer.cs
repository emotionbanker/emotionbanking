namespace umfrage2
{
    partial class Polarity2008ColBoxControl
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
            this.SetButton = new System.Windows.Forms.Button();
            this.XButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(0, 0);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(75, 23);
            this.SetButton.TabIndex = 0;
            this.SetButton.Text = "---";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // XButton
            // 
            this.XButton.Location = new System.Drawing.Point(81, 0);
            this.XButton.Name = "XButton";
            this.XButton.Size = new System.Drawing.Size(25, 23);
            this.XButton.TabIndex = 1;
            this.XButton.Text = "x";
            this.XButton.UseVisualStyleBackColor = true;
            this.XButton.Click += new System.EventHandler(this.XButton_Click);
            // 
            // Polarity2008ColBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.XButton);
            this.Controls.Add(this.SetButton);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "Polarity2008ColBoxControl";
            this.Size = new System.Drawing.Size(107, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.Button XButton;
    }
}
