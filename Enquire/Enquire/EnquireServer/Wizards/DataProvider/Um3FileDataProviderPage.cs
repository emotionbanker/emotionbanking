using System;
using System.IO;
using System.Windows.Forms;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.EnquireServer.Wizards.DataProvider
{
    public class Um3FileDataProviderPage : BaseWizardPage
    {
        private readonly Um3FileDataProviderPageControl _control;

        public String FileName
        {
            get { return _control._textBoxFile.Text; }
            set { _control._textBoxFile.Text = value; }
        }

        public String DisplayName
        {
            get { return _control._namingControl.DisplayName; }
            set { _control._namingControl.DisplayName = value; }
        }

        public String ProviderDescription
        {
            get { return _control._namingControl.Description; }
        }

        public Um3FileDataProviderPage()
        {
            _control = new Um3FileDataProviderPageControl();

            PageControl = _control;

            DisplayName = "File Data Provider";

            Header = "Select Data File";
            Description = "Choose the UMV 2008 data file.";

            AllowFinish = true;

            _control._selectFileButton.Click += _selectFileButton_Click;
        }

        private void _selectFileButton_Click(object sender, EventArgs e)
        {
            if (_control._openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = _control._openFileDialog.FileName;
            }
        }


        public override void Validate()
        {
            if (!File.Exists(FileName))
            {
                throw new WizardValidationException("Chosen file does not exist.");
            }

            if (String.IsNullOrWhiteSpace(DisplayName))
            {
                throw new WizardValidationException("A name must be specified.");                
            }
        }
    }
}
