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
	public class OutputFormBarometer : DialogTemplate
	{
		private System.Windows.Forms.Panel HeaderPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel crossPanel;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button EndButton;
		private System.ComponentModel.IContainer components = null;

		public Barometer bar;
		private Evaluation eval;
		private bool single;

		private PreviewControl previewBox;
		private SizeControl sizeControl;
		private System.Windows.Forms.Button BArrowLarge;
		private System.Windows.Forms.Label LArrowBig;
		private System.Windows.Forms.ComboBox PArrowLarge;
		private System.Windows.Forms.ComboBox PArrowSmall;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label LArrowSmall;
		private System.Windows.Forms.ComboBox PSmallLeft;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label LSmallLeft;
		private System.Windows.Forms.ComboBox PSmallRight;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label LSmallRight;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox MarkBox;
		private System.Windows.Forms.CheckBox RedCheck;

		private Crossing cross;

		public OutputFormBarometer(Evaluation eval)
		{
            Set(eval, true, new Barometer(eval));

			Preview();
		}

		public OutputFormBarometer(Evaluation eval, bool single)
		{
            Set(eval, single, new Barometer(eval));

			Preview();
		}

		public OutputFormBarometer(Evaluation eval, bool single, Barometer bar)
		{
			Set(eval, single, bar);

			EndButton.Visible = false;
						
			Preview();
		}

		private void Set(Evaluation eval, bool single, Barometer bar)
		{
			this.eval = eval;
			this.single = single;
			this.bar = bar;

			Console.WriteLine("eval null?" + (eval==null));
			InitializeComponent();

			this.CancelButton = EndButton;

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(bar.Cross);

			OutputNameControl onc = new OutputNameControl(bar);
			onc.Location = new Point(530,16);
			HeaderPanel.Controls.Add(onc);

			sizeControl.SetSize(bar.width, bar.height);

			foreach (PersonSetting ps in eval.CombinedPersons)
			{
				PArrowLarge.Items.Add(ps);
				PArrowSmall.Items.Add(ps);
				PSmallLeft.Items.Add(ps);
				PSmallRight.Items.Add(ps);
			}

			PArrowLarge.SelectedItem = bar.PArrowBig;
			PArrowSmall.SelectedItem = bar.PArrowSmall;
			PSmallLeft.SelectedItem = bar.PSmallLeft;
			PSmallRight.SelectedItem = bar.PSmallRight;

			if (bar.ArrowBig != null)
				LArrowBig.Text = bar.ArrowBig.SID.ToString();
			if (bar.ArrowSmall != null)
				LArrowSmall.Text = bar.ArrowSmall.SID.ToString();
			if (bar.SmallLeft != null)
				LSmallLeft.Text = bar.SmallLeft.SID.ToString();
			if (bar.SmallRight != null)
				LSmallRight.Text = bar.SmallRight.SID.ToString();

			MarkBox.Text = bar.Heading;
			RedCheck.Checked = bar.Red;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OutputFormBarometer));
			this.HeaderPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.crossPanel = new System.Windows.Forms.Panel();
			this.SaveButton = new System.Windows.Forms.Button();
			this.EndButton = new System.Windows.Forms.Button();
			this.previewBox = new PreviewControl();
			this.sizeControl = new SizeControl();
			this.BArrowLarge = new System.Windows.Forms.Button();
			this.LArrowBig = new System.Windows.Forms.Label();
			this.PArrowLarge = new System.Windows.Forms.ComboBox();
			this.PArrowSmall = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.LArrowSmall = new System.Windows.Forms.Label();
			this.PSmallLeft = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.LSmallLeft = new System.Windows.Forms.Label();
			this.PSmallRight = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.LSmallRight = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.MarkBox = new System.Windows.Forms.TextBox();
			this.RedCheck = new System.Windows.Forms.CheckBox();
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
			this.HeaderPanel.Size = new System.Drawing.Size(778, 80);
			this.HeaderPanel.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Arial", 18F);
			this.label1.ForeColor = System.Drawing.Color.Gray;
			this.label1.Location = new System.Drawing.Point(72, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(296, 56);
			this.label1.TabIndex = 1;
			this.label1.Text = "Barometer";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 64);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// crossPanel
			// 
			this.crossPanel.Location = new System.Drawing.Point(536, 248);
			this.crossPanel.Name = "crossPanel";
			this.crossPanel.Size = new System.Drawing.Size(232, 48);
			this.crossPanel.TabIndex = 48;
			// 
			// SaveButton
			// 
			this.SaveButton.BackColor = System.Drawing.Color.LightGray;
			this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.SaveButton.Location = new System.Drawing.Point(504, 488);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(216, 32);
			this.SaveButton.TabIndex = 46;
			this.SaveButton.Text = "Speichern...";
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// EndButton
			// 
			this.EndButton.BackColor = System.Drawing.Color.LightGray;
			this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.EndButton.Location = new System.Drawing.Point(504, 448);
			this.EndButton.Name = "EndButton";
			this.EndButton.Size = new System.Drawing.Size(216, 32);
			this.EndButton.TabIndex = 45;
			this.EndButton.Text = "Schliessen";
			this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
			// 
			// previewBox
			// 
			this.previewBox.BackColor = System.Drawing.Color.Gainsboro;
			this.previewBox.Location = new System.Drawing.Point(8, 88);
			this.previewBox.Name = "previewBox";
			this.previewBox.Size = new System.Drawing.Size(472, 432);
			this.previewBox.SmallPreview = null;
			this.previewBox.TabIndex = 49;
			// 
			// sizeControl
			// 
			this.sizeControl.BackColor = System.Drawing.Color.Gainsboro;
			this.sizeControl.Location = new System.Drawing.Point(664, 312);
			this.sizeControl.Name = "sizeControl";
			this.sizeControl.Size = new System.Drawing.Size(104, 56);
			this.sizeControl.TabIndex = 50;
			this.sizeControl.ChosenSizeChanged += new SizeEventHandler(this.sizeControl_ChosenSizeChanged);
			// 
			// BArrowLarge
			// 
			this.BArrowLarge.BackColor = System.Drawing.Color.LightGray;
			this.BArrowLarge.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BArrowLarge.Location = new System.Drawing.Point(664, 96);
			this.BArrowLarge.Name = "BArrowLarge";
			this.BArrowLarge.Size = new System.Drawing.Size(104, 24);
			this.BArrowLarge.TabIndex = 52;
			this.BArrowLarge.Text = "Großer Pfeil...";
			this.BArrowLarge.Click += new System.EventHandler(this.BArrowLarge_Click);
			// 
			// LArrowBig
			// 
			this.LArrowBig.Location = new System.Drawing.Point(616, 96);
			this.LArrowBig.Name = "LArrowBig";
			this.LArrowBig.Size = new System.Drawing.Size(48, 23);
			this.LArrowBig.TabIndex = 53;
			this.LArrowBig.Text = "?";
			this.LArrowBig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PArrowLarge
			// 
			this.PArrowLarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PArrowLarge.DropDownWidth = 200;
			this.PArrowLarge.Location = new System.Drawing.Point(488, 96);
			this.PArrowLarge.Name = "PArrowLarge";
			this.PArrowLarge.Size = new System.Drawing.Size(120, 24);
			this.PArrowLarge.TabIndex = 54;
			this.PArrowLarge.SelectedIndexChanged += new System.EventHandler(this.PArrowLarge_SelectedIndexChanged);
			// 
			// PArrowSmall
			// 
			this.PArrowSmall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PArrowSmall.Location = new System.Drawing.Point(488, 128);
			this.PArrowSmall.Name = "PArrowSmall";
			this.PArrowSmall.Size = new System.Drawing.Size(120, 24);
			this.PArrowSmall.TabIndex = 57;
			this.PArrowSmall.SelectedIndexChanged += new System.EventHandler(this.PArrowSmall_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LightGray;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(664, 128);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 24);
			this.button1.TabIndex = 55;
			this.button1.Text = "Kleiner Pfeil...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// LArrowSmall
			// 
			this.LArrowSmall.Location = new System.Drawing.Point(616, 128);
			this.LArrowSmall.Name = "LArrowSmall";
			this.LArrowSmall.Size = new System.Drawing.Size(48, 23);
			this.LArrowSmall.TabIndex = 56;
			this.LArrowSmall.Text = "?";
			this.LArrowSmall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PSmallLeft
			// 
			this.PSmallLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PSmallLeft.Location = new System.Drawing.Point(488, 160);
			this.PSmallLeft.Name = "PSmallLeft";
			this.PSmallLeft.Size = new System.Drawing.Size(120, 24);
			this.PSmallLeft.TabIndex = 60;
			this.PSmallLeft.SelectedIndexChanged += new System.EventHandler(this.PSmallLeft_SelectedIndexChanged);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.LightGray;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Location = new System.Drawing.Point(664, 160);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 24);
			this.button2.TabIndex = 58;
			this.button2.Text = "Klein Links...";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// LSmallLeft
			// 
			this.LSmallLeft.Location = new System.Drawing.Point(616, 160);
			this.LSmallLeft.Name = "LSmallLeft";
			this.LSmallLeft.Size = new System.Drawing.Size(48, 23);
			this.LSmallLeft.TabIndex = 59;
			this.LSmallLeft.Text = "?";
			this.LSmallLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PSmallRight
			// 
			this.PSmallRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PSmallRight.Location = new System.Drawing.Point(488, 192);
			this.PSmallRight.Name = "PSmallRight";
			this.PSmallRight.Size = new System.Drawing.Size(120, 24);
			this.PSmallRight.TabIndex = 63;
			this.PSmallRight.SelectedIndexChanged += new System.EventHandler(this.PSmallRight_SelectedIndexChanged);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.LightGray;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button3.Location = new System.Drawing.Point(664, 192);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(104, 24);
			this.button3.TabIndex = 61;
			this.button3.Text = "Klein Rechts...";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// LSmallRight
			// 
			this.LSmallRight.Location = new System.Drawing.Point(616, 192);
			this.LSmallRight.Name = "LSmallRight";
			this.LSmallRight.Size = new System.Drawing.Size(48, 23);
			this.LSmallRight.TabIndex = 62;
			this.LSmallRight.Text = "?";
			this.LSmallRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(504, 384);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 64;
			this.label2.Text = "Beschriftung:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MarkBox
			// 
			this.MarkBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MarkBox.Location = new System.Drawing.Point(592, 384);
			this.MarkBox.Name = "MarkBox";
			this.MarkBox.Size = new System.Drawing.Size(176, 23);
			this.MarkBox.TabIndex = 65;
			this.MarkBox.Text = "";
			this.MarkBox.TextChanged += new System.EventHandler(this.MarkBox_TextChanged);
			// 
			// RedCheck
			// 
			this.RedCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.RedCheck.Location = new System.Drawing.Point(504, 312);
			this.RedCheck.Name = "RedCheck";
			this.RedCheck.Size = new System.Drawing.Size(136, 24);
			this.RedCheck.TabIndex = 66;
			this.RedCheck.Text = "Roter Hintergrund";
			this.RedCheck.CheckedChanged += new System.EventHandler(this.RedCheck_CheckedChanged);
			// 
			// OutputFormBarometer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(778, 534);
			this.Controls.Add(this.RedCheck);
			this.Controls.Add(this.MarkBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.PSmallRight);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.LSmallRight);
			this.Controls.Add(this.PSmallLeft);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.LSmallLeft);
			this.Controls.Add(this.PArrowSmall);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.LArrowSmall);
			this.Controls.Add(this.PArrowLarge);
			this.Controls.Add(this.BArrowLarge);
			this.Controls.Add(this.LArrowBig);
			this.Controls.Add(this.sizeControl);
			this.Controls.Add(this.previewBox);
			this.Controls.Add(this.crossPanel);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.EndButton);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "OutputFormBarometer";
			this.Text = "Einzelauswertung";
			this.HeaderPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Preview()
		{
			bar.eval = eval;

			Size os = new Size(bar.width, bar.height);

			bar.width = 470;
			bar.height = 400;

			bar.Compute();
			
			previewBox.SmallPreview = bar.OutputImage;
			
			bar.width = os.Width;
			bar.height = os.Height;

			bar.Compute();
			
			previewBox.BigPreview = bar.OutputImage;
		}

		private void SaveButton_Click(object sender, System.EventArgs e)
		{		
			if (single)
			{
				SaveDialog sd = new SaveDialog(bar);
				sd.ShowDialog();
			}
			else
			{
				Close();
				this.DialogResult = DialogResult.OK;
			}
		}

		

		private void EndButton_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cross_CrossChanged()
		{
			bar.Cross = cross.cross;
		}

		private void sizeControl_ChosenSizeChanged()
		{
			bar.width = sizeControl.ChosenWidth;
			bar.height = sizeControl.ChosenHeight;

			Preview();
		}

		private void PArrowLarge_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bar.PArrowBig = (PersonSetting)PArrowLarge.SelectedItem;
			Preview();
		}

		private void PArrowSmall_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bar.PArrowSmall = (PersonSetting)PArrowSmall.SelectedItem;
			Preview();
		}

		private void PSmallLeft_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bar.PSmallLeft = (PersonSetting)PSmallLeft.SelectedItem;
			Preview();
		}

		private void PSmallRight_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			bar.PSmallRight = (PersonSetting)PSmallRight.SelectedItem;
			Preview();
		}

		private void BArrowLarge_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			qs.ShowDialog();

			if (qs.SelectedQuestion != null)
				LArrowBig.Text = qs.SelectedQuestion.SID.ToString();
			else LArrowBig.Text = "";

			bar.ArrowBig = qs.SelectedQuestion;
			
			Preview();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			qs.ShowDialog();

			if (qs.SelectedQuestion != null)
				LArrowSmall.Text = qs.SelectedQuestion.SID.ToString();
			else LArrowSmall.Text = "";
			bar.ArrowSmall = qs.SelectedQuestion;

			Preview();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			qs.ShowDialog();

			if (qs.SelectedQuestion != null)
				LSmallLeft.Text = qs.SelectedQuestion.SID.ToString();
			else LSmallRight.Text = "";
			bar.SmallLeft = qs.SelectedQuestion;

			Preview();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			qs.ShowDialog();

			if (qs.SelectedQuestion != null)
				LSmallRight.Text = qs.SelectedQuestion.SID.ToString();
			else LSmallRight.Text = "";
			bar.SmallRight = qs.SelectedQuestion;

			Preview();
		}

		private void MarkBox_TextChanged(object sender, System.EventArgs e)
		{
			bar.Heading = MarkBox.Text;
			Preview();
		}

		private void RedCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			bar.Red = RedCheck.Checked;
			Preview();
		}
	}
}

