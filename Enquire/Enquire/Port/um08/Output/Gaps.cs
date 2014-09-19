using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Gaps.
	/// </summary>
	/// 

	[Serializable]
	public class GapResult
	{
		public string line;
		public float gap;

		public GapResult(string line, float GAP)
		{
			this.line = line;
			this.gap = GAP;
		}
	}

	[Serializable]
	public class Gaps : Output
	{
		[NonSerialized]
		public bool Images = false;

		public string ResultTable;

		public Question[] Questions;

		[NonSerialized]
		public ArrayList Lines;

        public int Design;

        public Gaps(Evaluation eval)
        {
            this.eval = eval;
			ResultTable = string.Empty;
			OutputImage = new Bitmap(1,1);

            this.Design = Output.Victor2006;
		}
        
        public override void LoadGlobalQ()
        {
            LoadQArray(Questions);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQArray(td, Questions);
        }

		/// <summary>
		/// serialization functions
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info, ctxt);

            Question.SetMultipartArray(Questions, Multipart);

			info.AddValue("Questions", this.Questions);
			info.AddValue("ResultTable", this.ResultTable);

            info.AddValue("Design", this.Design);

		}

		public Gaps(SerializationInfo info, StreamingContext ctxt)
		{
			base.ReadSerData(info, ctxt);

			this.Questions = (Question[])info.GetValue("Questions", typeof(Question[]));
			this.ResultTable = info.GetString("ResultTable");

            try
            {
                Design = info.GetInt32("Design");
              //  dnc = (DNCSettings)info.GetValue("dnc", typeof(DNCSettings));
            }
            catch
            {
                Design = Victor2006;
             //   dnc = new DNCSettings();
            }
		}


		public void Quicksort(int lo, int hi)
		{
			if(Lines.Count == 0)
				return;

			int i = lo, j = hi;
			float x = ((GapResult)(Lines[(lo+hi)/2])).gap;
			GapResult h;

			do
			{
			while (((GapResult)Lines[i]).gap > x) i++;
			while (((GapResult)Lines[j]).gap < x) j--;

				if (i<=j)
				{
					h = (GapResult)Lines[i];
					Lines[i] = Lines[j];
					Lines[j] = h;
					i++;
					j--;
				}
			}while (i<=j);

			if (lo<j) Quicksort(lo, j);
			if (i<hi) Quicksort(i, hi);
		}

		private void ComputeTable()
		{
			ResultTable = string.Empty;

			ResultTable = "Frage\t";

			foreach (PersonSetting ps in CombinedPersons)
			{
				ResultTable += ps.Short + "\t";
			}

			ResultTable += "GAP\r\n";

			float[] totpersons = new float[CombinedPersons.Length];
			float[] totcount = new float[CombinedPersons.Length];

			Lines = new ArrayList();

			foreach (Question q in Questions)
			{
				if (q == null) continue;

				for (int i = 0; i < CombinedPersons.Length; i++)
				{
					float a = q.GetAverageByPersonAsMark(Eval, CombinedPersons[i], 1);
					if (a != -1)
					{
						totpersons[i] += a;
						totcount[i] ++;
					}
				}
			}

			
			foreach (Question q in Questions)
			{
				if (q == null) continue;

				for (int i = 0; i < (CombinedPersons.Length-1); i++)
				{
					int j;
					for (j = (i+1); j < CombinedPersons.Length; j++)
					{
						string ResultTableLine = "";

						ResultTableLine += q.SID + "\t";
					
						for (int t = 0; t < i; t++)
							ResultTableLine += "\t";

						float a = q.GetAverageByPersonAsMark(Eval, CombinedPersons[i], 1);
						float b = q.GetAverageByPersonAsMark(Eval, CombinedPersons[j], 1);

						if (a != -1)
							ResultTableLine += a;
						else
							ResultTableLine += "-";
						
						ResultTableLine += "\t";

						for (int z = (i+1); z < j; z++)
							ResultTableLine += "\t";

						
						if (b != -1)
							ResultTableLine += b;
						else
							ResultTableLine += "-";
						
						ResultTableLine += "\t";

						for (int z = j; z < (CombinedPersons.Length-1); z++)
							ResultTableLine += "\t";

						float gap;

						if (a != -1 && b != -1)
						{
							gap = Math.Abs(a-b);
							ResultTableLine += Math.Round(Math.Abs(a-b),1).ToString();
						}
						else 
						{  
							gap = -1;
							ResultTableLine += "keine Werte";
						}

						//ResultTableLine += "\r\n";
						GapResult gr = new GapResult(ResultTableLine, gap);

						Lines.Add(gr);

						//ResultTable += ResultTableLine;
					}
				}
			}

			Quicksort(0, Lines.Count-1);

			foreach (GapResult gr in Lines)
			{
				ResultTable += gr.line + "\r\n";
			}

			for (int t = 0; t < totpersons.Length-1; t++)
			{
				for (int t2 = t+1; t2 < totpersons.Length; t2++)
				{
					ResultTable += "Gesamt\t";
					
					for (int t3 = 0; t3 < t; t3++)
						ResultTable += "\t";

					float a = (float)Math.Round(totpersons[t]/totcount[t],1);
					float b = (float)Math.Round(totpersons[t2]/totcount[t2],1);

					if (a != -1)
						ResultTable += a;
					else
						ResultTable += "-";
						
					ResultTable += "\t";

					for (int z = (t+1); z < t2; z++)
						ResultTable += "\t";

						
					if (b != -1)
						ResultTable += b;
					else
						ResultTable += "-";
						
					ResultTable += "\t";

					for (int z = t2; z < (CombinedPersons.Length-1); z++)
						ResultTable += "\t";

					if (a != -1 && b != -1)
						ResultTable += Math.Round(Math.Abs(a-b),1).ToString();
					else 
						ResultTable += "keine Werte";

					ResultTable += "\r\n";
				}
			}

			ResultTable += "\r\n";
			ResultTable += "\r\n";


			foreach (Question q in Questions)
			{
				if (q != null)
					ResultTable += q.SID + "...\t" + q.Text + "\r\n";
			}
		}

		private Bitmap GAP(PersonSetting top, PersonSetting bot, float topt, float bott)
		{
			Bitmap bmp = new Bitmap(200,160);
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.White);

			g.SmoothingMode = SmoothingMode.AntiAlias;

			
			Brush piea = new LinearGradientBrush(new RectangleF(0, 0, 200+10, 140), top.Color2, top.Color1, 0, false);
			Brush pieb = new LinearGradientBrush(new RectangleF(0, 20, 200+10, 140), bot.Color2, bot.Color1, 0, false);


			g.FillPie(piea,  0, 0, 200, 140, 180, 180);
			g.FillPie(pieb, 0, 20, 200, 140, 0, 180);

			g.FillEllipse(new SolidBrush(Color.White), 60, 40, 80, 60);
			g.FillEllipse(new SolidBrush(Color.White), 60, 60, 80, 60);

			Font gapF = new Font("Arial", 27, FontStyle.Bold, GraphicsUnit.Pixel);
			Font valF = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Pixel);

			g.DrawString("GAP", gapF, new SolidBrush(Color.Black), 135, 65);

			string gstring;
			if (topt == -1 || bott == -1)
				gstring = "?";
			else
				gstring = Math.Abs(Math.Round(topt-bott, 1)).ToString();

			g.DrawString(gstring, gapF, new SolidBrush(Color.Black), 100 - g.MeasureString(gstring, gapF).Width/2 , 65);


			string astring = top.Short;
			string bstring = bot.Short;

			string aval;
			string bval;

			if (topt != -1)
				aval = topt.ToString();
			else
				aval = "?";

			if (bott != -1)
				bval = bott.ToString();
			else
				bval = "?";

			g.DrawString(astring, valF, new SolidBrush(Color.Black), 65 - g.MeasureString(astring, valF).Width, 40);
			g.DrawString(bstring, valF, new SolidBrush(Color.Black), 65 - g.MeasureString(bstring, valF).Width, 60 + g.MeasureString(bstring, valF).Height);

			g.DrawString(aval, valF, new SolidBrush(Color.Black), 100 - g.MeasureString(aval, valF).Width/2, 7);
			g.DrawString(bval, valF, new SolidBrush(Color.Black), 100 - g.MeasureString(bval, valF).Width/2, 160 - g.MeasureString(aval, valF).Height);

			return bmp;
		}

		public void ComputeImages()
		{
			if (Questions.Length == 0 || CombinedPersons.Length <= 1)
				return;

			//Console.WriteLine(MathTools.Fact(2).ToString());
			Font f = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);

			OutputImage = new Bitmap(500, 220 * MathTools.Fact(CombinedPersons.Length-1) * (Questions.Length + 1));
			Graphics g = Graphics.FromImage(OutputImage);
			g.Clear(Color.White);

			int ypos = 0;

			foreach (Question q in Questions)
			{
				for (int i = 0; i < (CombinedPersons.Length-1); i++)
				{
					for (int j = (i+1); j < CombinedPersons.Length; j++)
					{
						string mark = GraphicTools.SplitString(eval.getTextOverload(q), 250, g, f);
						SizeF ms = g.MeasureString(mark, f);

						g.DrawString(mark, f, new SolidBrush(Color.Black), 0, ypos);

						//ypos+=20;

						Bitmap gb = GAP(CombinedPersons[i],  CombinedPersons[j], q.GetAverageByPersonAsMark(Eval, CombinedPersons[i], 1), q.GetAverageByPersonAsMark(Eval, CombinedPersons[j], 1));
						g.DrawImage(gb, 300, ypos);

						ypos += 220;
					}
				}
			}

			float[] totpersons = new float[CombinedPersons.Length];
			float[] totcount = new float[CombinedPersons.Length];

			foreach (Question q in Questions)
			{
				for (int i = 0; i < CombinedPersons.Length; i++)
				{
					float a = q.GetAverageByPersonAsMark(Eval, CombinedPersons[i], 1);
					if (a != -1)
					{
						totpersons[i] += a;
						totcount[i] ++;
					}
				}
			}

			for (int i = 0; i < totpersons.Length-1; i++)
			{
				for (int j = i+1; j < totpersons.Length; j++)
				{
					float a = (float)Math.Round(totpersons[i]/totcount[i],1);
					float b = (float)Math.Round(totpersons[j]/totcount[j],1);

					string mark = GraphicTools.SplitString("Gesamt", 180, g, f);
					SizeF ms = g.MeasureString(mark, f);

					g.DrawString(mark, f, new SolidBrush(Color.Black), 0, ypos);

					ypos+=20;

					Bitmap gb = GAP(CombinedPersons[i],  CombinedPersons[j], a, b);
					g.DrawImage(gb, 300, ypos);

					ypos += 160;
				}
			}
		}

		public override void Compute()
		{
			ComputeTable();
			if (Images)
			{
				ComputeImages();
				OutputImage = GraphicTools.ChangeTransparency(OutputImage, Color.White);
			}
		}

		public override void Save(string name, string path)
		{
			//
			Question[] baseq = Questions;
			
			//cross?
			Evaluation seval;
			if (CrossTargets(Questions))
			{
				seval = this.CrEval;
			}
			else if (this.OvEval != null)
			{
				seval = OvEval;
			}
			else
			{
				seval = this.eval;
			}
			//Targets

			string TR = string.Empty;

			foreach (TargetData td in seval.CombinedTargets)
			{
				if (!td.Included)
					continue;

				ArrayList qs = new ArrayList();

				int i = 0;
				foreach (Question q in baseq)
					if (q != null)
						qs.Add(td.GetQuestion(q, Eval));


				Questions = new Question[qs.Count];
				foreach (Question q in qs)
					Questions[i++] = q;

				Compute();

				if (Images)
				{
					FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " ("+td.Name+").png"), FileMode.Create );
					OutputImage.Save( myFileOut, ImageFormat.Png );
					myFileOut.Close();
				}
				
				TR += td.Name + "\r\n\r\n";
				TR += ResultTable;
				TR += "\r\n\r\n";
			}

			FileStream fs = new FileStream(path + "\\" + SystemTools.Savable(name + " (Ergebnistabelle).txt"), FileMode.Create);
			StreamWriter sr = new StreamWriter(fs);
			sr.Write(TR);
			sr.Close();

			seval = null;
			OutputImage = null;
			ResultTable = string.Empty;
		}

		public override void EditDialog()
		{
			OutputFormGaps ofg  = new OutputFormGaps(eval, false, this);
			ofg.ShowDialog();
		}
        
        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Gaps(eval, false, this);
        }
	}
}
