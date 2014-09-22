using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using MySql.Data.MySqlClient;

namespace compucare.Enquire.Legacy.Umfrage2Lib.circular
{
    public class QuestionEnrichment
    {
        private readonly MySqlConnection _connection;
        private readonly string _databasePrefix;

        private readonly string _queryQuestionnaires;

        public QuestionEnrichment(MySqlConnection connection, String databasePrefix)
        {
            _connection = connection;
            _databasePrefix = databasePrefix;

            _queryQuestionnaires = String.Format("SELECT f_id, f_klasse, f_p_id, reihenfolge from {0}fragebogen", _databasePrefix);
        }

        public void EnrichQuestionTexts(Evaluation eval, TargetData td)
        {
            //get questionnaire info
            QuestionnaireInfos infos = new QuestionnaireInfos();

            MySqlCommand command = new MySqlCommand(_queryQuestionnaires, _connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                QuestionnaireInfo info = new QuestionnaireInfo
                        {
                            Identifier = reader.GetInt32(0),
                            Class = reader.GetString(1),
                            PersonId = reader.GetInt32(2),
                            Code = reader.GetString(3)
                        };
                info.ComputeAlii();
                infos.Add(info);
            }
            
            //store alternative pointer for each question, for each result
            foreach (Question q in td.Questions)
            {
                foreach (Result r in q.Results)
                {
                    User user = eval.Users.Where(u => u.ID == r.UserID).FirstOrDefault();

                    if (user == null) continue;

                    QuestionnaireInfo info = infos.GetByUserData(user.PersonID, td.Class);

                    /*
                    String debugString = "pid: " + user.PersonID + " bank: " + td.Class;
                    debugString += "\n";

                    foreach (QuestionnaireInfo ai in infos)
                    {
                        debugString += "_pid: " + ai.PersonId + " bank:" + ai.Class;
                    }
                     */

                    if (info == null) continue;

                    r.AliasId = info.GetAliasId(q.ID);
                }
            }


            //make question .Text property, auto-return highest ranked alternative text
        }

        

        public static String GetAlias(Question q)
        {
            try
            {
                Dictionary<Int32, Int32> allDict = new Dictionary<int, int>();

                foreach (Result r in q.Results)
                {
                    if (allDict.ContainsKey(r.AliasId))
                        allDict[r.AliasId] = allDict[r.AliasId] + 1;
                    else allDict.Add(r.AliasId, 1);
                }
                int topAlias = -1;
                int top = 0;
                foreach (int key in allDict.Keys)
                {
                    if (allDict[key] > top)
                    {
                        top = allDict[key];
                        topAlias = key;
                    }
                }

                if (topAlias == -1 || !q.TextAlii.ContainsKey(topAlias)) return q.DefaultText;

                return (String) q.TextAlii[topAlias];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message + "?" + (q.TextAlii == null));
            }
            return "";
        }
    }

    public class QuestionnaireInfo
    {
        public Int32 Identifier { get; set; }
        public String Class { get; set; }
        public Int32 PersonId { get; set; }
        public String Code { get; set; }

        private Dictionary<Int32, Int32> _aliasList; 

        public void ComputeAlii()
        {
            _aliasList = new Dictionary<int, int>();
            List<String> qCommandList = new List<string>();

            foreach (String baseCommandRaw in Code.Split(';'))
            {
                String baseCommand = baseCommandRaw.Trim();
                //String baseCommand = baseCommandRaw;
                if (baseCommand.StartsWith("w"))
                {
                    //sub: wenn(condition)(command)
                    int start = baseCommand.LastIndexOf("(") + 1;
                    int end = baseCommand.LastIndexOf(")");
                    int len = end - start;

                    String cmdString = baseCommand.Substring(start, len);

                    foreach (String sRaw in cmdString.Split(','))
                    {
                        String s = sRaw.Trim();
                        if (s.StartsWith("L") || s.StartsWith("N") || s.StartsWith("H"))
                        {
                            s = s.Substring(1);
                        }
                        if (!s.StartsWith("w") && !s.StartsWith("#") && !s.StartsWith("@"))
                        {
                            qCommandList.Add(s);
                        }
                    }
                }
                else if (!baseCommand.StartsWith("#") && !baseCommand.StartsWith("@"))
                {
                    if (baseCommand.StartsWith("L") || baseCommand.StartsWith("N") || baseCommand.StartsWith("H"))
                    {
                        qCommandList.Add(baseCommand.Substring(1)); 
                    }
                    else
                    {
                        qCommandList.Add(baseCommand);                        
                    }
                }
            }

            foreach (String qCommand in qCommandList)
            {
                
                if (qCommand.Contains("/"))
                {
                    String[] alias = qCommand.Split('/');
                    String aString = alias[1];
                    try
                    {
                        if (aString.Contains("!"))
                        {
                            aString = aString.Split('!')[0];
                        }

                        _aliasList.Add(Int32.Parse(alias[0]), Int32.Parse(aString));

                    }
                    catch (Exception ex)
                    {
                        Exception myEx = new Exception("Failed on parsing '"+qCommand+"':'"+aString+"'\r\n\r\nCode:\r\n\r\n" + Code, ex);
                        throw myEx;
                    }
                }
            }
        }

        public Int32 GetAliasId(Int32 qid)
        {
            if (_aliasList.ContainsKey(qid))
            {
                return _aliasList[qid];
            }
            return -1;
        }
    }

    public class QuestionnaireInfos :ICollection<QuestionnaireInfo>
    {
        private readonly List<QuestionnaireInfo> _list;

        public QuestionnaireInfos()
        {
            _list = new List<QuestionnaireInfo>();
        }

        public QuestionnaireInfo GetByUserData(Int32 personId, String bankClass)
        {
            return _list.FirstOrDefault(info => info.Class == bankClass && info.PersonId == personId);
        }

        public IEnumerator<QuestionnaireInfo> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(QuestionnaireInfo item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(QuestionnaireInfo item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(QuestionnaireInfo[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(QuestionnaireInfo item)
        {
            return _list.Remove(item);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
    }
}
