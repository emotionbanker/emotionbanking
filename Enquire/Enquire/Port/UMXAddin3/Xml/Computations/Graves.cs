using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.Graves;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class Graves : IXmlGraphic
    {
        private readonly Evaluation _eval;
        private readonly XmlDocument _doc;
        private readonly TargetData _td;

        public Size Size
        {
            get { return GravesSpiral.RawImage.Size; }
        }

        public Graves(Evaluation eval, XmlDocument doc, TargetData td)
        {
            _eval = eval;
            _doc = doc;
            _td = td;
        }

        public string Store()
        {
            string tempName = System.IO.Path.GetTempFileName() + ".png";

            GravesSpiral spiral = new GravesSpiral(_doc, _eval);

            spiral.Compute(_td).Save(tempName, ImageFormat.Png);

            return tempName;
        }
    }
}
