using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	public delegate void SlideEventHandler();

	/// <summary>
	/// Summary description for FloatSlideControl.
	/// </summary>
	public class FloatSlideControl : UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public Color SliderColor;

		private float val;

		public event SlideEventHandler Slided;

		public float Value
		{
			get 
			{
				//if (Inverted)
				//	return 1-val;
				//else
					return val;
			}
			set 
			{
				if (Inverted)
					val = 1-value;
				else
					val = value;

				Slided();
				Refresh();
			}
		}

		private bool MouseIsDown;

		public bool Border;

		public bool Inverted;

		public float MinVal;
		public float MaxVal;

		private FloatSlideControl slave;

		public FloatSlideControl()
		{
			InitializeComponent();
			Slided+=new SlideEventHandler(FloatSlideControl_Slided);
			SliderColor = Color.Black;
			val = 0f;
			Border = true;
			MouseIsDown = false;
			Inverted = false;
			MinVal = 0;
			MaxVal = 1;

			this.SetStyle(ControlStyles.DoubleBuffer,true);
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
			// 
			// FloatSlideControl
			// 
			this.Cursor = Cursors.VSplit;
			this.Font = new Font("Arial", 8F);
			this.Name = "FloatSlideControl";
			this.Size = new Size(200, 32);
			this.MouseUp += new MouseEventHandler(this.FloatSlideControl_MouseUp);
			this.Paint += new PaintEventHandler(this.FloatSlideControl_Paint);
			this.MouseMove += new MouseEventHandler(this.FloatSlideControl_MouseMove);
			this.MouseLeave += new EventHandler(this.FloatSlideControl_MouseLeave);
			this.MouseDown += new MouseEventHandler(this.FloatSlideControl_MouseDown);

		}
		#endregion

		public void Slave(FloatSlideControl slave)
		{
			this.slave = slave;
			Slided();
		}

		private void FloatSlideControl_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.Clear(this.BackColor);

			SolidBrush b = new SolidBrush(SliderColor);

			float wid = ((float)this.Width) * Value;

			if (Inverted)
			{
				if (wid > 0)
					g.FillRectangle(b, Width-wid, 0, Width, Height);
			}
			else
			{
				if (wid > 0)
					g.FillRectangle(b, 0, 0, wid, this.Height);
			}

			if (Border)
				g.DrawRectangle(new Pen(Color.Black), 0, 0, Width, Height);
		}

		private void UpdateVal(int X)
		{
			if (X <= Width && X >= 0)
			{
				float pos = X / ((float)Width);
				Value = pos;
				if (Value < MinVal)
					Value = MinVal;
				if (Value > MaxVal)
					Value = MaxVal;
				
				Refresh();
				//Slided();
				//Console.WriteLine("val=" + Value);
			}
		}
		private void FloatSlideControl_MouseDown(object sender, MouseEventArgs e)
		{
			UpdateVal(e.X);
			MouseIsDown = true;
		}

		private void FloatSlideControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (MouseIsDown)
			{
				UpdateVal(e.X);
			}
		}

		private void FloatSlideControl_MouseLeave(object sender, EventArgs e)
		{
			MouseIsDown = false;
		}

		private void FloatSlideControl_MouseUp(object sender, MouseEventArgs e)
		{
			MouseIsDown = false;
		}

		private void FloatSlideControl_Slided()
		{
			if (slave != null && slave.Inverted)
			{
				if (slave.Value > (1-Value))
				{
					slave.Value = Value;
				}
			}
			if (slave != null && !slave.Inverted)
			{
				if (slave.Value > (1-Value))
				{
					slave.Value = (1-Value);
				}
			}
		}
	}
}
