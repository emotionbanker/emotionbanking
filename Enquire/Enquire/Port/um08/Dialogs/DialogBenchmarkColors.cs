using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogBenchmarkColors : DialogTemplate
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		private GroupBox groupBox1;
		private Label label5;
		private Button ThisColButton;
		private Label label4;
		private Button AllColButton;
		private Label label3;
		private Label label2;
		private Button ValColButton;
		private Button GoodButton;
		private Button AvgButton;
		private Button BadButton;
		private FloatSlideControl c1Slider;
		private FloatSlideControl c2Slider;
		private PictureBox pictureBox2;
		private Button button1;
		private IContainer components = null;
		private ColorDialog colorDialog;

		private Evaluation eval;

		public DialogBenchmarkColors(Evaluation eval)
		{
			this.eval = eval;

			InitializeComponent();		

			this.SetStyle(

				ControlStyles.AllPaintingInWmPaint |

				ControlStyles.UserPaint |

				ControlStyles.DoubleBuffer,true);

			c1Slider.BackColor = Color.White;
			c1Slider.SliderColor = Color.Red;
			c1Slider.Value = eval.TlbVal1;

			c2Slider.BackColor = Color.White;
			c2Slider.SliderColor = Color.Green;
			c2Slider.Value = 1-eval.TlbVal1-eval.TlbVal2;
			c2Slider.Inverted = true;

			c1Slider.Slave(c2Slider);
			c2Slider.Slave(c1Slider);

			c1Slider.Slided+=new SlideEventHandler(c1Slider_Slided);
			c2Slider.Slided+=new SlideEventHandler(Slided);

			BadButton.BackColor  = eval.TlbColor1;
			AvgButton.BackColor  = eval.TlbColor2;
			GoodButton.BackColor = eval.TlbColor3;
			ValColButton.BackColor = eval.TlbValCol;
			AllColButton.BackColor = eval.TlbAllCol;
			ThisColButton.BackColor = eval.TlbThisCol;
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
			ResourceManager resources = new ResourceManager(typeof(DialogBenchmarkColors));
			this.HeaderPanel = new Panel();
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.groupBox1 = new GroupBox();
			this.label5 = new Label();
			this.ThisColButton = new Button();
			this.label4 = new Label();
			this.AllColButton = new Button();
			this.label3 = new Label();
			this.label2 = new Label();
			this.ValColButton = new Button();
			this.GoodButton = new Button();
			this.AvgButton = new Button();
			this.BadButton = new Button();
			this.c1Slider = new FloatSlideControl();
			this.c2Slider = new FloatSlideControl();
			this.pictureBox2 = new PictureBox();
			this.button1 = new Button();
			this.colorDialog = new ColorDialog();
			this.HeaderPanel.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.HeaderPanel.Size = new Size(530, 80);
			this.HeaderPanel.TabIndex = 3;
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
			this.label1.Text = "Benchmarking - Farben";
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.ThisColButton);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.AllColButton);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.ValColButton);
			this.groupBox1.Controls.Add(this.GoodButton);
			this.groupBox1.Controls.Add(this.AvgButton);
			this.groupBox1.Controls.Add(this.BadButton);
			this.groupBox1.Controls.Add(this.c1Slider);
			this.groupBox1.Controls.Add(this.c2Slider);
			this.groupBox1.Controls.Add(this.pictureBox2);
			this.groupBox1.Location = new Point(8, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(512, 176);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Farbeinstellungen";
			// 
			// label5
			// 
			this.label5.Location = new Point(304, 128);
			this.label5.Name = "label5";
			this.label5.Size = new Size(112, 24);
			this.label5.TabIndex = 14;
			this.label5.Text = "Diese Umfrage:";
			this.label5.TextAlign = ContentAlignment.MiddleRight;
			// 
			// ThisColButton
			// 
			this.ThisColButton.FlatStyle = FlatStyle.Flat;
			this.ThisColButton.Location = new Point(432, 128);
			this.ThisColButton.Name = "ThisColButton";
			this.ThisColButton.Size = new Size(56, 24);
			this.ThisColButton.TabIndex = 13;
			this.ThisColButton.Click += new EventHandler(this.ThisColButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new Point(320, 96);
			this.label4.Name = "label4";
			this.label4.Size = new Size(96, 24);
			this.label4.TabIndex = 12;
			this.label4.Text = "Alle Umfragen:";
			this.label4.TextAlign = ContentAlignment.MiddleRight;
			// 
			// AllColButton
			// 
			this.AllColButton.FlatStyle = FlatStyle.Flat;
			this.AllColButton.Location = new Point(432, 96);
			this.AllColButton.Name = "AllColButton";
			this.AllColButton.Size = new Size(56, 24);
			this.AllColButton.TabIndex = 11;
			this.AllColButton.Click += new EventHandler(this.AllColButton_Click);
			// 
			// label3
			// 
			this.label3.Location = new Point(320, 64);
			this.label3.Name = "label3";
			this.label3.Size = new Size(168, 24);
			this.label3.TabIndex = 10;
			this.label3.Text = "Bester/Schlechtester Wert:";
			this.label3.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new Point(320, 24);
			this.label2.Name = "label2";
			this.label2.Size = new Size(96, 24);
			this.label2.TabIndex = 8;
			this.label2.Text = "Eigener Wert:";
			this.label2.TextAlign = ContentAlignment.MiddleRight;
			// 
			// ValColButton
			// 
			this.ValColButton.FlatStyle = FlatStyle.Flat;
			this.ValColButton.Location = new Point(432, 24);
			this.ValColButton.Name = "ValColButton";
			this.ValColButton.Size = new Size(56, 24);
			this.ValColButton.TabIndex = 7;
			this.ValColButton.Click += new EventHandler(this.ValColButton_Click);
			// 
			// GoodButton
			// 
			this.GoodButton.FlatStyle = FlatStyle.Flat;
			this.GoodButton.Location = new Point(152, 32);
			this.GoodButton.Name = "GoodButton";
			this.GoodButton.Size = new Size(56, 24);
			this.GoodButton.TabIndex = 6;
			this.GoodButton.Click += new EventHandler(this.GoodButton_Click);
			// 
			// AvgButton
			// 
			this.AvgButton.FlatStyle = FlatStyle.Flat;
			this.AvgButton.Location = new Point(88, 32);
			this.AvgButton.Name = "AvgButton";
			this.AvgButton.Size = new Size(56, 24);
			this.AvgButton.TabIndex = 5;
			this.AvgButton.Click += new EventHandler(this.AvgButton_Click);
			// 
			// BadButton
			// 
			this.BadButton.FlatStyle = FlatStyle.Flat;
			this.BadButton.Location = new Point(24, 32);
			this.BadButton.Name = "BadButton";
			this.BadButton.Size = new Size(56, 24);
			this.BadButton.TabIndex = 4;
			this.BadButton.Click += new EventHandler(this.BadButton_Click);
			// 
			// c1Slider
			// 
			this.c1Slider.Cursor = Cursors.VSplit;
			this.c1Slider.Font = new Font("Arial", 8F);
			this.c1Slider.Location = new Point(24, 120);
			this.c1Slider.Name = "c1Slider";
			this.c1Slider.Size = new Size(184, 8);
			this.c1Slider.TabIndex = 3;
			this.c1Slider.Value = 0F;
			// 
			// c2Slider
			// 
			this.c2Slider.Cursor = Cursors.VSplit;
			this.c2Slider.Font = new Font("Arial", 8F);
			this.c2Slider.Location = new Point(24, 72);
			this.c2Slider.Name = "c2Slider";
			this.c2Slider.Size = new Size(184, 8);
			this.c2Slider.TabIndex = 2;
			this.c2Slider.Value = 0F;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = Color.White;
			this.pictureBox2.BorderStyle = BorderStyle.FixedSingle;
			this.pictureBox2.Location = new Point(24, 88);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(184, 24);
			this.pictureBox2.TabIndex = 0;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Paint += new PaintEventHandler(this.pictureBox2_Paint);
			// 
			// button1
			// 
			this.button1.BackColor = Color.LightGray;
			this.button1.FlatStyle = FlatStyle.Popup;
			this.button1.Location = new Point(368, 280);
			this.button1.Name = "button1";
			this.button1.Size = new Size(152, 32);
			this.button1.TabIndex = 5;
			this.button1.Text = "OK";
			this.button1.Click += new EventHandler(this.button1_Click);
			// 
			// DialogBenchmarkColors
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.Gainsboro;
			this.ClientSize = new Size(530, 334);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "DialogBenchmarkColors";
			this.HeaderPanel.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Slided()
		{
			eval.TlbVal2 = 1 - (c1Slider.Value + c2Slider.Value);
			pictureBox2.Refresh();
		}

		private void c1Slider_Slided()
		{
			eval.TlbVal2 = 1 - (c1Slider.Value + c2Slider.Value);
			eval.TlbVal1 = c1Slider.Value;
			pictureBox2.Refresh();
		}

		private void BadButton_Click(object sender, EventArgs e)
		{
			colorDialog.Color = eval.TlbColor1;
			if (colorDialog.ShowDialog(this.ParentForm) == DialogResult.OK)
			{
				eval.TlbColor1 = colorDialog.Color;
				BadButton.BackColor = eval.TlbColor1;
				c1Slider.SliderColor = eval.TlbColor1;
				Refresh();
			}
		}

		private void AvgButton_Click(object sender, EventArgs e)
		{
			colorDialog.Color = eval.TlbColor2;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				eval.TlbColor2 = colorDialog.Color;
				AvgButton.BackColor = eval.TlbColor2;
				Refresh();
			}
		}

		private void GoodButton_Click(object sender, EventArgs e)
		{
			colorDialog.Color = eval.TlbColor3;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				eval.TlbColor3 = colorDialog.Color;
				GoodButton.BackColor = eval.TlbColor3;
				c2Slider.SliderColor = eval.TlbColor3;
				Refresh();
			}
		}

		private void ValColButton_Click(object sender, EventArgs e)
		{
			colorDialog.Color = eval.TlbValCol;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				eval.TlbValCol = colorDialog.Color;
				ValColButton.BackColor = eval.TlbValCol;
				Refresh();
			}
		}

		private void AllColButton_Click(object sender, EventArgs e)
		{
			colorDialog.Color = eval.TlbAllCol;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				eval.TlbAllCol = colorDialog.Color;
				AllColButton.BackColor = eval.TlbAllCol;
				Refresh();
			}
		}

		private void ThisColButton_Click(object sender, EventArgs e)
		{
			colorDialog.Color = eval.TlbThisCol;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				eval.TlbThisCol = colorDialog.Color;
				ThisColButton.BackColor = eval.TlbThisCol;
				Refresh();
			}
		}

		private void pictureBox2_Paint(object sender, PaintEventArgs e)
		{
			Bitmap b = Benchmarking.TrafficLightBar(pictureBox2.Width, pictureBox2.Height, eval, 3f, 3.25f,2.25f, 3.5f, 2f, false);
			e.Graphics.DrawImage(b,0,0);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

