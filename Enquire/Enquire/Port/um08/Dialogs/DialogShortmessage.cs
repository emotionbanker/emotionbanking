using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogShortmessage : DialogTemplate
	{
		private Panel panel1;
		private Label label1;
		private IContainer components = null;

		public DialogShortmessage(string message)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			label1.Text = message;
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
			this.panel1 = new Panel();
			this.label1 = new Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(176, 40);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new Point(8, 10);
			this.label1.Name = "label1";
			this.label1.Size = new Size(168, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "speichere.... bitte warten";
			// 
			// DialogSaving
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.Gainsboro;
			this.ClientSize = new Size(176, 40);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = FormBorderStyle.None;
			this.Name = "DialogSaving";
			this.StartPosition = FormStartPosition.Manual;
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

