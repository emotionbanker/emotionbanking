namespace umfrage2._2007.Controls
{
    partial class SettingsControl_Alternates
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.QuestionList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AlternatesBox = new System.Windows.Forms.TextBox();
            this.AlertLabel = new System.Windows.Forms.Label();
            this.StatsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Location = new System.Drawing.Point(106, 16);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(748, 20);
            this.searchBox.TabIndex = 15;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Suche nach:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // QuestionList
            // 
            this.QuestionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionList.FormattingEnabled = true;
            this.QuestionList.Location = new System.Drawing.Point(14, 46);
            this.QuestionList.Name = "QuestionList";
            this.QuestionList.Size = new System.Drawing.Size(840, 184);
            this.QuestionList.TabIndex = 16;
            this.QuestionList.SelectedIndexChanged += new System.EventHandler(this.QuestionList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(11, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Alternativen für diese Frage:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(11, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "(durch Beistriche getrennt)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AlternatesBox
            // 
            this.AlternatesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlternatesBox.Location = new System.Drawing.Point(200, 257);
            this.AlternatesBox.Name = "AlternatesBox";
            this.AlternatesBox.Size = new System.Drawing.Size(472, 20);
            this.AlternatesBox.TabIndex = 19;
            this.AlternatesBox.TextChanged += new System.EventHandler(this.AlternatesBox_TextChanged);
            // 
            // AlertLabel
            // 
            this.AlertLabel.BackColor = System.Drawing.Color.Transparent;
            this.AlertLabel.ForeColor = System.Drawing.Color.Red;
            this.AlertLabel.Location = new System.Drawing.Point(200, 284);
            this.AlertLabel.Name = "AlertLabel";
            this.AlertLabel.Size = new System.Drawing.Size(472, 24);
            this.AlertLabel.TabIndex = 21;
            this.AlertLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatsButton
            // 
            this.StatsButton.Location = new System.Drawing.Point(14, 320);
            this.StatsButton.Name = "StatsButton";
            this.StatsButton.Size = new System.Drawing.Size(101, 24);
            this.StatsButton.TabIndex = 22;
            this.StatsButton.Text = "Fragenstatistik";
            this.StatsButton.UseVisualStyleBackColor = true;
            this.StatsButton.Click += new System.EventHandler(this.StatsButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 24);
            this.button1.TabIndex = 23;
            this.button1.Text = "Alternativen löschen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingsControl_Alternates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StatsButton);
            this.Controls.Add(this.AlertLabel);
            this.Controls.Add(this.AlternatesBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuestionList);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SettingsControl_Alternates";
            this.Size = new System.Drawing.Size(935, 442);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox QuestionList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AlternatesBox;
        private System.Windows.Forms.Label AlertLabel;
        private System.Windows.Forms.Button StatsButton;
        private System.Windows.Forms.Button button1;
    }
}
