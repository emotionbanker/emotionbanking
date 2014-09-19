using System;
using System.Xml;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations;
using Compucare.Enquire.Common.Calculation.Texts.Sokd;
using System.Windows.Forms;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml
{
    public class XmlHelper
    {
        public static IXmlGraphic ComputeGraphic(String xmlString, TargetData td, Evaluation eval)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            XmlElement dataItem = doc.DocumentElement;

            switch (dataItem.GetAttribute("type"))
            {
                case "exclamation-advanced":
                    return new ExclamationAdvanced(doc, td, eval);
                case "indicatorIcon":
                    return new IndicatorIcon(doc, td, eval);
                case "benchmark":
                    return new Benchmark(eval, doc, td);
                case "comparativeBenchmark":
                    return new ComparativeBenchmark(eval, doc, td);
                case "percentbar":
                    return new Percentbar(eval, doc, td);
                case "graves":
                    return new Graves(eval, doc, td);
                case "sokd":
                    return new SokdGraphic(eval, doc);
            }

            return null;
        }


        public static IXmlText ComputeText(String xmlString, TargetData td, Evaluation eval)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            XmlElement dataItem = doc.DocumentElement;

            switch (dataItem.GetAttribute("type"))
            {
                case "comparativeBenchmarkvalue":
                    return new ComparativeBenchmarkValue(eval, doc, td);
                case "gap":
                    return new LinkGap(doc, td, eval);
                case "expression":
                    return new EnquireExpression(doc, td, eval);
                case "topflop":
                    return new TopFlopItem(doc, td, eval);
                case "matrixCrossing":
                    return new MatrixCrossing(doc, td, eval);
                case "sokd":
                   return new Sokd(eval, doc);
            }

            return null;
        }

        public static Decimal GetPrecision(XmlElement root)
        {
            return Int32.Parse(root.GetElementsByTagName("Precision")[0].InnerText);
        }

        public static String GetInnerText(XmlElement root, String tag)
        {
            return root.GetElementsByTagName(tag)[0].InnerText;
        }

        public static String GetInnerXml(XmlElement root, String tag)
        {
            return root.GetElementsByTagName(tag)[0].InnerXml;
        }

        public static QuestionDataItem GetQuestion(XmlElement root, String tag, Evaluation eval)
        {
            return new QuestionDataItem(root.GetElementsByTagName(tag)[0].InnerXml, eval);
        }

        public static SokdValues GetXml(XmlElement root, String tag, Evaluation eval)
        {
            return new SokdValues(root.GetElementsByTagName(tag)[0].InnerXml, eval);
        }
    }
}
