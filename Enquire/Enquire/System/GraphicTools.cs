using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// Summary description for GraphicTools.
	/// </summary>
	public class GraphicTools
	{
		public GraphicTools()
		{
		}

		public static Color VariableContrast(Color orig, int deg)
		{
			int r, g, b;

			if (orig.R > 255-deg) r = orig.R - deg; else r = orig.R + deg;
			if (orig.G > 255-deg) g = orig.G - deg; else g = orig.G + deg;
			if (orig.B > 255-deg) b = orig.B - deg; else b = orig.B + deg;

			return Color.FromArgb(r,g,b);
		}

		public static Color Contrast(Color orig, int deg)
		{
			int r, g, b;

			int fact = 1;

			if (orig.R > 225 || orig.G > 225 || orig.B > 225) fact = -1;

			r = Math.Min(Math.Max(orig.R + deg * fact, 0),255);
			g = Math.Min(Math.Max(orig.G + deg * fact, 0),255);
			b = Math.Min(Math.Max(orig.B + deg * fact, 0),255);

			return Color.FromArgb(r,g,b);
		}

		public static Bitmap ResizeBitmap( Bitmap b, int nWidth, int nHeight )
		{
			Bitmap result = new Bitmap( nWidth, nHeight );
			using( Graphics g = Graphics.FromImage( (Image) result ) )
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.DrawImage( b, 0, 0, nWidth, nHeight );

			}
			return result;
		}

		public static Bitmap ChangeColor(Bitmap bmp, Color o, Color n)
		{
			for (int x = 0; x < bmp.Width; x++)
			{
				for (int y = 0; y < bmp.Height; y++)
				{
					if (bmp.GetPixel(x, y).Equals(o))
					{
						bmp.SetPixel(x,y,n);
					}
				}
			}
			return bmp;
		}

		public static Bitmap ChangeTransparency(Bitmap bmp, Color T)
		{
			for (int x = 0; x < bmp.Width; x++)
			{
				for (int y = 0; y < bmp.Height; y++)
				{
					if (bmp.GetPixel(x, y) == T)
					{
						bmp.SetPixel(x,y,Color.Transparent);
					}
				}
			}
			return bmp;
		}

		public static void Sphere(float x, float y, float radius, Color color1, Color color2, Graphics g)
		{
			Sphere(x, y, radius, color1, color2, g, Color.Black);
		}
		public static void Sphere(float x, float y, float radius, Color color1, Color color2, Graphics g, Color BorderColor)
		{
			if (radius <= 0) return;
				
			g.SmoothingMode = SmoothingMode.AntiAlias;
			Pen Border = new Pen(BorderColor);

			GraphicsPath path=new GraphicsPath();

			path.AddEllipse(x-radius,y-radius,radius*2,radius*2);

			PathGradientBrush Sphere = new PathGradientBrush(path);
			Sphere.CenterColor = color1;
			Sphere.CenterPoint = new PointF(x-radius/2,y-radius/2);
			Sphere.SurroundColors = new Color[]{color2};

			g.FillEllipse(Sphere, x-radius, y-radius, radius*2, radius*2);
			g.DrawEllipse(Border, x-radius, y-radius, radius*2, radius*2);
		}

		public static void Box(float x, float y, float width, float height, Color Fill, Color Fill2, Color Border, Graphics g)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;
			Brush Gradient = new LinearGradientBrush(new RectangleF(x,y,width,height), Fill, Fill2, 0, false);
			Pen BP = new Pen(Border);

			g.FillRectangle(Gradient,x,y,width,height);
			g.DrawRectangle(BP,x,y,width,height);
		}

		public static void Bar(float x, float y, float width, float height, float angle, Color color1, Color color2, Graphics g)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;
			Brush Gradient = new LinearGradientBrush(new RectangleF(x, y, width, height), color2, color1, angle, false);
			Pen Border = new Pen(Color.Black);

			g.FillRectangle(Gradient,x,y,width,height);
			g.DrawRectangle(Border,x,y,width,height);
		}


		public static void Bar3d(float x, float y, float width, float height, float angle, float offset, Color color1, Color color2, Graphics g, bool toppled)
		{
			if (width < 1) width = 1;
			if (height < 1) height = 1;

			g.SmoothingMode = SmoothingMode.AntiAlias;
			Brush Gradient = new LinearGradientBrush(new RectangleF(x, y, width, height), color2, color1, angle, false);
			Brush OffsetGradientRight = new LinearGradientBrush(new RectangleF(x, y - offset, width+offset, height+offset), color2, color1, angle-offset, false);
			Brush OffsetSolidTop = new SolidBrush(color1);
			Pen Border = new Pen(Color.Black);

			//g.FillRectangle(OffsetGradient,x+offset,y-offset,width,height);
			g.FillRectangle(Gradient,x,y,width,height);
			g.DrawRectangle(Border,x,y,width,height);

			Brush b1, b2;
			if (!toppled)
			{
				b1 = OffsetGradientRight;
				b2 = OffsetSolidTop;
			}
			else
			{
				b1 = OffsetSolidTop;
				b2 = OffsetGradientRight;
			}
	
			g.FillPolygon(b1,new PointF[]{new PointF(x+width,y), new PointF(x+width+offset, y-offset), new PointF(x+width+offset,y+height-offset), new PointF(x+width,y+height)}, FillMode.Alternate);

			g.FillPolygon(b2, new PointF[]{new PointF(x,y), new PointF(x+offset, y-offset), new PointF(x+offset+width, y-offset), new PointF(x+width, y)}, FillMode.Alternate);

			g.DrawLine(Border,x+offset,y-offset,x+width+offset,y-offset); //top
			g.DrawLine(Border,x+offset+width,y-offset,x+offset+width,y+height-offset); //right
			g.DrawLine(Border, x,y, x+offset, y-offset); //top left to top left
			g.DrawLine(Border, x+width, y+height, x+width+offset,y+height-offset); //bottom right to bottom right
			g.DrawLine(Border, x+width,y,x+width+offset,y-offset); //top right to top right
		}

		//public static float GetLineHeight()

		public static string SplitString(string source, float width, Graphics g, Font f)
		{
			string temp = string.Empty;
			string result = string.Empty;
			string remain = source;
			int pos = 0;

			//bool first = true;

			char[] splitChars = new char[]{' '};

			SizeF size = g.MeasureString(source, f, new PointF(0, 0), StringFormat.GenericDefault);

			if (size.Width < width)
				return source;

			// goto exact character break

			//temp = remain;

			while (pos < source.Length)
			{
				int i = 0;
				do
				{
					temp = source.Substring(pos, i);
					size = g.MeasureString(temp, f, new PointF(0, 0), StringFormat.GenericDefault);
					i++;
					//Console.WriteLine("inner");
				}
				while(size.Width < width && (pos+i) < source.Length);

				if ( (pos + i) >= source.Length)
				{
					result += source.Substring(pos).Trim();
					break;
				}

				//now find last split char

				int splitAt = temp.LastIndexOfAny(splitChars);

				if (splitAt == 0 || splitAt == -1)
				{
					splitAt = temp.Length-1;
					if (temp.Length-1 < 1)
						return "";
					result += temp.Substring(0, temp.Length-1).Trim() + "-\n";
				}
				else
				{
					result += source.Substring(pos, splitAt).Trim() + "\n";
				}

				pos += splitAt;

				//Console.WriteLine("outer temp=" + temp + "; pos=" + pos);
			}

			return result;
		}

		public static Bitmap ImageTable(ArrayList table, int[] dimensions, string[]header, Color[] RowColors)
		{
			return ImageTable(table, dimensions, header, RowColors, false);
		}

		public static Bitmap ImageTable(ArrayList table, int[] dimensions, string[]header, Color[] RowColors, bool LineColors)
		{
			///Vars
			///

			int Width = 0;
			foreach (int d in dimensions)
				Width+=d;

			SizeF size;

			int xoff = 3;
			int yoff = 3;

			float linepos = yoff*2;

			///Tools
			///
			SolidBrush HeaderBack = new SolidBrush(Color.LightGray);
			SolidBrush LineBack2  = new SolidBrush(Color.White);
			SolidBrush LineBack1  = new SolidBrush(Color.White);

			Pen OuterLine = new Pen(Color.Black, 3);
			Pen SeperatorLine = new Pen(Color.Black, 2);
			Pen GridLine = new Pen(Color.Black, 1);

			SolidBrush BlackBrush = new SolidBrush(Color.Black);

			Font HeadFont = new Font("Arial", 8, FontStyle.Bold);
			Font TextFont = new Font("Arial", 8, FontStyle.Regular);

			///
			Bitmap bmp = new Bitmap(Width + 2*xoff,5000 + 2*xoff);
			Graphics g = Graphics.FromImage(bmp);

			g.Clear(Color.White);

			float height = 0;
			int widpos;

			///header
			///

			if (header != null)
			{
			
				///content
				///

				height = 0;
			
				for (int i = 0; i < dimensions.Length; i++)
				{
					size = g.MeasureString(SplitString(header[i], dimensions[i], g, HeadFont), HeadFont, new PointF(0, 0), StringFormat.GenericDefault);				
					if (size.Height > height)
						height = size.Height;
				}

				g.FillRectangle(HeaderBack, xoff, yoff, Width-xoff, height+2*yoff);

				widpos = xoff*2;

				for (int i = 0; i < dimensions.Length; i++)
				{
					string col = SplitString(header[i], dimensions[i]-2*xoff, g, HeadFont); 
				
					Brush b;
					if (!LineColors)
						b = new SolidBrush(RowColors[i]);
					else
						b = BlackBrush;

					g.DrawString(col, HeadFont, b, widpos, linepos);

					widpos += dimensions[i];
				}
				linepos += height + yoff;

				g.DrawLine(SeperatorLine, xoff, linepos, Width, linepos);

				linepos+=yoff;
			}

			///rows
			///

			bool alt = true;
			
			int r = 0;
			foreach (string[] row in table)
			{
				height = 0;//g.MeasureString("A", TextFont).Height;
			
				for (int i = 0; i < dimensions.Length; i++)
				{
					//Console.WriteLine("row " + i + "= '" + row[i] + "'");
					size = g.MeasureString(SplitString(row[i], dimensions[i]-2*xoff, g, TextFont), TextFont, new PointF(0, 0), StringFormat.GenericDefault);				
					if (size.Height > height)
						height = size.Height;
				}

				Brush b2;
				if (alt) b2 = LineBack1;
				else     b2 = LineBack2;
				alt = !alt;

				if (LineColors)
					b2 = new SolidBrush(RowColors[r]);

				g.FillRectangle(b2, xoff, linepos-yoff, Width-xoff, height+2*yoff);

				widpos = xoff*2;
				for (int i = 0; i < dimensions.Length; i++)
				{
					string col = SplitString(row[i], dimensions[i], g, TextFont); 

					Brush b;
					if (!LineColors)
						b = new SolidBrush(RowColors[i]);
					else
						b = BlackBrush;

					g.DrawString(col, TextFont, b, widpos, linepos);

					widpos += dimensions[i];
				}
				height += yoff;
				linepos += height;

				g.DrawLine(GridLine, xoff, linepos-1, Width, linepos-1);

				linepos += yoff;
				r++;
			}
	

			//draw border

			g.DrawLine(OuterLine, xoff, yoff, Width, yoff);
			g.DrawLine(OuterLine, xoff, linepos-yoff, Width, linepos-yoff);
			g.DrawLine(OuterLine, xoff, yoff, xoff, linepos-yoff);
			g.DrawLine(OuterLine, Width, yoff, Width, linepos-yoff);


			// draw grid


			widpos = xoff + dimensions[0];
			for (int i = 1; i < dimensions.Length; i++)
			{
				g.DrawLine(GridLine, widpos, yoff, widpos, linepos-yoff);
				widpos += dimensions[i];
			}


			Bitmap result = new Bitmap(Width + 2*xoff,(int)linepos+1);
			Graphics rg = Graphics.FromImage(result);

			rg.DrawImage(bmp, 0, 0);

			return result;
		}


		public static Bitmap ColorTable(Color[] colors, Color[] colors2, string[]names, decimal[]percent, float width)
		{
			///Vars
			///

			float linepos   = 3;
			float boxwidth  = 30;
			float pcntwidth = 50;

			float textwidth = width - boxwidth - pcntwidth;

			float yoff = 3;

			decimal total = 0;
			foreach (decimal p in percent)
				total+=p;

			for (int i = 0; i < percent.Length; i++)
			{
				if (total == 0)
					percent[i] = 0;
				else
					percent[i] = (percent[i] / total) * 100;
			}

			///Tools
			///
			SolidBrush LineBack2  = new SolidBrush(Color.White);
			SolidBrush LineBack1  = new SolidBrush(Color.Gainsboro);

			Pen OuterLine = new Pen(Color.Gray, 1);

			SolidBrush BlackBrush = new SolidBrush(Color.Black);

			Font TextFont = new Font("Arial", 8, FontStyle.Regular);

			///
			Bitmap bmp = new Bitmap((int)width+1, 5000);
			Graphics g = Graphics.FromImage(bmp);

			g.Clear(Color.White);


			for (int i = 0; i < names.Length; i++)
			{
				names[i] = SplitString(names[i], textwidth, g, TextFont);
			}

			//float height;
			//int widpos;

			bool alt = true;
			
			int r = 0;
			foreach (string name in names)
			{
				SizeF size = g.MeasureString(name, TextFont, new PointF(0, 0), StringFormat.GenericDefault);				

				Brush b2;
				if (alt) b2 = LineBack1;
				else     b2 = LineBack2;
				alt = !alt;

				g.FillRectangle(b2, 0, linepos-yoff, width, size.Height+2*yoff);


				//box

				Box(7, linepos, boxwidth-14, boxwidth-14, colors[r], colors2[r], Color.Black, g);

				//name

				g.DrawString(name, TextFont, BlackBrush, boxwidth+5, linepos);

				//pecent

				g.DrawString(Math.Round(percent[r], 1) + "%", TextFont, BlackBrush, boxwidth + textwidth + 5, linepos);

				
				linepos += Math.Max(size.Height, g.MeasureString("A",TextFont).Height) + yoff;

				//g.DrawLine(GridLine, 0, linepos-1, width, linepos-1);

				linepos += yoff;
				r++;
			}
	

			//draw border

			g.DrawLine(OuterLine, 0, 0, width, 0);
			g.DrawLine(OuterLine, 0, linepos, width, linepos);
			g.DrawLine(OuterLine, 0, 0, 0, linepos);
			g.DrawLine(OuterLine, width, 0, width, linepos);



			Bitmap result = new Bitmap((int)width+1,(int)linepos+5);
			Graphics rg = Graphics.FromImage(result);

			rg.DrawImage(bmp, 0, 0);

			return result;
		}
	}
}
