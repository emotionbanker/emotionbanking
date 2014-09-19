using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.Benchmarking;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Windows.Forms;
using log4net;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class Benchmark : IXmlGraphic
    {
        private readonly Evaluation _eval;
        private readonly XmlDocument _doc;
        private readonly TargetData _td;

        public Size Size { get; set; }

        public Benchmark(Evaluation eval, XmlDocument doc, TargetData td)
        {
            _eval = eval;
            _doc = doc;
            _td = td;
        }

        public string Store()
        {
            QuestionDataItem qItem = XmlHelper.GetQuestion(_doc.DocumentElement, "Question", _eval);
            Benchmarking bm = new Benchmarking();

            float hBest = 5;
            float best = 5;
            float hWorst = 0;
            float worst = 0;
            float avg = 0;

            foreach (HistoricData hd in _eval.History)
            {
                hd.LoadInfo();
            }

            foreach (HistoricData hd in _eval.History)
            {
                foreach (TargetData htd in hd.Eval.CombinedTargets)
                {
                    if (htd.Test) continue;

                    Question hq = htd.GetQuestion(qItem.QuestionId, hd.Eval);
                    if (hq == null)
                        continue;

                    float ha = hq.GetAverageByPersonAsMark(hd.Eval, qItem.Persons[0]);

                    if (ha != -1 && ha < hBest)
                        hBest = ha;
                    if (ha != -1 && ha > hWorst)
                        hWorst = ha;
                }
            }


            float[] Averages = new float[_eval.CombinedTargets.Length];

            int t = 0;

            foreach (TargetData td in _eval.CombinedTargets)
            {
                if (td.Test)
                {
                    t++;
                    continue;
                }

                Question qq = td.GetQuestion(qItem.QuestionId, _eval);

                if (qq != null)
                {
                    Averages[t] = qq.GetAverageByPersonAsMark(_eval, qItem.Persons[0]);

                    if (Averages[t] != -1 && Averages[t] < best)
                        best = Averages[t];

                    if (Averages[t] != -1 && Averages[t] > worst)
                        worst = Averages[t];
                }

                if (td == _td)
                {
                    avg = Averages[t];
                }

                t++;
            }

            if (best < hBest)
            {
                hBest = best;
            }
            
            if (worst > hWorst)
            {
                hWorst = worst;
            }

            bm.Evaluation = _eval;
            bm.Average = avg;
            bm.BestValue = best;
            bm.HistoricBest = hBest;
            bm.HistoricWorst = hWorst;
            bm.WorstValue = worst;
            bm.Compute();

            string tempName = System.IO.Path.GetTempFileName() + ".png";
            ((Image)bm.Result).Save(tempName, ImageFormat.Png);
            return tempName;
        }//end Store
    }
}
