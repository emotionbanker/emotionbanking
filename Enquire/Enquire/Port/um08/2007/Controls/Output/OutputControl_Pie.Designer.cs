using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_Pie
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
            this.StartPosBar = new System.Windows.Forms.TrackBar();
            this.CheckRing = new System.Windows.Forms.CheckBox();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.HorizontalButton = new System.Windows.Forms.Button();
            this.QLabel = new System.Windows.Forms.Label();
            this.QueLabel = new System.Windows.Forms.Label();
            this.GoButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AvgPieBox = new System.Windows.Forms.CheckBox();
            this.ExplodeBox = new System.Windows.Forms.CheckBox();
            this.Box3d = new System.Windows.Forms.CheckBox();
            this.MasterDesignBox = new System.Windows.Forms.ComboBox();
            this.DesignButton = new System.Windows.Forms.Button();
            this.sizeControl = new SizeControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.previewBox = new PreviewControl();
            ((System.ComponentModel.ISupportInitialize)(this.StartPosBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Personengruppen.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartPosBar
            // 
            this.StartPosBar.BackColor = System.Drawing.Color.CadetBlue;
            this.StartPosBar.LargeChange = 45;
            this.StartPosBar.Location = new System.Drawing.Point(97, 15);
            this.StartPosBar.Maximum = 360;
            this.StartPosBar.Name = "StartPosBar";
            this.StartPosBar.Size = new System.Drawing.Size(88, 45);
            this.StartPosBar.SmallChange = 10;
            this.StartPosBar.TabIndex = 42;
            this.StartPosBar.TickFrequency = 45;
            this.StartPosBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.StartPosBar.Scroll += new System.EventHandler(this.StartPosBar_Scroll);
            // 
            // CheckRing
            // 
            this.CheckRing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckRing.Location = new System.Drawing.Point(6, 20);
            this.CheckRing.Name = "CheckRing";
            this.CheckRing.Size = new System.Drawing.Size(63, 20);
            this.CheckRing.TabIndex = 41;
            this.CheckRing.Text = "Ring";
            this.CheckRing.CheckedChanged += new System.EventHandler(this.CheckRing_CheckedChanged);
            // 
            // ColorPanel
            // 
            this.ColorPanel.Location = new System.Drawing.Point(193, 25);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(329, 88);
            this.ColorPanel.TabIndex = 40;
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(10, 49);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(188, 52);
            this.crossPanel.TabIndex = 35;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPanel.Location = new System.Drawing.Point(3, 16);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(200, 174);
            this.PersonPanel.TabIndex = 34;
            // 
            // HorizontalButton
            // 
            this.HorizontalButton.BackColor = System.Drawing.Color.Transparent;
            this.HorizontalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HorizontalButton.Location = new System.Drawing.Point(111, 16);
            this.HorizontalButton.Name = "HorizontalButton";
            this.HorizontalButton.Size = new System.Drawing.Size(86, 26);
            this.HorizontalButton.TabIndex = 32;
            this.HorizontalButton.Text = "ändern...";
            this.HorizontalButton.UseVisualStyleBackColor = false;
            this.HorizontalButton.Click += new System.EventHandler(this.HorizontalButton_Click);
            // 
            // QLabel
            // 
            this.QLabel.Location = new System.Drawing.Point(52, 24);
            this.QLabel.Name = "QLabel";
            this.QLabel.Size = new System.Drawing.Size(45, 19);
            this.QLabel.TabIndex = 33;
            this.QLabel.Text = "?";
            this.QLabel.Click += new System.EventHandler(this.QLabel_Click);
            // 
            // QueLabel
            // 
            this.QueLabel.Location = new System.Drawing.Point(7, 24);
            this.QueLabel.Name = "QueLabel";
            this.QueLabel.Size = new System.Drawing.Size(47, 20);
            this.QueLabel.TabIndex = 31;
            this.QueLabel.Text = "Frage:";
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.White;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoButton.Image = Resources.shell32_dll_I00f6_0409;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(6, 11);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(206, 34);
            this.GoButton.TabIndex = 43;
            this.GoButton.Text = "Auswerten";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AvgPieBox);
            this.groupBox2.Controls.Add(this.ExplodeBox);
            this.groupBox2.Controls.Add(this.Box3d);
            this.groupBox2.Controls.Add(this.MasterDesignBox);
            this.groupBox2.Controls.Add(this.DesignButton);
            this.groupBox2.Controls.Add(this.ColorPanel);
            this.groupBox2.Controls.Add(this.CheckRing);
            this.groupBox2.Controls.Add(this.StartPosBar);
            this.groupBox2.Controls.Add(this.sizeControl);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 128);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Design";
            // 
            // AvgPieBox
            // 
            this.AvgPieBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AvgPieBox.Location = new System.Drawing.Point(6, 68);
            this.AvgPieBox.Name = "AvgPieBox";
            this.AvgPieBox.Size = new System.Drawing.Size(120, 20);
            this.AvgPieBox.TabIndex = 61;
            this.AvgPieBox.Text = "Mittelwerttorte";
            this.AvgPieBox.CheckedChanged += new System.EventHandler(this.AvgPieBox_CheckedChanged);
            // 
            // ExplodeBox
            // 
            this.ExplodeBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExplodeBox.Location = new System.Drawing.Point(6, 52);
            this.ExplodeBox.Name = "ExplodeBox";
            this.ExplodeBox.Size = new System.Drawing.Size(85, 20);
            this.ExplodeBox.TabIndex = 60;
            this.ExplodeBox.Text = "Explodieren";
            this.ExplodeBox.CheckedChanged += new System.EventHandler(this.ExplodeBox_CheckedChanged);
            // 
            // Box3d
            // 
            this.Box3d.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Box3d.Location = new System.Drawing.Point(6, 37);
            this.Box3d.Name = "Box3d";
            this.Box3d.Size = new System.Drawing.Size(63, 20);
            this.Box3d.TabIndex = 59;
            this.Box3d.Text = "3D";
            this.Box3d.CheckedChanged += new System.EventHandler(this.Box3d_CheckedChanged);
            // 
            // MasterDesignBox
            // 
            this.MasterDesignBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MasterDesignBox.Location = new System.Drawing.Point(56, -2);
            this.MasterDesignBox.Name = "MasterDesignBox";
            this.MasterDesignBox.Size = new System.Drawing.Size(179, 21);
            this.MasterDesignBox.TabIndex = 58;
            this.MasterDesignBox.SelectedIndexChanged += new System.EventHandler(this.MasterDesignBox_SelectedIndexChanged);
            // 
            // DesignButton
            // 
            this.DesignButton.BackColor = System.Drawing.Color.White;
            this.DesignButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DesignButton.Image = Resources.shell32_dll_I010e_0409;
            this.DesignButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignButton.Location = new System.Drawing.Point(6, 90);
            this.DesignButton.Name = "DesignButton";
            this.DesignButton.Size = new System.Drawing.Size(169, 31);
            this.DesignButton.TabIndex = 58;
            this.DesignButton.Text = "     Einstellungen...";
            this.DesignButton.UseVisualStyleBackColor = true;
            this.DesignButton.Click += new System.EventHandler(this.DesignButton_Click);
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Transparent;
            this.sizeControl.Location = new System.Drawing.Point(541, 19);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(112, 58);
            this.sizeControl.TabIndex = 36;
            this.sizeControl.Load += new System.EventHandler(this.sizeControl_Load);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.Personengruppen);
            this.panel3.Controls.Add(this.GoButton);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(431, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(219, 419);
            this.panel3.TabIndex = 48;
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.PersonPanel);
            this.Personengruppen.Location = new System.Drawing.Point(6, 175);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Size = new System.Drawing.Size(206, 193);
            this.Personengruppen.TabIndex = 58;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Personengruppen";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QueLabel);
            this.groupBox1.Controls.Add(this.HorizontalButton);
            this.groupBox1.Controls.Add(this.QLabel);
            this.groupBox1.Controls.Add(this.crossPanel);
            this.groupBox1.Location = new System.Drawing.Point(6, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 116);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daten";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(8, 427);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel2.Size = new System.Drawing.Size(642, 136);
            this.panel2.TabIndex = 57;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Transparent;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(8, 8);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(423, 419);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 27;
            this.previewBox.Load += new System.EventHandler(this.previewBox_Load);
            // 
            // OutputControl_Pie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "OutputControl_Pie";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(658, 571);
            this.Load += new System.EventHandler(this.OutputControl_Pie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StartPosBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar StartPosBar;
        private System.Windows.Forms.CheckBox CheckRing;
        private System.Windows.Forms.Panel ColorPanel;
        private PreviewControl previewBox;
        private SizeControl sizeControl;
        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Panel PersonPanel;
        private System.Windows.Forms.Button HorizontalButton;
        private System.Windows.Forms.Label QLabel;
        private System.Windows.Forms.Label QueLabel;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Personengruppen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button DesignButton;
        private System.Windows.Forms.ComboBox MasterDesignBox;
        private System.Windows.Forms.CheckBox Box3d;
        private System.Windows.Forms.CheckBox ExplodeBox;
        private System.Windows.Forms.CheckBox AvgPieBox;
    }
}
