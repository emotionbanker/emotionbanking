using System;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Calculation.Template.Controls
{
    public class TemplateFileSelectorController
    {
        private readonly TemplateFileSelectorControl _control;
        private readonly string _xmlTemplateIdentifier;
        private readonly bool _saveDialog;

        public String FileName
        {
            get { return _saveDialog ? _control._saveTemplateDialog.FileName : _control._openTemplateDialog.FileName; }
        }

        public TemplateFileSelectorController(TemplateFileSelectorControl control,
            String xmlTemplateIdentifier, bool saveDialog)
        {
            this._control = control;
            _xmlTemplateIdentifier = xmlTemplateIdentifier;
            _saveDialog = saveDialog;

            _control._dialogButton.Click += DialogButtonClick;
        }

        void DialogButtonClick(object sender, EventArgs e)
        {
            if (_saveDialog)
            {
                if (_control._saveTemplateDialog.ShowDialog() == DialogResult.OK)
                {
                    _control._textLocation.Text = _control._saveTemplateDialog.FileName;

                }
            }
            else
            {
                if (_control._openTemplateDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Template t = Template.LoadFromFile(_control._openTemplateDialog.FileName);
                        if (t.XmlTemplateIdentifier != _xmlTemplateIdentifier)
                        {
                            throw new Exception("Wrong template type (was " + t.XmlTemplateIdentifier + ", expected " + _xmlTemplateIdentifier);
                        }
                        _control._textLocation.Text = _control._openTemplateDialog.FileName;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Invalid template file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
