using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Compucare.Enquire.Legacy.Umfrage2Lib;
using Compucare.Frontends.Common.Command;

namespace Compucare.Enquire.Common.Controls.Utils
{
    /// <summary>
    /// TreeView DropDown Controller
    /// </summary>
    public class DropDownTextBoxController
    {
        #region Fields

        private readonly DropDownTextbox _control;
        private readonly List<DropDownTextBoxItem> _items;
        private bool _dropped;

        private DropDownTextBoxItem _selectedItem;
        private readonly List<DropDownTextBoxItem> _selectedItems;

        #endregion Fields

        public DropDownTextBoxItem SelectedItem { get { return _selectedItem; } }
        public List<DropDownTextBoxItem> SelectedItems { get { return _selectedItems; } }

        public Control Control
        {
            get { return _control; }
        }

        #region Events

        public event CommonEventHandler<Object> SelectionChanged;

        #endregion Events

        public ImageList Images { get { return _control._tree.ImageList; } set { _control._tree.ImageList = value; } }

        public Boolean Checkable
        {
            get { return _control._tree.CheckBoxes; }
            set 
            { 
                _control._tree.CheckBoxes = value;
                _control._textbox.ReadOnly = value;
            }
        }

        public DropDownTextBoxController(DropDownTextbox control)
        {
            _control = control;

            _items = new List<DropDownTextBoxItem>();
            _selectedItems = new List<DropDownTextBoxItem>();

            _control._dropButton.Click += DropButtonClick;
            _control._tree.NodeMouseDoubleClick += TreeNodeMouseDoubleClick;
            _control._tree.AfterCheck += TreeAfterCheck;
            _control._tree.KeyDown += TreeKeyDown;
            _control._textbox.KeyDown += TextboxKeyDown;
            _control._textbox.TextChanged += TextboxTextChanged;
            _control._textbox.GotFocus += TextboxGotFocus;
            _control._tree.Leave += TreeLostFocus;
            _control._textbox.MouseWheel += TextboxMouseWheel;
            SelectionChanged += DropDownTextBoxControllerSelectionChanged;

        }

        private void TextboxMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                ShowDropDown(true);
            }
        }

        private void TreeLostFocus(object sender, EventArgs e)
        {
            if (!_control._dropButton.ContainsFocus)
            {
                CloseDropDown();
            }
        }

     
        private void TextboxTextChanged(object sender, EventArgs e)
        {
            if (Checkable) return;

            else Search(_control._textbox.Text);
            if (_control._textbox.Text != "")
            {
                ShowDropDown(false);
            }
            else
            {
                _selectedItem = null;
                EventHelper.Fire(SelectionChanged, _selectedItem);                
                CloseDropDown();
            }
           
        }

        private void TextboxGotFocus(object sender, EventArgs e)
        {
            CloseDropDown();
        }

        private void TextboxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ShowDropDown();
            }
            
            if (e.KeyCode != Keys.Escape) return;

            CloseDropDown();
            e.Handled = true;
            e.SuppressKeyPress = true;
            EventHelper.Fire(SelectionChanged, _selectedItem);
        }

        private void Search(String needle)
        {
            if (!Checkable)
            {
                //check searchlist
                IEnumerable<DropDownTextBoxItem> res = _items.Where(x => x.ToString().Contains(needle));
                SetItems(res);
            }
        }

        private void TreeKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CloseDropDown();
                e.SuppressKeyPress = true;
                e.Handled = true;
                EventHelper.Fire(SelectionChanged, _selectedItem);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                _selectedItem = (DropDownTextBoxItem)_control._tree.SelectedNode.Tag;
                EventHelper.Fire(SelectionChanged, _selectedItem);
                CloseDropDown();
            }
        }

        private void DropDownTextBoxControllerSelectionChanged(object arg1)
        {
            if (arg1 == null)
            {
                return;
            }
            if (Checkable)
            {
                //items
                List<String> items = new List<string>();
                foreach (Object item in (IList)SelectedItems)
                {
                    items.Add(item.ToString());
                }
                _control._textbox.Text = @"{" + String.Join("; ", items.ToArray()) + @"}";
            }
            else
            {
                _control._textbox.Text = SelectedItem.ToString();
            }
        }

        private void TreeAfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked && !_selectedItems.Contains(e.Node.Tag))
            {
                _selectedItems.Add((DropDownTextBoxItem)e.Node.Tag);
            }
            else if (!e.Node.Checked && _selectedItems.Contains(e.Node.Tag))
            {
                _selectedItems.Remove((DropDownTextBoxItem)e.Node.Tag);
            }
            EventHelper.Fire(SelectionChanged, _selectedItems);
        }

        private void TreeNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _selectedItem = (DropDownTextBoxItem)e.Node.Tag;
            EventHelper.Fire(SelectionChanged, _selectedItem);
            CloseDropDown();
        }

        private void DropButtonClick(object sender, EventArgs e)
        {
            if (_dropped) CloseDropDown();
            else ShowDropDown();
        }

        public void StartWait()
        {
            _control._activityIndicator.Visible = true;
        }

        public void StopWait()
        {
            _control._activityIndicator.Visible = false;
        }

        public void ClearItems()
        {
            _items.Clear();
            _control._tree.Nodes.Clear();
        }

        public void AddItem(DropDownTextBoxItem item)
        {
            _items.Add(item);

            //add to dropdown
            _control._tree.Nodes.Add(item.Node);
        }

        public void SetItems(IEnumerable<DropDownTextBoxItem> items)
        {
            _control._tree.Nodes.Clear();
            IEnumerable<TreeNode> nodes = items.Select(x => x.Node);

            foreach (TreeNode node in nodes)
            {
                _control._tree.Nodes.Add(node);
            }
        }

        public void SelectItem<T>(T itemToSelect)
        {
            foreach (DropDownTextBoxItem item in _items)
            {
                if ( ((T)item.Value).Equals(itemToSelect) )
                {
                    _selectedItem = item;
                    _control._tree.SelectedNode = item.Node;        
                }
            }

            EventHelper.Fire(SelectionChanged, _selectedItem);
        }


        public void ShowDropDown()
        {
            ShowDropDown(true);
        }

        public void ShowDropDown(bool focus)
        {
            Form parent = _control.FindForm();

            if (parent == null)
            {
                return;
            }

            Point formPoint = parent.PointToClient(_control.PointToScreen(_control._textbox.Location));
            _control._tree.Location = new Point(formPoint.X, formPoint.Y + _control._textbox.Height);
            
            parent.Controls.Add(_control._tree);
            _control._tree.BringToFront();
            _control._tree.Visible = true;
            _dropped = true;

            _control._dropButton.BackgroundImage = Pictures.arrow_up;

            if (focus) _control._tree.Focus();
        }

        public void CloseDropDown()
        {
            _control._tree.Visible = false;
            _control._dropButton.BackgroundImage = Pictures.arrow_down;
            _dropped = false;
        }
    }
}
