using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	public delegate void SizeEventHandler();

	/// <summary>
	/// Summary description for SizeControl.
	/// </summary>
	public class SizeControl : UserControl
	{
		private Label label1;
		private Label label2;
		private TextBox HeightBox;
		private TextBox WidthBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public event SizeEventHandler ChosenSizeChanged;

		private int startwid = 500;
		private int starthei = 500;

		public int ChosenHeight
		{
			get
			{
				return Int32.Parse(HeightBox.Text);
			}
		}

		public int ChosenWidth
		{
			get
			{
				return Int32.Parse(WidthBox.Text);
			}
		}

		public void SetDefaultSize(int wid, int hei)
		{
			starthei = hei;
			startwid = wid;
			SetSize(wid, hei);
		}

		public SizeControl(int wid, int hei)
		{
			starthei = hei;
			startwid = wid;

			InitializeComponent();

			SetSize(wid, hei);

			ChosenSizeChanged +=new SizeEventHandler(SizeControl_SizeChanged);

		}

		public SizeControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			ChosenSizeChanged +=new SizeEventHandler(SizeControl_SizeChanged);

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
            this.label1 = new Label();
            this.label2 = new Label();
            this.HeightBox = new TextBox();
            this.WidthBox = new TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new Point(-8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(56, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Höhe:";
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new Point(-8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new Size(56, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Breite:";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // HeightBox
            // 
            this.HeightBox.BorderStyle = BorderStyle.FixedSingle;
            this.HeightBox.Location = new Point(56, 0);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new Size(48, 22);
            this.HeightBox.TabIndex = 2;
            this.HeightBox.Text = "500";
            this.HeightBox.TextChanged += new EventHandler(this.HeightBox_TextChanged);
            // 
            // WidthBox
            // 
            this.WidthBox.BorderStyle = BorderStyle.FixedSingle;
            this.WidthBox.Location = new Point(56, 32);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new Size(48, 22);
            this.WidthBox.TabIndex = 3;
            this.WidthBox.Text = "500";
            this.WidthBox.TextChanged += new EventHandler(this.WidthBox_TextChanged);
            // 
            // SizeControl
            // 
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.WidthBox);
            this.Controls.Add(this.HeightBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SizeControl";
            this.Size = new Size(104, 56);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void SetSize(int x, int y)
		{
			HeightBox.Text = y.ToString();
			WidthBox.Text = x.ToString();
		}

		private void HeightBox_TextChanged(object sender, EventArgs e)
		{
			try {Int32.Parse(HeightBox.Text);ChosenSizeChanged();}
			catch {HeightBox.Text = starthei.ToString();}
		}

		private void WidthBox_TextChanged(object sender, EventArgs e)
		{
			try {Int32.Parse(WidthBox.Text);ChosenSizeChanged();}
			catch {WidthBox.Text = startwid.ToString();}
		}

		private void SizeControl_SizeChanged()
		{

		}
	}
}
