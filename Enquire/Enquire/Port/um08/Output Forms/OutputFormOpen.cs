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
	public class OutputFormOpen : DialogTemplate
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
		private System.ComponentModel.IContainer components = null;

		public Open open;
		private Evaluation eval;
		private bool single;

		private ChoosePersonControl cpp;
		private System.Windows.Forms.CheckBox GroupAnswersBox;
		private Crossing cross;

		public OutputFormOpen(Evaluation eval)
		{
            Set(eval, true, new Open(eval));
		}

		public OutputFormOpen(Evaluation eval, bool single)
		{
            Set(eval, single, new Open(eval));
		}

		public OutputFormOpen(Evaluation eval, bool single, Open avg)
		{
			Set(eval, single, avg);

			EndButton.Visible = false;
			
			//question lists

			foreach (Question q in avg.Questions)
				QBox.Items.Add(q);

			cpp.SetSelection(avg.PersonList, avg.ComboList);

			Preview();
		}

		private void Set(Evaluation eval, bool single, Open avg)
		{
			this.eval = eval;
			this.single = single;
			
			avg.eval = eval;

			this.open = avg;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputFormOpen));
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
            this.GroupAnswersBox = new System.Windows.Forms.CheckBox();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.HeaderPanel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 18F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(53, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Offene Fragen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 45);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(293, 72);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(194, 38);
            this.crossPanel.TabIndex = 69;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Location = new System.Drawing.Point(300, 110);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(187, 78);
            this.PersonPanel.TabIndex = 68;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LightGray;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Location = new System.Drawing.Point(300, 266);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(187, 26);
            this.SaveButton.TabIndex = 67;
            this.SaveButton.Text = "Speichern...";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.BackColor = System.Drawing.Color.LightGray;
            this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndButton.Location = new System.Drawing.Point(300, 234);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(187, 26);
            this.EndButton.TabIndex = 66;
            this.EndButton.Text = "Schliessen";
            this.EndButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 26);
            this.label2.TabIndex = 65;
            this.label2.Text = "Fragen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.LightGray;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(7, 130);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(26, 26);
            this.QRemove.TabIndex = 64;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new System.EventHandler(this.QRemove_Click);
            // 
            // QAdd
            // 
            this.QAdd.BackColor = System.Drawing.Color.LightGray;
            this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QAdd.Location = new System.Drawing.Point(7, 98);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new System.Drawing.Size(26, 26);
            this.QAdd.TabIndex = 63;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            this.QAdd.Click += new System.EventHandler(this.QAdd_Click);
            // 
            // QBox
            // 
            this.QBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 14;
            this.QBox.Location = new System.Drawing.Point(47, 72);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(226, 212);
            this.QBox.TabIndex = 62;
            // 
            // GroupAnswersBox
            // 
            this.GroupAnswersBox.Location = new System.Drawing.Point(300, 208);
            this.GroupAnswersBox.Name = "GroupAnswersBox";
            this.GroupAnswersBox.Size = new System.Drawing.Size(187, 20);
            this.GroupAnswersBox.TabIndex = 70;
            this.GroupAnswersBox.Text = "Antworten gruppieren";
            this.GroupAnswersBox.CheckedChanged += new System.EventHandler(this.GroupAnswersBox_CheckedChanged);
            // 
            // OutputFormOpen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(602, 369);
            this.Controls.Add(this.GroupAnswersBox);
            this.Controls.Add(this.crossPanel);
            this.Controls.Add(this.PersonPanel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QRemove);
            this.Controls.Add(this.QAdd);
            this.Controls.Add(this.QBox);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "OutputFormOpen";
            this.Text = "Einzelauswertung";
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
			open.ComboList = cpp.SelectedCombos;
			open.PersonList = cpp.SelectedPersons;
			open.Questions = getList();
			open.eval = eval;
			open.Cross = cross.Cross;
			//open.Group = this.GroupAnswersBox.Checked;
		}

		private void cpp_SelectionChanged()
		{
			Preview();
		}

		private void QAdd_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval, "text");
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
				SaveDialog sd = new SaveDialog(open);
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
			open.Cross = cross.cross;
		}

		private void GroupAnswersBox_CheckedChanged(object sender, System.EventArgs e)
		{
			//open.Group = GroupAnswersBox.Checked;
		}
	}
}

