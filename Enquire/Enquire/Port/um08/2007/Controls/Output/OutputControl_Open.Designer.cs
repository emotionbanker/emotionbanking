using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class OutputControl_Open
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
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.QAdd = new System.Windows.Forms.Button();
            this.QBox = new System.Windows.Forms.ListBox();
            this.QRemove = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Personengruppen = new System.Windows.Forms.GroupBox();
            this.styleBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.Personengruppen.SuspendLayout();
            this.SuspendLayout();
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(451, 266);
            this.crossPanel.Margin = new System.Windows.Forms.Padding(4);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(241, 64);
            this.crossPanel.TabIndex = 79;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPanel.Location = new System.Drawing.Point(4, 21);
            this.PersonPanel.Margin = new System.Windows.Forms.Padding(4);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(233, 180);
            this.PersonPanel.TabIndex = 78;
            // 
            // QAdd
            // 
            this.QAdd.BackColor = System.Drawing.Color.Transparent;
            this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QAdd.Location = new System.Drawing.Point(380, 6);
            this.QAdd.Margin = new System.Windows.Forms.Padding(4);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new System.Drawing.Size(39, 43);
            this.QAdd.TabIndex = 73;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            this.QAdd.Click += new System.EventHandler(this.QAdd_Click);
            // 
            // QBox
            // 
            this.QBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 16;
            this.QBox.Location = new System.Drawing.Point(4, 7);
            this.QBox.Margin = new System.Windows.Forms.Padding(4);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(369, 338);
            this.QBox.TabIndex = 72;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.Transparent;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(380, 57);
            this.QRemove.Margin = new System.Windows.Forms.Padding(4);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(39, 43);
            this.QRemove.TabIndex = 74;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new System.EventHandler(this.QRemove_Click);
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.White;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoButton.Image = Resources.shell32_dll_I00f6_0409;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(451, 7);
            this.GoButton.Margin = new System.Windows.Forms.Padding(4);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(241, 42);
            this.GoButton.TabIndex = 81;
            this.GoButton.Text = "Auswerten";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PersonPanel);
            this.groupBox1.Location = new System.Drawing.Point(451, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(241, 205);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personengruppen";
            // 
            // Personengruppen
            // 
            this.Personengruppen.Controls.Add(this.styleBox);
            this.Personengruppen.Location = new System.Drawing.Point(4, 362);
            this.Personengruppen.Margin = new System.Windows.Forms.Padding(4);
            this.Personengruppen.Name = "Personengruppen";
            this.Personengruppen.Padding = new System.Windows.Forms.Padding(4);
            this.Personengruppen.Size = new System.Drawing.Size(687, 69);
            this.Personengruppen.TabIndex = 84;
            this.Personengruppen.TabStop = false;
            this.Personengruppen.Text = "Einstellungen";
            // 
            // styleBox
            // 
            this.styleBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.styleBox.FormattingEnabled = true;
            this.styleBox.Location = new System.Drawing.Point(15, 22);
            this.styleBox.Name = "styleBox";
            this.styleBox.Size = new System.Drawing.Size(154, 24);
            this.styleBox.TabIndex = 0;
            this.styleBox.SelectedIndexChanged += new System.EventHandler(this.styleBox_SelectedIndexChanged);
            // 
            // OutputControl_Open
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Personengruppen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.crossPanel);
            this.Controls.Add(this.QAdd);
            this.Controls.Add(this.QBox);
            this.Controls.Add(this.QRemove);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OutputControl_Open";
            this.Padding = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.Size = new System.Drawing.Size(1009, 715);
            this.Load += new System.EventHandler(this.OutputControl_Open_Load);
            this.groupBox1.ResumeLayout(false);
            this.Personengruppen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel crossPanel;
        private System.Windows.Forms.Panel PersonPanel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button QAdd;
        private System.Windows.Forms.ListBox QBox;
        private System.Windows.Forms.Button QRemove;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.GroupBox Personengruppen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox styleBox;
    }
}
