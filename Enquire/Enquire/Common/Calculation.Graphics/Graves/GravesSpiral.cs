using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Common.Calculation.Graphics.Graves
{
    public class GravesSpiral
    {
        private readonly Evaluation _eval;
        private readonly Dictionary<int, Dictionary<int, QuestionDataItem>> _xmlData;

        private const Int32 X1 = 1127;
        private const Int32 X5 = 2183;

        private const float Fact = (X5 - X1)/4f;

        private const float Radius = 30;
        private const float Thickness = 3;

        public static Bitmap RawImage
        {
            get { return Pictures.graves20111211; }
        }

        public GravesSpiral(XmlDocument xml, Evaluation eval)
        {
            _eval = eval;

            _xmlData = new Dictionary<int, Dictionary<int, QuestionDataItem>>();

            //load xml
            foreach (XmlNode element in xml.DocumentElement.ChildNodes)
            {
                if (element.Name.StartsWith("Level"))
                {
                    int level = Int32.Parse(element.Name.Substring(5));
                    
                    Dictionary<int, QuestionDataItem> items = new Dictionary<int, QuestionDataItem>();

                    foreach (XmlNode question in element.FirstChild.ChildNodes)
                    {
                        int qnum = Int32.Parse(question.Name.Substring(8));

                        items[qnum] = new QuestionDataItem(question.InnerXml, eval);
                    }

                    _xmlData[level] = items;
                }
            }
        }

        public Image Compute(TargetData td)
        {
            Bitmap bmp = (Bitmap)RawImage.Clone();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

            for (int i = 1; i <= 8; i++ )
            {
                //layers
                int y = GetLayerY(i);

                //1: gray dot
                if (_xmlData[i].ContainsKey(1))
                {
                    float x = GetMark(td, _xmlData[i][1]);
                    if (x >= 1 && x <= 4)
                    {
                        GravesPointDrawer.DrawCircleFilled(g, GravesPointDrawer.Gray, new Point((int)(X1 + ((x - 1) * Fact)), y), Radius);    
                    }
                }

                //2: gray circle
                if (_xmlData[i].ContainsKey(2))
                {
                    float x = GetMark(td, _xmlData[i][2]);
                    if (x >= 1 && x <= 4)
                    {
                        GravesPointDrawer.DrawCircleOutline(g, GravesPointDrawer.Gray, new Point((int)(X1 + ((x - 1) * Fact)), y),
                                                            Radius, Thickness);
                    }
                }

                //3: orange square
                if (_xmlData[i].ContainsKey(3))
                {
                    float x = GetMark(td, _xmlData[i][3]);
                    if (x >= 1 && x <= 4)
                    {
                        GravesPointDrawer.DrawRectangleFilled(g, GravesPointDrawer.Orange,
                                                               new Point((int)(X1 + ((x - 1) * Fact)), y), Radius);
                    }
                }

                //4: orange border
                if (_xmlData[i].ContainsKey(4))
                {
                    float x = GetMark(td, _xmlData[i][4]);
                    if (x >= 1 && x <= 4)
                    {
                        GravesPointDrawer.DrawRectangleOutline(g, GravesPointDrawer.Orange,
                                                                new Point((int)(X1 + ((x - 1) * Fact)), y), Radius, Thickness);
                    }
                }
            }

            return bmp;
        }

        private float GetMark(TargetData td, QuestionDataItem item)
        {
            Question q = td.GetQuestion(item.QuestionId, _eval);
            return q.GetAverageByPersonAsMark(_eval, item.Persons[0]);
        }

        private static int GetLayerY(int i)
        {
            switch (i)
            {
                case 1:
                    return 343;
                case 2:
                    return 500;
                case 3:
                    return 636;
                case 4:
                    return 758;
                case 5:
                    return 860;
                case 6:
                    return 949;
                case 7:
                    return 1023;
                case 8:
                    return 1092;
            }

            return 0;
        }
    }
}
