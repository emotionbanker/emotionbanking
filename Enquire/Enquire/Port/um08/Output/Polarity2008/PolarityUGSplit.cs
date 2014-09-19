using System;
using System.Drawing;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output.Polarity2008
{
    [Serializable]
    public class PolarityUGSplit
    {
        public PersonSetting person;
        
        public Question split;
        public int splitID;

        public string Name;

        public int GroupID;

        public Color Col1;
        public Color Col2;

        //TODO: add line type
        //TODO: add line width

        public PolarityUGSplit(PersonSetting person)
        {
            if (person == null) Set(null, null, "", 0);
            else Set(person, null, person.Short, 0);
        }

        //TODO: add custom (de)serialisation

        private void Set(PersonSetting person, Question split, string Name, int GroupID)
        {
            this.person = person;
            this.split = split;
            this.Name = Name;
            this.GroupID = GroupID;
        }

        public PolarityUGSplit Clone()
        {
            return (PolarityUGSplit)this.MemberwiseClone();
        }
    }
}
