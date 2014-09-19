using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2._2008.Dialogs
{
    public partial class QuestionDetails : Form
    {
        public QuestionDetails()
        {
            InitializeComponent();
        }

        public static void ShowStats(Question q, Evaluation eval)
        {
            QuestionDetails qd = new QuestionDetails();
            qd.questionStats1.ShowStats(q, eval);
            qd.ShowDialog();
        }

        private void QuestionDetails_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            Brush b = new LinearGradientBrush(r, Color.FromArgb(242, 248, 254), Color.FromArgb(194, 211, 255), 0, true);

            g.FillRectangle(b, r);
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}