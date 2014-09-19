using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Misc
{
    public partial class FadeLabel : Panel
    {
        public Color Color;
        private int alpha;
        public int step;
        public int dir;

        public FadeLabel()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);

            alpha = 255;

            Color = Color.Black;

            step = 20;
            dir = 1;

            Timer t = new Timer();
            t.Interval = 100;

            t.Tick += new EventHandler(t_Tick);

            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            anim();
        }


        private void anim()
        {
            if (dir == 1)
                alpha += step;
            else 
                alpha -= step;

            if (alpha > 255) { alpha -= 2*step; dir = 0; }
            if (alpha < 0) { alpha += 2*step; dir = 1; }

            this.ForeColor = Color.FromArgb(alpha, Color);
            Refresh();
            //Console.WriteLine("c=" + ForeColor);
        }
        

        private void FadeLabel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SizeF ss = g.MeasureString(Text, Font);

            g.DrawString(this.Text, this.Font, new SolidBrush(ForeColor), this.Width / 2 - ss.Width / 2, this.Height / 2 - ss.Height / 2);

            //Refresh();
        }
    }
}
