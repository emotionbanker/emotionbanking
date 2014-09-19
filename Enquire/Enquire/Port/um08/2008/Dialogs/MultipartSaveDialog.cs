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
    public partial class MultipartSaveDialog : Form
    {
        private Evaluation eval;
        private string filename;

        public MultipartSaveDialog()
        {
            InitializeComponent();

            EndButton.Enabled = false;  //Weiter Button ist grau hintergelegt bzw nicht anklickbar
            DoneLabel.Visible = false;  //Info Label wird nicht angezeigt.

            status.Done += new DoneEventHandler(status_Done); //kontrolle
        }

        public void Save(Evaluation eval, string filename)
        {
            this.eval = eval;
            this.filename = filename;
            this.ShowDialog();
        }

        void status_Done()
        {
            EndButton.Enabled = DoneLabel.Visible = true;
            DoneLabel.Refresh();
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MultipartSaveDialog_Load(object sender, EventArgs e)
        {
            umfrage2._2008.Tools.EvaluationSaver es = new umfrage2._2008.Tools.EvaluationSaver(eval);
            es.SaveTo(filename, this.status);
        }

        private void MultipartSaveDialog_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            Brush b = new LinearGradientBrush(r, Color.FromArgb(242, 248, 254), Color.FromArgb(194, 211, 255), 0, true);

            g.FillRectangle(b, r);
        }
    }
}