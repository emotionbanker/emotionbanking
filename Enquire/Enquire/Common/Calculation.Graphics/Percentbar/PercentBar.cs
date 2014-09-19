using System;
using System.Collections.Generic;
using System.Drawing;
using Compucare.Enquire.Common.Calculation.Attributes;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Common.Calculation.Graphics.Percentbar
{
    [DataItem]
    public class PercentBar : BaseEnquireCalculation
    {
        #region Parameters

        [DataItemParameter]
        public PersonSetting PersonSetting { get; set; }

        [DataItemParameter]
        public Dictionary<Int32,Color> Colors { get; set; }

        [DataItemParameter]
        public Question Question { get; set; }

        [DataItemParameter]
        public Evaluation Evaluation { get; set; }

        #endregion Parameters

        public PercentBar()
        {
            ResultType = typeof (Image);
        }

        public override void Compute()
        {
            base.Compute();

            Result = CreateBarImage(Evaluation, Question, PersonSetting, 180, 17);
        }

        private Image CreateBarImage(Evaluation eval, Question q, PersonSetting ps, int width, int height)
        {
            float pcnt1 = (float)q.GetAnswerPercentByPerson(0, eval, ps);
            float pcnt2 = (float)q.GetAnswerPercentByPerson(1, eval, ps);
            float pcnt3 = (float)q.GetAnswerPercentByPerson(2, eval, ps);
            float pcnt4 = (float)q.GetAnswerPercentByPerson(3, eval, ps);
            float pcnt5 = (float)q.GetAnswerPercentByPerson(4, eval, ps);

            Bitmap bmp = new Bitmap(width, height);

            float fact = ((float)width) / 100f;

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

            g.FillRectangle(new SolidBrush(Colors[1]), 0, 0, (pcnt1 * fact), height);
            g.FillRectangle(new SolidBrush(Colors[2]), (pcnt1 * fact), 0, (pcnt2 * fact), height);

            g.FillRectangle(new SolidBrush(Colors[3]), (pcnt1 * fact) + (pcnt2 * fact), 0, (pcnt3 * fact), height);

            g.FillRectangle(new SolidBrush(Colors[4]), (pcnt1 * fact) + (pcnt2 * fact) + (pcnt3 * fact), 0, (pcnt4 * fact), height);
            g.FillRectangle(new SolidBrush(Colors[5]), (pcnt1 * fact) + (pcnt2 * fact) + (pcnt3 * fact) + (pcnt4 * fact), 0, (pcnt5 * fact), height);

            return bmp;

        }
    }
}
