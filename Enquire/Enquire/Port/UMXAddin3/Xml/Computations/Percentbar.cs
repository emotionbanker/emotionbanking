using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.Percentbar;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class Percentbar : IXmlGraphic
    {
        private readonly Evaluation _eval;
        private readonly XmlDocument _doc;
        private readonly TargetData _td;

        public Size Size { get; set; }

        public Percentbar(Evaluation eval, XmlDocument doc, TargetData td)
        {
            _eval = eval;
            _doc = doc;
            _td = td;

            Size = new Size(120, 20);
        }

        public string Store()
        {
            QuestionDataItem qItem = XmlHelper.GetQuestion(_doc.DocumentElement, "Question", _eval);

            PercentBar pb = new PercentBar();
            pb.Evaluation = _eval;
            pb.Question = _td.GetQuestionById(qItem.QuestionId);
            pb.PersonSetting = qItem.Persons[0];

            Dictionary<Int32,Color> colors = new Dictionary<int, Color>();

            colors.Add(1, Color.FromArgb(Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement,"C1"))));
            colors.Add(2, Color.FromArgb(Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement,"C2"))));
            colors.Add(3, Color.FromArgb(Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement,"C3"))));
            colors.Add(4, Color.FromArgb(Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement,"C4"))));
            colors.Add(5, Color.FromArgb(Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement,"C5"))));

            pb.Colors = colors;

            string tempName = System.IO.Path.GetTempFileName() + ".png";
            pb.Compute();
            ((Image)pb.Result).Save(tempName);
            return tempName;
        }
    }
}
