namespace umfrage2._2008.Dialogs
{
    partial class QuestionDetails
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
            this.EndButton = new System.Windows.Forms.Button();
            this.questionStats1 = new umfrage2._2008.Controls.QuestionStats();
            this.SuspendLayout();
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(386, 394);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(101, 24);
            this.EndButton.TabIndex = 2;
            this.EndButton.Text = "Schliessen";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // questionStats1
            // 
            this.questionStats1.BackColor = System.Drawing.Color.Transparent;
            this.questionStats1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.questionStats1.Location = new System.Drawing.Point(-2, 12);
            this.questionStats1.Name = "questionStats1";
            this.questionStats1.Size = new System.Drawing.Size(497, 389);
            this.questionStats1.TabIndex = 0;
            // 
            // QuestionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 427);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.questionStats1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QuestionDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Fragenstatistik";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.QuestionDetails_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EndButton;
        public umfrage2._2008.Controls.QuestionStats questionStats1;
    }
}