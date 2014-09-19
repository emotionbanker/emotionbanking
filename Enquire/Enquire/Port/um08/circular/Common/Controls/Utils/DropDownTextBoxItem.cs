using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Controls.Utils
{
    public class DropDownTextBoxItem
    {
        private readonly String _displayName;
        private Object _value;
        private readonly TreeNode _node;
        private Boolean _checked;

        public Object Value
        {
            get { return _value; }
            set 
            { 
                _value = value;
                _node.Tag = value;
            }
        }

        public TreeNode Node
        {
            get { return _node; }
        }

        public Boolean Checked
        {
            get { return _checked; }
            set 
            { 
                _checked = value;
                _node.Checked = value;
            }
        }

        public int ImageIndex
        {
            get { return _node.ImageIndex; }
            set { _node.ImageIndex = _node.SelectedImageIndex = value; }
        }

        public DropDownTextBoxItem(String displayName, object value)
        {
            _displayName = displayName;
            _value = value;
            _node = new TreeNode(_displayName);
            _node.Tag = this;
        }

        public override string ToString()
        {
            return _displayName;
        }
    }
}
