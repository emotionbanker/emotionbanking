using System;
using System.Windows.Forms;


namespace Compucare.Enquire.System
{
	/// <summary>
	/// Summary description for InfoBox.
	/// </summary>
	public class InfoBox
	{
		public InfoBox()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void Show(string head, string text)
		{
			/*
			InformationBox ib = new InformationBox();
			ib.Header = head;
			ib.Message = text;
			ib.ShowDialog();
			*/

			MessageBox.Show(text, head, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
