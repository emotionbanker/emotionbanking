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
    public partial class OutputControl_MultiGap : UserControl
    {
        
        private System.ComponentModel.IContainer components = null;


        public MultiGap bar;
        private Evaluation eval;
        private bool single;

       
        
        
        private Crossing cross;

        public OutputControl_MultiGap(Evaluation eval)
		{
            Set(eval, true, new MultiGap(eval));

			Preview();
		}

		public OutputControl_MultiGap(Evaluation eval, bool single)
		{
            Set(eval, single, new MultiGap(eval));

			Preview();
		}

        public OutputControl_MultiGap(Evaluation eval, bool single, MultiGap bar)
		{
			Set(eval, single, bar);
					
			Preview();
		}

        private void Set(Evaluation eval, bool single, MultiGap bar)
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

			OutputNameControl onc = new OutputNameControl(bar);
			onc.Location = new Point(530,16);
			//HeaderPanel.Controls.Add(onc);

			sizeControl.SetSize(bar.width, bar.height);
            sizeControl.ChosenSizeChanged += new SizeEventHandler(sizeControl_ChosenSizeChanged);

			foreach (PersonSetting ps in eval.CombinedPersons)
			{
				PArrowLarge.Items.Add(ps);
				PArrowSmall.Items.Add(ps);
				PSmallLeft.Items.Add(ps);
				PSmallRight.Items.Add(ps);
			}

			PArrowLarge.SelectedItem = bar.PTopRight;
			PArrowSmall.SelectedItem = bar.PTopLeft;
			PSmallLeft.SelectedItem = bar.PBotRight;
			PSmallRight.SelectedItem = bar.PBotLeft;

            if (bar.TopLeft != null)
                LArrowBig.Text = bar.TopLeft.SID.ToString();
            if (bar.TopRight != null)
                LArrowSmall.Text = bar.TopRight.SID.ToString();
            if (bar.BotLeft != null)
                LSmallLeft.Text = bar.BotLeft.SID.ToString();
            if (bar.BotRight != null)
                LSmallRight.Text = bar.BotRight.SID.ToString();

			MarkBoxLeft.Text = bar.HeadingLeft;
            MarkBoxRight.Text = bar.HeadingRight;
            MarkBoxCenter.Text = bar.HeadingCenter;
		}

        void sizeControl_ChosenSizeChanged()
        {
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
            bar.PTopLeft = (PersonSetting)PArrowLarge.SelectedItem;
            Preview();
        }

        private void PArrowSmall_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.PTopRight = (PersonSetting)PArrowSmall.SelectedItem;
            Preview();
        }

        private void BArrowLarge_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LArrowBig.Text = qs.SelectedQuestion.SID.ToString();
            else LArrowBig.Text = "";

            bar.TopLeft = qs.SelectedQuestion;

            Preview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LArrowSmall.Text = qs.SelectedQuestion.SID.ToString();
            else LArrowSmall.Text = "";
            bar.TopRight = qs.SelectedQuestion;

            Preview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LSmallLeft.Text = qs.SelectedQuestion.SID.ToString();
            else LSmallRight.Text = "";
            bar.BotLeft = qs.SelectedQuestion;

            Preview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            qs.ShowDialog();

            if (qs.SelectedQuestion != null)
                LSmallRight.Text = qs.SelectedQuestion.SID.ToString();
            else LSmallRight.Text = "";
            bar.BotRight = qs.SelectedQuestion;

            Preview();
        }

        private void PSmallLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.PBotLeft = (PersonSetting)PSmallLeft.SelectedItem;
            Preview();
        }

        private void PSmallRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            bar.PBotRight = (PersonSetting)PSmallRight.SelectedItem;
            Preview();
        }


        private void MarkBox_TextChanged(object sender, EventArgs e)
        {
            bar.HeadingLeft = MarkBoxLeft.Text;
            Preview();
        }

        private void MarkBoxRight_TextChanged(object sender, EventArgs e)
        {
            bar.HeadingRight = MarkBoxRight.Text;
            Preview();
        }

        private void MarkBoxCenter_TextChanged(object sender, EventArgs e)
        {
            bar.HeadingCenter = MarkBoxCenter.Text;
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

            bar.width = Math.Min(previewBox.Width, previewBox.Height) - 30;
            bar.height = Math.Min(previewBox.Width, previewBox.Height) - 30;

            bar.Compute();

            previewBox.SmallPreview = bar.OutputImage;

            bar.width = sizeControl.ChosenWidth;
            bar.height = sizeControl.ChosenHeight;

            bar.Compute();

            previewBox.BigPreview = bar.OutputImage;
        }

        private void cross_CrossChanged()
        {
            bar.Cross = cross.cross;
        }

        private void FSH_Click(object sender, EventArgs e)
        {
            FontD.Font = bar.HeadFont;
            if (FontD.ShowDialog() == DialogResult.OK) bar.HeadFont = FontD.Font;
            Preview();
        }

        private void FSV_Click(object sender, EventArgs e)
        {
            FontD.Font = bar.ValueFont;
            if (FontD.ShowDialog() == DialogResult.OK) bar.ValueFont = FontD.Font;
            Preview();
        }

        private void CSH_Click(object sender, EventArgs e)
        {
            ColorD.Color = bar.HeadColor;
            if (ColorD.ShowDialog() == DialogResult.OK) bar.HeadColor = ColorD.Color;
            Preview();
        }

        private void CSV_Click(object sender, EventArgs e)
        {
            ColorD.Color = bar.ValueColor;
            if (ColorD.ShowDialog() == DialogResult.OK) bar.ValueColor = ColorD.Color;
            Preview();
        }

       
     
    }
}