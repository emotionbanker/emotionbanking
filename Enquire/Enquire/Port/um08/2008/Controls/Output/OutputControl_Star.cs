using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output.Star;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;
using umfrage2._2008;


namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Star : UserControl
    {
		private Evaluation eval;
		public Star star;
		private Crossing cross;
		private OutputNameControl onc;
		
		

		private Question question;
		
		private bool single;

		public OutputControl_Star(Evaluation eval)
		{
			Set(eval, true, new Star(eval));
		}

		public OutputControl_Star(Evaluation eval, bool single)
		{
			Set(eval, single, new Star(eval));
		}

		public OutputControl_Star(Evaluation eval, bool single, Star star)
		{
            Set(eval, single, star);

            sizeControl.SetSize(star.width, star.height);

            Preview();
		}

        private void Set(Evaluation eval, bool single, Star star)
		{
			this.single = single;
			this.eval = eval;
            this.star = star;

			InitializeComponent();

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_SizeChanged);


			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(star.Cross);


            SetRadios();

            SetColBox();
		}

        private void SetRadios()
        {
            db1.Checked = (star.SType == Star.StarType.One);
            db2.Checked = !db1.Checked;
        }

        public void SetColBox()
        {
            DataPanel.Controls.Clear();

            int pos = 0;
            foreach (StarElement elem in star.Elements)
            {
                StarAxisControl sac = new StarAxisControl(star, eval, elem);
                sac.Location = new Point(5, pos);
                sac.SelfDestruct += new StarAxisControl.SelfDestructDelegate(sac_SelfDestruct);
                sac.Changed += new StarAxisControl.ControlChangeDelegate(sac_Changed);
                pos += sac.Height;
                DataPanel.Controls.Add(sac);
            }
        }

        void sac_Changed()
        {
            Preview();
        }

        void sac_SelfDestruct()
        {
            SetColBox();
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>

        private void Preview()
        {
            Preview(false);
        }

        private void Preview(bool bigOnly)
        {
           
                star.height = sizeControl.ChosenHeight;
                star.width = sizeControl.ChosenWidth;
                star.Compute();

                previewBox.SmallPreview = star.OutputImage;
                previewBox.BigPreview = star.OutputImage;
        }

        private void sizeControl_SizeChanged()
        {
            Preview(true);
        }

        private void cross_CrossChanged()
        {
            star.Cross = cross.cross;
        }

        private void colsel_ColorChanged()
        {
            Preview();
        }


        private void GoButton_Click(object sender, EventArgs e)
        {
            star.eval = eval;
            star.Cross = cross.Cross;
            star.width = sizeControl.ChosenWidth;
            star.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(star);
            sd.ShowDialog();
        }

        private void db1_CheckedChanged(object sender, EventArgs e)
        {
            star.SType = Star.StarType.One;
            Preview();
        }

        private void db2_CheckedChanged(object sender, EventArgs e)
        {
            star.SType = Star.StarType.Two;
            Preview();
        }

        private void NewElemButton_Click(object sender, EventArgs e)
        {
            star.Elements.Add(new StarElement());
            SetColBox();
        }

        private void DataPanel_Paint(object sender, PaintEventArgs e)
        {

        }

    
    }
}
