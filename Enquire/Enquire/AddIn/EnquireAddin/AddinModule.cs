using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard;
using Compucare.Enquire.EnquireAddin;
using Compucare.Enquire.Legacy.UMXAddin3;
using Compucare.Enquire.Legacy.UMXAddin3.Enquire;
using Extensibility;

namespace EnquireAddin
{
    /// <summary>
    ///   Add-in Express Add-in Module
    /// </summary>
    [GuidAttribute("B87E6FC8-AD15-4942-87D1-798E8C96D895"), ProgId("EnquireAddin.AddinModule")]
    public class AddinModule : AddinExpress.MSO.ADXAddinModule
    {
        private Connect _addin3;

        public AddinModule()
        {
            InitializeComponent();
            // Please add any initialization code to the AddinInitialize event handler
            
            AddinInitialize += AddinModuleAddinInitialize;
            AddinBeginShutdown += AddinModuleAddinBeginShutdown;
            AddinStartupComplete += AddinModuleAddinStartupComplete;
            
        }

        private void AddinModuleAddinStartupComplete(object sender, EventArgs e)
        {
            Array custom = null;
            _addin3.OnStartupComplete(ref custom);
        }

        private void AddinModuleAddinBeginShutdown(object sender, EventArgs e)
        {
            Array custom = null;

            _addin3.OnBeginShutdown(ref custom);
        }

        private void AddinModuleAddinInitialize(object sender, EventArgs e)
        {
            //OnConnection
            _addin3 = new Connect();

            _insertTextPopup.Enabled = false;
            _insertGraphicsPopup.Enabled = false;
            _addin3.EvalChanged += Addin3EvalChanged;

            Array custom = null;

            _addin3.OnConnection(HostApplication, ext_ConnectMode.ext_cm_Startup, this, ref custom);


            RegisterCommandBarButtonHandlers();
            RegisterRibbonHandlers();
        }

        private void RegisterCommandBarButtonHandlers()
        {
            _buttonTextGap.Click += ButtonTextGapClick;
            _buttonGraphicsExclamation.Click += ButtonGraphicsExclamationClick;
            _buttonGraphicsTraffic.Click += ButtonGraphicsTrafficClick;
            _buttonBenchmark.Click += ButtonBenchmarkClick;
            _buttonTextTopTable.Click += ButtonTextTopTableClick;
            _buttonTextScript.Click += ButtonTextScriptClick;
            _buttonPercentbar.Click += ButtonPercentbarClick;
            _buttonGraves.Click += ButtonGravesClick;
            _buttonMatrixCrossing.Click += ButtonMatrixCrossingClick;
               
        }

        private void RegisterRibbonHandlers()
        {
            //command & control
            _ribbonConnection.OnClick += delegate { _addin3.OpenSettingsDialog(); };
            _ribbonReload.OnClick += delegate { _addin3.ProcessDocument(true); };
            _ribbonEdit.OnClick += delegate { _addin3.OpenEditDialog(); };
            _ribbonProperties.OnClick += delegate { _addin3.OpenPropertiesDialog(); };
            _ribbonInsert.OnClick += delegate { _addin3.OpenInsertDialog(); };
            _ribbonOpenUm3.OnClick += delegate { _addin3.OpenSettingsDialog(true); };
            _ribbonAbout.OnClick += delegate { OpenAboutDialog(); };
            _ribbonUpdateFormula.OnClick += delegate { _addin3.OpenUpdateFormulaDialog(); };

            //text
            _ribbonScript.OnClick += delegate { ButtonTextScriptClick(this); };
            _ribbonGap.OnClick += delegate { ButtonTextGapClick(this); };
            _ribbonMatrixCrossing.OnClick += delegate { ButtonMatrixCrossingClick(this); };

            //tables
            _ribbonTopFlop.OnClick += delegate { ButtonTextTopTableClick(this); }; 

            //images
            _ribbonExclamation.OnClick += delegate { ButtonGraphicsExclamationClick(this); };
            _ribbonTrafficLight.OnClick += delegate { ButtonGraphicsTrafficClick(this); };
            _ribbonPercentBar.OnClick += delegate { ButtonPercentbarClick(this); };
            _ribbonBenchmark.OnClick += delegate { ButtonBenchmarkClick(this); };
            _ribbonGraves.OnClick += delegate { ButtonGravesClick(this); }; 

            //sokd
            adxRibbonButton1.OnClick += delegate { ButtonSokdClick(this); };
            adxRibbonButton2.OnClick += delegate { ButtonBenchmarkValueClick(this); };

        }

        private void OpenAboutDialog()
        {
            new AboutBox().ShowDialog();
        }

        private void ButtonSokdClick(object sender)
        {
            AddinHelper.ShowSokdDialog(_addin3);
        }

        private void ButtonBenchmarkValueClick(object sender)
        {
            AddinHelper.ShowBenchmarkValueDialog(_addin3);

        }

        private void ButtonMatrixCrossingClick(object sender)
        {
            AddinHelper.ShowMatrixCrossingDialog(_addin3);
        }

        private void ButtonGravesClick(object sender)
        {
            AddinHelper.ShowGravesDialog(_addin3);
        }

        private void ButtonPercentbarClick(object sender)
        {
            AddinHelper.ShowPercentbarDialog(_addin3);
        }

        private void ButtonTextScriptClick(object sender)
        {
            AddinHelper.ShowScriptDialog(_addin3);
        }

        private void ButtonTextTopTableClick(object sender)
        {
            AddinHelper.ShowTopFlopDialog(_addin3);
        }

        private void ButtonBenchmarkClick(object sender)
        {
            AddinHelper.ShowBenchmarkDialog(_addin3);
        }

        private void ButtonGraphicsTrafficClick(object sender)
        {
            AddinHelper.ShowIndicatorIconDialog(_addin3, IndicatorGraphics.TrafficLight);
        }

        private void ButtonGraphicsExclamationClick(object sender)
        {
            AddinHelper.ShowIndicatorIconDialog(_addin3, IndicatorGraphics.ExclamationMark);
        }

        void Addin3EvalChanged(bool arg1)
        {
            _insertTextPopup.Enabled = arg1;
            _insertGraphicsPopup.Enabled = arg1;
        }

        void ButtonTextGapClick(object sender)
        {
            AddinHelper.ShowGapDialog(_addin3);
        }

        internal AddinExpress.MSO.ADXCommandBar _enquireCommandBar;
        internal AddinExpress.MSO.ADXCommandBarPopup _insertTextPopup;
        internal AddinExpress.MSO.ADXCommandBarButton _buttonTextGap;
        internal ImageList _imageList16;
        internal AddinExpress.MSO.ADXCommandBarPopup _insertGraphicsPopup;
        internal AddinExpress.MSO.ADXCommandBarButton _buttonGraphicsExclamation;
        private AddinExpress.MSO.ADXCommandBarButton _buttonGraphicsTraffic;
        private AddinExpress.MSO.ADXCommandBarButton _buttonBenchmark;
        private AddinExpress.MSO.ADXCommandBarButton _buttonTextTopTable;
        internal AddinExpress.MSO.ADXCommandBarButton _buttonTextScript;
        private AddinExpress.MSO.ADXCommandBarButton _buttonPercentbar;
        internal AddinExpress.MSO.ADXRibbonTab _enquireRibbonTab;
        internal AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup1;
        private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup2;
        private AddinExpress.MSO.ADXRibbonButton _ribbonScript;
        private AddinExpress.MSO.ADXRibbonButton _ribbonGap;
        private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup4;
        private AddinExpress.MSO.ADXRibbonButton _ribbonTopFlop;
        private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup3;
        private AddinExpress.MSO.ADXRibbonButton _ribbonExclamation;
        private AddinExpress.MSO.ADXRibbonButton _ribbonTrafficLight;
        private AddinExpress.MSO.ADXRibbonButton _ribbonPercentBar;
        private AddinExpress.MSO.ADXRibbonButton _ribbonBenchmark;
        private AddinExpress.MSO.ADXRibbonButton _ribbonConnection;
        private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup5;
        private AddinExpress.MSO.ADXRibbonButton _ribbonProperties;
        private AddinExpress.MSO.ADXRibbonButton _ribbonEdit;
        internal ImageList _imageList32;
        private AddinExpress.MSO.ADXCommandBarButton _buttonGraves;
        private AddinExpress.MSO.ADXRibbonButton _ribbonReload;
        private AddinExpress.MSO.ADXRibbonButton _ribbonGraves;
        private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup6;
        private AddinExpress.MSO.ADXRibbonButton _ribbonInsert;
        internal AddinExpress.MSO.ADXCommandBarButton _buttonMatrixCrossing;
        private AddinExpress.MSO.ADXRibbonButton _ribbonMatrixCrossing;
        private AddinExpress.MSO.ADXRibbonButton _ribbonOpenUm3;
        private AddinExpress.MSO.ADXRibbonButton _ribbonAbout;
        private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup7;
        private AddinExpress.MSO.ADXRibbonButton adxRibbonButton1;
        private AddinExpress.MSO.ADXRibbonButton adxRibbonButton2;
        private AddinExpress.MSO.ADXRibbonButton _ribbonUpdateFormula;

 
        #region Component Designer generated code
        /// <summary>
        /// Required by designer
        /// </summary>
        private System.ComponentModel.IContainer components;
 
        /// <summary>
        /// Required by designer support - do not modify
        /// the following method
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddinModule));
            this._enquireCommandBar = new AddinExpress.MSO.ADXCommandBar(this.components);
            this._insertTextPopup = new AddinExpress.MSO.ADXCommandBarPopup(this.components);
            this._buttonTextGap = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this._imageList16 = new System.Windows.Forms.ImageList(this.components);
            this._buttonTextTopTable = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this._buttonTextScript = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this._buttonMatrixCrossing = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this._insertGraphicsPopup = new AddinExpress.MSO.ADXCommandBarPopup(this.components);
            this._buttonGraphicsExclamation = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this._buttonGraphicsTraffic = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this._buttonBenchmark = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this._buttonPercentbar = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this._buttonGraves = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this._enquireRibbonTab = new AddinExpress.MSO.ADXRibbonTab(this.components);
            this.adxRibbonGroup1 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this._ribbonConnection = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._imageList32 = new System.Windows.Forms.ImageList(this.components);
            this._ribbonOpenUm3 = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonAbout = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonGroup6 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this._ribbonInsert = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonGroup5 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this._ribbonProperties = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonEdit = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonReload = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonUpdateFormula = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonGroup2 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this._ribbonScript = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonGap = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonMatrixCrossing = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonGroup4 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this._ribbonTopFlop = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonGroup3 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this._ribbonExclamation = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonTrafficLight = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonPercentBar = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonBenchmark = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this._ribbonGraves = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonGroup7 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.adxRibbonButton1 = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonButton2 = new AddinExpress.MSO.ADXRibbonButton(this.components);
            // 
            // _enquireCommandBar
            // 
            this._enquireCommandBar.CommandBarName = "Enquire Command Bar";
            this._enquireCommandBar.CommandBarTag = "16a2cddc-e6b1-4d26-926a-8f05cc3930e9";
            this._enquireCommandBar.Controls.Add(this._insertTextPopup);
            this._enquireCommandBar.Controls.Add(this._insertGraphicsPopup);
            this._enquireCommandBar.SupportedApps = ((AddinExpress.MSO.ADXOfficeHostApp)((AddinExpress.MSO.ADXOfficeHostApp.ohaWord | AddinExpress.MSO.ADXOfficeHostApp.ohaPowerPoint)));
            this._enquireCommandBar.UpdateCounter = 14;
            this._enquireCommandBar.UseForRibbon = true;
            // 
            // _insertTextPopup
            // 
            this._insertTextPopup.Caption = "Insert Text";
            this._insertTextPopup.Controls.Add(this._buttonTextGap);
            this._insertTextPopup.Controls.Add(this._buttonTextTopTable);
            this._insertTextPopup.Controls.Add(this._buttonTextScript);
            this._insertTextPopup.Controls.Add(this._buttonMatrixCrossing);
            this._insertTextPopup.ControlTag = "3dcc39f6-6450-49f5-a859-1bad08094b1e";
            this._insertTextPopup.UpdateCounter = 6;
            // 
            // _buttonTextGap
            // 
            this._buttonTextGap.Caption = "Gap";
            this._buttonTextGap.ControlTag = "461d4a9f-7e6c-4393-ac64-864932784d4b";
            this._buttonTextGap.Image = 0;
            this._buttonTextGap.ImageList = this._imageList16;
            this._buttonTextGap.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._buttonTextGap.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this._buttonTextGap.UpdateCounter = 7;
            // 
            // _imageList16
            // 
            this._imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList16.ImageStream")));
            this._imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList16.Images.SetKeyName(0, "gap16_2.png");
            this._imageList16.Images.SetKeyName(1, "exclamation.png");
            this._imageList16.Images.SetKeyName(2, "dot-green.png");
            this._imageList16.Images.SetKeyName(3, "insert-chart-bar.ico");
            this._imageList16.Images.SetKeyName(4, "kdb_table.ico");
            this._imageList16.Images.SetKeyName(5, "applications-education-mathematics.ico");
            this._imageList16.Images.SetKeyName(6, "emblem-percentage.ico");
            this._imageList16.Images.SetKeyName(7, "document-properties.ico");
            this._imageList16.Images.SetKeyName(8, "cog-edit.ico");
            this._imageList16.Images.SetKeyName(9, "view-refresh-5.png");
            this._imageList16.Images.SetKeyName(10, "twisted_matrix.png");
            this._imageList16.Images.SetKeyName(11, "table-border-all.png");
            // 
            // _buttonTextTopTable
            // 
            this._buttonTextTopTable.Caption = "Top/Flop Table";
            this._buttonTextTopTable.ControlTag = "c33b9cc8-ddf2-4ea9-a250-40cf8fcc92cf";
            this._buttonTextTopTable.Image = 4;
            this._buttonTextTopTable.ImageList = this._imageList16;
            this._buttonTextTopTable.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._buttonTextTopTable.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this._buttonTextTopTable.UpdateCounter = 7;
            // 
            // _buttonTextScript
            // 
            this._buttonTextScript.Caption = "Script Expression";
            this._buttonTextScript.ControlTag = "b266d769-2807-4fdc-90a2-1fc2d751a212";
            this._buttonTextScript.Image = 5;
            this._buttonTextScript.ImageList = this._imageList16;
            this._buttonTextScript.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._buttonTextScript.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this._buttonTextScript.UpdateCounter = 6;
            // 
            // _buttonMatrixCrossing
            // 
            this._buttonMatrixCrossing.Caption = "Matrix Crossing";
            this._buttonMatrixCrossing.ControlTag = "9bac47ba-69be-4e9e-a33b-2cbcb680bcd2";
            this._buttonMatrixCrossing.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._buttonMatrixCrossing.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this._buttonMatrixCrossing.UpdateCounter = 3;
            // 
            // _insertGraphicsPopup
            // 
            this._insertGraphicsPopup.Caption = "Insert Graphics";
            this._insertGraphicsPopup.Controls.Add(this._buttonGraphicsExclamation);
            this._insertGraphicsPopup.Controls.Add(this._buttonGraphicsTraffic);
            this._insertGraphicsPopup.Controls.Add(this._buttonBenchmark);
            this._insertGraphicsPopup.Controls.Add(this._buttonPercentbar);
            this._insertGraphicsPopup.Controls.Add(this._buttonGraves);
            this._insertGraphicsPopup.ControlTag = "ca308722-58a7-4ac3-849e-3c2b97d8e26c";
            this._insertGraphicsPopup.UpdateCounter = 3;
            // 
            // _buttonGraphicsExclamation
            // 
            this._buttonGraphicsExclamation.Caption = "Exclamation Mark";
            this._buttonGraphicsExclamation.ControlTag = "af360794-c892-400b-9b7e-a8a33c982cca";
            this._buttonGraphicsExclamation.Image = 1;
            this._buttonGraphicsExclamation.ImageList = this._imageList16;
            this._buttonGraphicsExclamation.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._buttonGraphicsExclamation.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this._buttonGraphicsExclamation.UpdateCounter = 8;
            // 
            // _buttonGraphicsTraffic
            // 
            this._buttonGraphicsTraffic.Caption = "Traffic Light";
            this._buttonGraphicsTraffic.ControlTag = "eba507d8-578a-415c-b278-b6fd63e8590d";
            this._buttonGraphicsTraffic.Image = 2;
            this._buttonGraphicsTraffic.ImageList = this._imageList16;
            this._buttonGraphicsTraffic.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._buttonGraphicsTraffic.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this._buttonGraphicsTraffic.UpdateCounter = 6;
            // 
            // _buttonBenchmark
            // 
            this._buttonBenchmark.Caption = "Benchmark";
            this._buttonBenchmark.ControlTag = "e56d1f08-9a10-4d66-b024-5fdef03ff232";
            this._buttonBenchmark.Image = 3;
            this._buttonBenchmark.ImageList = this._imageList16;
            this._buttonBenchmark.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._buttonBenchmark.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this._buttonBenchmark.UpdateCounter = 7;
            // 
            // _buttonPercentbar
            // 
            this._buttonPercentbar.Caption = "Percent Bar";
            this._buttonPercentbar.ControlTag = "2fdaa09e-0aa3-4eb1-bd07-9d9eba13d06f";
            this._buttonPercentbar.Image = 6;
            this._buttonPercentbar.ImageList = this._imageList16;
            this._buttonPercentbar.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._buttonPercentbar.Style = AddinExpress.MSO.ADXMsoButtonStyle.adxMsoButtonIconAndCaption;
            this._buttonPercentbar.UpdateCounter = 5;
            // 
            // _buttonGraves
            // 
            this._buttonGraves.Caption = "Graves";
            this._buttonGraves.ControlTag = "0237ab84-1e87-4812-8323-a49bd28f39f1";
            this._buttonGraves.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._buttonGraves.UpdateCounter = 3;
            // 
            // _enquireRibbonTab
            // 
            this._enquireRibbonTab.Caption = "Enquire";
            this._enquireRibbonTab.Controls.Add(this.adxRibbonGroup1);
            this._enquireRibbonTab.Controls.Add(this.adxRibbonGroup6);
            this._enquireRibbonTab.Controls.Add(this.adxRibbonGroup5);
            this._enquireRibbonTab.Controls.Add(this.adxRibbonGroup2);
            this._enquireRibbonTab.Controls.Add(this.adxRibbonGroup4);
            this._enquireRibbonTab.Controls.Add(this.adxRibbonGroup3);
            this._enquireRibbonTab.Controls.Add(this.adxRibbonGroup7);
            this._enquireRibbonTab.Id = "adxRibbonTab_9dc5d42c0e4d45f5bab22874dbbaf668";
            this._enquireRibbonTab.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // adxRibbonGroup1
            // 
            this.adxRibbonGroup1.Caption = "Settings";
            this.adxRibbonGroup1.Controls.Add(this._ribbonConnection);
            this.adxRibbonGroup1.Controls.Add(this._ribbonOpenUm3);
            this.adxRibbonGroup1.Controls.Add(this._ribbonAbout);
            this.adxRibbonGroup1.Id = "adxRibbonGroup_ff5a7dea3567495b981e041dc58087ac";
            this.adxRibbonGroup1.ImageList = this._imageList16;
            this.adxRibbonGroup1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup1.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonConnection
            // 
            this._ribbonConnection.Caption = "Connection";
            this._ribbonConnection.Id = "adxRibbonButton_c12965a82494472d8dcd6ca7fec8bbcf";
            this._ribbonConnection.Image = 0;
            this._ribbonConnection.ImageList = this._imageList32;
            this._ribbonConnection.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonConnection.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            this._ribbonConnection.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            // 
            // _imageList32
            // 
            this._imageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList32.ImageStream")));
            this._imageList32.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList32.Images.SetKeyName(0, "system-settings.png");
            this._imageList32.Images.SetKeyName(1, "office-chart-bar-stacked.png");
            this._imageList32.Images.SetKeyName(2, "folder-open.png");
            this._imageList32.Images.SetKeyName(3, "help-about-3.png");
            this._imageList32.Images.SetKeyName(4, "Logo-Sparkasse.png");
            // 
            // _ribbonOpenUm3
            // 
            this._ribbonOpenUm3.Caption = "Open UM3 File";
            this._ribbonOpenUm3.Id = "adxRibbonButton_18be487730e048329e763b4bc11cdb4e";
            this._ribbonOpenUm3.Image = 2;
            this._ribbonOpenUm3.ImageList = this._imageList32;
            this._ribbonOpenUm3.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonOpenUm3.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            this._ribbonOpenUm3.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            // 
            // _ribbonAbout
            // 
            this._ribbonAbout.Caption = "Info";
            this._ribbonAbout.Id = "adxRibbonButton_4caed842e6c54f50a93b4be469369cfa";
            this._ribbonAbout.Image = 3;
            this._ribbonAbout.ImageList = this._imageList32;
            this._ribbonAbout.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonAbout.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            this._ribbonAbout.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            // 
            // adxRibbonGroup6
            // 
            this.adxRibbonGroup6.Caption = "Data";
            this.adxRibbonGroup6.Controls.Add(this._ribbonInsert);
            this.adxRibbonGroup6.Id = "adxRibbonGroup_9bbd1d3641cc42eab0bef36b6868ce00";
            this.adxRibbonGroup6.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup6.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonInsert
            // 
            this._ribbonInsert.Caption = "Insert Text or Chart";
            this._ribbonInsert.Id = "adxRibbonButton_397140f3d3de4a0aa8da6bcd30d155ed";
            this._ribbonInsert.Image = 1;
            this._ribbonInsert.ImageList = this._imageList32;
            this._ribbonInsert.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonInsert.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            this._ribbonInsert.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            // 
            // adxRibbonGroup5
            // 
            this.adxRibbonGroup5.Caption = "Tools";
            this.adxRibbonGroup5.Controls.Add(this._ribbonProperties);
            this.adxRibbonGroup5.Controls.Add(this._ribbonEdit);
            this.adxRibbonGroup5.Controls.Add(this._ribbonReload);
            this.adxRibbonGroup5.Controls.Add(this._ribbonUpdateFormula);
            this.adxRibbonGroup5.Id = "adxRibbonGroup_9a78ab781c7d47b4afce4b38bda22541";
            this.adxRibbonGroup5.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup5.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonProperties
            // 
            this._ribbonProperties.Caption = "Properties";
            this._ribbonProperties.Id = "adxRibbonButton_ff9ee6e5a2294ab8aff0d82bf6020176";
            this._ribbonProperties.Image = 7;
            this._ribbonProperties.ImageList = this._imageList16;
            this._ribbonProperties.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonProperties.Ribbons = AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation;
            // 
            // _ribbonEdit
            // 
            this._ribbonEdit.Caption = "Edit";
            this._ribbonEdit.Id = "adxRibbonButton_9a8073ebdd384b69bff7c4b6e286b0b3";
            this._ribbonEdit.Image = 8;
            this._ribbonEdit.ImageList = this._imageList16;
            this._ribbonEdit.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonEdit.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonReload
            // 
            this._ribbonReload.Caption = "Reload Document";
            this._ribbonReload.Id = "adxRibbonButton_6004b4530ad44849b722b9bf3ad54383";
            this._ribbonReload.Image = 9;
            this._ribbonReload.ImageList = this._imageList16;
            this._ribbonReload.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonReload.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonUpdateFormula
            // 
            this._ribbonUpdateFormula.Caption = "Edit Formula(s)";
            this._ribbonUpdateFormula.Id = "adxRibbonButton_efe035d667f440a4af8a27ac042a84ef";
            this._ribbonUpdateFormula.Image = 9;
            this._ribbonUpdateFormula.ImageList = this._imageList16;
            this._ribbonUpdateFormula.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonUpdateFormula.Ribbons = AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation;
            // 
            // adxRibbonGroup2
            // 
            this.adxRibbonGroup2.AutoScale = true;
            this.adxRibbonGroup2.Caption = "Text";
            this.adxRibbonGroup2.Controls.Add(this._ribbonScript);
            this.adxRibbonGroup2.Controls.Add(this._ribbonGap);
            this.adxRibbonGroup2.Controls.Add(this._ribbonMatrixCrossing);
            this.adxRibbonGroup2.Id = "adxRibbonGroup_cd56d788813044759b0bb72cba8ac15e";
            this.adxRibbonGroup2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup2.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonScript
            // 
            this._ribbonScript.Caption = "Script Expression";
            this._ribbonScript.Id = "adxRibbonButton_69cd955b0b0d44b198e1715cfc1e26fe";
            this._ribbonScript.Image = 5;
            this._ribbonScript.ImageList = this._imageList16;
            this._ribbonScript.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonScript.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonGap
            // 
            this._ribbonGap.Caption = "Gap";
            this._ribbonGap.Id = "adxRibbonButton_fe9d31c367eb4c1ebbc3941b6d202783";
            this._ribbonGap.Image = 0;
            this._ribbonGap.ImageList = this._imageList16;
            this._ribbonGap.ImageTransparentColor = System.Drawing.Color.White;
            this._ribbonGap.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonMatrixCrossing
            // 
            this._ribbonMatrixCrossing.Caption = "Matrix Crossing";
            this._ribbonMatrixCrossing.Id = "adxRibbonButton_5d31b40b94c9480283b21546a632ccd4";
            this._ribbonMatrixCrossing.Image = 11;
            this._ribbonMatrixCrossing.ImageList = this._imageList16;
            this._ribbonMatrixCrossing.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonMatrixCrossing.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // adxRibbonGroup4
            // 
            this.adxRibbonGroup4.Caption = "Tables";
            this.adxRibbonGroup4.Controls.Add(this._ribbonTopFlop);
            this.adxRibbonGroup4.Id = "adxRibbonGroup_1c1bcf90c67541f7a4aee00e880c1b57";
            this.adxRibbonGroup4.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup4.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonTopFlop
            // 
            this._ribbonTopFlop.Caption = "Top/Flop Table";
            this._ribbonTopFlop.Id = "adxRibbonButton_e55e362ba16c4d57b48f28a397b5e426";
            this._ribbonTopFlop.Image = 4;
            this._ribbonTopFlop.ImageList = this._imageList16;
            this._ribbonTopFlop.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonTopFlop.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // adxRibbonGroup3
            // 
            this.adxRibbonGroup3.Caption = "Images";
            this.adxRibbonGroup3.Controls.Add(this._ribbonExclamation);
            this.adxRibbonGroup3.Controls.Add(this._ribbonTrafficLight);
            this.adxRibbonGroup3.Controls.Add(this._ribbonPercentBar);
            this.adxRibbonGroup3.Controls.Add(this._ribbonBenchmark);
            this.adxRibbonGroup3.Controls.Add(this._ribbonGraves);
            this.adxRibbonGroup3.Id = "adxRibbonGroup_d43e84b434ac46a28ae4f2699c432434";
            this.adxRibbonGroup3.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup3.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonExclamation
            // 
            this._ribbonExclamation.Caption = "Exclamation Mark";
            this._ribbonExclamation.Id = "adxRibbonButton_c7531c92f58e4f7589c07b858ff8d2aa";
            this._ribbonExclamation.Image = 1;
            this._ribbonExclamation.ImageList = this._imageList16;
            this._ribbonExclamation.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonExclamation.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonTrafficLight
            // 
            this._ribbonTrafficLight.Caption = "Traffic Light";
            this._ribbonTrafficLight.Id = "adxRibbonButton_086a8807cbdc486bb81f512d905d2b9b";
            this._ribbonTrafficLight.Image = 2;
            this._ribbonTrafficLight.ImageList = this._imageList16;
            this._ribbonTrafficLight.ImageTransparentColor = System.Drawing.Color.White;
            this._ribbonTrafficLight.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonPercentBar
            // 
            this._ribbonPercentBar.Caption = "Percent Bar";
            this._ribbonPercentBar.Id = "adxRibbonButton_685f5ea1addb4f42b886b54cbc8c61d2";
            this._ribbonPercentBar.Image = 6;
            this._ribbonPercentBar.ImageList = this._imageList16;
            this._ribbonPercentBar.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonPercentBar.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonBenchmark
            // 
            this._ribbonBenchmark.Caption = "Benchmark";
            this._ribbonBenchmark.Id = "adxRibbonButton_7c27e099d78a4e46b20ef4ea1d3f6257";
            this._ribbonBenchmark.Image = 3;
            this._ribbonBenchmark.ImageList = this._imageList16;
            this._ribbonBenchmark.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonBenchmark.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // _ribbonGraves
            // 
            this._ribbonGraves.Caption = "Graves";
            this._ribbonGraves.Id = "adxRibbonButton_2c1ad31e73eb4e92ae28166191231fb8";
            this._ribbonGraves.Image = 10;
            this._ribbonGraves.ImageList = this._imageList16;
            this._ribbonGraves.ImageTransparentColor = System.Drawing.Color.Transparent;
            this._ribbonGraves.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // adxRibbonGroup7
            // 
            this.adxRibbonGroup7.Caption = "Values";
            this.adxRibbonGroup7.Controls.Add(this.adxRibbonButton1);
            this.adxRibbonGroup7.Controls.Add(this.adxRibbonButton2);
            this.adxRibbonGroup7.Id = "adxRibbonGroup_bec71462e2894f37b3537e21382e6338";
            this.adxRibbonGroup7.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup7.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // adxRibbonButton1
            // 
            this.adxRibbonButton1.Caption = "SOKD";
            this.adxRibbonButton1.Id = "adxRibbonButton_73582a7703f84b5f8ff2bb5275d8ba9c";
            this.adxRibbonButton1.Image = 4;
            this.adxRibbonButton1.ImageList = this._imageList32;
            this.adxRibbonButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonButton1.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // adxRibbonButton2
            // 
            this.adxRibbonButton2.Caption = "Benchmark";
            this.adxRibbonButton2.Id = "adxRibbonButton_845cdfd4ea6b45c7a7280205c349536a";
            this.adxRibbonButton2.Image = 3;
            this.adxRibbonButton2.ImageList = this._imageList16;
            this.adxRibbonButton2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonButton2.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrWordDocument | AddinExpress.MSO.ADXRibbons.msrPowerPointPresentation)));
            // 
            // AddinModule
            // 
            this.AddinName = "EnquireAddin";
            this.SupportedApps = ((AddinExpress.MSO.ADXOfficeHostApp)((AddinExpress.MSO.ADXOfficeHostApp.ohaWord | AddinExpress.MSO.ADXOfficeHostApp.ohaPowerPoint)));

        }
        #endregion
 
        #region Add-in Express automatic code
 
        // Required by Add-in Express - do not modify
        // the methods within this region
 
        public override System.ComponentModel.IContainer GetContainer()
        {
            if (components == null)
                components = new System.ComponentModel.Container();
            return components;
        }
 
        [ComRegisterFunctionAttribute]
        public static void AddinRegister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXRegister(t);
        }
 
        [ComUnregisterFunctionAttribute]
        public static void AddinUnregister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXUnregister(t);
        }
 
        public override void UninstallControls()
        {
            base.UninstallControls();
        }

        #endregion

        public Word._Application WordApp
        {
            get
            {
                return (HostApplication as Word._Application);
            }
        }
        public PowerPoint._Application PowerPointApp
        {
            get
            {
                return (HostApplication as PowerPoint._Application);
            }
        }

    }
}

