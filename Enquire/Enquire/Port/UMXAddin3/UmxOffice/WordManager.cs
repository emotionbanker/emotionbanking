namespace Compucare.Enquire.Legacy.UMXAddin3.UmxOffice
{
    public class WordManager : UmxOfficeManager
    {
        private Microsoft.Office.Interop.Word.Document _document;

        public void SetDocument(Microsoft.Office.Interop.Word.Document doc)
        {
            _document = doc;
        }

        public override void OnSave()
        {
            //save!
            foreach (Microsoft.Office.Interop.Word.InlineShape shape in _document.InlineShapes)
            {
                try
                {
                    if (shape.AlternativeText.StartsWith("umo"))
                    {
                        string id = shape.AlternativeText.Substring(3);
                        foreach (Microsoft.Office.Interop.Word.Field f in _document.Fields)
                        {
                            if (f.Code.Text.StartsWith(" ADDIN umo:"))
                            {
                                string[] master = (f.Code.Text + "|").Split(new char[] { '|' });
                                string[] param = master[0].Split(new char[] { ':' });

                                if (id.Equals(master[1])) //found!
                                {
                                    param[4] = "" + shape.Width;
                                    param[5] = "" + shape.Height;

                                    f.Code.Text = " ADDIN umo";

                                    for (int i = 1; i < param.Length; i++)
                                        f.Code.Text += ":" + param[i];

                                    for (int i = 1; i < master.Length; i++)
                                        f.Code.Text += "|" + master[i];

                                    break;
                                }
                            }
                        }




                    }
                }
                catch { }
            }

            RecursiveShapeSaver(_document.Shapes);
        }

        public static void RecursiveShapeSaver(Microsoft.Office.Interop.Word.Shapes ss)
        {
            foreach (Microsoft.Office.Interop.Word.Shape s in ss)
            {
                try
                {
                    foreach (Microsoft.Office.Interop.Word.InlineShape shape in s.TextFrame.TextRange.InlineShapes)
                    {
                        try
                        {
                            if (shape.AlternativeText.StartsWith("umo"))
                            {
                                string id = shape.AlternativeText.Substring(3);

                                foreach (Microsoft.Office.Interop.Word.Field f in s.TextFrame.TextRange.Fields)
                                {
                                    if (f.Code.Text.StartsWith(" ADDIN umo:"))
                                    {
                                        string[] master = (f.Code.Text + "|").Split(new char[] { '|' });
                                        string[] param = master[0].Split(new char[] { ':' });

                                        if (id.Equals(master[1])) //found!
                                        {
                                            param[4] = "" + shape.Width;
                                            param[5] = "" + shape.Height;

                                            f.Code.Text = " ADDIN umo";

                                            for (int i = 1; i < param.Length; i++)
                                                f.Code.Text += ":" + param[i];

                                            for (int i = 1; i < master.Length; i++)
                                                f.Code.Text += "|" + master[i];

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                            //MessageBox.Show(ex.StackTrace, ex.Message);
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show(ex.StackTrace, ex.Message);
                }
            }
        }
    }
}
