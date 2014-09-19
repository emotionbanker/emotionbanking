using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Compucare.Enquire.Common.DataModule.DataProvider;
using Compucare.Enquire.Common.DataModule.DataSource;
using Compucare.Enquire.Common.DataModule.File.Um3;
using Compucare.Enquire.EnquireServer.Wizards.DataProvider;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.EnquireServer.Controls
{
    public class DataSourceManagementController
    {
        private readonly DataSourceManagementControl _control;
        private readonly EnquireServer _server;
        private readonly DataProviderPersistence _provider;

        private TreeNode _tnFiles;
        private TreeNode _tnDatabases;
        private TreeNode _tnRandom;

        public DataSourceManagementController(DataSourceManagementControl control,
            EnquireServer server)
        {
            _control = control;
            _server = server;
            _provider = new DataProviderPersistence(_server.ServerDataConnection);

            _control._listPanel.HeadImage = Pictures.database;

            _control._addDataSourceButton.Click += new EventHandler(_addDataSourceButton_Click);

            _control._tree.MouseUp += new MouseEventHandler(_tree_MouseUp);

            _control._leafGetData.Click += new EventHandler(_leafGetData_Click);
        }

        private void _tree_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                _control._tree.SelectedNode = _control._tree.GetNodeAt(e.X, e.Y);

                if (_control._tree.SelectedNode != null)
                {
                    if (_control._tree.SelectedNode.Tag is BaseEnquireDataProvider)
                    {
                        _control._contextMenuLeaf.Show(_control._tree, e.Location);
                    }
                }
            }
        }

        private void _leafGetData_Click(object sender, EventArgs e)
        {
            String timeString = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fffffff");
            //create data source
            IEnquireDataSource source = ((BaseEnquireDataProvider) _control._tree.SelectedNode.Tag).LoadDataSource(timeString, _server.ServerDataConnection);

            List<TreeNode> nodes = _control._tree.SelectedNode.Nodes.Cast<TreeNode>().ToList();

            _control._tree.SelectedNode.Nodes.Clear();

            //TODO: add to list
            AddDataSource(source, _control._tree.SelectedNode, true);

            foreach (TreeNode node in nodes)
            {
                AddDataSource((IEnquireDataSource)node.Tag, _control._tree.SelectedNode, false);

            }

            //TODO: start data load command
        }

        void _addDataSourceButton_Click(object sender, EventArgs e)
        {
            DataProviderWizard wiz = new DataProviderWizard(_provider);

            wiz.ShowDialog();

            Initialize();
        }

        private void AddProvider(BaseEnquireDataProvider p)
        {
            TreeNode node = new TreeNode(p.DisplayName, 0, 0);
            node.Tag = p;

            if (p is FileUm3DataProvider)
            {
                node.ImageIndex = node.SelectedImageIndex = 1;
                _tnFiles.Nodes.Add(node);
            }

            bool first = true;
            foreach (IEnquireDataSource dataSource in p.DataSources)
            {
                AddDataSource(dataSource, node, first);
                first = false;
            }
        }

        private static void AddDataSource(IEnquireDataSource dataSource, TreeNode parent, bool first)
        {
            TreeNode sourceNode = new TreeNode(dataSource.DisplayName, 2, 2);
            sourceNode.Tag = dataSource;

            sourceNode.ForeColor = first ? Color.Green : Color.Black;

            //color coding
            if (dataSource.Status == "WAITING")
            {
                sourceNode.ForeColor = Color.Orange;
            }
            
            parent.Nodes.Add(sourceNode);
        }

        public void Initialize()
        {
            _control._tree.Nodes.Clear();

            //Add Folders

            _tnFiles = _control._tree.Nodes.Add("_folderFiles", "Files", 0, 0);
            _tnDatabases = _control._tree.Nodes.Add("_folderDatabases", "Databases", 0, 0);
            _tnRandom = _control._tree.Nodes.Add("_folderRandom", "Random", 0, 0);

            foreach (BaseEnquireDataProvider p in _provider.GetProviderList())
            {
                AddProvider(p);
            }
        }
    }
}
