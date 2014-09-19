using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class InformationBox : DialogTemplate
	{
		private Panel HeaderPanel;
		private Label HeadLabel;
		private PictureBox pictureBox1;
		private TextBox TextBox;
		private Button EndButton;
		private IContainer components = null;

		public string Header
		{
			get{return HeadLabel.Text;}
			set{HeadLabel.Text = value;}
		}

		public string Message
		{
			get{return TextBox.Text;}
			set{TextBox.Text = value;}
		}

		public InformationBox()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			this.CancelButton = EndButton;
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
			ResourceManager resources = new ResourceManager(typeof(InformationBox));
			this.HeaderPanel = new Panel();
			this.HeadLabel = new Label();
			this.pictureBox1 = new PictureBox();
			this.TextBox = new TextBox();
			this.EndButton = new Button();
			this.HeaderPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// HeaderPanel
			// 
			this.HeaderPanel.BackColor = Color.White;
			this.HeaderPanel.Controls.Add(this.HeadLabel);
			this.HeaderPanel.Controls.Add(this.pictureBox1);
			this.HeaderPanel.Dock = DockStyle.Top;
			this.HeaderPanel.Location = new Point(0, 0);
			this.HeaderPanel.Name = "HeaderPanel";
			this.HeaderPanel.Size = new Size(458, 56);
			this.HeaderPanel.TabIndex = 5;
			// 
			// HeadLabel
			// 
			this.HeadLabel.BackColor = Color.White;
			this.HeadLabel.Font = new Font("Arial", 18F);
			this.HeadLabel.ForeColor = Color.Gray;
			this.HeadLabel.Location = new Point(72, 8);
			this.HeadLabel.Name = "HeadLabel";
			this.HeadLabel.Size = new Size(552, 56);
			this.HeadLabel.TabIndex = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new Point(8, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(64, 64);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// TextBox
			// 
			this.TextBox.AcceptsReturn = true;
			this.TextBox.AcceptsTab = true;
			this.TextBox.BackColor = Color.Gainsboro;
			this.TextBox.BorderStyle = BorderStyle.None;
			this.TextBox.Location = new Point(8, 64);
			this.TextBox.Multiline = true;
			this.TextBox.Name = "TextBox";
			this.TextBox.ReadOnly = true;
			this.TextBox.Size = new Size(448, 56);
			this.TextBox.TabIndex = 6;
			this.TextBox.Text = "";
			this.TextBox.TextChanged += new EventHandler(this.TextBox_TextChanged);
			// 
			// EndButton
			// 
			this.EndButton.BackColor = Color.LightGray;
			this.EndButton.FlatStyle = FlatStyle.Popup;
			this.EndButton.Location = new Point(240, 128);
			this.EndButton.Name = "EndButton";
			this.EndButton.Size = new Size(216, 32);
			this.EndButton.TabIndex = 19;
			this.EndButton.Text = "Schliessen";
			// 
			// InformationBox
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.Gainsboro;
			this.ClientSize = new Size(458, 166);
			this.Controls.Add(this.EndButton);
			this.Controls.Add(this.TextBox);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "InformationBox";
			this.HeaderPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void TextBox_TextChanged(object sender, EventArgs e)
		{
			TextBox.Select(0,0);
		}
	}
}

