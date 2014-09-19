using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;


namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Barometer : UserControl
    {
        
        private System.ComponentModel.IContainer components = null;


        public Barometer bar;
        private Evaluation eval;
        private bool single;

       
        
        
        private Crossing cross;

        public OutputControl_Barometer(Evaluation eval)
		{
            Set(eval, true, new Barometer(eval));

			Preview();
		}

		public OutputControl_Barometer(Evaluation eval, bool single)
		{
            Set(eval, single, new Barometer(eval));

			Preview();
		}

		public OutputControl_Barometer(Evaluation eval, bool single, Barometer bar)
		{
			Set(eval, single, bar);
					
			Preview();
		}

		private void Set(Evaluation eval, bool single, Barometer bar)
		{
			this.eval = eval;
			this.single = single;
			this.bar = bar;

			Console.WriteLine("eval null?" + (eval==null));
			InitializeComponent();


			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(bar.Cross);

			OutputNameControl onc = new OutputNameControl(bar);
			onc.Location = new Point(530,16);
			//HeaderPanel.Controls.Add(onc);

			sizeControl.SetSize(bar.width, bar.height);

			foreach (PersonSetting ps in eval.CombinedPersons)
			{
				PArrowLarge.Items.Add(ps);
				PArrowSmall.Items.Add(ps);
				PSmallLeft.Items.Add(ps);
				PSmallRight.Items.Add(ps);
			}

			PArrowLarge.SelectedItem = bar.PArrowBig;
			PArrowSmall.SelectedItem = bar.PArrowSmall;
			PSmallLeft.SelectedItem = bar.PSmallLeft;
			PSmallRight.SelectedItem = bar.PSmallRight;

			if (bar.ArrowBig != null)
				LArrowBig.Text = bar.ArrowBig.SID.ToString();
			if (bar.ArrowSmall != null)
				LArrowSmall.Text = bar.ArrowSmall.SID.ToString();
			if (bar.SmallLeft != null)
				LSmallLeft.Text = bar.SmallLeft.SID.ToString();
			if (bar.SmallRight != null)
				LSmallRight.Text = bar.SmallRight.SID.ToString();

			MarkBox.Text = bar.Heading;
			RedCheck.Checked = bar.Red;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


        private void PArrowLarge_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.PArrowBig = (PersonSetting)PArrowLarge.SelectedItem;
            Preview();
        }

        private void PArrowSmall_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.PArrowSmall = (PersonSetting)PArrowSmall.SelectedItem;
            Preview();
        }

        private void BArrowLarge_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LArrowBig.Text = qs.SelectedQuestion.SID.ToString();
            else LArrowBig.Text = "";

            bar.ArrowBig = qs.SelectedQuestion;

            Preview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LArrowSmall.Text = qs.SelectedQuestion.SID.ToString();
            else LArrowSmall.Text = "";
            bar.ArrowSmall = qs.SelectedQuestion;

            Preview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LSmallLeft.Text = qs.SelectedQuestion.SID.ToString();
            else LSmallRight.Text = "";
            bar.SmallLeft = qs.SelectedQuestion;

            Preview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LSmallRight.Text = qs.SelectedQuestion.SID.ToString();
            else LSmallRight.Text = "";
            bar.SmallRight = qs.SelectedQuestion;

            Preview();
        }

        private void PSmallLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.PSmallLeft = (PersonSetting)PSmallLeft.SelectedItem;
            Preview();
        }

        private void PSmallRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.PSmallRight = (PersonSetting)PSmallRight.SelectedItem;
            Preview();
        }

        private void RedCheck_CheckedChanged(object sender, EventArgs e)
        {
            bar.Red = RedCheck.Checked;
            Preview();
        }

        private void MarkBox_TextChanged(object sender, EventArgs e)
        {
            bar.Heading = MarkBox.Text;
            Preview();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            bar.eval = eval;
            bar.Cross = cross.Cross;
            bar.width = sizeControl.ChosenWidth;
            bar.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(bar);
            sd.ShowDialog();
        }

        private void Preview()
        {
            bar.eval = eval;

            Size os = new Size(bar.width, bar.height);

            bar.width = 470;
            bar.height = 400;

            bar.Compute();

            previewBox.SmallPreview = bar.OutputImage;

            bar.width = os.Width;
            bar.height = os.Height;

            bar.Compute();

            previewBox.BigPreview = bar.OutputImage;
        }

        private void cross_CrossChanged()
        {
            bar.Cross = cross.cross;
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        private void OutputControl_Barometer_Load(object sender, EventArgs e)
        {

        }

        private void previewBox_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crossPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}