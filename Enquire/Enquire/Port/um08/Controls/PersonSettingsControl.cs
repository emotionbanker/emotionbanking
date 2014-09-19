using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for PersonSettingsControl.
	/// </summary>
	public class PersonSettingsControl : UserControl
	{
		private Label label1;
		private Panel Color1Box;
		private Button SelectColor1Button;
		private Button SelectColor2Button;
		private Panel Color2Box;
		
		private IContainer components;

		private ColorDialog colorDialog;
		private PictureBox PreviewPanel;
		private Label label2;
		private TextBox CutBox;
		private Label label3;
		private ComboBox iSymbolBox;
		private ImageList imageList;
        private ComboBox ShadeBox;
        private Label label4;
        private NumericUpDown SymSize;
        private Label label5;

		private PersonSetting person;

		public PersonSettingsControl(PersonSetting person)
		{
			this.person = person;

			InitializeComponent();

			UpdatePreview();
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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(PersonSettingsControl));
            this.label1 = new Label();
            this.Color1Box = new Panel();
            this.SelectColor1Button = new Button();
            this.SelectColor2Button = new Button();
            this.Color2Box = new Panel();
            this.colorDialog = new ColorDialog();
            this.PreviewPanel = new PictureBox();
            this.label2 = new Label();
            this.CutBox = new TextBox();
            this.iSymbolBox = new ComboBox();
            this.imageList = new ImageList(this.components);
            this.label3 = new Label();
            this.ShadeBox = new ComboBox();
            this.label4 = new Label();
            this.SymSize = new NumericUpDown();
            this.label5 = new Label();
            ((ISupportInitialize)(this.PreviewPanel)).BeginInit();
            ((ISupportInitialize)(this.SymSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new Size(64, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Farben:";
            // 
            // Color1Box
            // 
            this.Color1Box.BorderStyle = BorderStyle.FixedSingle;
            this.Color1Box.Location = new Point(112, 16);
            this.Color1Box.Name = "Color1Box";
            this.Color1Box.Size = new Size(42, 32);
            this.Color1Box.TabIndex = 1;
            // 
            // SelectColor1Button
            // 
            this.SelectColor1Button.BackColor = Color.White;
            this.SelectColor1Button.FlatStyle = FlatStyle.Popup;
            this.SelectColor1Button.Location = new Point(160, 20);
            this.SelectColor1Button.Name = "SelectColor1Button";
            this.SelectColor1Button.Size = new Size(72, 24);
            this.SelectColor1Button.TabIndex = 2;
            this.SelectColor1Button.Text = "ändern";
            this.SelectColor1Button.UseVisualStyleBackColor = false;
            this.SelectColor1Button.Click += new EventHandler(this.SelectColor1Button_Click);
            // 
            // SelectColor2Button
            // 
            this.SelectColor2Button.BackColor = Color.White;
            this.SelectColor2Button.FlatStyle = FlatStyle.Popup;
            this.SelectColor2Button.Location = new Point(296, 20);
            this.SelectColor2Button.Name = "SelectColor2Button";
            this.SelectColor2Button.Size = new Size(72, 24);
            this.SelectColor2Button.TabIndex = 5;
            this.SelectColor2Button.Text = "ändern";
            this.SelectColor2Button.UseVisualStyleBackColor = false;
            this.SelectColor2Button.Click += new EventHandler(this.SelectColor2Button_Click);
            // 
            // Color2Box
            // 
            this.Color2Box.BorderStyle = BorderStyle.FixedSingle;
            this.Color2Box.Location = new Point(248, 16);
            this.Color2Box.Name = "Color2Box";
            this.Color2Box.Size = new Size(42, 32);
            this.Color2Box.TabIndex = 4;
            // 
            // PreviewPanel
            // 
            this.PreviewPanel.BorderStyle = BorderStyle.FixedSingle;
            this.PreviewPanel.Location = new Point(16, 115);
            this.PreviewPanel.Name = "PreviewPanel";
            this.PreviewPanel.Size = new Size(496, 104);
            this.PreviewPanel.TabIndex = 6;
            this.PreviewPanel.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new Point(385, 20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(61, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kürzel:";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CutBox
            // 
            this.CutBox.BorderStyle = BorderStyle.FixedSingle;
            this.CutBox.Location = new Point(437, 22);
            this.CutBox.Name = "CutBox";
            this.CutBox.Size = new Size(40, 23);
            this.CutBox.TabIndex = 8;
            this.CutBox.TextChanged += new EventHandler(this.CutBox_TextChanged);
            // 
            // iSymbolBox
            // 
            this.iSymbolBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.iSymbolBox.FlatStyle = FlatStyle.Popup;
            this.iSymbolBox.ItemHeight = 15;

            this.iSymbolBox.Location = new Point(101, 70);
            this.iSymbolBox.Name = "iSymbolBox";
            this.iSymbolBox.Size = new Size(56, 21);
            this.iSymbolBox.TabIndex = 9;
            this.iSymbolBox.SelectedIndexChanged += new EventHandler(this.iSymbolBox_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            // 
            // label3
            // 
            this.label3.Location = new Point(24, 74);
            this.label3.Name = "label3";
            this.label3.Size = new Size(56, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Symbol:";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ShadeBox
            // 
            this.ShadeBox.FlatStyle = FlatStyle.Popup;
            this.ShadeBox.FormattingEnabled = true;
            this.ShadeBox.Location = new Point(387, 71);
            this.ShadeBox.Name = "ShadeBox";
            this.ShadeBox.Size = new Size(114, 24);
            this.ShadeBox.TabIndex = 18;
            this.ShadeBox.SelectedIndexChanged += new EventHandler(this.ShadeBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new Point(311, 70);
            this.label4.Name = "label4";
            this.label4.Size = new Size(70, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Shading";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SymSize
            // 
            this.SymSize.BorderStyle = BorderStyle.FixedSingle;
            this.SymSize.Location = new Point(238, 72);
            this.SymSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.SymSize.Name = "SymSize";
            this.SymSize.Size = new Size(41, 23);
            this.SymSize.TabIndex = 16;
            this.SymSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.SymSize.ValueChanged += new EventHandler(this.SymSize_ValueChanged);
            // 
            // label5
            // 
            this.label5.Location = new Point(176, 70);
            this.label5.Name = "label5";
            this.label5.Size = new Size(56, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Größe";
            this.label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PersonSettingsControl
            // 
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.ShadeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SymSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iSymbolBox);
            this.Controls.Add(this.CutBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PreviewPanel);
            this.Controls.Add(this.SelectColor2Button);
            this.Controls.Add(this.Color2Box);
            this.Controls.Add(this.SelectColor1Button);
            this.Controls.Add(this.Color1Box);
            this.Controls.Add(this.label1);
            this.Font = new Font("Arial", 8F);
            this.Name = "PersonSettingsControl";
            this.Size = new Size(529, 253);
            ((ISupportInitialize)(this.PreviewPanel)).EndInit();
            ((ISupportInitialize)(this.SymSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void SelectColor1Button_Click(object sender, EventArgs e)
		{
			colorDialog.Color = person.Color1;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				person.Color1 = colorDialog.Color;
			}

			UpdatePreview();
		}

		private void SelectColor2Button_Click(object sender, EventArgs e)
		{
			colorDialog.Color = person.Color2;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				person.Color2 = colorDialog.Color;
			}

			UpdatePreview();
		}

		private void UpdatePreview()
		{
			Color1Box.BackColor = person.Color1;
			Color2Box.BackColor = person.Color2;

			CutBox.Text = person.Short;

            foreach (Symbol.Shader shade in Enum.GetValues(typeof(Symbol.Shader)))
            {
                ShadeBox.Items.Add(shade);
            }

            try
            {
                iSymbolBox.SelectedIndex = person.Sym.Shape;
            }
            catch
            {
               // person.Sym = new Symbol();
               // person.Sym.Shape = person.Shape;
            }

            SymSize.Value = (decimal)person.Sym.Size;

			Image Preview = new Bitmap(496,104);

			Graphics g = Graphics.FromImage(Preview);

			//g.Clear(Color.White);
            g.Clear(Color.Transparent);
			
			GraphicTools.Bar(5,5,150,25,0,person.Color1, person.Color2, g);
			GraphicTools.Bar(5,35,80,25,0,person.Color1, person.Color2, g);
			GraphicTools.Bar(5,65,110,25,0,person.Color1, person.Color2, g);

			GraphicTools.Sphere(225, 50, 45, person.Color1, person.Color2, g);
			GraphicTools.Sphere(300, 30, 25, person.Color1, person.Color2, g);
			GraphicTools.Sphere(290, 80, 15, person.Color1, person.Color2, g);

			GraphicTools.Bar3d(380,10,25,85,270,8,person.Color1, person.Color2,g, false);
			GraphicTools.Bar3d(410,50,25,45,270,8,person.Color1, person.Color2,g, false);
			GraphicTools.Bar3d(440,30,25,65,270,8,person.Color1, person.Color2,g, false);
			
			PreviewPanel.Image = Preview;
		}

		private void CutBox_TextChanged(object sender, EventArgs e)
		{
			person.Short = CutBox.Text;
		}

		private void iSymbolBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (iSymbolBox.SelectedItem != null)
				person.Sym.Shape = iSymbolBox.SelectedIndex;
		}

        private void SymSize_ValueChanged(object sender, EventArgs e)
        {
            person.Sym.Size = (int)SymSize.Value;
        }

        private void ShadeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            person.Sym.Shading = (Symbol.Shader)ShadeBox.SelectedItem;
        }
	}
}
