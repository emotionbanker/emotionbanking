using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.SystemExtensions
{
    [Serializable]
    class TargetAndSplitQuestion
    {
        private TargetData td;
        private int id;

        public string tostring(){
            return td.name + "/" + id;
        }

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

        public void setQuestionId(int i)
        {
            this.id = i;
        }
    }
}
