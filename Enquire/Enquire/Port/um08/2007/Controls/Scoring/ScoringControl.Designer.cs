namespace umfrage2._2007.Controls
{
    partial class ScoringControl
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.targetBox = new System.Windows.Forms.Panel();
            this.ScoringG = new System.Windows.Forms.GroupBox();
            this.Cockpits06 = new System.Windows.Forms.CheckBox();
            this.Cockpits = new System.Windows.Forms.CheckBox();
            this.ScoreButton = new System.Windows.Forms.Button();
            this.EditColumnButton = new System.Windows.Forms.Button();
            this.DeleteColumnButton = new System.Windows.Forms.Button();
            this.NewColumnButton = new System.Windows.Forms.Button();
            this.ColumnBox = new System.Windows.Forms.ListBox();
            this.Cockpits07 = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.ScoringG.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.targetBox);
            this.groupBox3.Location = new System.Drawing.Point(16, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 272);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zielauswahl";
            // 
            // targetBox
            // 
            this.targetBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetBox.Location = new System.Drawing.Point(3, 20);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(162, 249);
            this.targetBox.TabIndex = 36;
            // 
            // ScoringG
            // 
            this.ScoringG.Controls.Add(this.Cockpits07);
            this.ScoringG.Controls.Add(this.Cockpits06);
            this.ScoringG.Controls.Add(this.Cockpits);
            this.ScoringG.Controls.Add(this.ScoreButton);
            this.ScoringG.Controls.Add(this.EditColumnButton);
            this.ScoringG.Controls.Add(this.DeleteColumnButton);
            this.ScoringG.Controls.Add(this.NewColumnButton);
            this.ScoringG.Controls.Add(this.ColumnBox);
            this.ScoringG.Location = new System.Drawing.Point(200, 12);
            this.ScoringG.Name = "ScoringG";
            this.ScoringG.Size = new System.Drawing.Size(572, 272);
            this.ScoringG.TabIndex = 44;
            this.ScoringG.TabStop = false;
            this.ScoringG.Text = "Scoring";
            // 
            // Cockpits06
            // 
            this.Cockpits06.Location = new System.Drawing.Point(216, 163);
            this.Cockpits06.Name = "Cockpits06";
            this.Cockpits06.Size = new System.Drawing.Size(168, 24);
            this.Cockpits06.TabIndex = 39;
            this.Cockpits06.Text = "victor 06 Cockpits";
            this.Cockpits06.CheckedChanged += new System.EventHandler(this.Cockpits06_CheckedChanged);
            // 
            // Cockpits
            // 
            this.Cockpits.Location = new System.Drawing.Point(216, 142);
            this.Cockpits.Name = "Cockpits";
            this.Cockpits.Size = new System.Drawing.Size(168, 24);
            this.Cockpits.TabIndex = 38;
            this.Cockpits.Text = "victor 05 Cockpits";
            this.Cockpits.CheckedChanged += new System.EventHandler(this.Cockpits_CheckedChanged);
            // 
            // ScoreButton
            // 
            this.ScoreButton.BackColor = System.Drawing.Color.LightGray;
            this.ScoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ScoreButton.Location = new System.Drawing.Point(216, 224);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Size = new System.Drawing.Size(168, 32);
            this.ScoreButton.TabIndex = 37;
            this.ScoreButton.Text = "Berechnen";
            this.ScoreButton.UseVisualStyleBackColor = false;
            this.ScoreButton.Click += new System.EventHandler(this.ScoreButton_Click);
            // 
            // EditColumnButton
            // 
            this.EditColumnButton.BackColor = System.Drawing.Color.LightGray;
            this.EditColumnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditColumnButton.Location = new System.Drawing.Point(216, 104);
            this.EditColumnButton.Name = "EditColumnButton";
            this.EditColumnButton.Size = new System.Drawing.Size(168, 32);
            this.EditColumnButton.TabIndex = 36;
            this.EditColumnButton.Text = "Säule bearbeiten";
            this.EditColumnButton.UseVisualStyleBackColor = false;
            this.EditColumnButton.Click += new System.EventHandler(this.EditColumnButton_Click);
            // 
            // DeleteColumnButton
            // 
            this.DeleteColumnButton.BackColor = System.Drawing.Color.LightGray;
            this.DeleteColumnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteColumnButton.Location = new System.Drawing.Point(216, 64);
            this.DeleteColumnButton.Name = "DeleteColumnButton";
            this.DeleteColumnButton.Size = new System.Drawing.Size(168, 32);
            this.DeleteColumnButton.TabIndex = 35;
            this.DeleteColumnButton.Text = "Säule löschen";
            this.DeleteColumnButton.UseVisualStyleBackColor = false;
            this.DeleteColumnButton.Click += new System.EventHandler(this.DeleteColumnButton_Click);
            // 
            // NewColumnButton
            // 
            this.NewColumnButton.BackColor = System.Drawing.Color.LightGray;
            this.NewColumnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NewColumnButton.Location = new System.Drawing.Point(216, 24);
            this.NewColumnButton.Name = "NewColumnButton";
            this.NewColumnButton.Size = new System.Drawing.Size(168, 32);
            this.NewColumnButton.TabIndex = 34;
            this.NewColumnButton.Text = "Neue Säule";
            this.NewColumnButton.UseVisualStyleBackColor = false;
            this.NewColumnButton.Click += new System.EventHandler(this.NewColumnButton_Click);
            // 
            // ColumnBox
            // 
            this.ColumnBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColumnBox.HorizontalScrollbar = true;
            this.ColumnBox.ItemHeight = 16;
            this.ColumnBox.Location = new System.Drawing.Point(8, 19);
            this.ColumnBox.Name = "ColumnBox";
            this.ColumnBox.Size = new System.Drawing.Size(192, 242);
            this.ColumnBox.TabIndex = 33;
            this.ColumnBox.DoubleClick += new System.EventHandler(this.ColumnBox_DoubleClick);
            // 
            // Cockpits07
            // 
            this.Cockpits07.Location = new System.Drawing.Point(216, 184);
            this.Cockpits07.Name = "Cockpits07";
            this.Cockpits07.Size = new System.Drawing.Size(168, 24);
            this.Cockpits07.TabIndex = 40;
            this.Cockpits07.Text = "victor 07 Cockpits";
            // 
            // ScoringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ScoringG);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "ScoringControl";
            this.Size = new System.Drawing.Size(722, 496);
            this.groupBox3.ResumeLayout(false);
            this.ScoringG.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel targetBox;
        private System.Windows.Forms.GroupBox ScoringG;
        private System.Windows.Forms.CheckBox Cockpits06;
        private System.Windows.Forms.CheckBox Cockpits;
        private System.Windows.Forms.Button ScoreButton;
        private System.Windows.Forms.Button EditColumnButton;
        private System.Windows.Forms.Button DeleteColumnButton;
        private System.Windows.Forms.Button NewColumnButton;
        private System.Windows.Forms.ListBox ColumnBox;
        private System.Windows.Forms.CheckBox Cockpits07;
    }
}
