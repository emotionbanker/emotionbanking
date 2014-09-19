using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_Radar
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
            this.OverloadButton = new System.Windows.Forms.Button();
            this.QRemove = new System.Windows.Forms.Button();
            this.QAdd = new System.Windows.Forms.Button();
            this.QBox = new System.Windows.Forms.ListBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.QFontDialog = new System.Windows.Forms.FontDialog();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.DesignButton = new System.Windows.Forms.Button();
            this.previewBox = new PreviewControl();
            this.sizeControl = new SizeControl();
            this.panel1.SuspendLayout();
            this.Personengruppen.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OverloadButton
            // 
            this.OverloadButton.BackColor = System.Drawing.Color.Transparent;
            this.OverloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OverloadButton.Location = new System.Drawing.Point(18, 78);
            this.OverloadButton.Margin = new System.Windows.Forms.Padding(4);
            this.OverloadButton.Name = "OverloadButton";
            this.OverloadButton.Size = new System.Drawing.Size(240, 32);
            this.OverloadButton.TabIndex = 60;
            this.OverloadButton.Text = "Beschriftungen";
            this.OverloadButton.UseVisualStyleBackColor = false;
            this.OverloadButton.Click += new System.EventHandler(this.OverloadButton_Click);
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.Transparent;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(219, 70);
            this.QRemove.Margin = new System.Windows.Forms.Padding(4);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(39, 39);
            this.QRemove.TabIndex = 58;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new System.EventHandler(this.QRemove_Click);
            // 
            // QAdd
            // 
            this.QAdd.BackColor = System.Drawing.Color.Transparent;
            this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QAdd.Location = new System.Drawing.Point(219, 23);
            this.QAdd.Margin = new System.Windows.Forms.Padding(4);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new System.Drawing.Size(39, 39);
            this.QAdd.TabIndex = 57;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            this.QAdd.Click += new System.EventHandler(this.QAdd_Click);
            // 
            // QBox
            // 
            this.QBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 16;
            this.QBox.Location = new System.Drawing.Point(8, 23);
            this.QBox.Margin = new System.Windows.Forms.Padding(4);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(206, 130);
            this.QBox.TabIndex = 56;
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(8, 161);
            this.crossPanel.Margin = new System.Windows.Forms.Padding(4);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(250, 64);
            this.crossPanel.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Personengruppen);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.GoButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(491, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 495);
            this.panel1.TabIndex = 68;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.panel3);
            this.Personengruppen.Location = new System.Drawing.Point(13, 305);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Size = new System.Drawing.Size(275, 182);
            this.Personengruppen.TabIndex = 90;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Personengruppen";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 18);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(15);
            this.panel3.Size = new System.Drawing.Size(269, 161);
            this.panel3.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QBox);
            this.groupBox1.Controls.Add(this.crossPanel);
            this.groupBox1.Controls.Add(this.QAdd);
            this.groupBox1.Controls.Add(this.QRemove);
            this.groupBox1.Location = new System.Drawing.Point(13, 67);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(275, 231);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daten";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 505);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 185);
            this.panel2.TabIndex = 69;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DesignButton);
            this.groupBox2.Controls.Add(this.sizeControl);
            this.groupBox2.Controls.Add(this.OverloadButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(780, 185);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Einstellungen";
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.White;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoButton.Image = Resources.shell32_dll_I00f6_0409;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(13, 17);
            this.GoButton.Margin = new System.Windows.Forms.Padding(4);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(275, 42);
            this.GoButton.TabIndex = 89;
            this.GoButton.Text = "Auswerten";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // DesignButton
            // 
            this.DesignButton.BackColor = System.Drawing.Color.White;
            this.DesignButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DesignButton.Image = Resources.shell32_dll_I010e_0409;
            this.DesignButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignButton.Location = new System.Drawing.Point(18, 32);
            this.DesignButton.Margin = new System.Windows.Forms.Padding(4);
            this.DesignButton.Name = "DesignButton";
            this.DesignButton.Size = new System.Drawing.Size(239, 38);
            this.DesignButton.TabIndex = 70;
            this.DesignButton.Text = "     Einstellungen...";
            this.DesignButton.UseVisualStyleBackColor = true;
            this.DesignButton.Click += new System.EventHandler(this.DesignButton_Click);
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Transparent;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(10, 10);
            this.previewBox.Margin = new System.Windows.Forms.Padding(4);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(481, 495);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 50;
            this.previewBox.Load += new System.EventHandler(this.previewBox_Load);
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Transparent;
            this.sizeControl.Location = new System.Drawing.Point(300, 32);
            this.sizeControl.Margin = new System.Windows.Forms.Padding(4);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(169, 73);
            this.sizeControl.TabIndex = 53;
            // 
            // OutputControl_Radar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "OutputControl_Radar";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(800, 700);
            this.panel1.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OverloadButton;
        private System.Windows.Forms.Button QRemove;
        private System.Windows.Forms.Button QAdd;
        private System.Windows.Forms.ListBox QBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FontDialog QFontDialog;
        private PreviewControl previewBox;
        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Personengruppen;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DesignButton;
        private SizeControl sizeControl;
    }
}
