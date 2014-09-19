using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.HistoricChange;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using dotnetCHARTING.WinForms;
using umfrage2._2007;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.HistoricChange
{
    [Serializable]
    public class HistoricChangeDiagram : Output.Output
    {
        public DNCSettings DncSettings { get; set; }
        public Question[] Questions { get; set; }
        public String[] HistoricIDs { get; set; }
        public String CurrentName { get; set; }
        public Boolean ShowArea { get; set; }

        public Double ScaleMax { get; set; }
        public Double ScaleMin { get; set; }

        public Int32 LineWidth { get; set; }
        public DashStyle styleofLine { get; set; }

        public Dictionary<String, Color> Colors { get; set; }
        public Dictionary<String, DashStyle> LineStyle { get; set; }
        public Dictionary<String, String> Legends { get; set; }
        public Dictionary<String, Int32> Widths { get; set; }

        public bool InvertScale { get; set; }

        public HistoricChangeDiagram(Evaluation evaluation)
        {
            eval = evaluation;
            Questions = new Question[0];
            HistoricIDs = new string[0];
            DncSettings = new DNCSettings();
            width = 500;
            height = 500;
            CurrentName = DateTime.Now.Year.ToString();
            Colors = new Dictionary<String, Color>();
            LineStyle = new Dictionary<String, DashStyle>();
            styleofLine = DashStyle.Solid;
            ScaleMax = 5;
            ScaleMin = 1;
            LineWidth = 1;
            Legends = new Dictionary<string, string>();
            Widths = new Dictionary<string, Int32>();
            InvertScale = false;
        }

        #region Serialization

        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            LoadSerData(info, ctxt);

            Question.SetMultipartArray(Questions, Multipart);

            info.AddValue("Questions", Questions);
            info.AddValue("DncSettings", DncSettings);
            info.AddValue("HistoricIDs", HistoricIDs);
            info.AddValue("CurrentName", CurrentName);
            info.AddValue("Colors", Colors);
            info.AddValue("LineStyle", LineStyle);
            info.AddValue("ShowArea", ShowArea);

            info.AddValue("ScaleMax", ScaleMax);
            info.AddValue("ScaleMin", ScaleMin);
            info.AddValue("LineWidth", LineWidth);

            info.AddValue("InvertScale", InvertScale);

            info.AddValue("Legends", Legends);

            info.AddValue("Widths", Widths);
            info.AddValue("styleofLine", styleofLine);
        }

        public HistoricChangeDiagram(SerializationInfo info, StreamingContext ctxt)
        {
            ReadSerData(info, ctxt);

            Questions = (Question[])info.GetValue("Questions", typeof (Question[]));
            DncSettings = (DNCSettings)info.GetValue("DncSettings", typeof(DNCSettings));
            HistoricIDs = (String[])info.GetValue("HistoricIDs", typeof(String[]));
            try {CurrentName = info.GetString("CurrentName");}
            catch (Exception) { CurrentName = DateTime.Now.Year.ToString(); }
            try { Colors = (Dictionary<String, Color>)info.GetValue("Colors", typeof(Dictionary<String, Color>)); }
            catch (Exception) { Colors = new Dictionary<string, Color>(); }
            
            try { ShowArea = info.GetBoolean("ShowArea"); }
            catch (Exception) { ShowArea = false; }

            try
            {
                ScaleMax = info.GetDouble("ScaleMax");
                ScaleMin = info.GetDouble("ScaleMin");
            }
            catch (Exception)
            {
                ScaleMax = 5;
                ScaleMin = 1;
            }

            try { LineWidth = info.GetInt32("LineWidth"); }
            catch (Exception) { LineWidth = 1; }

            try { Legends = (Dictionary<String, String>)info.GetValue("Legends", typeof(Dictionary<String, String>)); }
            catch (Exception) { Legends = new Dictionary<String, String>(); }

            try { Widths = (Dictionary<String, Int32>)info.GetValue("Widths", typeof(Dictionary<String, Int32>)); }
            catch (Exception) { Widths = new Dictionary<String, Int32>(); }

            try { LineStyle = (Dictionary<String, DashStyle>)info.GetValue("LineStyle", typeof(Dictionary<String, DashStyle>)); }
            catch (Exception) { LineStyle = new Dictionary<string, DashStyle>(); }

            try { styleofLine = DashStyle.Solid; }
            catch (Exception) { LineWidth = 1; }

            try
            {
                InvertScale = info.GetBoolean("InvertScale");
            } 
            catch (Exception)
            {
                InvertScale = false;
            }
        }

        #endregion Serialization

        #region Question Localisation

        public override void LoadGlobalQ()
        {
            LoadQArray(Questions);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQArray(td, Questions);
        }

        #endregion Question Localisation

        public override void Compute()
        {
            Compute(eval.Global);
        }

        private void Compute(TargetData td)
        {
            //prepare 

            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            Chart chart = new Chart();
            DncSettings.Apply(chart);
            chart.Title = "";
            chart.Width = width;
            chart.Height = height;
            chart.DefaultSeries.EmptyElement.Mode = EmptyElementMode.TreatAsZero;
            chart.Type = ChartType.Combo;
            chart.DefaultSeries.Type = SeriesType.Line;
            chart.LegendBox.Visible = DncSettings.ShowLegend;
            chart.LegendBox.DefaultEntry.Value = "";

            //chart.Depth = 15;

            //compute
            SeriesCollection series = new SeriesCollection();


            //get person combo
            foreach (PersonSetting ps in CombinedPersons)
            {
                // each question is a series
                foreach (Question q in Questions)
                {
                    Series s = new Series(q.SID+" "+ps.Short);
                    s.DefaultElement.Marker.Type = ElementMarkerType.Circle;
                    s.DefaultElement.Color = Colors[q.SID + ps.Short];
                    s.LegendEntry.Name = Legends.ContainsKey(q.SID + ps.Short) ? Legends[q.SID+ps.Short] : q.SID + " "+ps.Short;

                    s.Line.Width = Widths.ContainsKey(q.SID + ps.Short) ? Widths[q.SID + ps.Short] : LineWidth;
                    s.Line.DashStyle = LineStyle.ContainsKey(q.SID + ps.Short) ? LineStyle[q.SID + ps.Short] : styleofLine;

                    //each historic representation is an element
                    foreach (String histId in HistoricIDs)
                    {
                        Element e = new Element();
                        e.Name = histId;

                        bool found = false;

                        //get historic td
                        foreach (HistoricData hData in eval.History)
                        {
                            if (hData.Name == histId)
                            {
                                //get td
                                foreach (TargetData hTd in hData.Eval.CombinedTargets)
                                {
                                    try
                                    {
                                        if (hTd.Name == td.Name)
                                        {
                                            e.YValue = hTd.GetQuestion(q, hData.Eval).GetAverageByPersonAsMark(hData.Eval, ps);
                                            found = true;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //htd.GetQuestion holt ein wert welches nicht gibt -> Exception
                                        //MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                                    }
                                }
                            }
                        }

                        if (found && e.YValue != -1)
                        {
                            s.Elements.Add(e);
                        }
                    }

                    //current value is also an element
                    Element current = new Element();
                    current.Name = CurrentName;
                    current.YValue = td.GetQuestion(q, eval).GetAverageByPersonAsMark(eval, ps);
                    if (current.YValue != -1)
                    {
                        s.Elements.Add(current);
                    }

                    series.Add(s);
                }//end loop
            




            #region Area

            if (ShowArea)
            {
                Series area = new Series();
                area.Type = SeriesType.AreaLine;
                area.DefaultElement.Transparency = 80;
                area.DefaultElement.Color = Color.Gray;
                area.DefaultElement.Marker.Type = ElementMarkerType.None;

                foreach (Question q in Questions)
                {
                    //historic elements
                    //each historic representation is an element
                    foreach (String histId in HistoricIDs)
                    {
                        Element e = new Element();
                        e.Color = Colors[q.SID];
                        e.Name = histId;

                        bool found = false;

                        //get historic td
                        foreach (HistoricData hData in eval.History)
                        {
                            if (hData.Name == histId)
                            {
                                e.YValue = GetFlop(hData.Eval, q, ps);
                                e.YValueStart = GetTop(hData.Eval, q, ps);
                                found = true;
                            }
                        }

                        if (found && e.YValue != Double.MinValue && e.YValueStart != Double.MaxValue)
                        {
                            area.Elements.Add(e);
                        }
                    }

                    //current element
                    Element current = new Element();
                    current.Name = CurrentName;
                    current.YValue = GetFlop(eval, q, ps);
                    current.YValueStart = GetTop(eval, q, ps);
                    if (current.YValue != Double.MinValue && current.YValueStart != Double.MaxValue)
                    {
                        area.Elements.Add(current);
                    }
                }

                series.Add(area);
            }

            #endregion Area
            }///

            chart.SeriesCollection.Add(series);
            chart.YAxis.Maximum = ScaleMax;
            chart.YAxis.Minimum = ScaleMin;
            chart.YAxis.InvertScale = InvertScale;

            //save
            chart.Application = "itcIidhdhyk+bW1OOBTArpfNOr3GopKuOit20bU6/G4MlNN6vnk4wkfGB+NlXC+EWdY1Rm4vJ0qKOQOmw7d7gw==";
            chart.DrawToBitmap(OutputImage, new Rectangle(0, 0, OutputImage.Width, OutputImage.Height));
        }//end Compute

        private double GetTop(Evaluation e, Question q, PersonSetting p)
        {
            double top = Double.MaxValue;
            foreach (TargetData td in e.Targets)
            {
                double val = td.GetQuestion(q, e).GetAverageByPersonAsMark(e, p);
                if (val != -1 && val < top)
                {
                    top = val;
                }
            }
            return top;
        }

        private double GetFlop(Evaluation e, Question q, PersonSetting p)
        {
            double top = Double.MinValue;
            foreach (TargetData td in e.Targets)
            {
                double val = td.GetQuestion(q, e).GetAverageByPersonAsMark(e, p);
                if (val != -1 && val > top)
                {
                    top = val;
                }
            }
            return top;
        }

        public override Control EditControl()
        {
            HistoricChangeControl control = new HistoricChangeControl();
            HistoricChangeController controller = new HistoricChangeController(control, eval, this);
            controller.Preview();
            return control;
        }

        #region Save and Edit

        public override void Save(string name, string path)
        {
            Question[] baseq = Questions;

            //cross?
            Evaluation seval;
            if (CrossTargets(Questions))
            {
                seval = CrEval;
            }
            else if (OvEval != null)
            {
                seval = OvEval;
            }
            else
            {
                seval = eval;
            }
            //Targets

            foreach (TargetData td in seval.CombinedTargets)
            {
                if (!td.Included)
                    continue;

                int i = 0;
                foreach (Question q in baseq)
                    Questions[i++] = td.GetQuestion(q, Eval);

                Compute();

                FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").png"), FileMode.Create);
                OutputImage.Save(myFileOut, ImageFormat.Png);
                myFileOut.Close();
            }

            OutputImage = null;
        }

        public override void EditDialog()
        {
            throw new NotImplementedException();
        }

        #endregion Save and Edit
    }
}
