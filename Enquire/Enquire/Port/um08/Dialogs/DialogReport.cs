using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogReport : DialogTemplate
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		private Button EndButton;
		private Button OkButton;
		private IContainer components = null;
		private Label label2;
		private TextBox NameBox;

		private Report report;

		private string newName;

		public DialogReport(Report r)
		{
			report = r;

			InitializeComponent();

			this.CancelButton = EndButton;
			this.AcceptButton = OkButton;

			NameBox.Text = r.Name;
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
			ResourceManager resources = new ResourceManager(typeof(DialogReport));
			this.HeaderPanel = new Panel();
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.EndButton = new Button();
			this.OkButton = new Button();
			this.label2 = new Label();
			this.NameBox = new TextBox();
			this.HeaderPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// HeaderPanel
			// 
			this.HeaderPanel.BackColor = Color.White;
			this.HeaderPanel.Controls.Add(this.label1);
			this.HeaderPanel.Controls.Add(this.pictureBox1);
			this.HeaderPanel.Dock = DockStyle.Top;
			this.HeaderPanel.Location = new Point(0, 0);
			this.HeaderPanel.Name = "HeaderPanel";
			this.HeaderPanel.Size = new Size(618, 80);
			this.HeaderPanel.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.BackColor = Color.White;
			this.label1.Font = new Font("Arial", 18F);
			this.label1.ForeColor = Color.Gray;
			this.label1.Location = new Point(72, 16);
			this.label1.Name = "label1";
			this.label1.Size = new Size(552, 56);
			this.label1.TabIndex = 1;
			this.label1.Text = "Bericht";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(64, 64);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// EndButton
			// 
			this.EndButton.BackColor = Color.Gainsboro;
			this.EndButton.FlatStyle = FlatStyle.Popup;
			this.EndButton.Location = new Point(152, 144);
			this.EndButton.Name = "EndButton";
			this.EndButton.Size = new Size(216, 32);
			this.EndButton.TabIndex = 20;
			this.EndButton.Text = "Abbrechen";
			this.EndButton.Click += new EventHandler(this.EndButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.BackColor = Color.Gainsboro;
			this.OkButton.FlatStyle = FlatStyle.Popup;
			this.OkButton.Location = new Point(384, 144);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new Size(216, 32);
			this.OkButton.TabIndex = 21;
			this.OkButton.Text = "OK";
			this.OkButton.Click += new EventHandler(this.OkButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new Point(16, 96);
			this.label2.Name = "label2";
			this.label2.Size = new Size(96, 24);
			this.label2.TabIndex = 22;
			this.label2.Text = "Name:";
			this.label2.TextAlign = ContentAlignment.MiddleRight;
			// 
			// NameBox
			// 
			this.NameBox.BorderStyle = BorderStyle.FixedSingle;
			this.NameBox.Location = new Point(120, 96);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new Size(480, 23);
			this.NameBox.TabIndex = 23;
			this.NameBox.Text = "";
			this.NameBox.TextChanged += new EventHandler(this.NameBox_TextChanged);
			// 
			// DialogReport
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.Gainsboro;
			this.ClientSize = new Size(618, 190);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.EndButton);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "DialogReport";
			this.HeaderPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			newName = NameBox.Text;
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			report.Name = newName;
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void EndButton_Click(object sender, EventArgs e)
		{
		}
	}
}

