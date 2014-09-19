using System;
using System.Runtime.Serialization;
using System.Collections;
using Compucare.Enquire.System;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// Summary description for Column.
	/// </summary>
	/// 

	public delegate void CategoryEventHandler(Category source);

	[Serializable]
	public class Column : ISerializable
	{
		public string Name;

        public string HeadTop;
        public string HeadB1;
        public string HeadB2;
        public string HeadB3;

		public float[] answerPoints;

		public float[] AnswerPoints
		{
			set
			{
				answerPoints = value;
			}
			get
			{
				if (GapOnly)
				{
					return new float[answerPoints.Length];
				}
				else
				{
					return answerPoints;
				}
			}
		}

        public double MinPointsForTarget(TargetData td, Evaluation eval)
        {
            double tot = 0;

            foreach (ColumnQuestion cq in Questions)
            {
                Question qu = td.GetQuestion(cq.QuestionID, eval);
                if (qu == null) continue;

                double v = 0;

                foreach (PersonV pv in cq.gap.Persons)
                {
                    if (qu.ContainsPerson(eval, pv.A) && qu.ContainsPerson(eval, pv.B))
                    {
                        v += MaxGapVal;
                    }
                }

                //double v = MaxGapVal * ((double)cq.gap.Persons.Count);

                if (cq.Cat != null) v *= ((double)cq.Cat.Weight);

                tot += v;
            }

            return tot;
        }

        public double MinPoints
        {
            get
            {
                double tot = 0;

                foreach (ColumnQuestion cq in Questions)
                {
                    //cq.
                    double v = MaxGapVal * ((double)cq.gap.Persons.Count);

                    if (cq.Cat != null) v *= ((double)cq.Cat.Weight);

                    tot += v;
                }

                return tot;
            }
        }

		public int MaxPoints;

		public Category[] Categories;

		public ColumnQuestion[] Questions;

		public float GapStep;

		public bool GapOnly = false;

        public double MaxGapVal = -4;

		//public ArrayList Gaps;

		[NonSerialized]
		private CategoryEventHandler categoryAdded;
		public event CategoryEventHandler CategoryAdded
		{
			add { categoryAdded+= value; }
			remove { categoryAdded-= value; }
		}

		[NonSerialized]
		private CategoryEventHandler categoryRemoved;
		public event CategoryEventHandler CategoryRemoved
		{
			add { categoryRemoved+= value; }
			remove { categoryRemoved-= value; }
		}

		public Column()
		{
			Name = "Neue Säule";
			AnswerPoints = new float[5];
			MaxPoints = 0;
			GapStep = 1f;

			Categories = new Category[0];
			Questions = new ColumnQuestion[0];

			this.CategoryAdded+=new CategoryEventHandler(Column_CategoryAdded);
			this.CategoryRemoved+=new CategoryEventHandler(Column_CategoryRemoved);

			//this.Gaps = new ArrayList();
		}


		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("Name", this.Name);
			info.AddValue("AnswerPoints", this.answerPoints);
			info.AddValue("MaxPoints", this.MaxPoints);
			info.AddValue("Categories", this.Categories);
			info.AddValue("Questions", this.Questions);
			info.AddValue("GapStep", this.GapStep);
			
			info.AddValue("GapOnly", this.GapOnly);

            info.AddValue("HeadTop", this.HeadTop);
            info.AddValue("HeadB1", this.HeadB1);
            info.AddValue("HeadB2", this.HeadB2);
            info.AddValue("HeadB3", this.HeadB3);

            info.AddValue("MaxGapVal", this.MaxGapVal);
		}

		public Column(SerializationInfo info, StreamingContext ctxt)
		{
			this.Name = info.GetString("Name");
			this.answerPoints = (float[])info.GetValue("AnswerPoints", typeof(float[]));
			this.MaxPoints = info.GetInt32("MaxPoints");
			this.Categories = (Category[])info.GetValue("Categories", typeof(Category[]));
			this.Questions = (ColumnQuestion[])info.GetValue("Questions", typeof(ColumnQuestion[]));
			this.GapStep = (float)info.GetValue("GapStep", typeof(float));

			try {this.GapOnly = info.GetBoolean("GapOnly");}
			catch{this.GapOnly = false;}

            try
            {
                HeadTop = info.GetString("HeadTop");
                HeadB1 = info.GetString("HeadB1");
                HeadB2 = info.GetString("HeadB2");
                HeadB3 = info.GetString("HeadB3");
            }
            catch
            {
                HeadTop = HeadB1 = HeadB2 = HeadB3 = string.Empty;
            }

            try
            {
                MaxGapVal = info.GetDouble("MaxGapVal");
            }
            catch
            {
                MaxGapVal = -4;
            }
		}

		public int CategoryIndex(Category cat)
		{
			int i = 0;
			foreach (Category c in Categories)
			{
				if (c == cat) return i;
				i++;
			}

			return -1;
		}

		public void AddQuestion(ColumnQuestion q)
		{
			if (Questions == null) Questions = new ColumnQuestion[0];

			ColumnQuestion[] nc = new ColumnQuestion[Questions.Length + 1];

			int i = 0;
			foreach (ColumnQuestion c in Questions)
				nc[i++] = c;

			nc[i] = q;

			Questions = nc;
		}

		public void RemoveQuestion(ColumnQuestion q)
		{
			if (Questions == null || Questions.Length == 1)
			{
				Questions = new ColumnQuestion[0];
				return;
			}

			ColumnQuestion[] nc = new ColumnQuestion[Questions.Length - 1];

			int i = 0;
			foreach (ColumnQuestion c in Questions)
				if (c != q)
					nc[i++] = c;

			Questions = nc;
		}

		public void AddCategory(Category cat)
		{
			if (Categories == null) Categories = new Category[0];

			Category[] nc = new Category[Categories.Length + 1];

			int i = 0;
			foreach (Category c in Categories)
				nc[i++] = c;

			nc[i] = cat;

			Categories = nc;

			try
			{
				categoryAdded(cat);
			}
			catch
			{
			}
		}

		public void RemoveCategory(Category cat)
		{
			if (cat != null && CatCount(cat) > 0)
			{
				if (System.Windows.Forms.MessageBox.Show(CatCount(cat) + " Fragen sind dieser Kategorie zugewiesen.\nSoll diese Kategorie wirklich gelöscht werden?", "ACHTUNG", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
					return;
				
			}
			if (Categories == null || Categories.Length == 1)
			{
				Categories = new Category[0];
				categoryRemoved(cat);
				return;
			}

			Category[] nc = new Category[Categories.Length - 1];

			int i = 0;
			foreach (Category c in Categories)
				if (c != cat)
					nc[i++] = c;

			Categories = nc;

			CleanCat(cat);
			categoryRemoved(cat);
		}

		public int CatCount(Category cat)
		{
			int count = 0;

			foreach (ColumnQuestion q in Questions)
			{
				if (q.Cat == cat)
					count++;
			}

			return count;
		}

		public void CleanCat(Category cat)
		{
			foreach (ColumnQuestion q in Questions)
			{
				if (q.Cat == cat)
					q.Cat = null;
			}
		}

		public override string ToString()
		{
			return Name;
		}

		private void Column_CategoryAdded(Category source)
		{
			// do nothing
		}

		private void Column_CategoryRemoved(Category source)
		{
			// do nothing
		}
	}
}
