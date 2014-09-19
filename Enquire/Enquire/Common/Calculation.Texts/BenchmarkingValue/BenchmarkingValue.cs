using System.Drawing;
using Compucare.Enquire.Common.Calculation.Attributes;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Calculation.Graphics.Benchmarking
{
    [DataItem]
    public class Benchmarking : BaseEnquireCalculation
    {
        #region Parameters

        [DataItemParameter]
        public float Average { get; set; }

        [DataItemParameter]
        public float OwnValue { get; set; }

        [DataItemParameter]
        public float BestValue { get; set; }

        [DataItemParameter]
        public float WorstValue { get; set; }

        [DataItemParameter]
        public float HistoricBest { get; set; }

        [DataItemParameter]
        public float HistoricWorst { get; set; }

        [DataItemParameter]
        public Evaluation Evaluation { get; set; }

        #endregion Parameters

        public Benchmarking()
        {
            ResultType = typeof (string);
        }

        public override void Compute()
        {

           base.Compute();

           Result = compucare.Enquire.Legacy.Umfrage2Lib.Output.Benchmarking.TrafficLightBar(180, 17, Evaluation, 
                4 - (Average - 1), 4 - (BestValue - 1), 4 - (WorstValue - 1), 4 - (HistoricBest - 1), 4 - (HistoricWorst - 1), true, 4 - (OwnValue - 1));
        }
    }
}
