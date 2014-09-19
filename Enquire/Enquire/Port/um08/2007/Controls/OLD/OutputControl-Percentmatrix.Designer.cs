namespace umfrage2._2007.Controls
{
    partial class OutputControl_PercentMatrix
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
            this.PrecBox = new System.Windows.Forms.ComboBox();
            this.LegendBox = new System.Windows.Forms.CheckBox();
            this.StyleBox = new System.Windows.Forms.ComboBox();
            this.ArrowBox = new System.Windows.Forms.CheckBox();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.VerticalButton = new System.Windows.Forms.Button();
            this.VerticalLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HorizontalButton = new System.Windows.Forms.Button();
            this.HorizontalLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MasterDesignBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DesignButton = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.previewBox = new umfrage2.PreviewControl();
            this.sizeControl = new umfrage2.SizeControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Personengruppen.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrecBox
            // 
            this.PrecBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PrecBox.Location = new System.Drawing.Point(9, 61);
            this.PrecBox.Name = "PrecBox";
            this.PrecBox.Size = new System.Drawing.Size(229, 24);
            this.PrecBox.TabIndex = 43;
            this.PrecBox.SelectedIndexChanged += new System.EventHandler(this.PrecBox_SelectedIndexChanged);
            // 
            // LegendBox
            // 
            this.LegendBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LegendBox.Location = new System.Drawing.Point(270, 57);
            this.LegendBox.Name = "LegendBox";
            this.LegendBox.Size = new System.Drawing.Size(112, 24);
            this.LegendBox.TabIndex = 42;
            this.LegendBox.Text = "Beschriftung";
            this.LegendBox.CheckedChanged += new System.EventHandler(this.LegendBox_CheckedChanged);
            // 
            // StyleBox
            // 
            this.StyleBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StyleBox.Location = new System.Drawing.Point(9, 23);
            this.StyleBox.Name = "StyleBox";
            this.StyleBox.Size = new System.Drawing.Size(229, 24);
            this.StyleBox.TabIndex = 41;
            this.StyleBox.SelectedIndexChanged += new System.EventHandler(this.StyleBox_SelectedIndexChanged);
            // 
            // ArrowBox
            // 
            this.ArrowBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArrowBox.Location = new System.Drawing.Point(270, 30);
            this.ArrowBox.Name = "ArrowBox";
            this.ArrowBox.Size = new System.Drawing.Size(112, 24);
            this.ArrowBox.TabIndex = 40;
            this.ArrowBox.Text = "Pfeile";
            this.ArrowBox.CheckedChanged += new System.EventHandler(this.ArrowBox_CheckedChanged);
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(2, 88);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(234, 35);
            this.crossPanel.TabIndex = 39;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Location = new System.Drawing.Point(12, 24);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(235, 185);
            this.PersonPanel.TabIndex = 38;
            // 
            // VerticalButton
            // 
            this.VerticalButton.BackColor = System.Drawing.Color.White;
            this.VerticalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VerticalButton.Location = new System.Drawing.Point(132, 51);
            this.VerticalButton.Name = "VerticalButton";
            this.VerticalButton.Size = new System.Drawing.Size(104, 29);
            this.VerticalButton.TabIndex = 34;
            this.VerticalButton.Text = "ändern...";
            this.VerticalButton.UseVisualStyleBackColor = false;
            this.VerticalButton.Click += new System.EventHandler(this.VerticalButton_Click);
            // 
            // VerticalLabel
            // 
            this.VerticalLabel.Location = new System.Drawing.Point(86, 57);
            this.VerticalLabel.Name = "VerticalLabel";
            this.VerticalLabel.Size = new System.Drawing.Size(40, 23);
            this.VerticalLabel.TabIndex = 35;
            this.VerticalLabel.Text = "?";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "Vertikal:";
            // 
            // HorizontalButton
            // 
            this.HorizontalButton.BackColor = System.Drawing.Color.White;
            this.HorizontalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HorizontalButton.Location = new System.Drawing.Point(132, 16);
            this.HorizontalButton.Name = "HorizontalButton";
            this.HorizontalButton.Size = new System.Drawing.Size(104, 29);
            this.HorizontalButton.TabIndex = 31;
            this.HorizontalButton.Text = "ändern...";
            this.HorizontalButton.UseVisualStyleBackColor = false;
            this.HorizontalButton.Click += new System.EventHandler(this.HorizontalButton_Click);
            // 
            // HorizontalLabel
            // 
            this.HorizontalLabel.Location = new System.Drawing.Point(86, 22);
            this.HorizontalLabel.Name = "HorizontalLabel";
            this.HorizontalLabel.Size = new System.Drawing.Size(40, 23);
            this.HorizontalLabel.TabIndex = 32;
            this.HorizontalLabel.Text = "?";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "Horizontal:";
            // 
            // MasterDesignBox
            // 
            this.MasterDesignBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MasterDesignBox.Location = new System.Drawing.Point(270, 0);
            this.MasterDesignBox.Name = "MasterDesignBox";
            this.MasterDesignBox.Size = new System.Drawing.Size(229, 24);
            this.MasterDesignBox.TabIndex = 44;
            this.MasterDesignBox.SelectedIndexChanged += new System.EventHandler(this.MasterDesignBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.HorizontalLabel);
            this.groupBox1.Controls.Add(this.HorizontalButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.crossPanel);
            this.groupBox1.Controls.Add(this.VerticalLabel);
            this.groupBox1.Controls.Add(this.VerticalButton);
            this.groupBox1.Location = new System.Drawing.Point(16, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 138);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daten";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DesignButton);
            this.groupBox2.Controls.Add(this.MasterDesignBox);
            this.groupBox2.Controls.Add(this.StyleBox);
            this.groupBox2.Controls.Add(this.PrecBox);
            this.groupBox2.Controls.Add(this.LegendBox);
            this.groupBox2.Controls.Add(this.ArrowBox);
            this.groupBox2.Location = new System.Drawing.Point(14, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 113);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Design";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Personengruppen);
            this.panel1.Controls.Add(this.sizeControl);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.GoButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(605, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 545);
            this.panel1.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 402);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 143);
            this.panel2.TabIndex = 49;
            // 
            // DesignButton
            // 
            this.DesignButton.BackColor = System.Drawing.Color.White;
            this.DesignButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DesignButton.Image = global::umfrage2.Properties.Resources.shell32_dll_I010e_0409;
            this.DesignButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignButton.Location = new System.Drawing.Point(377, 63);
            this.DesignButton.Name = "DesignButton";
            this.DesignButton.Size = new System.Drawing.Size(179, 31);
            this.DesignButton.TabIndex = 48;
            this.DesignButton.Text = "     Einstellungen...";
            this.DesignButton.UseVisualStyleBackColor = true;
            this.DesignButton.Click += new System.EventHandler(this.DesignButton_Click);
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.White;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoButton.Image = global::umfrage2.Properties.Resources.shell32_dll_I00f6_0409;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(16, 27);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(261, 42);
            this.GoButton.TabIndex = 28;
            this.GoButton.Text = "Auswerten";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.PersonPanel);
            this.Personengruppen.Location = new System.Drawing.Point(16, 82);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Size = new System.Drawing.Size(261, 226);
            this.Personengruppen.TabIndex = 47;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Personengruppen";
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Transparent;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(0, 0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Padding = new System.Windows.Forms.Padding(15);
            this.previewBox.Size = new System.Drawing.Size(605, 402);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 27;
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Transparent;
            this.sizeControl.Location = new System.Drawing.Point(16, 472);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(104, 56);
            this.sizeControl.TabIndex = 37;
            // 
            // OutputControl_PercentMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "OutputControl_PercentMatrix";
            this.Size = new System.Drawing.Size(900, 545);
            this.SizeChanged += new System.EventHandler(this.OutputControl_PercentMatrix_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.ComboBox PrecBox;
        private System.Windows.Forms.CheckBox LegendBox;
        private System.Windows.Forms.ComboBox StyleBox;
        private System.Windows.Forms.CheckBox ArrowBox;
        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Panel PersonPanel;
        private SizeControl sizeControl;
        private System.Windows.Forms.Button VerticalButton;
        private System.Windows.Forms.Label VerticalLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button HorizontalButton;
        private System.Windows.Forms.Label HorizontalLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox MasterDesignBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DesignButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private PreviewControl previewBox;
        private System.Windows.Forms.GroupBox Personengruppen;
    }
}
