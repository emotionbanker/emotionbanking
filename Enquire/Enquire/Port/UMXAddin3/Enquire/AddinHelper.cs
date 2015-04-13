using System.Windows.Forms;
using Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard;
using Compucare.Enquire.Common.Calculation.Graphics.Graves.Wizard;
using Compucare.Enquire.Common.Calculation.Graphics.Percentbar.Wizard;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard;
using Compucare.Enquire.Common.Calculation.Texts.Benchmarking.Wizard.WizardPages;
using Compucare.Enquire.Common.Calculation.Texts.Gaps.Wizard;
using Compucare.Enquire.Common.Calculation.Texts.MatrixCrossings.Wizard;
using Compucare.Enquire.Common.Calculation.Texts.Script.Wizard;
using Compucare.Enquire.Common.Calculation.Texts.Sokd;
using Compucare.Enquire.Common.Calculation.Texts.TopFlop.Wizard;
using Compucare.Enquire.Common.Calculation.Texts.AnswerOfField;



namespace Compucare.Enquire.Legacy.UMXAddin3.Enquire
{
    public static class AddinHelper
    {
        public static void ShowGapDialog(Connect addin3)
        {
            GapWizard wiz = new GapWizard(addin3.eval);
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlText", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }
        }

        public static void ShowIndicatorIconDialog(Connect addin3, IndicatorGraphics type)
        {
            ExclamationMarkWizard wiz = new ExclamationMarkWizard(addin3.eval, true, type);
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlGraphic", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }
        }

        public static void ShowBenchmarkDialog(Connect addin3)
        {
            BenchmarkingWizard wiz = new BenchmarkingWizard(addin3.eval, addin3.GetTarget());
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlGraphic", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }
        }

        public static void ShowTopFlopDialog(Connect addin3)
        {
            TopFlopWizard wiz = new TopFlopWizard(addin3.eval);
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddTable(wiz.GetXml(), wiz.Columns);
            }
        }

        public static void ShowScriptDialog(Connect addin3)
        {
            EnquireScriptWizard wiz = new EnquireScriptWizard(addin3.eval, addin3.GetTarget());
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlText", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }
        }

        public static void ShowScriptImageDialog(Connect addin3)
        {
            ExpressionMarkWizard wiz = new ExpressionMarkWizard(addin3.eval, addin3.GetTarget(),addin3.multiEvals);
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlGraphic", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }
        }

        public static void ShowPercentbarDialog(Connect addin3)
        {
            PercentBarWizard wiz = new PercentBarWizard(addin3.eval);
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlGraphic", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }
        }

        public static void ShowGravesDialog(Connect addin3)
        {
            GravesWizard wiz = new GravesWizard(addin3.eval);
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlGraphic", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }
        }

        public static void ShowMatrixCrossingDialog(Connect addin3)
        {
            MatrixCrossingWizard wiz = new MatrixCrossingWizard(addin3.eval);
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlText", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }
        }

        public static void ShowAnswerOfFieldDialog(Connect addin3)
        {
            AnswerOfFieldWizard wiz = new AnswerOfFieldWizard(addin3.eval);
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlText", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }
        }

        public static void ShowSokdDialog(Connect addin3)
        {
            SokdWizard wiz = new SokdWizard(addin3.eval);
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                if (wiz.GetTypeofSokd())
                {
                    addin3.AddField(FieldHelper.CreateCode("xmlGraphic", wiz.GetXml(), addin3.GetDocument(), "", ""));
                }
                else
                {
                    addin3.AddField(FieldHelper.CreateCode("xmlText", wiz.GetXml(), addin3.GetDocument(), "", ""));
                }
            }
        }//end ShowSokdDialog

        public static void ShowBenchmarkValueDialog(Connect addin3)
        {
            BenchmarkValueWizard wiz = new BenchmarkValueWizard(addin3.eval, addin3.GetTarget());
            if (wiz.ShowDialog() == DialogResult.OK)
            {
                addin3.AddField(FieldHelper.CreateCode("xmlText", wiz.GetXml(), addin3.GetDocument(), "", ""));
            }        
        }

        
    }
}
