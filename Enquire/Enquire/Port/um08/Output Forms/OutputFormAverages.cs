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
	public class OutputFormAverages : DialogTemplate
	{
		private System.Windows.Forms.Panel HeaderPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel crossPanel;
		private System.Windows.Forms.Panel PersonPanel;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button EndButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button QRemove;
		private System.Windows.Forms.Button QAdd;
		private System.Windows.Forms.ListBox QBox;
		private System.Windows.Forms.RichTextBox resultBox;
		private System.ComponentModel.IContainer components = null;

		public Averages avg;
		private Evaluation eval;
		private bool single;

		private ChoosePersonControl cpp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown precControl;
		private System.Windows.Forms.CheckBox AvgBox;
		private System.Windows.Forms.CheckBox AvgMedian;
		private System.Windows.Forms.CheckBox PcntBox;

		private Crossing cross;

		public OutputFormAverages(Evaluation eval)
		{
            Set(eval, true, new Averages(eval));
		}

		public OutputFormAverages(Evaluation eval, bool single)
		{
            Set(eval, single, new Averages(eval));
		}

		public OutputFormAverages(Evaluation eval, bool single, Averages avg)
		{
			Set(eval, single, avg);

			EndButton.Visible = false;
			
			cpp.SetSelection(avg.PersonList, avg.ComboList);

			//question lists

			foreach (Question q in avg.Questions)
				QBox.Items.Add(q);

			precControl.Value = avg.Precision;


			AvgBox.Checked	= avg.average;
			AvgMedian.Checked = avg.median;
			PcntBox.Checked = avg.percent;

			Preview();
		}

		private void Set(Evaluation eval, bool single, Averages avg)
		{
			this.eval = eval;
			this.single = single;
			this.avg = avg;

			InitializeComponent();

			this.CancelButton = EndButton;

			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			PersonPanel.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(avg.Cross);

			OutputNameControl onc = new OutputNameControl(avg);
			onc.Location = new Point(380,16);
			HeaderPanel.Controls.Add(onc);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputFormAverages));
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EndButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.QRemove = new System.Windows.Forms.Button();
            this.QAdd = new System.Windows.Forms.Button();
            this.QBox = new System.Windows.Forms.ListBox();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.precControl = new System.Windows.Forms.NumericUpDown();
            this.AvgBox = new System.Windows.Forms.CheckBox();
            this.AvgMedian = new System.Windows.Forms.CheckBox();
            this.PcntBox = new System.Windows.Forms.CheckBox();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precControl)).BeginInit();
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
            this.HeaderPanel.Size = new System.Drawing.Size(602, 65);
            this.HeaderPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 18F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(60, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mittelwerte";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 52);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(293, 176);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(194, 38);
            this.crossPanel.TabIndex = 48;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Location = new System.Drawing.Point(300, 214);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(187, 78);
            this.PersonPanel.TabIndex = 47;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LightGray;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Location = new System.Drawing.Point(307, 396);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(180, 26);
            this.SaveButton.TabIndex = 46;
            this.SaveButton.Text = "Speichern...";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.BackColor = System.Drawing.Color.LightGray;
            this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndButton.Location = new System.Drawing.Point(307, 364);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(180, 26);
            this.EndButton.TabIndex = 45;
            this.EndButton.Text = "Schliessen";
            this.EndButton.UseVisualStyleBackColor = false;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(447, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 26);
            this.label2.TabIndex = 44;
            this.label2.Text = "Fragen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.LightGray;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(453, 143);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(27, 26);
            this.QRemove.TabIndex = 43;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new System.EventHandler(this.QRemove_Click);
            // 
            // QAdd
            // 
            this.QAdd.BackColor = System.Drawing.Color.LightGray;
            this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QAdd.Location = new System.Drawing.Point(453, 110);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new System.Drawing.Size(27, 26);
            this.QAdd.TabIndex = 42;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            this.QAdd.Click += new System.EventHandler(this.QAdd_Click);
            // 
            // QBox
            // 
            this.QBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 14;
            this.QBox.Location = new System.Drawing.Point(300, 78);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(140, 86);
            this.QBox.TabIndex = 41;
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(7, 72);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(286, 350);
            this.resultBox.TabIndex = 49;
            this.resultBox.Text = "";
            this.resultBox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(300, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 50;
            this.label3.Text = "Genauigkeit";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // precControl
            // 
            this.precControl.Location = new System.Drawing.Point(373, 299);
            this.precControl.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.precControl.Name = "precControl";
            this.precControl.Size = new System.Drawing.Size(34, 20);
            this.precControl.TabIndex = 51;
            this.precControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.precControl.ValueChanged += new System.EventHandler(this.precControl_ValueChanged);
            // 
            // AvgBox
            // 
            this.AvgBox.Checked = true;
            this.AvgBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AvgBox.Location = new System.Drawing.Point(307, 318);
            this.AvgBox.Name = "AvgBox";
            this.AvgBox.Size = new System.Drawing.Size(73, 20);
            this.AvgBox.TabIndex = 52;
            this.AvgBox.Text = "Mittelwert";
            this.AvgBox.CheckedChanged += new System.EventHandler(this.AvgBox_CheckedChanged);
            // 
            // AvgMedian
            // 
            this.AvgMedian.Location = new System.Drawing.Point(307, 338);
            this.AvgMedian.Name = "AvgMedian";
            this.AvgMedian.Size = new System.Drawing.Size(73, 20);
            this.AvgMedian.TabIndex = 53;
            this.AvgMedian.Text = "Median";
            this.AvgMedian.CheckedChanged += new System.EventHandler(this.AvgMedian_CheckedChanged);
            // 
            // PcntBox
            // 
            this.PcntBox.Location = new System.Drawing.Point(380, 318);
            this.PcntBox.Name = "PcntBox";
            this.PcntBox.Size = new System.Drawing.Size(73, 20);
            this.PcntBox.TabIndex = 54;
            this.PcntBox.Text = "Prozente";
            this.PcntBox.CheckedChanged += new System.EventHandler(this.PcntBox_CheckedChanged);
            // 
            // OutputFormAverages
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(602, 534);
            this.Controls.Add(this.PcntBox);
            this.Controls.Add(this.AvgMedian);
            this.Controls.Add(this.AvgBox);
            this.Controls.Add(this.precControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.crossPanel);
            this.Controls.Add(this.PersonPanel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QRemove);
            this.Controls.Add(this.QAdd);
            this.Controls.Add(this.QBox);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "OutputFormAverages";
            this.Text = "Einzelauswertung";
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precControl)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private Question[] getList()
		{
			Question[] qs = new Question[QBox.Items.Count];				

			int i = 0;
			foreach (Question q in QBox.Items)
				qs[i++] = q;

			return qs;
		}

		private void Preview()
		{
			if (QBox.Items.Count > 0)
			{
				avg.Questions = getList();
				avg.PersonList = cpp.SelectedPersons;
				avg.ComboList = cpp.SelectedCombos;
				avg.eval = eval;
				avg.Precision = (int)precControl.Value;
				avg.Cross = cross.Cross;

				avg.Compute();

				//previewBox.SmallPreview = previewBox.BigPreview = gap.OutputImage;

				resultBox.Text = avg.ResultTable;
			}
		}

		private void QAdd_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				foreach (Question q in qs.SelectedQuestions)
					QBox.Items.Add(q);
			}
			Preview();
		}

		private void QRemove_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < QBox.SelectedItems.Count; i++)
			{
				QBox.Items.Remove(QBox.SelectedItems[i]);
			}
			Preview();
		}

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			if (QBox.Items.Count > 0)
			{
			}
			
			if (single && QBox.Items.Count > 0)
			{
				SaveDialog sd = new SaveDialog(avg);
				sd.ShowDialog();
			}
			else
			{
				Close();
				this.DialogResult = DialogResult.OK;
			}
		}

		private void sizeControl_ChosenSizeChanged()
		{
			Preview();
		}

		private void cpp_SelectionChanged()
		{
			Preview();
		}

		private void EndButton_Click(object sender, System.EventArgs e)
		{
		
		}

		private void precControl_ValueChanged(object sender, System.EventArgs e)
		{
			Preview();
		}

		private void AvgBox_CheckedChanged(object sender, System.EventArgs e)
		{
			avg.average = AvgBox.Checked;
			Preview();
		}

		private void AvgMedian_CheckedChanged(object sender, System.EventArgs e)
		{
			avg.median = AvgMedian.Checked;
			Preview();
		}

		private void PcntBox_CheckedChanged(object sender, System.EventArgs e)
		{
			avg.percent = PcntBox.Checked;
			Preview();
		}

		private void cross_CrossChanged()
		{
			avg.Cross = cross.cross;
		}
	}
}

