using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for BenchmarkControl.
	/// </summary>
	public class BenchmarkControl : UserControl
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Evaluation eval;
		private ColorDialog colorDialog;
		private GroupBox groupBox2;
		private Label label6;
		private Button QRemove;
		private Button QAdd;
		private ListBox QBox;

		private DataStatusControl StatusControl;
		private Panel targetBox;
		private Button SaveButton;

		private ChooseTargetControl TargetSelector;
		private CheckBox AllQuestionsBox;
		private Button ColorButton;
		private Panel personBox;

		private Benchmarking bench;
		private GroupBox groupBox1;
		private GroupBox groupBox3;
		private CheckBox wordBox;

		private ChoosePersonControl cpp;
		
		public BenchmarkControl(Evaluation eval)
		{
			this.eval = eval;

			bench = new Benchmarking(eval);

			this.SetStyle(

				ControlStyles.AllPaintingInWmPaint |

				ControlStyles.UserPaint |

				ControlStyles.DoubleBuffer,true);

			InitializeComponent();

			StatusControl = new DataStatusControl(eval);
			StatusControl.Location = new Point(8,88);

			this.Controls.Add(StatusControl);

			TargetSelector = new ChooseTargetControl(eval);
			TargetSelector.Dock = DockStyle.Fill;

			targetBox.Controls.Add(TargetSelector);

			cpp = new ChoosePersonControl(eval);
			cpp.Dock = DockStyle.Fill;

			personBox.Controls.Add(cpp);
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(BenchmarkControl));
            this.HeaderPanel = new Panel();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            this.colorDialog = new ColorDialog();
            this.groupBox2 = new GroupBox();
            this.wordBox = new CheckBox();
            this.AllQuestionsBox = new CheckBox();
            this.SaveButton = new Button();
            this.QAdd = new Button();
            this.QBox = new ListBox();
            this.QRemove = new Button();
            this.label6 = new Label();
            this.ColorButton = new Button();
            this.targetBox = new Panel();
            this.personBox = new Panel();
            this.groupBox1 = new GroupBox();
            this.groupBox3 = new GroupBox();
            this.HeaderPanel.SuspendLayout();
            ((ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.HeaderPanel.Size = new Size(624, 80);
            this.HeaderPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = Color.White;
            this.label1.Font = new Font("Arial", 18F);
            this.label1.ForeColor = Color.Gainsboro;
            this.label1.Location = new Point(72, 16);
            this.label1.Name = "label1";
            this.label1.Size = new Size(552, 56);
            this.label1.TabIndex = 1;
            this.label1.Text = "Benchmarking";
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
            this.groupBox2.Controls.Add(this.wordBox);
            this.groupBox2.Controls.Add(this.AllQuestionsBox);
            this.groupBox2.Controls.Add(this.SaveButton);
            this.groupBox2.Controls.Add(this.QAdd);
            this.groupBox2.Controls.Add(this.QBox);
            this.groupBox2.Controls.Add(this.QRemove);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ColorButton);
            this.groupBox2.Location = new Point(368, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(224, 272);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Benchmarking";
            // 
            // wordBox
            // 
            this.wordBox.Image = ((Image)(resources.GetObject("wordBox.Image")));
            this.wordBox.ImageAlign = ContentAlignment.MiddleLeft;
            this.wordBox.Location = new Point(120, 144);
            this.wordBox.Name = "wordBox";
            this.wordBox.Size = new Size(48, 24);
            this.wordBox.TabIndex = 39;
            this.wordBox.TextAlign = ContentAlignment.MiddleRight;
            this.wordBox.CheckedChanged += new EventHandler(this.wordBox_CheckedChanged);
            // 
            // AllQuestionsBox
            // 
            this.AllQuestionsBox.Location = new Point(8, 144);
            this.AllQuestionsBox.Name = "AllQuestionsBox";
            this.AllQuestionsBox.Size = new Size(96, 24);
            this.AllQuestionsBox.TabIndex = 38;
            this.AllQuestionsBox.Text = "Alle Fragen";
            this.AllQuestionsBox.CheckedChanged += new EventHandler(this.AllQuestionsBox_CheckedChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = Color.LightGray;
            this.SaveButton.FlatStyle = FlatStyle.Popup;
            this.SaveButton.Location = new Point(8, 224);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(192, 32);
            this.SaveButton.TabIndex = 37;
            this.SaveButton.Text = "Speichern...";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
            // 
            // QAdd
            // 
            this.QAdd.BackColor = Color.LightGray;
            this.QAdd.FlatStyle = FlatStyle.Popup;
            this.QAdd.Location = new Point(168, 56);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new Size(32, 32);
            this.QAdd.TabIndex = 33;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            this.QAdd.Click += new EventHandler(this.QAdd_Click);
            // 
            // QBox
            // 
            this.QBox.BorderStyle = BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 16;
            this.QBox.Location = new Point(8, 24);
            this.QBox.Name = "QBox";
            this.QBox.Size = new Size(144, 114);
            this.QBox.TabIndex = 32;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = Color.LightGray;
            this.QRemove.FlatStyle = FlatStyle.Popup;
            this.QRemove.Location = new Point(168, 96);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new Size(32, 32);
            this.QRemove.TabIndex = 34;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new EventHandler(this.QRemove_Click);
            // 
            // label6
            // 
            this.label6.Location = new Point(160, 16);
            this.label6.Name = "label6";
            this.label6.Size = new Size(48, 32);
            this.label6.TabIndex = 35;
            this.label6.Text = "Fragen";
            this.label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = Color.LightGray;
            this.ColorButton.FlatStyle = FlatStyle.Popup;
            this.ColorButton.Location = new Point(8, 184);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new Size(192, 32);
            this.ColorButton.TabIndex = 5;
            this.ColorButton.Text = "Farben...";
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new EventHandler(this.ColorButton_Click);
            // 
            // targetBox
            // 
            this.targetBox.Dock = DockStyle.Fill;
            this.targetBox.Location = new Point(3, 19);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new Size(162, 250);
            this.targetBox.TabIndex = 36;
            // 
            // personBox
            // 
            this.personBox.Dock = DockStyle.Fill;
            this.personBox.Location = new Point(3, 19);
            this.personBox.Name = "personBox";
            this.personBox.Size = new Size(162, 250);
            this.personBox.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.personBox);
            this.groupBox1.Location = new Point(192, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(168, 272);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personenauswahl";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.targetBox);
            this.groupBox3.Location = new Point(8, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(168, 272);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zielauswahl";
            // 
            // BenchmarkControl
            // 
            this.BackColor = Color.Gainsboro;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.HeaderPanel);
            this.Font = new Font("Arial", 8F);
            this.Name = "BenchmarkControl";
            this.Size = new Size(624, 512);
            this.HeaderPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		

		private void QAdd_Click(object sender, EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				foreach (Question q in qs.SelectedQuestions)
					QBox.Items.Add(q);
			}
		}

		private void QRemove_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < QBox.SelectedItems.Count; i++)
			{
				QBox.Items.Remove(QBox.SelectedItems[i]);
			}
		}

		private Question[] getList()
		{
			if (AllQuestionsBox.Checked)
			{
				return eval.Global.Questions;
			}
			else
			{
				Question[] qs = new Question[QBox.Items.Count];				

				int i = 0;
				foreach (Question q in QBox.Items)
					qs[i++] = q;

				return qs;
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			bench.Name = "Benchmarking";
			bench.Word = wordBox.Checked;
			bench.Questions = getList();
			bench.PersonList = cpp.SelectedPersons;
			bench.ComboList = cpp.SelectedCombos;
			SaveDialog sd = new SaveDialog(bench);
			sd.ShowDialog();
		}

		private void AllQuestionsBox_CheckedChanged(object sender, EventArgs e)
		{
			if (AllQuestionsBox.Checked)
			{
				QBox.Enabled = QAdd.Enabled = QRemove.Enabled = false;
			}
			else
			{
				QBox.Enabled = QAdd.Enabled = QRemove.Enabled = true;
			}
		}

		private void ColorButton_Click(object sender, EventArgs e)
		{
			DialogBenchmarkColors dbc = new DialogBenchmarkColors(eval);
			dbc.ShowDialog();
		}

        private void wordBox_CheckedChanged(object sender, EventArgs e)
        {

        }
	}
}
