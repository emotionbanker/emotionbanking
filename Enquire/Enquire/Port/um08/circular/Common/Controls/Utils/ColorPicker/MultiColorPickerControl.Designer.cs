namespace Compucare.Enquire.Common.Controls.Utils.ColorPickerUtil
{
    partial class MultiColorPickerControl
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
            this._scrollPane = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _scrollPane
            // 
            this._scrollPane.AutoScroll = true;
            this._scrollPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scrollPane.Location = new System.Drawing.Point(0, 0);
            this._scrollPane.Name = "_scrollPane";
            this._scrollPane.Size = new System.Drawing.Size(220, 115);
            this._scrollPane.TabIndex = 0;
            // 
            // MultiColorPickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._scrollPane);
            this.Name = "MultiColorPickerControl";
            this.Size = new System.Drawing.Size(220, 115);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel _scrollPane;

    }
}
