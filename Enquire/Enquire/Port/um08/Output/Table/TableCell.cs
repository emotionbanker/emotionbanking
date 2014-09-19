using System.Drawing;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output.Table
{
    class TableCell
    {
        public string Text;
        public Font TextFont;
        public Color TextColor;

        public int Border;
        public Color BorderColor;

        public Bitmap Content;

        public TableCell()
        {
            Text = string.Empty;
            TextFont = null;
            TextColor = Color.Black;

            Border = -1;
            BorderColor = Color.Black;

            Content = null;
        }
    }
}
