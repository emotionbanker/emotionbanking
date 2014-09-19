using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	/// <summary>
	/// Summary description for DialogTemplate.
	/// </summary>
	public class DialogTemplate : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public DialogTemplate()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			// 
			// DialogTemplate
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.White;
			this.ClientSize = new Size(292, 268);
			this.Font = new Font("Arial", 8F);
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Name = "DialogTemplate";
			this.ShowInTaskbar = false;
			this.StartPosition = FormStartPosition.CenterParent;

		}
		#endregion
	}
}
