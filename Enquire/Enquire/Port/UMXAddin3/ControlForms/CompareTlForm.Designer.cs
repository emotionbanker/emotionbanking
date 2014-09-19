namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    partial class CompareTlForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.qBox = new System.Windows.Forms.TextBox();
            this.SelectQButton = new System.Windows.Forms.Button();
            this.mw = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.qBox);
            this.groupBox1.Controls.Add(this.SelectQButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vergleichen mit";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(17, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 27);
            this.button1.TabIndex = 66;
            this.button1.Text = "Ampeleinstellungen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // qBox
            // 
            this.qBox.Location = new System.Drawing.Point(17, 29);
            this.qBox.Name = "qBox";
            this.qBox.Size = new System.Drawing.Size(107, 20);
            this.qBox.TabIndex = 64;
            this.qBox.TextChanged += new System.EventHandler(this.qBox_TextChanged);
            // 
            // SelectQButton
            // 
            this.SelectQButton.BackColor = System.Drawing.SystemColors.Control;
            this.SelectQButton.Location = new System.Drawing.Point(130, 25);
            this.SelectQButton.Name = "SelectQButton";
            this.SelectQButton.Size = new System.Drawing.Size(107, 27);
            this.SelectQButton.TabIndex = 63;
            this.SelectQButton.Text = "Frage...";
            this.SelectQButton.UseVisualStyleBackColor = false;
            this.SelectQButton.Click += new System.EventHandler(this.SelectQButton_Click);
            // 
            // mw
            // 
            this.mw.Location = new System.Drawing.Point(164, 117);
            this.mw.Name = "mw";
            this.mw.Size = new System.Drawing.Size(106, 29);
            this.mw.TabIndex = 3;
            this.mw.Text = "Einfügen";
            this.mw.UseVisualStyleBackColor = true;
            this.mw.Click += new System.EventHandler(this.mw_Click);
            // 
            // CompareTlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 164);
            this.Controls.Add(this.mw);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CompareTlForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vergleichende Ampelgraphik";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox qBox;
        private System.Windows.Forms.Button SelectQButton;
        private System.Windows.Forms.Button mw;
        private System.Windows.Forms.Button button1;

    }
}