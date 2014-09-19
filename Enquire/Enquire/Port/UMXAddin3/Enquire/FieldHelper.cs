using System;

namespace Compucare.Enquire.Legacy.UMXAddin3.Enquire
{
    public static class FieldHelper
    {
        public const String ADDIN_PREFIX = " ADDIN umo:";
        public const String MASTER_SEPERATOR = "|";

        public static String CreateCode(String type, String xml, Microsoft.Office.Interop.PowerPoint.Presentation doc, String crosslist, String percentbase)
        {
            return String.Format("{0}{1}:{2}{3}{4}{3}{5}{3}{6}",
                                ADDIN_PREFIX,
                                type,
                                xml,
                                MASTER_SEPERATOR,
                                //GetMax(doc) + 1,
                                null,
                                crosslist,
                                percentbase);
        }

        public static String CreateCode(String type, String xml, Microsoft.Office.Interop.Word.Document doc, String crosslist, String percentbase)
        {
            return String.Format("{0}{1}:{2}{3}{4}{3}{5}{3}{6}",
                                 ADDIN_PREFIX,
                                 type,
                                 xml,
                                 MASTER_SEPERATOR,
                                 GetMax(doc) + 1,
                                 crosslist,
                                 percentbase);
        }

        /*public static int GetMax(Microsoft.Office.Interop.PowerPoint.Presentation doc)
        {
            int max = 0;
            try
            {
                foreach (Microsoft.Office.Interop.PowerPoint f in doc.Fields)
                {
                    if (f.Code.Text.StartsWith(ADDIN_PREFIX))
                    {
                        string[] master = f.Code.Text.Split('|');

                        if (master.Length > 1 && Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                    }
                }
                foreach (Microsoft.Office.Interop.Word.Shape s in doc.Shapes)
                {
                    try
                    {
                        foreach (Microsoft.Office.Interop.Word.Field sf in s.TextFrame.TextRange.Fields)
                        {
                            string[] master = sf.Code.Text.Split('|');

                            if (master.Length > 1 && Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                //powerpoint
                max = 0;
            }

            return max;
        }// end*/ 

        public static int GetMax(Microsoft.Office.Interop.Word.Document doc)
        {
            int max = 0;
            try
            {
                foreach (Microsoft.Office.Interop.Word.Field f in doc.Fields)
                {
                    if (f.Code.Text.StartsWith(ADDIN_PREFIX))
                    {
                        string[] master = f.Code.Text.Split('|');

                        if (master.Length > 1 && Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                    }
                }
                foreach (Microsoft.Office.Interop.Word.Shape s in doc.Shapes)
                {
                    try
                    {
                        foreach (Microsoft.Office.Interop.Word.Field sf in s.TextFrame.TextRange.Fields)
                        {
                            string[] master = sf.Code.Text.Split('|');

                            if (master.Length > 1 && Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                //powerpoint
                max = 0;
            }

            return max;
        }
    }
}
