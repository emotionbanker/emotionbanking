using System;
using System.Collections;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// Zusammenfassung für Gap.
	/// </summary>
	/// 

	[Serializable]
	public class PersonV
	{
		public Person A;
		public Person B;

		public PersonV()
		{
		}

		public override string ToString()
		{
			return A.Name +";" + B.Name;
		}

	}

	[Serializable]
	public class Gap
	{
		public ColumnQuestion q;

		public ArrayList Persons;

		public float Limit;
	
		public Gap()
		{
			Persons = new ArrayList();
		}

		public Gap(ColumnQuestion q)
		{
			this.q = q;
			Persons = new ArrayList();
		}

		public void AddPersons(Person A, Person B)
		{
			PersonV n = new PersonV();

			n.A = A;
			n.B = B;

			Persons.Add(n);
		}

		public void RemovePersons(PersonV v)
		{
			Persons.Remove(v);
		}

		public void RemovePersons(Person A, Person B)
		{
			PersonV n = new PersonV();

			n.A = A;
			n.B = B;

			int i = 0;
			foreach (PersonV o in Persons)
			{
				if ( (o.A == A && o.B == B) || (o.A == B && o.B == A) )
					break;

				i++;
			}
			
			if (i < Persons.Count)
				Persons.RemoveAt(i);
		}

		public float GetGap(PersonV v, Question qu, Evaluation eval)
		{
			float a = qu.GetAverageByPersonAsMark(eval, v.A.ID);
			float b = qu.GetAverageByPersonAsMark(eval, v.B.ID);

			if (a == -1 || b == -1) return 0;

			float gap = Math.Abs(a-b);

			if (gap >= this.Limit && this.Limit > 0)
			{
				return gap/this.Limit;
			}
			else return 0;
		}

		public float GetGapAbs(PersonV v, Question qu, Evaluation eval)
		{
			float a = qu.GetAverageByPersonAsMark(eval, v.A.ID);
			float b = qu.GetAverageByPersonAsMark(eval, v.B.ID);

			if (a == -1 || b == -1) return 0;

			return Math.Abs(a-b);
		}


		public float GetPenalty(float gap)
		{
			return gap * this.q.Weight;
		}

		public float GetPenalty(PersonV v, Question qu, Evaluation eval)
		{
			return GetGap(v,qu,eval) * this.q.Weight;
		}
	}
}
