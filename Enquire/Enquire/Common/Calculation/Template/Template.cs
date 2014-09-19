using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Compucare.Enquire.Common.Calculation.Template
{
    public class Template
    {
        private readonly XmlDocument _doc;

        public static String TYPE_ATTRIBUTE = "type";

        public static Template LoadFromFile(String filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            return new Template(doc);
        }

        private Template(XmlDocument doc)
        {
            _doc = doc;
        }

        public String XmlTemplateIdentifier
        {
            get
            {
                return _doc.DocumentElement.GetAttribute(TYPE_ATTRIBUTE);
            }
        }
    }
}
