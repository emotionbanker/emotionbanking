using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class SettingsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsControl));
            this.SettingsToolstrip = new System.Windows.Forms.ToolStrip();
            this.DbButton = new System.Windows.Forms.ToolStripButton();
            this.PersonsButton = new System.Windows.Forms.ToolStripButton();
            this.TargetButton = new System.Windows.Forms.ToolStripButton();
            this.SplitButton = new System.Windows.Forms.ToolStripButton();
            this.QuestionButton = new System.Windows.Forms.ToolStripButton();
            this.Alternates = new System.Windows.Forms.ToolStripButton();
            this.VisButton = new System.Windows.Forms.ToolStripButton();
            this.HistoryButton = new System.Windows.Forms.ToolStripButton();
            this.QuestionPlaceholderButton = new System.Windows.Forms.ToolStripButton();
            this.MainPane = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.QuestionManagementButton = new System.Windows.Forms.ToolStripButton();
            this.SettingsToolstrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsToolstrip
            // 
            this.SettingsToolstrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(155)))), ((int)(((byte)(183)))), ((int)(((byte)(214)))));
            this.SettingsToolstrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.SettingsToolstrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SettingsToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DbButton,
            this.PersonsButton,
            this.TargetButton,
            this.SplitButton,
            this.QuestionButton,
            this.Alternates,
            this.VisButton,
            this.HistoryButton,
            this.QuestionPlaceholderButton,
            this.QuestionManagementButton});
            this.SettingsToolstrip.Location = new System.Drawing.Point(0, 0);
            this.SettingsToolstrip.Name = "SettingsToolstrip";
            this.SettingsToolstrip.Size = new System.Drawing.Size(129, 473);
            this.SettingsToolstrip.TabIndex = 3;
            this.SettingsToolstrip.Text = "toolStrip1";
            // 
            // DbButton
            // 
            this.DbButton.Checked = true;
            this.DbButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DbButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DbButton.Image = ((System.Drawing.Image)(resources.GetObject("DbButton.Image")));
            this.DbButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DbButton.Margin = new System.Windows.Forms.Padding(0, 50, 0, 2);
            this.DbButton.Name = "DbButton";
            this.DbButton.Size = new System.Drawing.Size(126, 19);
            this.DbButton.Text = "Datenbank";
            this.DbButton.Click += new System.EventHandler(this.DbButton_Click);
            // 
            // PersonsButton
            // 
            this.PersonsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PersonsButton.Image = ((System.Drawing.Image)(resources.GetObject("PersonsButton.Image")));
            this.PersonsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PersonsButton.Name = "PersonsButton";
            this.PersonsButton.Size = new System.Drawing.Size(126, 19);
            this.PersonsButton.Text = "Personen";
            this.PersonsButton.Click += new System.EventHandler(this.PersonsButton_Click);
            // 
            // TargetButton
            // 
            this.TargetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TargetButton.Image = ((System.Drawing.Image)(resources.GetObject("TargetButton.Image")));
            this.TargetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TargetButton.Name = "TargetButton";
            this.TargetButton.Size = new System.Drawing.Size(126, 19);
            this.TargetButton.Text = "Ziele";
            this.TargetButton.Click += new System.EventHandler(this.TargetButton_Click);
            // 
            // SplitButton
            // 
            this.SplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SplitButton.Image = ((System.Drawing.Image)(resources.GetObject("SplitButton.Image")));
            this.SplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SplitButton.Name = "SplitButton";
            this.SplitButton.Size = new System.Drawing.Size(126, 19);
            this.SplitButton.Text = "Zielteilungen";
            this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
            // 
            // QuestionButton
            // 
            this.QuestionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.QuestionButton.Image = ((System.Drawing.Image)(resources.GetObject("QuestionButton.Image")));
            this.QuestionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuestionButton.Name = "QuestionButton";
            this.QuestionButton.Size = new System.Drawing.Size(126, 19);
            this.QuestionButton.Text = "Fragenkombinationen";
            this.QuestionButton.Click += new System.EventHandler(this.QuestionButton_Click);
            // 
            // Alternates
            // 
            this.Alternates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Alternates.Image = ((System.Drawing.Image)(resources.GetObject("Alternates.Image")));
            this.Alternates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Alternates.Name = "Alternates";
            this.Alternates.Size = new System.Drawing.Size(126, 19);
            this.Alternates.Text = "Fragenalternativen";
            this.Alternates.Click += new System.EventHandler(this.Alternates_Click);
            // 
            // VisButton
            // 
            this.VisButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.VisButton.Image = ((System.Drawing.Image)(resources.GetObject("VisButton.Image")));
            this.VisButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VisButton.Name = "VisButton";
            this.VisButton.Size = new System.Drawing.Size(126, 19);
            this.VisButton.Text = "Visualisierung";
            this.VisButton.Click += new System.EventHandler(this.VisButton_Click);
            // 
            // HistoryButton
            // 
            this.HistoryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HistoryButton.Image = ((System.Drawing.Image)(resources.GetObject("HistoryButton.Image")));
            this.HistoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Size = new System.Drawing.Size(126, 19);
            this.HistoryButton.Text = "Historische Daten";
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // QuestionPlaceholderButton
            // 
            this.QuestionPlaceholderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.QuestionPlaceholderButton.Image = ((System.Drawing.Image)(resources.GetObject("QuestionPlaceholderButton.Image")));
            this.QuestionPlaceholderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuestionPlaceholderButton.Name = "QuestionPlaceholderButton";
            this.QuestionPlaceholderButton.Size = new System.Drawing.Size(126, 19);
            this.QuestionPlaceholderButton.Text = "Fragenplatzhalter";
            this.QuestionPlaceholderButton.Click += new System.EventHandler(this.QuestionPlaceholderButton_Click);
            // 
            // MainPane
            // 
            this.MainPane.AutoScroll = true;
            this.MainPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPane.Location = new System.Drawing.Point(129, 0);
            this.MainPane.Name = "MainPane";
            this.MainPane.Size = new System.Drawing.Size(701, 473);
            this.MainPane.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell321;
            this.pictureBox1.Location = new System.Drawing.Point(44, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // QuestionManagementButton
            // 
            this.QuestionManagementButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.QuestionManagementButton.Image = ((System.Drawing.Image)(resources.GetObject("QuestionManagementButton.Image")));
            this.QuestionManagementButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuestionManagementButton.Name = "QuestionManagementButton";
            this.QuestionManagementButton.Size = new System.Drawing.Size(126, 19);
            this.QuestionManagementButton.Text = "Fragenverwaltung";
            this.QuestionManagementButton.Click += new System.EventHandler(this.QuestionManagementButton_Click);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.MainPane);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SettingsToolstrip);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(830, 473);
            this.SettingsToolstrip.ResumeLayout(false);
            this.SettingsToolstrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip SettingsToolstrip;
        private System.Windows.Forms.ToolStripButton DbButton;
        private System.Windows.Forms.ToolStripButton PersonsButton;
        private System.Windows.Forms.ToolStripButton TargetButton;
        private System.Windows.Forms.ToolStripButton QuestionButton;
        private System.Windows.Forms.ToolStripButton VisButton;
        private System.Windows.Forms.ToolStripButton HistoryButton;
        private System.Windows.Forms.Panel MainPane;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton SplitButton;
        private System.Windows.Forms.ToolStripButton Alternates;
        private System.Windows.Forms.ToolStripButton QuestionPlaceholderButton;
        private System.Windows.Forms.ToolStripButton QuestionManagementButton;
    }
}
