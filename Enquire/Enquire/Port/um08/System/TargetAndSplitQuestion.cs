using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.System
{
    class TargetAndSplitQuestion
    {
        private TargetData td;
        private int id;

        public TargetAndSplitQuestion(TargetData targetdata, int questionId)
        {
            td = targetdata;
            id = questionId;
        }

        public TargetData getTargetData()
        {
            return this.td;
        }

        public int getQuestionId()
        {
            return this.id;
        }

        public void setTargetData(TargetData t)
        {
            this.td = t;
        }

        public void setQuestionId(int iy)
        {
            this.id = i;
        }
    }
}
