using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.DataModule.DataProvider;
using Compucare.Enquire.Common.DataModule.File.Um3;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.EnquireServer.Wizards.DataProvider
{
    public class DataProviderWizard : BaseWizard
    {
        private readonly DataProviderTypeSelectionPage _typeSelectionPage;
        private readonly Um3FileDataProviderPage _filePage;
        private readonly DataProviderPersistence _provider;

        public DataProviderWizard(DataProviderPersistence provider)
        {
            _provider = provider;

            Text = "Data Provider Wizard";

            AskOnCancel = true;

            PageHeadImage = Pictures.database_48;

            _typeSelectionPage = new DataProviderTypeSelectionPage();
            AddWizardPage(_typeSelectionPage);

            _filePage = new Um3FileDataProviderPage();
            AddWizardPage(_filePage);
        }

        protected override void OnAfterSetPage()
        {
            if (CurrentPage is Um3FileDataProviderPage)
            {
                if (_typeSelectionPage.SelectedType != DataProviderType.File) Skip();
            }
        }

        protected override void OnFinish()
        {
            if (_typeSelectionPage.SelectedType == DataProviderType.File)
            {
                FileUm3DataProvider fileProvider = new FileUm3DataProvider(_filePage.FileName);
                fileProvider.DisplayName = _filePage.DisplayName;
                fileProvider.Description = _filePage.ProviderDescription;
                _provider.AddDataProvider(fileProvider);
            }
        }
    }
}
