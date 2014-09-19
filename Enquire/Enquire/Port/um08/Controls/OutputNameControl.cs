using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for OutputNameControl.
	/// </summary>
	public class OutputNameControl : UserControl
	{
        private TextBox NameBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Output.Output output;
        private ListViewItem lwi;

        public OutputNameControl(Output.Output output)
        {
            Set(output, new ListViewItem());
        }

		public OutputNameControl(Output.Output output, ListViewItem lwi)
		{
			Set(output, lwi);
		}

        private void Set(Output.Output output, ListViewItem lwi)
        {
            this.output = output;
            this.lwi = lwi;

            InitializeComponent();

            this.NameBox.Text = output.Name;

            this.NameBox.TextChanged += new EventHandler(NameBox_TextChanged);
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
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.BorderStyle = BorderStyle.FixedSingle;
            this.NameBox.Dock = DockStyle.Fill;
            this.NameBox.Location = new Point(0, 0);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new Size(603, 22);
            this.NameBox.TabIndex = 5;
            // 
            // OutputNameControl
            // 
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.NameBox);
            this.Name = "OutputNameControl";
            this.Size = new Size(603, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			output.Name = NameBox.Text;
            lwi.Text = output.Name;
		}

		public void SetName(string name)
		{
			NameBox.Text = name;
		}
	}
}
