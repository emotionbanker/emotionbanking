using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class MatrixCrossing : IXmlText
    {
        private readonly XmlDocument _doc;
        private readonly TargetData _td;
        private readonly Evaluation _eval;

        public MatrixCrossing(XmlDocument doc, TargetData td, Evaluation eval)
        {
            _doc = doc;
            _td = td;
            _eval = eval;
        }

        public string Compute()
        {
            QuestionDataItem horizontal = XmlHelper.GetQuestion(_doc.DocumentElement, "Horizontal", _eval);
            QuestionDataItem vertical = XmlHelper.GetQuestion(_doc.DocumentElement, "Vertical", _eval);
            int factor = Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement, "Factor"));
            int x = Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement, "ValueItemX"));
            int y = Int32.Parse(XmlHelper.GetInnerText(_doc.DocumentElement, "ValueItemY"));

            Compute07(horizontal, vertical);

            if (factor == 2)
            {
                return _resultArray8[1-x, y].ToString();
            }
            if (factor == 3)
            {
                return _resultArray[2-x, y].ToString();
            }
            if (factor == 5)
            {
                return _resultArray25[4-x, y].ToString();
            }

            return "n.A.";
        }

        private readonly double[,] _resultArray = new double[3, 3];
        private readonly double[,] _resultArray25 = new double[5, 5];
        private readonly double[,] _resultArray8 = new double[2, 2];

        public void Compute07(QuestionDataItem horizontal, QuestionDataItem vertical)
        {
            Question h = _td.GetQuestion(horizontal.QuestionId, _eval);
            Question v = _td.GetQuestion(vertical.QuestionId, _eval);

            List<PersonSetting> personSettings = new List<PersonSetting>();
            personSettings.AddRange(horizontal.Persons);
            personSettings.AddRange(vertical.Persons);

            #region compute07)));

            for (int ri = 0; ri < 3; ri++)
                for (int ro = 0; ro < 3; ro++)
                    _resultArray[ri, ro] = 0d;

            for (int ri = 0; ri < 2; ri++)
                for (int ro = 0; ro < 2; ro++)
                    _resultArray8[ri, ro] = 0d;

            for (int ri = 0; ri < 5; ri++)
                for (int ro = 0; ro < 5; ro++)
                    _resultArray25[ri, ro] = 0d;

            double counter = 0;

            double highest = 0;
            double highest25 = 0;
            double highest8 = 0;

            if (h != null && v != null)
            {
                ArrayList users = new ArrayList();

                foreach (Result r in h.Results)
                {
                    if (users.Contains(r.UserID)) continue;

                    users.Add(r.UserID);

                    bool add = false;
                    int PID;

                    PID = _eval.GetPersonIdByUser(r.UserID);

                    foreach (PersonSetting ps in personSettings)
                    {
                        if (ps.ContainsID(PID)) add = true;
                    }

                    if (add)
                    {
                        int yr;

                        double cnt = 0;
                        double val = 0;

                        if (v.GetResultByUserID(r.UserID) != null)
                        {
                            foreach (Result vres in v.Results)
                            {
                                //might be a combo, get average of multiple results
                                if (vres.UserID == r.UserID)
                                {
                                    cnt++;
                                    val += vres.SelectedAnswer;
                                }
                            }
                            yr = (int)Math.Round(val / cnt, 0, MidpointRounding.AwayFromZero);
                        }
                        else
                            continue;

                        cnt = 0;
                        val = 0;

                        //average for xr
                        foreach (Result rres in h.Results)
                        {
                            //might be a combo, get average of multiple results
                            if (rres.UserID == r.UserID)
                            {
                                cnt++;
                                val += rres.SelectedAnswer;
                            }
                        }
                        int xr = (int)Math.Round(val / cnt, 0, MidpointRounding.AwayFromZero);

                        //int xr = r.SelectedAnswer;

                        if (xr > 4 || yr > 4 || xr < 0 || yr < 0) continue;
                        _resultArray25[xr, yr]++;

                        int sxr = 0, syr = 0;
                        bool ok = true;

                        if (yr == 0 || yr == 1) syr = 0;
                        else if (yr == 2 || yr == 3 || yr == 4) syr = 1;
                        else ok = false;

                        if (xr == 0 || xr == 1) sxr = 0;
                        else if (xr == 2 || xr == 3 || xr == 4) sxr = 1;
                        else ok = false;

                        if (ok) _resultArray8[sxr, syr]++;

                        if (yr == 0 || yr == 1) yr = 0;
                        else if (yr == 2) yr = 1;
                        else if (yr == 3 || yr == 4) yr = 2;
                        else continue;

                        if (xr == 0 || xr == 1) xr = 0;
                        else if (xr == 2) xr = 1;
                        else if (xr == 3 || xr == 4) xr = 2;
                        else continue;

                        _resultArray[xr, yr]++;

                        counter++;
                    }
                }


                for (int n = 0; n < 3; n++)
                {
                    for (int m = 0; m < 3; m++)
                    {
                        _resultArray[n, m] = Math.Round(((_resultArray[n, m] / counter) * 100d), 0);

                        if (_resultArray[n, m] > highest)
                            highest = _resultArray[n, m];
                    }
                }
                for (int n = 0; n < 5; n++)
                {
                    for (int m = 0; m < 5; m++)
                    {
                        _resultArray25[n, m] = Math.Round(((_resultArray25[n, m] / counter) * 100d), 0);

                        if (_resultArray25[n, m] > highest25)
                            highest25 = _resultArray25[n, m];
                    }
                }
                for (int n = 0; n < 2; n++)
                {
                    for (int m = 0; m < 2; m++)
                    {
                        _resultArray8[n, m] = Math.Round(((_resultArray8[n, m] / counter) * 100d), 0);

                        if (_resultArray8[n, m] > highest8)
                            highest8 = _resultArray8[n, m];
                    }
                }
            }

            #endregion
        }
    }
}
