using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	/// <summary>
	/// Summary description for ImagePreview.
	/// </summary>
	public class ImagePreview : Form
	{
		private PictureBox pictureBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public ImagePreview(Image image)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			this.Width = image.Width + 50;
			this.Height = image.Height + 50;

			pictureBox.Image = image;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.pictureBox = new PictureBox();
            ((ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox.Dock = DockStyle.Fill;
            this.pictureBox.Location = new Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new Size(482, 302);
            this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // ImagePreview
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.Gainsboro;
            this.ClientSize = new Size(482, 302);
            this.Controls.Add(this.pictureBox);
            this.Font = new Font("Arial", 8F);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "ImagePreview";
            this.ShowInTaskbar = false;
            this.Text = "Detailvorschau";
            ((ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}
