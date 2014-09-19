using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace umfrage2
{
    /*
	public class DialogLoad : umfrage2.DialogTemplate
	{
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		public MacTools.Forms.StatusBar statusBar;

		private EvalDeserializer ed;

		public DialogLoad(EvalDeserializer ed)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			this.ed = ed;
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.statusBar = new MacTools.Forms.StatusBar();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(28, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "lade.... bitte warten";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gainsboro;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.statusBar);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Font = new System.Drawing.Font("Arial", 8F);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(176, 64);
			this.panel1.TabIndex = 0;
			// 
			// statusBar
			// 
			this.statusBar.BackgroundColorA = System.Drawing.Color.DarkGray;
			this.statusBar.BackgroundColorB = System.Drawing.Color.LightGray;
			this.statusBar.BorderColor = System.Drawing.Color.Black;
			this.statusBar.BorderWidth = 1F;
			this.statusBar.Location = new System.Drawing.Point(8, 32);
			this.statusBar.MaxValue = 100;
			this.statusBar.MinValue = 0;
			this.statusBar.Name = "statusBar";
			this.statusBar.Precision = 1;
			this.statusBar.ProgressColorA = System.Drawing.Color.DarkBlue;
			this.statusBar.ProgressColorB = System.Drawing.Color.Blue;
			this.statusBar.Size = new System.Drawing.Size(160, 16);
			this.statusBar.TabIndex = 1;
			this.statusBar.TextColor = System.Drawing.Color.White;
			this.statusBar.TextColorAlternate = System.Drawing.Color.White;
			this.statusBar.TextFont = new System.Drawing.Font("Arial", 8F);
			this.statusBar.Value = 0;
			// 
			// DialogLoad
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(176, 64);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "DialogLoad";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void Tick(double percent)
		{
			statusBar.Value = percent*100;
			//Console.WriteLine(percent + "%");
		}
	}*/
}

