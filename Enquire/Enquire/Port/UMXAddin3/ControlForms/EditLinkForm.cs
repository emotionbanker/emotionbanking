using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Office.Interop.PowerPoint;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    public partial class EditLinkForm : Form
    {
        private AppType _appType;
        private List<Shape> _shapeList;
        private List<Microsoft.Office.Interop.Word.Field> _fieldList;
        private Microsoft.Office.Interop.Word.Document _doc;

        public class LinkData
        {
            public string Code = "";
            public List<String> Data;
            public string OID;
            public string Crosses;
            public string Basis;

            public LinkData(string code)
            {
                Code = code;
                Data = new List<string>();

                string[] master = (code + "|").Split(new char[] { '|' });

                foreach (string v in master[0].Split(new char[] { ':' }))
                    Data.Add(v);

                OID = master[1];
                Crosses = master[2];
                Basis = master[3];
            }

            public override string ToString()
            {
                return Data[1] + "/" + Data[2];
            }
        }

        public EditLinkForm()
        {
            InitializeComponent();

            this.CancelButton = cancelButton;
        }

        public void SetData(List<Microsoft.Office.Interop.Word.Field> fields, Microsoft.Office.Interop.Word.Document doc)
        {
            _appType = AppType.Word;
            WordSetButton.Visible = true; 
            _doc = doc;

            _fieldList = new List<Microsoft.Office.Interop.Word.Field>();

            LinkList.Items.Clear();

            foreach (Microsoft.Office.Interop.Word.Field s in fields)
            {
                LinkList.Items.Add(new LinkData(s.Code.Text));
                _fieldList.Add(s);
            }
        }

        public void SetData(List<Microsoft.Office.Interop.PowerPoint.Shape> shapeList)
        {
            _appType = AppType.PowerPoint;
            WordSetButton.Visible = false;

            _shapeList = new List<Shape>();

            LinkList.Items.Clear();

            foreach (Shape s in shapeList)
            {
                LinkList.Items.Add(new LinkData(s.Tags["umxcode"]));
                _shapeList.Add(s);
            }
        }

        private void ReplaceeButton_Click(object sender, EventArgs e)
        {
            int rcount = 0;

            if (_appType == AppType.PowerPoint)
            {
                foreach (Shape s in _shapeList)
                {
                    string rep =  s.Tags["umxcode"].Replace(SearchString.Text, ReplaceString.Text);
                    if (!rep.Equals(s.Tags["umxcode"])) rcount ++;
                    s.Tags.Delete("umxcode");
                    s.Tags.Add("umxcode", rep);
                }

                SetData(_shapeList);
            }
            else if (_appType == AppType.Word)
            {
                foreach (Microsoft.Office.Interop.Word.Field f in _fieldList)
                {
                    string rep = f.Code.Text.Replace(SearchString.Text, ReplaceString.Text);
                    if (!rep.Equals(f.Code.Text)) rcount++;
                    f.Code.Text = rep;
                }

                SetData(_fieldList, _doc);
            }

            MessageBox.Show(rcount + " der ausgewählten Verknüpfungen wurden verändert", "Suchen und ersetzen", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowInfo(string dat)
        {
            string d = string.Empty;

            string[] master = (dat + "|").Split(new char[] { '|' });

            d += "Verknüpfungsdaten:\n\n";

            int i = 0;
            foreach (string v in master[0].Split(new char[] { ':' }))
                d += (i++) + ": " + v + "\n";

            d += "\n";

            d += "Word Object ID: " + master[1] + "\n";
            d += "Kreuzungen: " + master[2] + "\n";
            d += "Prozentbasis: " + master[3];

            MessageBox.Show(d, "Eigenschaften", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LinkList.SelectedItem != null)
            {
                ShowInfo( ((LinkData)LinkList.SelectedItem).Code);
            }
        }

        private void LinkList_DoubleClick(object sender, EventArgs e)
        {
            if (LinkList.SelectedItem != null)
            {
                ShowInfo(((LinkData)LinkList.SelectedItem).Code);
            }
        }

        private int GetNext()
        {
            int max = 0;
            try
            {
                foreach (Microsoft.Office.Interop.Word.Field f in _doc.Fields)
                {
                    if (f.Code.Text.StartsWith(" ADDIN umo:"))
                    {
                        string[] master = f.Code.Text.Split(new char[] { '|' });

                        if (master.Length > 1 && Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                    }
                }
                foreach (Microsoft.Office.Interop.Word.Shape s in _doc.Shapes)
                {
                    try
                    {
                        foreach (Microsoft.Office.Interop.Word.Field sf in s.TextFrame.TextRange.Fields)
                        {
                            string[] master = sf.Code.Text.Split(new char[] { '|' });

                            if (master.Length > 1 && Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch { }

            return max+1;
        }

        private void WordSetButton_Click(object sender, EventArgs e)
        {
            foreach (Microsoft.Office.Interop.Word.Field f in _fieldList)
            {
                string[] master = f.Code.Text.Split(new char[] { '|' });

                master[1] = GetNext().ToString();

                f.Code.Text = String.Join("|", master);
            }

            

            MessageBox.Show("Alle Word-IDs wurden angepasst", "IDs anpassen", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}