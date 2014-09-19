using System;
using System.IO;
using System.Windows.Forms;

//using MacTools;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	public delegate void ReportEventHandler();

	/// <summary>
	/// Summary description for Report.
	/// </summary>
	/// 
	[Serializable]
	public class Report
	{
		public Output.Output[] Outputs;

		public string Name;

		public Report Clone
		{
			get
			{
				Report c = new Report("Kopie von " + this.Name);

				foreach (Output.Output o in this.Outputs)
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
			Outputs = new Output.Output[0];
			this.Name = Name;

			this.OutputDataChanged+=new ReportEventHandler(Report_OutputDataChanged);
		}

		public override string ToString()
		{
			return Name;
		}


		public void AddOutput(Output.Output output)
		{
			Output.Output[] old = Outputs;

			Outputs = new Output.Output[Outputs.Length + 1];

			int i = 0;
			foreach (Output.Output o in old)
				Outputs[i++] = o;

			Outputs[i] = output;

			try{outputDataChanged();}
			catch{}
		}

		public void RemoveOutput(Output.Output output)
		{
			if (Outputs == null)
				Outputs = new Output.Output[0];

			if (Outputs.Length == 0)
				return;

			if (Outputs.Length == 1)
			{
				Outputs = new Output.Output[0];
                try { outputDataChanged(); }
                catch { }
				return;
			}

			bool found = false;
			foreach(Output.Output o in Outputs)
			{
				if (o==output)
					found = true;
			}

			if (!found)
				return;

			Output.Output[] old = Outputs;

			Outputs = new Output.Output[Outputs.Length - 1];

			int i = 0;
			foreach (Output.Output o in old)
			{
				if (o != output)
					Outputs[i++] = o;
			}

			try{outputDataChanged();}
			catch{}
		}

		public void Save(string path, bool addfolders, Label status, Evaluation oveval)
		{
			foreach (Output.Output o in Outputs)
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
