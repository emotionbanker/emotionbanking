using System;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.Controls.Utils;
using Compucare.Enquire.Legacy.Umfrage2Lib.Script;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Forms;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Texts.Script.Wizard.WizardPages
{
    public class ExpressionWizardPage : BaseWizardPage
    {
        private readonly Evaluation _eval;
        private readonly TargetData _targetData;
        private readonly ExpressionWizardPageControl _control;
        private readonly DropDownTextBoxController _usergController;
        private readonly EnquireScript _script;

        internal String Expression
        {
            get { return _control._expression.Text; }
        }

        internal PersonSetting UserGroup
        {
            get { return _usergController.SelectedItem.Value as PersonSetting; }
        }

        public ExpressionWizardPage(Evaluation eval, TargetData targetData)
        {
            _eval = eval;
            _targetData = targetData;
            _control = new ExpressionWizardPageControl();
            PageControl = _control;

            _usergController = new DropDownTextBoxController(_control._personBox);
            _usergController.Images = new ImageList();
            _usergController.Images.Images.Add(Pictures.system_users_4);

            Header = "Expression Settings";
            Description = "Enter the expression and specify the expression options.";

            _script = new EnquireScript(_eval, _targetData);

            _control._testButton.Click += TestButtonClick;
            _usergController.SelectionChanged += UsergControllerSelectionChanged;
        }

        ~ExpressionWizardPage()
        {
            _control._testButton.Click -= TestButtonClick;
            _usergController.SelectionChanged -= UsergControllerSelectionChanged;
        }


        private void UsergControllerSelectionChanged(object arg1)
        {
            _script.SetUserGroup(UserGroup);
        }

        private void TestButtonClick(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(_control.ParentForm, Evaluate(), "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
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
