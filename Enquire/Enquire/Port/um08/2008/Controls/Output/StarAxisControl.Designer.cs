namespace umfrage2._2008
{
    partial class StarAxisControl
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
            this.XButton = new System.Windows.Forms.Button();
            this.SetButton = new System.Windows.Forms.Button();
            this.UGSelectBox = new System.Windows.Forms.ComboBox();
            this.ColButton = new System.Windows.Forms.Button();
            this.AxisSelector = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.AxisSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // XButton
            // 
            this.XButton.Location = new System.Drawing.Point(323, 1);
            this.XButton.Name = "XButton";
            this.XButton.Size = new System.Drawing.Size(25, 23);
            this.XButton.TabIndex = 3;
            this.XButton.Text = "x";
            this.XButton.UseVisualStyleBackColor = true;
            this.XButton.Click += new System.EventHandler(this.XButton_Click);
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(3, 1);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(75, 23);
            this.SetButton.TabIndex = 2;
            this.SetButton.Text = "---";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // UGSelectBox
            // 
            this.UGSelectBox.FormattingEnabled = true;
            this.UGSelectBox.Location = new System.Drawing.Point(84, 2);
            this.UGSelectBox.Name = "UGSelectBox";
            this.UGSelectBox.Size = new System.Drawing.Size(153, 21);
            this.UGSelectBox.TabIndex = 4;
            this.UGSelectBox.SelectedIndexChanged += new System.EventHandler(this.UGSelectBox_SelectedIndexChanged);
            // 
            // ColButton
            // 
            this.ColButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColButton.Location = new System.Drawing.Point(242, 4);
            this.ColButton.Name = "ColButton";
            this.ColButton.Size = new System.Drawing.Size(30, 18);
            this.ColButton.TabIndex = 5;
            this.ColButton.UseVisualStyleBackColor = true;
            this.ColButton.Click += new System.EventHandler(this.ColButton_Click);
            // 
            // AxisSelector
            // 
            this.AxisSelector.Location = new System.Drawing.Point(278, 2);
            this.AxisSelector.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.AxisSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AxisSelector.Name = "AxisSelector";
            this.AxisSelector.Size = new System.Drawing.Size(39, 20);
            this.AxisSelector.TabIndex = 6;
            this.AxisSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AxisSelector.ValueChanged += new System.EventHandler(this.AxisSelector_ValueChanged_1);
            // 
            // StarAxisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AxisSelector);
            this.Controls.Add(this.ColButton);
            this.Controls.Add(this.UGSelectBox);
            this.Controls.Add(this.XButton);
            this.Controls.Add(this.SetButton);
            this.Name = "StarAxisControl";
            this.Size = new System.Drawing.Size(351, 24);
            ((System.ComponentModel.ISupportInitialize)(this.AxisSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button XButton;
        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.ComboBox UGSelectBox;
        private System.Windows.Forms.Button ColButton;
        private System.Windows.Forms.NumericUpDown AxisSelector;
    }
}
