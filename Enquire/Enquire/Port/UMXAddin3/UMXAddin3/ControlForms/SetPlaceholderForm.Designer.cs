namespace UMXAddin3.ControlForms
{
    partial class SetPlaceholderForm
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
            this.PlaceholderControlPanel = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlaceholderControlPanel
            // 
            this.PlaceholderControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlaceholderControlPanel.Location = new System.Drawing.Point(0, 0);
            this.PlaceholderControlPanel.Name = "PlaceholderControlPanel";
            this.PlaceholderControlPanel.Size = new System.Drawing.Size(687, 447);
            this.PlaceholderControlPanel.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(547, 457);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(117, 26);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ACHTUNG: Alle hier vorgenommenen Änderungen bleiben nur für die Dauer der";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(12, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bearbeitung dieses Dokuments bestehen und sind nicht permanent!";
            // 
            // SetPlaceholderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 493);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.PlaceholderControlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetPlaceholderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Platzhalter setzen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlaceholderControlPanel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}