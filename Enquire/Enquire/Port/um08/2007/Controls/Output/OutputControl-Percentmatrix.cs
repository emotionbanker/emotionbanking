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
    public partial class OutputControl_PercentMatrix : UserControl
    {
        public Evaluation eval;
        public SingleMatrix matrix;
        private ChoosePersonControl cpp;
        private Crossing cross;

        private Question horizontal;
        private Question vertical;

        public OutputControl_PercentMatrix(Evaluation eval)
        {
            Init(eval, new SingleMatrix(eval));
        }

        public OutputControl_PercentMatrix(Evaluation eval, SingleMatrix matrix)
        {
            Init(eval, matrix);
        }

        private void Init(Evaluation eval, SingleMatrix matrix)
        {
            this.eval = eval;
            this.matrix = matrix;

            InitializeComponent();

            cpp = new ChoosePersonControl(eval);
            cpp.SelectionChanged += new CppEventHandler(cpp_SelectionChanged);
            cpp.Dock = DockStyle.Fill;

            PersonPanel.Controls.Add(cpp);

            cross = new Crossing(eval);
            cross.Dock = DockStyle.Fill;
            cross.CrossChanged += new CrossEventHandler(cross_CrossChanged);
            crossPanel.Controls.Add(cross);

            cross.UpdateCross(matrix.Cross);

            sizeControl.ChosenSizeChanged += new SizeEventHandler(sizeControl_ChosenSizeChanged);

            StyleBox.Items.Clear();
            StyleBox.Items.Add("4 Verläufe");
            StyleBox.Items.Add("Victor 05");
            StyleBox.Items.Add("Kegel");
            StyleBox.Items.Add("Balken");
            StyleBox.Items.Add("Victor 07");
            StyleBox.Items.Add("4 Verläufe (Ohne Gitter)");
            StyleBox.Items.Add("Victor 05 (Ohne Gitter)");
            StyleBox.Items.Add("4 Verläufe (5x5 Gitter)");
            StyleBox.Items.Add("Verlaufend (5x5 Gitter)");

            PrecBox.Items.Clear();
            PrecBox.Items.Add("3x3");
            PrecBox.Items.Add("5x5");
            PrecBox.Items.Add("2x2");

            SkalaBox.Items.Clear();
            SkalaBox.Items.Add("12-3-45");
            SkalaBox.Items.Add("1-2-345");
            SkalaBox.Items.Add("1-23-45");
            SkalaBox.Items.Add("1-234-5");
            SkalaBox.Items.Add("12-34-5");
            SkalaBox.Items.Add("123-4-5");

            SkalaBox1.Items.Clear();
            SkalaBox1.Items.Add("12-345");
            SkalaBox1.Items.Add("1-2345");
            SkalaBox1.Items.Add("123-45");
            SkalaBox1.Items.Add("1234-5");


            MasterDesignBox.Items.Clear();
            MasterDesignBox.Items.Add("Victor 2006");
            MasterDesignBox.Items.Add("Victor 2007");

            ArrowBox.Checked = matrix.DrawArrow;

            LegendBox.Checked = matrix.Legend;

            //MessageBox.Show("\nStyle: "+matrix.Style+"\nPrecision: "+matrix.Precision+"\nSkala: "+matrix.Skala);
            StyleBox.SelectedIndex = matrix.Style;
            PrecBox.SelectedIndex = matrix.Precision;
            if (PrecBox.SelectedIndex == 0){           
                SkalaBox.SelectedIndex = matrix.Skala;
            }else if (PrecBox.SelectedIndex == 2)
            {
                SkalaBox1.SelectedIndex = matrix.Skala1;
            }
           
            

            MasterDesignBox.SelectedIndex = matrix.Design;

            cpp.SetSelection(matrix.PersonList, matrix.ComboList);

            GlobalRef.Checked = matrix.GlobalRef;

            horizontal = matrix.h;
            vertical = matrix.v;

            try
            {
                HorizontalLabel.Text = horizontal.SID;
                VerticalLabel.Text = vertical.SID;
            }
            catch { }

            DesignButton.Visible = false;

            ArrowColorButton.BackColor = matrix.ArrowColor;

            InvertBox.Checked = matrix.Invert;

            checkBox1.Checked = matrix.InvertY;

            SetStyleControls();
        }


        private void cpp_SelectionChanged()
        {
            matrix.PersonList = cpp.SelectedPersons;
            matrix.ComboList = cpp.SelectedCombos;

            Preview();
        }



        private void sizeControl_ChosenSizeChanged()
        {
            matrix.eval = eval;
            matrix.h = horizontal;
            matrix.v = vertical;
            matrix.PersonList = cpp.SelectedPersons;
            matrix.ComboList = cpp.SelectedCombos;
            matrix.width = sizeControl.ChosenWidth;
            matrix.height = sizeControl.ChosenHeight;
            matrix.Compute();
            previewBox.BigPreview = matrix.OutputImage;
        }

        private void cross_CrossChanged()
        {
            matrix.Cross = cross.cross;
        }

        private void Preview()
        {
            if (horizontal != null && vertical != null && previewBox.Width > 0 && previewBox.Height>35)
            {
                matrix.eval = eval;
                matrix.width = Math.Min(previewBox.Width, previewBox.Height - 35);
                matrix.height = Math.Min(previewBox.Width, previewBox.Height - 35);
                matrix.Compute();
                previewBox.SmallPreview = matrix.OutputImage;

                matrix.width = sizeControl.ChosenWidth;
                matrix.height = sizeControl.ChosenHeight;
                matrix.Compute();
                previewBox.BigPreview = matrix.OutputImage;
            }
        }

        private void HorizontalButton_Click(object sender, System.EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                matrix.h = qs.SelectedQuestion;
                horizontal = qs.SelectedQuestion;
                HorizontalLabel.Text = horizontal.SID;

                Preview();
            }
        }

        private void VerticalButton_Click(object sender, System.EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                matrix.v = qs.SelectedQuestion;
                vertical = qs.SelectedQuestion;
                VerticalLabel.Text = vertical.SID;

                Preview();
            }
        }

        private void ArrowBox_CheckedChanged(object sender, System.EventArgs e)
        {
            matrix.DrawArrow = ArrowBox.Checked;
            Preview();
        }

        private void StyleBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            matrix.Style = StyleBox.SelectedIndex;
            Preview();
        }

        private void LegendBox_CheckedChanged(object sender, System.EventArgs e)
        {
            matrix.Legend = LegendBox.Checked;
            Preview();
        }

        private void PrecBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //MessageBox.Show("PrecBox_SelectedIndexChanged");
            matrix.Precision = PrecBox.SelectedIndex;
            
            if (PrecBox.SelectedIndex == 0) //3x3
            {
                SkalaBox.Visible = true;
                SkalaBox1.Visible = false;
            }
            else if (PrecBox.SelectedIndex == 1) //5x5
            {
                SkalaBox.Visible = false;
                SkalaBox1.Visible = false;
            }
            else
            { //2x2
                SkalaBox.Visible = false;
                SkalaBox1.Visible = true;
            }
            //matrix.Skala = SkalaBox.SelectedIndex;
            //SkalaBox.SelectedIndex = matrix.Skala;
            Preview();
        }

        private void MasterDesignBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            matrix.Design = MasterDesignBox.SelectedIndex;
            SetStyleControls();
            Preview();
        }

        private void SetStyleControls()
        {
            //disable all
            ArrowBox.Visible = true;
            StyleBox.Visible = true;
            //PrecBox.Visible = false;
            ArrowColorButton.Visible = false;

            DesignButton.Visible = false;

            //enable
            if (matrix.Design == SingleMatrix.Victor2006)
            {
                StyleBox.Visible = true;
                //PrecBox.Visible = true;
            }
            else if (matrix.Design == SingleMatrix.Victor2007)
            {
                //ShadingBox.Visible = true;
                DesignButton.Visible = true;
                ArrowColorButton.Visible = true;
            }
        }

        private void DesignButton_Click(object sender, EventArgs e)
        {
            ChartingSettings cs = new ChartingSettings(matrix.dnc);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                matrix.dnc = cs.Settings;
                Preview();
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            matrix.eval = eval;
            matrix.Cross = cross.Cross;
            matrix.width = sizeControl.ChosenWidth;
            matrix.height = sizeControl.ChosenHeight;

			SaveDialog sd = new SaveDialog(matrix);
			sd.ShowDialog();
        }

        private void OutputControl_PercentMatrix_SizeChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void previewBox_Load(object sender, EventArgs e)
        {

        }

        private void ArrowColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = matrix.ArrowColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                matrix.ArrowColor = colorDialog1.Color;
                ArrowColorButton.BackColor = matrix.ArrowColor;
                Preview();
            }
        }

        private void InvertBox_CheckedChanged(object sender, EventArgs e)
        {
            matrix.Invert = InvertBox.Checked;
            Preview();
        }

        private void GlobalRef_CheckedChanged(object sender, EventArgs e)
        {
            matrix.GlobalRef = GlobalRef.Checked;
            Preview();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            matrix.InvertY = checkBox1.Checked;
            Preview();
        }

        private void SkalaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            matrix.Skala = SkalaBox.SelectedIndex;
            Preview();
        }

        private void SkalaBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            matrix.Skala1 = SkalaBox1.SelectedIndex;
            Preview();
        }

    }
}