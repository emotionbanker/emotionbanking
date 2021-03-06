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
	public class OutputFormGaps : DialogTemplate
	{
		private System.Windows.Forms.Panel HeaderPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button QRemove;
		private System.Windows.Forms.Button QAdd;
		private System.Windows.Forms.ListBox QBox;
		private System.Windows.Forms.Panel crossPanel;
		private System.Windows.Forms.Panel PersonPanel;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button EndButton;
		private System.ComponentModel.IContainer components = null;

		public Gaps gap;
		private Evaluation eval;
		private bool single;

		private ChoosePersonControl cpp;
		private System.Windows.Forms.RichTextBox resultBox;
		private System.Windows.Forms.Button OverloadButton;
		private System.Windows.Forms.CheckBox saveImages;

		private Crossing cross;

		public OutputFormGaps(Evaluation eval)
		{
            Set(eval, true, new Gaps(eval));
		}

		public OutputFormGaps(Evaluation eval, bool single)
		{
            Set(eval, single, new Gaps(eval));
		}

		public OutputFormGaps(Evaluation eval, bool single, Gaps gap)
		{
			Set(eval, single, gap);

			EndButton.Visible = false;
			
			cpp.SetSelection(gap.PersonList, gap.ComboList);

			//question lists

			foreach (Question q in gap.Questions)
				QBox.Items.Add(q);

			Preview();
		}

		private void Set(Evaluation eval, bool single, Gaps gap)
		{
			this.eval = eval;
			this.single = single;
			this.gap = gap;

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

			cross.UpdateCross(gap.Cross);

			OutputNameControl onc = new OutputNameControl(gap);
			onc.Location = new Point(380,16);
			HeaderPanel.Controls.Add(onc);

			if (!single)
			{
				SaveButton.Text = "OK";
				EndButton.Text = "Abbrechen";
				saveImages.Visible = false;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OutputFormGaps));
			this.HeaderPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.QRemove = new System.Windows.Forms.Button();
			this.QAdd = new System.Windows.Forms.Button();
			this.QBox = new System.Windows.Forms.ListBox();
			this.crossPanel = new System.Windows.Forms.Panel();
			this.PersonPanel = new System.Windows.Forms.Panel();
			this.SaveButton = new System.Windows.Forms.Button();
			this.EndButton = new System.Windows.Forms.Button();
			this.resultBox = new System.Windows.Forms.RichTextBox();
			this.OverloadButton = new System.Windows.Forms.Button();
			this.saveImages = new System.Windows.Forms.CheckBox();
			this.HeaderPanel.SuspendLayout();
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
			this.HeaderPanel.Size = new System.Drawing.Size(602, 80);
			this.HeaderPanel.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Arial", 18F);
			this.label1.ForeColor = System.Drawing.Color.Gray;
			this.label1.Location = new System.Drawing.Point(88, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 48);
			this.label1.TabIndex = 1;
			this.label1.Text = "Gaps";
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
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(536, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 32);
			this.label2.TabIndex = 35;
			this.label2.Text = "Fragen";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// QRemove
			// 
			this.QRemove.BackColor = System.Drawing.Color.LightGray;
			this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.QRemove.Location = new System.Drawing.Point(544, 176);
			this.QRemove.Name = "QRemove";
			this.QRemove.Size = new System.Drawing.Size(32, 32);
			this.QRemove.TabIndex = 34;
			this.QRemove.Text = "-";
			this.QRemove.Click += new System.EventHandler(this.QRemove_Click);
			// 
			// QAdd
			// 
			this.QAdd.BackColor = System.Drawing.Color.LightGray;
			this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.QAdd.Location = new System.Drawing.Point(544, 136);
			this.QAdd.Name = "QAdd";
			this.QAdd.Size = new System.Drawing.Size(32, 32);
			this.QAdd.TabIndex = 33;
			this.QAdd.Text = "+";
			this.QAdd.Click += new System.EventHandler(this.QAdd_Click);
			// 
			// QBox
			// 
			this.QBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.QBox.HorizontalScrollbar = true;
			this.QBox.ItemHeight = 16;
			this.QBox.Location = new System.Drawing.Point(360, 96);
			this.QBox.Name = "QBox";
			this.QBox.Size = new System.Drawing.Size(168, 114);
			this.QBox.TabIndex = 32;
			// 
			// crossPanel
			// 
			this.crossPanel.Location = new System.Drawing.Point(352, 256);
			this.crossPanel.Name = "crossPanel";
			this.crossPanel.Size = new System.Drawing.Size(232, 48);
			this.crossPanel.TabIndex = 40;
			// 
			// PersonPanel
			// 
			this.PersonPanel.Location = new System.Drawing.Point(360, 304);
			this.PersonPanel.Name = "PersonPanel";
			this.PersonPanel.Size = new System.Drawing.Size(224, 160);
			this.PersonPanel.TabIndex = 39;
			// 
			// SaveButton
			// 
			this.SaveButton.BackColor = System.Drawing.Color.LightGray;
			this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.SaveButton.Location = new System.Drawing.Point(368, 520);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(216, 32);
			this.SaveButton.TabIndex = 37;
			this.SaveButton.Text = "Speichern...";
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// EndButton
			// 
			this.EndButton.BackColor = System.Drawing.Color.LightGray;
			this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.EndButton.Location = new System.Drawing.Point(368, 480);
			this.EndButton.Name = "EndButton";
			this.EndButton.Size = new System.Drawing.Size(216, 32);
			this.EndButton.TabIndex = 36;
			this.EndButton.Text = "Schliessen";
			// 
			// resultBox
			// 
			this.resultBox.Location = new System.Drawing.Point(8, 88);
			this.resultBox.Name = "resultBox";
			this.resultBox.ReadOnly = true;
			this.resultBox.Size = new System.Drawing.Size(344, 424);
			this.resultBox.TabIndex = 42;
			this.resultBox.Text = "";
			this.resultBox.WordWrap = false;
			// 
			// OverloadButton
			// 
			this.OverloadButton.BackColor = System.Drawing.Color.LightGray;
			this.OverloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.OverloadButton.Location = new System.Drawing.Point(368, 216);
			this.OverloadButton.Name = "OverloadButton";
			this.OverloadButton.Size = new System.Drawing.Size(216, 32);
			this.OverloadButton.TabIndex = 45;
			this.OverloadButton.Text = "Beschriftungen";
			this.OverloadButton.Click += new System.EventHandler(this.OverloadButton_Click);
			// 
			// saveImages
			// 
			this.saveImages.Checked = true;
			this.saveImages.CheckState = System.Windows.Forms.CheckState.Checked;
			this.saveImages.Location = new System.Drawing.Point(8, 520);
			this.saveImages.Name = "saveImages";
			this.saveImages.Size = new System.Drawing.Size(344, 32);
			this.saveImages.TabIndex = 46;
			this.saveImages.Text = "Mit Grafiken speichern";
			// 
			// OutputFormGaps
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(602, 566);
			this.Controls.Add(this.saveImages);
			this.Controls.Add(this.OverloadButton);
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
			this.Name = "OutputFormGaps";
			this.Text = "Einzelauswertung";
			this.HeaderPanel.ResumeLayout(false);
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
				gap.Questions = getList();
				gap.PersonList = cpp.SelectedPersons;
				gap.ComboList = cpp.SelectedCombos;
				gap.eval = eval;
				gap.Cross = cross.Cross;

				if (!single || !saveImages.Checked)
					gap.Images = false;
				else
					gap.Images = true;

				gap.Compute();

				//previewBox.SmallPreview = previewBox.BigPreview = gap.OutputImage;

				resultBox.Text = gap.ResultTable;
			}
		}

		private void QAdd_Click(object sender,  System.EventArgs e)
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
				SaveDialog sd = new SaveDialog(gap);
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

		private void cross_CrossChanged()
		{
			gap.Cross = cross.cross;
		}

		private void OverloadButton_Click(object sender, System.EventArgs e)
		{
			DialogTextOverload dto = new DialogTextOverload(eval, getList());
			dto.ShowDialog();

			Preview();
		}
	}
}

