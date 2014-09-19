using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace UMXAddin3
{
    public class LinkData
    {
        public string Settings;
        public int ContentLength;

        public void LoadFromString(String raw)
        {
            //check type
            if (raw.StartsWith("ADDIN umo"))
            {
                //basic
                Settings = raw;
            }
            if (raw.StartsWith("<addinumo>"))
            {
                //xml
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(raw);
                Settings = xdoc.GetElementsByTagName("settings")[0].InnerText;
                ContentLength = Int32.Parse(xdoc.GetElementsByTagName("length")[0].InnerText);
            }
        }

        public string ToBasicString()
        {
            return Settings;
        }

        public string ToXmlString()
        {
            return "<addinumo><settings><![CDATA[" + Settings + "]]></settings><length>" + ContentLength + "</length></addinumo>";
        }
    }
}
