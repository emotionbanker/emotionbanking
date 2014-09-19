using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

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

            OutputNameControl onc = new OutputNameControl(matrix);
            onc.Location = new Point(15, 10);
            onc.Width = previewBox.Width;

            Controls.Add(onc);

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

            PrecBox.Items.Clear();
            PrecBox.Items.Add("3x3");
            PrecBox.Items.Add("5x5");

            MasterDesignBox.Items.Clear();
            MasterDesignBox.Items.Add("Victor 2006");
            MasterDesignBox.Items.Add("Victor 2007");

            ArrowBox.Checked = matrix.DrawArrow;

            LegendBox.Checked = matrix.Legend;

            StyleBox.SelectedIndex = matrix.Style;

            PrecBox.SelectedIndex = matrix.Precision;

            MasterDesignBox.SelectedIndex = matrix.Design;

            DesignButton.Visible = false;
            DesignButton.Location = StyleBox.Location;

           

            SetStyleControls();
        }


        private void cpp_SelectionChanged()
        {
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
            //if (horizontal != null && vertical != null)
            {
                matrix.eval = eval;
                matrix.h = horizontal;
                matrix.v = vertical;
                matrix.width = Math.Min(previewBox.Width, previewBox.Height - 35);
                matrix.height = Math.Min(previewBox.Width, previewBox.Height - 35);
                matrix.PersonList = cpp.SelectedPersons;
                matrix.ComboList = cpp.SelectedCombos;

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
            matrix.Precision = PrecBox.SelectedIndex;
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

            ArrowBox.Visible = false;
            StyleBox.Visible = false;
            //PrecBox.Visible = false;

            DesignButton.Visible = false;

            //enable
            if (matrix.Design == SingleMatrix.Victor2006)
            {
                ArrowBox.Visible = true;
                StyleBox.Visible = true;
                //PrecBox.Visible = true;
            }
            else if (matrix.Design == SingleMatrix.Victor2007)
            {
                //ShadingBox.Visible = true;
                DesignButton.Visible = true;
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
    }
}