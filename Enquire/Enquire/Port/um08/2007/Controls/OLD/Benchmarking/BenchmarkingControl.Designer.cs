namespace umfrage2._2007.Controls
{
    partial class BenchmarkingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BenchmarkingControl));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.targetBox = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.personBox = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wordBox = new System.Windows.Forms.CheckBox();
            this.AllQuestionsBox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.QAdd = new System.Windows.Forms.Button();
            this.QBox = new System.Windows.Forms.ListBox();
            this.QRemove = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ColorButton = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.targetBox);
            this.groupBox3.Location = new System.Drawing.Point(15, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 272);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zielauswahl";
            // 
            // targetBox
            // 
            this.targetBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetBox.Location = new System.Drawing.Point(3, 20);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(162, 249);
            this.targetBox.TabIndex = 36;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.personBox);
            this.groupBox1.Location = new System.Drawing.Point(199, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 272);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personenauswahl";
            // 
            // personBox
            // 
            this.personBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personBox.Location = new System.Drawing.Point(3, 20);
            this.personBox.Name = "personBox";
            this.personBox.Size = new System.Drawing.Size(162, 249);
            this.personBox.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wordBox);
            this.groupBox2.Controls.Add(this.AllQuestionsBox);
            this.groupBox2.Controls.Add(this.SaveButton);
            this.groupBox2.Controls.Add(this.QAdd);
            this.groupBox2.Controls.Add(this.QBox);
            this.groupBox2.Controls.Add(this.QRemove);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ColorButton);
            this.groupBox2.Location = new System.Drawing.Point(375, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 272);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Benchmarking";
            // 
            // wordBox
            // 
            this.wordBox.Image = ((System.Drawing.Image)(resources.GetObject("wordBox.Image")));
            this.wordBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.wordBox.Location = new System.Drawing.Point(120, 144);
            this.wordBox.Name = "wordBox";
            this.wordBox.Size = new System.Drawing.Size(48, 24);
            this.wordBox.TabIndex = 39;
            this.wordBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AllQuestionsBox
            // 
            this.AllQuestionsBox.Location = new System.Drawing.Point(8, 144);
            this.AllQuestionsBox.Name = "AllQuestionsBox";
            this.AllQuestionsBox.Size = new System.Drawing.Size(96, 24);
            this.AllQuestionsBox.TabIndex = 38;
            this.AllQuestionsBox.Text = "Alle Fragen";
            this.AllQuestionsBox.CheckedChanged += new System.EventHandler(this.AllQuestionsBox_CheckedChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LightGray;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Location = new System.Drawing.Point(8, 224);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(192, 32);
            this.SaveButton.TabIndex = 37;
            this.SaveButton.Text = "Speichern...";
            this.SaveButton.UseVisualStyleBackColor = false;
            // 
            // QAdd
            // 
            this.QAdd.BackColor = System.Drawing.Color.LightGray;
            this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QAdd.Location = new System.Drawing.Point(168, 56);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new System.Drawing.Size(32, 32);
            this.QAdd.TabIndex = 33;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            // 
            // QBox
            // 
            this.QBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 16;
            this.QBox.Location = new System.Drawing.Point(8, 24);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(144, 114);
            this.QBox.TabIndex = 32;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.LightGray;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(168, 96);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(32, 32);
            this.QRemove.TabIndex = 34;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(160, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 32);
            this.label6.TabIndex = 35;
            this.label6.Text = "Fragen";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = System.Drawing.Color.LightGray;
            this.ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColorButton.Location = new System.Drawing.Point(8, 184);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(192, 32);
            this.ColorButton.TabIndex = 5;
            this.ColorButton.Text = "Farben...";
            this.ColorButton.UseVisualStyleBackColor = false;
            // 
            // BenchmarkingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "BenchmarkingControl";
            this.Size = new System.Drawing.Size(753, 545);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel targetBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel personBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox wordBox;
        private System.Windows.Forms.CheckBox AllQuestionsBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button QAdd;
        private System.Windows.Forms.ListBox QBox;
        private System.Windows.Forms.Button QRemove;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ColorButton;
    }
}
