using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_SocioMatrix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputControl_SocioMatrix));
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.VerticalButton = new System.Windows.Forms.Button();
            this.VerticalLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HorizontalButton = new System.Windows.Forms.Button();
            this.HorizontalLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._relativeWeightBox = new System.Windows.Forms.CheckBox();
            this._invertBox = new System.Windows.Forms.CheckBox();
            this._colorRange = new Compucare.Enquire.Common.Calculation.Graphics.Common.Controls.ColorRanges.TripleColorRangeControlPercent();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.angleControl = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.maxThick = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.minThickControl = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bubbleWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.bubbleHeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nodeFontButton = new System.Windows.Forms.Button();
            this.maxThickControl = new System.Windows.Forms.Panel();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.sizeControl = new SizeControl();
            this.GoButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nodeFontDialog = new System.Windows.Forms.FontDialog();
            this.previewBox = new PreviewControl();
            this._nodeModeCombo = new System.Windows.Forms.ComboBox();
            this._comboNodeSelector = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleControl)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxThick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minThickControl)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleHeight)).BeginInit();
            this.maxThickControl.SuspendLayout();
            this.Personengruppen.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(12, 94);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(250, 64);
            this.crossPanel.TabIndex = 39;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPanel.Location = new System.Drawing.Point(3, 16);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(269, 116);
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
            this.label4.Size = new System.Drawing.Size(71, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "Kantenfrage:";
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
            this.label2.Text = "Knotenfrage:";
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
            this.groupBox1.Location = new System.Drawing.Point(6, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 167);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daten";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._comboNodeSelector);
            this.groupBox2.Controls.Add(this._nodeModeCombo);
            this.groupBox2.Controls.Add(this._relativeWeightBox);
            this.groupBox2.Controls.Add(this._invertBox);
            this.groupBox2.Controls.Add(this._colorRange);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 225);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Einstellungen";
            // 
            // _relativeWeightBox
            // 
            this._relativeWeightBox.AutoSize = true;
            this._relativeWeightBox.Location = new System.Drawing.Point(470, 49);
            this._relativeWeightBox.Name = "_relativeWeightBox";
            this._relativeWeightBox.Size = new System.Drawing.Size(124, 17);
            this._relativeWeightBox.TabIndex = 5;
            this._relativeWeightBox.Text = "Relative Gewichtung";
            this._relativeWeightBox.UseVisualStyleBackColor = true;
            // 
            // _invertBox
            // 
            this._invertBox.AutoSize = true;
            this._invertBox.Location = new System.Drawing.Point(470, 26);
            this._invertBox.Name = "_invertBox";
            this._invertBox.Size = new System.Drawing.Size(107, 17);
            this._invertBox.TabIndex = 4;
            this._invertBox.Text = "Pfeile invertieren";
            this._invertBox.UseVisualStyleBackColor = true;
            // 
            // _colorRange
            // 
            this._colorRange.ColorHigh = System.Drawing.Color.Green;
            this._colorRange.ColorLow = System.Drawing.Color.Red;
            this._colorRange.ColorMid = System.Drawing.Color.Black;
            this._colorRange.ColorRange = ((Compucare.Enquire.Common.Calculation.Graphics.Common.ColorRanges.MultiColorRange)(resources.GetObject("_colorRange.ColorRange")));
            this._colorRange.Location = new System.Drawing.Point(267, 113);
            this._colorRange.MaxValue = 100D;
            this._colorRange.MinValue = 0D;
            this._colorRange.Name = "_colorRange";
            this._colorRange.RangeHigh = 75D;
            this._colorRange.RangeMid = 25D;
            this._colorRange.Size = new System.Drawing.Size(396, 85);
            this._colorRange.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.angleControl);
            this.groupBox5.Location = new System.Drawing.Point(264, 26);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 79);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Positionierung";
            // 
            // angleControl
            // 
            this.angleControl.Location = new System.Drawing.Point(17, 22);
            this.angleControl.Maximum = 360;
            this.angleControl.Name = "angleControl";
            this.angleControl.Size = new System.Drawing.Size(177, 45);
            this.angleControl.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.maxThick);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.minThickControl);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(16, 111);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(242, 79);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kanten/Rahmen";
            // 
            // maxThick
            // 
            this.maxThick.Location = new System.Drawing.Point(85, 55);
            this.maxThick.Name = "maxThick";
            this.maxThick.Size = new System.Drawing.Size(49, 20);
            this.maxThick.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "max. Stärke";
            // 
            // minThickControl
            // 
            this.minThickControl.Location = new System.Drawing.Point(85, 29);
            this.minThickControl.Name = "minThickControl";
            this.minThickControl.Size = new System.Drawing.Size(49, 20);
            this.minThickControl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "min. Stärke";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bubbleWidth);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.bubbleHeight);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.nodeFontButton);
            this.groupBox3.Location = new System.Drawing.Point(16, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 79);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Knoten";
            // 
            // bubbleWidth
            // 
            this.bubbleWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bubbleWidth.Location = new System.Drawing.Point(54, 50);
            this.bubbleWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.bubbleWidth.Name = "bubbleWidth";
            this.bubbleWidth.Size = new System.Drawing.Size(49, 20);
            this.bubbleWidth.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Breite";
            // 
            // bubbleHeight
            // 
            this.bubbleHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bubbleHeight.Location = new System.Drawing.Point(54, 24);
            this.bubbleHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.bubbleHeight.Name = "bubbleHeight";
            this.bubbleHeight.Size = new System.Drawing.Size(49, 20);
            this.bubbleHeight.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Höhe";
            // 
            // nodeFontButton
            // 
            this.nodeFontButton.Location = new System.Drawing.Point(129, 19);
            this.nodeFontButton.Name = "nodeFontButton";
            this.nodeFontButton.Size = new System.Drawing.Size(93, 30);
            this.nodeFontButton.TabIndex = 39;
            this.nodeFontButton.Text = "Schriftart";
            this.nodeFontButton.UseVisualStyleBackColor = true;
            this.nodeFontButton.Click += new System.EventHandler(this.nodeFontButton_Click);
            // 
            // maxThickControl
            // 
            this.maxThickControl.AutoScroll = true;
            this.maxThickControl.Controls.Add(this.Personengruppen);
            this.maxThickControl.Controls.Add(this.sizeControl);
            this.maxThickControl.Controls.Add(this.groupBox1);
            this.maxThickControl.Controls.Add(this.GoButton);
            this.maxThickControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.maxThickControl.Location = new System.Drawing.Point(505, 0);
            this.maxThickControl.Name = "maxThickControl";
            this.maxThickControl.Size = new System.Drawing.Size(295, 465);
            this.maxThickControl.TabIndex = 48;
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.PersonPanel);
            this.Personengruppen.Location = new System.Drawing.Point(6, 224);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Size = new System.Drawing.Size(275, 135);
            this.Personengruppen.TabIndex = 47;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Personengruppen";
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Transparent;
            this.sizeControl.Location = new System.Drawing.Point(9, 365);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(104, 56);
            this.sizeControl.TabIndex = 37;
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.White;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoButton.Image = Resources.shell32_dll_I00f6_0409;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(6, 3);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(275, 42);
            this.GoButton.TabIndex = 28;
            this.GoButton.Text = "Auswerten";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 465);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel2.Size = new System.Drawing.Size(800, 235);
            this.panel2.TabIndex = 49;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Transparent;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(0, 0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(505, 465);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 27;
            // 
            // _nodeModeCombo
            // 
            this._nodeModeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._nodeModeCombo.FormattingEnabled = true;
            this._nodeModeCombo.Location = new System.Drawing.Point(470, 72);
            this._nodeModeCombo.Name = "_nodeModeCombo";
            this._nodeModeCombo.Size = new System.Drawing.Size(121, 21);
            this._nodeModeCombo.TabIndex = 6;
            // 
            // _comboNodeSelector
            // 
            this._comboNodeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboNodeSelector.FormattingEnabled = true;
            this._comboNodeSelector.Location = new System.Drawing.Point(597, 72);
            this._comboNodeSelector.Name = "_comboNodeSelector";
            this._comboNodeSelector.Size = new System.Drawing.Size(121, 21);
            this._comboNodeSelector.TabIndex = 7;
            // 
            // OutputControl_SocioMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.maxThickControl);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "OutputControl_SocioMatrix";
            this.Size = new System.Drawing.Size(800, 700);
            this.SizeChanged += new System.EventHandler(this.OutputControl_PercentMatrix_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleControl)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxThick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minThickControl)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleHeight)).EndInit();
            this.maxThickControl.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Panel PersonPanel;
        private SizeControl sizeControl;
        private System.Windows.Forms.Button VerticalButton;
        private System.Windows.Forms.Label VerticalLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button HorizontalButton;
        private System.Windows.Forms.Label HorizontalLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel maxThickControl;
        private System.Windows.Forms.Panel panel2;
        private PreviewControl previewBox;
        private System.Windows.Forms.GroupBox Personengruppen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button nodeFontButton;
        private System.Windows.Forms.FontDialog nodeFontDialog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown maxThick;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minThickControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TrackBar angleControl;
        private System.Windows.Forms.NumericUpDown bubbleWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown bubbleHeight;
        private System.Windows.Forms.Label label6;
        private Compucare.Enquire.Common.Calculation.Graphics.Common.Controls.ColorRanges.TripleColorRangeControlPercent _colorRange;
        private System.Windows.Forms.CheckBox _relativeWeightBox;
        private System.Windows.Forms.CheckBox _invertBox;
        private System.Windows.Forms.ComboBox _nodeModeCombo;
        private System.Windows.Forms.ComboBox _comboNodeSelector;
    }
}
