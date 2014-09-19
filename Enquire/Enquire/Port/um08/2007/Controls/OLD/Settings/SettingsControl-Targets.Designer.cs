namespace umfrage2._2007.Controls
{
    partial class SettingsControl_Targets
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
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboName = new System.Windows.Forms.TextBox();
            this.RemoveTarget = new System.Windows.Forms.Button();
            this.AddTarget = new System.Windows.Forms.Button();
            this.ChooseTargetPanel = new System.Windows.Forms.Panel();
            this.TargetList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(294, 327);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(216, 29);
            this.button4.TabIndex = 35;
            this.button4.Text = "Als Testbank markieren";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(291, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 23);
            this.label3.TabIndex = 34;
            this.label3.Text = "Bezeichnung der Kombination:";
            // 
            // ComboName
            // 
            this.ComboName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComboName.Location = new System.Drawing.Point(294, 175);
            this.ComboName.Name = "ComboName";
            this.ComboName.Size = new System.Drawing.Size(216, 24);
            this.ComboName.TabIndex = 33;
            this.ComboName.TextChanged += new System.EventHandler(this.ComboName_TextChanged);
            // 
            // RemoveTarget
            // 
            this.RemoveTarget.BackColor = System.Drawing.Color.White;
            this.RemoveTarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveTarget.Location = new System.Drawing.Point(294, 240);
            this.RemoveTarget.Name = "RemoveTarget";
            this.RemoveTarget.Size = new System.Drawing.Size(216, 29);
            this.RemoveTarget.TabIndex = 32;
            this.RemoveTarget.Text = "Kombination löschen";
            this.RemoveTarget.UseVisualStyleBackColor = false;
            this.RemoveTarget.Click += new System.EventHandler(this.RemoveTarget_Click);
            // 
            // AddTarget
            // 
            this.AddTarget.BackColor = System.Drawing.Color.White;
            this.AddTarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddTarget.Location = new System.Drawing.Point(294, 205);
            this.AddTarget.Name = "AddTarget";
            this.AddTarget.Size = new System.Drawing.Size(216, 29);
            this.AddTarget.TabIndex = 31;
            this.AddTarget.Text = "Kombination hinzufügen";
            this.AddTarget.UseVisualStyleBackColor = false;
            this.AddTarget.Click += new System.EventHandler(this.AddTarget_Click);
            // 
            // ChooseTargetPanel
            // 
            this.ChooseTargetPanel.Location = new System.Drawing.Point(13, 162);
            this.ChooseTargetPanel.Name = "ChooseTargetPanel";
            this.ChooseTargetPanel.Size = new System.Drawing.Size(220, 194);
            this.ChooseTargetPanel.TabIndex = 30;
            // 
            // TargetList
            // 
            this.TargetList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetList.HorizontalScrollbar = true;
            this.TargetList.ItemHeight = 16;
            this.TargetList.Location = new System.Drawing.Point(13, 28);
            this.TargetList.Name = "TargetList";
            this.TargetList.Size = new System.Drawing.Size(497, 98);
            this.TargetList.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Kombinationen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Ziele:";
            // 
            // SettingsControl_Targets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboName);
            this.Controls.Add(this.RemoveTarget);
            this.Controls.Add(this.AddTarget);
            this.Controls.Add(this.ChooseTargetPanel);
            this.Controls.Add(this.TargetList);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SettingsControl_Targets";
            this.Size = new System.Drawing.Size(908, 609);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ComboName;
        private System.Windows.Forms.Button RemoveTarget;
        private System.Windows.Forms.Button AddTarget;
        private System.Windows.Forms.Panel ChooseTargetPanel;
        private System.Windows.Forms.ListBox TargetList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
