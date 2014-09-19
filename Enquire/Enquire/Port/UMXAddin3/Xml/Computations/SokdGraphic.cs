using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Xml;
using MySQLDriverCS;
using Compucare.Enquire.Common.Calculation.Texts.Sokd;
using Compucare.Enquire.Legacy.Umfrage2Lib;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml.Computations
{
    public class SokdGraphic: IXmlGraphic
    {
        private readonly Evaluation _eval;
        private readonly XmlDocument _doc;
        private MySQLConnection database;
        private Datenbank _db;
        private MySQLCommand cmd;
        private MySQLDataReader d;
        private string sqlResult1 = "";
        private string sql = "";
        private int counter;
        private int temp;
        public Size Size { get; set; }
        private Dictionary <string,string> map;
        private bool Combi;
        private QuestionCombo qCombo;
        private int CombiSumme = 0;
        private int CombiCounter = 0;
        private TargetData targetData;
        private double[] endsummen;
        private int endsummencounter = 0;
        private double[] endsummen2;
        private int endsummencounter2 = 0;
        private bool Abweichung;


        public SokdGraphic(Evaluation eval, XmlDocument doc)
        {
            _eval = eval;
            _doc = doc;
            this.map = new Dictionary<string,string>();
        }

        public string Store()
        {
            int EndCounter = 0;
            int EndSumme = 0;
            System.Threading.Thread.Sleep(500);
            SokdValues _val2 = XmlHelper.GetXml(_doc.DocumentElement, "Value", _eval);

            double result = 0.0;

            

            try
            {
                //_db = new Datenbank();
                database = new MySQLConnection(new MySQLConnectionString("95.129.200.5", "bankdesje_db", "bankdesje_sql", "cNcPjCYFzzKJ9").AsString);
                database.Open();

                if (_val2.getFrage() <= -100 && _val2.getFrage() > -5000 && _val2.getFrage() != 0)
                {
                    Combi = true;
                    qCombo = _eval.Global.GetCombo(_val2.getFrage(), _eval);

                }
                else
                {
                    Combi = false;
                    qCombo = null;
                }
                double wert1, wert2;
                if (_val2.getIsPercent() == false)  // Mittelwert Abweichung
                {
                    if (Combi)
                    {
                        double returnValue = 0.0;
                        double returnValue2 = 0.0;
                        foreach (Int32 id in qCombo.QuestionList)
                        {
                            _val2.setFrage(id);
                            if (_val2.getJahr() <= 2012)
                            {
                                returnValue += getValue2011_2012(_val2);
                            }
                            else
                            {
                                if (_val2.getBlz() == 99999 || _val2.getBlz() == 99998)
                                {
                                    getGesamt2012Greater(_val2, _val2.getBlz(), _val2.getJahr(), ref  CombiCounter, ref  CombiSumme);
                                }
                                else
                                {
                                    returnValue += getValue2012Greater(_val2, _val2.getJahr(), false);
                                }
                                
                            }
                        }
                        returnValue = (double)CombiSumme / CombiCounter;
                        returnValue += 1;
                        CombiCounter = CombiSumme = 0;
                        returnValue = Math.Round(returnValue, 1);


                        foreach (Int32 id in qCombo.QuestionList)
                        {
                            _val2.setFrage(id);
                            if (_val2.getJahr2() <= 2012)
                            {
                                returnValue2 += getValue2011_2012(_val2);
                            }
                            else
                            {

                                if (_val2.getBlz2() == 99999 || _val2.getBlz2() == 99998)
                                {
                                    getGesamt2012Greater(_val2, _val2.getBlz2(), _val2.getJahr2(), ref  CombiCounter, ref  CombiSumme);
                                }
                                else
                                {
                                    returnValue2 += getValue2012Greater(_val2, _val2.getJahr2(), true);
                                }
                            }
                        }
                        returnValue2 = (double)CombiSumme / CombiCounter;
                        returnValue2 += 1;
                        CombiCounter = CombiSumme = 0;
                        returnValue2 = Math.Round(returnValue2, 1);

                        result = returnValue2 - returnValue;
                        result = Math.Round(result, 2);
                    }
                    else
                    {
                        if (_val2.getJahr() <= 2012)
                        {
                            if (_val2.getBlz() == 99999 || _val2.getBlz() == 99998)
                            {
                                wert1 = getOSV2011_2012(_val2, _val2.getJahr());
                            }
                            else
                            {
                                wert1 = getValue2011_2012(_val2);
                            }
                        }
                        else
                        {
                            if (_val2.getBlz() == 99999 || _val2.getBlz() == 99998)
                            {
                                getGesamt2012Greater(_val2, _val2.getBlz(), _val2.getJahr(), ref  CombiCounter, ref  CombiSumme);
                                wert1 = (double)CombiSumme / CombiCounter;
                                wert1 += 1;
                            }
                            else
                            {
                                wert1 = getValue2012Greater(_val2, _val2.getJahr(), false);
                            }
                            
                        }


                        CombiCounter = CombiSumme = 0;
                        if (_val2.getJahr2() <= 2012)
                        {
                            if (_val2.getBlz2() == 99999 || _val2.getBlz2() == 99998)
                            {
                                wert2 = getOSV2011_2012(_val2, _val2.getJahr2());
                            }
                            else
                            {
                                wert2 = getValue2011_2012(_val2);
                            }
                        }
                        else
                        {
                            if (_val2.getBlz2() == 99999 || _val2.getBlz2() == 99998)
                            {
                                getGesamt2012Greater(_val2, _val2.getBlz2(), _val2.getJahr2(), ref  CombiCounter, ref  CombiSumme);
                                wert2 = (double)CombiSumme / CombiCounter;
                                wert2 += 1;
                            }
                            else
                            {
                                wert2 = getValue2012Greater(_val2, _val2.getJahr2(), true);
                            }
                            
                        }

                        wert1 = Math.Round(wert1, 1);
                        wert2 = Math.Round(wert2, 1);
                        result = wert2 - wert1;
                        result = Math.Round(result, 1);
                    }
                }
                else
                {

                    Abweichung = false;
                    if (Combi)
                    {

                        endsummen = new double[qCombo.QuestionList.Length];
                        endsummen2 = new double[qCombo.QuestionList.Length];
                        double returnValue = 0.0;
                        double returnValue2 = 0.0;
                        foreach (Int32 id in qCombo.QuestionList)
                        {
                            _val2.setFrage(id);
                            if (_val2.getJahr() <= 2012)
                            {
                                returnValue += getPercentValue2011_2012(_val2);
                            }
                            else
                            {

                                if (_val2.getBlz() == 99999 || _val2.getBlz() == 99998)
                                {
                                    getPercentGesamt2012Greater(_val2, _val2.getBlz(), _val2.getJahr(), ref CombiCounter, ref CombiSumme, ref EndCounter, ref EndSumme);

                                }
                                else
                                {
                                    returnValue += getPercentValue2012Greater(_val2, _val2.getJahr(), false);
                                }
                            }
                        }
                        if (qCombo.Type == 2)
                        {
                            if (_val2.getBlz() == 99999 || _val2.getBlz() == 99998)
                            {
                                double x = (double)100 / EndCounter * EndSumme;
                                x = Math.Round(x, 1);
                                returnValue = x;
                            }
                            else
                            {
                                double summe = 0.0;
                                for (int i = 0; i < endsummen.Length; i++)
                                {
                                    summe += endsummen[i];
                                }
                                summe = Math.Round(summe, 1);
                                returnValue = summe;
                            } 
                        }
                        else
                        {
                            returnValue = (double)100 / CombiCounter * CombiSumme;
                            returnValue = Math.Round(returnValue, 1);
                        }
                        //MessageBox.Show("returnValue: " + returnValue);
                        CombiSumme = CombiCounter = EndCounter = EndSumme;
                        Abweichung = true;
                        foreach (Int32 id in qCombo.QuestionList)
                        {
                            _val2.setFrage(id);

                            if (_val2.getJahr2() <= 2012)
                            {
                                returnValue2 += getPercentValue2011_2012(_val2);
                            }
                            else
                            {
                                if (_val2.getBlz2() == 99999 || _val2.getBlz2() == 99998)
                                {
                                    getPercentGesamt2012Greater(_val2, _val2.getBlz2(), _val2.getJahr2(), ref CombiCounter, ref CombiSumme, ref EndCounter, ref EndSumme);
                                }
                                else
                                {
                                    returnValue2 += getPercentValue2012Greater(_val2, _val2.getJahr2(), true);
                                }

                            }
                        }

                        if (qCombo.Type == 2)
                        {
                            if (_val2.getBlz() == 99999 || _val2.getBlz() == 99998)
                            {
                                double x = (double)100 / EndCounter * EndSumme;
                                x = Math.Round(x, 1);
                                returnValue2 = x;
                            }
                            else
                            {
                                double summe = 0;
                                for (int i = 0; i < endsummen2.Length; i++)
                                {
                                    summe += endsummen2[i];
                                }
                                summe = Math.Round(summe, 1);
                                returnValue2 = summe;
                            }
                        }
                        else
                        {

                            returnValue2 = (double)100 / CombiCounter * CombiSumme;
                            returnValue2 = Math.Round(returnValue2, 2);
                        }
               
                        CombiSumme = CombiCounter = EndCounter = EndSumme = 0;
                        result = returnValue2 - returnValue;
                        result = Math.Round(result, 2);
                    }
                    else
                    {
                        if (_val2.getJahr() <= 2012)
                        {
                            if (_val2.getBlz() == 99999 || _val2.getBlz() == 99998)
                                wert1 = getOSVPercentValue2011_2012(_val2, _val2.getJahr());
                            else
                                wert1 = getPercentValue2011_2012(_val2);
                        }
                        else
                        {
                            if (_val2.getBlz() == 99999 || _val2.getBlz() == 99998)
                            {
                                getPercentGesamt2012Greater(_val2, _val2.getBlz(), _val2.getJahr(), ref CombiCounter, ref CombiSumme, ref EndCounter, ref EndSumme);
                                wert1 = (double)100 / CombiCounter * CombiSumme;
                            }
                            else
                            {
                                wert1 = getPercentValue2012Greater(_val2, _val2.getJahr(), false);
                            }
                        }

                        CombiCounter = CombiSumme = 0;
                        if (_val2.getJahr2() <= 2012)
                        {
                            if (_val2.getBlz2() == 99999 || _val2.getBlz2() == 99998)
                                wert2 = getOSVPercentValue2011_2012(_val2, _val2.getJahr2());
                            else
                                wert2 = getPercentValue2011_2012(_val2);
                        }
                        else
                        {
                            if (_val2.getBlz2() == 99999 || _val2.getBlz2() == 99998)
                            {
                                getPercentGesamt2012Greater(_val2, _val2.getBlz2(), _val2.getJahr2(), ref CombiCounter, ref CombiSumme, ref EndCounter, ref EndSumme);
                                wert2 = (double)100 / CombiCounter * CombiSumme;
                            }
                            else
                            {
                                wert2 = getPercentValue2012Greater(_val2, _val2.getJahr2(), true);
                            }
                           
                        }


                        result = wert2 - wert1;
                        result = Math.Round(result, 2);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }

            Color c = Color.Yellow;
            float angle = 0;
            if (qCombo!=null && qCombo.Type == 2)
            {
                if (result > 10.00 && result <= 100.00)
                {
                    c = Color.Green;
                    angle = (float)-90.0;
                }
                else if (result <= 10.00 && result > 4.00)
                {
                    c = Color.YellowGreen;
                    angle = (float)-45.0;
                }
                else if (result <= 4.00 && result > -4.00)
                {
                    c = Color.Yellow;
                    angle = (float)0.0;
                }
                else if (result <= -4.00 && result > -10.00)
                {
                    c = Color.Orange;
                    angle = (float)45.0;
                }
                else
                {
                    c = Color.Red;
                    angle = (float)90.0;
                }
            }
            else
            {
                if (result >= 0.61 && result <= 4.01)
                {
                    c = Color.Red;
                    angle = (float)90.0;
                }
                else if (result < 0.60 && result >= 0.20)
                {
                    c = Color.Orange;
                    angle = (float)45.0;
                }
                else if (result < 0.20 && result >= -0.20)
                {
                    c = Color.Yellow;
                    angle = (float)0.0;
                }
                else if (result < -0.20 && result >= -0.60)
                {
                    c = Color.YellowGreen;
                    angle = (float)-45.0;
                }
                else
                {
                    c = Color.Green;
                    angle = (float)-90.0;
                }
            }//else


            try
            {
                string tempName = System.IO.Path.GetTempFileName() + ".png";
                Tools.CreateTrendArrow(c, angle, 40, 0, Color.Black).Save(tempName, ImageFormat.Png);
                return tempName;
            }
            catch
            {
                return "";
            }
          
        }//end Store


        public double getOSV2011_2012(SokdValues _val2, int jahr)
        {
            string sql1 = "";
            string sql2 = "";
            double counter = 0.0;
            double summe = 0.0;
            ArrayList blz = new ArrayList();
            try
            {

                cmd = new MySQLCommand("select blz from sokd_teilnehmer where jahr = " + jahr, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    blz.Add(d.GetInt32(0));
                }

                foreach (int b in blz)
                {
                    sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` != '999'";
                    cmd = new MySQLCommand(sql, database);
                    d = cmd.ExecuteReaderEx();
                    while (d.Read() && d != null)
                    {
                        sql2 = d.GetString(0);
                    }

                    sql = "select sum(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` != '999'";
                    cmd = new MySQLCommand(sql, database);
                    d = cmd.ExecuteReaderEx();
                    while (d.Read() && d != null)
                    {
                        sql1 = d.GetString(0);
                    }

                    counter += Convert.ToDouble(sql2);
                    summe += Convert.ToDouble(sql1);


                }

                double sqlResult = (double)summe / counter;
                sqlResult = Math.Round(sqlResult, 1);
                return sqlResult;
            }
            catch
            {
                MessageBox.Show("BLZ: " + _val2.getBlz() + " hat im Jahr " + _val2.getJahr() + " nicht teilgenommen!");
            }
            return 0.0;
        }

        public double getOSVPercentValue2011_2012(SokdValues _val2, int jahr)
        {
            string sql1 = "";
            string sql2 = "";
            double counter = 0.0;
            double counter2 = 0.0;
            ArrayList blz = new ArrayList();
            try
            {
                cmd = new MySQLCommand("select blz from sokd_teilnehmer where jahr = " + jahr, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    blz.Add(d.GetInt32(0));
                }

                foreach (int b in blz)
                {
                    sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` != '999'";
                    cmd = new MySQLCommand(sql, database);
                    d = cmd.ExecuteReaderEx();
                    while (d.Read() && d != null)
                    {
                        sql2 = d.GetString(0);
                    }
                    sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` = '" + (_val2.getSpaltenId() + 1) + "'";
                    cmd = new MySQLCommand(sql, database);
                    d = cmd.ExecuteReaderEx();
                    while (d.Read() && d != null)
                    {
                        sql1 = d.GetString(0);
                    }
                    counter += Convert.ToDouble(sql2);
                    counter2 += Convert.ToDouble(sql1);

                }
                double sqlResult = (double)100 / counter * counter2;
                sqlResult = Math.Round(sqlResult, 2);
                return sqlResult;

            }
            catch
            {
                MessageBox.Show("BLZ: " + _val2.getBlz() + " hat im Jahr " + jahr + " nicht teilgenommen!");
                return 0.00;
            }

        }

        public void getGesamt2012Greater(SokdValues _val2, int blz, int jahr, ref int counterUP, ref int summeUP)
        {
            int gesamt = 0;
            if (blz == 99999)
                gesamt = 0;
            else if (blz == 99998)
                gesamt = 1;

            ArrayList bankenliste = new ArrayList();
            try
            {
                cmd = new MySQLCommand("select blz from sokd_teilnehmer where jahr = " + jahr + " and gesamt = " + gesamt, database);
                //cmd = new MySQLCommand("select blz from sokd_teilnehmer where jahr = " + jahr, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    bankenliste.Add(d.GetInt32(0));
                }

                foreach (int b in bankenliste)
                {
                    UP1getGesamt2012Greater(_val2, jahr, ref counterUP, ref summeUP, b);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public void UP1getGesamt2012Greater(SokdValues _val2, int jahr, ref int counterUP, ref int summeUP, int b)
        {
            string sql1 = "";
            string sql2 = "";
            string bankName;
            bool rohdaten;
            bankName = getBankName(b, jahr);
            rohdaten = Rohdatenexist(b, jahr);

            if (rohdaten == true)
            {
                sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` != '999'";
                //sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` != '999' AND `" + _val2.getFrage() + "` != '6'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    sql2 = d.GetString(0);
                }

                sql = "select sum(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` != '999'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    sql1 = d.GetString(0);
                }

                counterUP += Convert.ToInt16(sql2);
                summeUP += Convert.ToInt16(sql1);
            }
            else
            {
                string[] bankenNamen = bankName.Split('*');
                for (int i = 0; i < bankenNamen.Length - 1; i++)
                {
                    sql = "select kuerzel from sokd_teilnehmer where name = '" + bankenNamen[i] + "' and jahr =" + jahr;
                    cmd = new MySQLCommand(sql, database);
                    d = cmd.ExecuteReaderEx();
                    while (d.Read() && d != null)
                    {
                        sqlResult1 = d.GetString(0);
                    }

                    sql = "select z_id from victor" + jahr + "zugangsdaten where z_b_id = '" + sqlResult1 + "' and z_p_id = '3' and status >='50'";
                    cmd = new MySQLCommand(sql, database);
                    d = cmd.ExecuteReaderEx();
                    sqlResult1 = "";
                    while (d.Read() && d != null)
                    {
                        sqlResult1 += d.GetString(0) + " ";
                    }
                    String[] fragebogenIds = sqlResult1.Split(' ');

                    for (int j = 0; j < fragebogenIds.Length - 1; j++)
                    {
                        if (!fragebogenIds[j].StartsWith(" "))
                        {
                            sql = "select a_id from victor" + jahr + "ergebnisse where e_z_id = '" + fragebogenIds[j] + "' and e_fr_id= '" + _val2.getFrage() + "'";
                            cmd = new MySQLCommand(sql, database);
                            d = cmd.ExecuteReaderEx();
                            sqlResult1 = "";
                            while (d.Read() && d != null)
                            {
                                try
                                {
                                    sqlResult1 = d.GetString(0);
                                    if (sqlResult1 != null)
                                    {
                                        if (sqlResult1.Equals("0")) { summeUP += Convert.ToInt32(sqlResult1); counterUP++; }
                                        else if (sqlResult1.Equals("1")) { summeUP += Convert.ToInt32(sqlResult1); counterUP++; }
                                        else if (sqlResult1.Equals("2")) { summeUP += Convert.ToInt32(sqlResult1); counterUP++; }
                                        else if (sqlResult1.Equals("3")) { summeUP += Convert.ToInt32(sqlResult1); counterUP++; }
                                        else if (sqlResult1.Equals("4")) { summeUP += Convert.ToInt32(sqlResult1); counterUP++; }

                                    }
                                }
                                catch { }
                            }//end while

                        }//end if
                    }
                }
            }//end else
        }

        public void getPercentGesamt2012Greater(SokdValues _val2, int blz, int jahr, ref int counterUP, ref int summeUP, ref int EndCounter2, ref int EndSumme2)
        {
            int gesamt = 0;
            if (blz == 99999)
                gesamt = 0;
            else if (blz == 99998)
                gesamt = 1;

            ArrayList bankenliste = new ArrayList();
            try
            {
                cmd = new MySQLCommand("select blz from sokd_teilnehmer where jahr = " + jahr + " and gesamt = " + gesamt, database);
                //cmd = new MySQLCommand("select blz from `sokd_teilnehmer` where `jahr` = '" + jahr + "' AND `Gesamt` = '" + Gesamt+"'", database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    bankenliste.Add(d.GetInt32(0));
                }

                foreach (int b in bankenliste)
                {
                    UP1getPercentGesamt2012Greater(_val2, jahr, ref counterUP, ref summeUP, b, ref EndCounter2, ref EndSumme2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public void UP1getPercentGesamt2012Greater(SokdValues _val2, int jahr, ref int counterUP, ref int summeUP, int b, ref int EndCounter2, ref int EndSumme2)
        {

            List<String> results = new List<string>();
            int CounterUP = 0;
            int SummeUP = 0;
            string sql1 = "";
            string sql2 = "";
            string bankName;
            bool rohdaten;
            bankName = getBankName(b, jahr);
            rohdaten = Rohdatenexist(b, jahr);

            if (rohdaten == true)
            {
                sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` != '999'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    sql2 = d.GetString(0);
                }

                sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` = '" + (_val2.getSpaltenId() + 1) + "'";
                //sql = "select sum(`" + _val2.getFrage() + "`) from `sokd_" + jahr + "` where `sokd_blz`='" + b + "' AND `" + _val2.getFrage() + "` != '999'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    sql1 = d.GetString(0);
                }
                EndCounter2 += Convert.ToInt16(sql2);
                EndSumme2 += Convert.ToInt16(sql1);

                CounterUP += Convert.ToInt16(sql2);
                SummeUP += Convert.ToInt16(sql1);
            }
            else
            {
                string[] bankenNamen = bankName.Split('*');
                for (int i = 0; i < bankenNamen.Length - 1; i++)
                {
                    sql = "select kuerzel from sokd_teilnehmer where name = '" + bankenNamen[i] + "' and jahr =" + jahr;
                    cmd = new MySQLCommand(sql, database);
                    d = cmd.ExecuteReaderEx();
                    while (d.Read() && d != null)
                    {
                        sqlResult1 = d.GetString(0);
                    }

                    sql = "select z_id from victor" + jahr + "zugangsdaten where z_b_id = '" + sqlResult1 + "' and z_p_id = '3' and status >='50'";
                    cmd = new MySQLCommand(sql, database);
                    d = cmd.ExecuteReaderEx();
                    sqlResult1 = "";
                    while (d.Read() && d != null)
                    {
                        sqlResult1 += d.GetString(0) + " ";
                    }
                    String[] fragebogenIds = sqlResult1.Split(' ');

                    for (int j = 0; j < fragebogenIds.Length - 1; j++)
                    {
                        if (!fragebogenIds[j].StartsWith(" "))
                        {
                            sql = "select a_id from victor" + jahr + "ergebnisse where e_z_id = '" + fragebogenIds[j] + "' and e_fr_id= '" + _val2.getFrage() + "'";
                            cmd = new MySQLCommand(sql, database);
                            d = cmd.ExecuteReaderEx();
                            sqlResult1 = "";
                            while (d.Read() && d != null)
                            {
                                try
                                {
                                    sqlResult1 = d.GetString(0);
                                    if (sqlResult1 != null)
                                    {
                                        if (sqlResult1.Equals(_val2.getSpaltenId().ToString())) { summeUP++; counterUP++; CombiSumme++; CombiCounter++; results.Add(sqlResult1); }
                                        else if (sqlResult1.Equals("0") || sqlResult1.Equals("1") || sqlResult1.Equals("2") || sqlResult1.Equals("3") || sqlResult1.Equals("4") || sqlResult1.Equals("5")) { counterUP++; CombiCounter++; results.Add(sqlResult1); }
                                        else { }
                                    }
                                }
                                catch { }
                            }//end while

                        }//end if
                    }
                }

                if (rohdaten == true)
                    return;

                if (qCombo != null)
                {
                    if (qCombo.Type == 2)
                    {

                        CombiSumme = CombiCounter = 0;

                        List<int> spalten = new List<int>();
                        int spaltencount = qCombo.ACombTable.Count - 1;

                        Question quel = _eval.Global.GetQuestionById(_val2.getFrage());
                        Hashtable table = new Hashtable();
                        int countm = 0;
                        foreach (string tmp in quel.AnswerList)
                        {
                            table.Add(countm, tmp);
                            countm++;
                        }

                        //MessageBox.Show(_val2.getSpaltenText().ToString());
                        foreach (DictionaryEntry de in qCombo.ACombTable)
                        {
                            if (de.Value.Equals(_val2.getSpaltenText()))
                            {
                                foreach (DictionaryEntry fe in table)
                                {
                                    if (de.Key.Equals(fe.Value))
                                    {
                                        spalten.Add(Int32.Parse(fe.Key.ToString()));
                                    }
                                }
                            }
                        }


                        double endergebnis = 0.0;
                        double x = 0.0;
                        foreach (int sp in spalten)
                        {
                            foreach (string tmp in results)
                            {
                                if (sp == Int32.Parse(tmp))
                                {
                                    CombiSumme++;
                                    EndSumme2++;
                                }

                            }
                            x = (double)100 / results.Count * CombiSumme;
                            endergebnis += x;
                            CombiSumme = 0;
                        }

                        EndCounter2 += results.Count;
                        double lo = 100 / EndCounter2 * EndSumme2;



                        if (!Abweichung)
                        {
                            endsummen[endsummencounter] = endergebnis;
                            endsummencounter++;
                        }
                        else
                        {
                            endsummen2[endsummencounter2] = endergebnis;
                            endsummencounter2++;
                        }

                        endsummencounter2 = endsummencounter = 0;

                        //return endergebnis;
                    }
                }
            }//end if
        }

        public double getPercentValue2011_2012(SokdValues _val2)
        {
            string sql1 = "";
            string sql2 = "";
            try
            {
                sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + _val2.getJahr() + "` where `sokd_blz`='" + _val2.getBlz() + "' AND `" + _val2.getFrage() + "` != '999'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    sql2 = d.GetString(0);
                }
                sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + _val2.getJahr() + "` where `sokd_blz`='" + _val2.getBlz() + "' AND `" + _val2.getFrage() + "` = '" + (_val2.getSpaltenId() + 1) + "'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    sql1 = d.GetString(0);
                }

                double sqlResult = (double)100 / Convert.ToInt32(sql2) * Convert.ToInt32(sql1);
                //MessageBox.Show(sql2 + " -- " + sql1 + " -- " + sqlResult);
                sqlResult = Math.Round(sqlResult, 2);
                return sqlResult;
            }
            catch
            {
                MessageBox.Show("BLZ: " + _val2.getBlz() + " hat im Jahr " + _val2.getJahr() + " nicht teilgenommen!");
                return 0.00;
            }
        }

        public double getPercentValue2012Greater(SokdValues _val2, int jahr, bool ok)
        {
            List<String> results = new List<string>();
            temp = 0;
            counter = 0;

            string bankName;
            bool rohdaten;
            if (ok)
            {
                bankName = getBankName(_val2.getBlz2(), jahr);
                rohdaten = Rohdatenexist(_val2.getBlz2(), jahr);
            }
            else
            {
                bankName = getBankName(_val2.getBlz(), jahr);
                rohdaten = Rohdatenexist(_val2.getBlz(), jahr);
            }


            if (rohdaten == true)
            {
                return getPercentValue2011_2012(_val2);
            }

            string[] bankenNamen = bankName.Split('*');
            //MessageBox.Show((bankenNamen[0]).ToString());
            for (int i = 0; i < bankenNamen.Length - 1; i++)
            {
                //MessageBox.Show((bankenNamen[i]).ToString());//Bank
                //bankkürzel selektieren
                sql = "select kuerzel from sokd_teilnehmer where name = '" + bankenNamen[i] + "' and jahr =" + jahr;
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    sqlResult1 = d.GetString(0);
                }
                //MessageBox.Show("kürzel: " + sqlResult1);
                //fragebogen ids selektieren welche privatkunde und status größer als 50
                sql = "select z_id from victor" + jahr + "zugangsdaten where z_b_id = '" + sqlResult1 + "' and z_p_id = '3' and status >='50'";
                //sql = "select z_id from victor" + jahr + "zugangsdaten where z_b_id = '" + sqlResult1 + "' and z_p_id = '3'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                sqlResult1 = "";
                while (d.Read() && d != null)
                {
                    sqlResult1 += d.GetString(0) + " ";
                }
                String[] fragebogenIds = sqlResult1.Split(' ');

                //MessageBox.Show("fragebogenIds: " + (fragebogenIds.Length-1));
                for (int j = 0; j < fragebogenIds.Length - 1; j++)
                {
                    if (!fragebogenIds[j].StartsWith(" "))
                    {
                        sql = "select a_id from victor" + jahr + "ergebnisse where e_z_id = '" + fragebogenIds[j] + "' and e_fr_id= '" + _val2.getFrage() + "'";
                        cmd = new MySQLCommand(sql, database);
                        d = cmd.ExecuteReaderEx();
                        sqlResult1 = "";
                        while (d.Read() && d != null)
                        {
                            try
                            {

                                sqlResult1 = d.GetString(0);
                                if (sqlResult1 != null)
                                {
                                    if (sqlResult1.Equals(_val2.getSpaltenId().ToString())) { temp++; counter++; CombiSumme++; CombiCounter++; results.Add(sqlResult1); }
                                    else if (sqlResult1.Equals("0") || sqlResult1.Equals("1") || sqlResult1.Equals("2") || sqlResult1.Equals("3") || sqlResult1.Equals("4") || sqlResult1.Equals("5")) { counter++; CombiCounter++; results.Add(sqlResult1); }
                                    else { }

                                }

                            }
                            catch { }
                        }//end while
                    }//end if
                }//end for 
            }//end 1st for 

            if (counter == 0)
            {
                counter = 1;
                return 0.0;
            }
            if (qCombo != null)
            {
                if (qCombo.Type == 2)
                {
                    CombiSumme = CombiCounter = 0;

                    List<int> spalten = new List<int>();
                    int spaltencount = qCombo.ACombTable.Count - 1;

                    Question quel = _eval.Global.GetQuestionById(_val2.getFrage());
                    Hashtable table = new Hashtable();
                    int countm = 0;
                    foreach (string tmp in quel.AnswerList)
                    {
                        table.Add(countm, tmp);
                        countm++;
                    }

                    //MessageBox.Show(_val2.getSpaltenText().ToString());
                    foreach (DictionaryEntry de in qCombo.ACombTable)
                    {
                        if (de.Value.Equals(_val2.getSpaltenText()))
                        {
                            foreach (DictionaryEntry fe in table)
                            {
                                if (de.Key.Equals(fe.Value))
                                {
                                    spalten.Add(Int32.Parse(fe.Key.ToString()));
                                }
                            }
                        }
                    }

                    double endergebnis = 0.0;
                    foreach (int sp in spalten)
                    {
                        foreach (string tmp in results)
                        {
                            if (sp == Int32.Parse(tmp))
                            {
                                CombiSumme++;
                            }

                        }
                        double x = (double)100 / results.Count * CombiSumme;
                        endergebnis += x;
                        CombiSumme = 0;
                    }

                    if (!Abweichung)
                    {
                        endsummen[endsummencounter] = endergebnis;
                        endsummencounter++;
                    }
                    else
                    {
                        endsummen2[endsummencounter2] = endergebnis;
                        endsummencounter2++;
                    }

                    endsummencounter2 = endsummencounter = 0;

                    return endergebnis;
                }
            }

            double result = (double)100 / counter * temp;
            result = Math.Round(result, 2);
            return result;

        }

        public double getValue2011_2012(SokdValues _val2)
        {
            string sql1 = "";
            string sql2 = "";
            try
            {
                //sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + _val2.getJahr() + "` where `sokd_blz`='" + _val2.getBlz() + "' AND `" + _val2.getFrage() + "` != '999' AND `" + _val2.getFrage() + "` != '6'";
                sql = "select count(`" + _val2.getFrage() + "`) from `sokd_" + _val2.getJahr() + "` where `sokd_blz`='" + _val2.getBlz() + "' AND `" + _val2.getFrage() + "` != '999'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    sql2 = d.GetString(0);
                }
                //sql = "select sum(`" + _val2.getFrage() + "`) from `sokd_" + _val2.getJahr() + "` where `sokd_blz`='" + _val2.getBlz() + "' AND `" + _val2.getFrage() + "` != '999'";
                //sql = "select sum(`" + _val2.getFrage() + "`) from `sokd_" + _val2.getJahr() + "` where `sokd_blz`='" + _val2.getBlz() + "' AND `" + _val2.getFrage() + "` != '999' AND `" + _val2.getFrage() + "` != '6'";
                sql = "select sum(`" + _val2.getFrage() + "`) from `sokd_" + _val2.getJahr() + "` where `sokd_blz`='" + _val2.getBlz() + "' AND `" + _val2.getFrage() + "` != '999'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null) { sql1 = d.GetString(0); }

                double sqlResult = (double)Convert.ToInt32(sql1) / Convert.ToInt32(sql2);
                sqlResult = Math.Round(sqlResult, 1);
                return sqlResult;
            }
            catch
            {
                MessageBox.Show("BLZ: " + _val2.getBlz() + " hat im Jahr " + _val2.getJahr() + " nicht teilgenommen!");
                return 0.00;
            }
        }//end get2011or2012Value

        public double getValue2012Greater(SokdValues _val2, int jahr, bool ok)
        {
            temp = 0;
            counter = 0;

            string bankName;
            bool rohdaten;
            if (ok)
            {
                bankName = getBankName(_val2.getBlz2(), jahr);
                rohdaten = Rohdatenexist(_val2.getBlz2(), jahr);
            }
            else
            {
                bankName = getBankName(_val2.getBlz(), jahr);
                rohdaten = Rohdatenexist(_val2.getBlz(), jahr);
            }


            if (rohdaten == true)
            {
                return getValue2011_2012(_val2);
            }


            string[] bankenNamen = bankName.Split('*');
            //MessageBox.Show((bankenNamen.Length-1).ToString());
            for (int i = 0; i < bankenNamen.Length - 1; i++)
            {
                //MessageBox.Show((bankenNamen[i]).ToString());//Bank
                //bankkürzel selektieren
                sql = "select kuerzel from sokd_teilnehmer where name = '" + bankenNamen[i] + "' and jahr =" + jahr;
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                while (d.Read() && d != null)
                {
                    sqlResult1 = d.GetString(0);
                }
                //MessageBox.Show("kürzel: " + sqlResult1);
                //fragebogen ids selektieren welche privatkunde und status größer als 50
                sql = "select z_id from victor" + jahr + "zugangsdaten where z_b_id = '" + sqlResult1 + "' and z_p_id = '3' and status >='50'";
                //sql = "select z_id from victor" + jahr + "zugangsdaten where z_b_id = '" + sqlResult1 + "' and z_p_id = '3'";
                cmd = new MySQLCommand(sql, database);
                d = cmd.ExecuteReaderEx();
                sqlResult1 = "";
                while (d.Read() && d != null)
                {
                    sqlResult1 += d.GetString(0) + " ";
                }
                String[] fragebogenIds = sqlResult1.Split(' ');

                //MessageBox.Show("fragebogenIds: " + (fragebogenIds.Length-1));
                for (int j = 0; j < fragebogenIds.Length - 1; j++)
                {
                    if (!fragebogenIds[j].StartsWith(" "))
                    {
                        sql = "select a_id from victor" + jahr + "ergebnisse where e_z_id = '" + fragebogenIds[j] + "' and e_fr_id= '" + _val2.getFrage() + "'";
                        cmd = new MySQLCommand(sql, database);
                        d = cmd.ExecuteReaderEx();
                        sqlResult1 = "";
                        while (d.Read() && d != null)
                        {
                            try
                            {
                                sqlResult1 = d.GetString(0);
                                if (sqlResult1 != null)
                                {
                                    if (sqlResult1.Equals("0")) { temp += 0; counter++; CombiSumme += 0; CombiCounter++; }
                                    else if (sqlResult1.Equals("1")) { temp += 1; counter++; CombiSumme += 1; CombiCounter++; }
                                    else if (sqlResult1.Equals("2")) { temp += 2; counter++; CombiSumme += 2; CombiCounter++; }
                                    else if (sqlResult1.Equals("3")) { temp += 3; counter++; CombiSumme += 3; CombiCounter++; }
                                    else if (sqlResult1.Equals("4")) { temp += 4; counter++; CombiSumme += 4; CombiCounter++; }

                                }
                            }
                            catch { }
                        }//end while

                    }//end if
                }//end for 
            }//end 1st for 
            if (counter == 0)
            {
                counter = 1;
            }
            double result = (double)temp / counter;
            result += 1;
            result = Math.Round(result, 1);
            return result;
        }

        public bool Rohdatenexist(int blz, int jahr)
        {
            bool rohdaten = false;
            cmd = new MySQLCommand("select rohdaten from sokd_teilnehmer where blz = " + blz + " and jahr = " + jahr, database);
            d = cmd.ExecuteReaderEx();
            while (d.Read() && d != null)
            {
                rohdaten = d.GetBoolean(0);
            }

            return rohdaten;
        }

        public string getBankName(int blz, int jahr)
        {
            string bName = "";
            cmd = new MySQLCommand("select name from sokd_teilnehmer where blz = " + blz + " and jahr = " + jahr, database);
            d = cmd.ExecuteReaderEx();
            while (d.Read() && d != null)
            {
                bName += d.GetString(0) + "*";
            }
            return bName;
        }
    }
}
