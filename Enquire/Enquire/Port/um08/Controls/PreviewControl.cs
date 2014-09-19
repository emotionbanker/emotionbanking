using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for PreviewControl.
	/// </summary>
	public class PreviewControl : UserControl
	{
		public PictureBox picBox;
        private Panel TopPanel;
		private Button EndButton;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public Image SmallPreview
		{
			get
			{
				return picBox.Image;
			}

			set
			{
				picBox.Image = value;
			}
		}

		public Bitmap BigPreview;

		public PreviewControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.TopPanel = new Panel();
            this.EndButton = new Button();
            this.picBox = new PictureBox();
            this.TopPanel.SuspendLayout();
            ((ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.EndButton);
            this.TopPanel.Controls.Add(this.picBox);
            this.TopPanel.Dock = DockStyle.Fill;
            this.TopPanel.Location = new Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new Size(464, 400);
            this.TopPanel.TabIndex = 1;
            // 
            // EndButton
            // 
            this.EndButton.BackColor = Color.White;
            this.EndButton.FlatStyle = FlatStyle.Popup;
            this.EndButton.Image = Resources.shell32_dll_I0017_0409;
            this.EndButton.Location = new Point(429, 0);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new Size(35, 40);
            this.EndButton.TabIndex = 25;
            this.EndButton.UseVisualStyleBackColor = false;
            this.EndButton.Click += new EventHandler(this.EndButton_Click);
            // 
            // picBox
            // 
            this.picBox.BackColor = Color.Transparent;
            this.picBox.BorderStyle = BorderStyle.FixedSingle;
            this.picBox.Dock = DockStyle.Fill;
            this.picBox.Location = new Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new Size(464, 400);
            this.picBox.SizeMode = PictureBoxSizeMode.AutoSize;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // PreviewControl
            // 
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.TopPanel);
            this.Name = "PreviewControl";
            this.Size = new Size(464, 400);
            this.SizeChanged += new EventHandler(this.PreviewControl_SizeChanged);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void EndButton_Click(object sender, EventArgs e)
		{
			ImagePreview ip = new ImagePreview(BigPreview);
			ip.ShowDialog();
		}

        private void PreviewControl_SizeChanged(object sender, EventArgs e)
        {
            EndButton.Location = new Point(this.Width - EndButton.Width - this.Padding.Right - this.Padding.Left, 0);
        }
	}
}
