using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_Gaps
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveImages = new System.Windows.Forms.CheckBox();
            this.OverloadButton = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.QRemove = new System.Windows.Forms.Button();
            this.QAdd = new System.Windows.Forms.Button();
            this.QBox = new System.Windows.Forms.ListBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MasterDesignBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.Personengruppen.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveImages
            // 
            this.saveImages.Checked = true;
            this.saveImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveImages.Location = new System.Drawing.Point(18, 90);
            this.saveImages.Margin = new System.Windows.Forms.Padding(4);
            this.saveImages.Name = "saveImages";
            this.saveImages.Size = new System.Drawing.Size(193, 32);
            this.saveImages.TabIndex = 58;
            this.saveImages.Text = "Mit Grafiken speichern";
            // 
            // OverloadButton
            // 
            this.OverloadButton.BackColor = System.Drawing.Color.Transparent;
            this.OverloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OverloadButton.Location = new System.Drawing.Point(18, 50);
            this.OverloadButton.Margin = new System.Windows.Forms.Padding(4);
            this.OverloadButton.Name = "OverloadButton";
            this.OverloadButton.Size = new System.Drawing.Size(240, 32);
            this.OverloadButton.TabIndex = 57;
            this.OverloadButton.Text = "Beschriftungen";
            this.OverloadButton.UseVisualStyleBackColor = false;
            this.OverloadButton.Click += new System.EventHandler(this.OverloadButton_Click);
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.SystemColors.Window;
            this.resultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultBox.Location = new System.Drawing.Point(10, 10);
            this.resultBox.Margin = new System.Windows.Forms.Padding(4);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(481, 523);
            this.resultBox.TabIndex = 56;
            this.resultBox.Text = "";
            this.resultBox.WordWrap = false;
            this.resultBox.TextChanged += new System.EventHandler(this.resultBox_TextChanged);
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(8, 161);
            this.crossPanel.Margin = new System.Windows.Forms.Padding(4);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(250, 64);
            this.crossPanel.TabIndex = 55;
            this.crossPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.crossPanel_Paint);
            // 
            // PersonPanel
            // 
            this.PersonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPanel.Location = new System.Drawing.Point(4, 19);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(267, 182);
            this.PersonPanel.TabIndex = 54;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.Transparent;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(222, 70);
            this.QRemove.Margin = new System.Windows.Forms.Padding(4);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(39, 39);
            this.QRemove.TabIndex = 50;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new System.EventHandler(this.QRemove_Click);
            // 
            // QAdd
            // 
            this.QAdd.BackColor = System.Drawing.Color.Transparent;
            this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QAdd.Location = new System.Drawing.Point(222, 23);
            this.QAdd.Margin = new System.Windows.Forms.Padding(4);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new System.Drawing.Size(39, 39);
            this.QAdd.TabIndex = 49;
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
            this.QBox.TabIndex = 48;
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.White;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoButton.Image = Resources.shell32_dll_I00f6_0409;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(14, 8);
            this.GoButton.Margin = new System.Windows.Forms.Padding(4);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(275, 42);
            this.GoButton.TabIndex = 59;
            this.GoButton.Text = "Auswerten";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Personengruppen);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.GoButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(491, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 523);
            this.panel1.TabIndex = 60;
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.PersonPanel);
            this.Personengruppen.Location = new System.Drawing.Point(14, 297);
            this.Personengruppen.Margin = new System.Windows.Forms.Padding(4);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Padding = new System.Windows.Forms.Padding(4);
            this.Personengruppen.Size = new System.Drawing.Size(275, 205);
            this.Personengruppen.TabIndex = 58;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Personengruppen";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QBox);
            this.groupBox1.Controls.Add(this.crossPanel);
            this.groupBox1.Controls.Add(this.QRemove);
            this.groupBox1.Controls.Add(this.QAdd);
            this.groupBox1.Location = new System.Drawing.Point(14, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(275, 231);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daten";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 533);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel2.Size = new System.Drawing.Size(780, 157);
            this.panel2.TabIndex = 61;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MasterDesignBox);
            this.groupBox2.Controls.Add(this.saveImages);
            this.groupBox2.Controls.Add(this.OverloadButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(780, 147);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Einstellungen";
            // 
            // MasterDesignBox
            // 
            this.MasterDesignBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MasterDesignBox.Location = new System.Drawing.Point(126, -2);
            this.MasterDesignBox.Margin = new System.Windows.Forms.Padding(4);
            this.MasterDesignBox.Name = "MasterDesignBox";
            this.MasterDesignBox.Size = new System.Drawing.Size(304, 24);
            this.MasterDesignBox.TabIndex = 62;
            this.MasterDesignBox.SelectedIndexChanged += new System.EventHandler(this.MasterDesignBox_SelectedIndexChanged);
            // 
            // OutputControl_Gaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "OutputControl_Gaps";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(800, 700);
            this.Load += new System.EventHandler(this.OutputControl_Gaps_Load);
            this.panel1.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox saveImages;
        private System.Windows.Forms.Button OverloadButton;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Panel PersonPanel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Button QRemove;
        private System.Windows.Forms.Button QAdd;
        private System.Windows.Forms.ListBox QBox;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Personengruppen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox MasterDesignBox;
    }
}
