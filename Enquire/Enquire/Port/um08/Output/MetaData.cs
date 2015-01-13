using System;
using System.IO;
using System.Collections;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
    class MetaData
    {
        public static void Compute(Evaluation eval, string file, string type)
        {
            FileStream fs = new FileStream(file, FileMode.Create);
            StreamWriter sr = new StreamWriter(fs);


            sr.WriteLine("Metadaten und Statistiken, " + eval.DatabaseName + "/" + eval.DatabasePrefix + ", " + eval.LastResultUpdate);


            foreach (TargetData td in eval.CombinedTargets)
            {
                sr.WriteLine();
                sr.WriteLine();
                sr.WriteLine("==============================");

                sr.WriteLine(td.ToString());

                sr.WriteLine("==============================");
                sr.WriteLine();
                sr.WriteLine();

                ArrayList uids = new ArrayList();
                
                foreach (Question q in td.Questions)
                {
                    foreach (Result r in q.Results)
                    {
                        if (!uids.Contains(r.UserID))
                        {
                            uids.Add(r.UserID);
                            
                        }
                    }
                }

                int c = 0;
                int tot = 0;
                ArrayList times = new ArrayList();

                ArrayList endtimes = new ArrayList();
                ArrayList users = new ArrayList();

                foreach (User u in eval.Users)
                {
                    if (!uids.Contains(u.ID)) continue;

                    users.Add(u);

                    int time = u.End - u.Start;

                    if (u.End != 0) endtimes.Add(u.End);

                    if (u.Start > u.End) continue;

                    if (time == 0) continue;

                    c++;
                    tot += time;

                    times.Add(time);
                }


                times.Sort();
                sr.WriteLine("Anzahl Benutzer: " + uids.Count);

                if (type.Equals("splithalf"))
                {
                    sr.WriteLine();

                    if (c > 0) sr.WriteLine("Durchschnittliche Ausfüllzeit in Sekunden: " + (tot / c) + " (= " + ((tot / c) / 60) + " Minuten)");
                    if (times.Count > 1) sr.WriteLine("Median der Ausfüllzeit in Sekunden: " + times[times.Count / 2] + " (= " + (((int)(times[times.Count / 2])) / 60) + " Minuten)");
                    //eval.Users[0].


                    sr.WriteLine();
                    sr.WriteLine("Ausfülldauer nach Benutzergruppe (in Minuten)");
                    sr.WriteLine("Mittel\tMedian\tBenutzergruppe\tEinzelwerte");

                    foreach (Person p in eval.Persons)
                    {
                        int uc = 0;
                        int utot = 0;
                        ArrayList utimes = new ArrayList();

                        foreach (User u in eval.Users)
                        {
                            if (!uids.Contains(u.ID)) continue;

                            if (u.PersonID != p.ID) continue;

                            int utime = u.End - u.Start;

                            if (u.Start > u.End) continue;

                            if (utime == 0) continue;

                            uc++;
                            utot += utime;

                            utimes.Add(utime);
                        }

                        utimes.Sort();

                        if (uc > 0) sr.Write("" + ((utot / uc) / 60));
                        else sr.Write("-");

                        sr.Write("\t");

                        if (utimes.Count > 1) sr.Write("" + (((int)(utimes[utimes.Count / 2])) / 60));
                        else sr.Write("-");

                        sr.Write("\t");
                        sr.WriteLine(p.Name);

                        sr.Write("\t(");
                        foreach (int tt in utimes)
                            sr.Write( (tt/60) + ",");
                        sr.WriteLine(")");
                    }


                    sr.WriteLine();
                    sr.WriteLine("Ausfülldauer pro Benutzer (kommagetrennte liste)");

                    foreach (int utt in times)
                        sr.Write( (utt/60) + ",");


                    sr.WriteLine();

                    sr.WriteLine();
                    sr.WriteLine();
                    sr.WriteLine("Split Half reliability");

                    endtimes.Sort();

                    ArrayList h1 = new ArrayList();
                    ArrayList h2 = new ArrayList();

                    ArrayList e1 = new ArrayList();
                    ArrayList e2 = new ArrayList();

                    for (int i = 0; i < endtimes.Count; i++)
                    {
                        if (i < endtimes.Count / 2) e1.Add(endtimes[i]);
                        else e2.Add(endtimes[i]);
                    }

                    foreach (User u in users)
                    {
                        if (e1.Contains(u.End)) h1.Add(u.ID);
                        else if (e2.Contains(u.End)) h2.Add(u.ID);
                    }

                    //sr.WriteLine("h1:" + h1.Count + "\th2:" + h2.Count);

                    foreach (Question q in td.Questions)
                    {
                        float r1 = 0;
                        float c1 = 0;
                        float r2 = 0;
                        float c2 = 0;


                        foreach (Result r in q.Results)
                        {
                            if (h1.Contains(r.UserID))
                            {
                                r1 += r.SelectedAnswer;
                                c1++;
                            }
                            else if (h2.Contains(r.UserID))
                            {
                                r2 += r.SelectedAnswer;
                                c2++;
                            }
                        }

                        sr.WriteLine(q.SID + "\t1:" + Math.Round((r1 / c1) + 1, 3) + "\t2:" + Math.Round((r2 / c2) + 1, 3));
                    }

                }
                
                if (type.Equals("vert"))
                {
                    sr.WriteLine();
                    sr.WriteLine("Ausfüllquote");
                    
                    
                    for (int j = 10; j <= td.Questions.Length; j++)
                    {
                        if (j % 10 == 0 || j == (td.Questions.Length))
                        {
                            int cusers = 0;
                            foreach (User u in users)
                            {
                                int fill = 0;

                                foreach (Question q in td.Questions)
                                {
                                    foreach (Result r in q.Results)
                                    {
                                        if (r.UserID == u.ID) fill++;
                                    }
                                }

                                if (fill > (j - 10) && fill <= j) cusers++;
                            }
                            sr.WriteLine((j - 10) + "-" + j + ":\t" + cusers + "\t (="+  Math.Round( ( ((float)cusers)/((float)users.Count) ) * 100,2) +"%)");
                        }
                    }
                    
                }
            }

            
            sr.Close();
        }
    }
}
