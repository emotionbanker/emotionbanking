using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for OutputNameControl.
	/// </summary>
	public class ColumnNameControl : UserControl
	{
		private TextBox NameBox;
		private Label label3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Column column;

		public ColumnNameControl(Column column)
		{
			this.column = column;

			InitializeComponent();
			
			this.NameBox.Text = column.Name;

			this.NameBox.TextChanged+=new EventHandler(NameBox_TextChanged);
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
			this.NameBox = new TextBox();
			this.label3 = new Label();
			this.SuspendLayout();
			// 
			// NameBox
			// 
			this.NameBox.BorderStyle = BorderStyle.FixedSingle;
			this.NameBox.Location = new Point(0, 24);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new Size(216, 22);
			this.NameBox.TabIndex = 5;
			this.NameBox.Text = "";
			this.NameBox.TextAlign = HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new Point(8, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(208, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "Name dieser Säule:";
			this.label3.TextAlign = ContentAlignment.TopRight;
			// 
			// OutputNameControl
			// 
			this.BackColor = Color.White;
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.label3);
			this.Name = "OutputNameControl";
			this.Size = new Size(216, 48);
			this.ResumeLayout(false);

		}
		#endregion

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			column.Name = NameBox.Text;
		}

		public void SetName(string name)
		{
			NameBox.Text = name;
		}
	}
}
