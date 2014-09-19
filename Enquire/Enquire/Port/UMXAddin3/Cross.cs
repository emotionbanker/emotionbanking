using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3
{
    class Cross
    {
        public Question q;
        public int a;

        public Cross()
        {
            q = null;
            a = -1;
        }

        public override string ToString()
        {
            return q.SID;
        }
    }
}
