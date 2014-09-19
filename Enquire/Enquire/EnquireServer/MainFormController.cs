using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Compucare.Enquire.EnquireServer.ContentEditors;
using Compucare.Enquire.EnquireServer.Controls;

namespace Compucare.Enquire.EnquireServer
{
    public class MainFormController
    {
        private readonly MainForm _form;
        private readonly EnquireServer _server;

        private readonly UserManagementController _userManagementController;
        private readonly DataSourceManagementController _datasourceController;

        public MainFormController(MainForm form, EnquireServer server)
        {
            _form = form;
            _server = server;

            _datasourceController = new DataSourceManagementController(_form._dataSourceManagementControl, server);
            _datasourceController.Initialize();


            _userManagementController = new UserManagementController(_form._userManagementControl, server);
            _userManagementController.Initialize();

            server.StatusChanged += new Frontends.Common.Command.CommonEventHandler(server_StatusChanged);
        }


        void server_StatusChanged()
        {
            _form._statusLabel.Text = _server.Status;
        }

        private void LoadControl(Control c)
        {
            _form._contentPanel.Controls.Clear();
            _form._contentPanel.Controls.Add(c);
            c.Dock = DockStyle.Fill;
        }
    }
}
