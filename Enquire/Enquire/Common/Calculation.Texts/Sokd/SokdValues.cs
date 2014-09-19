using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.DataModule.Xml;
using System.Xml;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Common.Calculation.Texts.Sokd
{
    public class SokdValues : IXmlTransformable
    {

        public const String TagRoot = "SokdSettings";
        public const String TagJahr = "Jahr";
        public const String TagJahr2 = "Jahr_2";
        public const String TagQuestion = "FragenId";
        public const String TagBlz = "Blz";
        public const String TagBlz2 = "Blz2";
        public const String TagGrafik = "isGrafik";
        public const String TagGrafik2 = "Vergleichswert";
        public const String TagWert = "Wert";
        public const String TagPercent = "Prozent";
        public const String TagSpalte = "SpaltenId";
        public const String TagSpaltenText = "Spaltentext";
        private double wert;
        private int jahr;
        private int jahr2;
        private int frage;
        private int blz;
        private int blz2;
        private bool isGrafik;
        private bool isGrafikValue;
        private bool isPercent;
        private int spaltenId;
        private string spaltenText;


        public SokdValues()
        {
           this.isPercent = false;
           this.isGrafik = false;
           this.isGrafikValue = false;
           this.jahr = 0;
           this.wert = 0.0;
           this.frage = 0;
           this.blz = 0;
           this.blz2 = 0;
           this.spaltenId = 0;
           this.spaltenText = "";
        }

        public SokdValues(string xml, Evaluation eval)
        {
            FromXml(xml, eval);
        }

        public string ToXml()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement(TagRoot));
                root.AppendChild(doc.CreateElement(TagJahr)).InnerText = getJahr().ToString();
                root.AppendChild(doc.CreateElement(TagJahr2)).InnerText = getJahr2().ToString();
                root.AppendChild(doc.CreateElement(TagQuestion)).InnerText = getFrage().ToString();
                root.AppendChild(doc.CreateElement(TagBlz)).InnerText = getBlz().ToString();
                root.AppendChild(doc.CreateElement(TagBlz2)).InnerText = getBlz2().ToString();
                root.AppendChild(doc.CreateElement(TagGrafik)).InnerText = getIsGrafik().ToString();
                root.AppendChild(doc.CreateElement(TagGrafik2)).InnerText = getIsGrafik2().ToString();
                root.AppendChild(doc.CreateElement(TagPercent)).InnerText = getIsPercent().ToString();
                root.AppendChild(doc.CreateElement(TagSpalte)).InnerText = getSpaltenId().ToString();
                root.AppendChild(doc.CreateElement(TagSpaltenText)).InnerText = getSpaltenText().ToString();
            }
            catch
            {

            }
           
           return doc.OuterXml;
        }
       
        public void FromXml(string xmlString, Evaluation eval)
        {
           try
           {
                // erstellt ein Xml Dokument
               XmlDocument doc = new XmlDocument();

               //wandelt xmlString in ein XmlDokument um
               doc.LoadXml(xmlString);

               //definiert den wurzel element
               XmlElement root = doc.DocumentElement;
               setJahr(Int32.Parse(root.GetElementsByTagName(TagJahr)[0].InnerText));
               setJahr2(Int32.Parse(root.GetElementsByTagName(TagJahr2)[0].InnerText));
               setBlz(Int32.Parse(root.GetElementsByTagName(TagBlz)[0].InnerText));
               setBlz2(Int32.Parse(root.GetElementsByTagName(TagBlz2)[0].InnerText));
               setFrage(Int32.Parse(root.GetElementsByTagName(TagQuestion)[0].InnerText));
               setIsGrafik(Convert.ToBoolean(root.GetElementsByTagName(TagGrafik)[0].InnerText));
               setIsGrafik2(Convert.ToBoolean(root.GetElementsByTagName(TagGrafik2)[0].InnerText));
               setIsPercent(Convert.ToBoolean(root.GetElementsByTagName(TagPercent)[0].InnerText));
               setSpaltenId(Int32.Parse(root.GetElementsByTagName(TagSpalte)[0].InnerText));
               setSpaltenText(root.GetElementsByTagName(TagSpaltenText)[0].InnerText);
           }
           catch
           {
               setIsPercent(false);
               setSpaltenId(0);
               setSpaltenText("");
           }
         }//FromXml

        public int getJahr()
        {
            return this.jahr;
        }

        public void setJahr(int jahr)
        {
           this.jahr = jahr;
        }

        public int getJahr2()
        {
            return this.jahr2;
        }

        public void setJahr2(int jahr2)
        {
            this.jahr2 = jahr2;
        }

        public int getFrage()
        {
            return this.frage;
        }

        public void setFrage(int frage)
        {
            this.frage = frage;
        }       

        public double getWert()
        {
            return this.wert;
        }

        public void setWert(double wert)
        {
          this.wert = wert; 
        }

        public int getBlz()
        {
            return this.blz;
        }

        public void setBlz(int blz)
        {
            this.blz = blz;
        }

        public int getBlz2()
        {
            return this.blz2;
        }

        public void setBlz2(int blz2)
        {
            this.blz2 = blz2;
        }

        public bool getIsGrafik()
        {
           return this.isGrafik;
        }

        public void setIsGrafik(bool gr)
        {
            this.isGrafik = gr;
        }

        public bool getIsGrafik2()
        {
            return this.isGrafikValue;
        }

        public void setIsGrafik2(bool gr2)
        {
            this.isGrafikValue = gr2;
        }

        public bool getIsPercent()
        {
            return this.isPercent;
        }

        public void setIsPercent(bool percent)
        {
            this.isPercent = percent;
        }

        public int getSpaltenId()
        {
            return this.spaltenId;
        }

        public void setSpaltenId(int spaltenId)
        {
            this.spaltenId = spaltenId;
        }

        public string getSpaltenText()
        {
            return this.spaltenText;
        }

        public void setSpaltenText(string spaltenText)
        {
            this.spaltenText = spaltenText;
        }
    }
}
