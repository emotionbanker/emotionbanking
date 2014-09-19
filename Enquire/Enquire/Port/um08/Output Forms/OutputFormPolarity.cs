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
	public class OutputFormPolarity : DialogTemplate
	{
		private System.Windows.Forms.Button OverloadButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button QRemove;
		private System.Windows.Forms.Button QAdd;
		private System.Windows.Forms.ListBox QBox;
		private PreviewControl previewBox;
		private System.Windows.Forms.Panel crossPanel;
		private System.Windows.Forms.Panel PersonPanel;
		private SizeControl sizeControl;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button EndButton;
		private System.Windows.Forms.Panel HeaderPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.IContainer components = null;

		public Polarity pol;
		private Evaluation eval;
		public bool single;

		private ChoosePersonControl cpp;
		private System.Windows.Forms.FontDialog ValueFontDialog;
		private System.Windows.Forms.Button ValueFontButton;
		private System.Windows.Forms.Button QFontButton;
		private System.Windows.Forms.FontDialog QFontDialog;
        private Button BColorAButton;
        private Panel BColorAPanel;
        private Button BColorBButton;
        private Panel BColorBPanel;
        private ColorDialog colorDialog;
		private Crossing cross;

		public OutputFormPolarity(Evaluation eval)
		{
			Set(eval, true, new Polarity(eval));
		}

		public OutputFormPolarity(Evaluation eval, bool single)
		{
			Set(eval, single, new Polarity(eval));
		}

		public OutputFormPolarity(Evaluation eval, bool single, Polarity pol)
		{
			Set(eval, single, pol);

			EndButton.Visible = false;
			
			cpp.SetSelection(pol.PersonList, pol.ComboList);

			sizeControl.SetSize(pol.width, pol.height);

			//question lists

			foreach (Question q in pol.Questions)
				QBox.Items.Add(q);

			Preview();
		}

		private void Set(Evaluation eval, bool single, Polarity pol)
		{
			this.eval = eval;
			this.single = single;

			this.pol = pol;

			InitializeComponent();

			sizeControl.SetDefaultSize(1000, 100);

			this.CancelButton = EndButton;

			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			PersonPanel.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(pol.Cross);

			OutputNameControl onc = new OutputNameControl(pol);
			onc.Location = new Point(380,16);
			HeaderPanel.Controls.Add(onc);

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_ChosenSizeChanged);

			if (!single)
			{
				SaveButton.Text = "OK";
				EndButton.Text = "Abbrechen";
			}

			ValueFontDialog.Font = pol.ValueFont;
			QFontDialog.Font = pol.QFont;

            BColorAPanel.BackColor = pol.BackColorA;
            BColorBPanel.BackColor = pol.BackColorB;
		}
		
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
				pol.imagesonly = true;
				pol.eval = eval;
				pol.Cross = cross.Cross;
				pol.width = previewBox.Width;
				pol.height = previewBox.Height - 30;
				pol.PersonList = cpp.SelectedPersons;
				pol.ComboList = cpp.SelectedCombos;
				
				pol.Questions = getList();

				pol.Compute();

				previewBox.SmallPreview = pol.OutputImage;

				pol.imagesonly = false;
				pol.width = sizeControl.ChosenWidth;
				pol.height = sizeControl.ChosenHeight;

				pol.Compute();

				previewBox.BigPreview = pol.OutputImage;
			}
			else
				previewBox.SmallPreview = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputFormPolarity));
            this.OverloadButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.QRemove = new System.Windows.Forms.Button();
            this.QAdd = new System.Windows.Forms.Button();
            this.QBox = new System.Windows.Forms.ListBox();
            this.previewBox = new PreviewControl();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.sizeControl = new SizeControl();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EndButton = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ValueFontDialog = new System.Windows.Forms.FontDialog();
            this.ValueFontButton = new System.Windows.Forms.Button();
            this.QFontButton = new System.Windows.Forms.Button();
            this.QFontDialog = new System.Windows.Forms.FontDialog();
            this.BColorAButton = new System.Windows.Forms.Button();
            this.BColorAPanel = new System.Windows.Forms.Panel();
            this.BColorBButton = new System.Windows.Forms.Button();
            this.BColorBPanel = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OverloadButton
            // 
            this.OverloadButton.BackColor = System.Drawing.Color.LightGray;
            this.OverloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OverloadButton.Location = new System.Drawing.Point(376, 224);
            this.OverloadButton.Name = "OverloadButton";
            this.OverloadButton.Size = new System.Drawing.Size(216, 32);
            this.OverloadButton.TabIndex = 44;
            this.OverloadButton.Text = "Beschriftungen";
            this.OverloadButton.UseVisualStyleBackColor = false;
            this.OverloadButton.Click += new System.EventHandler(this.OverloadButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(544, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 32);
            this.label2.TabIndex = 43;
            this.label2.Text = "Fragen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = System.Drawing.Color.LightGray;
            this.QRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QRemove.Location = new System.Drawing.Point(552, 176);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new System.Drawing.Size(32, 32);
            this.QRemove.TabIndex = 42;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new System.EventHandler(this.QRemove_Click_1);
            // 
            // QAdd
            // 
            this.QAdd.BackColor = System.Drawing.Color.LightGray;
            this.QAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QAdd.Location = new System.Drawing.Point(552, 136);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new System.Drawing.Size(32, 32);
            this.QAdd.TabIndex = 41;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            this.QAdd.Click += new System.EventHandler(this.QAdd_Click_1);
            // 
            // QBox
            // 
            this.QBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 16;
            this.QBox.Location = new System.Drawing.Point(368, 96);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(168, 114);
            this.QBox.TabIndex = 40;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Gainsboro;
            this.previewBox.Location = new System.Drawing.Point(8, 96);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(352, 527);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 34;
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(360, 264);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(232, 48);
            this.crossPanel.TabIndex = 39;
            // 
            // PersonPanel
            // 
            this.PersonPanel.Location = new System.Drawing.Point(368, 312);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(224, 96);
            this.PersonPanel.TabIndex = 38;
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Gainsboro;
            this.sizeControl.Location = new System.Drawing.Point(488, 416);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(104, 56);
            this.sizeControl.TabIndex = 37;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LightGray;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Location = new System.Drawing.Point(376, 591);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(216, 32);
            this.SaveButton.TabIndex = 36;
            this.SaveButton.Text = "Speichern...";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.BackColor = System.Drawing.Color.LightGray;
            this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndButton.Location = new System.Drawing.Point(376, 551);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(216, 32);
            this.EndButton.TabIndex = 35;
            this.EndButton.Text = "Schliessen";
            this.EndButton.UseVisualStyleBackColor = false;
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
            this.HeaderPanel.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 18F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(72, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Polaritäten";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ValueFontButton
            // 
            this.ValueFontButton.BackColor = System.Drawing.Color.LightGray;
            this.ValueFontButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ValueFontButton.Location = new System.Drawing.Point(368, 416);
            this.ValueFontButton.Name = "ValueFontButton";
            this.ValueFontButton.Size = new System.Drawing.Size(112, 24);
            this.ValueFontButton.TabIndex = 45;
            this.ValueFontButton.Text = "Werte...";
            this.ValueFontButton.UseVisualStyleBackColor = false;
            this.ValueFontButton.Click += new System.EventHandler(this.ValueFontButton_Click);
            // 
            // QFontButton
            // 
            this.QFontButton.BackColor = System.Drawing.Color.LightGray;
            this.QFontButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QFontButton.Location = new System.Drawing.Point(368, 448);
            this.QFontButton.Name = "QFontButton";
            this.QFontButton.Size = new System.Drawing.Size(112, 24);
            this.QFontButton.TabIndex = 46;
            this.QFontButton.Text = "Text...";
            this.QFontButton.UseVisualStyleBackColor = false;
            this.QFontButton.Click += new System.EventHandler(this.QFontButton_Click);
            // 
            // BColorAButton
            // 
            this.BColorAButton.BackColor = System.Drawing.Color.LightGray;
            this.BColorAButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BColorAButton.Location = new System.Drawing.Point(477, 487);
            this.BColorAButton.Name = "BColorAButton";
            this.BColorAButton.Size = new System.Drawing.Size(115, 24);
            this.BColorAButton.TabIndex = 51;
            this.BColorAButton.Text = "Hintergrund 1...";
            this.BColorAButton.UseVisualStyleBackColor = false;
            this.BColorAButton.Click += new System.EventHandler(this.BColorAButton_Click);
            // 
            // BColorAPanel
            // 
            this.BColorAPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BColorAPanel.Location = new System.Drawing.Point(376, 487);
            this.BColorAPanel.Name = "BColorAPanel";
            this.BColorAPanel.Size = new System.Drawing.Size(95, 24);
            this.BColorAPanel.TabIndex = 50;
            // 
            // BColorBButton
            // 
            this.BColorBButton.BackColor = System.Drawing.Color.LightGray;
            this.BColorBButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BColorBButton.Location = new System.Drawing.Point(477, 517);
            this.BColorBButton.Name = "BColorBButton";
            this.BColorBButton.Size = new System.Drawing.Size(115, 24);
            this.BColorBButton.TabIndex = 53;
            this.BColorBButton.Text = "Hintergrund 2...";
            this.BColorBButton.UseVisualStyleBackColor = false;
            this.BColorBButton.Click += new System.EventHandler(this.BColorBButton_Click);
            // 
            // BColorBPanel
            // 
            this.BColorBPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BColorBPanel.Location = new System.Drawing.Point(376, 517);
            this.BColorBPanel.Name = "BColorBPanel";
            this.BColorBPanel.Size = new System.Drawing.Size(95, 24);
            this.BColorBPanel.TabIndex = 52;
            // 
            // OutputFormPolarity
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(602, 627);
            this.Controls.Add(this.BColorBButton);
            this.Controls.Add(this.BColorBPanel);
            this.Controls.Add(this.BColorAButton);
            this.Controls.Add(this.BColorAPanel);
            this.Controls.Add(this.QFontButton);
            this.Controls.Add(this.ValueFontButton);
            this.Controls.Add(this.OverloadButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QRemove);
            this.Controls.Add(this.QAdd);
            this.Controls.Add(this.QBox);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.crossPanel);
            this.Controls.Add(this.PersonPanel);
            this.Controls.Add(this.sizeControl);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "OutputFormPolarity";
            this.Text = "Einzelauswertung";
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		private void sizeControl_ChosenSizeChanged()
		{
			Preview();
		}

		private void cpp_SelectionChanged()
		{
			Preview();
		}

		private void QAdd_Click_1(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				foreach (Question q in qs.SelectedQuestions)
					QBox.Items.Add(q);
			}
			Preview();
		}

		private void QRemove_Click_1(object sender, System.EventArgs e)
		{
			for (int i = 0; i < QBox.SelectedItems.Count; i++)
			{
				QBox.Items.Remove(QBox.SelectedItems[i]);
			}
			Preview();
		}

		private void OverloadButton_Click(object sender, System.EventArgs e)
		{
			DialogTextOverload dto = new DialogTextOverload(eval, getList());
			dto.ShowDialog();

			Preview();
		}

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			if (QBox.Items.Count > 0)
			{
				pol.imagesonly = false;
				pol.eval = eval;
				pol.Cross = cross.Cross;
				pol.width = sizeControl.ChosenWidth;
				pol.height = sizeControl.ChosenHeight;
				pol.PersonList = cpp.SelectedPersons;
				pol.ComboList = cpp.SelectedCombos;
				
				pol.Questions = getList();
			}

			if (single && QBox.Items.Count > 0)
			{
				SaveDialog sd = new SaveDialog(pol);
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
			pol.Cross = cross.cross;
		}

		private void ValueFontButton_Click(object sender, System.EventArgs e)
		{
			if (ValueFontDialog.ShowDialog() == DialogResult.OK)
				pol.ValueFont = ValueFontDialog.Font;

			Preview();
		}

		private void QFontButton_Click(object sender, System.EventArgs e)
		{
			if (QFontDialog.ShowDialog() == DialogResult.OK)
				pol.QFont = QFontDialog.Font;

			Preview();
		}

        private void BColorAButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = pol.BackColorA;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pol.BackColorA = colorDialog.Color;
                BColorAPanel.BackColor = pol.BackColorA;
                Preview();
            }
        }

        private void BColorBButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = pol.BackColorB;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pol.BackColorB = colorDialog.Color;
                BColorBPanel.BackColor = pol.BackColorB;
                Preview();
            }
        }
	}
}

