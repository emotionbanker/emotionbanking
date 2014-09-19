namespace umfrage2._2007.Controls
{
    partial class SingleControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleControl));
            this.SettingsToolstrip = new System.Windows.Forms.ToolStrip();
            this.PmButton = new System.Windows.Forms.ToolStripButton();
            this.MButton = new System.Windows.Forms.ToolStripButton();
            this.PieButton = new System.Windows.Forms.ToolStripButton();
            this.BarButton = new System.Windows.Forms.ToolStripButton();
            this.PolButton = new System.Windows.Forms.ToolStripButton();
            this.GapButton = new System.Windows.Forms.ToolStripButton();
            this.AvgButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.CrossButton = new System.Windows.Forms.ToolStripButton();
            this.BaromButton = new System.Windows.Forms.ToolStripButton();
            this.MainPane = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RadarButton = new System.Windows.Forms.ToolStripButton();
            this.GaugeButton = new System.Windows.Forms.ToolStripButton();
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
            this.PmButton,
            this.MButton,
            this.PieButton,
            this.BarButton,
            this.PolButton,
            this.GapButton,
            this.AvgButton,
            this.toolStripButton1,
            this.OpenButton,
            this.CrossButton,
            this.BaromButton,
            this.RadarButton,
            this.GaugeButton});
            this.SettingsToolstrip.Location = new System.Drawing.Point(0, 0);
            this.SettingsToolstrip.Name = "SettingsToolstrip";
            this.SettingsToolstrip.Size = new System.Drawing.Size(122, 473);
            this.SettingsToolstrip.TabIndex = 3;
            this.SettingsToolstrip.Text = "toolStrip1";
            // 
            // PmButton
            // 
            this.PmButton.Checked = true;
            this.PmButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PmButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PmButton.Image = ((System.Drawing.Image)(resources.GetObject("PmButton.Image")));
            this.PmButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PmButton.Margin = new System.Windows.Forms.Padding(0, 50, 0, 2);
            this.PmButton.Name = "PmButton";
            this.PmButton.Size = new System.Drawing.Size(119, 22);
            this.PmButton.Text = "Prozentmatrix";
            this.PmButton.Click += new System.EventHandler(this.PmButton_Click);
            // 
            // MButton
            // 
            this.MButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MButton.Image = ((System.Drawing.Image)(resources.GetObject("MButton.Image")));
            this.MButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MButton.Name = "MButton";
            this.MButton.Size = new System.Drawing.Size(119, 22);
            this.MButton.Text = "Matrix";
            this.MButton.Click += new System.EventHandler(this.MButton_Click);
            // 
            // PieButton
            // 
            this.PieButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PieButton.Image = ((System.Drawing.Image)(resources.GetObject("PieButton.Image")));
            this.PieButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PieButton.Name = "PieButton";
            this.PieButton.Size = new System.Drawing.Size(119, 22);
            this.PieButton.Text = "Tortendiagramm";
            // 
            // BarButton
            // 
            this.BarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BarButton.Image = ((System.Drawing.Image)(resources.GetObject("BarButton.Image")));
            this.BarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BarButton.Name = "BarButton";
            this.BarButton.Size = new System.Drawing.Size(119, 22);
            this.BarButton.Text = "Balkendiagramm";
            // 
            // PolButton
            // 
            this.PolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PolButton.Image = ((System.Drawing.Image)(resources.GetObject("PolButton.Image")));
            this.PolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PolButton.Name = "PolButton";
            this.PolButton.Size = new System.Drawing.Size(119, 22);
            this.PolButton.Text = "Polaritäten";
            // 
            // GapButton
            // 
            this.GapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GapButton.Image = ((System.Drawing.Image)(resources.GetObject("GapButton.Image")));
            this.GapButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GapButton.Name = "GapButton";
            this.GapButton.Size = new System.Drawing.Size(119, 22);
            this.GapButton.Text = "Gaps";
            // 
            // AvgButton
            // 
            this.AvgButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AvgButton.Image = ((System.Drawing.Image)(resources.GetObject("AvgButton.Image")));
            this.AvgButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AvgButton.Name = "AvgButton";
            this.AvgButton.Size = new System.Drawing.Size(119, 22);
            this.AvgButton.Text = "Mittelwerte";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(119, 22);
            this.toolStripButton1.Text = "Ranking";
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(119, 22);
            this.OpenButton.Text = "Offene Fragen";
            // 
            // CrossButton
            // 
            this.CrossButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CrossButton.Image = ((System.Drawing.Image)(resources.GetObject("CrossButton.Image")));
            this.CrossButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CrossButton.Name = "CrossButton";
            this.CrossButton.Size = new System.Drawing.Size(119, 22);
            this.CrossButton.Text = "MW- Kreuzung";
            // 
            // BaromButton
            // 
            this.BaromButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BaromButton.Image = ((System.Drawing.Image)(resources.GetObject("BaromButton.Image")));
            this.BaromButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BaromButton.Name = "BaromButton";
            this.BaromButton.Size = new System.Drawing.Size(119, 22);
            this.BaromButton.Text = "Barometer";
            // 
            // MainPane
            // 
            this.MainPane.AutoScroll = true;
            this.MainPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPane.Location = new System.Drawing.Point(122, 0);
            this.MainPane.Name = "MainPane";
            this.MainPane.Size = new System.Drawing.Size(708, 473);
            this.MainPane.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::umfrage2.Properties.Resources.shell32_dll_I0113_0409;
            this.pictureBox1.Location = new System.Drawing.Point(44, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // RadarButton
            // 
            this.RadarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RadarButton.Enabled = false;
            this.RadarButton.Image = ((System.Drawing.Image)(resources.GetObject("RadarButton.Image")));
            this.RadarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RadarButton.Name = "RadarButton";
            this.RadarButton.Size = new System.Drawing.Size(119, 22);
            this.RadarButton.Text = "Radar";
            // 
            // GaugeButton
            // 
            this.GaugeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GaugeButton.Enabled = false;
            this.GaugeButton.Image = ((System.Drawing.Image)(resources.GetObject("GaugeButton.Image")));
            this.GaugeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GaugeButton.Name = "GaugeButton";
            this.GaugeButton.Size = new System.Drawing.Size(119, 22);
            this.GaugeButton.Text = "Tachometer";
            // 
            // SingleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.MainPane);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SettingsToolstrip);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SingleControl";
            this.Size = new System.Drawing.Size(830, 473);
            this.SettingsToolstrip.ResumeLayout(false);
            this.SettingsToolstrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip SettingsToolstrip;
        private System.Windows.Forms.ToolStripButton PmButton;
        private System.Windows.Forms.Panel MainPane;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton MButton;
        private System.Windows.Forms.ToolStripButton PieButton;
        private System.Windows.Forms.ToolStripButton BarButton;
        private System.Windows.Forms.ToolStripButton PolButton;
        private System.Windows.Forms.ToolStripButton GapButton;
        private System.Windows.Forms.ToolStripButton AvgButton;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton CrossButton;
        private System.Windows.Forms.ToolStripButton BaromButton;
        private System.Windows.Forms.ToolStripButton RadarButton;
        private System.Windows.Forms.ToolStripButton GaugeButton;
    }
}
