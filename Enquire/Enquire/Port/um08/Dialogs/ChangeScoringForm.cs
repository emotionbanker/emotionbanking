using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using Compucare.Enquire.Legacy.Umfrage2Lib.Output.Scoring;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class ChangeScoringForm : DialogTemplate
	{
		private Panel HeaderPanel;
		private PictureBox pictureBox3;
		private Label label1;
		private Button SaveButton;
		private TabControl TargetTab;
		private IContainer components = null;

		private Hashtable cockpits;
		private Evaluation eval;

		public Hashtable Cockpits
		{
			get
			{
				Hashtable cp = new Hashtable();

				foreach (TabPage tp in TargetTab.TabPages)
				{
					ChangeScoringControl csc = (ChangeScoringControl)tp.Controls[0];

					TargetData td = (TargetData)tp.Tag;

					cp[td.Name] = csc.NewTable;
				}

				return cp;
			}
		}

        public Hashtable IncCockpits
        {
            get
            {
                Hashtable cp = new Hashtable();

                foreach (TabPage tp in TargetTab.TabPages)
                {
                    ChangeScoringControl csc = (ChangeScoringControl)tp.Controls[0];

                    TargetData td = (TargetData)tp.Tag;

                    cp[td.Name] = csc.IncTable;
                }

                return cp;
            }
        }

		public Hashtable Tops
		{
			get
			{
				Hashtable t = new Hashtable();

				foreach (string sc in Cockpits.Keys)
				{
					Hashtable cp = (Hashtable)Cockpits[sc];
					foreach (string col in cp.Keys)
					{
						if (!t.ContainsKey(col))
							t[col] = cp[col];
						else
						{
							float v = (float)t[col];
							float n = (float)cp[col];

							if (n > v)
								t[col] = n;
						}
					}
				}

				return t;
			}
		}

        public Hashtable IncTops
        {
            get
            {
                Hashtable t = new Hashtable();

                foreach (string sc in IncCockpits.Keys)
                {
                    Hashtable cp = (Hashtable)IncCockpits[sc];
                    foreach (string col in cp.Keys)
                    {
                        if (!t.ContainsKey(col))
                            t[col] = cp[col];
                        else
                        {
                            float v = (float)t[col];
                            float n = (float)cp[col];

                            if (n > v)
                                t[col] = n;
                        }
                    }
                }

                return t;
            }
        }

		public Hashtable Flops
		{
			get
			{
				Hashtable t = new Hashtable();

				foreach (string sc in Cockpits.Keys)
				{
					Hashtable cp = (Hashtable)Cockpits[sc];
					foreach (string col in cp.Keys)
					{
						if (!t.ContainsKey(col))
							t[col] = cp[col];
						else
						{
							float v = (float)t[col];
							float n = (float)cp[col];

							if (n < v)
								t[col] = n;
						}
					}
				}

				return t;
			}
		}

        public Hashtable IncFlops
        {
            get
            {
                Hashtable t = new Hashtable();

                foreach (string sc in IncCockpits.Keys)
                {
                    Hashtable cp = (Hashtable)IncCockpits[sc];
                    foreach (string col in cp.Keys)
                    {
                        if (!t.ContainsKey(col))
                            t[col] = cp[col];
                        else
                        {
                            float v = (float)t[col];
                            float n = (float)cp[col];

                            if (n < v)
                                t[col] = n;
                        }
                    }
                }

                return t;
            }
        }

		public Hashtable Averages
		{
			get
			{
                
				Hashtable t = new Hashtable();

				Hashtable count = new Hashtable();

				foreach (string sc in Cockpits.Keys)
				{
					Hashtable cp = (Hashtable)Cockpits[sc];
					foreach (string col in cp.Keys)
					{
						if (!t.ContainsKey(col))
							t[col] = 0f;

						if (!count.ContainsKey(col))
							count[col] = 0f;
						
						t[col] = ((float)t[col]) + ((float)cp[col]);
						count[col] = ((float)count[col]) + 1f;
					}
				}

				Hashtable results = new Hashtable();

				foreach (string scol in t.Keys)
				{
					results[scol] = ((float)t[scol]) / ((float)count[scol]);
				}

				return results;
			}
		}

        public Hashtable IncAverages
        {
            get
            {
                return (Hashtable)IncCockpits["Global"];
                /*
                Hashtable t = new Hashtable();

                Hashtable count = new Hashtable();

                foreach (string sc in IncCockpits.Keys)
                {
                    Hashtable cp = (Hashtable)IncCockpits[sc];
                    foreach (string col in cp.Keys)
                    {
                        if (!t.ContainsKey(col))
                            t[col] = 0f;

                        if (!count.ContainsKey(col))
                            count[col] = 0f;

                        t[col] = ((float)t[col]) + ((float)cp[col]);
                        count[col] = ((float)count[col]) + 1f;
                    }
                }

                Hashtable results = new Hashtable();

                foreach (string scol in t.Keys)
                {
                    results[scol] = ((float)t[scol]) / ((float)count[scol]);
                }

                return results;
                 * */
            }
        }

        public ArrayList IncList(TargetData td, Evaluation eval)
        {
            Hashtable cps = (Hashtable)IncCockpits[td.Name];

            ArrayList list = new ArrayList();

            foreach (string cpname in cps.Keys)
            {
                float val = (float)cps[cpname];
                CockpitElement ce;
                Column c = eval.GetColumnByName(cpname);

                if (c != null)
                {
                    ce = new CockpitElement(c.HeadTop, c.HeadB1, c.HeadB2, c.HeadB3, (int)val, (int)(float)IncAverages[cpname]);
                }
                else
                {
                    ce = new CockpitElement(cpname, "", "", "", (int)val, (int)(float)IncAverages[cpname]);
                }
                list.Add(ce);
            }

            return list;
        }

        public int IncTotal(TargetData[] targets, Evaluation eval)
        {
            int tot = 0;
            foreach (TargetData td in targets)
            {
                if (!td.Included) continue;

                foreach (CockpitElement ce in IncList(td, eval)) tot += ce.pts;
            }
            return tot;
        }
		
		public ChangeScoringForm(Evaluation eval, Hashtable cockpits)
		{
			this.cockpits = cockpits;
			this.eval = eval;

			InitializeComponent();

			Init();
		}

		private void Init()
		{
			foreach (TargetData td in eval.CombinedTargets)
			{
				if (!td.Included)
					continue;

				TabPage tp = new TabPage(td.Name);
				tp.Tag = td;

				Hashtable ht = (Hashtable)cockpits[td.Name];

				ChangeScoringControl csc = new ChangeScoringControl(ht);
				csc.Dock = DockStyle.Fill;
				csc.Width = tp.Width;
				tp.Controls.Add(csc);
				
				TargetTab.TabPages.Add(tp);
			}
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ChangeScoringForm));
            this.HeaderPanel = new Panel();
            this.pictureBox3 = new PictureBox();
            this.label1 = new Label();
            this.SaveButton = new Button();
            this.TargetTab = new TabControl();
            this.HeaderPanel.SuspendLayout();
            ((ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = Color.White;
            this.HeaderPanel.Controls.Add(this.pictureBox3);
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Dock = DockStyle.Top;
            this.HeaderPanel.Location = new Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new Size(554, 52);
            this.HeaderPanel.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new Point(13, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(34, 26);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = Color.White;
            this.label1.Font = new Font("Arial", 18F);
            this.label1.ForeColor = Color.Gray;
            this.label1.Location = new Point(60, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(307, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cockpit - Werte anpassen";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = Color.LightGray;
            this.SaveButton.FlatStyle = FlatStyle.Popup;
            this.SaveButton.Location = new Point(267, 312);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(186, 26);
            this.SaveButton.TabIndex = 27;
            this.SaveButton.Text = "Weiter";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
            // 
            // TargetTab
            // 
            this.TargetTab.Location = new Point(7, 58);
            this.TargetTab.Name = "TargetTab";
            this.TargetTab.SelectedIndex = 0;
            this.TargetTab.Size = new Size(446, 248);
            this.TargetTab.TabIndex = 28;
            // 
            // ChangeScoringForm
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.Gainsboro;
            this.ClientSize = new Size(554, 430);
            this.Controls.Add(this.TargetTab);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "ChangeScoringForm";
            this.Text = "Scoring";
            this.HeaderPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

            this.ShowInTaskbar = true;
		}
		#endregion

		private void SaveButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

