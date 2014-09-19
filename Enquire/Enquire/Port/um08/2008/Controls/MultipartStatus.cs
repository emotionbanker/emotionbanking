using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace umfrage2._2008
{
    public delegate void DoneEventHandler();
    public partial class MultipartStatus : UserControl
    {
        public event DoneEventHandler Done;

        public MultipartStatus()
        {
            InitializeComponent();

            MarqueeBar.Location = SingleBar.Location;
            MarqueeBar.Size = SingleBar.Size;

            Done += new DoneEventHandler(MultipartStatus_Done);
        }

        void MultipartStatus_Done()
        {
            //do nothing
        }

        public void Continue()
        {
            Done();
        }
    }
}
