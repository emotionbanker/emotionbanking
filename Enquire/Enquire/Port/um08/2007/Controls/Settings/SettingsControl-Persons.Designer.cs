namespace umfrage2._2007.Controls
{
    partial class SettingsControl_Persons
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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ChoosePersonPanel = new System.Windows.Forms.Panel();
            this.PersonList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.White;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteButton.Location = new System.Drawing.Point(13, 180);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(216, 29);
            this.DeleteButton.TabIndex = 25;
            this.DeleteButton.Text = "Kombination löschen";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.White;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddButton.Location = new System.Drawing.Point(13, 145);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(216, 29);
            this.AddButton.TabIndex = 24;
            this.AddButton.Text = "Kombination hinzufügen";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ChoosePersonPanel
            // 
            this.ChoosePersonPanel.AutoScroll = true;
            this.ChoosePersonPanel.Location = new System.Drawing.Point(246, 145);
            this.ChoosePersonPanel.Name = "ChoosePersonPanel";
            this.ChoosePersonPanel.Size = new System.Drawing.Size(322, 116);
            this.ChoosePersonPanel.TabIndex = 23;
            // 
            // PersonList
            // 
            this.PersonList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PersonList.HorizontalScrollbar = true;
            this.PersonList.ItemHeight = 16;
            this.PersonList.Location = new System.Drawing.Point(13, 19);
            this.PersonList.Name = "PersonList";
            this.PersonList.Size = new System.Drawing.Size(555, 114);
            this.PersonList.TabIndex = 22;
            // 
            // SettingsControl_Persons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ChoosePersonPanel);
            this.Controls.Add(this.PersonList);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "SettingsControl_Persons";
            this.Size = new System.Drawing.Size(692, 473);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Panel ChoosePersonPanel;
        private System.Windows.Forms.ListBox PersonList;
    }
}
