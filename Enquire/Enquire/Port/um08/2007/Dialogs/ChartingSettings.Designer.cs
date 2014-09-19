using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Dialogs
{
    partial class ChartingSettings
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
            this.ShadingBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TransparencyControl = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.YAxis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.XAxis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.KButton = new System.Windows.Forms.Button();
            this.CButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CBorder = new System.Windows.Forms.Button();
            this.EChooseColor = new System.Windows.Forms.Button();
            this.EChooseFont = new System.Windows.Forms.Button();
            this.EFPreview = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ElementFont = new System.Windows.Forms.FontDialog();
            this.ElementColor = new System.Windows.Forms.ColorDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.GlassBox = new System.Windows.Forms.CheckBox();
            this.BevelBox = new System.Windows.Forms.CheckBox();
            this.BackColorButton2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BackColorButton1 = new System.Windows.Forms.Button();
            this.ColDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ChartGlass = new System.Windows.Forms.CheckBox();
            this.ChartBevel = new System.Windows.Forms.CheckBox();
            this.ChartBack2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ChartBack1 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.OnlyLegendBox = new System.Windows.Forms.CheckBox();
            this.ShowLegendBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LBorder = new System.Windows.Forms.Button();
            this.LChooseColor = new System.Windows.Forms.Button();
            this.LChooseFont = new System.Windows.Forms.Button();
            this.LFPreview = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LegendG = new System.Windows.Forms.CheckBox();
            this.LegendB = new System.Windows.Forms.CheckBox();
            this.Legend2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Legend1 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ShowNBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransparencyControl)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShadingBox
            // 
            this.ShadingBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShadingBox.Location = new System.Drawing.Point(157, 23);
            this.ShadingBox.Name = "ShadingBox";
            this.ShadingBox.Size = new System.Drawing.Size(163, 21);
            this.ShadingBox.TabIndex = 49;
            this.ShadingBox.SelectedIndexChanged += new System.EventHandler(this.ShadingBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ShadingBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 63);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shading";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Schattierungsmodus:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.TransparencyControl);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 63);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Farbeinstellungen";
            // 
            // TransparencyControl
            // 
            this.TransparencyControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TransparencyControl.Location = new System.Drawing.Point(161, 23);
            this.TransparencyControl.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TransparencyControl.Name = "TransparencyControl";
            this.TransparencyControl.Size = new System.Drawing.Size(70, 20);
            this.TransparencyControl.TabIndex = 55;
            this.TransparencyControl.ValueChanged += new System.EventHandler(this.TransparencyControl_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Transparenz (0-255):";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.YAxis);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.XAxis);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 85);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Achsen";
            // 
            // YAxis
            // 
            this.YAxis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.YAxis.Location = new System.Drawing.Point(131, 47);
            this.YAxis.Name = "YAxis";
            this.YAxis.Size = new System.Drawing.Size(189, 20);
            this.YAxis.TabIndex = 59;
            this.YAxis.TextChanged += new System.EventHandler(this.YAxis_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Beschriftung Y:";
            // 
            // XAxis
            // 
            this.XAxis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.XAxis.Location = new System.Drawing.Point(131, 17);
            this.XAxis.Name = "XAxis";
            this.XAxis.Size = new System.Drawing.Size(189, 20);
            this.XAxis.TabIndex = 57;
            this.XAxis.TextChanged += new System.EventHandler(this.XAxis_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Beschriftung X:";
            // 
            // KButton
            // 
            this.KButton.BackColor = System.Drawing.Color.White;
            this.KButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.KButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00f6_0409;
            this.KButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KButton.Location = new System.Drawing.Point(528, 393);
            this.KButton.Name = "KButton";
            this.KButton.Size = new System.Drawing.Size(160, 42);
            this.KButton.TabIndex = 52;
            this.KButton.Text = "OK";
            this.KButton.UseVisualStyleBackColor = true;
            this.KButton.Click += new System.EventHandler(this.KButton_Click);
            // 
            // CButton
            // 
            this.CButton.BackColor = System.Drawing.Color.White;
            this.CButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00f0_0409;
            this.CButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CButton.Location = new System.Drawing.Point(353, 393);
            this.CButton.Name = "CButton";
            this.CButton.Size = new System.Drawing.Size(160, 42);
            this.CButton.TabIndex = 51;
            this.CButton.Text = "Abbrechen";
            this.CButton.UseVisualStyleBackColor = true;
            this.CButton.Click += new System.EventHandler(this.CButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.CBorder);
            this.groupBox4.Controls.Add(this.EChooseColor);
            this.groupBox4.Controls.Add(this.EChooseFont);
            this.groupBox4.Controls.Add(this.EFPreview);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(353, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(335, 132);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Diagramm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "Rahmen:";
            // 
            // CBorder
            // 
            this.CBorder.BackColor = System.Drawing.Color.White;
            this.CBorder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBorder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBorder.Location = new System.Drawing.Point(91, 63);
            this.CBorder.Name = "CBorder";
            this.CBorder.Size = new System.Drawing.Size(45, 29);
            this.CBorder.TabIndex = 72;
            this.CBorder.UseVisualStyleBackColor = true;
            this.CBorder.Click += new System.EventHandler(this.CBorder_Click);
            // 
            // EChooseColor
            // 
            this.EChooseColor.BackColor = System.Drawing.Color.White;
            this.EChooseColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EChooseColor.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I010e_0409;
            this.EChooseColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EChooseColor.Location = new System.Drawing.Point(271, 23);
            this.EChooseColor.Name = "EChooseColor";
            this.EChooseColor.Size = new System.Drawing.Size(45, 42);
            this.EChooseColor.TabIndex = 60;
            this.EChooseColor.UseVisualStyleBackColor = true;
            this.EChooseColor.Click += new System.EventHandler(this.EChooseColor_Click);
            // 
            // EChooseFont
            // 
            this.EChooseFont.BackColor = System.Drawing.Color.White;
            this.EChooseFont.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EChooseFont.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I009c_0409;
            this.EChooseFont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EChooseFont.Location = new System.Drawing.Point(220, 23);
            this.EChooseFont.Name = "EChooseFont";
            this.EChooseFont.Size = new System.Drawing.Size(45, 42);
            this.EChooseFont.TabIndex = 59;
            this.EChooseFont.UseVisualStyleBackColor = true;
            this.EChooseFont.Click += new System.EventHandler(this.EChooseFont_Click);
            // 
            // EFPreview
            // 
            this.EFPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EFPreview.Location = new System.Drawing.Point(91, 23);
            this.EFPreview.Name = "EFPreview";
            this.EFPreview.Size = new System.Drawing.Size(123, 20);
            this.EFPreview.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Elemente:";
            // 
            // ElementFont
            // 
            this.ElementFont.Font = new System.Drawing.Font("Tahoma", 8F);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.GlassBox);
            this.groupBox5.Controls.Add(this.BevelBox);
            this.groupBox5.Controls.Add(this.BackColorButton2);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.BackColorButton1);
            this.groupBox5.Location = new System.Drawing.Point(12, 312);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(334, 65);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Allgemeiner Hintergrund";
            // 
            // GlassBox
            // 
            this.GlassBox.AutoSize = true;
            this.GlassBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GlassBox.Location = new System.Drawing.Point(251, 26);
            this.GlassBox.Name = "GlassBox";
            this.GlassBox.Size = new System.Drawing.Size(73, 17);
            this.GlassBox.TabIndex = 65;
            this.GlassBox.Text = "Glaseffekt";
            this.GlassBox.UseVisualStyleBackColor = true;
            this.GlassBox.CheckedChanged += new System.EventHandler(this.GlassBox_CheckedChanged);
            // 
            // BevelBox
            // 
            this.BevelBox.AutoSize = true;
            this.BevelBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BevelBox.Location = new System.Drawing.Point(193, 26);
            this.BevelBox.Name = "BevelBox";
            this.BevelBox.Size = new System.Drawing.Size(50, 17);
            this.BevelBox.TabIndex = 64;
            this.BevelBox.Text = "Bevel";
            this.BevelBox.UseVisualStyleBackColor = true;
            this.BevelBox.CheckedChanged += new System.EventHandler(this.BevelBox_CheckedChanged);
            // 
            // BackColorButton2
            // 
            this.BackColorButton2.BackColor = System.Drawing.Color.White;
            this.BackColorButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackColorButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackColorButton2.Location = new System.Drawing.Point(142, 21);
            this.BackColorButton2.Name = "BackColorButton2";
            this.BackColorButton2.Size = new System.Drawing.Size(45, 29);
            this.BackColorButton2.TabIndex = 63;
            this.BackColorButton2.UseVisualStyleBackColor = true;
            this.BackColorButton2.Click += new System.EventHandler(this.BackColorButton2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Farben:";
            // 
            // BackColorButton1
            // 
            this.BackColorButton1.BackColor = System.Drawing.Color.White;
            this.BackColorButton1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackColorButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackColorButton1.Location = new System.Drawing.Point(91, 21);
            this.BackColorButton1.Name = "BackColorButton1";
            this.BackColorButton1.Size = new System.Drawing.Size(45, 29);
            this.BackColorButton1.TabIndex = 61;
            this.BackColorButton1.UseVisualStyleBackColor = true;
            this.BackColorButton1.Click += new System.EventHandler(this.BackColorButton1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.ChartGlass);
            this.groupBox6.Controls.Add(this.ChartBevel);
            this.groupBox6.Controls.Add(this.ChartBack2);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.ChartBack1);
            this.groupBox6.Location = new System.Drawing.Point(12, 241);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(334, 63);
            this.groupBox6.TabIndex = 58;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Objekthintergrund";
            // 
            // ChartGlass
            // 
            this.ChartGlass.AutoSize = true;
            this.ChartGlass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChartGlass.Location = new System.Drawing.Point(251, 27);
            this.ChartGlass.Name = "ChartGlass";
            this.ChartGlass.Size = new System.Drawing.Size(73, 17);
            this.ChartGlass.TabIndex = 65;
            this.ChartGlass.Text = "Glaseffekt";
            this.ChartGlass.UseVisualStyleBackColor = true;
            this.ChartGlass.CheckedChanged += new System.EventHandler(this.ChartGlass_CheckedChanged);
            // 
            // ChartBevel
            // 
            this.ChartBevel.AutoSize = true;
            this.ChartBevel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChartBevel.Location = new System.Drawing.Point(193, 26);
            this.ChartBevel.Name = "ChartBevel";
            this.ChartBevel.Size = new System.Drawing.Size(50, 17);
            this.ChartBevel.TabIndex = 64;
            this.ChartBevel.Text = "Bevel";
            this.ChartBevel.UseVisualStyleBackColor = true;
            this.ChartBevel.CheckedChanged += new System.EventHandler(this.ChartBevel_CheckedChanged);
            // 
            // ChartBack2
            // 
            this.ChartBack2.BackColor = System.Drawing.Color.White;
            this.ChartBack2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChartBack2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChartBack2.Location = new System.Drawing.Point(142, 21);
            this.ChartBack2.Name = "ChartBack2";
            this.ChartBack2.Size = new System.Drawing.Size(45, 29);
            this.ChartBack2.TabIndex = 63;
            this.ChartBack2.UseVisualStyleBackColor = true;
            this.ChartBack2.Click += new System.EventHandler(this.ChartBack2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Farben:";
            // 
            // ChartBack1
            // 
            this.ChartBack1.BackColor = System.Drawing.Color.White;
            this.ChartBack1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChartBack1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChartBack1.Location = new System.Drawing.Point(91, 21);
            this.ChartBack1.Name = "ChartBack1";
            this.ChartBack1.Size = new System.Drawing.Size(45, 29);
            this.ChartBack1.TabIndex = 61;
            this.ChartBack1.UseVisualStyleBackColor = true;
            this.ChartBack1.Click += new System.EventHandler(this.ChartBack1_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.OnlyLegendBox);
            this.groupBox7.Controls.Add(this.ShowLegendBox);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.LBorder);
            this.groupBox7.Controls.Add(this.LChooseColor);
            this.groupBox7.Controls.Add(this.LChooseFont);
            this.groupBox7.Controls.Add(this.LFPreview);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.LegendG);
            this.groupBox7.Controls.Add(this.LegendB);
            this.groupBox7.Controls.Add(this.Legend2);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.Legend1);
            this.groupBox7.Location = new System.Drawing.Point(353, 156);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(335, 148);
            this.groupBox7.TabIndex = 59;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Legende";
            // 
            // OnlyLegendBox
            // 
            this.OnlyLegendBox.AutoSize = true;
            this.OnlyLegendBox.Enabled = false;
            this.OnlyLegendBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OnlyLegendBox.Location = new System.Drawing.Point(153, 125);
            this.OnlyLegendBox.Name = "OnlyLegendBox";
            this.OnlyLegendBox.Size = new System.Drawing.Size(132, 17);
            this.OnlyLegendBox.TabIndex = 73;
            this.OnlyLegendBox.Text = "Nur Legende Anzeigen";
            this.OnlyLegendBox.UseVisualStyleBackColor = true;
            this.OnlyLegendBox.CheckedChanged += new System.EventHandler(this.OnlyLegendBox_CheckedChanged);
            // 
            // ShowLegendBox
            // 
            this.ShowLegendBox.AutoSize = true;
            this.ShowLegendBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowLegendBox.Location = new System.Drawing.Point(153, 107);
            this.ShowLegendBox.Name = "ShowLegendBox";
            this.ShowLegendBox.Size = new System.Drawing.Size(112, 17);
            this.ShowLegendBox.TabIndex = 72;
            this.ShowLegendBox.Text = "Legende Anzeigen";
            this.ShowLegendBox.UseVisualStyleBackColor = true;
            this.ShowLegendBox.CheckedChanged += new System.EventHandler(this.ShowLegendBox_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Rahmen:";
            // 
            // LBorder
            // 
            this.LBorder.BackColor = System.Drawing.Color.White;
            this.LBorder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LBorder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBorder.Location = new System.Drawing.Point(91, 109);
            this.LBorder.Name = "LBorder";
            this.LBorder.Size = new System.Drawing.Size(45, 29);
            this.LBorder.TabIndex = 70;
            this.LBorder.UseVisualStyleBackColor = true;
            this.LBorder.Click += new System.EventHandler(this.LBorder_Click);
            // 
            // LChooseColor
            // 
            this.LChooseColor.BackColor = System.Drawing.Color.White;
            this.LChooseColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LChooseColor.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I010e_0409;
            this.LChooseColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LChooseColor.Location = new System.Drawing.Point(271, 59);
            this.LChooseColor.Name = "LChooseColor";
            this.LChooseColor.Size = new System.Drawing.Size(45, 42);
            this.LChooseColor.TabIndex = 69;
            this.LChooseColor.UseVisualStyleBackColor = true;
            this.LChooseColor.Click += new System.EventHandler(this.LChooseColor_Click);
            // 
            // LChooseFont
            // 
            this.LChooseFont.BackColor = System.Drawing.Color.White;
            this.LChooseFont.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LChooseFont.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I009c_0409;
            this.LChooseFont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LChooseFont.Location = new System.Drawing.Point(220, 59);
            this.LChooseFont.Name = "LChooseFont";
            this.LChooseFont.Size = new System.Drawing.Size(45, 42);
            this.LChooseFont.TabIndex = 68;
            this.LChooseFont.UseVisualStyleBackColor = true;
            this.LChooseFont.Click += new System.EventHandler(this.LChooseFont_Click);
            // 
            // LFPreview
            // 
            this.LFPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LFPreview.Location = new System.Drawing.Point(91, 59);
            this.LFPreview.Name = "LFPreview";
            this.LFPreview.Size = new System.Drawing.Size(123, 20);
            this.LFPreview.TabIndex = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 66;
            this.label9.Text = "Elemente:";
            // 
            // LegendG
            // 
            this.LegendG.AutoSize = true;
            this.LegendG.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LegendG.Location = new System.Drawing.Point(251, 23);
            this.LegendG.Name = "LegendG";
            this.LegendG.Size = new System.Drawing.Size(73, 17);
            this.LegendG.TabIndex = 65;
            this.LegendG.Text = "Glaseffekt";
            this.LegendG.UseVisualStyleBackColor = true;
            this.LegendG.CheckedChanged += new System.EventHandler(this.LegendG_CheckedChanged);
            // 
            // LegendB
            // 
            this.LegendB.AutoSize = true;
            this.LegendB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LegendB.Location = new System.Drawing.Point(193, 23);
            this.LegendB.Name = "LegendB";
            this.LegendB.Size = new System.Drawing.Size(50, 17);
            this.LegendB.TabIndex = 64;
            this.LegendB.Text = "Bevel";
            this.LegendB.UseVisualStyleBackColor = true;
            this.LegendB.CheckedChanged += new System.EventHandler(this.LegendB_CheckedChanged);
            // 
            // Legend2
            // 
            this.Legend2.BackColor = System.Drawing.Color.White;
            this.Legend2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Legend2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Legend2.Location = new System.Drawing.Point(142, 18);
            this.Legend2.Name = "Legend2";
            this.Legend2.Size = new System.Drawing.Size(45, 29);
            this.Legend2.TabIndex = 63;
            this.Legend2.UseVisualStyleBackColor = true;
            this.Legend2.Click += new System.EventHandler(this.Legend2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Farben:";
            // 
            // Legend1
            // 
            this.Legend1.BackColor = System.Drawing.Color.White;
            this.Legend1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Legend1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Legend1.Location = new System.Drawing.Point(91, 18);
            this.Legend1.Name = "Legend1";
            this.Legend1.Size = new System.Drawing.Size(45, 29);
            this.Legend1.TabIndex = 61;
            this.Legend1.UseVisualStyleBackColor = true;
            this.Legend1.Click += new System.EventHandler(this.Legend1_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.ShowNBox);
            this.groupBox8.Location = new System.Drawing.Point(352, 312);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(335, 64);
            this.groupBox8.TabIndex = 60;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Statistik";
            // 
            // ShowNBox
            // 
            this.ShowNBox.AutoSize = true;
            this.ShowNBox.BackColor = System.Drawing.Color.Transparent;
            this.ShowNBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowNBox.Location = new System.Drawing.Point(20, 27);
            this.ShowNBox.Name = "ShowNBox";
            this.ShowNBox.Size = new System.Drawing.Size(155, 17);
            this.ShowNBox.TabIndex = 72;
            this.ShowNBox.Text = "Stichprobengröße anzeigen";
            this.ShowNBox.UseVisualStyleBackColor = false;
            this.ShowNBox.CheckedChanged += new System.EventHandler(this.ShowNBox_CheckedChanged);
            // 
            // ChartingSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(698, 482);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.KButton);
            this.Controls.Add(this.CButton);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChartingSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Erweiterte Einstellungen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransparencyControl)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ShadingBox;
        private System.Windows.Forms.Button CButton;
        private System.Windows.Forms.Button KButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TransparencyControl;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox YAxis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox XAxis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FontDialog ElementFont;
        private System.Windows.Forms.TextBox EFPreview;
        private System.Windows.Forms.Button EChooseFont;
        private System.Windows.Forms.Button EChooseColor;
        private System.Windows.Forms.ColorDialog ElementColor;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BackColorButton2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BackColorButton1;
        private System.Windows.Forms.ColorDialog ColDialog;
        private System.Windows.Forms.CheckBox GlassBox;
        private System.Windows.Forms.CheckBox BevelBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox ChartGlass;
        private System.Windows.Forms.CheckBox ChartBevel;
        private System.Windows.Forms.Button ChartBack2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ChartBack1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox LegendG;
        private System.Windows.Forms.CheckBox LegendB;
        private System.Windows.Forms.Button Legend2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Legend1;
        private System.Windows.Forms.Button LChooseColor;
        private System.Windows.Forms.Button LChooseFont;
        private System.Windows.Forms.TextBox LFPreview;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button CBorder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button LBorder;
        private System.Windows.Forms.CheckBox ShowLegendBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox ShowNBox;
        private System.Windows.Forms.CheckBox OnlyLegendBox;
    }
}