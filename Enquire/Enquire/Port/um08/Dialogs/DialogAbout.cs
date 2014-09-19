using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogAbout : DialogTemplate
	{
		private Label label1;
		private Label label2;
        private Label label3;
		private PictureBox pictureBox2;
        private Button EndButton;
		private IContainer components = null;

		public DialogAbout()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

			this.CancelButton = EndButton;
			label2.Text = "Version " + Application.ProductVersion;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DialogAbout));
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.pictureBox2 = new PictureBox();
            this.EndButton = new Button();
            ((ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(183, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Umfrageverwaltung";
            // 
            // label2
            // 
            this.label2.Location = new Point(1, 33);
            this.label2.Name = "label2";
            this.label2.Size = new Size(208, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version 4.10";
            // 
            // label3
            // 
            this.label3.Location = new Point(1, 57);
            this.label3.Name = "label3";
            this.label3.Size = new Size(174, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Samet Celik";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new Point(226, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(176, 158);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // EndButton
            // 
            this.EndButton.BackColor = Color.White;
            this.EndButton.FlatStyle = FlatStyle.Popup;
            this.EndButton.Image = Resources.shell32_dll_I00f0_0409;
            this.EndButton.ImageAlign = ContentAlignment.MiddleLeft;
            this.EndButton.Location = new Point(4, 130);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new Size(205, 37);
            this.EndButton.TabIndex = 19;
            this.EndButton.Text = "       Schliessen";
            this.EndButton.UseVisualStyleBackColor = false;
            this.EndButton.Click += new EventHandler(this.EndButton_Click);
            // 
            // DialogAbout
            // 
            this.AutoScaleBaseSize = new Size(6, 16);
            this.ClientSize = new Size(414, 188);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DialogAbout";
            this.Text = "Über Umfrageverwaltung";
            ((ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void EndButton_Click(object sender, EventArgs e)
        {
            Close();
        }
	}
}

