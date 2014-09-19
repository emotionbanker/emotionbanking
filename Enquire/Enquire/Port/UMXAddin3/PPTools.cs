using System;
using System.Collections;
using System.Drawing;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Compucare.Enquire.Legacy.UMXAddin3
{
    class PPTools
    {
        public Question q;
        public string[] crosses;
        public Evaluation eval;
        public TargetData td;
        public TargetData tdo;
        public string[] dat;
        public Question cq;
        public int cqid;
        public string[] master;
        public Question bq = null;
        private string _code;

        public bool Base
        {
            get
            {
                return (bq != null);
            }
        }

        public String GetXmlMaster()
        {
            //strip header
            string xml = master[0].Substring(master[0].IndexOf(':') + 1);

            //strip xml header
            xml = xml.Substring(xml.IndexOf(':') + 1);

            return xml;
        }

        

        public PPTools(String code, TargetData td, Evaluation eval)
        {
            // master[0] = dat
            // master[1] = word link id
            // master[2] = cross
            // master[3] = percent base
            _code = code;

            master = (code + "|").Split(new char[] { '|' });

            string[] dat = master[0].Split(new char[] { ':' });
            string[] crosses = null;

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

            this.dat = dat;

            if (!dat[1].StartsWith("xml"))
            {
                Question q;
                if (!dat[1].Equals("op") && !dat[1].Equals("op-c"))
                    q = td.GetQuestion(Int32.Parse(dat[2]), eval);
                else
                    q = null;

                try
                {

                    int cqid = 0;
                    foreach (string cross in crosses)
                    {
                        string[] cdat = cross.Split(new char[] {'.'});
                        cqid = Int32.Parse(cdat[0]);
                    }

                    Question cq = tdo.GetQuestion(cqid, eval);
                    this.cq = cq;
                    this.cqid = cqid;
                }
                catch
                {
                }

                this.q = q;
                this.crosses = crosses;
                this.eval = eval;
                this.td = td;
                this.tdo = tdo;
                this.dat = dat;

                // compute baseq

                if (master.Length > 3 && master[3].Trim() != string.Empty)
                {
                    string[] bdat = master[3].Split(new char[] {':'});

                    TargetData btd = tdo.Clone;

                    if (bdat[1].Trim() != string.Empty)
                    {
                        string[] bcrosses = bdat[1].Split(new char[] {'#'});

                        foreach (string cross in bcrosses)
                        {
                            string[] cdat = cross.Split(new char[] {'.'});

                            int qid = Int32.Parse(cdat[0]);
                            int aid = Int32.Parse(cdat[1]);

                            btd = Tools.Cross(eval, btd, btd.GetQuestion(qid, eval), aid);
                        }
                    }

                    bq = btd.GetQuestion(Int32.Parse(bdat[0]), eval);
                }
            }
        }

        public String NPS()
        {
            return NPS(td.GetQuestion(Int32.Parse(dat[2]), eval),eval);
        }

        public String NPS(Question q, Evaluation eval2)
        {

            PersonSetting ps = eval2.CombinedPersons[Int32.Parse(dat[4])];
            string ins = "";

            int n = q.NAnswersByPerson(eval2, ps);

            if (n == 0)
            {
                return "k.A.";
            }

            Question pqn = q; //
            float pcnt1 = (float)pqn.GetAnswerPercentByPerson(0, eval2, ps);
            float pcnt3 = (float)pqn.GetAnswerPercentByPerson(2, eval2, ps);
            float pcnt4 = (float)pqn.GetAnswerPercentByPerson(3, eval2, ps);
            float pcnt5 = (float)pqn.GetAnswerPercentByPerson(4, eval2, ps);

            float nps = (pcnt1 - (pcnt3 + pcnt4 + pcnt5));

            if (nps > 0) ins = "+";
            else ins = "";
            ins += Math.Round(nps, Int32.Parse(dat[3]));

            return ins;
        }

        public String NPSDiff(Question q1, Evaluation eval1, Question q2, Evaluation eval2)
        {
            double nps1 = double.Parse(NPS(q1, eval1));
            double nps2 = double.Parse(NPS(q2, eval2));

            return Math.Round(nps1 - nps2, Int32.Parse(dat[3])).ToString();
        }

        public ArrayList ComputeTag()
        {
            //get percent/answer for answer
            /*
             * 2 .. qid
             * 3 .. prec
             * 4 .. person
             * 5,6,7 .. col1
             * 8,9,10 .. col2
             * 11,12,13 .. col3
             * 14,15 .. x1,x2
             * 16,17 .. f1,f2
             * 18/19/20 .. answer
             * 18 .. log style or linear - log if not set
             * 19 .. auto color or no color
             * */

            bool log = true;
            bool auto = true;

            string answer = dat[18];

            if (dat.Length > 20)
            {
                if (dat[18].Equals("lin")) log = false;
                if (dat[19].Equals("none")) auto = false;
                answer = dat[20];
            }

            float apcnt = (float)q.GetAnswerPercentByPerson(answer, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

            float tmin = 100;
            float tmax = 0;

            foreach (String a in q.AnswerList)
            {
                float vapcnt = (float)q.GetAnswerPercentByPerson(a, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                if (vapcnt > tmax) tmax = vapcnt;
                if (vapcnt < tmin) tmin = vapcnt;
            }

            if (tmin == 100) tmin = 0;

            Color c = Color.Black;

            float x1 = float.Parse(dat[14], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            float x2 = float.Parse(dat[15], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            if (apcnt > x1) c = Color.FromArgb(Int32.Parse(dat[5]), Int32.Parse(dat[6]), Int32.Parse(dat[7]));
            else if (apcnt > x2) c = Color.FromArgb(Int32.Parse(dat[8]), Int32.Parse(dat[9]), Int32.Parse(dat[10]));
            else c = Color.FromArgb(Int32.Parse(dat[11]), Int32.Parse(dat[12]), Int32.Parse(dat[13]));

            float fmin = float.Parse(dat[16], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            float fmax = float.Parse(dat[17], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            
            float f = fmin;

            if (log)
            {
                if (tmax - tmin != 0)
                {
                    if (apcnt > tmin) f = (fmax * (apcnt - tmin)) / (tmax - tmin);
                }
            }
            else
            {
                //linear

                // 0..min
                // 100..max

                float rangefact = (fmax - fmin)/100;

                f = fmin + (apcnt * rangefact);
            }

            if (f < fmin) f = fmin;

            

            ArrayList res = new ArrayList();

            if (auto) res.Add(c);
            else res.Add(null);
            res.Add(f);
            res.Add(answer);
            return res;
        }
      
        public string ComputeMaturity()
        {
            int r = Int32.Parse(dat[7]);
            int f = Int32.Parse(dat[8]);

            PersonSetting ps = eval.CombinedPersons[Int32.Parse(dat[9])];

            

            double count = 0;
            double[,] table = new double[4, 4];

            string rowlist = "";

            string r1 = "";
            string r2 = "";
            string r3 = "";
            
            
            foreach (User u in eval.Users)
            {
                if (u == null) continue;
                if (!ps.ContainsID(u.PersonID)) continue;

                bool skip = false;
                bool[] vals = new bool[4];

                for (int row = 0; row < 4; row++)
                {
                    double val = 0;
                    double cnt = 0;

                    foreach (string id in dat[3 + row].Split(new char[] { ',' }))
                    {
                        Question q = td.GetQuestionById(Int32.Parse(id.Trim()));

                        
                        if (q == null) continue;

                        if (q.GetResultByUserID(u.ID) != null)
                        {
                            if (q.GetResultByUserID(u.ID).SelectedAnswer >= 0 && q.GetResultByUserID(u.ID).SelectedAnswer <= 4)
                            {
                                val += (double)q.GetResultByUserID(u.ID).SelectedAnswer + 1;
                                cnt++;

                            }
                        }
                    }

                    /*
                    if (val >= 1 && val <= 5 && row == 1)
                    {
                        rowlist += val + ";";
                        if (cnt == 2) MessageBox.Show("val=" + val);
                    }
                     * */

                    val = Math.Round(val/cnt, 0, MidpointRounding.AwayFromZero);

                   

                    //if (val == 0) MessageBox.Show("0 sollte hier nicht sein");

                    if (val == 1 || val == 2) vals[row] = true;
                    else if (val == 3 || val == 4 || val == 5) vals[row] = false;
                    else skip = true;
                
                }

                if (skip) continue;

                int[] rf = new int[2];

                /*
                 * 0 .. a.rel. wissen
                 * 1 .. leist. mot.
                 * 2 .. mitarb.or
                 * 3 .. aufg.or
                 * 
                 * */

                if (!vals[0] && !vals[1]) rf[0] = 1;
                else if (!vals[0] && vals[1]) rf[0] = 2;
                else if (vals[0] && !vals[1]) rf[0] = 3;
                else if (vals[0] && vals[1]) rf[0] = 4;

                if (!vals[2] && vals[3]) rf[1] = 1;
                else if (vals[2] && vals[3]) rf[1] = 2;
                else if (vals[2] && !vals[3]) rf[1] = 3;
                else if (!vals[2] && !vals[3]) rf[1] = 4;

                table[rf[0] - 1, rf[1] - 1]++;
                count++;

            }

            //MessageBox.Show(rowlist, rowcount + "/" + ps.GetAllUsers(eval).Count);
            
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    table[i, j] = Math.Round(table[i, j] / count * 100, Int32.Parse(dat[10]));

            //return rowlist + "    ---    " + rowlist2;
            //return rowlist;
            return "" + table[r, f];
        }

        public static void SetStyle(Microsoft.Office.Interop.PowerPoint.Shape s, Microsoft.Office.Interop.PowerPoint.Shape ns)
        {
            try
            {
                //ns.ShapeStyle = s.ShapeStyle;
                //ns.Shadow = s.Shadow;
                //ns.SoftEdge = s.SoftEdge;
                //ns.ThreeD = s.ThreeD;
                //ns.Visible = s.Visible;
                //ns.PictureFormat = s.PictureFormat;
                //ns.LockAspectRatio = s.LockAspectRatio;
                //ns.Glow = s.Glow;
                //ns.Fill = s.Fill;
                //ns.BlackWhiteMode = s.BlackWhiteMode;
                //ns.BackgroundStyle = s.BackgroundStyle;
                //ns.AutoShapeType = s.AutoShapeType;

                ns.Tags.Add("umxcode", s.Tags["umxcode"]);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace, exception.Message);
            }
        }

        public string Potpic()
        {
            if (crosses == null) return "";

            int iqid = 0;
            int iaid = -1;
            foreach (string cross in crosses)
            {
                string[] cdat = cross.Split(new char[] { '.' });

                iqid = Int32.Parse(cdat[0]);
                iaid = Int32.Parse(cdat[1]);
            }


            if (iqid == 0 || iaid == -1) return "";

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


            return pbfname;
        }

        public string Potpcnt()
        {
            string ins = "";
            //master
            if (crosses == null) return "k.A.";

            int qid = 0;
            int aid = -1;
            foreach (string cross in crosses)
            {
                string[] cdat = cross.Split(new char[] { '.' });

                qid = Int32.Parse(cdat[0]);
                aid = Int32.Parse(cdat[1]);
            }


            if (qid == 0 || aid == -1) return "k.A.";

            QuestionSplit qsplit = new QuestionSplit(tdo.GetQuestion(Int16.Parse(dat[2]), eval), tdo.GetQuestion(qid, eval));

            Question[] qlist = qsplit.ComputeQuestionSplits(eval);


            float ptotavg = tdo.GetQuestion(Int16.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - 1;

            foreach (Question qlq in qlist)
            {
                if (qlq.ID == aid)
                {
                    float myavg = qlq.GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - 1;

                    //sign change
                    //ins = "" + (Math.Round((((myavg - ptotavg) / ptotavg) * 100), Int32.Parse(dat[3])) * -1);
                    //no sign change
                    ins = "" + (Math.Round((((myavg - ptotavg) / ptotavg) * 100), Int32.Parse(dat[3])));
                }
            }

            return ins;
        }

        public string Pbar()
        {
            string bfname = System.IO.Path.GetTempFileName() + ".png";

            Tools.CreateBarImage(eval, q, eval.CombinedPersons[Int32.Parse(dat[4])], 180, 17).Save(bfname, System.Drawing.Imaging.ImageFormat.Png);


            return bfname;
        }

        public string Tl()
        {
            double tval = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));


            string tfname = System.IO.Path.GetTempFileName() + ".png";

            Tools.CreateTLImage(eval, tval, 8).Save(tfname, System.Drawing.Imaging.ImageFormat.Png);

            return tfname;
        }

        public string Idivtl()
        {
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


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public String ExclamationGap()
        {
            try
            {
                string[] pids = dat[4].Split(new char[] { '#' });

                double gap = 0;

                if (pids.Length >= 2)
                {
                    int p1 = Int32.Parse(pids[0]);
                    int p2 = Int32.Parse(pids[1]);

                    double v1 = q.GetAverageByPersonAsMark(eval, eval.CombinedPersons[p1]);
                    double v2 = q.GetAverageByPersonAsMark(eval, eval.CombinedPersons[p2]);

                    gap = Math.Round(Math.Abs(v1 - v2), Int32.Parse(dat[3]));
                }

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

                ExclamationMark mark = new ExclamationMark();
                mark.ColorHigh = c1;
                mark.ColorMiddle = c2;
                mark.ColorLow = c3;

                mark.Value = gap;

                mark.RangeDelimiterHigh = x1;
                mark.RangeDelimiterLow = x2;

                mark.ImageSize = rad;

                mark.Compute();

                ((Image)mark.Result).Save(itfname, ImageFormat.Png);

                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public String ExclamationCompare()
        {
            try
            {
                double itval1 = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));
                double itval2 = Math.Round(tdo.GetQuestion(Int32.Parse(dat[5]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));

                double itval = itval1 - itval2;
                //MessageBox.Show(itval1 + " - " + itval2 + " = " + itval);

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";

                ExclamationMark mark = new ExclamationMark();
                mark.ColorHigh = c1;
                mark.ColorMiddle = c2;
                mark.ColorLow = c3;

                mark.Value = itval;

                mark.RangeDelimiterHigh = x1;
                mark.RangeDelimiterLow = x2;

                mark.ImageSize = rad;

                mark.Compute();

                ((Image)mark.Result).Save(itfname, ImageFormat.Png);

                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string ExclamationSingle()
        {
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

                ExclamationMark mark = new ExclamationMark();
                mark.ColorHigh = c1;
                mark.ColorMiddle = c2;
                mark.ColorLow = c3;

                mark.Value = itval;

                mark.RangeDelimiterHigh = x1;
                mark.RangeDelimiterLow = x2;

                mark.ImageSize = rad;

                mark.Compute();

                ((Image)mark.Result).Save(itfname, ImageFormat.Png);

                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string Comparetl()
        {
            try
            {
                double itval1 = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));
                double itval2 = Math.Round(tdo.GetQuestion(Int32.Parse(dat[5]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));

                double itval = itval1 - itval2;
                //MessageBox.Show(itval1 + " - " + itval2 + " = " + itval);

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                Tools.CreateTLImage2(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string IdivtlPcnt()
        {
            try
            {
                double itval = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAnswerPercentByPerson(dat[11], eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));

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


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }


        public string Comparetlpcnt()
        {
            try
            {
                double itval1 = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAnswerPercentByPerson(dat[12], eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));
                double itval2 = Math.Round(tdo.GetQuestion(Int32.Parse(dat[5]), eval).GetAnswerPercentByPerson(dat[12], eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));

                double itval = itval1 - itval2;

                //MessageBox.Show(itval+"");

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                Tools.CreateTLImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string Comparetlnps()
        {
            try
            {
                Question q1 = td.GetQuestion(Int32.Parse(dat[2]), eval);
                Question q2 = tdo.GetQuestion(Int32.Parse(dat[5]), eval);

                float pcnt1 = (float)q1.GetAnswerPercentByPerson(0, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                float pcnt3 = (float)q1.GetAnswerPercentByPerson(2, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                float pcnt4 = (float)q1.GetAnswerPercentByPerson(3, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                float pcnt5 = (float)q1.GetAnswerPercentByPerson(4, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

                //=nps
                double nps1 = (pcnt1 - (pcnt3 + pcnt4 + pcnt5));

                pcnt1 = (float)q2.GetAnswerPercentByPerson(0, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                pcnt3 = (float)q2.GetAnswerPercentByPerson(2, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                pcnt4 = (float)q2.GetAnswerPercentByPerson(3, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                pcnt5 = (float)q2.GetAnswerPercentByPerson(4, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

                //=nps
                double nps2 = (pcnt1 - (pcnt3 + pcnt4 + pcnt5));

                double itval = nps1 - nps2;

                //MessageBox.Show(itval1 + " - " + itval2 + " = " + itval);

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                Tools.CreateTLImage2(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string IdivtlNps()
        {
            try
            {
                Question pqn = td.GetQuestion(Int32.Parse(dat[2]), eval);
                float pcnt1 = (float)pqn.GetAnswerPercentByPerson(0, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                float pcnt3 = (float)pqn.GetAnswerPercentByPerson(2, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                float pcnt4 = (float)pqn.GetAnswerPercentByPerson(3, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                float pcnt5 = (float)pqn.GetAnswerPercentByPerson(4, eval, eval.CombinedPersons[Int32.Parse(dat[4])]);

                //=nps
                double itval = (pcnt1 - (pcnt3 + pcnt4 + pcnt5));


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


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string IdivtlNum()
        {
            try
            {
                double itval = Math.Round(td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageAnswersByUser(eval, eval.CombinedPersons[Int32.Parse(dat[4])]), Int32.Parse(dat[3]));

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


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }


        public string bconCombo(TargetData ctv, Evaluation[] multiEvals)
        {

            return "";
        }

        public Image bconTrendImage(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                //vals
                double ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                double ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAverageByPersonAsMark(multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                double i = Math.Round(ctvoval - ctvcval, Int32.Parse(dat[3]));


                //colors 6,7,8,9,10

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[9].Split(new char[] { '-' });
                Color c4 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[10].Split(new char[] { '-' });
                Color c5 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                //values 11,12,13,14

                float x1 = float.Parse(dat[11]);
                float x2 = float.Parse(dat[12]);
                float x3 = float.Parse(dat[13]);
                float x4 = float.Parse(dat[14]);

                //autoangle 15

                string aangle = dat[15];

                //angles 16,17,18,19,20

                float angle1 = float.Parse(dat[16]);
                float angle2 = float.Parse(dat[17]);
                float angle3 = float.Parse(dat[18]);
                float angle4 = float.Parse(dat[19]);
                float angle5 = float.Parse(dat[20]);

                //draw

                Color ccol = Color.Gray;

                if (i >= x1) ccol = c1;
                else if (i >= x2) ccol = c2;
                else if (i >= x3) ccol = c3;
                else if (i >= x4) ccol = c4;
                else ccol = c5;


                float angle = 0;

                if (aangle == "1")
                {
                    angle = (float)((90 / 4) * i);
                }
                else
                {
                    if (i >= x1) angle = angle1;
                    else if (i >= x2) angle = angle2;
                    else if (i >= x3) angle = angle3;
                    else if (i >= x4) angle = angle4;
                    else angle = angle5;
                }

                //choose tlb color
                //x1 = 26, x2 = 27

                Color c = Color.LightGray;

                dss = dat[23].Split(new char[] { '-' });
                c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[24].Split(new char[] { '-' });
                c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[25].Split(new char[] { '-' });
                c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));


                //MessageBox.Show("val=" + ctvoval + ": " + dat[26] + "/" + dat[27]);
                //MessageBox.Show("1:" + c1 + "\n2:" + c2 + "\n3:" + c3, "cols");
                if (ctvoval == -1) c = Color.LightGray;
                else if (ctvoval < float.Parse(dat[27])) c = c3; //grün
                else if (ctvoval < float.Parse(dat[26])) c = c2; //gelb
                else c = c1; //rot

                //build
                
                return Tools.CreateTrendArrow(ccol, angle, Int32.Parse(dat[22]), Int32.Parse(dat[21]), c);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return null;
            }
        }

        public Image bconTrendNPSImage(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                //vals
                double ctvoval = Double.Parse(NPS(td.GetQuestion(Int32.Parse(dat[2]), eval), eval));

                double i = Double.Parse(NPSDiff(td.GetQuestion(Int32.Parse(dat[2]), eval), eval,
                                       ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]),
                                      multiEvals[Int32.Parse(dat[5])]));


                //colors 6,7,8,9,10

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[9].Split(new char[] { '-' });
                Color c4 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[10].Split(new char[] { '-' });
                Color c5 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                //values 11,12,13,14

                float x1 = float.Parse(dat[11]);
                float x2 = float.Parse(dat[12]);
                float x3 = float.Parse(dat[13]);
                float x4 = float.Parse(dat[14]);


                //autoangle 15

                string aangle = dat[15];

                //angles 16,17,18,19,20

                float angle1 = float.Parse(dat[16]);
                float angle2 = float.Parse(dat[17]);
                float angle3 = float.Parse(dat[18]);
                float angle4 = float.Parse(dat[19]);
                float angle5 = float.Parse(dat[20]);




                //draw

                Color ccol = Color.Gray;

                if (i >= x1) ccol = c1;
                else if (i >= x2) ccol = c2;
                else if (i >= x3) ccol = c3;
                else if (i >= x4) ccol = c4;
                else ccol = c5;


                float angle = 0;

                if (aangle == "1")
                {
                    angle = (float)((90 / 4) * i);
                }
                else
                {
                    if (i >= x1) angle = angle1;
                    else if (i >= x2) angle = angle2;
                    else if (i >= x3) angle = angle3;
                    else if (i >= x4) angle = angle4;
                    else angle = angle5;
                }

                //choose tlb color
                //x1 = 26, x2 = 27

                Color c = Color.LightGray;

                dss = dat[23].Split(new char[] { '-' });
                c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[24].Split(new char[] { '-' });
                c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[25].Split(new char[] { '-' });
                c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));


                //MessageBox.Show("val=" + ctvoval + ": " + dat[26] + "/" + dat[27]);
                //MessageBox.Show("1:" + c1 + "\n2:" + c2 + "\n3:" + c3, "cols");
                if (ctvoval == -1) c = Color.LightGray;
                else if (ctvoval < float.Parse(dat[27])) c = c3; //grün
                else if (ctvoval < float.Parse(dat[26])) c = c2; //gelb
                else c = c1; //rot

                //build

                return Tools.CreateTrendArrow(ccol, angle, Int32.Parse(dat[22]), Int32.Parse(dat[21]), c);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return null;
            }
        }

        public string bconTrend(TargetData ctv, Evaluation[] multiEvals)
        {

            //temp file
            string itfname = System.IO.Path.GetTempFileName() + ".png";

            bconTrendImage(ctv, multiEvals).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);

            return itfname;
        }

        public string bconExclamation(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                
                double ctvoval;
                double ctvcval;

                ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAverageByPersonAsMark(multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                double itval = Math.Round(ctvoval - ctvcval, Int32.Parse(dat[3]));
          
                //compare on 8

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);
                
                string itfname = System.IO.Path.GetTempFileName() + ".png";

           
                Tools.CreateExclamationImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);

              
                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
            
            
            
        }

        public string bconExclamationApc(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                double ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAnswerPercentByPerson(dat[12], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                double ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAnswerPercentByPerson(dat[12], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                double itval = Math.Round(ctvoval - ctvcval, Int32.Parse(dat[3]));

                //compare on 8

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                Tools.CreateExclamationImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string bconExclamationNPS(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                double itval = Double.Parse(NPSDiff(td.GetQuestion(Int32.Parse(dat[2]), eval), eval,
                                       ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]),
                                      multiEvals[Int32.Parse(dat[5])]));

                //compare on 8

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                Tools.CreateExclamationImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_code);
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string bconTrendNPS(TargetData ctv, Evaluation[] multiEvals)
        {

            //temp file
            string itfname = System.IO.Path.GetTempFileName() + ".png";

            bconTrendNPSImage(ctv, multiEvals).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);

            return itfname;
        }

        public string bconTrendApc(TargetData ctv, Evaluation[] multiEvals)
        {

            //temp file
            string itfname = System.IO.Path.GetTempFileName() + ".png";

            bconTrendImageApc(ctv, multiEvals).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);

            return itfname;
        }

        public Image bconTrendImageApc(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                //answer should be 29
                //MessageBox.Show(dat[29]);

                //vals
                double ctvoval;
                double ctvcval;

                if (Base)
                {
                    ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAnswerPercentByPersonWithBase(dat[29], eval, eval.CombinedPersons[Int32.Parse(dat[4])], bq);
                    ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAnswerPercentByPersonWithBase(dat[29], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])], bq);
                }
                else
                {
                    ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAnswerPercentByPerson(dat[29], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                    ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAnswerPercentByPerson(dat[29], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);
                }

                double i = Math.Round(ctvoval - ctvcval, Int32.Parse(dat[3]));


                //colors 6,7,8,9,10

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[9].Split(new char[] { '-' });
                Color c4 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[10].Split(new char[] { '-' });
                Color c5 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                //values 11,12,13,14

                float x1 = float.Parse(dat[11]);
                float x2 = float.Parse(dat[12]);
                float x3 = float.Parse(dat[13]);
                float x4 = float.Parse(dat[14]);


                //autoangle 15

                string aangle = dat[15];

                //angles 16,17,18,19,20

                float angle1 = float.Parse(dat[16]);
                float angle2 = float.Parse(dat[17]);
                float angle3 = float.Parse(dat[18]);
                float angle4 = float.Parse(dat[19]);
                float angle5 = float.Parse(dat[20]);




                //draw

                Color ccol = Color.Gray;

                if (i >= x1) ccol = c1;
                else if (i >= x2) ccol = c2;
                else if (i >= x3) ccol = c3;
                else if (i >= x4) ccol = c4;
                else ccol = c5;


                float angle = 0;

                if (aangle == "1")
                {
                    angle = (float)((90 / 100) * i);
                }
                else
                {
                    if (i >= x1) angle = angle1;
                    else if (i >= x2) angle = angle2;
                    else if (i >= x3) angle = angle3;
                    else if (i >= x4) angle = angle4;
                    else angle = angle5;
                }

                //choose tlb color
                //x1 = 26, x2 = 27
                //rad = 28

                Color c = Color.LightGray;

                dss = dat[23].Split(new char[] { '-' });
                c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[24].Split(new char[] { '-' });
                c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[25].Split(new char[] { '-' });
                c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));


                //MessageBox.Show("val=" + ctvoval + ": " + dat[26] + "/" + dat[27]);
                //MessageBox.Show("1:" + c1 + "\n2:" + c2 + "\n3:" + c3, "cols");
                if (ctvoval == -1) c = Color.LightGray;
                else if (ctvoval < float.Parse(dat[27])) c = c3; //grün
                else if (ctvoval < float.Parse(dat[26])) c = c2; //gelb
                else c = c1; //rot

                //build

                return Tools.CreateTrendArrow(ccol, angle, Int32.Parse(dat[22]), Int32.Parse(dat[21]), c);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return null;
            }
        }

        public string bcontLightImage(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                double ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                double ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAverageByPersonAsMark(multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                double itval = Math.Round(ctvoval - ctvcval, Int32.Parse(dat[3]));

                //compare on 8

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                Tools.CreateTLImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string bcontLight(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                double ctvoval;
                double ctvcval;

                ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAverageByPersonAsMark(multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                double itval = Math.Round(ctvoval - ctvcval, Int32.Parse(dat[3]));

                //compare on 8

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                Tools.CreateTLImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_code);
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string bcontLightNPS(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                double itval = Double.Parse(NPSDiff(td.GetQuestion(Int32.Parse(dat[2]), eval), eval,
                                       ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]),
                                      multiEvals[Int32.Parse(dat[5])]));

                //compare on 8

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                Tools.CreateTLImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_code);
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public string bcontLightApc(TargetData ctv, Evaluation[] multiEvals)
        {
            try
            {
                double ctvoval = td.GetQuestion(Int32.Parse(dat[2]), eval).GetAnswerPercentByPerson(dat[12], eval, eval.CombinedPersons[Int32.Parse(dat[4])]);
                double ctvcval = ctv.GetQuestion(Int32.Parse(dat[2]), multiEvals[Int32.Parse(dat[5])]).GetAnswerPercentByPerson(dat[12], multiEvals[Int32.Parse(dat[5])], multiEvals[Int32.Parse(dat[5])].CombinedPersons[Int32.Parse(dat[4])]);

                double itval = Math.Round(ctvoval - ctvcval, Int32.Parse(dat[3]));

                //compare on 8

                float x1 = float.Parse(dat[9]);
                float x2 = float.Parse(dat[10]);

                string[] dss = dat[6].Split(new char[] { '-' });
                Color c1 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[7].Split(new char[] { '-' });
                Color c2 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                dss = dat[8].Split(new char[] { '-' });
                Color c3 = Color.FromArgb(Int32.Parse(dss[0]), Int32.Parse(dss[1]), Int32.Parse(dss[2]));

                int rad = Int32.Parse(dat[11]);

                string itfname = System.IO.Path.GetTempFileName() + ".png";


                Tools.CreateTLImage(eval, itval, rad, x1, x2, c1, c2, c3).Save(itfname, System.Drawing.Imaging.ImageFormat.Png);


                return itfname;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
                return "";
            }
        }

        public Output compop = null;

        public string op()
        {
            foreach (Report rep in eval.Reports)
            {
                if (rep.Name.Equals(dat[2]))
                {
                    foreach (Output o in rep.Outputs)
                    {
                        if (o.Name.Equals(dat[3]))
                        {
                            this.compop = o;
                            //o.width = (int) float.Parse(dat[4]);
                            //o.height = (int) float.Parse(dat[5]);

                            o.LoadTargetQ(td);

                            o.Eval = eval;

                            o.Compute();
                            
                            string fname = System.IO.Path.GetTempFileName() + ".png";

                            //MessageBox.Show(fname);

                            EncoderParameters ep = new EncoderParameters(1);
                            ep.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                            ImageCodecInfo ici = null;

                            foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                            {

                                if (codec.MimeType == "image/png")

                                    ici = codec;

                            }

                            o.OutputImage.Save(fname, ici, ep);

                            return fname;
                        }
                    }

                    break;
                }
            }

            return "";
        }

        public string opC(Connect conn)
        {
            Int32 cval = Int32.Parse(dat[6]);
            Evaluation ceval = conn.GetCEval(cval);
            TargetData ctd = conn.GetCTarget(cval);

            foreach (Report rep in ceval.Reports)
            {
                if (rep.Name.Equals(dat[2]))
                {
                    foreach (Output o in rep.Outputs)
                    {
                        if (o.Name.Equals(dat[3]))
                        {
                            this.compop = o;
                            //o.width = (int) float.Parse(dat[4]);
                            //o.height = (int) float.Parse(dat[5]);

                            o.LoadTargetQ(ctd);

                            o.Eval = ceval;

                            o.Compute();

                            string fname = System.IO.Path.GetTempFileName() + ".png";

                            //MessageBox.Show(fname);

                            EncoderParameters ep = new EncoderParameters(1);
                            ep.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

                            ImageCodecInfo ici = null;

                            foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                            {

                                if (codec.MimeType == "image/png")

                                    ici = codec;

                            }

                            o.OutputImage.Save(fname, ici, ep);

                            return fname;
                        }
                    }

                    break;
                }
            }

            return "";
        }

        public string Potval()
        {
            string ins = "k.A.";
            if (crosses == null) return ins ;

            int vqid = 0;
            int vaid = -1;
            foreach (string cross in crosses)
            {
                string[] cdat = cross.Split(new char[] { '.' });

                vqid = Int32.Parse(cdat[0]);
                vaid = Int32.Parse(cdat[1]);
            }


            if (vqid == 0 || vaid == -1) return ins;

            QuestionSplit vqsplit = new QuestionSplit(tdo.GetQuestion(Int16.Parse(dat[2]), eval), tdo.GetQuestion(vqid, eval));

            Question[] vqlist = vqsplit.ComputeQuestionSplits(eval);


            float totavg = tdo.GetQuestion(Int16.Parse(dat[2]), eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - 1;

            foreach (Question vqlq in vqlist)
            {
                if (vqlq.ID == vaid)
                {
                    // sign change
                    //ins = "" + (Math.Round((vqlq.GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - totavg) - 1, Int32.Parse(dat[3])) * -1);
                    // no sigtn change
                    ins = "" + (Math.Round((vqlq.GetAverageByPersonAsMark(eval, eval.CombinedPersons[Int32.Parse(dat[4])]) - totavg) - 1, Int32.Parse(dat[3])));
                }
            }

            return ins;
        }
    }
}
