using System.Drawing;

namespace Compucare.Enquire.Common.Calculation.Graphics.TrafficLights
{
    public class TrafficLight : ExclamationMark.ExclamationMark
    {
        public override void Draw(System.Drawing.Graphics g, Color useColor, float wid, float hei)
        {
            SolidBrush colorBrush = new SolidBrush(useColor);

            g.FillEllipse(colorBrush, 0, 0, wid, hei);
        }
    }
}
