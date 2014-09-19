using System;
using System.Drawing;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class ColControl : UserControl
    {
        public delegate void SelfDeleteDelegate(ColControl sender);

        public event SelfDeleteDelegate SelfDelete;

        public ColControl()
        {
            InitializeComponent();

            foreach (Table.ColTypes s in Enum.GetValues(typeof(Table.ColTypes)))
            {
                ColType.Items.Add(s);
            }

            SelfDelete += new SelfDeleteDelegate(ColControl_SelfDelete);

            SetControls();
        }

        void ColControl_SelfDelete(ColControl sender)
        {
            //
        }

        public void Set(Col c)
        {
            this.Tag = c;
            ColType.SelectedItem = c.Type;
        }

        private void XButton_Click(object sender, EventArgs e)
        {
            SelfDelete(this);
        }

        private void ColType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Col c = (Col)this.Tag;

                if (ColType.SelectedItem != null)
                    c.Type = (Table.ColTypes)ColType.SelectedItem;

                SetControls();
            }
            catch { }
        }

        public void SetControls()
        {
            try
            {
                Col c = (Col)this.Tag;

                if (c.Type == Table.ColTypes.ProzentNachAntwort) // || c.Type == Table.ColTypes.SchachbrettKreuzung)
                {
                    this.SettingsButton.Visible = true;
                }
                else
                {
                    this.SettingsButton.Visible = false;
                }
            }
            catch { }
        }

        public Col GetCol()
        {
            return (Col)this.Tag;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            if (GetCol().Type == Table.ColTypes.ProzentNachAntwort)
            {
                ContextMenu asel = new ContextMenu();

                for (int i=0; i<30; i++)
                {
                    MenuItem mi = new MenuItem();
                    mi.Text = "Antwortmöglichkeit " + (i+1);
                    mi.Tag = i;
                    mi.Click += new EventHandler(mi_Click);

                    if (GetCol().ASel == i) mi.Checked = true;

                    asel.MenuItems.Add(mi);
                }
            

                asel.Show(SettingsButton, new Point(SettingsButton.Width, SettingsButton.Height));
            }
        }

        void mi_Click(object sender, EventArgs e)
        {
            Col c = GetCol();
            c.ASel = (int)((MenuItem)sender).Tag;
        }
    }
}
