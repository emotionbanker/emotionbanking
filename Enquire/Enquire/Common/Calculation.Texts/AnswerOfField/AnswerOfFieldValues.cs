using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.DataModule.Xml;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Xml;

namespace Compucare.Enquire.Common.Calculation.Texts.AnswerOfField
{
    public class AnswerOfFieldValues : IXmlTransformable
    {
        public const String TagRoot = "Settings";
        public const String TagFrage = "Frage";
        public const String TagPersonengruppe = "Personengruppe";
      
        private int frage;
        private string personengruppe;

        public AnswerOfFieldValues()
        {
            this.frage = 0;
            this.personengruppe = "";
        }

        public AnswerOfFieldValues(string xml, Evaluation eval)
        {
            FromXml(xml, eval);
        }

        public string ToXml()
        {
            XmlDocument doc = new XmlDocument();

            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement(TagRoot));
            root.AppendChild(doc.CreateElement(TagFrage)).InnerText = getFrage().ToString();
            root.AppendChild(doc.CreateElement(TagPersonengruppe)).InnerText = getPersonengruppe().ToString();
            return doc.OuterXml;
        }//ToXml

        public void FromXml(string xmlString, Evaluation eval)
        {
                // erstellt ein Xml Dokument
                XmlDocument doc = new XmlDocument();

                //wandelt xmlString in ein XmlDokument um
                doc.LoadXml(xmlString);

                //definiert den wurzel element
                XmlElement root = doc.DocumentElement;
                setFrage(Int32.Parse(root.GetElementsByTagName(TagFrage)[0].InnerText));
                setPersonengruppe(root.GetElementsByTagName(TagPersonengruppe)[0].InnerText);
        }//FromXml

        public int getFrage()
        {
            return this.frage;
        }

        public void setFrage(int frage)
        {
            this.frage = frage;
        }

        public string getPersonengruppe()
        {
            return this.personengruppe;
        }

        public void setPersonengruppe(string pergruppe)
        {
            this.personengruppe = pergruppe;
        }
    }
}
