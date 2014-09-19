namespace umfrage2._2007.Controls
{
    partial class SettingsControl_DB
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
            this.PrefixBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.DatabaseBox = new System.Windows.Forms.TextBox();
            this.ServerBox = new System.Windows.Forms.TextBox();
            this.SelectVirtualButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrefixBox
            // 
            this.PrefixBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrefixBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PrefixBox.Location = new System.Drawing.Point(164, 149);
            this.PrefixBox.Name = "PrefixBox";
            this.PrefixBox.Size = new System.Drawing.Size(296, 21);
            this.PrefixBox.TabIndex = 25;
            this.PrefixBox.VisibleChanged += new System.EventHandler(this.PrefixBox_SelectedIndexChanged);
            this.PrefixBox.SelectedIndexChanged += new System.EventHandler(this.PrefixBox_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 26);
            this.label6.TabIndex = 24;
            this.label6.Text = "Virtuelle Datenbank:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PasswordBox
            // 
            this.PasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordBox.Location = new System.Drawing.Point(164, 117);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(294, 20);
            this.PasswordBox.TabIndex = 23;
            this.PasswordBox.VisibleChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // UserBox
            // 
            this.UserBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserBox.Location = new System.Drawing.Point(164, 87);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(294, 20);
            this.UserBox.TabIndex = 22;
            this.UserBox.VisibleChanged += new System.EventHandler(this.UserBox_TextChanged);
            this.UserBox.TextChanged += new System.EventHandler(this.UserBox_TextChanged_1);
            // 
            // DatabaseBox
            // 
            this.DatabaseBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DatabaseBox.Location = new System.Drawing.Point(164, 58);
            this.DatabaseBox.Name = "DatabaseBox";
            this.DatabaseBox.Size = new System.Drawing.Size(294, 20);
            this.DatabaseBox.TabIndex = 21;
            this.DatabaseBox.TextChanged += new System.EventHandler(this.DatabaseBox_TextChanged);
            // 
            // ServerBox
            // 
            this.ServerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerBox.Location = new System.Drawing.Point(164, 29);
            this.ServerBox.Name = "ServerBox";
            this.ServerBox.Size = new System.Drawing.Size(294, 20);
            this.ServerBox.TabIndex = 20;
            this.ServerBox.TextChanged += new System.EventHandler(this.ServerBox_TextChanged);
            // 
            // SelectVirtualButton
            // 
            this.SelectVirtualButton.BackColor = System.Drawing.Color.White;
            this.SelectVirtualButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SelectVirtualButton.Location = new System.Drawing.Point(164, 180);
            this.SelectVirtualButton.Name = "SelectVirtualButton";
            this.SelectVirtualButton.Size = new System.Drawing.Size(294, 28);
            this.SelectVirtualButton.TabIndex = 19;
            this.SelectVirtualButton.Text = "Nach virtuellen Datenbanken suchen....";
            this.SelectVirtualButton.UseVisualStyleBackColor = false;
            this.SelectVirtualButton.Click += new System.EventHandler(this.SelectVirtualButton_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "Passwort:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "Benutzername:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 26);
            this.label2.TabIndex = 16;
            this.label2.Text = "Datenbank:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 26);
            this.label5.TabIndex = 15;
            this.label5.Text = "Server:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SettingsControl_DB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PrefixBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.DatabaseBox);
            this.Controls.Add(this.ServerBox);
            this.Controls.Add(this.SelectVirtualButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SettingsControl_DB";
            this.Size = new System.Drawing.Size(628, 383);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PrefixBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox UserBox;
        private System.Windows.Forms.TextBox DatabaseBox;
        private System.Windows.Forms.TextBox ServerBox;
        private System.Windows.Forms.Button SelectVirtualButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}
