using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Enquire.EnquireServer.ContentEditors
{
    public class BaseContentEditorController
    {
        private readonly BaseContentEditor _control;

        public Image HeadImage
        {
            get { return _control._headPicture.Image; }
            set { _control._headPicture.Image = value; }
        }

        public String Header
        {
            get { return _control._headLabel.Text; }
            set { _control._headLabel.Text = value; }
        }

        public Control Content
        {
            get
            {
                return _control._contentPanel.Controls.Count > 0 ? _control._contentPanel.Controls[0] : null;
            }
            set
            {
                _control._contentPanel.Controls.Clear();
                _control._contentPanel.Controls.Add(value);
                value.Dock = DockStyle.Fill;
            }
        }

        public Control Control
        {
            get { return _control; }
        }

        public BaseContentEditorController(BaseContentEditor control)
        {
            _control = control;
        }
    }
}
