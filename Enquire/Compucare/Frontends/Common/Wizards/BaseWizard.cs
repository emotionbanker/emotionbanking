using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Compucare.Frontends.Common.Wizards
{
    public enum WizardButton
    {
        Cancel,
        Finish,
        Next,
        Back
    }

    public class BaseWizard
    {
        private readonly BaseWizardForm _form;
        private Bitmap _icon;

        public Bitmap Icon
        {
            get { return _icon; }
            set { _icon = value; _form.Icon = System.Drawing.Icon.FromHandle(value.GetHicon()); }
        }

        public String Text
        {
            get { return _form.Text; }
            set { _form.Text = value; }
        }

        public Image PageHeadImage
        {
            get { return _form._headPicture.Image; }
            set { _form._headPicture.Image = value; }
        }

        public String PageHeader
        {
            get { return _form._labelStepHeader.Text; }
            set { _form._labelStepHeader.Text = value; }
        }

        public String PageSubHeader
        {
            get { return _form._labelStepDesc.Text; }
            set { _form._labelStepDesc.Text = value; }
        }

        private readonly List<BaseWizardPage> _wizardPages;

        public BaseWizardPage CurrentPage
        {
            get { return _pagePosition < _wizardPages.Count ? _wizardPages[_pagePosition] : new BaseWizardPage(); }
        }

        public bool AskOnCancel { get; set; }

        public DialogResult DialogResult { get { return _form.DialogResult; } }

        private int _pagePosition;
        private int _userPagePosition;
        private WizardButton _lastButton;
        
        public BaseWizard()
        {
            _form = new BaseWizardForm();

            _wizardPages = new List<BaseWizardPage>();
            
            Icon = Pictures.tools_wizard_3;
            PageHeadImage = Pictures.tools_wizard_3_48;

            
            Text = "BaseWizard";

            _form._buttonCancel.Click += ButtonCancelClick;
            _form._buttonFinish.Click += ButtonFinishClick;
            _form._buttonNext.Click += ButtonNextClick;
            _form._buttonBack.Click += ButtonBackClick;

            //_form.CancelButton = _form._buttonCancel;
            _form.Closing += FormClosing;
        }

        void FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((_lastButton != WizardButton.Finish) && AskOnCancel && MessageBox.Show("All entered data will be lost. Are you sure you want to cancel?", "Cancel Wizard", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                OnCancel();
            }
        }

        void ButtonBackClick(object sender, EventArgs e)
        {
            Back();
        }

        private void Back()
        {
            _lastButton = WizardButton.Back;
            _pagePosition--;
            if (_pagePosition < 0) _pagePosition = 0;
            _userPagePosition--;
            SetPage();
        }

        private void ButtonNextClick(object sender, EventArgs e)
        {
            Next(true);
        }

        private void Next(bool validate)
        {
            _lastButton = WizardButton.Next;

            if (validate)
            {
                if (!ValidatePage()) return;
            }

            OnBeforeNext();

            _pagePosition++;
            _userPagePosition++;
            SetPage();
        }

        public bool ValidatePage()
        {
            try
            {
                _form._errorLabel.Text = "";
                CurrentPage.Validate();
            }
            catch (WizardValidationException ex)
            {
                _form._errorLabel.Text = ex.Message;
                return false;
            }
            return true;
        }

        private void ButtonFinishClick(object sender, EventArgs e)
        {
            _lastButton = WizardButton.Finish;
            Finish();
        }

        private void Finish()
        {
            if (!ValidatePage()) return;

             OnFinish();
            _form.Close();
            _form.DialogResult = DialogResult.OK;
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            _lastButton = WizardButton.Cancel;
            _form.Close();
            _form.DialogResult = DialogResult.Cancel;
        }

        private void SetPage()
        {
            OnBeforeSetPage();

            _form._contentPanel.Controls.Clear();

            if (_pagePosition < _wizardPages.Count)
            {
                CurrentPage.PageControl.Dock = DockStyle.Fill;

                _form._contentPanel.Controls.Add(CurrentPage.PageControl);

                PageHeader = String.Format("Step {0}: {1}", _userPagePosition + 1, CurrentPage.Header);
                PageSubHeader = CurrentPage.Description;

                _form._buttonBack.Enabled = _pagePosition > 0 && CurrentPage.AllowBack;
                _form._buttonNext.Enabled = (_pagePosition + 1) < _wizardPages.Count && CurrentPage.AllowNext;
                _form._buttonFinish.Enabled = CurrentPage.AllowFinish;

                CurrentPage.Activate();
            }
            else
            {
                _pagePosition = _wizardPages.Count;
                PageHeader = String.Format("Step {0}: Unknown Page", _userPagePosition + 1);
                PageSubHeader = "This wizard page is not implemented.";

                _form._buttonBack.Enabled = CurrentPage.AllowBack;
                _form._buttonNext.Enabled = false;
                _form._buttonFinish.Enabled = false;
            }

            OnAfterSetPage();
        }

        public void Skip()
        {
            int lastPos = _pagePosition;
            if (_lastButton == WizardButton.Back)
            {
                Back();
                if (lastPos != _pagePosition)
                    _userPagePosition++;
            }
            else if (_lastButton == WizardButton.Next)
            {
                Next(false);
                if (lastPos != _pagePosition)
                    _userPagePosition--;
            }
            SetPage();
        }

        protected virtual void OnBeforeSetPage()
        {
        }

        protected virtual void OnAfterSetPage()
        {
        }

        protected virtual void OnCancel()
        {   
        }

        protected virtual void OnFinish()
        {
        }

        protected virtual void OnBeforeNext()
        {
            
        }

        protected void AddWizardPage(BaseWizardPage page)
        {
            _wizardPages.Add(page);
        }

        public DialogResult ShowDialog()
        {
            //initialise pages
            foreach (BaseWizardPage page in _wizardPages)
            {
                page.Initialise();
            }

            //set first page
            SetPage();
            return _form.ShowDialog();
        }
    }
}
