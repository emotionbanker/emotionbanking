using System;
using System.Collections.Generic;
using System.Text;
using umfrage2;

namespace UMXAddin3
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
