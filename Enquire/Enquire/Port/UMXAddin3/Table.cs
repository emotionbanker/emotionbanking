using System;
using System.Collections;

namespace Compucare.Enquire.Legacy.UMXAddin3
{
    public class Table
    {
        public enum ColTypes { Leer, Mittelwert, Median, Prozent, Gap, ProzentNachAntwort, Fragentext, Ampel, Prozentbalken };

        public ArrayList Questions;
        public ArrayList Items;

        public Table()
        {
            Questions = new ArrayList();
            Items = new ArrayList();
        }

        public Table(string s)
        {
            Questions = new ArrayList();
            Items = new ArrayList();

            string[] dat = s.Split(new char[] {'#'});

            string[] qs = dat[0].Split(new char[] {';'});
            string[] coltypes = dat[1].Split(new char[] {';'});

            foreach (string q in qs)
            {
                AddQuestion(Int32.Parse(q));
            }

            foreach (string c in coltypes)
            {
                Items.Add(new Col(c));
            }
        }

        public void AddQuestion(int id)
        {
            Questions.Add(id);
        }

        public void ResetQ(string list)
        {
            Questions = new ArrayList();

            foreach (string id in list.Split(new char[] {','}))
            {
                try {AddQuestion(Int32.Parse(id.Trim()));}
                catch {};
            }
        }

        public override string ToString()
        {
            string s = "";

            if (Questions.Count > 0) s += (int)Questions[0];
            for (int i = 1; i < Questions.Count; i++)
            {
                s += ";" + (int)Questions[i];
            }

            s += "#";


            if (Items.Count > 0) s += Items[0].ToString();
            for (int i = 1; i < Items.Count; i++)
            {
                s += ";" + Items[i].ToString();
            }


            return s;
        }
    }
}
