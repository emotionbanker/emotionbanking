using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;


namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Pie : UserControl
    {
		private Evaluation eval;
		public Pie pie;
		private ChoosePersonControl cpp;
		private Crossing cross;
		private OutputNameControl onc;
		
		

		private Question question;
		
		private bool single;

		public OutputControl_Pie(Evaluation eval)
		{
			Set(eval, true, new Pie(eval));
		}

		public OutputControl_Pie(Evaluation eval, bool single)
		{
			Set(eval, single, new Pie(eval));
		}

		public OutputControl_Pie(Evaluation eval, bool single, Pie pie)
		{
			Set(eval, single, pie);


			cpp.SetSelection(pie.PersonList, pie.ComboList);

			sizeControl.SetSize(pie.width, pie.height);

			if (pie.q != null)
			{
				question = pie.q;
				QLabel.Text = pie.q.SID;
			}

			UpdateColSel();
			Preview();
		}

		private void Set(Evaluation eval, bool single, Pie pie)
		{
			this.single = single;
			this.eval = eval;
			this.pie = pie;

			InitializeComponent();

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_SizeChanged);

			cpp = new ChoosePersonControl(eval);
            cpp.SetSelection(pie.PersonList, pie.ComboList);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			PersonPanel.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(pie.Cross);

			//onc = new OutputNameControl(pie);
			//onc.Location = new Point(380,16);
			//HeaderPanel.Controls.Add(onc);

			this.CheckRing.Checked = pie.Ring;
            this.ExplodeBox.Checked = pie.Explode;
            this.Box3d.Checked = pie.ThreeD;
            AvgPieBox.Checked = pie.AvgPie;
			this.StartPosBar.Value = pie.StartAngle;

			UpdateColSel();

            MasterDesignBox.Items.Clear();
            MasterDesignBox.Items.Add("Victor 2006");
            MasterDesignBox.Items.Add("Victor 2007");


            MasterDesignBox.SelectedIndex = pie.Design;


            SetStyleControls();
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
            if (question != null)
            {
                pie.q = question;

                pie.height = sizeControl.ChosenHeight;
                pie.width = sizeControl.ChosenWidth;
                pie.PersonList = cpp.SelectedPersons;
                pie.ComboList = cpp.SelectedCombos;

                pie.Compute();

                previewBox.SmallPreview = pie.OutputImage;
                previewBox.BigPreview = pie.OutputImage;
                /*

                if (pie.Design == Output.Victor2007 || !bigOnly)
                {
                    Console.WriteLine("Vorschaufenster");
                    pie.Ring = CheckRing.Checked;
                    pie.q = question;
                    pie.width = previewBox.Width - 10;
                    if (pie.Design == Output.Victor2006) pie.height = (previewBox.Height / 3) * 5 - 20;
                    else pie.height = previewBox.Height - 20;
                    pie.PersonList = cpp.SelectedPersons;
                    pie.ComboList = cpp.SelectedCombos;
                    pie.Compute();
                    if (pie.Design == Output.Victor2006) previewBox.SmallPreview = pie.PieImage;
                    else previewBox.SmallPreview = pie.OutputImage;
                }

                Pie p2 = new Pie(eval);
                p2.StartAngle = StartPosBar.Value;
                p2.Ring = CheckRing.Checked;
                p2.q = question;
                p2.width = sizeControl.ChosenWidth;
                p2.height = sizeControl.ChosenHeight;
                p2.PersonList = cpp.SelectedPersons;
                p2.ComboList = cpp.SelectedCombos;
                p2.Compute();
                if (pie.Design == Output.Victor2006) previewBox.BigPreview = pie.PieImage;
                else previewBox.BigPreview = pie.OutputImage;
                 * */
            }
        }

        private void sizeControl_SizeChanged()
        {
            Preview(true);
        }

        private void cross_CrossChanged()
        {
            pie.Cross = cross.cross;
        }

        private void colsel_ColorChanged()
        {
            Preview();
        }

        private void UpdateColSel()
        {
            ColorPanel.Controls.Clear();
            if (question != null)
            {
                ColorSelector colsel = new ColorSelector(eval, question.AnswerList);
                colsel.Dock = DockStyle.Fill;
                ColorPanel.Controls.Add(colsel);
                colsel.ColorChanged += new ColorChangedEvent(colsel_ColorChanged);
            }
        }

        private void cpp_SelectionChanged()
        {
            Preview();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            pie.eval = eval;
            pie.Cross = cross.Cross;
            pie.width = sizeControl.ChosenWidth;
            pie.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(pie);
            sd.ShowDialog();
        }

        private void HorizontalButton_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                question = qs.SelectedQuestion;
                QLabel.Text = question.SID;

                UpdateColSel();
                Preview();
            }
        }

        private void CheckRing_CheckedChanged(object sender, EventArgs e)
        {
            pie.Ring = CheckRing.Checked;
            Preview();
        }

        private void StartPosBar_Scroll(object sender, EventArgs e)
        {
            pie.StartAngle = StartPosBar.Value;
            Preview();
        }

        

        private void OutputControl_Pie_Load(object sender, EventArgs e)
        {

        }

        private void sizeControl_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void previewBox_Load(object sender, EventArgs e)
        {

        }

        private void SetStyleControls()
        {
            //disable all

            StartPosBar.Visible = false;
            Box3d.Visible = false;
            DesignButton.Visible = false;

            //enable
            if (pie.Design == Pie.Victor2006)
            {
                StartPosBar.Visible = true;
            }
            else if (pie.Design == Pie.Victor2007)
            {
                Box3d.Visible = true;
                DesignButton.Visible = true;
            }
        }


        private void MasterDesignBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pie.Design = MasterDesignBox.SelectedIndex;
            SetStyleControls();
            Preview();
        }

        private void DesignButton_Click(object sender, EventArgs e)
        {
            ChartingSettings cs = new ChartingSettings(pie.dnc);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                pie.dnc = cs.Settings;
                Preview();
            }
        }

        private void QLabel_Click(object sender, EventArgs e)
        {

        }

        private void Box3d_CheckedChanged(object sender, EventArgs e)
        {
            pie.ThreeD = Box3d.Checked;
            Preview();
        }

        private void ExplodeBox_CheckedChanged(object sender, EventArgs e)
        {
            pie.Explode = ExplodeBox.Checked;
            Preview();
        }

        private void AvgPieBox_CheckedChanged(object sender, EventArgs e)
        {
            pie.AvgPie = AvgPieBox.Checked;
            Preview();
        }
    }
}
