using System;
using System.IO;
using System.Windows.Forms;
using MacTools;

namespace Compucare.Enquire.System
{
	public delegate void ReportEventHandler();

	/// <summary>
	/// Summary description for Report.
	/// </summary>
	/// 
	[Serializable]
	public class Report
	{
		public Output[] Outputs;

		public string Name;

		public Report Clone
		{
			get
			{
				Report c = new Report("Kopie von " + this.Name);

				foreach (Output o in this.Outputs)
					c.AddOutput(o.Clone);

				return c;
			}
		}

		[NonSerialized]
		private ReportEventHandler outputDataChanged;
		public event ReportEventHandler OutputDataChanged
		{
			add { outputDataChanged+= value; }
			remove { outputDataChanged-= value; }
		}

		public Report(string Name)
		{
			Outputs = new Output[0];
			this.Name = Name;

			this.OutputDataChanged+=new ReportEventHandler(Report_OutputDataChanged);
		}

		public override string ToString()
		{
			return Name;
		}


		public void AddOutput(Output output)
		{
			Output[] old = Outputs;

			Outputs = new Output[Outputs.Length + 1];

			int i = 0;
			foreach (Output o in old)
				Outputs[i++] = o;

			Outputs[i] = output;

			try{outputDataChanged();}
			catch{}
		}

		public void RemoveOutput(Output output)
		{
			if (Outputs == null)
				Outputs = new Output[0];

			if (Outputs.Length == 0)
				return;

			if (Outputs.Length == 1)
			{
				Outputs = new Output[0];
                try { outputDataChanged(); }
                catch { }
				return;
			}

			bool found = false;
			foreach(Output o in Outputs)
			{
				if (o==output)
					found = true;
			}

			if (!found)
				return;

			Output[] old = Outputs;

			Outputs = new Output[Outputs.Length - 1];

			int i = 0;
			foreach (Output o in old)
			{
				if (o != output)
					Outputs[i++] = o;
			}

			try{outputDataChanged();}
			catch{}
		}

		public void Save(string path, bool addfolders, MacStatusBar bar, Label status, Evaluation oveval)
		{
			bar.Min = 0;
			bar.Max = Outputs.Length;

			foreach (Output o in Outputs)
			{
				o.OvEval = oveval;

				status.Text = "Werte aus: " + o.Name;
				status.Refresh();
				if (addfolders)
				{
					Directory.CreateDirectory(path + "\\" + o.Name);
					o.Save(o.Name, path + "\\" + o.Name);
				}
				else
				{
					o.Save(o.Name, path);
				}

				bar.Value++;
				bar.Refresh();
				o.OvEval = null;
			}

			GC.Collect();
		}

		private void Report_OutputDataChanged()
		{
			//do nothing
		}
	}
}
