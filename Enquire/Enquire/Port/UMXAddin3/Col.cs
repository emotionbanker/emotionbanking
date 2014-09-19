using System;

namespace Compucare.Enquire.Legacy.UMXAddin3
{
    public class Col
    {
        public Table.ColTypes Type;
        public int ASel;

        public int CrossQ;
        public int CrossA;

        public Col(string s)
        {
            string[] dat = s.Split(new char[] { '|' });
            switch (dat[0])
            {
                case "Leer": Type = Table.ColTypes.Leer; break;
                case "Mittelwert": Type = Table.ColTypes.Mittelwert; break;
                case "Median": Type = Table.ColTypes.Median; break;
                case "Prozent": Type = Table.ColTypes.Prozent; break;
                case "Gap": Type = Table.ColTypes.Gap; break;
                case "ProzentNachAntwort": Type = Table.ColTypes.ProzentNachAntwort; break;
                case "Fragentext": Type = Table.ColTypes.Fragentext; break;
                case "Ampel": Type = Table.ColTypes.Ampel; break;
                case "Prozentbalken": Type = Table.ColTypes.Prozentbalken; break;
            }

            ASel = Int32.Parse(dat[1]);
            CrossQ = Int32.Parse(dat[2]);
            CrossA = Int32.Parse(dat[3]);
        }

        public Col()
        {
            Type = Table.ColTypes.Leer;
            ASel = -1;

            CrossQ = -1;
            CrossA = -1;
        }

        public override string ToString()
        {
            return Type + "|" + ASel + "|" + CrossQ + "|" + CrossA;
        }
    }
}
