using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.EnquireServer.Wizards.DataProvider
{
    public enum DataProviderType
    {
        File,
        Database,
        Random,
        None
    }

    public class DataProviderTypeSelectionPage : BaseWizardPage
    {
        private readonly DataProviderTypeSelectionPageControl _control;

        public DataProviderType SelectedType
        {
            get
            {
                if (_control._radioFile.Checked) return DataProviderType.File;
                if (_control._radioRemoteDb.Checked) return DataProviderType.Database;
                if (_control._radioRandom.Checked) return DataProviderType.Random;

                return DataProviderType.None;
            }
        }

        public DataProviderTypeSelectionPage()
        {
            _control = new DataProviderTypeSelectionPageControl();

            PageControl = _control;

            Header = "Select Data Provider Type";
            Description = "Choose the type of data to be integrated into Enquire 2011.";
        }

        public override void Validate()
        {
            if (SelectedType == DataProviderType.None)
            {
                throw  new WizardValidationException("A data provider type must be selected.");
            }
        }
    }
}
