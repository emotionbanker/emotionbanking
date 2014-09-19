using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_Star
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
            this.crossPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.db2 = new System.Windows.Forms.RadioButton();
            this.db1 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DataPanel = new System.Windows.Forms.Panel();
            this.NewElemButton = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.previewBox = new PreviewControl();
            this.sizeControl = new SizeControl();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(8, 19);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(192, 52);
            this.crossPanel.TabIndex = 35;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NewElemButton);
            this.groupBox2.Controls.Add(this.DataPanel);
            this.groupBox2.Controls.Add(this.db2);
            this.groupBox2.Controls.Add(this.db1);
            this.groupBox2.Controls.Add(this.sizeControl);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 128);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Design";
            // 
            // db2
            // 
            this.db2.AutoSize = true;
            this.db2.Location = new System.Drawing.Point(19, 51);
            this.db2.Name = "db2";
            this.db2.Size = new System.Drawing.Size(70, 17);
            this.db2.TabIndex = 38;
            this.db2.TabStop = true;
            this.db2.Text = "Vorlage 2";
            this.db2.UseVisualStyleBackColor = true;
            this.db2.CheckedChanged += new System.EventHandler(this.db2_CheckedChanged);
            // 
            // db1
            // 
            this.db1.AutoSize = true;
            this.db1.Location = new System.Drawing.Point(19, 28);
            this.db1.Name = "db1";
            this.db1.Size = new System.Drawing.Size(70, 17);
            this.db1.TabIndex = 37;
            this.db1.TabStop = true;
            this.db1.Text = "Vorlage 1";
            this.db1.UseVisualStyleBackColor = true;
            this.db1.CheckedChanged += new System.EventHandler(this.db1_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.GoButton);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(431, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(219, 419);
            this.panel3.TabIndex = 48;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crossPanel);
            this.groupBox1.Location = new System.Drawing.Point(6, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 88);
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
            // DataPanel
            // 
            this.DataPanel.AutoScroll = true;
            this.DataPanel.Location = new System.Drawing.Point(107, 19);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(355, 90);
            this.DataPanel.TabIndex = 36;
            this.DataPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DataPanel_Paint);
            // 
            // NewElemButton
            // 
            this.NewElemButton.Location = new System.Drawing.Point(468, 86);
            this.NewElemButton.Name = "NewElemButton";
            this.NewElemButton.Size = new System.Drawing.Size(94, 23);
            this.NewElemButton.TabIndex = 39;
            this.NewElemButton.Text = "Neues Element";
            this.NewElemButton.UseVisualStyleBackColor = true;
            this.NewElemButton.Click += new System.EventHandler(this.NewElemButton_Click);
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
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Transparent;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(8, 8);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(423, 419);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 27;
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Transparent;
            this.sizeControl.Location = new System.Drawing.Point(541, 19);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(112, 58);
            this.sizeControl.TabIndex = 36;
            // 
            // OutputControl_Star
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "OutputControl_Star";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(658, 571);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PreviewControl previewBox;
        private SizeControl sizeControl;
        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton db2;
        private System.Windows.Forms.RadioButton db1;
        private System.Windows.Forms.Panel DataPanel;
        private System.Windows.Forms.Button NewElemButton;
    }
}
