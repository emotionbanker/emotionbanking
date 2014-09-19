using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for SingleControl.
	/// </summary>
	public class SingleControl : UserControl
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Evaluation eval;
		private GroupBox groupBox2;
		private Button SingleMatrix;
		private Button MultiMatrix;
		private GroupBox targetBox;
		
		private DataStatusControl StatusControl;
		private Button Pie;
		private Button Bar;
		private Button button1;
		private Button Gaps;
		private Button Averages;
		private Button Ranking;
		private Button Open;
		private Button BarometerButton;
		private Button CrossAveragesButton;

		private ChooseTargetControl TargetSelector;

		public SingleControl(Evaluation eval)
		{
			this.eval = eval;

			InitializeComponent();

			
			StatusControl = new DataStatusControl(eval);
			StatusControl.Location = new Point(8,88);

			this.Controls.Add(StatusControl);

			TargetSelector = new ChooseTargetControl(eval);
			TargetSelector.Dock = DockStyle.Fill;

			targetBox.Controls.Add(TargetSelector);
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
			ResourceManager resources = new ResourceManager(typeof(SingleControl));
			this.HeaderPanel = new Panel();
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.groupBox2 = new GroupBox();
			this.BarometerButton = new Button();
			this.Open = new Button();
			this.Ranking = new Button();
			this.Averages = new Button();
			this.Gaps = new Button();
			this.button1 = new Button();
			this.Bar = new Button();
			this.Pie = new Button();
			this.MultiMatrix = new Button();
			this.SingleMatrix = new Button();
			this.targetBox = new GroupBox();
			this.CrossAveragesButton = new Button();
			this.HeaderPanel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// HeaderPanel
			// 
			this.HeaderPanel.BackColor = Color.White;
			this.HeaderPanel.Controls.Add(this.label1);
			this.HeaderPanel.Controls.Add(this.pictureBox1);
			this.HeaderPanel.Dock = DockStyle.Top;
			this.HeaderPanel.Location = new Point(0, 0);
			this.HeaderPanel.Name = "HeaderPanel";
			this.HeaderPanel.Size = new Size(600, 80);
			this.HeaderPanel.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.BackColor = Color.White;
			this.label1.Font = new Font("Arial", 18F);
			this.label1.ForeColor = Color.Gray;
			this.label1.Location = new Point(72, 16);
			this.label1.Name = "label1";
			this.label1.Size = new Size(552, 56);
			this.label1.TabIndex = 1;
			this.label1.Text = "Einzelauswertungen";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(64, 64);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.CrossAveragesButton);
			this.groupBox2.Controls.Add(this.BarometerButton);
			this.groupBox2.Controls.Add(this.Open);
			this.groupBox2.Controls.Add(this.Ranking);
			this.groupBox2.Controls.Add(this.Averages);
			this.groupBox2.Controls.Add(this.Gaps);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.Bar);
			this.groupBox2.Controls.Add(this.Pie);
			this.groupBox2.Controls.Add(this.MultiMatrix);
			this.groupBox2.Controls.Add(this.SingleMatrix);
			this.groupBox2.Location = new Point(200, 216);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(392, 280);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Einzelauswertungen";
			// 
			// BarometerButton
			// 
			this.BarometerButton.BackColor = Color.LightGray;
			this.BarometerButton.FlatStyle = FlatStyle.Popup;
			this.BarometerButton.Image = ((Image)(resources.GetObject("BarometerButton.Image")));
			this.BarometerButton.ImageAlign = ContentAlignment.MiddleLeft;
			this.BarometerButton.Location = new Point(200, 232);
			this.BarometerButton.Name = "BarometerButton";
			this.BarometerButton.Size = new Size(168, 32);
			this.BarometerButton.TabIndex = 10;
			this.BarometerButton.Text = "Barometer";
			this.BarometerButton.Click += new EventHandler(this.BarometerButton_Click);
			// 
			// Open
			// 
			this.Open.BackColor = Color.LightGray;
			this.Open.FlatStyle = FlatStyle.Popup;
			this.Open.Image = ((Image)(resources.GetObject("Open.Image")));
			this.Open.ImageAlign = ContentAlignment.MiddleLeft;
			this.Open.Location = new Point(200, 112);
			this.Open.Name = "Open";
			this.Open.Size = new Size(168, 32);
			this.Open.TabIndex = 9;
			this.Open.Text = "Offene Fragen";
			this.Open.Click += new EventHandler(this.Open_Click);
			// 
			// Ranking
			// 
			this.Ranking.BackColor = Color.LightGray;
			this.Ranking.FlatStyle = FlatStyle.Popup;
			this.Ranking.Image = ((Image)(resources.GetObject("Ranking.Image")));
			this.Ranking.ImageAlign = ContentAlignment.MiddleLeft;
			this.Ranking.Location = new Point(200, 72);
			this.Ranking.Name = "Ranking";
			this.Ranking.Size = new Size(168, 32);
			this.Ranking.TabIndex = 8;
			this.Ranking.Text = "Ranking";
			this.Ranking.Click += new EventHandler(this.Ranking_Click);
			// 
			// Averages
			// 
			this.Averages.BackColor = Color.LightGray;
			this.Averages.FlatStyle = FlatStyle.Popup;
			this.Averages.Image = ((Image)(resources.GetObject("Averages.Image")));
			this.Averages.ImageAlign = ContentAlignment.MiddleLeft;
			this.Averages.Location = new Point(200, 32);
			this.Averages.Name = "Averages";
			this.Averages.Size = new Size(168, 32);
			this.Averages.TabIndex = 7;
			this.Averages.Text = "Mittelwerte";
			this.Averages.Click += new EventHandler(this.Averages_Click);
			// 
			// Gaps
			// 
			this.Gaps.BackColor = Color.LightGray;
			this.Gaps.FlatStyle = FlatStyle.Popup;
			this.Gaps.Image = ((Image)(resources.GetObject("Gaps.Image")));
			this.Gaps.ImageAlign = ContentAlignment.MiddleLeft;
			this.Gaps.Location = new Point(16, 232);
			this.Gaps.Name = "Gaps";
			this.Gaps.Size = new Size(168, 32);
			this.Gaps.TabIndex = 6;
			this.Gaps.Text = "Gaps";
			this.Gaps.Click += new EventHandler(this.Gaps_Click);
			// 
			// button1
			// 
			this.button1.BackColor = Color.LightGray;
			this.button1.FlatStyle = FlatStyle.Popup;
			this.button1.Image = ((Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = ContentAlignment.MiddleLeft;
			this.button1.Location = new Point(16, 192);
			this.button1.Name = "button1";
			this.button1.Size = new Size(168, 32);
			this.button1.TabIndex = 5;
			this.button1.Text = "Polaritäten";
			this.button1.Click += new EventHandler(this.button1_Click);
			// 
			// Bar
			// 
			this.Bar.BackColor = Color.LightGray;
			this.Bar.FlatStyle = FlatStyle.Popup;
			this.Bar.Image = ((Image)(resources.GetObject("Bar.Image")));
			this.Bar.ImageAlign = ContentAlignment.MiddleLeft;
			this.Bar.Location = new Point(16, 152);
			this.Bar.Name = "Bar";
			this.Bar.Size = new Size(168, 32);
			this.Bar.TabIndex = 4;
			this.Bar.Text = "Balkendiagramm";
			this.Bar.Click += new EventHandler(this.Bar_Click);
			// 
			// Pie
			// 
			this.Pie.BackColor = Color.LightGray;
			this.Pie.FlatStyle = FlatStyle.Popup;
			this.Pie.Image = ((Image)(resources.GetObject("Pie.Image")));
			this.Pie.ImageAlign = ContentAlignment.MiddleLeft;
			this.Pie.Location = new Point(16, 112);
			this.Pie.Name = "Pie";
			this.Pie.Size = new Size(168, 32);
			this.Pie.TabIndex = 3;
			this.Pie.Text = "Tortendiagramm";
			this.Pie.Click += new EventHandler(this.Pie_Click);
			// 
			// MultiMatrix
			// 
			this.MultiMatrix.BackColor = Color.LightGray;
			this.MultiMatrix.FlatStyle = FlatStyle.Popup;
			this.MultiMatrix.Image = ((Image)(resources.GetObject("MultiMatrix.Image")));
			this.MultiMatrix.ImageAlign = ContentAlignment.MiddleLeft;
			this.MultiMatrix.Location = new Point(16, 72);
			this.MultiMatrix.Name = "MultiMatrix";
			this.MultiMatrix.Size = new Size(168, 32);
			this.MultiMatrix.TabIndex = 2;
			this.MultiMatrix.Text = "Matrix";
			this.MultiMatrix.Click += new EventHandler(this.MultiMatrix_Click);
			// 
			// SingleMatrix
			// 
			this.SingleMatrix.BackColor = Color.LightGray;
			this.SingleMatrix.FlatStyle = FlatStyle.Popup;
			this.SingleMatrix.Image = ((Image)(resources.GetObject("SingleMatrix.Image")));
			this.SingleMatrix.ImageAlign = ContentAlignment.MiddleLeft;
			this.SingleMatrix.Location = new Point(16, 32);
			this.SingleMatrix.Name = "SingleMatrix";
			this.SingleMatrix.Size = new Size(168, 32);
			this.SingleMatrix.TabIndex = 1;
			this.SingleMatrix.Text = "Prozentmatrix";
			this.SingleMatrix.Click += new EventHandler(this.SingleMatrix_Click);
			// 
			// targetBox
			// 
			this.targetBox.Location = new Point(8, 216);
			this.targetBox.Name = "targetBox";
			this.targetBox.Size = new Size(184, 280);
			this.targetBox.TabIndex = 5;
			this.targetBox.TabStop = false;
			this.targetBox.Text = "Zielauswahl";
			// 
			// CrossAveragesButton
			// 
			this.CrossAveragesButton.BackColor = Color.LightGray;
			this.CrossAveragesButton.FlatStyle = FlatStyle.Popup;
			this.CrossAveragesButton.Image = ((Image)(resources.GetObject("CrossAveragesButton.Image")));
			this.CrossAveragesButton.ImageAlign = ContentAlignment.MiddleLeft;
			this.CrossAveragesButton.Location = new Point(200, 192);
			this.CrossAveragesButton.Name = "CrossAveragesButton";
			this.CrossAveragesButton.Size = new Size(168, 32);
			this.CrossAveragesButton.TabIndex = 11;
			this.CrossAveragesButton.Text = "MW- Kreuzung";
			this.CrossAveragesButton.Click += new EventHandler(this.CrossAveragesButton_Click);
			// 
			// SingleControl
			// 
			this.BackColor = Color.Gainsboro;
			this.Controls.Add(this.targetBox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.HeaderPanel);
			this.Font = new Font("Arial", 8F);
			this.Name = "SingleControl";
			this.Size = new Size(600, 512);
			this.HeaderPanel.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void SingleMatrix_Click(object sender, EventArgs e)
		{
			OutputFormSingleMatrix ofsm = new OutputFormSingleMatrix(eval, true);
			ofsm.ShowDialog();
		}

		private void MultiMatrix_Click(object sender, EventArgs e)
		{
			OutputFormMultiMatrix ofmm = new OutputFormMultiMatrix(eval);
			ofmm.ShowDialog();
		}

		private void Pie_Click(object sender, EventArgs e)
		{
			OutputFormPie ofp = new OutputFormPie(eval);
			ofp.ShowDialog();
		}

		private void Bar_Click(object sender, EventArgs e)
		{
			OutputFormBar ofb = new OutputFormBar(eval);
			ofb.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OutputFormPolarity ofp = new OutputFormPolarity(eval);
			ofp.ShowDialog();
		}

		private void Gaps_Click(object sender, EventArgs e)
		{
			OutputFormGaps ofg = new OutputFormGaps(eval);
			ofg.ShowDialog();
		}

		private void Averages_Click(object sender, EventArgs e)
		{
			OutputFormAverages ofa = new OutputFormAverages(eval);
			ofa.ShowDialog();
		}

		private void Ranking_Click(object sender, EventArgs e)
		{
			OutputFormRank ofr = new OutputFormRank(eval);
			ofr.ShowDialog();
		}

		private void Open_Click(object sender, EventArgs e)
		{
			OutputFormOpen ofo = new OutputFormOpen(eval);
			ofo.ShowDialog();
		}

		private void BarometerButton_Click(object sender, EventArgs e)
		{
			OutputFormBarometer ofb = new OutputFormBarometer(eval);
			ofb.ShowDialog();
		}

		private void CrossAveragesButton_Click(object sender, EventArgs e)
		{
			OutputFormCrossAverages ofa = new OutputFormCrossAverages(eval);
			ofa.ShowDialog();
		}
	}
}
