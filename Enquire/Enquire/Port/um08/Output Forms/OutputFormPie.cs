using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2
{
	public class OutputFormPie : DialogTemplate
	{
		private System.Windows.Forms.Panel HeaderPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button HorizontalButton;
		private System.Windows.Forms.Panel crossPanel;
		private System.Windows.Forms.Panel PersonPanel;
		private SizeControl sizeControl;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button EndButton;
		private System.ComponentModel.IContainer components = null;

		private Evaluation eval;
		public Pie pie;
		private ChoosePersonControl cpp;
		private Crossing cross;
		private OutputNameControl onc;
		private PreviewControl previewBox;
		private System.Windows.Forms.Label QLabel;
		private System.Windows.Forms.Label QueLabel;
		private System.Windows.Forms.Panel ColorPanel;

		private Question question;
		private System.Windows.Forms.CheckBox CheckRing;
		private System.Windows.Forms.TrackBar StartPosBar;
		private bool single;

		public OutputFormPie(Evaluation eval)
		{
			Set(eval, true, new Pie(eval));
		}

		public OutputFormPie(Evaluation eval, bool single)
		{
			Set(eval, single, new Pie(eval));
		}

		public OutputFormPie(Evaluation eval, bool single, Pie pie)
		{
			Set(eval, single, pie);

			EndButton.Visible = false;

			cpp.SetSelection(pie.PersonList, pie.ComboList);

			sizeControl.SetSize(pie.width, pie.height);

			if (pie.q != null)
			{
				question = pie.q;
				QLabel.Text = pie.q.SID;
			}

			UpdateColSel();
			Preview();
		}

		private void Set(Evaluation eval, bool single, Pie pie)
		{
			this.single = single;
			this.eval = eval;
			this.pie = pie;

			InitializeComponent();

			this.CancelButton = EndButton;

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_SizeChanged);

			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			PersonPanel.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(pie.Cross);

			onc = new OutputNameControl(pie);
			onc.Location = new Point(380,16);
			HeaderPanel.Controls.Add(onc);

			this.CheckRing.Checked = pie.Ring;
			this.StartPosBar.Value = pie.StartAngle;

			UpdateColSel();

			if (!single)
			{
				SaveButton.Text = "OK";
				EndButton.Text = "Abbrechen";
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OutputFormPie));
			this.HeaderPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.HorizontalButton = new System.Windows.Forms.Button();
			this.QLabel = new System.Windows.Forms.Label();
			this.QueLabel = new System.Windows.Forms.Label();
			this.crossPanel = new System.Windows.Forms.Panel();
			this.PersonPanel = new System.Windows.Forms.Panel();
			this.sizeControl = new SizeControl();
			this.SaveButton = new System.Windows.Forms.Button();
			this.EndButton = new System.Windows.Forms.Button();
			this.previewBox = new PreviewControl();
			this.ColorPanel = new System.Windows.Forms.Panel();
			this.CheckRing = new System.Windows.Forms.CheckBox();
			this.StartPosBar = new System.Windows.Forms.TrackBar();
			this.HeaderPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.StartPosBar)).BeginInit();
			this.SuspendLayout();
			// 
			// HeaderPanel
			// 
			this.HeaderPanel.BackColor = System.Drawing.Color.White;
			this.HeaderPanel.Controls.Add(this.label1);
			this.HeaderPanel.Controls.Add(this.pictureBox1);
			this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
			this.HeaderPanel.Name = "HeaderPanel";
			this.HeaderPanel.Size = new System.Drawing.Size(610, 80);
			this.HeaderPanel.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Arial", 18F);
			this.label1.ForeColor = System.Drawing.Color.Gray;
			this.label1.Location = new System.Drawing.Point(80, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(272, 48);
			this.label1.TabIndex = 1;
			this.label1.Text = "Tortendiagramm";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 56);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// HorizontalButton
			// 
			this.HorizontalButton.BackColor = System.Drawing.Color.LightGray;
			this.HorizontalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.HorizontalButton.Location = new System.Drawing.Point(488, 96);
			this.HorizontalButton.Name = "HorizontalButton";
			this.HorizontalButton.Size = new System.Drawing.Size(104, 32);
			this.HorizontalButton.TabIndex = 19;
			this.HorizontalButton.Text = "ändern...";
			this.HorizontalButton.Click += new System.EventHandler(this.HorizontalButton_Click);
			// 
			// QLabel
			// 
			this.QLabel.Location = new System.Drawing.Point(440, 104);
			this.QLabel.Name = "QLabel";
			this.QLabel.Size = new System.Drawing.Size(40, 23);
			this.QLabel.TabIndex = 20;
			this.QLabel.Text = "?";
			// 
			// QueLabel
			// 
			this.QueLabel.Location = new System.Drawing.Point(368, 104);
			this.QueLabel.Name = "QueLabel";
			this.QueLabel.Size = new System.Drawing.Size(72, 24);
			this.QueLabel.TabIndex = 18;
			this.QueLabel.Text = "Frage:";
			// 
			// crossPanel
			// 
			this.crossPanel.Location = new System.Drawing.Point(360, 136);
			this.crossPanel.Name = "crossPanel";
			this.crossPanel.Size = new System.Drawing.Size(232, 48);
			this.crossPanel.TabIndex = 22;
			// 
			// PersonPanel
			// 
			this.PersonPanel.Location = new System.Drawing.Point(368, 184);
			this.PersonPanel.Name = "PersonPanel";
			this.PersonPanel.Size = new System.Drawing.Size(224, 96);
			this.PersonPanel.TabIndex = 21;
			// 
			// sizeControl
			// 
			this.sizeControl.BackColor = System.Drawing.Color.Gainsboro;
			this.sizeControl.Location = new System.Drawing.Point(488, 288);
			this.sizeControl.Name = "sizeControl";
			this.sizeControl.Size = new System.Drawing.Size(104, 56);
			this.sizeControl.TabIndex = 23;
			// 
			// SaveButton
			// 
			this.SaveButton.BackColor = System.Drawing.Color.LightGray;
			this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.SaveButton.Location = new System.Drawing.Point(376, 416);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(216, 32);
			this.SaveButton.TabIndex = 25;
			this.SaveButton.Text = "Speichern...";
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// EndButton
			// 
			this.EndButton.BackColor = System.Drawing.Color.LightGray;
			this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.EndButton.Location = new System.Drawing.Point(376, 376);
			this.EndButton.Name = "EndButton";
			this.EndButton.Size = new System.Drawing.Size(216, 32);
			this.EndButton.TabIndex = 24;
			this.EndButton.Text = "Schliessen";
			this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
			// 
			// previewBox
			// 
			this.previewBox.BackColor = System.Drawing.Color.Gainsboro;
			this.previewBox.Location = new System.Drawing.Point(8, 96);
			this.previewBox.Name = "previewBox";
			this.previewBox.Size = new System.Drawing.Size(352, 224);
			this.previewBox.SmallPreview = null;
			this.previewBox.TabIndex = 26;
			// 
			// ColorPanel
			// 
			this.ColorPanel.Location = new System.Drawing.Point(8, 328);
			this.ColorPanel.Name = "ColorPanel";
			this.ColorPanel.Size = new System.Drawing.Size(352, 120);
			this.ColorPanel.TabIndex = 27;
			// 
			// CheckRing
			// 
			this.CheckRing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CheckRing.Location = new System.Drawing.Point(368, 288);
			this.CheckRing.Name = "CheckRing";
			this.CheckRing.TabIndex = 28;
			this.CheckRing.Text = "Ring";
			this.CheckRing.CheckedChanged += new System.EventHandler(this.CheckRing_CheckedChanged);
			// 
			// StartPosBar
			// 
			this.StartPosBar.LargeChange = 45;
			this.StartPosBar.Location = new System.Drawing.Point(360, 312);
			this.StartPosBar.Maximum = 360;
			this.StartPosBar.Name = "StartPosBar";
			this.StartPosBar.Size = new System.Drawing.Size(120, 53);
			this.StartPosBar.SmallChange = 10;
			this.StartPosBar.TabIndex = 29;
			this.StartPosBar.TickFrequency = 45;
			this.StartPosBar.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.StartPosBar.Scroll += new System.EventHandler(this.StartPosBar_Scroll);
			// 
			// OutputFormPie
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(610, 462);
			this.Controls.Add(this.StartPosBar);
			this.Controls.Add(this.CheckRing);
			this.Controls.Add(this.ColorPanel);
			this.Controls.Add(this.previewBox);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.EndButton);
			this.Controls.Add(this.sizeControl);
			this.Controls.Add(this.crossPanel);
			this.Controls.Add(this.PersonPanel);
			this.Controls.Add(this.HorizontalButton);
			this.Controls.Add(this.QLabel);
			this.Controls.Add(this.QueLabel);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "OutputFormPie";
			this.Text = "Einzelauswertung";
			this.Load += new System.EventHandler(this.OutputFormPie_Load);
			this.HeaderPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.StartPosBar)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Preview()
		{
			Preview(false);
		}

		private void Preview(bool bigOnly)
		{
			if (question != null)
			{
				if (!bigOnly)
				{
					pie.Ring = CheckRing.Checked;
					pie.q = question;
					pie.width = previewBox.Width - 10;
					pie.height = (previewBox.Height/3) * 5 - 20;
					pie.PersonList = cpp.SelectedPersons;
					pie.ComboList = cpp.SelectedCombos;
					pie.Compute();
					previewBox.SmallPreview = pie.PieImage;
				}
				
				Pie p2 = new Pie(eval);
				p2.StartAngle = StartPosBar.Value;
				p2.Ring = CheckRing.Checked;
				p2.q = question;
				p2.width = sizeControl.ChosenWidth;
				p2.height = sizeControl.ChosenHeight;
				p2.PersonList = cpp.SelectedPersons;
				p2.ComboList = cpp.SelectedCombos;
				p2.Compute();
				previewBox.BigPreview = p2.OutputImage;
			}
		}

		private void UpdateColSel()
		{
			ColorPanel.Controls.Clear();
			if (question != null)
			{
				ColorSelector colsel = new ColorSelector(eval, question.AnswerList);
				colsel.Dock = DockStyle.Fill;
				ColorPanel.Controls.Add(colsel);
				colsel.ColorChanged+=new ColorChangedEvent(colsel_ColorChanged);
			}
		}

		private void cpp_SelectionChanged()
		{
			Preview();
		}

		private void HorizontalButton_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				question = qs.SelectedQuestion;
				QLabel.Text = question.SID;

				UpdateColSel();
				Preview();
			}
		}

		private void sizeControl_SizeChanged()
		{
			Preview(true);
		}

		private void colsel_ColorChanged()
		{
			Preview();
		}

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			pie.PersonList = cpp.SelectedPersons;
			pie.ComboList = cpp.SelectedCombos;
			pie.eval = eval;
			pie.Cross  = cross.Cross;
			pie.width  = sizeControl.ChosenWidth;
			pie.height = sizeControl.ChosenHeight;

			if (single)
			{
				SaveDialog sd = new SaveDialog(pie);
				sd.ShowDialog();
			}
			else
			{
				Close();
				this.DialogResult = DialogResult.OK;
			}
		}

		private void cross_CrossChanged()
		{
			pie.Cross = cross.cross;
		}

		private void CheckRing_CheckedChanged(object sender, System.EventArgs e)
		{
			pie.Ring = CheckRing.Checked;
			Preview();
		}

		private void StartPosBar_Scroll(object sender, System.EventArgs e)
		{
			pie.StartAngle = StartPosBar.Value;
			Preview();
		}

		private void OutputFormPie_Load(object sender, System.EventArgs e)
		{
		
		}

		private void EndButton_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}

