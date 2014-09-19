using System;
using System.Drawing;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output.DNCGeneric
{
    [Serializable]
    public class DNCElement
    {
        public enum DNCElementType { Mittelwert };
        
        public Question q;
        public DNCElementType Type;
        public Color ElementColor;

        public DNCElement()
        {
            q = null;
            Type = DNCElementType.Mittelwert;
        }
    }
}
