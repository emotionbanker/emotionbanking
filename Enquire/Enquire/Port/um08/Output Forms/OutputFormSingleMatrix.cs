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
	public class OutputFormSingleMatrix : DialogTemplate
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Panel HeaderPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button EndButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button HorizontalButton;
		private System.Windows.Forms.Label HorizontalLabel;
		
		private System.Windows.Forms.Button VerticalButton;
		private System.Windows.Forms.Label label4;

		private Evaluation eval;

		private Question horizontal;
		private System.Windows.Forms.Label VerticalLabel;
		private System.Windows.Forms.Button SaveButton;
		private Question vertical;
		private SizeControl sizeControl;
		private ChoosePersonControl cpp;
		private Crossing cross;
		public  SingleMatrix sm;
		private System.Windows.Forms.Panel PersonPanel;
		private System.Windows.Forms.Panel crossPanel;



		private bool single;
		private PreviewControl previewBox;
		private System.Windows.Forms.CheckBox ArrowBox;
		private System.Windows.Forms.ComboBox StyleBox;
		private System.Windows.Forms.CheckBox LegendBox;
		private System.Windows.Forms.ComboBox PrecBox;
        private System.Windows.Forms.ComboBox Skalabox;
        //private ComboBox Skalabox;

		private OutputNameControl onc;

		public OutputFormSingleMatrix(Evaluation eval, bool single)
		{
			Set(eval, single, new SingleMatrix(eval));
			ArrowBox.Checked = sm.DrawArrow;

			LegendBox.Checked = sm.Legend;

			StyleBox.SelectedIndex = sm.Style;

			PrecBox.SelectedIndex = sm.Precision;

            Skalabox.SelectedIndex = sm.Skala;
            
            
		}

		public OutputFormSingleMatrix(Evaluation eval, bool single, SingleMatrix smatrix)
		{
			Set(eval, single, smatrix);

			EndButton.Visible = false;

			try
			{
				horizontal = smatrix.h;
				HorizontalLabel.Text = horizontal.SID;
			}
			catch{}
			
			try
			{
				vertical = smatrix.v;
				VerticalLabel.Text = vertical.SID;
			}
			catch{}

			cpp.SetSelection(smatrix.PersonList, smatrix.ComboList);

			sizeControl.SetSize(smatrix.width, smatrix.height);

			ArrowBox.Checked = sm.DrawArrow;

			LegendBox.Checked = sm.Legend;

			StyleBox.SelectedIndex = sm.Style;

			PrecBox.SelectedIndex = sm.Precision;

            Skalabox.SelectedIndex = sm.Skala;
			Preview();
		}

		private void Set(Evaluation eval, bool single, SingleMatrix smatrix)
		{
			this.eval = eval;
			this.single = single;

			sm = smatrix;

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

			cross.UpdateCross(sm.Cross);

			onc = new OutputNameControl(sm);
			onc.Location = new Point(380,16);
			HeaderPanel.Controls.Add(onc);

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_ChosenSizeChanged);

			if (!single)
			{
				SaveButton.Text = "OK";
				EndButton.Text = "Abbrechen";
			}

			StyleBox.Items.Clear();
			StyleBox.Items.Add("4 Verläufe");
			StyleBox.Items.Add("Victor 05");
			StyleBox.Items.Add("Kegel");
			StyleBox.Items.Add("Balken");

			PrecBox.Items.Clear();
			PrecBox.Items.Add("3x3");
			PrecBox.Items.Add("5x5");

            Skalabox.Items.Clear();
            Skalabox.Items.Add("12-3-45");
            Skalabox.Items.Add("1-2-345");
            Skalabox.Items.Add("1-23-45");
            Skalabox.Items.Add("1-234-5");
            Skalabox.Items.Add("12-34-5");
            Skalabox.Items.Add("123-4-5");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputFormSingleMatrix));
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EndButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.HorizontalLabel = new System.Windows.Forms.Label();
            this.HorizontalButton = new System.Windows.Forms.Button();
            this.VerticalButton = new System.Windows.Forms.Button();
            this.VerticalLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.sizeControl = new compucare.Enquire.Legacy.Umfrage2Lib.Controls.SizeControl();
            this.PersonPanel = new System.Windows.Forms.Panel();
            this.crossPanel = new System.Windows.Forms.Panel();
            this.previewBox = new compucare.Enquire.Legacy.Umfrage2Lib.Controls.PreviewControl();
            this.ArrowBox = new System.Windows.Forms.CheckBox();
            this.StyleBox = new System.Windows.Forms.ComboBox();
            this.LegendBox = new System.Windows.Forms.CheckBox();
            this.PrecBox = new System.Windows.Forms.ComboBox();
            this.Skalabox = new System.Windows.Forms.ComboBox();
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
            this.HeaderPanel.Size = new System.Drawing.Size(618, 65);
            this.HeaderPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 18F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(67, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prozentmatrix";
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
            // EndButton
            // 
            this.EndButton.BackColor = System.Drawing.Color.LightGray;
            this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndButton.Location = new System.Drawing.Point(313, 354);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(180, 26);
            this.EndButton.TabIndex = 7;
            this.EndButton.Text = "Schliessen";
            this.EndButton.UseVisualStyleBackColor = false;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(300, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Horizontal:";
            // 
            // HorizontalLabel
            // 
            this.HorizontalLabel.Location = new System.Drawing.Point(367, 78);
            this.HorizontalLabel.Name = "HorizontalLabel";
            this.HorizontalLabel.Size = new System.Drawing.Size(33, 19);
            this.HorizontalLabel.TabIndex = 11;
            this.HorizontalLabel.Text = "?";
            // 
            // HorizontalButton
            // 
            this.HorizontalButton.BackColor = System.Drawing.Color.LightGray;
            this.HorizontalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HorizontalButton.Location = new System.Drawing.Point(407, 72);
            this.HorizontalButton.Name = "HorizontalButton";
            this.HorizontalButton.Size = new System.Drawing.Size(86, 26);
            this.HorizontalButton.TabIndex = 10;
            this.HorizontalButton.Text = "ändern...";
            this.HorizontalButton.UseVisualStyleBackColor = false;
            this.HorizontalButton.Click += new System.EventHandler(this.HorizontalButton_Click);
            // 
            // VerticalButton
            // 
            this.VerticalButton.BackColor = System.Drawing.Color.LightGray;
            this.VerticalButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VerticalButton.Location = new System.Drawing.Point(407, 98);
            this.VerticalButton.Name = "VerticalButton";
            this.VerticalButton.Size = new System.Drawing.Size(86, 26);
            this.VerticalButton.TabIndex = 13;
            this.VerticalButton.Text = "ändern...";
            this.VerticalButton.UseVisualStyleBackColor = false;
            this.VerticalButton.Click += new System.EventHandler(this.VerticalButton_Click);
            // 
            // VerticalLabel
            // 
            this.VerticalLabel.Location = new System.Drawing.Point(367, 104);
            this.VerticalLabel.Name = "VerticalLabel";
            this.VerticalLabel.Size = new System.Drawing.Size(33, 19);
            this.VerticalLabel.TabIndex = 14;
            this.VerticalLabel.Text = "?";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(313, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Vertikal:";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.LightGray;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Location = new System.Drawing.Point(313, 386);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(180, 26);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Speichern...";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // sizeControl
            // 
            this.sizeControl.BackColor = System.Drawing.Color.Gainsboro;
            this.sizeControl.Location = new System.Drawing.Point(407, 247);
            this.sizeControl.Name = "sizeControl";
            this.sizeControl.Size = new System.Drawing.Size(86, 45);
            this.sizeControl.TabIndex = 17;
            this.sizeControl.Load += new System.EventHandler(this.sizeControl_Load);
            // 
            // PersonPanel
            // 
            this.PersonPanel.Location = new System.Drawing.Point(307, 162);
            this.PersonPanel.Name = "PersonPanel";
            this.PersonPanel.Size = new System.Drawing.Size(186, 78);
            this.PersonPanel.TabIndex = 18;
            // 
            // crossPanel
            // 
            this.crossPanel.Location = new System.Drawing.Point(300, 124);
            this.crossPanel.Name = "crossPanel";
            this.crossPanel.Size = new System.Drawing.Size(193, 38);
            this.crossPanel.TabIndex = 19;
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Gainsboro;
            this.previewBox.Location = new System.Drawing.Point(7, 78);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(293, 334);
            this.previewBox.SmallPreview = null;
            this.previewBox.TabIndex = 0;
            // 
            // ArrowBox
            // 
            this.ArrowBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArrowBox.Location = new System.Drawing.Point(313, 247);
            this.ArrowBox.Name = "ArrowBox";
            this.ArrowBox.Size = new System.Drawing.Size(94, 19);
            this.ArrowBox.TabIndex = 20;
            this.ArrowBox.Text = "Pfeile";
            this.ArrowBox.CheckedChanged += new System.EventHandler(this.ArrowBox_CheckedChanged);
            // 
            // StyleBox
            // 
            this.StyleBox.Location = new System.Drawing.Point(313, 299);
            this.StyleBox.Name = "StyleBox";
            this.StyleBox.Size = new System.Drawing.Size(87, 22);
            this.StyleBox.TabIndex = 21;
            this.StyleBox.SelectedIndexChanged += new System.EventHandler(this.StyleBox_SelectedIndexChanged);
            // 
            // LegendBox
            // 
            this.LegendBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LegendBox.Location = new System.Drawing.Point(313, 266);
            this.LegendBox.Name = "LegendBox";
            this.LegendBox.Size = new System.Drawing.Size(94, 20);
            this.LegendBox.TabIndex = 22;
            this.LegendBox.Text = "Beschriftung";
            this.LegendBox.CheckedChanged += new System.EventHandler(this.LegendBox_CheckedChanged);
            // 
            // PrecBox
            // 
            this.PrecBox.Location = new System.Drawing.Point(407, 299);
            this.PrecBox.Name = "PrecBox";
            this.PrecBox.Size = new System.Drawing.Size(86, 22);
            this.PrecBox.TabIndex = 23;
            this.PrecBox.SelectedIndexChanged += new System.EventHandler(this.PrecBox_SelectedIndexChanged);
            // 
            // Skalabox
            // 
            this.Skalabox.Location = new System.Drawing.Point(313, 326);
            this.Skalabox.Name = "Skalabox";
            this.Skalabox.Size = new System.Drawing.Size(87, 22);
            this.Skalabox.TabIndex = 24;
            // 
            // OutputFormSingleMatrix
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(618, 486);
            this.Controls.Add(this.Skalabox);
            this.Controls.Add(this.PrecBox);
            this.Controls.Add(this.LegendBox);
            this.Controls.Add(this.StyleBox);
            this.Controls.Add(this.ArrowBox);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.crossPanel);
            this.Controls.Add(this.PersonPanel);
            this.Controls.Add(this.sizeControl);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.VerticalButton);
            this.Controls.Add(this.VerticalLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HorizontalButton);
            this.Controls.Add(this.HorizontalLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "OutputFormSingleMatrix";
            this.Text = "Einzelauswertung";
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void HorizontalButton_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				horizontal = qs.SelectedQuestion;
				HorizontalLabel.Text = horizontal.SID;

				Preview();
			}
		}

		private void VerticalButton_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				vertical = qs.SelectedQuestion;
				VerticalLabel.Text = vertical.SID;

				Preview();
			}
		}

		private void Preview()
		{
			//if (horizontal != null && vertical != null)
			{
				sm.eval = eval;
				sm.h = horizontal;
				sm.v = vertical;
				sm.width = previewBox.Width;
				sm.height = previewBox.Height - 25;
				sm.PersonList = cpp.SelectedPersons;
				sm.ComboList = cpp.SelectedCombos;
				sm.Compute();
				previewBox.SmallPreview = sm.OutputImage;

				sm.width = sizeControl.ChosenWidth;
				sm.height = sizeControl.ChosenHeight;
				sm.Compute();
				previewBox.BigPreview = sm.OutputImage;
			}
		}

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			sm.eval = eval;
			sm.Cross  = cross.Cross;
			sm.width  = sizeControl.ChosenWidth;
			sm.height = sizeControl.ChosenHeight;

			if (single)
			{
				SaveDialog sd = new SaveDialog(sm);
				sd.ShowDialog();
			}
			else
			{
				Close();
				this.DialogResult = DialogResult.OK;
			}
		}

		private void sizeControl_Load(object sender, System.EventArgs e)
		{
		
		}

		private void EndButton_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cpp_SelectionChanged()
		{
			Preview();
		}

		private void sizeControl_ChosenSizeChanged()
		{
			sm.eval = eval;
			sm.h = horizontal;
			sm.v = vertical;
			sm.PersonList = cpp.SelectedPersons;
			sm.ComboList = cpp.SelectedCombos;
 			sm.width = sizeControl.ChosenWidth;
			sm.height = sizeControl.ChosenHeight;
			sm.Compute();
			previewBox.BigPreview = sm.OutputImage;
		}

		private void cross_CrossChanged()
		{
			sm.Cross = cross.cross;
		}

		private void ArrowBox_CheckedChanged(object sender, System.EventArgs e)
		{
			sm.DrawArrow = ArrowBox.Checked;
			Preview();
		}

		private void StyleBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			sm.Style = StyleBox.SelectedIndex;
			Preview();
		}

		private void LegendBox_CheckedChanged(object sender, System.EventArgs e)
		{
			sm.Legend = LegendBox.Checked;
			Preview();
		}

		private void PrecBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			sm.Precision = PrecBox.SelectedIndex;
			Preview();
		}
	}
}

