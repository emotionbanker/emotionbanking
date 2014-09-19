namespace UMXAddin3
{
    using System;
    using Extensibility;
    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.Office.Core;
    using umfrage2;
    using Microsoft.Office.Interop;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;


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
	[GuidAttribute("94445D30-D18F-4A29-9397-AE524B691180"), ProgId("UMXAddin3.Connect")]
	public class Connect : Object, Extensibility.IDTExtensibility2
	{

        Microsoft.Office.Interop.Word.Application wordApp;
        Microsoft.Office.Interop.PowerPoint.Application pptApp;


        Microsoft.Office.Core.CommandBarButton settingsButton;
        Microsoft.Office.Core.CommandBarButton insertButton;
        Microsoft.Office.Core.CommandBarButton propButton;
        Microsoft.Office.Core.CommandBarButton editButton;


        Microsoft.Office.Core.CommandBar toolBar;
        
        umfrage2.Evaluation eval;

        public Evaluation[] multiEvals = new Evaluation[5];
        public string[] multiTargets = new string[5];

        public AppType AType
        {
            get
            {
                if (wordApp != null) return AppType.Word;
                else return AppType.PowerPoint;
            }
        }

		/// <summary>
		///		Implements the constructor for the Add-in object.
		///		Place your initialization code within this method.
		/// </summary>
		public Connect()
		{
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
		}

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
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
		/// <param term='application'>
		///      Root object of the host application.
		/// </param>
		/// <param term='connectMode'>
		///      Describes how the Add-in is being loaded.
		/// </param>
		/// <param term='addInInst'>
		///      Object representing this Add-in.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom)
		{
			applicationObject = application;
			addInInstance = addInInst;

            toolBar = null;

            if (application is Microsoft.Office.Interop.Word.Application)
            {
                wordApp = (Microsoft.Office.Interop.Word.Application)application;
                pptApp = null;
               
                toolBar = AddWordToolbar(wordApp, "UMXAddin3");

                wordApp.DocumentOpen += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentOpenEventHandler(wordapp_DocumentOpen);
                wordApp.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(wordapp_DocumentBeforeSave);

            }
            else if (application is Microsoft.Office.Interop.PowerPoint.Application)
            {
                pptApp = (Microsoft.Office.Interop.PowerPoint.Application)application;
                wordApp = null;


                toolBar = AddPPtToolbar(pptApp, "UMXAddin3");

                pptApp.PresentationOpen += new Microsoft.Office.Interop.PowerPoint.EApplication_PresentationOpenEventHandler(pptApp_PresentationOpen);
                pptApp.PresentationBeforeSave += new Microsoft.Office.Interop.PowerPoint.EApplication_PresentationBeforeSaveEventHandler(pptApp_PresentationBeforeSave);

                propButton = AddButton(toolBar, "Eigenschaften", 25, new _CommandBarButtonEvents_ClickEventHandler(propButton_Click));
            }

           


            settingsButton = AddButton(toolBar, "Einstellungen", 16, new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(settingsButton_Click));
            insertButton = AddButton(toolBar, "Einfügen", 17, new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(insertButton_Click));
            editButton = AddButton(toolBar, "Bearbeiten", 162, new _CommandBarButtonEvents_ClickEventHandler(editButton_Click));
		}

        void pptApp_PresentationOpen(Microsoft.Office.Interop.PowerPoint.Presentation Pres)
        {
            //ProcessDocument(false);
        }

        void pptApp_PresentationBeforeSave(Microsoft.Office.Interop.PowerPoint.Presentation Pres, ref bool Cancel)
        {
            //TODO
        }

        void wordapp_DocumentOpen(Microsoft.Office.Interop.Word.Document Doc)
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

        void wordapp_DocumentBeforeSave(Microsoft.Office.Interop.Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
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

        public static void RecursiveShapeSaver(Microsoft.Office.Interop.Word.Shapes ss)
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


        private Microsoft.Office.Core.CommandBar AddPPtToolbar(Microsoft.Office.Interop.PowerPoint.Application ppt, string toolbarName)
        {
            Microsoft.Office.Core.CommandBar toolBar = null;
            try
            {
                // Create a command bar for the add-in
                object missing = System.Reflection.Missing.Value;
                toolBar = (Microsoft.Office.Core.CommandBar)
                    pptApp.CommandBars.Add(toolbarName,
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


        private Microsoft.Office.Core.CommandBar AddWordToolbar(Microsoft.Office.Interop.Word.Application word, string toolbarName)
        {
            Microsoft.Office.Core.CommandBar toolBar = null;
            try
            {
                // Create a command bar for the add-in
                object missing = System.Reflection.Missing.Value;
                toolBar = (Microsoft.Office.Core.CommandBar)
                    wordApp.CommandBars.Add(toolbarName,
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


        // C#
        private Microsoft.Office.Core.CommandBarButton AddButton(  Microsoft.Office.Core.CommandBar commandBar, string caption, int faceID, 
                                                                   Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler clickHandler)
        {
            object missing = System.Reflection.Missing.Value;
            try
            {
                Microsoft.Office.Core.CommandBarButton newButton;
                newButton = (Microsoft.Office.Core.CommandBarButton)
                    commandBar.Controls.Add(
                    Microsoft.Office.Core.MsoControlType.msoControlButton,
                    missing, missing, missing, missing);
                newButton.Caption = caption;
                newButton.FaceId = faceID;
                newButton.Style = Microsoft.Office.Core.MsoButtonStyle.msoButtonIconAndCaption;
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

		/// <summary>
		///     Implements the OnDisconnection method of the IDTExtensibility2 interface.
		///     Receives notification that the Add-in is being unloaded.
		/// </summary>
		/// <param term='disconnectMode'>
		///      Describes how the Add-in is being unloaded.
		/// </param>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom)
		{
		}

		/// <summary>
		///      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
		///      Receives notification that the collection of Add-ins has changed.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnAddInsUpdate(ref System.Array custom)
		{
		}

		/// <summary>
		///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		///      Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref System.Array custom)
		{
            
		}

		/// <summary>
		///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		///      Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref System.Array custom)
		{
		}
		
		private object applicationObject;
		private object addInInstance;





        public void settingsButton_Click(Microsoft.Office.Core.CommandBarButton barButton, ref bool someBool)
        {
            UMSettingsForm sf = null;

            if (AType == AppType.PowerPoint)
            {
                sf = new UMSettingsForm(eval, multiEvals, multiTargets, pptApp.ActivePresentation);
            }
            else if (AType == AppType.Word)
            {
                sf = new UMSettingsForm(eval, multiEvals, multiTargets, GetDocument());
            }
            if (sf != null && sf.ShowDialog() == DialogResult.Retry)

            ProcessDocument(true);

            eval = sf.eval;
            multiEvals = sf.multiEvals;
            multiTargets = sf.multiTargets;
        }

        private Microsoft.Office.Interop.Word.Document GetDocument()
        {
            try
            {
                Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)applicationObject;

                Microsoft.Office.Interop.Word.Document doc = wordapp.ActiveDocument;

                return doc;
            }
            catch
            {
                return null;
            }
        }

        private void ProcessDocument(bool tf)
        {
            if (AType == AppType.PowerPoint)
            {
                ProcessPresentation(pptApp.ActivePresentation, tf);
            }
            else if (AType == AppType.Word)
            {
                Microsoft.Office.Interop.Word.Document doc = GetDocument();

                if (doc != null) ProcessDocument(doc, tf);
            }
        }


        private void ProcessPresentation(Microsoft.Office.Interop.PowerPoint.Presentation pres, bool tf)
        {

            if (eval != null)
            {
                Tools.SetPPtDocumentPropertyValue(pptApp.ActivePresentation, "umo:filename", eval.FileName);
            }
            else
            {
                object FileName = null;

                FileName = Tools.GetPPtDocumentPropertyValue(pptApp.ActivePresentation, "umo:filename");

                if (FileName != null)
                {
                    eval = Tools.LoadEval((string)FileName);
                    if (eval != null) ProcessDocument(tf);
                    else
                    {
                       Tools.SetPPtDocumentPropertyValue(pptApp.ActivePresentation, "umo:filename", "");
                    }
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

                    if (eval != null) tf = true; //ProcessDocument(tf);
                    
                    if (eval == null)
                    {
                       Tools.SetWordDocumentPropertyValue(doc, "umo:filename", "");
                    }
                }
            }


            if (tf) ComputeDocument();

        }

        private Evaluation GetCEval(int pos)
        {
            return multiEvals[pos];
        }

        private TargetData GetCTarget(int pos)
        {
            TargetData tdr = null;

            string name = null;

            
            if (multiEvals[pos] == null) return null;


            if (AType == AppType.PowerPoint)
                name = Tools.GetPPtDocumentPropertyValue(pptApp.ActivePresentation, "umo:mtarget" + pos);
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

        private TargetData GetTarget()
        {
            TargetData tdr = null;

            string name = null;


            if (AType == AppType.PowerPoint)
                name = Tools.GetPPtDocumentPropertyValue(pptApp.ActivePresentation, "umo:target");
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

        void td_IncludedChanged(TargetData sender)
        {
            //scheiss .net- events
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

        private string personsToPerson(string p)
        {
            string[] dat = p.Split(new char[] {'#'});

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
                Microsoft.Office.Interop.PowerPoint.Presentation pres = pptApp.ActivePresentation;

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
                if (!dat[1].Equals("op"))
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
                                                ProcessShape(range, sld, CreateCode("md:" + qid + ":" + tls.dat[3] + ":" + personsToPerson(tls.dat[4]), master[2],tls.master[3]));
                                                break;

                                            case Table.ColTypes.Mittelwert:
                                                ProcessShape(range, sld, CreateCode("mw:" + qid + ":" + tls.dat[3] + ":" + personsToPerson(tls.dat[4]), master[2], tls.master[3]));
                                                break;

                                            case Table.ColTypes.Prozent:
                                                ProcessShape(range, sld, CreateCode("pc:" + qid + ":" + tls.dat[3] + ":" + personsToPerson(tls.dat[4]), master[2], tls.master[3]));
                                                break;

                                            case Table.ColTypes.ProzentNachAntwort:
                                                if (Tq.Answers.Length > c.ASel)
                                                    ProcessShape(range, sld, CreateCode("apc:" + qid + ":" + tls.dat[3] + ":" + personsToPerson(tls.dat[4]) + ":" + Tq.AnswerList[c.ASel], master[2], master[3]));
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
                                s.TextFrame.TextRange.Font.Color.RGB = System.Drawing.ColorTranslator.ToWin32((Color)res[0]);
                            break;

                        case "mw": //Mittelwert

                            double val = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));

                            if (val == -1) ins = "k.A.";
                            else ins = "" + val;


                            s.TextFrame.TextRange.Text = ins;

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
                            else aapcnt = aapq.GetAnswerPercentByPerson(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);


                            //MessageBox.Show();
                            ins = "" + Math.Round(aapcnt, Int32.Parse(dat[3]));

                            s.TextFrame.TextRange.Text = ins + "%";

                            break;

                        case "bcont-value-apc":
                            TargetData vaatd = GetCTarget(Int32.Parse(dat[5]));
                            Question vaapq = vaatd.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]);

                            float vaapcnt;
                            if (tls.Base) vaapcnt = vaapq.GetAnswerPercentByPersonWithBase(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                            else vaapcnt = vaapq.GetAnswerPercentByPerson(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                            Question vpq = td.GetQuestion(Int32.Parse(dat[2]), eval);

                            float vpcnt;
                            if (tls.Base) vpcnt = vpq.GetAnswerPercentByPersonWithBase(dat[6], eval, eval.CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                            else vpcnt = vpq.GetAnswerPercentByPerson(dat[6], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);


                            ins = "" + Math.Round(vpcnt - vaapcnt, Int32.Parse(dat[3]));
                            
                            s.TextFrame.TextRange.Text = ins + "%";

                            break;

                        case "apc":
                            Question pq = td.GetQuestion(Int32.Parse(dat[2]), eval);

                            float pcnt;
                            if (tls.Base) pcnt = pq.GetAnswerPercentByPersonWithBase(dat[5], eval, eval.CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                            else pcnt = pq.GetAnswerPercentByPerson(dat[5], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

                            ins = "" + Math.Round(pcnt, Int32.Parse(dat[3]));

                            s.TextFrame.TextRange.Text = ins + "%";
                            break;

                        case "gap":
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

                                s.TextFrame.TextRange.Text = ins;
                            }
                            else
                            {
                                s.TextFrame.TextRange.Text = "k.A.";
                            }
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
                            string[] npids = dat[4].Split(new char[] { '#' });

                            int n = 0;

                            foreach (string pid in npids)
                            {
                                n += q.NAnswersByPerson(eval, eval.CombinedPersons[Int32.Parse(pid)]);
                            }

                            ins = n.ToString();

                            s.TextFrame.TextRange.Text = ins;
                            break;

                        case "nps":
                            s.TextFrame.TextRange.Text = tls.NPS();

                            break;

                        case "md":
                            ins = "" + Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetMedianByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])], Int32.Parse(dat[3])), Int32.Parse(dat[3]));

                            s.TextFrame.TextRange.Text = ins;
                            break;

                        case "pc":
                            ins = "" + Math.Round(((5f - td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])])) / 4f) * 100, Int32.Parse(dat[3]));
                            s.TextFrame.TextRange.Text = ins;
                            break;

                        case "aabs":
                            Question apq = td.GetQuestion(Int32.Parse(dat[2]), eval);
                            float apcnt = apq.GetAnswerCountByPerson(dat[5], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

                            ins = "" + Math.Round(apcnt, Int32.Parse(dat[3]));
                            s.TextFrame.TextRange.Text = ins;
                            break;

                        case "aas":
                            ins = "" + Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageAnswersByUser(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));
                            s.TextFrame.TextRange.Text = ins;
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

        private void ProcessField(Microsoft.Office.Interop.Word.Field f)
        {
            if (eval == null) return;

            PPTools tls = new PPTools(f.Code.Text, GetTarget(), eval);

            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)applicationObject;
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
            if (!dat[1].Equals("op"))
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


                        string pbfname = System.IO.Path.GetTempFileName() + ".png";


                        Tools.CreatePotBar(eval, ppp, true, 50, 180, 20).Save(pbfname, System.Drawing.Imaging.ImageFormat.Png);

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

                        wordApp.Selection.Font.Size = (float)res[1];
                        if (res[0] != null) wordApp.Selection.Font.Color = (Microsoft.Office.Interop.Word.WdColor)System.Drawing.ColorTranslator.ToWin32((Color)res[0]);
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

                            string itfname = System.IO.Path.GetTempFileName() + ".png";


                            Tools.CreateTLImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                            object tr97 = f.Result;

                            Microsoft.Office.Interop.Word.InlineShape itshape = doc.InlineShapes.AddPicture(itfname, ref ltof, ref inline, ref tr97);
                            //tshape.Width = 12f;
                            //tshape.Height = 12f;

                            //bookmark
                            Microsoft.Office.Interop.Word.Range itrb = f.Result;

                            itrb.Start = itrb.End;
                            itrb.End = itrb.Start + 1;
                            object itranb = (object)itrb;
                            doc.Bookmarks.Add("UMXDEL" + master[1], ref itranb);
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
                        else aapcnt = aapq.GetAnswerPercentByPerson(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

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
                        else vaapcnt = vaapq.GetAnswerPercentByPerson(dat[6], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                        Question vpq = td.GetQuestion(Int32.Parse(dat[2]), eval);

                        float vpcnt;
                        if (tls.Base) vpcnt = vpq.GetAnswerPercentByPersonWithBase(dat[6], eval, eval.CombinedPersons[Int32.Parse(dat[4])], tls.bq);
                        else vpcnt = vpq.GetAnswerPercentByPerson(dat[6], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);


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
                        else pcnt = pq.GetAnswerPercentByPerson(dat[5], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

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
                }
            }
            catch
            {
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
                    foreach (Microsoft.Office.Interop.PowerPoint.Slide sld in pptApp.ActiveWindow.Presentation.Slides)
                    {
                        //MessageBox.Show("compute " + sld.Shapes.Count + " shapes on sld " + sld.SlideIndex);
                        System.Collections.ArrayList tempShapes = new System.Collections.ArrayList();

                        foreach (Microsoft.Office.Interop.PowerPoint.Shape sp in sld.Shapes)
                        {
                            if (sp.Tags["umxcode"].Equals("table") || (sp.Tags["umxcode"].IndexOf("ADDIN") != -1) )
                                tempShapes.Add(sp);
                        }

                        foreach (Microsoft.Office.Interop.PowerPoint.Shape sp in tempShapes)
                        {

                            if (sp.Tags["umxcode"].Equals("table"))
                            {
                                for (int i = 1; i <= sp.Table.Columns.Count; i++)
                                    for (int j = 1; j <= sp.Table.Rows.Count; j++)
                                        if (sp.Table.Cell(i, j).Shape.Tags["umxcode"].IndexOf("ADDIN") != -1)
                                            ProcessShape(sp.Table.Cell(i, j).Shape, sld);

                            }

                            else if (sp.Tags["umxcode"].IndexOf("ADDIN") != -1)
                                ProcessShape(sp, sld);
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
                    //delete all relevant bookmarks
                    Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)applicationObject;

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

        public void insertButton_Click(Microsoft.Office.Core.CommandBarButton barButton, ref bool someBool)
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

        void AddField(string code)
        {
            if (AType == AppType.PowerPoint)
            {
                AddPField(code);
            }
            else if (AType == AppType.Word)
            {
                Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)applicationObject;
                AddField(code, wordapp.Selection.Range);
            }
        }

        void AddPField(string code)
        {
            PPTools tls = new PPTools(code, GetTarget(), eval);

            Microsoft.Office.Interop.PowerPoint.Slide sl = (Microsoft.Office.Interop.PowerPoint.Slide)pptApp.ActiveWindow.View.Slide;

            Microsoft.Office.Interop.PowerPoint.Shape ns = null;

            //text fields
            switch (tls.dat[1])
            {
                case "mw": case "potpcnt": case "potval": case "n": case "nps": case "md": case "pc": 
                case "aabs": case "aas": case "gap": case "apc": case "bcont-value": case "bcont-comp-mw":
                case "bcont-comp-apc": case "bcont-value-apc": case "origaw": case "bcont-nps-value":
                case "bcont-nps-diff":
                    ns = sl.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 70, 40);
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


                case "bcont-trend-apc":
                    ns = sl.Shapes.AddPicture(tls.bconTrendApc(GetCTarget(Int32.Parse(tls.dat[5])), multiEvals), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, Int32.Parse(tls.dat[22]), Int32.Parse(tls.dat[22]));
                    break;

                case "op":
                    ns = sl.Shapes.AddPicture(tls.op(), MsoTriState.msoFalse, MsoTriState.msoTrue, 100, 100, tls.compop.OutputImage.Width, tls.compop.OutputImage.Height);
                    break;

            }

            if (ns != null)
            {
                ns.Tags.Add("umxcode", code);

                ProcessShape(ns, sl);
            }
        }



        void AddField(string code, Microsoft.Office.Interop.Word.Range range)
        {
            Microsoft.Office.Interop.Word.Document doc = GetDocument();
            object missing = System.Reflection.Missing.Value;

            if (doc == null) return;

            object Type = Microsoft.Office.Interop.Word.WdFieldType.wdFieldAddin; //.wdFieldAddin;

            Microsoft.Office.Interop.Word.Field nf = doc.Fields.Add(range, ref Type, ref missing, ref missing);

            nf.Code.Text = code;
            nf.ShowCodes = false;

            ProcessField(nf);
        }

        void CreateTable(InsertForm inf)
        {
            Table t = inf.tableset;

            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)applicationObject;
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


        

        void CreatePotTable(String code, InsertForm inf)
        {
            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)applicationObject;
            Microsoft.Office.Interop.Word.Document doc = GetDocument();

            object missing = System.Reflection.Missing.Value;
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
            if (!dat[1].Equals("op"))
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



        void CreateMaturity(String code, InsertForm inf)
        {
            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)applicationObject;
            Microsoft.Office.Interop.Word.Document doc = GetDocument();

            object missing = System.Reflection.Missing.Value;
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
                for (int f = 0; f < 4; f++)
                {
                    if (r == f) wtab.Cell(r + 2, f + 2).Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray15;
                    ran = wtab.Cell(r+2, f+2).Range;
                    ran.Collapse(ref direction);
                    Code("maturity-val:0:" + tls.dat[5] + ":" + tls.dat[6] + ":" + tls.dat[7] + ":" + tls.dat[8] + ":" + r + ":" + f + ":" + tls.dat[4] + ":" + tls.dat[3], tls.master[2], inf.pbf.IString, ran);
                }


        }



        void CreateTablePPt(InsertForm inf)
        {
            if (inf.countPersons() < 1)
            {
                MessageBox.Show("Sie haben keine Personengruppen ausgewählt", "Eingabefehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Table t = inf.tableset;


                Microsoft.Office.Interop.PowerPoint.Slide sl = (Microsoft.Office.Interop.PowerPoint.Slide)pptApp.ActiveWindow.View.Slide;
                Microsoft.Office.Interop.PowerPoint.Shape ns = null;


                ns = sl.Shapes.AddTable(t.Questions.Count + 1, t.Items.Count + 1, 50, 50, t.Items.Count * 150, t.Questions.Count * 25);

                ns.Tags.Add("umxcode", inf.FieldCode);
                ns.Tags.Add("tableset", t.ToString());

                ProcessShape(ns, sl);
            }
            

        }


        void CreatePotTablePPt(String code, InsertForm inf)
        {
            PPTools tls = new PPTools(code, GetTarget(), eval);

            Microsoft.Office.Interop.PowerPoint.Slide sl = (Microsoft.Office.Interop.PowerPoint.Slide)pptApp.ActiveWindow.View.Slide;
            Microsoft.Office.Interop.PowerPoint.Shape ns = null;


            ns = sl.Shapes.AddTable(tls.cq.AnswerList.Length + 2, 4, 50, 50, 350, 50 * tls.cq.AnswerList.Length + 2);

            ns.Tags.Add("umxcode", code);

            ProcessShape(ns, sl);
        }

        void CreateMaturityPPt(String code, InsertForm inf)
        {
            Microsoft.Office.Interop.PowerPoint.Slide sl = (Microsoft.Office.Interop.PowerPoint.Slide)pptApp.ActiveWindow.View.Slide;
            Microsoft.Office.Interop.PowerPoint.Shape ns = null;

            ns = sl.Shapes.AddTable(5, 5, 50, 50, 550, 250);

            ns.Tags.Add("umxcode", code);

            ProcessShape(ns, sl);
        }

        void CreateTagCloudPPt(String code, InsertForm inf)
        {
            PPTools tls = new PPTools(code, GetTarget(), eval);

            Microsoft.Office.Interop.PowerPoint.Slide sl = (Microsoft.Office.Interop.PowerPoint.Slide)pptApp.ActiveWindow.View.Slide;
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

        void CreateTagCloud(string code, InsertForm inf)
        {
            Microsoft.Office.Interop.Word.Application wordapp = (Microsoft.Office.Interop.Word.Application)applicationObject;
            Microsoft.Office.Interop.Word.Document doc = GetDocument();

            object missing = System.Reflection.Missing.Value;
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





        public void propButton_Click(Microsoft.Office.Core.CommandBarButton barButton, ref bool someBool)
        {
            try
            {
                if (pptApp.ActiveWindow.Selection.ShapeRange.Tags["umxcode"].Equals("table") || (pptApp.ActiveWindow.Selection.ShapeRange.Tags["umxcode"].IndexOf("ADDIN") != -1))
                {
                    string dat = pptApp.ActiveWindow.Selection.ShapeRange.Tags["umxcode"];

                    string d = string.Empty;

                    string[] master = (dat+ "|").Split(new char[] {'|'});

                    d+= "Verknüpfungsdaten:\n\n";

                    int i = 0;
                    foreach (string v in master[0].Split(new char[] {':'}))
                        d += (i++) + ": " + v + "\n";

                    d+= "\n";

                    d+= "Word Object ID: " + master[1] + "\n";
                    d+= "Kreuzungen: " + master[2] + "\n";
                    d+= "Prozentbasis: " + master[3];

                    MessageBox.Show(d, "Eigenschaften", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Auswahl enthält keine Umfrageverknüpfungen", "Eigenschaften", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }

        public void editButton_Click(Microsoft.Office.Core.CommandBarButton barButton, ref bool someBool)
        {
            if (this.AType == AppType.PowerPoint)
            {
                //get selection (all shapes)
                //get all tags

                List<Microsoft.Office.Interop.PowerPoint.Shape> selShapes = new List<Microsoft.Office.Interop.PowerPoint.Shape>();
                List<string> tags = new List<string>();

                foreach (Microsoft.Office.Interop.PowerPoint.Shape selShape in pptApp.ActiveWindow.Selection.ShapeRange)
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

                foreach (Microsoft.Office.Interop.Word.Field f in wordApp.Selection.Fields)
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
	}
}