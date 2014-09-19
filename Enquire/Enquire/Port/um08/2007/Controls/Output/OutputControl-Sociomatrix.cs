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
    public partial class OutputControl_SocioMatrix : UserControl
    {
        public Evaluation eval;
        public SocioMatrix matrix;

        private ChoosePersonControl cpp;
        private Crossing cross;

        private Question horizontal;
        private Question vertical;

        public OutputControl_SocioMatrix(Evaluation eval)
        {
            Init(eval, new SocioMatrix(eval));
        }

        public OutputControl_SocioMatrix(Evaluation eval, SocioMatrix matrix)
        {
            Init(eval, matrix);
        }

        private void Init(Evaluation eval, SocioMatrix matrix)
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

          
            horizontal = matrix._nodeQuestion;
            vertical = matrix._edgeQuestion;

            try
            {
                HorizontalLabel.Text = horizontal.SID;
                VerticalLabel.Text = vertical.SID;
            }
            catch { }

            cpp.SetSelection(matrix.PersonList, matrix.ComboList);

            bubbleHeight.Value = matrix._nodeSize.Height;
            bubbleWidth.Value = matrix._nodeSize.Width;
            bubbleHeight.ValueChanged += new EventHandler(bubbleHeight_ValueChanged);
            bubbleWidth.ValueChanged += new EventHandler(bubbleWidth_ValueChanged);

            minThickControl.Value = (decimal)matrix._edgeMinSize;
            maxThick.Value = (decimal)matrix._edgeMaxSize;

            maxThick.ValueChanged += new EventHandler(maxThick_ValueChanged);
            minThickControl.ValueChanged += new EventHandler(minThickControl_ValueChanged);

            angleControl.Value = matrix._startAngle;
            angleControl.ValueChanged += new EventHandler(angleControl_ValueChanged);

            _colorRange.SettingsChanged += new Compucare.Frontends.Common.Command.CommonEventHandler<Compucare.Enquire.Common.Calculation.Graphics.Common.Controls.ColorRanges.TripleColorRangeControl>(_colorRange_SettingsChanged);

            _colorRange.ColorRange = matrix._colorRange;

            _invertBox.CheckedChanged += delegate { this.matrix._invert = _invertBox.Checked; Preview(); };
            _relativeWeightBox.CheckedChanged += delegate { this.matrix._relativeWeighting = _relativeWeightBox.Checked; Preview(); };

            _invertBox.Checked = matrix._invert;
            _relativeWeightBox.Checked = matrix._invert;

            _nodeModeCombo.Items.Add(SocioMatrix.NodeMode.All);
            _nodeModeCombo.Items.Add(SocioMatrix.NodeMode.Single);
            _nodeModeCombo.Items.Add(SocioMatrix.NodeMode.SingleIn);
            _nodeModeCombo.Items.Add(SocioMatrix.NodeMode.SingleOut);

            _nodeModeCombo.SelectedValueChanged += delegate
                                                       {
                                                           this.matrix._nodeMode = (SocioMatrix.NodeMode) _nodeModeCombo.SelectedItem;
                                                           _comboNodeSelector.Enabled = this.matrix._nodeMode != SocioMatrix.NodeMode.All;
                                                           Preview();
                                                       };

            FillNodeCombo();

            this.matrix._nodeQuestion = horizontal;
            this.matrix._edgeQuestion = vertical;

            _comboNodeSelector.SelectedValueChanged += delegate
                                                           {
                                                               this.matrix._singleNode =
                                                                   _comboNodeSelector.SelectedItem as String;
                                                               Preview();
                                                           };

            _comboNodeSelector.SelectedItem = matrix._singleNode;
            _nodeModeCombo.SelectedItem = matrix._nodeMode;
                   
            Preview();
        }

        void _colorRange_SettingsChanged(Compucare.Enquire.Common.Calculation.Graphics.Common.Controls.ColorRanges.TripleColorRangeControl arg1)
        {
            matrix._colorRange = _colorRange.ColorRange;
            Preview();
        }

        void bubbleWidth_ValueChanged(object sender, EventArgs e)
        {
            matrix._nodeSize.Width = (int)bubbleWidth.Value;
            Preview();
        }

        void bubbleHeight_ValueChanged(object sender, EventArgs e)
        {
            matrix._nodeSize.Height = (int)bubbleHeight.Value;
            Preview();
        }

        void angleControl_ValueChanged(object sender, EventArgs e)
        {
            matrix._startAngle = angleControl.Value;
            Preview();
        }

        void minThickControl_ValueChanged(object sender, EventArgs e)
        {
            matrix._edgeMinSize = (double)minThickControl.Value;
            Preview();
        }

        void maxThick_ValueChanged(object sender, EventArgs e)
        {
            matrix._edgeMaxSize = (double) maxThick.Value;
            Preview();
        }

        private void cpp_SelectionChanged()
        {
            
            matrix.PersonList = cpp.SelectedPersons;
            matrix.ComboList = cpp.SelectedCombos;

            Preview();
        }

        private void Compute()
        {
            matrix.eval = eval;
            matrix._nodeQuestion = horizontal;
            matrix._edgeQuestion = vertical;
            matrix.PersonList = cpp.SelectedPersons;
            matrix.ComboList = cpp.SelectedCombos;
            matrix.width = sizeControl.ChosenWidth;
            matrix.height = sizeControl.ChosenHeight;
            matrix.Compute();
        }

        private void sizeControl_ChosenSizeChanged()
        {
            Compute();
            previewBox.BigPreview = matrix.OutputImage;
            previewBox.SmallPreview = matrix.OutputImage;
        }

        private void cross_CrossChanged()
        {
            matrix.Cross = cross.cross;
        }

        private void Preview()
        {
            Compute();
            previewBox.BigPreview = matrix.OutputImage;
            previewBox.SmallPreview = matrix.OutputImage;
        }

        private void HorizontalButton_Click(object sender, System.EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                matrix._nodeQuestion = qs.SelectedQuestion;
                horizontal = qs.SelectedQuestion;
                HorizontalLabel.Text = horizontal.SID;

                FillNodeCombo();

                Preview();
            }
        }

        private void FillNodeCombo()
        {
            object si = _comboNodeSelector.SelectedItem;
            _comboNodeSelector.Items.Clear();

            if (horizontal != null)
            {
                foreach (String node in horizontal.AnswerList)
                    _comboNodeSelector.Items.Add(node);
            }
        
            _comboNodeSelector.SelectedItem = si;
        }

        private void VerticalButton_Click(object sender, System.EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                matrix._edgeQuestion = qs.SelectedQuestion;
                vertical = qs.SelectedQuestion;
                VerticalLabel.Text = vertical.SID;

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

        private void nodeFontButton_Click(object sender, EventArgs e)
        {
            nodeFontDialog.Font = matrix._nodeFont;
            if (nodeFontDialog.ShowDialog() == DialogResult.OK)
            {
                matrix._nodeFont = nodeFontDialog.Font;
            }
        }
    }
}