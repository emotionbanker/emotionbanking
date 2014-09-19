using System;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// Summary description for MathTools.
	/// </summary>
	public class MathTools
	{
		public MathTools()
		{
		}

		public static int Fact(int var)
		{
			if (var == 0)
				return var;
			else
				return var + Fact(var - 1);
		}
	}
}
