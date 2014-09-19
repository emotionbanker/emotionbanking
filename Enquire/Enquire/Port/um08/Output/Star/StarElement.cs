using System;
using System.Drawing;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output.Star
{
    [Serializable]
    public class StarElement
    {
        public int Axis;
        public Color ElementColor;

        public Question q;
        public PersonSetting p;

        public StarElement()
        {
            Axis = 1;
            ElementColor = Color.Blue;
            q = null;
            p = null;
        }
    }
}
