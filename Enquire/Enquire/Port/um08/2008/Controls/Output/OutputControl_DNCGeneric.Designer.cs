using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_DNCGeneric
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
            this.NewElemButton = new System.Windows.Forms.Button();
            this.DataPanel = new System.Windows.Forms.Panel();
            this.CrossSel = new System.Windows.Forms.RadioButton();
            this.UGSel = new System.Windows.Forms.RadioButton();
            this.ChartTypeSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.GoButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.previewBox = new PreviewControl();
            this.sizeControl = new SizeControl();
            this.DesignButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Personengruppen.SuspendLayout();
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
            this.groupBox2.Controls.Add(this.DesignButton);
            this.groupBox2.Controls.Add(this.NewElemButton);
            this.groupBox2.Controls.Add(this.DataPanel);
            this.groupBox2.Controls.Add(this.CrossSel);
            this.groupBox2.Controls.Add(this.UGSel);
            this.groupBox2.Controls.Add(this.ChartTypeSelect);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 128);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Design";
            // 
            // NewElemButton
            // 
            this.NewElemButton.Location = new System.Drawing.Point(538, 83);
            this.NewElemButton.Name = "NewElemButton";
            this.NewElemButton.Size = new System.Drawing.Size(94, 23);
            this.NewElemButton.TabIndex = 42;
            this.NewElemButton.Text = "Neues Element";
            this.NewElemButton.UseVisualStyleBackColor = true;
            this.NewElemButton.Click += new System.EventHandler(this.NewElemButton_Click_1);
            // 
            // DataPanel
            // 
            this.DataPanel.AutoScroll = true;
            this.DataPanel.Location = new System.Drawing.Point(204, 16);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(328, 90);
            this.DataPanel.TabIndex = 41;
            // 
            // CrossSel
            // 
            this.CrossSel.AutoSize = true;
            this.CrossSel.Location = new System.Drawing.Point(19, 60);
            this.CrossSel.Name = "CrossSel";
            this.CrossSel.Size = new System.Drawing.Size(97, 17);
            this.CrossSel.TabIndex = 40;
            this.CrossSel.TabStop = true;
            this.CrossSel.Text = "nach Kreuzung";
            this.CrossSel.UseVisualStyleBackColor = true;
            // 
            // UGSel
            // 
            this.UGSel.AutoSize = true;
            this.UGSel.Location = new System.Drawing.Point(19, 43);
            this.UGSel.Name = "UGSel";
            this.UGSel.Size = new System.Drawing.Size(136, 17);
            this.UGSel.TabIndex = 39;
            this.UGSel.TabStop = true;
            this.UGSel.Text = "nach Personengruppen";
            this.UGSel.UseVisualStyleBackColor = true;
            this.UGSel.CheckedChanged += new System.EventHandler(this.UGSel_CheckedChanged);
            // 
            // ChartTypeSelect
            // 
            this.ChartTypeSelect.FormattingEnabled = true;
            this.ChartTypeSelect.Location = new System.Drawing.Point(50, 16);
            this.ChartTypeSelect.Name = "ChartTypeSelect";
            this.ChartTypeSelect.Size = new System.Drawing.Size(148, 21);
            this.ChartTypeSelect.TabIndex = 38;
            this.ChartTypeSelect.SelectedIndexChanged += new System.EventHandler(this.ChartTypeSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Typ:";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.Personengruppen);
            this.panel3.Controls.Add(this.GoButton);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.sizeControl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(431, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(219, 419);
            this.panel3.TabIndex = 48;
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.PersonPanel);
            this.Personengruppen.Location = new System.Drawing.Point(6, 141);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Size = new System.Drawing.Size(206, 193);
            this.Personengruppen.TabIndex = 59;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Personengruppen";
            // 
            // PersonPanel
            // 
            this.PersonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPanel.Location = new System.Drawing.Point(3, 16);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(200, 174);
            this.PersonPanel.TabIndex = 34;
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
            this.sizeControl.Location = new System.Drawing.Point(9, 340);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(112, 58);
            this.sizeControl.TabIndex = 36;
            // 
            // DesignButton
            // 
            this.DesignButton.BackColor = System.Drawing.Color.White;
            this.DesignButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DesignButton.Image = Resources.shell32_dll_I010e_0409;
            this.DesignButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DesignButton.Location = new System.Drawing.Point(19, 83);
            this.DesignButton.Name = "DesignButton";
            this.DesignButton.Size = new System.Drawing.Size(169, 31);
            this.DesignButton.TabIndex = 59;
            this.DesignButton.Text = "     Einstellungen...";
            this.DesignButton.UseVisualStyleBackColor = true;
            this.DesignButton.Click += new System.EventHandler(this.DesignButton_Click);
            // 
            // OutputControl_DNCGeneric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "OutputControl_DNCGeneric";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(658, 571);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ChartTypeSelect;
        private System.Windows.Forms.GroupBox Personengruppen;
        private System.Windows.Forms.Panel PersonPanel;
        private System.Windows.Forms.RadioButton CrossSel;
        private System.Windows.Forms.RadioButton UGSel;
        private System.Windows.Forms.Button NewElemButton;
        private System.Windows.Forms.Panel DataPanel;
        private System.Windows.Forms.Button DesignButton;
    }
}
