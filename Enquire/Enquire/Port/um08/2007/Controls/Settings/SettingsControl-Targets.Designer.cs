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
            this._btn_allesAuswaehlen = new System.Windows.Forms.Button();
            this._btn_allesAbwaehlen = new System.Windows.Forms.Button();
            this.TargetkombiList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.ComboName.Size = new System.Drawing.Size(216, 20);
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
            this.ChooseTargetPanel.Size = new System.Drawing.Size(220, 282);
            this.ChooseTargetPanel.TabIndex = 30;
            // 
            // TargetList
            // 
            this.TargetList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetList.HorizontalScrollbar = true;
            this.TargetList.Location = new System.Drawing.Point(13, 28);
            this.TargetList.Name = "TargetList";
            this.TargetList.Size = new System.Drawing.Size(497, 93);
            this.TargetList.TabIndex = 29;
            this.TargetList.SelectedIndexChanged += new System.EventHandler(this.TargetList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Kombinationen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Ziele:";
            // 
            // _btn_allesAuswaehlen
            // 
            this._btn_allesAuswaehlen.BackColor = System.Drawing.Color.White;
            this._btn_allesAuswaehlen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._btn_allesAuswaehlen.Location = new System.Drawing.Point(294, 380);
            this._btn_allesAuswaehlen.Name = "_btn_allesAuswaehlen";
            this._btn_allesAuswaehlen.Size = new System.Drawing.Size(216, 29);
            this._btn_allesAuswaehlen.TabIndex = 38;
            this._btn_allesAuswaehlen.Text = "alle auswählen";
            this._btn_allesAuswaehlen.UseVisualStyleBackColor = false;
            this._btn_allesAuswaehlen.Click += new System.EventHandler(this._btn_allesAuswaehlen_Click);
            // 
            // _btn_allesAbwaehlen
            // 
            this._btn_allesAbwaehlen.BackColor = System.Drawing.Color.White;
            this._btn_allesAbwaehlen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._btn_allesAbwaehlen.Location = new System.Drawing.Point(294, 415);
            this._btn_allesAbwaehlen.Name = "_btn_allesAbwaehlen";
            this._btn_allesAbwaehlen.Size = new System.Drawing.Size(216, 29);
            this._btn_allesAbwaehlen.TabIndex = 39;
            this._btn_allesAbwaehlen.Text = "alle abwählen";
            this._btn_allesAbwaehlen.UseVisualStyleBackColor = false;
            this._btn_allesAbwaehlen.Click += new System.EventHandler(this._btn_allesAbwaehlen_Click);
            // 
            // TargetkombiList
            // 
            this.TargetkombiList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetkombiList.HorizontalScrollbar = true;
            this.TargetkombiList.Location = new System.Drawing.Point(531, 28);
            this.TargetkombiList.Name = "TargetkombiList";
            this.TargetkombiList.Size = new System.Drawing.Size(258, 93);
            this.TargetkombiList.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(528, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Ziele von Kombinationen:";
            // 
            // SettingsControl_Targets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TargetkombiList);
            this.Controls.Add(this._btn_allesAbwaehlen);
            this.Controls.Add(this._btn_allesAuswaehlen);
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
        private System.Windows.Forms.Button _btn_allesAuswaehlen;
        private System.Windows.Forms.Button _btn_allesAbwaehlen;
        private System.Windows.Forms.ListBox TargetkombiList;
        private System.Windows.Forms.Label label4;
    }
}
