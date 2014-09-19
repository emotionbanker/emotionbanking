using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for DataStatusControl.
	/// </summary>
	public class DataStatusControl : UserControl
	{
		private GroupBox groupBox1;
		private Button SelectVirtualButton;
		private Label label4;
		private Label lastResultUpdateLabel;
		private Label label2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;
		private Label TargetCountLabel;
		private Label label5;
		private Label ResultCountLabel;

		private Evaluation eval;

		public DataStatusControl(Evaluation eval)
		{
			this.eval = eval;

			eval.ResultDataChanged+=new EvaluationEventHandler(eval_ResultDataChanged);

			InitializeComponent();

			UpdateData();
		}

		public void UpdateData()
		{
			lastResultUpdateLabel.Text = eval.LastResultUpdate;
			TargetCountLabel.Text = eval.TargetCount.ToString();
			ResultCountLabel.Text = eval.QuestionCount.ToString() + "/" + eval.ResultCount.ToString();
		}

		/// <summary> 
		/// Clean up any resources being used.
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new GroupBox();
			this.SelectVirtualButton = new Button();
			this.TargetCountLabel = new Label();
			this.label4 = new Label();
			this.lastResultUpdateLabel = new Label();
			this.label2 = new Label();
			this.label5 = new Label();
			this.ResultCountLabel = new Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.SelectVirtualButton);
			this.groupBox1.Controls.Add(this.ResultCountLabel);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.TargetCountLabel);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.lastResultUpdateLabel);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(584, 112);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datenstatus";
			// 
			// SelectVirtualButton
			// 
			this.SelectVirtualButton.BackColor = Color.LightGray;
			this.SelectVirtualButton.FlatStyle = FlatStyle.Popup;
			this.SelectVirtualButton.Location = new Point(408, 24);
			this.SelectVirtualButton.Name = "SelectVirtualButton";
			this.SelectVirtualButton.Size = new Size(160, 32);
			this.SelectVirtualButton.TabIndex = 9;
			this.SelectVirtualButton.Text = "Daten laden...";
			this.SelectVirtualButton.Click += new EventHandler(this.SelectVirtualButton_Click);
			// 
			// TargetCountLabel
			// 
			this.TargetCountLabel.Location = new Point(248, 56);
			this.TargetCountLabel.Name = "TargetCountLabel";
			this.TargetCountLabel.Size = new Size(160, 24);
			this.TargetCountLabel.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new Point(16, 56);
			this.label4.Name = "label4";
			this.label4.Size = new Size(232, 24);
			this.label4.TabIndex = 2;
			this.label4.Text = "Anzahl der Ziele:";
			this.label4.TextAlign = ContentAlignment.TopRight;
			// 
			// lastResultUpdateLabel
			// 
			this.lastResultUpdateLabel.Location = new Point(248, 32);
			this.lastResultUpdateLabel.Name = "lastResultUpdateLabel";
			this.lastResultUpdateLabel.Size = new Size(160, 24);
			this.lastResultUpdateLabel.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new Point(16, 32);
			this.label2.Name = "label2";
			this.label2.Size = new Size(232, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "Letztes Einlesen aus der Datenbank:";
			this.label2.TextAlign = ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.BackColor = Color.Gainsboro;
			this.label5.Font = new Font("Arial", 8F);
			this.label5.Location = new Point(16, 80);
			this.label5.Name = "label5";
			this.label5.Size = new Size(232, 24);
			this.label5.TabIndex = 4;
			this.label5.Text = "Anzahl der Fragen/Ergebnisse:";
			this.label5.TextAlign = ContentAlignment.TopRight;
			// 
			// ResultCountLabel
			// 
			this.ResultCountLabel.BackColor = Color.Gainsboro;
			this.ResultCountLabel.Font = new Font("Arial", 8F);
			this.ResultCountLabel.Location = new Point(248, 80);
			this.ResultCountLabel.Name = "ResultCountLabel";
			this.ResultCountLabel.Size = new Size(160, 24);
			this.ResultCountLabel.TabIndex = 5;
			// 
			// DataStatusControl
			// 
			this.BackColor = Color.Gainsboro;
			this.Controls.Add(this.groupBox1);
			this.Font = new Font("Arial", 8F);
			this.Name = "DataStatusControl";
			this.Size = new Size(584, 112);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void SelectVirtualButton_Click(object sender, EventArgs e)
		{
			eval.LoadResults();
		}

		private void eval_ResultDataChanged(object source)
		{
			UpdateData();
		}
	}
}
