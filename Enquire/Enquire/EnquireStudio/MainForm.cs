using System;
using System.ServiceModel;
using System.Windows.Forms;
using Compucare.Enquire.Common.Communication;
using Compucare.Enquire.Common.Communication.Interfaces;

namespace Compucare.Enquire.EnquireStudio
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            
            ChannelFactory<IStatusService> fact = new ChannelFactory<IStatusService>("MyClient");

            IStatusService serverStatus = fact.CreateChannel();

            ServerStatus status = serverStatus.GetServerStatus(ServerVariables.OpenForBusiness);
            MessageBox.Show(status.ToString(), "Foo");

        }
    }
}
