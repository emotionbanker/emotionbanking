using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Calculation.Template.Controls;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Template.Wizard
{
    public class TemplateWizardPage : BaseWizardPage
    {
        private readonly TemplateWizardPageControl _control;
        private readonly TemplateFileSelectorController _loadController;
        private readonly TemplateFileSelectorController _saveController;

        public Boolean SaveToFile
        {
            get { return _control._saveToFile.Checked; }
        }

        public Boolean LoadFromFile
        {
            get { return _control._radioFile.Checked; }
        }

        public String SavePath
        {
            get { return _saveController.FileName; }
        }
        public String LoadPath
        {
            get { return _loadController.FileName; }
        }

        public TemplateWizardPage(String header, String xmlTemplateIdentifier)
        {
            _control = new TemplateWizardPageControl();

            _loadController = new TemplateFileSelectorController(_control._loadTemplateSelector, xmlTemplateIdentifier, false);
            _saveController = new TemplateFileSelectorController(_control._saveTemplateSelector, xmlTemplateIdentifier, true);

            Header = header;
            Description = "Choose template settigs.";

            PageControl = _control;

            _control._loadTemplateSelector.Visible = false;
            _control._saveTemplateSelector.Visible = false;

            _control._saveToFile.CheckedChanged += delegate
                                                       {
                                                           _control._saveTemplateSelector.Visible =
                                                               _control._saveToFile.Checked;
                                                       };

            _control._radioFile.CheckedChanged += delegate
                                                      {
                                                          _control._loadTemplateSelector.Visible =
                                                              _control._radioFile.Checked;
                                                      };
        }

        public override void Validate()
        {
            if (_control._saveToFile.Checked)
            {
                if (_saveController.FileName == null)
                {
                    throw new WizardValidationException("Invalid file (save to).");
                }
            }

            if (_control._radioFile.Checked)
            {
                if (_loadController.FileName == null)
                {
                    throw new WizardValidationException("Invalid file (load from).");
                }
            }
            base.Validate();
        }

    }
}
