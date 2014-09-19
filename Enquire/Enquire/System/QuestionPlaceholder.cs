using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Compucare.Enquire.System
{
    [Serializable]
    public class QuestionPlaceholder : ISerializable
    {
        public int QuestionID
        {
            get { return _qID; }
            set { _qID = value; }
        }

        public int PID;

        public string Text;

        private int _qID;

        public string[] AnswerList;

        public QuestionPlaceholder()
        {
            QuestionID = -1;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("_qID", _qID);
			info.AddValue("PID", PID);
            info.AddValue("Text", Text);
		}

        public QuestionPlaceholder(SerializationInfo info, StreamingContext ctxt)
		{
            this._qID = info.GetInt32("_qID");
            this.PID = info.GetInt32("PID");
            this.Text = info.GetString("Text");
		}

        public Question GetQuestion(TargetData td, Evaluation eval)
        {
            Question q = td.GetQuestion(QuestionID, eval);

            if (q == null) return q;

            q = q.Clone;

            q.ID = -100000 - PID;
            q.Text = String.Format("{0} ({1})", Text, q.Text);

            //channel answers

            this.AnswerList = q.AnswerList;

            string NewAnswers = "Antwort 0";
            for (int i = 1; i < 100; i++)
                NewAnswers += ";Antwort " + i;

            q.Answers = NewAnswers;

            return q;
        }

        public string getOriginalAnswer(int i)
        {
            return AnswerList[i];
        }

        public override string ToString()
        {
            return String.Format("P{0} ({1}) ({2})", PID, Text, QuestionID);
        }
    }
}
