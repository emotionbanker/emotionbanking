using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Enquire.Common.Tools.Logging;
using Compucare.Enquire.Legacy.UMXAddin3.ControlForms;
using Compucare.Enquire.Legacy.UMXAddin3.Enquire;
using Compucare.Enquire.Legacy.UMXAddin3.Xml;
using Compucare.Frontends.Common.Command;
using Microsoft.Office.Core;

namespace Compucare.Enquire.Legacy.UMXAddin3
{
    public enum AppType { Word, PowerPoint }

    #region Read me for Add-in installation and setup information.
    // When run, the Add-in wizard prepared the registry for the Add-in.
    // At a later time, if the Add-in becomes unavailable for reasons such as:
    //   1) You moved this project to a computer other than which is was originally created on.
    //   2) You chose 'Yes' when presented with a message asking if you wish to remove the Add-in.
    //   3) Registry corruption.
    // you will need to re-register the Add-in by building the UMXAddin3Setup project, 
    // right click the project in the Solution Explorer, then choose install.
    #endregion

    /// <summary>
    ///   The object for implementing an Add-in.
    /// </summary>
    /// <seealso class='IDTExtensibility2' />
    [GuidAttribute("D17FC01C-70C2-48DE-AEF1-4DB366BE6737"), ProgId("EnquireAddin.Connect")]
    public class Connect : Object, Extensibility.IDTExtensibility2
    {
        private Microsoft.Office.Interop.Word.Application _wordApp;
        private Microsoft.Office.Interop.PowerPoint.Application _pptApp;

        private CommandBarButton _settingsButton;
        private CommandBarButton _insertButton;
        private CommandBarButton _propButton;
        private CommandBarButton _editButton;
        private CommandBar _toolBar;

        private object _applicationObject;
        private object _addInInstance;

        public event CommonEventHandler<Boolean> EvalChanged;

        public Evaluation eval;

        public Evaluation[] multiEvals = new Evaluation[5];
        public string[] multiTargets = new string[5];

        public AppType AType
        {
            get
            {
                if (_wordApp != null)
                {
                    return AppType.Word;
                }

                return AppType.PowerPoint;
            }
        }

        /// <summary>
        ///		Implements the constructor for the Add-in object.
        ///		Place your initialization code within this method.
        /// </summary>
        public Connect()
        {
            Application.EnableVisualStyles();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly ayResult = null;
            string sShortAssemblyName = args.Name.Split(',')[0];
            Assembly[] ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ayAssembly in ayAssemblies)
            {
                if (sShortAssemblyName == ayAssembly.FullName.Split(',')[0])
                {
                    ayResult = ayAssembly;
                    break;
                }
            }
            return ayResult;
        }

        /// <summary>
        ///      Implements the OnConnection method of the IDTExtensibility2 interface.
        ///      Receives notification that the Add-in is being loaded.
        /// </summary>
        /// <param name='application'>
        ///      Root object of the host application.
        /// </param>
        /// <param name='connectMode'>
        ///      Describes how the Add-in is being loaded.
        /// </param>
        /// <param name='addInInst'>
        ///      Object representing this Add-in.
        /// </param>
        /// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            _applicationObject = application;
            _addInInstance = addInInst;

            _toolBar = null;

            if (application is Microsoft.Office.Interop.Word.Application)
            {
                _wordApp = (Microsoft.Office.Interop.Word.Application)application;
                _pptApp = null;

                _toolBar = AddWordToolbar(_wordApp, "UMXAddin3");

                _wordApp.DocumentOpen += wordapp_DocumentOpen;
                _wordApp.DocumentBeforeSave += wordapp_DocumentBeforeSave;

            }
            else if (application is Microsoft.Office.Interop.PowerPoint.Application)
            {
                _pptApp = (Microsoft.Office.Interop.PowerPoint.Application)application;
                _wordApp = null;


                _toolBar = AddPPtToolbar(_pptApp, "UMXAddin3");

                _pptApp.PresentationOpen += pptApp_PresentationOpen;
                _pptApp.PresentationBeforeSave += pptApp_PresentationBeforeSave;

                _propButton = AddButton(_toolBar, "Eigenschaften", 25, propButton_Click);
            }

            _settingsButton = AddButton(_toolBar, "Einstellungen", 16, settingsButton_Click);
            _insertButton = AddButton(_toolBar, "Einfügen", 17, insertButton_Click);
            _editButton = AddButton(_toolBar, "Bearbeiten", 162, editButton_Click);
        }

        /// <summary>
        ///     Implements the OnDisconnection method of the IDTExtensibility2 interface.
        ///     Receives notification that the Add-in is being unloaded.
        /// </summary>
        /// <param name='disconnectMode'>
        ///      Describes how the Add-in is being unloaded.
        /// </param>
        /// <param name='custom'>
        ///      Array of parameters that are host application specific.
        /// </param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref Array custom)
        {
        }

        /// <summary>
        ///      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
        ///      Receives notification that the collection of Add-ins has changed.
        /// </summary>
        /// <param name='custom'>
        ///      Array of parameters that are host application specific.
        /// </param>
        /// <seealso class='IDTExtensibility2' />
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>
        ///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
        ///      Receives notification that the host application has completed loading.
        /// </summary>
        /// <param name='custom'>
        ///      Array of parameters that are host application specific.
        /// </param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom)
        {

        }

        /// <summary>
        ///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
        ///      Receives notification that the host application is being unloaded.
        /// </summary>
        /// <param name='custom'>
        ///      Array of parameters that are host application specific.
        /// </param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom)
        {
        }

        public void OpenSettingsDialog()
        {
            OpenSettingsDialog(false);
        }

        public void OpenSettingsDialog(bool fileopen)
        {
            UMSettingsForm sf = null;

            if (AType == AppType.PowerPoint)
            {
                sf = new UMSettingsForm(eval, multiEvals, multiTargets, _pptApp.ActivePresentation);
            }
            else if (AType == AppType.Word)
            {
                sf = new UMSettingsForm(eval, multiEvals, multiTargets, GetDocument());
            }

            if (sf != null && sf.ShowDialogInternal(fileopen) == DialogResult.Retry)
            {
                ProcessDocument(true);
            }
            eval = sf.eval;
            EventHelper.Fire(EvalChanged, eval != null);
            multiEvals = sf.multiEvals;
            multiTargets = sf.multiTargets;
        }

        public Microsoft.Office.Interop.Word.Document GetDocument()
        {
            try
            {
                Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)_applicationObject;
                Microsoft.Office.Interop.Word.Document doc = wordapp.ActiveDocument;
                return doc;
            }
            catch
            {
                return null;
            }
        }

        public Microsoft.Office.Interop.PowerPoint.Presentation GetDocument1()
        {
            try
            {
                Microsoft.Office.Interop.PowerPoint.Application ppapp = (Microsoft.Office.Interop.PowerPoint.Application)_applicationObject;
                Microsoft.Office.Interop.PowerPoint.Presentation doc = ppapp.ActivePresentation;
                return doc;
            }
            catch
            {
                return null;
            }
        }

        public void ProcessDocument(bool tf)
        {
            DateTime start = DateTime.Now;

            if (AType == AppType.PowerPoint)
            {
                ProcessPresentation(_pptApp.ActivePresentation, tf);
            }
            else if (AType == AppType.Word)
            {
                Microsoft.Office.Interop.Word.Document doc = GetDocument();

                if (doc != null) ProcessDocument(doc, tf);
            }
            MessageBox.Show("Finished processing in " + (DateTime.Now - start).TotalMilliseconds + "ms");
        }

        public TargetData GetTarget()
        {
            TargetData tdr = null;

            string name = null;


            if (AType == AppType.PowerPoint)
                name = Tools.GetPPtDocumentPropertyValue(_pptApp.ActivePresentation, "umo:target");
            else if (AType == AppType.Word)
                name = (string)Tools.GetWordDocumentPropertyValue(GetDocument(), "umo:target");

            foreach (TargetData td in eval.CombinedTargets)
            {
                td.IncludedChanged += new IncludedChangedEventHandler(td_IncludedChanged);
                if (name != null && name.Equals(td.Name)) { tdr = td; td.Included = true; }
                else td.Included = false;

                //gt += td.name + "\t\t" + td.Included + "\r\n";
            }

            //MessageBox.Show(gt);

            return tdr;
        }

        public void AddTable(List<List<String>> table, int maxCols)
        {
            if (AType == AppType.PowerPoint)
            {
                
            }
            else if (AType == AppType.Word)
            {
                Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)_applicationObject;
                Microsoft.Office.Interop.Word.Document doc = GetDocument();
                object missing = null;
                
                Microsoft.Office.Interop.Word.Table wTable = doc.Tables.Add(wordapp.Selection.Range, 
                   table.Count, maxCols, ref missing, ref missing);

                wTable.Borders.Enable = 1;
                wTable.Borders.OutsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray60;

                for (int i = 0; i < table.Count; i++) //rows
                {
                    int j = 0;
                    foreach (String xml in table[i]) //columns
                    {
                        object direction = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;
                        object fieldType = Microsoft.Office.Interop.Word.WdFieldType.wdFieldAddin;

                        Microsoft.Office.Interop.Word.Range range = wTable.Range.Rows[i + 1].Cells[j + 1].Range;
                        range.Collapse(ref direction);

                        range.Select();

                        AddField(FieldHelper.CreateCode("xmlText", xml, GetDocument(), "", ""));

                        j++;
                    }
                }
            }
        }

        public void OpenPropertiesDialog()
        {
            try
            {
                if (_pptApp.ActiveWindow.Selection.ShapeRange.Tags["umxcode"].Equals("table") || (_pptApp.ActiveWindow.Selection.ShapeRange.Tags["umxcode"].IndexOf("ADDIN") != -1))
                {
                    string dat = _pptApp.ActiveWindow.Selection.ShapeRange.Tags["umxcode"];

                    string d = string.Empty;

                    string[] master = (dat + "|").Split(new char[] { '|' });

                    d += "Verknüpfungsdaten:\n\n";

                    int i = 0;
                    foreach (string v in master[0].Split(new char[] { ':' }))
                        d += (i++) + ": " + v + "\n";

                    d += "\n";

                    d += "Word Object ID: " + master[1] + "\n";
                    d += "Kreuzungen: " + master[2] + "\n";
                    d += "Prozentbasis: " + master[3];

                    MessageBox.Show(d, "Eigenschaften", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Auswahl enthält keine Umfrageverknüpfungen", "Eigenschaften", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }

        public void OpenEditDialog()
        {
            if (this.AType == AppType.PowerPoint)
            {
                //get selection (all shapes)
                //get all tags

                List<Microsoft.Office.Interop.PowerPoint.Shape> selShapes = new List<Microsoft.Office.Interop.PowerPoint.Shape>();
                List<string> tags = new List<string>();

                foreach (Microsoft.Office.Interop.PowerPoint.Shape selShape in _pptApp.ActiveWindow.Selection.ShapeRange)
                {
                    if (!String.Empty.Equals(selShape.Tags["umxcode"]))
                    {
                        selShapes.Add(selShape);
                        tags.Add((string)selShape.Tags["umxcode"]);
                    }
                }

                //show replacement options dialog
                EditLinkForm elf = new EditLinkForm();
                elf.SetData(selShapes);
                elf.ShowDialog();
            }
            else if (this.AType == AppType.Word)
            {
                List<Microsoft.Office.Interop.Word.Field> fields = new List<Microsoft.Office.Interop.Word.Field>();

                foreach (Microsoft.Office.Interop.Word.Field f in _wordApp.Selection.Fields)
                {
                    if (f.Code.Text.StartsWith(" ADDIN umo:"))
                    {
                        //MessageBox.Show(f.Code.Text);
                        fields.Add(f);
                    }
                }

                EditLinkForm elf = new EditLinkForm();
                elf.SetData(fields, GetDocument());
                elf.ShowDialog();
            }
        }

        public void OpenInsertDialog()
        {
            //open menu

            try
            {
                InsertForm inf = new InsertForm(eval, GetDocument());

                try
                {
                    DialogResult res = inf.ShowDialog();

                    if (res == DialogResult.OK)
                    {
                        AddField(inf.FieldCode);
                    }
                    else if (res == DialogResult.Yes)
                    {
                        //table
                        if (AType == AppType.PowerPoint)
                        {
                            CreateTablePPt(inf);
                        }
                        else if (AType == AppType.Word)
                        {
                            CreateTable(inf);
                        }

                    }
                    else if (res == DialogResult.Retry)
                    {
                        //pottable
                        if (AType == AppType.PowerPoint)
                        {
                            CreatePotTablePPt(inf.FieldCode, inf);
                        }
                        else if (AType == AppType.Word)
                        {
                            CreatePotTable(inf.FieldCode, inf);
                        }

                    }
                    else if (res == DialogResult.Ignore)
                    {
                        //maturity
                        if (AType == AppType.PowerPoint)
                        {
                            CreateMaturityPPt(inf.FieldCode, inf);
                        }
                        else if (AType == AppType.Word)
                        {
                            CreateMaturity(inf.FieldCode, inf);
                        }
                    }
                    else if (res == DialogResult.No)
                    {
                        //tagcloud
                        if (AType == AppType.PowerPoint)
                        {
                            CreateTagCloudPPt(inf.FieldCode, inf);
                        }
                        else if (AType == AppType.Word)
                        {
                            CreateTagCloud(inf.FieldCode, inf);
                        }
                    }
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }

        public void AddField(string code)
        {
            if (AType == AppType.PowerPoint)
            {
                AddPField(code);
            }
            else if (AType == AppType.Word)
            {
                Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)_applicationObject;
                AddField(code, wordapp.Selection.Range);
            }
        }

        private void AddPField(string code)
        {
            var tls = new PPTools(code, GetTarget(), eval);
            var sl = (Microsoft.Office.Interop.PowerPoint.Slide)_pptApp.ActiveWindow.View.Slide;

            Microsoft.Office.Interop.PowerPoint.Shape ns = null;

            switch (tls.dat[1])
            {
                case "potpcnt": case "potval":
                case "aabs": case "bcont-value": case "bcont-comp-mw":
                case "bcont-comp-apc": case "bcont-value-apc": case "origaw": case "bcont-nps-value":
                case "bcont-nps-diff": case "xmlText":
                    ns = sl.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 70, 40);
                    break;

                case "mw":
                    _pptApp.ActiveWindow.Selection.TextRange.Text = GetAverageValue(GetTarget(), tls.dat);
                    _pptApp.ActiveWindow.Selection.ShapeRange.Tags.Add("umxcode", code);
                    ns = null;
                    break;

                case "md":
                    _pptApp.ActiveWindow.Selection.TextRange.Text = GetMedianValue(GetTarget(), tls.dat);
                    _pptApp.ActiveWindow.Selection.ShapeRange.Tags.Add("umxcode", code);
                    ns = null;
                    break;

                case "pc":
                    _pptApp.ActiveWindow.Selection.TextRange.Text = GetPercentValue(GetTarget(), tls.dat);
                    _pptApp.ActiveWindow.Selection.ShapeRange.Tags.Add("umxcode", code);
                    ns = null;
                    break;

                case "apc":
                    _pptApp.ActiveWindow.Selection.TextRange.Text = GetPercentResponseValue(tls, GetTarget(), tls.dat);
                    _pptApp.ActiveWindow.Selection.ShapeRange.Tags.Add("umxcode", code);
                    ns = null;
                    break;

                case "gap":
                    _pptApp.ActiveWindow.Selection.TextRange.Text = GetGapValue(GetTarget(), tls.dat);
                    _pptApp.ActiveWindow.Selection.ShapeRange.Tags.Add("umxcode", code);
                    ns = null;
                    break;

                case "nps":
                    _pptApp.ActiveWindow.Selection.TextRange.Text = GetNpsValue(tls);
                    _pptApp.ActiveWindow.Selection.ShapeRange.Tags.Add("umxcode", code);
                    ns = null;
                    break;

                case "n":
                    _pptApp.ActiveWindow.Selection.TextRange.Text = GetSampleSizeValue(GetTarget(), tls.dat);
                    _pptApp.ActiveWindow.Selection.ShapeRange.Tags.Add("umxcode", code);
                    ns = null;
                    break;

                case "aas":
                    _pptApp.ActiveWindow.Selection.TextRange.Text = GetAverageReplyNumValue(GetTarget(), tls.dat);
                    _pptApp.ActiveWindow.Selection.ShapeRange.Tags.Add("umxcode", code);
                    ns = null;
                    break;

                case "potpic":
                    ns = sl.Shapes.AddPicture(tls.Potpic(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, 180, 20);
                    break;

                case "pbar":
                    ns = sl.Shapes.AddPicture(tls.Pbar(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, 180, 17);
                    break;

                case "tl":
                    ns = sl.Shapes.AddPicture(tls.Tl(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, 16, 16);
                    break;

                case "idivtl":
                    ns = sl.Shapes.AddPicture(tls.Idivtl(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[10]) * 2, Int32.Parse(tls.dat[10]) * 2);
                    break;

                case "comparetl":
                    ns = sl.Shapes.AddPicture(tls.Comparetl(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[11]) * 2, Int32.Parse(tls.dat[11]) * 2);
                    break;

                case "comparetlnps":
                    ns = sl.Shapes.AddPicture(tls.Comparetlnps(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[11]) * 2, Int32.Parse(tls.dat[11]) * 2);
                    break;

                case "compareidivtlpcnt":
                    ns = sl.Shapes.AddPicture(tls.Comparetlpcnt(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[11]) * 2, Int32.Parse(tls.dat[11]) * 2);
                    break;

                case "idivtlpcnt":
                    ns = sl.Shapes.AddPicture(tls.IdivtlPcnt(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[10]) * 2, Int32.Parse(tls.dat[10]) * 2);
                    break;

                case "idivtlnps":
                    ns = sl.Shapes.AddPicture(tls.IdivtlNps(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[10]) * 2, Int32.Parse(tls.dat[10]) * 2);
                    break;

                case "idivtlnum":
                    ns = sl.Shapes.AddPicture(tls.IdivtlNum(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[10]) * 2, Int32.Parse(tls.dat[10]) * 2);
                    break;

                case "bcont-light":
                    ns = sl.Shapes.AddPicture(tls.bcontLight(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[11]) * 2, Int32.Parse(tls.dat[11]) * 2);
                    break;

                case "bcont-trend":
                    ns = sl.Shapes.AddPicture(tls.bconTrend(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[22]), Int32.Parse(tls.dat[22]));                  
                    break;

                case "bcont-nps-trend":
                    ns = sl.Shapes.AddPicture(tls.bconTrendNPS(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[22]), Int32.Parse(tls.dat[22]));
                    break;

                case "bcont-nps-tlb":
                    ns = sl.Shapes.AddPicture(tls.bcontLightNPS(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[11]) * 2, Int32.Parse(tls.dat[11]) * 2);
                    break;

                case "bcont-light-apc":
                    ns = sl.Shapes.AddPicture(tls.bcontLightApc(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[11]) * 2, Int32.Parse(tls.dat[11]) * 2);
                    break;

                case "bcont-Exclamation":
                    ns = sl.Shapes.AddPicture(tls.bconExclamation(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[22])*2, Int32.Parse(tls.dat[22])*2);
                    break;

                case "bcont-Exclamation-apc":
                    ns = sl.Shapes.AddPicture(tls.bconExclamationApc(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[22]) * 2, Int32.Parse(tls.dat[22]) * 2);
                    break;

                case "bcont-Exclamation-nps":
                    ns = sl.Shapes.AddPicture(tls.bconExclamationNPS(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[22]) * 2, Int32.Parse(tls.dat[22]) * 2);
                    break;

                case "bcont-trend-apc":
                    ns = sl.Shapes.AddPicture(tls.bconTrendApc(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[22]), Int32.Parse(tls.dat[22]));
                    break;

                case "op":
                    ns = sl.Shapes.AddPicture(tls.op(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, tls.compop.OutputImage.Width, tls.compop.OutputImage.Height);
                    break;

                case "op-c":
                    ns = sl.Shapes.AddPicture(tls.opC(this), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, tls.compop.OutputImage.Width, tls.compop.OutputImage.Height);
                    break;

                case "exclamation-single":
                    ns = sl.Shapes.AddPicture(tls.ExclamationSingle(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[10]) * 2, Int32.Parse(tls.dat[10]) * 2);
                    break;

                case "exclamation-gap":
                    ns = sl.Shapes.AddPicture(tls.ExclamationGap(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[10]) * 2, Int32.Parse(tls.dat[10]) * 2);
                    break;

                case "exclamation-compare":
                    ns = sl.Shapes.AddPicture(tls.ExclamationCompare(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[11]) * 2, Int32.Parse(tls.dat[11]) * 2);
                    break;

                case "xmlGraphic":
                    IXmlGraphic gr = XmlHelper.ComputeGraphic(tls.GetXmlMaster(), GetTarget(), eval);
                    ns = sl.Shapes.AddPicture(gr.Store(),
                                              MsoTriState.msoFalse, MsoTriState.msoTrue,
                                              100, 100,
                                              gr.Size.Width, gr.Size.Height);
                    break;
            }

            if (ns != null)
            {
                ns.Tags.Add("umxcode", code);

                ProcessShape(ns, sl);
            }
        }

        private static void RecursiveShapeSaver(Microsoft.Office.Interop.Word.Shapes ss)
        {
            foreach (Microsoft.Office.Interop.Word.Shape s in ss)
            {
                try
                {
                    foreach (Microsoft.Office.Interop.Word.InlineShape shape in s.TextFrame.TextRange.InlineShapes)
                    {
                        try
                        {
                            if (shape.AlternativeText.StartsWith("umo"))
                            {
                                string id = shape.AlternativeText.Substring(3);

                                foreach (Microsoft.Office.Interop.Word.Field f in s.TextFrame.TextRange.Fields)
                                {
                                    if (f.Code.Text.StartsWith(" ADDIN umo:"))
                                    {
                                        string[] master = (f.Code.Text + "|").Split(new char[] { '|' });
                                        string[] param = master[0].Split(new char[] { ':' });

                                        if (id.Equals(master[1])) //found!
                                        {
                                            param[4] = "" + shape.Width;
                                            param[5] = "" + shape.Height;

                                            f.Code.Text = " ADDIN umo";

                                            for (int i = 1; i < param.Length; i++)
                                                f.Code.Text += ":" + param[i];

                                            for (int i = 1; i < master.Length; i++)
                                                f.Code.Text += "|" + master[i];

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        catch 
                        {
                            //MessageBox.Show(ex.StackTrace, ex.Message);
                        }
                    }
                }
                catch 
                {
                    //MessageBox.Show(ex.StackTrace, ex.Message);
                }
            }
        }

        private CommandBar AddPPtToolbar(Microsoft.Office.Interop.PowerPoint.Application ppt, string toolbarName)
        {
            Microsoft.Office.Core.CommandBar toolBar = null;
            try
            {
                // Create a command bar for the add-in
                object missing = System.Reflection.Missing.Value;
                toolBar = (Microsoft.Office.Core.CommandBar)
                    _pptApp.CommandBars.Add(toolbarName,
                    Microsoft.Office.Core.MsoBarPosition.msoBarTop,
                    missing, true);
                toolBar.Visible = true;
                return toolBar;
                
            }
            catch
            {
                // Add exception handling here.
                return null;
            }
        }

        private CommandBar AddWordToolbar(Microsoft.Office.Interop.Word.Application word, string toolbarName)
        {
            CommandBar toolBar = null;
            try
            {
                // Create a command bar for the add-in
                object missing = Missing.Value;
                toolBar = _wordApp.CommandBars.Add(toolbarName, MsoBarPosition.msoBarTop, missing, true);
                toolBar.Visible = true;
                return toolBar;
            }
            catch
            {
                // Add exception handling here.
                return null;
            }
        }

        // C#
        private CommandBarButton AddButton(CommandBar commandBar, string caption, int faceID,
                                            _CommandBarButtonEvents_ClickEventHandler clickHandler)
        {
            object missing = Missing.Value;
            try
            {
                CommandBarButton newButton;
                newButton = (CommandBarButton)
                    commandBar.Controls.Add(
                    MsoControlType.msoControlButton,
                    missing, missing, missing, missing);
                newButton.Caption = caption;
                newButton.FaceId = faceID;
                newButton.Style = MsoButtonStyle.msoButtonIconAndCaption;
                newButton.Click += clickHandler;
                newButton.Tag = caption;
                return newButton;
            }
            catch
            {
                // Add code here to handle the exception.
                return null;
            }
        }

        private void ProcessPresentation(Microsoft.Office.Interop.PowerPoint.Presentation pres, bool tf)
        {

            if (eval != null)
            {
                Tools.SetPPtDocumentPropertyValue(_pptApp.ActivePresentation, "umo:filename", eval.FileName);
            }
            else
            {
                object FileName = null;

                FileName = Tools.GetPPtDocumentPropertyValue(_pptApp.ActivePresentation, "umo:filename");

                if (FileName != null)
                {
                    eval = Tools.LoadEval((string)FileName);
                    if (eval != null) ProcessDocument(tf);
                    else
                    {
                       Tools.SetPPtDocumentPropertyValue(_pptApp.ActivePresentation, "umo:filename", "");
                    }
                    EventHelper.Fire(EvalChanged, eval != null);
                }
            }


            if (tf) ComputeDocument();

        }

        private void ProcessDocument(Microsoft.Office.Interop.Word.Document doc, bool tf)
        {

            if (eval != null)
            {
               Tools.SetWordDocumentPropertyValue(doc, "umo:filename", eval.FileName);
            }
            else
            {
                object FileName = null;

                FileName = Tools.GetWordDocumentPropertyValue(doc, "umo:filename");

                if (FileName != null)
                {
                    eval = Tools.LoadEval((string)FileName);
                    EventHelper.Fire(EvalChanged, eval != null);

                    if (eval != null) tf = true; //ProcessDocument(tf);
                    
                    if (eval == null)
                    {
                       Tools.SetWordDocumentPropertyValue(doc, "umo:filename", "");
                    }
                }
            }


            if (tf) ComputeDocument();

        }

        internal Evaluation GetCEval(int pos)
        {
            return multiEvals[pos];
        }

        internal TargetData GetCTarget(int pos)
        {
            TargetData tdr = null;

            string name = null;

            
            if (multiEvals[pos] == null) return null;


            if (AType == AppType.PowerPoint)
                name = Tools.GetPPtDocumentPropertyValue(_pptApp.ActivePresentation, "umo:mtarget" + pos);
            else if (AType == AppType.Word)
                name = (string)Tools.GetWordDocumentPropertyValue(GetDocument(), "umo:mtarget" + pos);

            foreach (TargetData td in this.multiEvals[pos].CombinedTargets)
            {
                td.IncludedChanged += new IncludedChangedEventHandler(td_IncludedChanged);
                if (name != null && name.Equals(td.Name)) { tdr = td; td.Included = true; }
                else td.Included = false;

                //gt += td.name + "\t\t" + td.Included + "\r\n";
            }

            //MessageBox.Show(gt);

            return tdr;
        }

        private void SetProps(Microsoft.Office.Interop.Word.Range r, string master, FieldStyle fs, int len)
        {
            r.Start = r.End;
            r.End = r.Start + len;
            object ran = (object)r;

            GetDocument().Bookmarks.Add("UMXDEL" + master, ref ran);

            Tools.SetFieldStyle(r, fs);
        }

        private void ProcessShape(Microsoft.Office.Interop.PowerPoint.Shape s, Microsoft.Office.Interop.PowerPoint.Slide sld)
        {
            ProcessShape(s, sld, s.Tags["umxcode"]);
        }

        private string PersonsToPerson(string p)
        {
            string[] dat = p.Split(new[] {'#'});

            try
            {
                int i = Int32.Parse(dat[0]);
                return "" + i;
            }
            catch
            {
                return "0";
            }
        }

        private void ProcessShape(Microsoft.Office.Interop.PowerPoint.Shape s, Microsoft.Office.Interop.PowerPoint.Slide sld, string code)
        {
            //if (code.Contains("idivtl")) MessageBox.Show("process shape on slide " + sld.SlideID + "\ncode=" + code + "\nshape=" + s.Id, "process shape");

            try
            {
                Microsoft.Office.Interop.PowerPoint.Presentation pres = _pptApp.ActivePresentation;

                //MessageBox.Show(s.Tags["umxcode"]);
                PPTools tls = new PPTools(code, GetTarget(), eval);

                string[] master = (code+"|").Split(new char[] { '|' });


                string[] dat = master[0].Split(new char[] { ':' });
                string[] crosses = null;

                TargetData td = GetTarget();
                TargetData tdo = td.Clone;

                if (master.Length > 2 && master[2].Trim().Length > 0)
                {
                    //cross!
                    crosses = master[2].Split(new char[] { '#' });

                    foreach (string cross in crosses)
                    {
                        string[] cdat = cross.Split(new char[] { '.' });

                        int qid = Int32.Parse(cdat[0]);
                        int aid = Int32.Parse(cdat[1]);

                        td = Tools.Cross(eval, td, td.GetQuestion(qid, eval), aid);
                    }
                }

                if (td == null) return;

                string ins = string.Empty;

                Question q;
                if (!dat[1].Equals("op") &&!dat[1].Equals("op-c") && !dat[1].StartsWith("xml"))
                    q = td.GetQuestion(Int32.Parse(dat[2]), eval);
                else
                    q = null;

                Microsoft.Office.Interop.PowerPoint.Shape ns;
                
                try
                {
                    switch (dat[1])
                    {
                        case "table":
                            Table t = new Table(s.Tags["tableset"]);

                            int row = 2;

                            int x = 2;
                            foreach (Col c in t.Items)
                            {
                                s.Table.Cell(1, x).Shape.TextFrame.TextRange.Text = c.Type.ToString();

                                if (c.Type == Table.ColTypes.ProzentNachAntwort)
                                    s.Table.Cell(1,x).Shape.TextFrame.TextRange.Text = c.Type.ToString() + " - " + (c.ASel + 1);

                                x++;
                            }

                            foreach (int qid in t.Questions)
                            {
                                //wtab.Rows.Add(ref missing);
                                try
                                {
                                    s.Table.Cell(row, 1).Shape.TextFrame.TextRange.Text = qid.ToString();

                                    for (int tid = 0; tid < t.Items.Count; tid++)
                                    {
                                        Microsoft.Office.Interop.PowerPoint.Shape range = s.Table.Cell(row, (tid+2)).Shape;

                                        Col c = (Col)t.Items[tid];
                                        Question Tq = eval.Global.GetQuestion(qid, eval);

                                        switch (c.Type)
                                        {

                                            case Table.ColTypes.Leer:
                                                range.TextFrame.TextRange.Text = "";
                                                break;

                                            case Table.ColTypes.Gap:
                                                ProcessShape(range, sld, CreateCode("gap:" + qid + ":" + tls.dat[3] + ":" + tls.dat[4], master[2], tls.master[3]));
                                                break;

                                            case Table.ColTypes.Median:
                                                ProcessShape(range, sld, CreateCode("md:" + qid + ":" + tls.dat[3] + ":" + PersonsToPerson(tls.dat[4]), master[2],tls.master[3]));
                                                break;

                                            case Table.ColTypes.Mittelwert:
                                                ProcessShape(range, sld, CreateCode("mw:" + qid + ":" + tls.dat[3] + ":" + PersonsToPerson(tls.dat[4]), master[2], tls.master[3]));
                                                break;

                                            case Table.ColTypes.Prozent:
                                                ProcessShape(range, sld, CreateCode("pc:" + qid + ":" + tls.dat[3] + ":" + PersonsToPerson(tls.dat[4]), master[2], tls.master[3]));
                                                break;

                                            case Table.ColTypes.ProzentNachAntwort:
                                                if (Tq.Answers.Length > c.ASel)
                                                    ProcessShape(range, sld, CreateCode("apc:" + qid + ":" + tls.dat[3] + ":" + PersonsToPerson(tls.dat[4]) + ":" + Tq.AnswerList[c.ASel], master[2], master[3]));
                                                break;

                                            case Table.ColTypes.Fragentext:
                                                range.TextFrame.TextRange.Text = Tq.Text;
                                                break;

                                            case Table.ColTypes.Ampel:
                                                ProcessShape(range, sld, CreateCode("tl#:" + qid + ":" + tls.dat[3] + ":" + tls.dat[4], master[2], tls.master[3]));
                                                break;

                                            case Table.ColTypes.Prozentbalken:
                                                ProcessShape(range, sld, CreateCode("pbar#:" + qid + ":" + tls.dat[3] + ":" + tls.dat[4], master[2], tls.master[3]));
                                                break;

                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.StackTrace, ex.Message);
                                }

                                row++;
                            }


                            break;

                        case "pottbl":

                            s.Table.Cell(1, 1).Shape.TextFrame.TextRange.Text = "Gesamt";

                            ProcessShape(s.Table.Cell(1, 2).Shape, sld, CreateCode("mw:" + tls.dat[2] + ":" + tls.dat[3] + ":" + tls.dat[4], "", tls.master[3]));


                            s.Table.Cell(2, 1).Shape.TextFrame.TextRange.Text = "Filialen";
                            s.Table.Cell(2, 2).Shape.TextFrame.TextRange.Text = "Mittelwertsabweichung";
                            s.Table.Cell(2, 3).Shape.TextFrame.TextRange.Text = "Prozentabweichung";

                            int prow = 3;
                            foreach (string cans in tls.cq.AnswerList)
                            {
                                s.Table.Cell(prow, 1).Shape.TextFrame.TextRange.Text = cans;

                                ProcessShape(s.Table.Cell(prow, 2).Shape, sld, CreateCode("potval:" + tls.dat[2] + ":" + tls.dat[3] + ":" + tls.dat[4], tls.cqid + "." + (prow - 3), tls.master[3]));
                                ProcessShape(s.Table.Cell(prow, 3).Shape, sld, CreateCode("potpcnt:" + tls.dat[2] + ":" + tls.dat[3] + ":" + tls.dat[4], tls.cqid + "." + (prow - 3), tls.master[3]));
                                ProcessShape(s.Table.Cell(prow, 4).Shape, sld, CreateCode("potpic#:" + dat[2] + ":" + dat[3] + ":" + dat[4], tls.cqid + "." + (prow - 3), tls.master[3]));

                                

                                prow++;
                            }

     
                            break;

                        case "maturity":

                            //MessageBox.Show("huiy");
                            s.Table.Cell(1, 1).Shape.TextFrame.TextRange.Text = "Reifegrad/Führung";

                            s.Table.Cell(1, 2).Shape.TextFrame.TextRange.Text = "Telling";
                            s.Table.Cell(1, 3).Shape.TextFrame.TextRange.Text = "Selling";
                            s.Table.Cell(1, 4).Shape.TextFrame.TextRange.Text = "Participating";
                            s.Table.Cell(1, 5).Shape.TextFrame.TextRange.Text = "Delegating";

                            s.Table.Cell(2, 1).Shape.TextFrame.TextRange.Text = "R1";
                            s.Table.Cell(3, 1).Shape.TextFrame.TextRange.Text = "R2";
                            s.Table.Cell(4, 1).Shape.TextFrame.TextRange.Text = "R3";
                            s.Table.Cell(5, 1).Shape.TextFrame.TextRange.Text = "R4";
                            
                        
                            for (int r = 0; r < 4; r++)
                                for (int f = 0; f < 4; f++)
                                    ProcessShape(s.Table.Cell(r + 2, f + 2).Shape, sld, CreateCode("maturity-val:0:" + tls.dat[5] + ":" + tls.dat[6] + ":" + tls.dat[7] + ":" + tls.dat[8] + ":" + r + ":" + f + ":" + dat[4] + ":" + dat[3], master[2], tls.master[3]));

                            break;

                        case "maturity-val":
                            //1..2, 4..5

                            s.TextFrame.TextRange.Text = tls.ComputeMaturity() + "%";

                            break;

                        case "origaw":
                            Question oq = td.GetQuestion(Int32.Parse(dat[2]), eval);
                            //MessageBox.Show("get oq for " + Int32.Parse(dat[2]));
                            //text is 5
                            string otxt = dat[5];
                            if (oq.IsPlaceholder)
                            {
                                int oaid = oq.GetAnswerId(dat[5]);
                                QuestionPlaceholder ph = eval.GetPlaceholder(oq.ID);
                                if (ph != null && ph.AnswerList.Length > oaid)
                                    otxt = ph.AnswerList[oaid];
                            }

                            s.TextFrame.TextRange.Text = otxt;

                            break;

                        case "tagcloud-val":
                            ArrayList res = tls.ComputeTag();
                            s.TextFrame.TextRange.Text = (string)res[2];
                            //MessageBox.Show("fsize= " + res[1] + "/ Col =" + res[0]);
                            
                            s.TextFrame.TextRange.Font.Size = (float)res[1];
                            if (res[0] != null)
                                s.TextFrame.TextRange.Font.Color.RGB = ColorTranslator.ToWin32((Color)res[0]);
                            break;

                        case "mw": //Mittelwert
                            s.TextFrame.TextRange.Text = GetAverageValue(td, dat);
                            break;

                        case "xmlText":
                            {
                                IXmlText gr = XmlHelper.ComputeText(tls.GetXmlMaster(), GetTarget(), eval);
                                s.TextFrame.TextRange.Text = gr.Compute();
                            }
                            break;

                        case "bcont-value":
                            //get compare value

                            TargetData ctv = GetCTarget(Int32.Parse(dat[5]));

                            if (ctv != null)
                            {
                                double ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                                double ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAverageByPersonAsMark(multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                                s.TextFrame.TextRange.Text = "" + Math.Round(ctvoval - ctvcval, Int32.Parse(dat[3]));
                            }
                            else
                            {
                                MessageBox.Show("Konnte nicht auf Vergleichsdaten zugreifen. Sind alle nötigen Daten geladen?", "Banksteuerungsbericht");
                                s.TextFrame.TextRange.Text = "err";
                            }

                            break;

                        case "bcont-nps-value":
                            {
                                TargetData actvm = GetCTarget(Int32.Parse(dat[5]));
                                s.TextFrame.TextRange.Text =
                                    tls.NPS(actvm.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]),
                                            multiEvals[Int32.Parse(dat[5])]);
                            }
                            break;

                        case "bcont-nps-diff":
                            {
                                TargetData actvm = GetCTarget(Int32.Parse(dat[5]));
                                s.TextFrame.TextRange.Text =
                                    tls.NPSDiff(td.GetQuestion(Int32.Parse(dat[2]), eval), eval, actvm.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]),
                                            multiEvals[Int32.Parse(dat[5])]);
                            }
                            break;

                        case "bcont-comp-mw":
                            TargetData ctvm = GetCTarget(Int32.Parse(dat[5]));
                            double ctvcvalmw = ctvm.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAverageByPersonAsMark(multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);
                            s.TextFrame.TextRange.Text = "" + Math.Round(ctvcvalmw, Int32.Parse(dat[3]));
                            break;

                        case "bcont-light":
                            ns = sld.Shapes.AddPicture(tls.bcontLight(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "bcont-light-apc":
                            ns = sld.Shapes.AddPicture(tls.bcontLightApc(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "bcont-trend":
                            ns = sld.Shapes.AddPicture(tls.bconTrend(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "bcont-nps-trend":
                            ns = sld.Shapes.AddPicture(tls.bconTrendNPS(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "bcont-nps-tlb":
                            ns = sld.Shapes.AddPicture(tls.bcontLightNPS(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "bcont-trend-apc":
                            ns = sld.Shapes.AddPicture(tls.bconTrendApc(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "bcont-comp-apc":
                            TargetData aatd = GetCTarget(Int32.Parse(dat[5]));
                            Question aapq = aatd.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]);
                            float aapcnt;
                            if (tls.Base) aapcnt = aapq.GetAnswerPercentByPersonWithBase(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                            else aapcnt = (float)aapq.GetAnswerPercentByPerson(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                            //MessageBox.Show();
                            ins = "" + Math.Round(aapcnt, Int32.Parse(dat[3]));

                            s.TextFrame.TextRange.Text = ins + "%";

                            break;

                        case "bcont-value-apc":
                            TargetData vaatd = GetCTarget(Int32.Parse(dat[5]));
                            Question vaapq = vaatd.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]);

                            float vaapcnt;
                            if (tls.Base) vaapcnt = vaapq.GetAnswerPercentByPersonWithBase(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                            else vaapcnt = (float)vaapq.GetAnswerPercentByPerson(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                            Question vpq = td.GetQuestion(Int32.Parse(dat[2]), eval);

                            float vpcnt;
                            if (tls.Base)
                            {
                                vpcnt = vpq.GetAnswerPercentByPersonWithBase(dat[6], eval,
                                    eval.CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                            }
                            else
                            {
                                vpcnt = (float)vpq.GetAnswerPercentByPerson(dat[6], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                            }

                            ins = "" + Math.Round(vpcnt - vaapcnt, Int32.Parse(dat[3]));

                            s.TextFrame.TextRange.Text = ins + "%";

                            break;

                        case "apc":
                            s.TextFrame.TextRange.Text = GetPercentResponseValue(tls, td, dat);
                            break;

                        case "gap":
                            s.TextFrame.TextRange.Text = GetGapValue(td, dat);
                            break;

                        case "potpic":

                            ns = sld.Shapes.AddPicture(tls.Potpic(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);

                            PPTools.SetStyle(s, ns);

                            s.Delete();

                            break;

                        case "potpic#":

                            s.Fill.UserPicture(tls.Potpic());

                            break;

                        case "op":
                            try
                            {
                                ns = sld.Shapes.AddPicture(tls.op(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                                PPTools.SetStyle(s, ns);
                                s.Delete();
                            }
                            catch 
                            {
                                MessageBox.Show("Graphik konnte nicht berechnet werden\n" + code, "Fehler auf Folie #" + sld.SlideIndex);
                            }
                            break;

                        case "op-c":
                            try
                            {
                                ns = sld.Shapes.AddPicture(tls.opC(this), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                                PPTools.SetStyle(s, ns);
                                s.Delete();
                            }
                            catch 
                            {
                                MessageBox.Show("Graphik konnte nicht berechnet werden\n" + code, "Fehler auf Folie #" + sld.SlideIndex);
                            }
                            break;

                        case "pbar":
                            ns = sld.Shapes.AddPicture(tls.Pbar(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "tl":
                            ns = sld.Shapes.AddPicture(tls.Tl(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "tl#":
                            s.Fill.UserPicture(tls.Tl());
                            break;

                        case "pbar#":
                            s.Fill.UserPicture(tls.Pbar());
                            break;

                        case "idivtl":
                            ns = sld.Shapes.AddPicture(tls.Idivtl(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "exclamation-single":
                            ns = sld.Shapes.AddPicture(tls.ExclamationSingle(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;


                        case "xmlGraphic":
                            {
                                IXmlGraphic gr = XmlHelper.ComputeGraphic(tls.GetXmlMaster(), GetTarget(), eval);
                                ns = sld.Shapes.AddPicture(gr.Store(),
                                                           MsoTriState.msoFalse, MsoTriState.msoTrue,
                                                           s.Left, s.Top, s.Width, s.Height);
                                PPTools.SetStyle(s, ns);
                                s.Delete();
                            }
                            break;

                        case "exclamation-gap":
                            ns = sld.Shapes.AddPicture(tls.ExclamationGap(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "exclamation-compare":
                            ns = sld.Shapes.AddPicture(tls.ExclamationCompare(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "idivtlnps":
                            ns = sld.Shapes.AddPicture(tls.IdivtlNps(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "comparetl":
                            ns = sld.Shapes.AddPicture(tls.Comparetl(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "comparetlnps":
                            ns = sld.Shapes.AddPicture(tls.Comparetlnps(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "comparetidivtlpcnt":
                            ns = sld.Shapes.AddPicture(tls.Comparetlpcnt(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;


                        case "idivtlpcnt":
                            ns = sld.Shapes.AddPicture(tls.IdivtlPcnt(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "idivtlnum":
                            ns = sld.Shapes.AddPicture(tls.IdivtlNum(), MsoTriState.msoFalse, MsoTriState.msoTrue, s.Left, s.Top, s.Width, s.Height);
                            PPTools.SetStyle(s, ns);
                            s.Delete();
                            break;

                        case "potpcnt":
                            s.TextFrame.TextRange.Text = tls.Potpcnt();
                            break;

                        case "potval":
                            s.TextFrame.TextRange.Text = tls.Potval();
                            break;

                        case "n":
                            s.TextFrame.TextRange.Text = GetSampleSizeValue(td, dat);
                            break;

                        case "nps":
                            s.TextFrame.TextRange.Text = GetNpsValue(tls);
                            break;

                        case "md":
                            s.TextFrame.TextRange.Text = GetMedianValue(td, dat);
                            break;

                        case "pc":
                            s.TextFrame.TextRange.Text = GetPercentValue(td, dat);
                            break;

                        case "aabs":
                            Question apq = td.GetQuestion(Int32.Parse(dat[2]), eval);
                            float apcnt = apq.GetAnswerCountByPerson(dat[5], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

                            ins = "" + Math.Round(apcnt, Int32.Parse(dat[3]));
                            s.TextFrame.TextRange.Text = ins;
                            break;

                        case "aas":
                            s.TextFrame.TextRange.Text = GetAverageReplyNumValue(td, dat);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "err on prep/main");
            }

            //MessageBox("process done: " + s.Tags["umxcode"]);
        }

        private string GetMedianValue(TargetData td, string[] dat)
        {
            var question = td.GetQuestion(Int32.Parse(dat[2]), eval);
            var digits = Int32.Parse(dat[3]);
            var personSetting = eval.CombinedPersons[Int32.Parse(dat[4])];
            var median = question.GetMedianByPersonAsMark(eval, personSetting, digits);

            return string.Format("{0}", Math.Round(median, digits));
        }

        private string GetAverageValue(TargetData td, string[] dat)
        {
            var question = td.GetQuestion(Int32.Parse(dat[2]), eval);
            var personSetting = eval.CombinedPersons[Int32.Parse(dat[4])];
            var average = question.GetAverageByPersonAsMark(eval, personSetting);
            var digits = Int32.Parse(dat[3]);
            var val = Math.Round(average, digits);

            if (val == -1)
            {
                return "k.A.";
            }

            return val.ToString();
        }

        private string GetPercentValue(TargetData td, string[] dat)
        {
            var question = td.GetQuestion(Int32.Parse(dat[2]), eval);
            var personSetting = eval.CombinedPersons[Int32.Parse(dat[4])];
            var percent = ((5f - question.GetAverageByPersonAsMark(eval, personSetting)) / 4f) * 100;
            var digits = Int32.Parse(dat[3]);

            return string.Format("{0}", Math.Round(percent, digits));
        }

        private string GetPercentResponseValue(PPTools tls, TargetData td, string[] dat)
        {
            var question = td.GetQuestion(Int32.Parse(dat[2]), eval);
            var personSetting = eval.CombinedPersons[Int32.Parse(dat[4])];
            var digits = Int32.Parse(dat[3]);

            float pcnt;
            if (tls.Base)
            {
                pcnt = question.GetAnswerPercentByPersonWithBase(dat[5], eval, personSetting, tls.bq);
            }
            else
            {
                pcnt = (float)question.GetAnswerPercentByPerson(dat[5], eval, personSetting);
            }

            return string.Format("{0}%", Math.Round(pcnt, digits));
        }

        private string GetGapValue(TargetData td, string[] dat)
        {
            //2: id
            //3: prec
            //4: plist

            var question = td.GetQuestion(Int32.Parse(dat[2]), eval);
            var digits = Int32.Parse(dat[3]);

            string[] pids = dat[4].Split(new[] { '#' });

            if (pids.Length >= 2)
            {
                int p1 = Int32.Parse(pids[0]);
                int p2 = Int32.Parse(pids[1]);

                double v1 = question.GetAverageByPersonAsMark(eval, eval.CombinedPersons[p1]);
                double v2 = question.GetAverageByPersonAsMark(eval, eval.CombinedPersons[p2]);

                return Math.Round(Math.Abs(v1 - v2), digits).ToString();
            }

            return "k.A.";
        }

        private string GetNpsValue(PPTools tls)
        {
            return tls.NPS();
        }

        private string GetSampleSizeValue(TargetData td, string[] dat)
        {
            var question = td.GetQuestion(Int32.Parse(dat[2]), eval);
            var personIds = dat[4].Split(new[] { '#' });

            int answersByPersonCount = 0;

            foreach (string personId in personIds)
            {
                var personSetting = eval.CombinedPersons[Int32.Parse(personId)];
                answersByPersonCount += question.NAnswersByPerson(eval, personSetting);
            }

            return answersByPersonCount.ToString();
        }

        private string GetAverageReplyNumValue(TargetData td, string[] dat)
        {
            var question = td.GetQuestion(Int32.Parse(dat[2]), eval);
            var personSetting = eval.CombinedPersons[Int32.Parse(dat[4])];
            var digits = Int32.Parse(dat[3]);

            var averageAnswersByUser = question.GetAverageAnswersByUser(eval, personSetting);

            return Math.Round(averageAnswersByUser, digits).ToString();
        }

        private void ProcessField(Microsoft.Office.Interop.Word.Field f)
        {
            if (eval == null) return;

            PPTools tls = new PPTools(f.Code.Text, GetTarget(), eval);

            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)_applicationObject;
            object wchar = Microsoft.Office.Interop.Word.WdUnits.wdCharacter;
            Microsoft.Office.Interop.Word.Document doc = GetDocument();

            object ltof = false;
            object inline = true;

            string[] master = (f.Code.Text + "|").Split(new char[] { '|' });
            /*
            if (master.Length >= 2)
            {
                foreach (Microsoft.Office.Interop.Word.Bookmark bmk in doc.Bookmarks)
                {
                    if (bmk.Name.StartsWith("UMXDEL" + master[1]))
                    {
                        bmk.Range.Select();

                        try 
                        { 
                            wordapp.Selection.Cut();
                            //if (master[1].Equals("3655")) MessageBox.Show("remove 3655");
                        }
                        catch { }
                    }
                }
            }
             */

            string[] dat = master[0].Split(new char[] { ':' });
            string[] crosses = null;

            TargetData td = GetTarget();
            TargetData tdo = td.Clone;

            if (master.Length > 2 && master[2].Trim().Length > 0)
            {
                //cross!
                crosses = master[2].Split(new char[] { '#' });

                foreach (string cross in crosses)
                {
                    string[] cdat = cross.Split(new char[] { '.' });

                    int qid = Int32.Parse(cdat[0]);
                    int aid = Int32.Parse(cdat[1]);

                    td = Tools.Cross(eval, td, td.GetQuestion(qid, eval), aid);
                }
            }

            if (td == null) return;

            string ins = string.Empty;
            //Microsoft.Office.Interop.Word.Range r = null;
            //object ran = null;

            FieldStyle fs = Tools.GetFieldStyle(f);

            f.ShowCodes = false;

            Question q;
            
            if (!dat[1].Equals("op") && !dat[1].Equals("op-c") && !dat[1].StartsWith("xml"))
                q = td.GetQuestion(Int32.Parse(dat[2]), eval);
            else
                q = null;

            try
            {
                switch (dat[1])
                {
                    case "potpic":

                        //master
                        if (crosses == null) break;

                        int iqid = 0;
                        int iaid = -1;
                        foreach (string cross in crosses)
                        {
                            string[] cdat = cross.Split(new char[] { '.' });

                            iqid = Int32.Parse(cdat[0]);
                            iaid = Int32.Parse(cdat[1]);
                        }


                        if (iqid == 0 || iaid == -1) break;

                        QuestionSplit iqsplit = new QuestionSplit(tdo.GetQuestion(Int16.Parse(dat[2]), eval), tdo.GetQuestion(iqid, eval));

                        Question[] iqlist = iqsplit.ComputeQuestionSplits(eval);


                        float iptotavg = tdo.GetQuestion(Int16.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - 1;

                        float ppp = 0;
                        foreach (Question iqlq in iqlist)
                        {
                            if (iqlq.ID == iaid)
                            {
                                float myavg = iqlq.GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - 1;

                                ppp = (float)Math.Round((((myavg - iptotavg) / iptotavg) * 100), 0);

                                ppp = ppp * -1;
                            }
                        }

                        string pbfname = Path.GetTempFileName() + ".png";

                        Tools.CreatePotBar(eval, ppp, true, 50, 180, 20).Save(pbfname, ImageFormat.Png);

                        object pr96 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape pbshape = doc.InlineShapes.AddPicture(pbfname, ref ltof, ref inline, ref pr96);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range pbrb = f.Result;

                        pbrb.Start = pbrb.End;
                        pbrb.End = pbrb.Start + 1;
                        object pbranb = (object)pbrb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref pbranb);

                        break;

                    case "potpcnt":

                        /*
                        //master
                        if (crosses == null) break;

                        int qid = 0;
                        int aid = -1;
                        foreach (string cross in crosses)
                        {
                            string[] cdat = cross.Split(new char[] { '.' });

                            qid = Int32.Parse(cdat[0]);
                            aid = Int32.Parse(cdat[1]);
                        }


                        if (qid == 0 || aid == -1) break;

                        QuestionSplit qsplit = new QuestionSplit(tdo.GetQuestion(Int16.Parse(dat[2]), eval), tdo.GetQuestion(qid, eval));

                        Question[] qlist = qsplit.ComputeQuestionSplits(eval);


                        float ptotavg = tdo.GetQuestion(Int16.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - 1;

                        foreach (Question qlq in qlist)
                        {
                            if (qlq.ID == aid)
                            {
                                float myavg = qlq.GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - 1;

                                ins = "" + (Math.Round((((myavg - ptotavg) / ptotavg) * 100), Int32.Parse(dat[3])) * -1);
                            }
                        }
                         * */

                        ins = tls.Potpcnt().ToString();

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);

                        break;


                    case "potval":

                        //master
                        /*
                        double vmval = GetTarget().GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                        double vval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

                        if (vval == -1 || vmval == -1) ins = "k.A.";
                        else
                        {
                            double vp = vval - vmval;

                            //vp = vp * -1;

                            ins = "";
                            if (vp > 0) ins = "+"; 

                            ins += "" + Math.Round(vp, Int32.Parse(dat[3]));
                        }
                         * */
                        /*
                        if (crosses == null) break;

                        int vqid = 0;
                        int vaid = -1;
                        foreach (string cross in crosses)
                        {
                            string[] cdat = cross.Split(new char[] { '.' });

                            vqid = Int32.Parse(cdat[0]);
                            vaid = Int32.Parse(cdat[1]);
                        }


                        if (vqid == 0 || vaid == -1) break;

                        QuestionSplit vqsplit = new QuestionSplit(tdo.GetQuestion(Int16.Parse(dat[2]), eval), tdo.GetQuestion(vqid, eval));

                        Question[] vqlist = vqsplit.ComputeQuestionSplits(eval);


                        float totavg = tdo.GetQuestion(Int16.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - 1;

                        foreach (Question vqlq in vqlist)
                        {
                            if (vqlq.ID == vaid)
                            {
                                ins = "" + (Math.Round((vqlq.GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - totavg) - 1, Int32.Parse(dat[3])) * -1);
                            }
                        }
                        */
                        
                        ins = tls.Potval().ToString();

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);

                        break;

                    case "aas": //durchschnittliche anzahl antworten
                        ins = "" + Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageAnswersByUser(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);
                        break;

                    case "origaw":
                        Question oq = td.GetQuestion(Int32.Parse(dat[2]), eval);
                        //text is 5
                        string otxt = dat[5];
                        if (oq.IsPlaceholder)
                        {
                            int oaid = oq.GetAnswerId(dat[5]);
                            QuestionPlaceholder ph = eval.GetPlaceholder(oq.ID);
                            if (ph != null && ph.AnswerList.Length > oaid)
                                otxt = ph.AnswerList[oaid];
                        }

                        f.Select();

                        wordapp.Selection.TypeText(otxt);

                        SetProps(f.Result, master[1], fs, otxt.Length);

                        break;

                    case "maturity-val":
                        //1..2, 4..5

                        ins = tls.ComputeMaturity();
                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);

                        break;

                    case "tagcloud-val":
                        ArrayList res = tls.ComputeTag();

                        ins = (string)res[2];


                        f.Select();

                        _wordApp.Selection.Font.Size = (float)res[1];
                        if (res[0] != null) _wordApp.Selection.Font.Color = (Microsoft.Office.Interop.Word.WdColor)System.Drawing.ColorTranslator.ToWin32((Color)res[0]);
                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);

                        break;

                    case "pbar": //percent bar


                        string bfname = System.IO.Path.GetTempFileName() + ".png";

                        Tools.CreateBarImage(eval, q, eval.CombinedPersons[Int32.Parse(dat[4])], 180, 17).Save(bfname, System.Drawing.Imaging.ImageFormat.Png);

                        object r96 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape bshape = doc.InlineShapes.AddPicture(bfname, ref ltof, ref inline, ref r96);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range brb = f.Result;

                        brb.Start = brb.End;
                        brb.End = brb.Start + 1;
                        object branb = (object)brb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref branb);

                        break;

                    case "tl": //ampel

                        double tval = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));


                        string tfname = System.IO.Path.GetTempFileName() + ".png";

                        Tools.CreateTLImage(eval, tval, 8).Save(tfname, System.Drawing.Imaging.ImageFormat.Png);

                        object r97 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape tshape = doc.InlineShapes.AddPicture(tfname, ref ltof, ref inline, ref r97);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range trb = f.Result;

                        trb.Start = trb.End;
                        trb.End = trb.Start + 1;
                        object tranb = (object)trb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref tranb);

                        break;


                    case "idivtl": //individuelle ampel

                        try
                        {
                            LogHelper.GetLogger().Info(
                                String.Format("IDIVTL (Individual Traffic Light) for question = '{0}'",
                                    Int32.Parse(dat[2])));

                            double itval = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));


                            float x1 = float.Parse(dat[8]);
                            float x2 = float.Parse(dat[9]);

                            string[] dss = dat[5].Split(new char[] { '-' });
                            Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                            dss = dat[6].Split(new char[] { '-' });
                            Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                            dss = dat[7].Split(new char[] { '-' });
                            Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                            int rad = Int32.Parse(dat[10]);

                            //string itfname = System.IO.Path.GetTempFileName() + ".png";

                            String imageFolder = doc.Path + "/" + doc.Name + "_images/";

                            if (!Directory.Exists(imageFolder))
                            {
                                try
                                {
                                    Directory.CreateDirectory(imageFolder);
                                } catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message + ex.StackTrace, "failed to create dir");
                                }
                            }

                            String itfname = imageFolder + Guid.NewGuid() + ".png";

                            // delete temp file if exists
                            //File.Delete(itfname);

                            Tools.CreateTLImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, ImageFormat.Png);


                            object tr97 = f.Result;

                            object referenceToFile = true;
                            object saveInline = false;

                            Microsoft.Office.Interop.Word.InlineShape itshape = doc.InlineShapes.AddPicture(itfname, ref referenceToFile, ref saveInline, ref tr97);
                            //tshape.Width = 12f;
                            //tshape.Height = 12f;

                            //bookmark
                            Microsoft.Office.Interop.Word.Range itrb = f.Result;

                            itrb.Start = itrb.End;
                            itrb.End = itrb.Start + 1;
                            object itranb = (object)itrb;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref itranb);

                            // delete temp file if exists
                            //File.Delete(itfname);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.StackTrace, ex.Message);
                        }
                        break;

                    case "comparetl":
                        string cppblitfname = tls.Comparetl();

                        object cppbltr97 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape cppblitshape = doc.InlineShapes.AddPicture(cppblitfname, ref ltof, ref inline, ref cppbltr97);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range cppblitrb = f.Result;

                        cppblitrb.Start = cppblitrb.End;
                        cppblitrb.End = cppblitrb.Start + 1;
                        object cppblitranb = (object)cppblitrb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref cppblitranb);
                        break;

                    case "comparetlnps":
                        string Xcppblitfname = tls.Comparetlnps();

                        object Xcppbltr97 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape Xcppblitshape = doc.InlineShapes.AddPicture(Xcppblitfname, ref ltof, ref inline, ref Xcppbltr97);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range Xcppblitrb = f.Result;

                        Xcppblitrb.Start = Xcppblitrb.End;
                        Xcppblitrb.End = Xcppblitrb.Start + 1;
                        object Xcppblitranb = (object)Xcppblitrb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref Xcppblitranb);
                        break;

                    case "compareidivtlpcnt":
                        string cXcppblitfname = tls.Comparetlpcnt();

                        object cXcppbltr97 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape cXcppblitshape = doc.InlineShapes.AddPicture(cXcppblitfname, ref ltof, ref inline, ref cXcppbltr97);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range cXcppblitrb = f.Result;

                        cXcppblitrb.Start = cXcppblitrb.End;
                        cXcppblitrb.End = cXcppblitrb.Start + 1;
                        object cXcppblitranb = (object)cXcppblitrb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref cXcppblitranb);
                        break;

                    case "idivtlpcnt":
                        string ppblitfname = tls.IdivtlPcnt();

                        object ppbltr97 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape ppblitshape = doc.InlineShapes.AddPicture(ppblitfname, ref ltof, ref inline, ref ppbltr97);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range ppblitrb = f.Result;

                        ppblitrb.Start = ppblitrb.End;
                        ppblitrb.End = ppblitrb.Start + 1;
                        object ppblitranb = (object)ppblitrb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref ppblitranb);
                        break;

                    case "idivtlnps":
                        string nsppblitfname = tls.IdivtlNps();
                        
                        object nsppbltr97 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape nsppblitshape = doc.InlineShapes.AddPicture(nsppblitfname, ref ltof, ref inline, ref nsppbltr97);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range nsppblitrb = f.Result;

                        nsppblitrb.Start = nsppblitrb.End;
                        nsppblitrb.End = nsppblitrb.Start + 1;
                        object nsppblitranb = (object)nsppblitrb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref nsppblitranb);
                        break;

                    case "exclamation-single":
                        {
                            String insertFile = tls.ExclamationSingle();
                            object fieldResult = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape insertShape = doc.InlineShapes.AddPicture(insertFile, ref ltof, ref inline, ref fieldResult);

                            //bookmark
                            Microsoft.Office.Interop.Word.Range bookmarkRange = f.Result;

                            bookmarkRange.Start = bookmarkRange.End;
                            bookmarkRange.End = bookmarkRange.Start + 1;
                            object bookmark = (object)bookmarkRange;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref bookmark);
                            break;
                        }

                    case "exclamation-gap":
                        {
                            String insertFile = tls.ExclamationGap();
                            object fieldResult = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape insertShape = doc.InlineShapes.AddPicture(insertFile, ref ltof, ref inline, ref fieldResult);

                            //bookmark
                            Microsoft.Office.Interop.Word.Range bookmarkRange = f.Result;

                            bookmarkRange.Start = bookmarkRange.End;
                            bookmarkRange.End = bookmarkRange.Start + 1;
                            object bookmark = (object)bookmarkRange;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref bookmark);
                            break;
                        }

                    case "exclamation-compare":
                        {
                            String insertFile = tls.ExclamationCompare();
                            object fieldResult = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape insertShape = doc.InlineShapes.AddPicture(insertFile, ref ltof, ref inline, ref fieldResult);

                            //bookmark
                            Microsoft.Office.Interop.Word.Range bookmarkRange = f.Result;

                            bookmarkRange.Start = bookmarkRange.End;
                            bookmarkRange.End = bookmarkRange.Start + 1;
                            object bookmark = (object)bookmarkRange;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref bookmark);
                            break;
                        }

                    case "xmlGraphic":
                        {
                            IXmlGraphic gr = XmlHelper.ComputeGraphic(tls.GetXmlMaster(), GetTarget(), eval);

                            String insertFile = gr.Store();
                            object fieldResult = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape insertShape = doc.InlineShapes.AddPicture(insertFile, ref ltof, ref inline, ref fieldResult);

                            //bookmark
                            Microsoft.Office.Interop.Word.Range bookmarkRange = f.Result;

                            bookmarkRange.Start = bookmarkRange.End;
                            bookmarkRange.End = bookmarkRange.Start + 1;
                            object bookmark = (object)bookmarkRange;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref bookmark);
                            break;
                        }

                    case "xmlText":
                        {
                            IXmlText gr = XmlHelper.ComputeText(tls.GetXmlMaster(), GetTarget(), eval);
                            ins = gr.Compute();
                            
                            f.Select();

                            wordapp.Selection.TypeText(ins);

                            SetProps(f.Result, master[1], fs, ins.Length);
                            break;
                        }

                    case "idivtlnum":
                        string nppblitfname = tls.IdivtlNum();

                        object nppbltr97 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape nppblitshape = doc.InlineShapes.AddPicture(nppblitfname, ref ltof, ref inline, ref nppbltr97);

                        //bookmark
                        Microsoft.Office.Interop.Word.Range nppblitrb = f.Result;

                        nppblitrb.Start = nppblitrb.End;
                        nppblitrb.End = nppblitrb.Start + 1;
                        object nppblitranb = (object)nppblitrb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref nppblitranb);
                        break;

                    case "n": //stichproben
                        string[] npids = dat[4].Split(new char[] { '#' });

                        int n = 0;

                        foreach (string pid in npids)
                        {
                            n += q.NAnswersByPerson(eval, eval.CombinedPersons[Int32.Parse(pid)]);
                        }

                        ins = n.ToString();

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);

                        break;

                    case "nps"://net promoter score
                        ins = tls.NPS();

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);


                        break;

                    case "gap"://Gap

                        //2: id
                        //3: prec
                        //4: plist

                        string[] pids = dat[4].Split(new char[] { '#' });

                        if (pids.Length >= 2)
                        {
                            int p1 = Int32.Parse(pids[0]);
                            int p2 = Int32.Parse(pids[1]);

                            double v1 = q.GetAverageByPersonAsMark(eval, eval.CombinedPersons[p1]);
                            double v2 = q.GetAverageByPersonAsMark(eval, eval.CombinedPersons[p2]);

                            ins = "" + Math.Round(Math.Abs(v1 - v2), Int32.Parse(dat[3]));

                            f.Select();

                            wordapp.Selection.TypeText(ins);

                            SetProps(f.Result, master[1], fs, ins.Length);
                        }

                        break;

                    case "md": //Median

                        ins = "" + Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetMedianByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])], Int32.Parse(dat[3])), Int32.Parse(dat[3]));

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);
                        break;

                    case "mw": //Mittelwert

                        double val = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));

                        if (val == -1) ins = "k.A.";
                        else ins = "" + val;

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);

                        //if (master[1].Equals("3655")) MessageBox.Show("added 3655");
                        break;



                    case "bcont-value":
                        //get compare value

                        
                        TargetData ctv = GetCTarget(Int32.Parse(dat[5]));

                        if (ctv != null)
                        {
                            double ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                            double ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAverageByPersonAsMark(multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                            ins = "" + Math.Round(ctvoval - ctvcval, Int32.Parse(dat[3]));
                        }
                        else
                        {
                            MessageBox.Show("Konnte nicht auf Vergleichsdaten zugreifen. Sind alle nötigen Daten geladen?", "Banksteuerungsbericht");
                            ins = "err";
                        }

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);

                        break;

                    case "bcont-comp-mw":
                        TargetData ctvm = GetCTarget(Int32.Parse(dat[5]));
                        double ctvcvalmw = ctvm.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAverageByPersonAsMark(multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);
                        ins = "" + Math.Round(ctvcvalmw, Int32.Parse(dat[3]));
                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);
                        break;

                    case "bcont-comp-apc":
                        TargetData aatd = GetCTarget(Int32.Parse(dat[5]));
                        Question aapq = aatd.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]);
                        
                        float aapcnt;
                        if (tls.Base) aapcnt = aapq.GetAnswerPercentByPersonWithBase(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                        else aapcnt = (float)aapq.GetAnswerPercentByPerson(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                        ins = "" + Math.Round(aapcnt, Int32.Parse(dat[3]));

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);
                        break;

                    case "bcont-value-apc":
                        TargetData vaatd = GetCTarget(Int32.Parse(dat[5]));


                        Question vaapq = vaatd.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]);

                        float vaapcnt;
                        if (tls.Base) vaapcnt = vaapq.GetAnswerPercentByPersonWithBase(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                        else vaapcnt = (float)vaapq.GetAnswerPercentByPerson(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                        Question vpq = td.GetQuestion(Int32.Parse(dat[2]), eval);

                        float vpcnt;
                        if (tls.Base) vpcnt = vpq.GetAnswerPercentByPersonWithBase(dat[6], eval, eval.CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                        else vpcnt = (float)vpq.GetAnswerPercentByPerson(dat[6], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);


                        ins = "" + Math.Round(vpcnt - vaapcnt, Int32.Parse(dat[3]));

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);

                        break;

                    case "bcont-nps-value":
                        {
                            TargetData actvm = GetCTarget(Int32.Parse(dat[5]));
                            ins =
                                tls.NPS(actvm.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]),
                                        multiEvals[Int32.Parse(dat[5])]);

                            f.Select();

                            wordapp.Selection.TypeText(ins);

                            SetProps(f.Result, master[1], fs, ins.Length);
                        }
                        break;

                    case "bcont-nps-diff":
                        {
                            TargetData actvm = GetCTarget(Int32.Parse(dat[5]));
                            ins =
                                tls.NPSDiff(td.GetQuestion(Int32.Parse(dat[2]), eval), eval, actvm.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]),
                                        multiEvals[Int32.Parse(dat[5])]);

                            f.Select();

                            wordapp.Selection.TypeText(ins);

                            SetProps(f.Result, master[1], fs, ins.Length);
                        }
                        break;


                    case "bcont-light":
                        {
                            string blitfname = tls.bcontLight(GetCTarget(Int32.Parse(dat[5])), multiEvals);

                            object bltr97 = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape blitshape = doc.InlineShapes.AddPicture(
                                blitfname, ref ltof, ref inline, ref bltr97);
                            //tshape.Width = 12f;
                            //tshape.Height = 12f;

                            //bookmark
                            Microsoft.Office.Interop.Word.Range blitrb = f.Result;

                            blitrb.Start = blitrb.End;
                            blitrb.End = blitrb.Start + 1;
                            object blitranb = (object) blitrb;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref blitranb);
                        }
                        break;

                    

                    case "bcont-nps-tlb":
                        {
                            string blitfname = tls.bcontLightNPS(GetCTarget(Int32.Parse(dat[5])), multiEvals);

                            object bltr97 = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape blitshape = doc.InlineShapes.AddPicture(
                                blitfname, ref ltof, ref inline, ref bltr97);
                            //tshape.Width = 12f;
                            //tshape.Height = 12f;

                            //bookmark
                            Microsoft.Office.Interop.Word.Range blitrb = f.Result;

                            blitrb.Start = blitrb.End;
                            blitrb.End = blitrb.Start + 1;
                            object blitranb = (object)blitrb;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref blitranb);
                        }
                        break;

                    case "bcont-light-apc":

                        string xblitfname = tls.bcontLightApc(GetCTarget(Int32.Parse(dat[5])), multiEvals);

                        object xbltr97 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape xblitshape = doc.InlineShapes.AddPicture(xblitfname, ref ltof, ref inline, ref xbltr97);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range xblitrb = f.Result;

                        xblitrb.Start = xblitrb.End;
                        xblitrb.End = xblitrb.Start + 1;
                        object xblitranb = (object)xblitrb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref xblitranb);
                        break;

                    
                    case "bcont-Exclamation":
                        {
                            string blitfname = tls.bconExclamation(GetCTarget(Int32.Parse(dat[5])), multiEvals);

                            object bltr97 = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape blitshape = doc.InlineShapes.AddPicture(
                                blitfname, ref ltof, ref inline, ref bltr97);
                            //tshape.Width = 12f;
                            //tshape.Height = 12f;

                            //bookmark
                            Microsoft.Office.Interop.Word.Range blitrb = f.Result;

                            blitrb.Start = blitrb.End;
                            blitrb.End = blitrb.Start + 1;
                            object blitranb = (object)blitrb;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref blitranb);
                        }
                        break;
                    case "bcont-Exclamation-apc":
                        string xblitfname1 = tls.bconExclamationApc(GetCTarget(Int32.Parse(dat[5])), multiEvals);

                        object xbltr97_1 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape xblitshape_1 = doc.InlineShapes.AddPicture(
                            xblitfname1, ref ltof, ref inline, ref xbltr97_1);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range xblitrb1 = f.Result;

                        xblitrb1.Start = xblitrb1.End;
                        xblitrb1.End = xblitrb1.Start + 1;
                        object xblitranb1 = (object)xblitrb1;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref xblitranb1);
                        break;
                    case "bcont-Exclamation-nps":
                        {
                            string blitfname1 = tls.bconExclamationNPS(GetCTarget(Int32.Parse(dat[5])), multiEvals);

                            object bltr97_1 = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape blitshape1 = doc.InlineShapes.AddPicture(
                                blitfname1, ref ltof, ref inline, ref bltr97_1);
                            //tshape.Width = 12f;
                            //tshape.Height = 12f;

                            //bookmark
                            Microsoft.Office.Interop.Word.Range blitrb1 = f.Result;

                            blitrb1.Start = blitrb1.End;
                            blitrb1.End = blitrb1.Start + 1;
                            object blitranb1 = (object)blitrb1;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref blitranb1);
                        }
                        break;

                    case "bcont-trend":
                        {

                            string btitfname = tls.bconTrend(GetCTarget(Int32.Parse(dat[5])), multiEvals);

                            object bttr97 = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape btitshape = doc.InlineShapes.AddPicture(
                                btitfname, ref ltof, ref inline, ref bttr97);
                            //tshape.Width = 12f;
                            //tshape.Height = 12f;

                            //bookmark
                            Microsoft.Office.Interop.Word.Range btitrb = f.Result;

                            btitrb.Start = btitrb.End;
                            btitrb.End = btitrb.Start + 1;
                            object btitranb = (object) btitrb;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref btitranb);
                        }
                        break;

                    case "bcont-nps-trend":
                        {

                            string btitfname = tls.bconTrendNPS(GetCTarget(Int32.Parse(dat[5])), multiEvals);

                            object bttr97 = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape btitshape = doc.InlineShapes.AddPicture(
                                btitfname, ref ltof, ref inline, ref bttr97);
                            //tshape.Width = 12f;
                            //tshape.Height = 12f;

                            //bookmark
                            Microsoft.Office.Interop.Word.Range btitrb = f.Result;

                            btitrb.Start = btitrb.End;
                            btitrb.End = btitrb.Start + 1;
                            object btitranb = (object)btitrb;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref btitranb);
                        }
                        break;

                    case "bcont-trend-apc":

                        string xbtitfname = tls.bconTrendApc(GetCTarget(Int32.Parse(dat[5])), multiEvals);

                        object xbttr97 = f.Result;

                        Microsoft.Office.Interop.Word.InlineShape xbtitshape = doc.InlineShapes.AddPicture(xbtitfname, ref ltof, ref inline, ref xbttr97);
                        //tshape.Width = 12f;
                        //tshape.Height = 12f;

                        //bookmark
                        Microsoft.Office.Interop.Word.Range xbtitrb = f.Result;

                        xbtitrb.Start = xbtitrb.End;
                        xbtitrb.End = xbtitrb.Start + 1;
                        object xbtitranb = (object)xbtitrb;
                        doc.Bookmarks.Add("UMXDEL" + master[1], ref xbtitranb);
                        break;

                    case "pc": //Prozent

                        ins = "" + Math.Round(((5f - td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])])) / 4f) * 100, Int32.Parse(dat[3]));


                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);
                        break;

                    case "apc": //AntwortProzent

                        Question pq = td.GetQuestion(Int32.Parse(dat[2]), eval);
                        
                        float pcnt;
                        if (tls.Base) pcnt = pq.GetAnswerPercentByPersonWithBase(dat[5], eval, eval.CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                        else pcnt = (float)pq.GetAnswerPercentByPerson(dat[5], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

                        ins = "" + Math.Round(pcnt, Int32.Parse(dat[3]));

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);
                        break;

                    case "aabs": //AntwortAbsolutwert

                        Question apq = td.GetQuestion(Int32.Parse(dat[2]), eval);
                        float apcnt = apq.GetAnswerCountByPerson(dat[5], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

                        ins = "" + Math.Round(apcnt, Int32.Parse(dat[3]));

                        f.Select();

                        wordapp.Selection.TypeText(ins);

                        SetProps(f.Result, master[1], fs, ins.Length);
                        break;

                    case "op": //Graph. output

                        foreach (Report rep in eval.Reports)
                        {
                            if (rep.Name.Equals(dat[2]))
                            {
                                foreach (Output o in rep.Outputs)
                                {
                                    if (o.Name.Equals(dat[3]))
                                    {
                                        //o.width = (int) float.Parse(dat[4]);
                                        //o.height = (int) float.Parse(dat[5]);

                                        o.LoadTargetQ(td);

                                        o.Eval = eval;

                                        o.Compute();

                                        string fname = System.IO.Path.GetTempFileName() + ".png";

                                        EncoderParameters ep = new EncoderParameters(1);
                                        ep.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                                        ImageCodecInfo ici = null;

                                        foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                                        {

                                            if (codec.MimeType == "image/png")

                                                ici = codec;

                                        }

                                        o.OutputImage.Save(fname, ici, ep);

                                        object r98 = f.Result;

                                        Microsoft.Office.Interop.Word.InlineShape shape = doc.InlineShapes.AddPicture(fname, ref ltof, ref inline, ref r98);
                                        shape.Width = float.Parse(dat[4]);
                                        shape.Height = float.Parse(dat[5]);

                                        shape.AlternativeText = "umo" + master[1];

                                        //bookmark
                                        Microsoft.Office.Interop.Word.Range rb = f.Result;

                                        rb.Start = rb.End;
                                        rb.End = rb.Start + 1;
                                        object ranb = (object)rb;
                                        doc.Bookmarks.Add("UMXDEL" + master[1], ref ranb);

                                        break;
                                    }
                                }

                                break;
                            }
                        }

                        break;

                    case "op-c": //Graph. output

                        // compare data: dat[6]
                        int ceval = Int32.Parse(dat[6]);

                        foreach (Report rep in GetCEval(ceval).Reports)
                        {
                            if (rep.Name.Equals(dat[2]))
                            {
                                foreach (Output o in rep.Outputs)
                                {
                                    if (o.Name.Equals(dat[3]))
                                    {
                                        //o.width = (int) float.Parse(dat[4]);
                                        //o.height = (int) float.Parse(dat[5]);

                                        o.LoadTargetQ(GetCTarget(ceval));

                                        o.Eval = GetCEval(ceval);

                                        o.Compute();

                                        string fname = System.IO.Path.GetTempFileName() + ".png";

                                        EncoderParameters ep = new EncoderParameters(1);
                                        ep.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                                        ImageCodecInfo ici = null;

                                        foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                                        {

                                            if (codec.MimeType == "image/png")

                                                ici = codec;

                                        }

                                        o.OutputImage.Save(fname, ici, ep);

                                        object r98 = f.Result;

                                        Microsoft.Office.Interop.Word.InlineShape shape = doc.InlineShapes.AddPicture(fname, ref ltof, ref inline, ref r98);
                                        shape.Width = float.Parse(dat[4]);
                                        shape.Height = float.Parse(dat[5]);

                                        shape.AlternativeText = "umo" + master[1];

                                        //bookmark
                                        Microsoft.Office.Interop.Word.Range rb = f.Result;

                                        rb.Start = rb.End;
                                        rb.End = rb.Start + 1;
                                        object ranb = (object)rb;
                                        doc.Bookmarks.Add("UMXDEL" + master[1], ref ranb);

                                        break;
                                    }
                                }

                                break;
                            }
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(typeof(Connect)).Error("Exception on field computation", ex);
                /*
                //screwed up field code, ignore
                if (master != null && master.Length > 1)
                    MessageBox.Show(ex.StackTrace, "processfield error on " + master[1] + ": " + ex.Message); 
                else
                    MessageBox.Show(ex.StackTrace, "processfield error on unknown master: " + ex.Message); 
                 * */
            }
        }

        private void ComputeDocument()
        {
            if (AType == AppType.PowerPoint)
            {
                try
                {
                    foreach (Microsoft.Office.Interop.PowerPoint.Slide sld in _pptApp.ActiveWindow.Presentation.Slides)
                    {
                        //MessageBox.Show("compute " + sld.Shapes.Count + " shapes on sld " + sld.SlideIndex);
                        ArrayList tempShapes = new ArrayList();

                        foreach (Microsoft.Office.Interop.PowerPoint.Shape sp in sld.Shapes)
                        {
                            if (sp.Tags["umxcode"].Equals("table") || (sp.Tags["umxcode"].IndexOf("ADDIN") != -1))
                            {
                                tempShapes.Add(sp);
                            }
                        }

                        foreach (Microsoft.Office.Interop.PowerPoint.Shape sp in tempShapes)
                        {
                            if (sp.Tags["umxcode"].Equals("table"))
                            {
                                for (int i = 1; i <= sp.Table.Columns.Count; i++)
                                {
                                    for (int j = 1; j <= sp.Table.Rows.Count; j++)
                                    {
                                        if (sp.Table.Cell(i, j).Shape.Tags["umxcode"].IndexOf("ADDIN") != -1)
                                        {
                                            ProcessShape(sp.Table.Cell(i, j).Shape, sld);
                                        }
                                    }
                                }
                            }
                            else if (sp.Tags["umxcode"].IndexOf("ADDIN") != -1)
                            {
                                ProcessShape(sp, sld);
                            }
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("main loop err");
                }
            
            }
            else
            {

                try
                {
                    // clear image folder
                    String imageFolder = GetDocument().Path + "/" + GetDocument().Name + "/";
                    if (Directory.Exists(imageFolder))
                    {
                        Directory.Delete(imageFolder, true);
                    }

                    //delete all relevant bookmarks
                    Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)_applicationObject;

                    foreach (Microsoft.Office.Interop.Word.Bookmark bmk in GetDocument().Bookmarks)
                    {
                        if (bmk.Name.StartsWith("UMXDEL"))
                        {
                            bmk.Range.Select();

                            try
                            {
                                wordapp.Selection.Cut();
                                bmk.Delete();
                            }
                            catch {} //(Exception exception) { MessageBox.Show(exception.StackTrace, exception.Message);  }
                        }
                    }

                    //MessageBox.Show("document clean");

                    foreach (Microsoft.Office.Interop.Word.Field f in GetDocument().Fields)
                    {
                        if (f.Code.Text.StartsWith(" ADDIN umo:"))
                        {
                            ProcessField(f);
                        }
                    }

                    int sferr = 0;
                    foreach (Microsoft.Office.Interop.Word.Shape s in GetDocument().Shapes)
                    {
                        try
                        {
                            foreach (Microsoft.Office.Interop.Word.Field sf in s.TextFrame.TextRange.Fields)
                            {
                                try
                                {
                                    if (sf.Code.Text.StartsWith(" ADDIN umo:"))
                                        ProcessField(sf);
                                }
                                catch
                                {
                                    MessageBox.Show("processfield err");
                                    //gfährlich!
                                }
                            }
                        }
                        catch { sferr++; }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\r\n\r\n" + ex.StackTrace, "ComputeDocument Error");
                }
            }
        }

        private void AddField(string code, Microsoft.Office.Interop.Word.Range range)
        {
            Microsoft.Office.Interop.Word.Document doc = GetDocument();
            object missing = Missing.Value;

            if (doc == null) return;

            object Type = Microsoft.Office.Interop.Word.WdFieldType.wdFieldAddin; //.wdFieldAddin;

            Microsoft.Office.Interop.Word.Field nf = doc.Fields.Add(range, ref Type, ref missing, ref missing);

            nf.Code.Text = code;
            nf.ShowCodes = false;

            ProcessField(nf);
        }

        private void CreateTable(InsertForm inf)
        {
            Table t = inf.tableset;

            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)_applicationObject;
            Microsoft.Office.Interop.Word.Document doc = GetDocument();

            object missing = System.Reflection.Missing.Value;
            object direction = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;

            if (t.Items.Count <= 0 || t.Questions.Count <= 0 || doc == null) return;

            //schachbrett adder?

            //int modifier = 0;

            Microsoft.Office.Interop.Word.Table wtab = doc.Tables.Add(wordapp.Selection.Range, t.Questions.Count + 1, t.Items.Count + 1, ref missing, ref missing);

            wtab.Borders.Enable = 1;
            wtab.Borders.OutsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray60;
            //wtab.Borders.

            int row = 2;

            int x = 2;
            foreach (Col c in t.Items)
            {
                wtab.Cell(1, x).Range.Text = c.Type.ToString();

                if (c.Type == Table.ColTypes.ProzentNachAntwort)
                    wtab.Cell(1, x).Range.Text = c.Type.ToString() + " - " + (c.ASel + 1);

                x++;
            }

            foreach (int qid in t.Questions)
            {
                //wtab.Rows.Add(ref missing);
                try
                {
                    wtab.Cell(row, 1).Range.Text = qid.ToString();

                    for (int tid = 0; tid < t.Items.Count; tid++)
                    {
                        Microsoft.Office.Interop.Word.Range range = wtab.Cell(row, (tid + 2)).Range;
                        range.Collapse(ref direction);
                        //range.Select();

                        Col c = (Col)t.Items[tid];
                        Question q = eval.Global.GetQuestion(qid, eval);

                        switch (c.Type)
                        {

                            case Table.ColTypes.Leer:
                                range.Text = "";
                                break;

                            case Table.ColTypes.Gap:
                                Code("gap:" + qid + ":" + inf.Prec + ":" + inf.getPersons(), inf.CrossList, inf.pbf.IString, range);
                                break;

                            case Table.ColTypes.Median:
                                Code("md:" + qid + ":" + inf.Prec + ":" + inf.getPerson(), inf.CrossList, inf.pbf.IString, range);
                                break;

                            case Table.ColTypes.Mittelwert:
                                Code("mw:" + qid + ":" + inf.Prec + ":" + inf.getPerson(), inf.CrossList, inf.pbf.IString, range);
                                break;

                            case Table.ColTypes.Prozent:
                                Code("pc:" + qid + ":" + inf.Prec + ":" + inf.getPerson(), inf.CrossList, inf.pbf.IString, range);
                                break;

                            case Table.ColTypes.ProzentNachAntwort:
                                if (q.Answers.Length > c.ASel)
                                    Code("apc:" + qid + ":" + inf.Prec + ":" + inf.getPerson() + ":" + q.AnswerList[c.ASel], inf.CrossList, inf.pbf.IString, range);
                                break;

                            case Table.ColTypes.Fragentext:
                                range.Text = q.Text;
                                break;

                            case Table.ColTypes.Ampel:
                                Code("tl:" + qid + ":" + inf.Prec + ":" + inf.getPerson(), inf.CrossList, inf.pbf.IString, range);
                                break;

                            case Table.ColTypes.Prozentbalken:
                                Code("pbar:" + qid + ":" + inf.Prec + ":" + inf.getPerson(), inf.CrossList, inf.pbf.IString, range);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, ex.Message);
                }

                row++;
            }
        }

        private void CreatePotTable(String code, InsertForm inf)
        {
            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)_applicationObject;
            Microsoft.Office.Interop.Word.Document doc = GetDocument();

            object missing = Missing.Value;
            object direction = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;

            string[] master = (code+"|").Split(new char[] { '|' });

            string[] dat = master[0].Split(new char[] { ':' });
            string[] crosses = null;

            Microsoft.Office.Interop.Word.Range ran = null;

            TargetData td = GetTarget();
            TargetData tdo = td.Clone;

            if (master.Length > 2 && master[2].Trim().Length > 0)
            {
                //cross!
                crosses = master[2].Split(new char[] { '#' });

                foreach (string cross in crosses)
                {
                    string[] cdat = cross.Split(new char[] { '.' });

                    int qid = Int32.Parse(cdat[0]);
                    int aid = Int32.Parse(cdat[1]);

                    td = Tools.Cross(eval, td, td.GetQuestion(qid, eval), aid);
                }
            }

            if (td == null) return;

            string ins = string.Empty;
            //Microsoft.Office.Interop.Word.Range r = null;

            Question q;
            if (!dat[1].Equals("op") && !dat[1].Equals("op-c"))
                q = td.GetQuestion(Int32.Parse(dat[2]), eval);
            else
                q = null;

            if (crosses == null) return;

            int cqid = 0;
            foreach (string cross in crosses)
            {
                string[] cdat = cross.Split(new char[] { '.' });
                cqid = Int32.Parse(cdat[0]);
            }

            Question cq = tdo.GetQuestion(cqid, eval);

            Microsoft.Office.Interop.Word.Table wtab = doc.Tables.Add(wordapp.Selection.Range, cq.AnswerList.Length + 2, 4, ref missing, ref missing);

            wtab.Borders.Enable = 1;
            wtab.Borders.OutsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray60;

            wtab.Cell(1, 1).Range.Text = "Gesamt";

            ran = wtab.Cell(1, 2).Range;
            ran.Collapse(ref direction);

            Code("mw:" + dat[2] + ":" + dat[3] + ":" + dat[4], "", master[3], ran);

            wtab.Cell(2, 1).Range.Text = "Filialen";
            wtab.Cell(2, 2).Range.Text = "Mittelwertsabweichung";
            wtab.Cell(2, 3).Range.Text = "Prozentabweichung";

            int row = 3;
            foreach (string cans in cq.AnswerList)
            {
                wtab.Cell(row, 1).Range.Text = cans;

                ran = wtab.Cell(row, 2).Range;
                ran.Collapse(ref direction);
                Code("potval:" + dat[2] + ":" + dat[3] + ":" + dat[4], cqid + "." + (row - 3), master[3], ran);

                ran = wtab.Cell(row, 3).Range;
                ran.Collapse(ref direction);
                Code("potpcnt:" + dat[2] + ":" + dat[3] + ":" + dat[4], cqid + "." + (row - 3), master[3], ran);

                ran = wtab.Cell(row, 4).Range;
                ran.Collapse(ref direction);
                Code("potpic:" + dat[2] + ":" + dat[3] + ":" + dat[4], cqid + "." + (row - 3), master[3], ran);

                row++;
            }
        }

        private void CreateMaturity(String code, InsertForm inf)
        {
            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)_applicationObject;
            Microsoft.Office.Interop.Word.Document doc = GetDocument();

            object missing = Missing.Value;
            object direction = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;

            PPTools tls = new PPTools(code, GetTarget(), eval);

            Microsoft.Office.Interop.Word.Range ran = null;

            Microsoft.Office.Interop.Word.Table wtab = doc.Tables.Add(wordapp.Selection.Range, 5, 5, ref missing, ref missing);

            wtab.Borders.Enable = 1;
            wtab.Borders.OutsideColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray60;

            wtab.Cell(1, 1).Range.Text = "Reifegrad/Führung";

            wtab.Cell(1, 2).Range.Text = "Telling";
            wtab.Cell(1, 3).Range.Text = "Selling";
            wtab.Cell(1, 4).Range.Text = "Participating";
            wtab.Cell(1, 5).Range.Text = "Delegating";

            wtab.Cell(2, 1).Range.Text = "R1";
            wtab.Cell(3, 1).Range.Text = "R2";
            wtab.Cell(4, 1).Range.Text = "R3";
            wtab.Cell(5, 1).Range.Text = "R4";

            for (int r = 0; r < 4; r++)
            {
                for (int f = 0; f < 4; f++)
                {
                    if (r == f) wtab.Cell(r + 2, f + 2).Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray15;
                    ran = wtab.Cell(r + 2, f + 2).Range;
                    ran.Collapse(ref direction);
                    Code("maturity-val:0:" + tls.dat[5] + ":" + tls.dat[6] + ":" + tls.dat[7] + ":" + tls.dat[8] + ":" + r + ":" + f + ":" + tls.dat[4] + ":" + tls.dat[3], tls.master[2], inf.pbf.IString, ran);
                }
            }
        }

        private void CreateTablePPt(InsertForm inf)
        {
            if (inf.countPersons() < 1)
            {
                MessageBox.Show("Sie haben keine Personengruppen ausgewählt", "Eingabefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Table t = inf.tableset;

                Microsoft.Office.Interop.PowerPoint.Slide sl = (Microsoft.Office.Interop.PowerPoint.Slide)_pptApp.ActiveWindow.View.Slide;
                Microsoft.Office.Interop.PowerPoint.Shape ns = null;

                ns = sl.Shapes.AddTable(t.Questions.Count + 1, t.Items.Count + 1, 50, 50, t.Items.Count * 150, t.Questions.Count * 25);

                ns.Tags.Add("umxcode", inf.FieldCode);
                ns.Tags.Add("tableset", t.ToString());

                ProcessShape(ns, sl);
            }
        }

        private void CreatePotTablePPt(String code, InsertForm inf)
        {
            PPTools tls = new PPTools(code, GetTarget(), eval);

            Microsoft.Office.Interop.PowerPoint.Slide sl = (Microsoft.Office.Interop.PowerPoint.Slide)_pptApp.ActiveWindow.View.Slide;
            Microsoft.Office.Interop.PowerPoint.Shape ns = null;

            ns = sl.Shapes.AddTable(tls.cq.AnswerList.Length + 2, 4, 50, 50, 350, 50 * tls.cq.AnswerList.Length + 2);

            ns.Tags.Add("umxcode", code);

            ProcessShape(ns, sl);
        }

        private void CreateMaturityPPt(String code, InsertForm inf)
        {
            Microsoft.Office.Interop.PowerPoint.Slide sl = (Microsoft.Office.Interop.PowerPoint.Slide)_pptApp.ActiveWindow.View.Slide;
            Microsoft.Office.Interop.PowerPoint.Shape ns = null;

            ns = sl.Shapes.AddTable(5, 5, 50, 50, 550, 250);

            ns.Tags.Add("umxcode", code);

            ProcessShape(ns, sl);
        }

        private void CreateTagCloudPPt(String code, InsertForm inf)
        {
            PPTools tls = new PPTools(code, GetTarget(), eval);

            Microsoft.Office.Interop.PowerPoint.Slide sl = (Microsoft.Office.Interop.PowerPoint.Slide)_pptApp.ActiveWindow.View.Slide;
            Microsoft.Office.Interop.PowerPoint.Shape ns = null;

            int ypos = 0;
            int height = 40;

            foreach (string answer in tls.q.AnswerList)
            {
                ns = sl.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 0, ypos, 200, 40);

                string c = "tagcloud-val:";

                for (int i = 0; i <= 17; i++)
                    c += tls.dat[i+2] + ":";

                c += answer;

                string cde = CreateCode(c, tls.master[2], tls.master[3]);

                ypos += height;

                ns.Tags.Add("umxcode", cde);
                ProcessShape(ns, sl);
            }
        }

        private void CreateTagCloud(string code, InsertForm inf)
        {
            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)_applicationObject;
            Microsoft.Office.Interop.Word.Document doc = GetDocument();

            object missing = Missing.Value;
            object direction = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;

            PPTools tls = new PPTools(code, GetTarget(), eval);

            Microsoft.Office.Interop.Word.Shape ns = null;

            int ypos = 0;
            int height = 25;

            foreach (string answer in tls.q.AnswerList)
            {
                ns = doc.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 0, ypos, 120, height, ref missing);
                //ns.SoftEdge.Type = MsoSoftEdgeType.msoSoftEdgeTypeNone;
                ns.Line.Visible = MsoTriState.msoFalse;
                //ns.Line.BackColor.RGB = System.Drawing.ColorTranslator.ToWin32(Color.Transparent);

                string c = "tagcloud-val:";

                for (int i = 0; i <= 17; i++)
                    c += tls.dat[i + 2] + ":";

                c += answer;

                string cde = CreateCode(c, tls.master[2], tls.master[3]);

                ypos += height;

                AddField(cde, ns.TextFrame.TextRange);
            }
        }

        private void Code(string code, string CrossList, string Base, Microsoft.Office.Interop.Word.Range range)
        {
            AddField(CreateCode(code, CrossList, Base), range);
        }

        private string CreateCode(string code, string CrossList, string Base)
        {
            int max = 0;

            if (AType == AppType.Word)
            {
                Microsoft.Office.Interop.Word.Document doc = GetDocument();

                foreach (Microsoft.Office.Interop.Word.Field f in doc.Fields)
                {
                    if (f.Code.Text.StartsWith(" ADDIN umo:"))
                    {
                        string[] master = (f.Code.Text+"|").Split(new char[] { '|' });

                        if (Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                    }
                }
                foreach (Microsoft.Office.Interop.Word.Shape s in doc.Shapes)
                {
                    try
                    {
                        foreach (Microsoft.Office.Interop.Word.Field sf in s.TextFrame.TextRange.Fields)
                        {
                            string[] master = (sf.Code.Text + "|").Split(new char[] { '|' });

                            if (master.Length > 1 && Int32.Parse(master[1]) > max) max = Int32.Parse(master[1]);
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return " ADDIN umo:" + code + "|" + (max + 1) + "|" + CrossList + "|" + Base;
        }

        #region Event Handlers

        private void td_IncludedChanged(TargetData sender)
        {
            //scheiss .net- events
        }

        private void pptApp_PresentationOpen(Microsoft.Office.Interop.PowerPoint.Presentation Pres)
        {
            //ProcessDocument(false);
        }

        private void pptApp_PresentationBeforeSave(Microsoft.Office.Interop.PowerPoint.Presentation Pres, ref bool Cancel)
        {
            //TODO
        }

        private void wordapp_DocumentOpen(Microsoft.Office.Interop.Word.Document Doc)
        {
            /*
            try
            {
                ProcessDocument(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
             */
        }

        private void wordapp_DocumentBeforeSave(Microsoft.Office.Interop.Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            //save!
            foreach (Microsoft.Office.Interop.Word.InlineShape shape in Doc.InlineShapes)
            {
                try
                {
                    if (shape.AlternativeText.StartsWith("umo"))
                    {
                        string id = shape.AlternativeText.Substring(3);
                        foreach (Microsoft.Office.Interop.Word.Field f in Doc.Fields)
                        {
                            if (f.Code.Text.StartsWith(" ADDIN umo:"))
                            {
                                string[] master = (f.Code.Text + "|").Split(new char[] { '|' });
                                string[] param = master[0].Split(new char[] { ':' });

                                if (id.Equals(master[1])) //found!
                                {
                                    param[4] = "" + shape.Width;
                                    param[5] = "" + shape.Height;

                                    f.Code.Text = " ADDIN umo";

                                    for (int i = 1; i < param.Length; i++)
                                        f.Code.Text += ":" + param[i];

                                    for (int i = 1; i < master.Length; i++ )
                                        f.Code.Text += "|" + master[i];

                                        break;
                                }
                            }
                        }
                    }
                }
                catch { }
            }

            RecursiveShapeSaver(Doc.Shapes);
        }

        private void insertButton_Click(CommandBarButton barButton, ref bool someBool)
        {
            OpenInsertDialog();
        }

        private void propButton_Click(CommandBarButton barButton, ref bool someBool)
        {
            OpenPropertiesDialog();
        }

        private void settingsButton_Click(CommandBarButton barButton, ref bool someBool)
        {
            OpenSettingsDialog();
        }

        private void editButton_Click(CommandBarButton barButton, ref bool someBool)
        {
            OpenEditDialog();
        }

        #endregion
    }
}
