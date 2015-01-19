using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Zusammenfassung für ChangeScoringControl.
	/// </summary>
	public class ChangeScoringControl : UserControl
	{
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private Container components = null;
		private Panel CPanel;

		private Hashtable ht;

        public Hashtable IncTable
        {
            get
            {
                Hashtable nht = new Hashtable();

                foreach (ChangeScoringColumn csc in CPanel.Controls)
                {
                    if (csc.Included) nht[csc.Txt] = csc.Value;
                }

                return nht;
            }
        }

		public Hashtable NewTable
		{
			get
			{
				Hashtable nht = new Hashtable();

				foreach (ChangeScoringColumn csc in CPanel.Controls)
				{
					nht[csc.Txt] = csc.Value;
				}

				return nht;
			}
		}

		public ChangeScoringControl(Hashtable ht)
		{
			this.ht = ht;

			InitializeComponent();

			Init();

		}

		private void Init()
		{
			int loc = 0;

			bool i = false;
			foreach (string cname in ht.Keys)
			{
				ChangeScoringColumn csc = new ChangeScoringColumn(cname, (float)ht[cname]);

				if (i) csc.BackColor = Color.LightGray;

				csc.Width = this.Width;
				csc.Location = new Point(0, loc);

				CPanel.Controls.Add(csc);
				
				loc+= csc.Height;

				i = !i;
			}
		}

		/// <summary> 
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Komponenten-Designer generierter Code
		/// <summary> 
		/// Erforderliche Methode für die Designerunterstьtzung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.CPanel = new Panel();
			this.SuspendLayout();
			// 
			// CPanel
			// 
			this.CPanel.AutoScroll = true;
			this.CPanel.BorderStyle = BorderStyle.Fixed3D;
			this.CPanel.Dock = DockStyle.Fill;
			this.CPanel.Location = new Point(0, 0);
			this.CPanel.Name = "CPanel";
			this.CPanel.Size = new Size(472, 296);
			this.CPanel.TabIndex = 0;
			this.CPanel.Resize += new EventHandler(this.CPanel_SizeChanged);
			this.CPanel.SizeChanged += new EventHandler(this.CPanel_SizeChanged);
			// 
			// ChangeScoringControl
			// 
			this.BackColor = Color.Gainsboro;
			this.Controls.Add(this.CPanel);
			this.Name = "ChangeScoringControl";
			this.Size = new Size(472, 296);
			this.Resize += new EventHandler(this.CPanel_SizeChanged);
			this.SizeChanged += new EventHandler(this.CPanel_SizeChanged);
			this.ResumeLayout(false);

		}
		#endregion

		private void CPanel_SizeChanged(object sender, EventArgs e)
		{
			foreach (Control c in this.Controls)
			{
				c.Width = this.Width;
			}

			Refresh();
		}
	}
}
