using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Web
{
	public class Admin : DialogTemplate
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		public AdminControl adminControl1;
		private Panel ControlPanel;
		private IContainer components = null;

		public Admin()
		{
			// Dieser Aufruf ist für den Windows Form-Designer erforderlich.
			InitializeComponent();

			// TODO: Initialisierungen nach dem Aufruf von InitializeComponent hinzufügen

			// 
			// adminControl1
			// 
			this.adminControl1 = new AdminControl(this);
			this.adminControl1.BackColor = Color.Gainsboro;
			this.adminControl1.Dock = DockStyle.Fill;
			this.adminControl1.Font = new Font("Arial", 8F);
			this.adminControl1.Location = new Point(0, 80);
			this.adminControl1.Name = "adminControl1";
			this.adminControl1.Size = new Size(738, 468);
			this.adminControl1.TabIndex = 4;

			ControlPanel.Controls.Add(this.adminControl1);
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
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

		#region Vom Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstьtzung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			ResourceManager resources = new ResourceManager(typeof(Admin));
			this.HeaderPanel = new Panel();
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.ControlPanel = new Panel();
			this.HeaderPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// HeaderPanel
			// 
			this.HeaderPanel.BackColor = Color.White;
			this.HeaderPanel.BorderStyle = BorderStyle.FixedSingle;
			this.HeaderPanel.Controls.Add(this.label1);
			this.HeaderPanel.Controls.Add(this.pictureBox1);
			this.HeaderPanel.Dock = DockStyle.Top;
			this.HeaderPanel.Location = new Point(0, 0);
			this.HeaderPanel.Name = "HeaderPanel";
			this.HeaderPanel.Size = new Size(738, 80);
			this.HeaderPanel.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.BackColor = Color.White;
			this.label1.Font = new Font("Arial", 18F);
			this.label1.ForeColor = Color.Gainsboro;
			this.label1.Location = new Point(72, 16);
			this.label1.Name = "label1";
			this.label1.Size = new Size(552, 56);
			this.label1.TabIndex = 1;
			this.label1.Text = "Internetumfrage";
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
			// ControlPanel
			// 
			this.ControlPanel.BackColor = Color.White;
			this.ControlPanel.Dock = DockStyle.Fill;
			this.ControlPanel.Location = new Point(0, 80);
			this.ControlPanel.Name = "ControlPanel";
			this.ControlPanel.Size = new Size(738, 468);
			this.ControlPanel.TabIndex = 4;
			// 
			// Admin
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.Gainsboro;
			this.ClientSize = new Size(738, 548);
			this.Controls.Add(this.ControlPanel);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "Admin";
			this.Text = "Administration";
			this.HeaderPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

