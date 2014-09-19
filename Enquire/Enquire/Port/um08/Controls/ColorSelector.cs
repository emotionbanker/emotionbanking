using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for ColorSelector.
	/// </summary>
	public class ColorSelector : UserControl
	{
		private Panel panel;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Evaluation eval;
		private string[] TextList;

		public event ColorChangedEvent ColorChanged;

		public ColorSelector(Evaluation eval, string[]TextList)
		{
			this.eval = eval;
			this.TextList = TextList;

			InitializeComponent();

			Color b1 = Color.Gainsboro;
			Color b2 = Color.LightGray;
			Color b = b2;

			int loc = 0;
			foreach (string text in TextList)
			{
				if (b == b2) b = b1;
				else b = b2;

				ChooseColorControl ccc = new ChooseColorControl(eval, text);
				ccc.Location = new Point(0, loc);
				ccc.BackColor = b;
				panel.Controls.Add(ccc);
				ccc.ColorChanged+=new ColorChangedEvent(ccc_ColorChanged);

				loc += ccc.Height;
			}

			this.ColorChanged+=new ColorChangedEvent(ColorSelector_ColorChanged);
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
			this.panel = new Panel();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.AutoScroll = true;
			this.panel.BorderStyle = BorderStyle.FixedSingle;
			this.panel.Dock = DockStyle.Fill;
			this.panel.Location = new Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new Size(416, 256);
			this.panel.TabIndex = 0;
			// 
			// ColorSelector
			// 
			this.BackColor = Color.Gainsboro;
			this.Controls.Add(this.panel);
			this.Font = new Font("Arial", 8F);
			this.Name = "ColorSelector";
			this.Size = new Size(416, 256);
			this.ResumeLayout(false);

		}
		#endregion

		private void ccc_ColorChanged()
		{
			ColorChanged();
		}

		private void ColorSelector_ColorChanged()
		{

		}
	}
}
