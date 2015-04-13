using System;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.Controls.Utils;
using Compucare.Enquire.Legacy.Umfrage2Lib.Script;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Forms;
using Compucare.Frontends.Common.Wizards;
using Compucare.Enquire.Common.Controls;

namespace Compucare.Enquire.Common.Calculation.Texts.Script.Wizard.WizardPages
{
    public class ExpressionWizardPage : BaseWizardPage
    {
        private readonly Evaluation _eval;
        private Evaluation[] _mEval;
        private readonly TargetData _targetData;
        private readonly ExpressionWizardPageControl _control;
        private readonly DropDownTextBoxController _usergController;
        private readonly EnquireScript _script;
        private EnquireScript _scriptVergleichsdaten;

        internal String Expression
        {
            get { return _control._expression.Text; }
        }

        internal PersonSetting UserGroup
        {
            get { return _usergController.SelectedItem.Value as PersonSetting; }
        }


        internal String GraphicType()
        {
            if (_control._rBTrafficLight.Checked == true)
                return "Ampel";
            else
                return "Rufzeichen";
               
        }

        internal Boolean ComparisonValue()
        {
            if (_control._checkboxVergleichsdaten.Checked == true)
                return true;
            else
                return false;
        }

        internal int ComparisonValueIndex()
        {
            return _control._comboVergleichsdaten.SelectedIndex+1;
        }

        internal string ComparisonValueTargetData()
        {
            Evaluation eva = _mEval[_control._comboVergleichsdaten.SelectedIndex];
            return eva.getSelectedTargetData().ToString();
        }



        public ExpressionWizardPage(Evaluation eval, TargetData targetData, Evaluation[] mEval)
        {
            _eval = eval;
            _targetData = targetData;
            _mEval = mEval;

            /*int counter = 1;
            foreach(Evaluation e in _mEval){
                if(e != null){
                    _control._comboVergleichsdaten.Items.Add("Vergleichsdaten " + counter);
                }
                counter++;
            }*/

            _control = new ExpressionWizardPageControl();
            PageControl = _control;

            _usergController = new DropDownTextBoxController(_control._personBox);
            _usergController.Images = new ImageList();
            _usergController.Images.Images.Add(Pictures.system_users_4);

            Header = "Expression Settings";
            Description = "Enter the expression and specify the expression options.";

            _script = new EnquireScript(_eval, _targetData);

            _control._testButton.Click += TestButtonClick;
            _control._btnVergleichsdaten.Click += TestButtonClick;
            _control._btnTestAll.Click += TestButtonClick;
            _usergController.SelectionChanged += UsergControllerSelectionChanged;
            _control._checkboxVergleichsdaten.CheckedChanged += VergleichsdatenCheckedChanged;
            _control._comboVergleichsdaten.SelectedValueChanged += VergleichsdatenValueChanged;
        }

        ~ExpressionWizardPage()
        {
            _control._testButton.Click -= TestButtonClick;
            _usergController.SelectionChanged -= UsergControllerSelectionChanged;
        }


        private void VergleichsdatenCheckedChanged(object arg1, EventArgs e)
        {
            if (_control._checkboxVergleichsdaten.Checked)
            {
                _control._comboVergleichsdaten.Enabled = true;
                _control._btnTestAll.Enabled = true;
                _control._btnVergleichsdaten.Enabled = true;
            }
            else
            {
                _control._comboVergleichsdaten.Enabled = false;
                _control._btnTestAll.Enabled = false;
                _control._btnVergleichsdaten.Enabled = false;
            }
        }

        public void VergleichsdatenValueChanged(object arg1, EventArgs e)
        {
            Evaluation eva = _mEval[_control._comboVergleichsdaten.SelectedIndex];
            
            _scriptVergleichsdaten = new EnquireScript(eva, eva.getSelectedTargetData());  
            _scriptVergleichsdaten.SetUserGroup(UserGroup);
        }

        private void UsergControllerSelectionChanged(object arg1)
        {
            _script.SetUserGroup(UserGroup);
            if(_control._checkboxVergleichsdaten.Checked)
                _scriptVergleichsdaten.SetUserGroup(UserGroup);
        }

        private void TestButtonClick(object sender, EventArgs e)
        {
            try
            {
                if(sender.Equals(_control._testButton))
                     MessageBox.Show(_control.ParentForm, Evaluate(), "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
                else if(sender.Equals(_control._btnVergleichsdaten))
                    MessageBox.Show(_control.ParentForm, EvaluateVergleichsdaten(), "Result", MessageBoxButtons.OK, MessageBoxIcon.None);               
                else if (sender.Equals(_control._btnTestAll))
                    MessageBox.Show(_control.ParentForm, EvaluateVergleichsdatenUndEvalution(), "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
               
            }
            catch (Exception ex)
            {
                ExceptionVisualiser.Show(ex);
            }
        }

     

        private String Evaluate()
        {
            return _script.Evaluate(Expression);            
        }

        private String EvaluateVergleichsdaten()
        {
            return _scriptVergleichsdaten.Evaluate(Expression);
        }

        private String EvaluateVergleichsdatenUndEvalution()
        {
            double a = Double.Parse(_script.Evaluate(Expression));
            double b = Double.Parse(_scriptVergleichsdaten.Evaluate(Expression));
            double er = a - b;
            return er.ToString();
         
        }

        public override void Initialise()
        {
            foreach (PersonSetting ps in _eval.CombinedPersons)
            {
                _usergController.AddItem(new DropDownTextBoxPerson(ps));
            }
        }

        public override void Validate()
        {
            if (_usergController.SelectedItem == null)
            {
                throw new WizardValidationException("No user group selected");
            }

            try
            {
                Evaluate();
            }
            catch (Exception)
            {
                throw new WizardValidationException("Expression is not valid.");
            }
        }
    }
}
