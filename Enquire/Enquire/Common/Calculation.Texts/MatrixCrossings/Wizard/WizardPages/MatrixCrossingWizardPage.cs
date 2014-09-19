using System;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Texts.MatrixCrossings.Wizard.WizardPages
{
    public class MatrixCrossingWizardPage : BaseWizardPage
    {
        private readonly Evaluation _eval;
        private readonly MatrixCrossingWizardPageControl _control;
        private readonly SingleQuestionSelector _qHorizontal;
        private readonly SingleQuestionSelector _qVertical;

        public MatrixCrossingWizardPage(Evaluation eval)
        {
            _eval = eval;
            _control = new MatrixCrossingWizardPageControl();

            PageControl = _control;

            Header = "Matrix Crossing options";
            Description = "Choose the questions and user groups you want to cross.";

            _qHorizontal = new SingleQuestionSelector(_control._qSelectHorizontal);
            _qVertical = new SingleQuestionSelector(_control._qSelectVertical);

            AddListeners();

            UpdateValueSelector();
        }

        public override void Initialise()
        {
            _qHorizontal.LoadItems(_eval);
            _qVertical.LoadItems(_eval);
        }

        private void AddListeners()
        {
            _control._radio2.CheckedChanged += RadioCheckedChanged;
            _control._radio3.CheckedChanged += RadioCheckedChanged;
            _control._radio5.CheckedChanged += RadioCheckedChanged;
        }

        void RadioCheckedChanged(object sender, EventArgs e)
        {
            UpdateValueSelector();
        }

        private void UpdateValueSelector()
        {
            float fact = GetFactor();

            _control._valueSelectionPanel.Controls.Clear();
            _control._valueSelectionPanel.RowCount = (int)fact;
            _control._valueSelectionPanel.ColumnCount = (int)fact;

            _control._valueSelectionPanel.RowStyles.Clear();
            _control._valueSelectionPanel.ColumnStyles.Clear();
            for (int i = 0; i < fact; i++ )
            {
                _control._valueSelectionPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 1 / fact));
                _control._valueSelectionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1 / fact));
            }
            
            //add radios
            for (int x = 0; x < (int)fact; x++)
            {
                for (int y = 0; y < (int)fact; y++)
                {
                    RadioButton rb = new RadioButton();
                    rb.Text = "";
                    rb.Tag = new Point(x, y);
                    _control._valueSelectionPanel.Controls.Add(rb, x, y);
                    if (x == 0 && y == 0)
                    {
                        rb.Checked = true;
                    }
                }
            }
        }

        public override void Validate()
        {
            if (!_qHorizontal.Validate()) throw new WizardValidationException("Question settings are invalid");
            if (!_qVertical.Validate()) throw new WizardValidationException("Question settings are invalid");
        }

        public QuestionDataItem GetHorizontalItem()
        {
            return _qHorizontal.GetDataItem();
        }

        public QuestionDataItem GetVerticalItem()
        {
            return _qVertical.GetDataItem();
        }

        public int GetFactor()
        {
            return _control._radio2.Checked
                           ? 2
                           : _control._radio3.Checked
                                 ? 3
                                 : 5;
        }

        public Point GetValueItem()
        {
            for (int x = 0; x < GetFactor(); x++)
            {
                for (int y = 0; y < GetFactor(); y++)
                {
                    RadioButton rb = (RadioButton) _control._valueSelectionPanel.GetControlFromPosition(x, y);
                    if (rb.Checked)
                    {
                        return new Point(x, y);
                    }
                }
            }
            return new Point(0, 0);
        }
    }
}
