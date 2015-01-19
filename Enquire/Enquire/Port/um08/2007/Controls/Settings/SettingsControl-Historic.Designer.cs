namespace umfrage2._2007.Controls
{
    partial class SettingsControl_Historic
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
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.HistoryList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(353, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(206, 29);
            this.button3.TabIndex = 33;
            this.button3.Text = "Auswertung bearbeiten";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(353, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 29);
            this.button1.TabIndex = 32;
            this.button1.Text = "Auswertung löschen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(353, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 29);
            this.button2.TabIndex = 31;
            this.button2.Text = "Auswertung Hinzufügen";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // HistoryList
            // 
            this.HistoryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HistoryList.HorizontalScrollbar = true;
            this.HistoryList.ItemHeight = 16;
            this.HistoryList.Location = new System.Drawing.Point(25, 18);
            this.HistoryList.Name = "HistoryList";
            this.HistoryList.Size = new System.Drawing.Size(320, 210);
            this.HistoryList.TabIndex = 30;
            this.HistoryList.DoubleClick += new System.EventHandler(this.HistoryList_DoubleClick);
            // 
            // Settings_Control_Historic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.HistoryList);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "Settings_Control_Historic";
            this.Size = new System.Drawing.Size(638, 422);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox HistoryList;
    }
}
