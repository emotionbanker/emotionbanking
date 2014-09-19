using System;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class MaturityModel : Form
    {
        public string IString
        {
            get
            {
                string s = "";

                s += List1.Text + ":";
                s += List2.Text + ":";
                s += List3.Text + ":";
                s += List4.Text;

                return s;
            }
        }

        public MaturityModel()
        {
            InitializeComponent();

            this.CancelButton = CButton;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (CheckLists())
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Fehler bei der Eingabe der Fragenlisten - Inkorrektes Format", "Reifegradmodell", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckLists()
        {
            try
            {
               foreach (string id in List1.Text.Split(new char[] { ',' }))
                   Int32.Parse(id.Trim());
               foreach (string id in List2.Text.Split(new char[] { ',' }))
                   Int32.Parse(id.Trim());
               foreach (string id in List3.Text.Split(new char[] { ',' }))
                   Int32.Parse(id.Trim());
               foreach (string id in List4.Text.Split(new char[] { ',' }))
                   Int32.Parse(id.Trim());

            }
            catch
            {
                return false;
            }

            return true;
        }

        private void CButton_Click(object sender, EventArgs e)
        {

        }
    }
}