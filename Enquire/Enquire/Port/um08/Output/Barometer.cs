using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Averages.
	/// </summary>
	/// 

	[Serializable]
	public class Barometer : Output
	{
		public Question ArrowBig;
		public Question ArrowSmall;

		public Question SmallLeft;
		public Question SmallRight;

		public PersonSetting PArrowBig;
		public PersonSetting PArrowSmall;

		public PersonSetting PSmallLeft;
		public PersonSetting PSmallRight;

		public string Heading;

		public bool Red = false;

		public Bitmap Raw
		{
			get
			{
				return new Bitmap(SystemTools.GetAppPath() + "barometer_raw.png");
			}
		}

		public Bitmap RawRed
		{
			get
			{
				return new Bitmap(SystemTools.GetAppPath() + "barometer_raw_red.png");
			}
		}

        public Barometer(Evaluation eval)
        {
            this.eval = eval;
			Heading = string.Empty;

			this.width = 800;
			this.height = 665;
		}

        public override void LoadGlobalQ()
        {
            LoadQ(ArrowBig);
            LoadQ(ArrowSmall);
            LoadQ(SmallLeft);
            LoadQ(SmallRight);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQ(td, ArrowBig);
            LoadTQ(td, ArrowSmall);
            LoadTQ(td, SmallLeft);
            LoadTQ(td, SmallRight);
        }

		/// <summary>
		/// serialization functions
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info,ctxt);

            Question.SetMultipart(ArrowBig, Multipart);
            Question.SetMultipart(ArrowSmall, Multipart);
            Question.SetMultipart(SmallLeft, Multipart);
            Question.SetMultipart(SmallRight, Multipart);

			info.AddValue("ArrowBig", this.ArrowBig);
			info.AddValue("ArrowSmall", this.ArrowSmall);
			info.AddValue("SmallLeft", this.SmallLeft);
			info.AddValue("SmallRight", this.SmallRight);
			info.AddValue("Heading", this.Heading);
			info.AddValue("Red", this.Red);

			info.AddValue("PArrowBig", this.PArrowBig);
			info.AddValue("PArrowSmall", this.PArrowSmall);
			info.AddValue("PSmallLeft", this.PSmallLeft);
			info.AddValue("PSmallRight", this.PSmallRight);
		}

		public Barometer(SerializationInfo info, StreamingContext ctxt)
		{
			ReadSerData(info, ctxt);
			this.ArrowBig = (Question)info.GetValue("ArrowBig", typeof(Question));
			this.ArrowSmall = (Question)info.GetValue("ArrowSmall", typeof(Question));
			this.SmallLeft = (Question)info.GetValue("SmallLeft", typeof(Question));
			this.SmallRight = (Question)info.GetValue("SmallRight", typeof(Question));

			this.Heading = info.GetString("Heading");
			this.Red = info.GetBoolean("Red");

			try
			{
				this.PArrowBig = (PersonSetting)info.GetValue("PArrowBig", typeof(PersonSetting));
				this.PArrowSmall = (PersonSetting)info.GetValue("PArrowSmall", typeof(PersonSetting));
				this.PSmallLeft = (PersonSetting)info.GetValue("PSmallLeft", typeof(PersonSetting));
				this.PSmallRight = (PersonSetting)info.GetValue("PSmallRight", typeof(PersonSetting));
			}
			catch{}
		}

		public float deg2rad(float grad)
		{
			return grad* (float)(Math.PI/180);
		}

		public float rad2deg(float rad)
		{
			return rad * 57.2957795f;
		}

		public void DrawNeedle(Graphics g, float x, float y, float len, float wid, float angle, Color c)
		{
			angle = 360 - angle;

			g.SmoothingMode = SmoothingMode.AntiAlias;
			Brush b = new SolidBrush(c);

			PointF[] pol =  new PointF[] {new PointF(0,0),
										new PointF(0,wid), 
										new PointF(len,wid/2)};

			Matrix m = new Matrix();
			   
			m.Rotate(angle, MatrixOrder.Append); 

			float xpos = x-wid/2;
			float ypos = y-wid/2;

			if (angle < 270) ypos = y;


			m.Translate(xpos, ypos, MatrixOrder.Append);
			g.Transform = m;
			g.FillPolygon(b, pol);
			g.ResetTransform();


		}
		public override void Compute()
		{
			Bitmap raw;

			if (Red) raw = RawRed;
			else raw = Raw;

			Bitmap img = GraphicTools.ResizeBitmap(raw, this.width, this.height);

			Graphics g = Graphics.FromImage(img);
			g.SmoothingMode = SmoothingMode.AntiAlias;

			float scalex = ((float)width) / ((float)raw.Width);
			float scaley = ((float)height) / ((float)raw.Height);

			float arrwid = 21 * scalex;

			float ArrowLargeLength = 400 * scaley;

			//center to worst/best
			float x = 292 * scalex;
			float y = 286 * scaley;

			float x2 = 249 * scalex;
			float y2 = 246 * scaley;

			float hyp = (float) Math.Sqrt( (x*x) + (y*y) );
			float hyp2 = (float) Math.Sqrt( (x2*x2) + (y2*y2) );

			//sin a = y / hyp;

			float angleWorst = rad2deg((float)  Math.Asin(y/hyp));
			float angleBest = 180 - angleWorst;

			float bottomHeight = 65 * scaley;

			Color cpColor = Color.FromArgb(224,185,40);

			PointF cpArrows = new PointF(387f*scalex,496f*scaley);

			PointF cpLeft = new PointF(228f*scalex,460f*scaley);
			PointF cpRight = new PointF(573f*scalex,458f*scaley);

			PointF cpText = new PointF(391f*scalex,341f*scaley);

			PointF cpSmallLeft = new PointF(226*scalex, 493*scaley);
			PointF cpSmallRight = new PointF(571*scalex, 493*scaley);

			PointF cpSL = new PointF(226*scalex, 460*scaley);
			PointF cpSR = new PointF(571*scalex, 460*scaley);

			float scaleAngle = (angleBest - angleWorst) / 4;

			Font sf = new Font("Verdana", 40*scaley, FontStyle.Regular, GraphicsUnit.Pixel);

			float smallRadX = 28 * scalex;
			float smallRadY = 28 * scaley;
			float pointRad = 45 *  ((scalex+scaley)/2);

			float scaleAngle2 = 180/4;

			float spreadAngle = 25;

			//heading

			Font hf = new Font("Verdana", 40*scaley, FontStyle.Bold, GraphicsUnit.Pixel);
			SizeF size = g.MeasureString(Heading, hf);

			g.DrawString(Heading, hf, new SolidBrush(Color.Black), cpText.X - size.Width/2, cpText.Y - size.Height/2);

			//small arrows

			if (SmallLeft != null && PSmallLeft != null)
			{
				SizeF sizef = g.MeasureString(PSmallLeft.Short, sf);

				g.DrawString(PSmallLeft.Short, sf, new SolidBrush(PSmallLeft.Color2), cpSmallLeft.X-sizef.Width/2, cpSmallLeft.Y);


                float val = scaleAngle2 * (this.SmallLeft.GetAverageByPersonAsMark(Eval, PSmallLeft)-1);
				if (val > 0 && val < 180)
				{
					val = (180 - val) + 90;

					PointF[] triangle = new PointF[]{new PointF(cpSL.X + (float)Math.Sin(deg2rad(val-spreadAngle))*smallRadX,(cpSL.Y + (float)Math.Cos(deg2rad(val-spreadAngle))*smallRadY)),
														new PointF(cpSL.X + (float)Math.Sin(deg2rad(val+spreadAngle))*smallRadX,(cpSL.Y + (float)Math.Cos(deg2rad(val+spreadAngle))*smallRadY)),
														new PointF(cpSL.X + (float)Math.Sin(deg2rad(val))*pointRad,(cpSL.Y + (float)Math.Cos(deg2rad(val))*pointRad))
													};

					g.FillPolygon(new SolidBrush(Color.Black), triangle);
				}
				
			}
			else
			{
				//remove small arrow button
				g.FillRectangle(Brushes.White, 159*scalex, 386*scaley, 140*scalex, 114*scaley);
			}

			if (SmallRight != null && PSmallRight != null)
			{
				SizeF sizef = g.MeasureString(PSmallRight.Short, sf);

				g.DrawString(PSmallRight.Short, sf, new SolidBrush(PSmallRight.Color2), cpSmallRight.X-sizef.Width/2, cpSmallRight.Y);

                float val = scaleAngle2 * (this.SmallRight.GetAverageByPersonAsMark(Eval, PSmallRight)-1);
				if (val > 0 && val < 180)
				{
					val = (180 - val) + 90;

					PointF[] triangle = new PointF[]{new PointF(cpSR.X + (float)Math.Sin(deg2rad(val-spreadAngle))*smallRadX,(cpSR.Y + (float)Math.Cos(deg2rad(val-spreadAngle))*smallRadY)),
														new PointF(cpSR.X + (float)Math.Sin(deg2rad(val+spreadAngle))*smallRadX,(cpSR.Y + (float)Math.Cos(deg2rad(val+spreadAngle))*smallRadY)),
														new PointF(cpSR.X + (float)Math.Sin(deg2rad(val))*pointRad,(cpSR.Y + (float)Math.Cos(deg2rad(val))*pointRad))
													};

					g.FillPolygon(new SolidBrush(Color.Black), triangle);
				}
			}
			else
			{
				//remove small arrow button
				g.FillRectangle(Brushes.White, 503*scalex, 386*scaley, 140*scalex, 114*scaley);
			}

			//arrows

			if (ArrowSmall != null && PArrowSmall != null)
			{
                float vArrowSmall = angleBest - (scaleAngle * (this.ArrowSmall.GetAverageByPersonAsMark(Eval, this.PArrowSmall)-1));
				if (vArrowSmall < angleBest)
					DrawNeedle(g, cpArrows.X, cpArrows.Y, hyp2, arrwid, vArrowSmall,Color.FromArgb(25,25,25));
			}


			if (ArrowBig != null && PArrowBig != null)
			{					
				float vArrowLarge = angleBest - (scaleAngle * (this.ArrowBig.GetAverageByPersonAsMark(Eval, this.PArrowBig)-1));
				//float vArrowLarge = 90;
				if (vArrowLarge <= angleBest)
				{
					DrawNeedle(g, cpArrows.X, cpArrows.Y, hyp, arrwid, vArrowLarge,Color.FromArgb(51,51,51));

					//bottom part

					vArrowLarge = 270 + vArrowLarge;

					float bx = (float)Math.Sin(deg2rad(vArrowLarge)) * bottomHeight;
					float by = (float)Math.Cos(deg2rad(vArrowLarge)) * bottomHeight;

					g.DrawLine(new Pen(Color.FromArgb(51,51,51),arrwid), cpArrows.X, cpArrows.Y, cpArrows.X + bx, cpArrows.Y + by);

					float lwid = arrwid * 1.5f;

					g.FillEllipse(new SolidBrush(Color.FromArgb(51,51,51)), cpArrows.X + bx -lwid/2, cpArrows.Y + by - lwid/2, lwid, lwid);
				}
			}

			g.FillEllipse(new SolidBrush(cpColor), 378*scalex, 486*scaley, 21*scalex, 21*scaley);


			


			this.OutputImage = img;
		}

		public override void EditDialog()
		{
			OutputFormBarometer ofa = new OutputFormBarometer(eval, false, this);
			ofa.ShowDialog();
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Barometer(eval, false, this);
        }

		public override void Save(string name, string path)
		{
			//
			Question[] baseq = new Question[4];
			
			baseq[0] = this.ArrowBig;
			baseq[1] = this.ArrowSmall;
			baseq[2] = this.SmallLeft;
			baseq[3] = this.SmallRight;
			
			//cross?
			Evaluation seval;
			if (CrossTargets(baseq))
			{
				seval = this.CrEval;
			}
			else if (this.OvEval != null)
			{
				seval = OvEval;
			}
			else
			{
				seval = this.eval;
			}
			//Targets

			foreach (TargetData td in seval.CombinedTargets)
			{
				if (!td.Included)
					continue;

				this.ArrowBig = td.GetQuestion(ArrowBig, Eval);
				this.ArrowSmall = td.GetQuestion(ArrowSmall, Eval);
				this.SmallLeft = td.GetQuestion(SmallLeft, Eval);
				this.SmallRight = td.GetQuestion(SmallRight, Eval);

				Compute();

				FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " ("+td.Name+").png"), FileMode.Create );
				OutputImage.Save( myFileOut, ImageFormat.Png );
				myFileOut.Close();
			}

			seval = null;
			OutputImage = null;
		}
	}
}
