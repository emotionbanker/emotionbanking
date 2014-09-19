using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
    [Serializable]
    public class Symbol
    {
        public const int SHAPE_ELLIPSED = 5;
        public const int SHAPE_ELLIPSE = 4;
        public const int SHAPE_TRIANGLED = 3;
        public const int SHAPE_TRIANGLE = 2;
        public const int SHAPE_CIRCLE = 1;
        public const int SHAPE_BOX = 0;

        public enum Shader { None, 
                             Diagonal45, Diagonal135, Diagonal225, Diagonal315,
                             LeftToRight, RightToLeft, TopToBottom, BottomToTop };

        public int Shape;

        public int Size;

        public Shader Shading;

        [NonSerialized]
        public float x;
        [NonSerialized]
        public float y;
        [NonSerialized]
        public float valueheight;

        public PointF topLeft
        { get { return new PointF(x - Size / 2, y + (valueheight - Size) / 2); } }

        public PointF topCenter
        { get { return new PointF(x, y + (valueheight - Size) / 2); } }

        public PointF topRight 
        { get { return new PointF(x + Size / 2, y + (valueheight - Size) / 2);}}
        public PointF botLeft 
        { get { return new PointF(x - Size / 2, y + valueheight - (valueheight - Size) / 2);}}
        public PointF botCenter 
        { get { return new PointF(x, y + valueheight - (valueheight - Size) / 2);}}
        public PointF botRight
        { get { return new PointF(x + Size / 2, y + valueheight - (valueheight - Size) / 2); } }

        public PointF rightCenter
        {
            get { return new PointF(x + Size / 2, y); }
        }

        public PointF leftCenter
        {
            get { return new PointF(x - Size / 2, y); }
        }

        public Symbol()
        {
            Shape = SHAPE_CIRCLE;
            Size = 20;
            Shading = Shader.Diagonal315;
        }

        public void Draw(Graphics g, PersonSetting p)
        {
            Draw(g, p.Color1, p.Color2, new Pen(new SolidBrush(Color.Transparent)));
        }


        public void Draw(Graphics g, Color Color1, Color Color2)
        {
            Draw(g, Color1, Color2, new Pen(new SolidBrush(Color.Transparent)));
        }

        public void Draw(Graphics g, Color Color1, Color Color2, Pen Border)
        {
            Brush b;

            switch (Shading)
            {
                case Shader.Diagonal45: b = new LinearGradientBrush(botLeft, topRight, Color1, Color2); break;
                case Shader.Diagonal135: b = new LinearGradientBrush(botRight, topLeft, Color1, Color2); break;
                case Shader.Diagonal225: b = new LinearGradientBrush(topRight, botLeft, Color1, Color2); break;
                case Shader.Diagonal315: b = new LinearGradientBrush(topLeft, botRight, Color1, Color2); break;

                case Shader.BottomToTop: b = new LinearGradientBrush(botCenter, topCenter, Color1, Color2); break;
                case Shader.TopToBottom: b = new LinearGradientBrush(topCenter, botCenter, Color1, Color2); break;
                case Shader.LeftToRight: b = new LinearGradientBrush(leftCenter, rightCenter, Color1, Color2); break;
                case Shader.RightToLeft: b = new LinearGradientBrush(rightCenter, leftCenter, Color1, Color2); break;

                default: b = new SolidBrush(Color1); break;
            }

            switch (Shape)
            {
                case SHAPE_BOX:
                    g.FillRectangle(b, topLeft.X, topLeft.Y, Size, Size);
                    g.DrawRectangle(Border, topLeft.X, topLeft.Y, Size, Size);
                    break;

                case SHAPE_CIRCLE:
                    //GraphicTools.Sphere(x, y+(valueheight/2), shapeheight/2, colors[i], colors[i], g);
                    g.FillEllipse(b, topLeft.X, topLeft.Y, Size, Size);
                    g.DrawEllipse(Border, topLeft.X, topLeft.Y, Size, Size);
                    break;

                case SHAPE_TRIANGLE:
                    g.FillPolygon(b, new PointF[] { topCenter, botRight, botLeft }, FillMode.Alternate);
                    g.DrawPolygon(Border, new PointF[] { topCenter, botRight, botLeft });
                    break;

                case SHAPE_TRIANGLED:
                    g.FillPolygon(b, new PointF[] { botCenter, topRight, topLeft }, FillMode.Alternate);
                    g.DrawPolygon(Border, new PointF[] { botCenter, topRight, topLeft });
                    break;

                case SHAPE_ELLIPSE:
                    g.FillEllipse(b, topLeft.X, topLeft.Y + Size / 4, Size, Size / 2);
                    g.DrawEllipse(Border, topLeft.X, topLeft.Y + Size / 4, Size, Size / 2);
                    break;

                case SHAPE_ELLIPSED:
                    g.FillEllipse(b, topLeft.X + Size / 4, topLeft.Y, Size / 2, Size);
                    g.DrawEllipse(Border, topLeft.X + Size / 4, topLeft.Y, Size / 2, Size);
                    break;
            }
        }
    }
}
