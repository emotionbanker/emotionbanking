using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Compucare.Enquire.Common.PersistenceModule.Server.UserManagement;

namespace Compucare.Enquire.EnquireServer.Controls
{
    public class UserManagementController
    {
        private readonly UserManagementControl _control;
        private readonly EnquireServer _server;
        private readonly UserManagementProvider _provider;

        public UserManagementController(UserManagementControl control,
            EnquireServer server)
        {
            _control = control;
            _server = server;

            _provider = new UserManagementProvider(_server.ServerDataConnection);

            _control._addUserButton.Click += new EventHandler(_addUserButton_Click);
            _control._removeUserButton.Click += new EventHandler(_removeUserButton_Click);

            _control._tree.AfterSelect += new TreeViewEventHandler(_tree_AfterSelect);

            _control._listPanel.HeadImage = Pictures.preferences_desktop_user_2;

            ValidateControl();
        }

        void _tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ValidateControl();
        }

        private void ValidateControl()
        {
            _control._removeUserButton.Enabled = _control._tree.SelectedNode != null;
        }

        void _removeUserButton_Click(object sender, EventArgs e)
        {
            _provider.RemoveUser(_control._tree.SelectedNode.Tag as String);
            Initialize();
        }

        void _addUserButton_Click(object sender, EventArgs e)
        {
            String newUser = "NewUser";
            int i = 2;
            while (_provider.UserExists(newUser))
            {
                newUser = "NewUser" + i;
                i++;
            }
            _provider.AddUser(newUser, "");
            Initialize();
        }

        public void Initialize()
        {
            _control._tree.Nodes.Clear();

            foreach (Tuple<String,String> user in _provider.GetUserList())
            {
                TreeNode node = _control._tree.Nodes.Add(user.Item1, user.Item1, 0, 0);
                node.Tag = user.Item1;
            }

            ValidateControl();
        }
    }
}
