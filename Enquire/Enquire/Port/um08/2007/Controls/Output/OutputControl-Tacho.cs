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
    public partial class OutputControl_Tacho : UserControl
    {
        
        private System.ComponentModel.IContainer components = null;


        public Tacho bar;
        private Evaluation eval;
        private bool single;

        private Crossing cross;

        public OutputControl_Tacho(Evaluation eval)
		{
            Set(eval, true, new Tacho(eval));

			Preview();
		}

		public OutputControl_Tacho(Evaluation eval, bool single)
		{
            Set(eval, single, new Tacho(eval));

			Preview();
		}

        public OutputControl_Tacho(Evaluation eval, bool single, Tacho bar)
		{
			Set(eval, single, bar);
					
			Preview();
		}

        private void Set(Evaluation eval, bool single, Tacho bar)
		{
			this.eval = eval;
			this.single = single;
			this.bar = bar;

			InitializeComponent();


			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(bar.Cross);

			sizeControl.SetSize(bar.width, bar.height);
            sizeControl.ChosenSizeChanged += new SizeEventHandler(sizeControl_ChosenSizeChanged);

			foreach (PersonSetting ps in eval.CombinedPersons)
			{
				PArrowLarge.Items.Add(ps);
				PArrowSmall.Items.Add(ps);
			}

			PArrowLarge.SelectedItem = bar.PLeft;
			PArrowSmall.SelectedItem = bar.PRight;

            if (bar.QLeft != null)
				LArrowBig.Text = bar.QLeft.SID.ToString();
			if (bar.QRight != null)
                LArrowSmall.Text = bar.QRight.SID.ToString();
		

			MarkBox.Text = bar.Heading;
            textBox1.Text = bar.HLeft;
            textBox2.Text = bar.HRight;

			DarkLightBox.Checked = (bar.Style == Tacho.TachoStyle.Light);
		}

        void sizeControl_ChosenSizeChanged()
        {
            bar.width = sizeControl.ChosenWidth;
            bar.height = sizeControl.ChosenHeight;
            Preview();
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
            bar.PLeft = (PersonSetting)PArrowLarge.SelectedItem;
            Preview();
        }

        private void PArrowSmall_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.PRight = (PersonSetting)PArrowSmall.SelectedItem;
            Preview();
        }

        private void BArrowLarge_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LArrowBig.Text = qs.SelectedQuestion.SID.ToString();
            else LArrowBig.Text = "";

            bar.QLeft = qs.SelectedQuestion;

            Preview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LArrowSmall.Text = qs.SelectedQuestion.SID.ToString();
            else LArrowSmall.Text = "";
            bar.QRight = qs.SelectedQuestion;

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

            bar.width = previewBox.Width;
            bar.height = previewBox.Height;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bar.HLeft = textBox1.Text;
            Preview();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bar.HRight = textBox2.Text;
            Preview();
        }

        private void FontButtonS_Click(object sender, EventArgs e)
        {
            fontD.Font = bar.FontS;
            if (fontD.ShowDialog() == DialogResult.OK) bar.FontS = fontD.Font;
            Preview();
        }

        private void FontButtonT_Click(object sender, EventArgs e)
        {
            fontD.Font = bar.FontT;
            if (fontD.ShowDialog() == DialogResult.OK) bar.FontT = fontD.Font;
            Preview();
        }

        private void DarkLightBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DarkLightBox.Checked) bar.Style = Tacho.TachoStyle.Light;
            else bar.Style = Tacho.TachoStyle.Dark;
            Preview();
        }
    }
}