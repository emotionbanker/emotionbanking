using System;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Script
{
    public class EnquireScriptFunctionBase
    {
        private readonly Evaluation _eval;
        private readonly TargetData _td;

        public PersonSetting UserGroup { get; set; }

        public EnquireScriptFunctionBase(Evaluation eval, TargetData td)
        {
            _eval = eval;
            _td = td;
        }   

        public double Avg(double question)
        {
            return _td.GetQuestion((Int32)question, _eval).GetAverageByPersonAsMark(_eval, UserGroup);
        }
        
        public double Avg(String question)
        {
            return Avg(Question.GetIdFromSid(question));
        }



        public double Median(double question)
        {
            return _td.GetQuestion((Int32)question, _eval).GetMedianByPersonAsMark(_eval, UserGroup,10);
        }

        public double Median(String question)
        {
            return Median(Question.GetIdFromSid(question));
        }



        public double Percent(double question, double answer)
        {
            return _td.GetQuestion((Int32) question, _eval).GetAnswerPercentByPerson((Int32) answer, _eval, UserGroup);
        }

        public double Percent(String question, double answer)
        {
            return Percent(Question.GetIdFromSid(question), answer);
        }




        public double N(double question)
        {
            return _td.GetQuestion((Int32) question, _eval).NAnswersByPerson(_eval, UserGroup);
        }

        public double N(String question)
        {
            return N(Question.GetIdFromSid(question));
        }


        public double NAll(double question)
        {
            return _td.GetQuestion((Int32)question, _eval).NAnswersByPerson(_eval, UserGroup, Question.NType.All);
        }

        public double NAll(String question)
        {
            return NAll(Question.GetIdFromSid(question));
        }

        public double NEmpty(double question)
        {
            return _td.GetQuestion((Int32)question, _eval).NAnswersByPerson(_eval, UserGroup, Question.NType.Empty);
        }

        public double NEmpty(String question)
        {
            return NEmpty(Question.GetIdFromSid(question));
        }



        public double Count(double question)
        {
            return _td.GetQuestion((Int32) question, _eval).GetAnswerCount(_eval, UserGroup);
        }

        public double Count(String question)
        {
            return Count(Question.GetIdFromSid(question));
        }
    }
}
