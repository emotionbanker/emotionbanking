using System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	/// <summary>
	/// Summary description for Category.
	/// </summary>
	/// 
	[Serializable]
	public class Category
	{
		public string Name;

		public float Weight;
		
		public Category()
		{
			Name = "Neue Kategorie";
			Weight = 0f;
		}

		public override string ToString()
		{
			//return Weight + " (" + Name + ")";
			return Name;
		}

	}
}
