using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard.WizardPages
{
    public enum BenchmarkingType
    {
        Simple,
        Comparative
    }

    public class BenchmarkingTypeWizardPage : BaseWizardPage
    {
        private readonly BenchmarkingTypeWizardPageControl _control;

        public BenchmarkingType Type
        {
            get
            {
                return _control._radioComparative.Checked
                           ? BenchmarkingType.Comparative
                           : BenchmarkingType.Simple;
            }
        }

        public BenchmarkingTypeWizardPage()
        {
            Header = "Benchmark type";
            Description = "Choose the benchmark you want to create.";

            _control = new BenchmarkingTypeWizardPageControl();

            PageControl = _control;
        }
    }
}
