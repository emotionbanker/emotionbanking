using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_Rank
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
            this.GoButton = new System.Windows.Forms.Button();
            this.QRemove = new System.Windows.Forms.Button();
            this.QAdd = new System.Windows.Forms.Button();
            this.QBox = new System.Windows.Forms.ListBox();
            this.FlopsBox = new System.Windows.Forms.CheckBox();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Personengruppen.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.White;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoButton.Image = Resources.shell32_dll_I00f6_0409;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(4, 4);
            this.GoButton.Margin = new System.Windows.Forms.Padding(4);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(275, 42);
            this.GoButton.TabIndex = 29;
            this.GoButton.Text = "Auswerten";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.Transparent;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(222, 70);
            this.QRemove.Margin = new System.Windows.Forms.Padding(4);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(39, 39);
            this.QRemove.TabIndex = 65;
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
            this.QAdd.TabIndex = 64;
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
            this.QBox.TabIndex = 63;
            // 
            // FlopsBox
            // 
            this.FlopsBox.Location = new System.Drawing.Point(18, 23);
            this.FlopsBox.Margin = new System.Windows.Forms.Padding(4);
            this.FlopsBox.Name = "FlopsBox";
            this.FlopsBox.Size = new System.Drawing.Size(195, 23);
            this.FlopsBox.TabIndex = 72;
            this.FlopsBox.Text = "Aufsteigend geordnet";
            this.FlopsBox.CheckedChanged += new System.EventHandler(this.FlopsBox_CheckedChanged);
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.SystemColors.Window;
            this.resultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultBox.Location = new System.Drawing.Point(10, 10);
            this.resultBox.Margin = new System.Windows.Forms.Padding(4);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(490, 606);
            this.resultBox.TabIndex = 71;
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
            this.crossPanel.TabIndex = 70;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPanel.Location = new System.Drawing.Point(4, 19);
            this.PersonPanel.Margin = new System.Windows.Forms.Padding(4);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(267, 182);
            this.PersonPanel.TabIndex = 69;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.GoButton);
            this.panel1.Controls.Add(this.Personengruppen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(500, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 606);
            this.panel1.TabIndex = 73;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QBox);
            this.groupBox1.Controls.Add(this.QRemove);
            this.groupBox1.Controls.Add(this.crossPanel);
            this.groupBox1.Controls.Add(this.QAdd);
            this.groupBox1.Location = new System.Drawing.Point(4, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(275, 233);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daten";
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.PersonPanel);
            this.Personengruppen.Location = new System.Drawing.Point(4, 295);
            this.Personengruppen.Margin = new System.Windows.Forms.Padding(4);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Padding = new System.Windows.Forms.Padding(4);
            this.Personengruppen.Size = new System.Drawing.Size(275, 205);
            this.Personengruppen.TabIndex = 75;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Personengruppen";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 616);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 74);
            this.panel2.TabIndex = 74;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FlopsBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(780, 74);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Einstellungen";
            // 
            // OutputControl_Rank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OutputControl_Rank";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(800, 700);
            this.Load += new System.EventHandler(this.OutputControl_Rank_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Button QRemove;
        private System.Windows.Forms.Button QAdd;
        private System.Windows.Forms.ListBox QBox;
        private System.Windows.Forms.CheckBox FlopsBox;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Panel PersonPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox Personengruppen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
