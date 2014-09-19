using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.Percentbar.Wizard.WizardPages
{
    public class PercentBarWizardPage : BaseWizardPage
    {
        private readonly Evaluation _eval;
        private readonly SingleQuestionSelector _q1Selector;

        private readonly PercentBarWizardPageControl _control;

        public PercentBarWizardPage(Evaluation eval)
        {
            _eval = eval;
            _control = new PercentBarWizardPageControl();
            
            Header = "Percent bar settings";
            Description = "Choose the percent bar you want to create.";

            PageControl = _control;

            _q1Selector = new SingleQuestionSelector(_control._selectQ);

            _control._buttonC1.Click += delegate { 
                _control._colorDialog.Color = _control._buttonC1.BackColor;
                if (_control._colorDialog.ShowDialog() == DialogResult.OK)
                    _control._buttonC1.BackColor = _control._colorDialog.Color;};
            
            _control._buttonC2.Click += delegate
            {
                _control._colorDialog.Color = _control._buttonC2.BackColor;
                if (_control._colorDialog.ShowDialog() == DialogResult.OK)
                    _control._buttonC2.BackColor = _control._colorDialog.Color;
            };

            _control._buttonC3.Click += delegate
            {
                _control._colorDialog.Color = _control._buttonC3.BackColor;
                if (_control._colorDialog.ShowDialog() == DialogResult.OK)
                    _control._buttonC3.BackColor = _control._colorDialog.Color;
            };

            _control._buttonC4.Click += delegate
            {
                _control._colorDialog.Color = _control._buttonC4.BackColor;
                if (_control._colorDialog.ShowDialog() == DialogResult.OK)
                    _control._buttonC4.BackColor = _control._colorDialog.Color;
            };

            _control._buttonC5.Click += delegate
            {
                _control._colorDialog.Color = _control._buttonC5.BackColor;
                if (_control._colorDialog.ShowDialog() == DialogResult.OK)
                    _control._buttonC5.BackColor = _control._colorDialog.Color;
            };

            _control._buttonC1.BackColor = Color.Green;
            _control._buttonC2.BackColor = Color.LightGreen;
            _control._buttonC3.BackColor = Color.White;
            _control._buttonC4.BackColor = Color.Red;
            _control._buttonC5.BackColor = Color.DarkRed;
        }

        public override void Initialise()
        {
            _q1Selector.LoadItems(_eval);
        }

        public override void Validate()
        {
            if (!_q1Selector.Validate()) throw new WizardValidationException("Question settings are invalid");
        }

        public QuestionDataItem GetItem()
        {
            return _q1Selector.GetDataItem();
        }

        public Dictionary<Int32, Color> GetColors()
        {
            Dictionary<Int32, Color> retVal = new Dictionary<int, Color>();

            retVal.Add(1, _control._buttonC1.BackColor);
            retVal.Add(2, _control._buttonC2.BackColor);
            retVal.Add(3, _control._buttonC3.BackColor);
            retVal.Add(4, _control._buttonC4.BackColor);
            retVal.Add(5, _control._buttonC5.BackColor);

            return retVal;
        }
    }
}
