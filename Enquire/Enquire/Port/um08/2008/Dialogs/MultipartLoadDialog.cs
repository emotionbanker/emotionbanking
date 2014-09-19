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
    public partial class MultipartLoadDialog : Form
    {
        public Evaluation eval;
        private string filename;
        private umfrage2._2008.Tools.EvaluationLoader es;

        public bool AutoComplete = false;

        public MultipartLoadDialog()
        {
            InitializeComponent();

            EndButton.Enabled = false;
            DoneLabel.Visible = false;

            status.Done += new DoneEventHandler(status_Done);
        }

        public void LoadFile(string filename)
        {
            this.filename = filename;
            this.ShowDialog();
        }

        void status_Done()
        {
            EndButton.Enabled = DoneLabel.Visible = true;
            DoneLabel.Refresh();
            eval = es.eval;
            if (AutoComplete) Close();
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MultipartSaveDialog_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            Brush b = new LinearGradientBrush(r, Color.FromArgb(242, 248, 254), Color.FromArgb(194, 211, 255), 0, true);

            g.FillRectangle(b, r);
        }

        private void MultipartLoadDialog_Load(object sender, EventArgs e)
        {
            es = new umfrage2._2008.Tools.EvaluationLoader();
            es.LoadFrom(filename, this.status);
        }

        private void status_Load(object sender, EventArgs e)
        {

        }
    }
}