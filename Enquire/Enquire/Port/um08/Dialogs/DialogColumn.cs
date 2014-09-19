using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogColumn : DialogTemplate
	{
		private PictureBox pictureBox1;
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox2;
		private IContainer components = null;

		private Evaluation eval;
		private PictureBox pictureBox3;
		private Button SaveButton;
		private ListBox QBox;
		private GroupBox groupBox1;
		private Button QRemove;
		private Button QAdd;
		private GroupBox setBox;
		private ListBox CatBox;
		private Label label2;
		private TextBox CatName;
		private Label label3;
		private Button AddCat;
		private Button button1;
		private GroupBox groupBox2;
		private Label label4;
		private Label label5;
		private NumericUpDown Weight1;
		private Label label6;
		private NumericUpDown Weight3;
		private Label label7;
		private NumericUpDown Weight4;
		private Label label8;
		private NumericUpDown Weight5;
		private Label label9;
		private NumericUpDown Weight2;
		private TextBox MaxPoints;
		private TextBox CatWeight;
		private TextBox QWeight;
		private Label label10;
		private Label label11;
		private ComboBox CatSelect;
		private Panel personPanel;
		private Column column;
		private Label label12;
		private NumericUpDown GapStepBox;
		private Label label13;
		private Button GapButton;
		private CheckBox JustGaps;
        private GroupBox groupBox3;
        private TextBox HeadB3B;
        private TextBox HeadB2B;
        private TextBox HeadB1B;
        private TextBox HeadTopB;
        private Label label15;
        private Label label14;
        private NumericUpDown maxGapNum;
        private Label label16;

		private ChoosePersonControl cpp;

		public DialogColumn(Evaluation eval, Column column)
		{
			this.eval = eval;
			this.column = column;

			InitializeComponent();

			ColumnNameControl onc = new ColumnNameControl(column);
			onc.Location = new Point(380,16);
			HeaderPanel.Controls.Add(onc);

			cpp = new ChoosePersonControl(eval, false);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			personPanel.Controls.Add(cpp);

			column.CategoryRemoved+=new CategoryEventHandler(column_CategoryRemoved);

			//fill data

			MaxPoints.Text = column.MaxPoints.ToString();
			Weight1.Value = (decimal)column.AnswerPoints[0];
			Weight2.Value = (decimal)column.AnswerPoints[1];
			Weight3.Value = (decimal)column.AnswerPoints[2];
			Weight4.Value = (decimal)column.AnswerPoints[3];
			Weight5.Value = (decimal)column.AnswerPoints[4];
			UpdateCatBox(null);

			foreach (ColumnQuestion cq in column.Questions)
				QBox.Items.Add(cq);

			GapStepBox.Value = (decimal)column.GapStep;
			GapStepBox.Visible = false;
			label13.Visible = false;

			JustGaps.Checked = column.GapOnly;

            HeadTopB.Text = column.HeadTop;
            HeadB1B.Text = column.HeadB1;
            HeadB2B.Text = column.HeadB2;
            HeadB3B.Text = column.HeadB3;

            maxGapNum.Value = (decimal)column.MaxGapVal;

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DialogColumn));
            this.pictureBox1 = new PictureBox();
            this.HeaderPanel = new Panel();
            this.pictureBox3 = new PictureBox();
            this.label1 = new Label();
            this.pictureBox2 = new PictureBox();
            this.SaveButton = new Button();
            this.QBox = new ListBox();
            this.groupBox1 = new GroupBox();
            this.GapButton = new Button();
            this.label12 = new Label();
            this.personPanel = new Panel();
            this.CatSelect = new ComboBox();
            this.label11 = new Label();
            this.QWeight = new TextBox();
            this.label10 = new Label();
            this.QRemove = new Button();
            this.QAdd = new Button();
            this.setBox = new GroupBox();
            this.button1 = new Button();
            this.AddCat = new Button();
            this.CatWeight = new TextBox();
            this.label3 = new Label();
            this.CatName = new TextBox();
            this.label2 = new Label();
            this.CatBox = new ListBox();
            this.groupBox2 = new GroupBox();
            this.maxGapNum = new NumericUpDown();
            this.JustGaps = new CheckBox();
            this.label16 = new Label();
            this.GapStepBox = new NumericUpDown();
            this.label13 = new Label();
            this.Weight5 = new NumericUpDown();
            this.label9 = new Label();
            this.Weight4 = new NumericUpDown();
            this.label8 = new Label();
            this.Weight3 = new NumericUpDown();
            this.label7 = new Label();
            this.Weight2 = new NumericUpDown();
            this.label6 = new Label();
            this.Weight1 = new NumericUpDown();
            this.label5 = new Label();
            this.MaxPoints = new TextBox();
            this.label4 = new Label();
            this.groupBox3 = new GroupBox();
            this.HeadB3B = new TextBox();
            this.HeadB2B = new TextBox();
            this.HeadB1B = new TextBox();
            this.HeadTopB = new TextBox();
            this.label15 = new Label();
            this.label14 = new Label();
            ((ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            ((ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.setBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize)(this.maxGapNum)).BeginInit();
            ((ISupportInitialize)(this.GapStepBox)).BeginInit();
            ((ISupportInitialize)(this.Weight5)).BeginInit();
            ((ISupportInitialize)(this.Weight4)).BeginInit();
            ((ISupportInitialize)(this.Weight3)).BeginInit();
            ((ISupportInitialize)(this.Weight2)).BeginInit();
            ((ISupportInitialize)(this.Weight1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = Color.White;
            this.HeaderPanel.Controls.Add(this.pictureBox3);
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Dock = DockStyle.Top;
            this.HeaderPanel.Location = new Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new Size(716, 52);
            this.HeaderPanel.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new Point(13, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(34, 26);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = Color.White;
            this.label1.Font = new Font("Arial", 18F);
            this.label1.ForeColor = Color.Gray;
            this.label1.Location = new Point(60, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(87, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Säule";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(100, 50);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = Color.LightGray;
            this.SaveButton.FlatStyle = FlatStyle.Popup;
            this.SaveButton.Location = new Point(340, 430);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new Size(359, 26);
            this.SaveButton.TabIndex = 26;
            this.SaveButton.Text = "OK";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
            // 
            // QBox
            // 
            this.QBox.BorderStyle = BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 14;
            this.QBox.Location = new Point(47, 20);
            this.QBox.Name = "QBox";
            this.QBox.Size = new Size(233, 128);
            this.QBox.TabIndex = 29;
            this.QBox.SelectedIndexChanged += new EventHandler(this.QBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GapButton);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.personPanel);
            this.groupBox1.Controls.Add(this.CatSelect);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.QWeight);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.QRemove);
            this.groupBox1.Controls.Add(this.QAdd);
            this.groupBox1.Controls.Add(this.QBox);
            this.groupBox1.Location = new Point(7, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(520, 176);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fragen";
            // 
            // GapButton
            // 
            this.GapButton.BackColor = Color.LightGray;
            this.GapButton.FlatStyle = FlatStyle.Popup;
            this.GapButton.Location = new Point(427, 46);
            this.GapButton.Name = "GapButton";
            this.GapButton.Size = new Size(80, 26);
            this.GapButton.TabIndex = 53;
            this.GapButton.Text = "Gaps";
            this.GapButton.UseVisualStyleBackColor = false;
            this.GapButton.Click += new EventHandler(this.GapButton_Click);
            // 
            // label12
            // 
            this.label12.Location = new Point(300, 72);
            this.label12.Name = "label12";
            this.label12.Size = new Size(107, 19);
            this.label12.TabIndex = 51;
            this.label12.Text = "Personengruppen:";
            this.label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // personPanel
            // 
            this.personPanel.Enabled = false;
            this.personPanel.Location = new Point(300, 91);
            this.personPanel.Name = "personPanel";
            this.personPanel.Size = new Size(213, 71);
            this.personPanel.TabIndex = 50;
            // 
            // CatSelect
            // 
            this.CatSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CatSelect.Enabled = false;
            this.CatSelect.Location = new Point(367, 20);
            this.CatSelect.Name = "CatSelect";
            this.CatSelect.Size = new Size(140, 22);
            this.CatSelect.Sorted = true;
            this.CatSelect.TabIndex = 49;
            this.CatSelect.SelectedIndexChanged += new EventHandler(this.CatSelect_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Location = new Point(300, 20);
            this.label11.Name = "label11";
            this.label11.Size = new Size(60, 17);
            this.label11.TabIndex = 48;
            this.label11.Text = "Kategorie:";
            this.label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // QWeight
            // 
            this.QWeight.BorderStyle = BorderStyle.FixedSingle;
            this.QWeight.Enabled = false;
            this.QWeight.Location = new Point(373, 46);
            this.QWeight.Name = "QWeight";
            this.QWeight.Size = new Size(40, 20);
            this.QWeight.TabIndex = 47;
            this.QWeight.Text = "0";
            this.QWeight.TextAlign = HorizontalAlignment.Right;
            this.QWeight.TextChanged += new EventHandler(this.QWeight_TextChanged);
            // 
            // label10
            // 
            this.label10.Location = new Point(300, 46);
            this.label10.Name = "label10";
            this.label10.Size = new Size(73, 19);
            this.label10.TabIndex = 46;
            this.label10.Text = "Gewichtung:";
            this.label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // QRemove
            // 
            this.QRemove.BackColor = Color.LightGray;
            this.QRemove.FlatStyle = FlatStyle.Popup;
            this.QRemove.Location = new Point(7, 58);
            this.QRemove.Name = "QRemove";
            this.QRemove.Size = new Size(33, 33);
            this.QRemove.TabIndex = 45;
            this.QRemove.Text = "-";
            this.QRemove.UseVisualStyleBackColor = false;
            this.QRemove.Click += new EventHandler(this.QRemove_Click);
            // 
            // QAdd
            // 
            this.QAdd.BackColor = Color.LightGray;
            this.QAdd.FlatStyle = FlatStyle.Popup;
            this.QAdd.Location = new Point(7, 20);
            this.QAdd.Name = "QAdd";
            this.QAdd.Size = new Size(33, 32);
            this.QAdd.TabIndex = 44;
            this.QAdd.Text = "+";
            this.QAdd.UseVisualStyleBackColor = false;
            this.QAdd.Click += new EventHandler(this.QAdd_Click);
            // 
            // setBox
            // 
            this.setBox.Controls.Add(this.button1);
            this.setBox.Controls.Add(this.AddCat);
            this.setBox.Controls.Add(this.CatWeight);
            this.setBox.Controls.Add(this.label3);
            this.setBox.Controls.Add(this.CatName);
            this.setBox.Controls.Add(this.label2);
            this.setBox.Controls.Add(this.CatBox);
            this.setBox.Location = new Point(7, 234);
            this.setBox.Name = "setBox";
            this.setBox.Size = new Size(320, 222);
            this.setBox.TabIndex = 31;
            this.setBox.TabStop = false;
            this.setBox.Text = "Kategorien";
            this.setBox.Enter += new EventHandler(this.setBox_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = Color.LightGray;
            this.button1.Enabled = false;
            this.button1.FlatStyle = FlatStyle.Popup;
            this.button1.Location = new Point(180, 124);
            this.button1.Name = "button1";
            this.button1.Size = new Size(127, 26);
            this.button1.TabIndex = 46;
            this.button1.Text = "Kategorie löschen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            // 
            // AddCat
            // 
            this.AddCat.BackColor = Color.LightGray;
            this.AddCat.FlatStyle = FlatStyle.Popup;
            this.AddCat.Location = new Point(180, 91);
            this.AddCat.Name = "AddCat";
            this.AddCat.Size = new Size(127, 26);
            this.AddCat.TabIndex = 45;
            this.AddCat.Text = "Neue Kategorie";
            this.AddCat.UseVisualStyleBackColor = false;
            this.AddCat.Click += new EventHandler(this.AddCat_Click);
            // 
            // CatWeight
            // 
            this.CatWeight.BorderStyle = BorderStyle.FixedSingle;
            this.CatWeight.Enabled = false;
            this.CatWeight.Location = new Point(267, 65);
            this.CatWeight.Name = "CatWeight";
            this.CatWeight.Size = new Size(35, 20);
            this.CatWeight.TabIndex = 34;
            this.CatWeight.Text = "0";
            this.CatWeight.TextAlign = HorizontalAlignment.Right;
            this.CatWeight.TextChanged += new EventHandler(this.CatWeight_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new Point(180, 65);
            this.label3.Name = "label3";
            this.label3.Size = new Size(73, 19);
            this.label3.TabIndex = 33;
            this.label3.Text = "Gewichtung:";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CatName
            // 
            this.CatName.BorderStyle = BorderStyle.FixedSingle;
            this.CatName.Enabled = false;
            this.CatName.Location = new Point(180, 39);
            this.CatName.Name = "CatName";
            this.CatName.Size = new Size(127, 20);
            this.CatName.TabIndex = 32;
            this.CatName.TextChanged += new EventHandler(this.CatName_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new Point(180, 20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(53, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "Name:";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CatBox
            // 
            this.CatBox.BorderStyle = BorderStyle.FixedSingle;
            this.CatBox.HorizontalScrollbar = true;
            this.CatBox.ItemHeight = 14;
            this.CatBox.Location = new Point(5, 17);
            this.CatBox.Name = "CatBox";
            this.CatBox.Size = new Size(162, 184);
            this.CatBox.TabIndex = 30;
            this.CatBox.SelectedIndexChanged += new EventHandler(this.CatBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxGapNum);
            this.groupBox2.Controls.Add(this.JustGaps);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.GapStepBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.Weight5);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.Weight4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Weight3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.Weight2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Weight1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.MaxPoints);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new Point(340, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(187, 190);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Einstellungen";
            // 
            // maxGapNum
            // 
            this.maxGapNum.DecimalPlaces = 1;
            this.maxGapNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.maxGapNum.Location = new Point(9, 156);
            this.maxGapNum.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.maxGapNum.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.maxGapNum.Name = "maxGapNum";
            this.maxGapNum.Size = new Size(63, 20);
            this.maxGapNum.TabIndex = 50;
            this.maxGapNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.maxGapNum.ValueChanged += new EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // JustGaps
            // 
            this.JustGaps.FlatStyle = FlatStyle.Flat;
            this.JustGaps.Location = new Point(7, 117);
            this.JustGaps.Name = "JustGaps";
            this.JustGaps.Size = new Size(180, 19);
            this.JustGaps.TabIndex = 49;
            this.JustGaps.Text = "Nur Gapabzüge (Keine Punkte)";
            this.JustGaps.CheckedChanged += new EventHandler(this.JustGaps_CheckedChanged);
            // 
            // label16
            // 
            this.label16.Location = new Point(7, 139);
            this.label16.Name = "label16";
            this.label16.Size = new Size(155, 17);
            this.label16.TabIndex = 49;
            this.label16.Text = "Max. Gapabzug pro Frage:";
            this.label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GapStepBox
            // 
            this.GapStepBox.DecimalPlaces = 1;
            this.GapStepBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.GapStepBox.Location = new Point(140, 98);
            this.GapStepBox.Name = "GapStepBox";
            this.GapStepBox.Size = new Size(40, 20);
            this.GapStepBox.TabIndex = 48;
            this.GapStepBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GapStepBox.Visible = false;
            this.GapStepBox.ValueChanged += new EventHandler(this.GapStepBox_ValueChanged);
            // 
            // label13
            // 
            this.label13.Location = new Point(7, 98);
            this.label13.Name = "label13";
            this.label13.Size = new Size(133, 17);
            this.label13.TabIndex = 47;
            this.label13.Text = "Punktabzug je Gap von:";
            this.label13.TextAlign = ContentAlignment.MiddleLeft;
            this.label13.Visible = false;
            // 
            // Weight5
            // 
            this.Weight5.DecimalPlaces = 1;
            this.Weight5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Weight5.Location = new Point(87, 58);
            this.Weight5.Name = "Weight5";
            this.Weight5.Size = new Size(40, 20);
            this.Weight5.TabIndex = 46;
            this.Weight5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Weight5.ValueChanged += new EventHandler(this.Weight5_ValueChanged);
            // 
            // label9
            // 
            this.label9.Location = new Point(73, 58);
            this.label9.Name = "label9";
            this.label9.Size = new Size(14, 20);
            this.label9.TabIndex = 45;
            this.label9.Text = "5:";
            this.label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Weight4
            // 
            this.Weight4.DecimalPlaces = 1;
            this.Weight4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Weight4.Location = new Point(87, 39);
            this.Weight4.Name = "Weight4";
            this.Weight4.Size = new Size(40, 20);
            this.Weight4.TabIndex = 44;
            this.Weight4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Weight4.ValueChanged += new EventHandler(this.Weight4_ValueChanged);
            // 
            // label8
            // 
            this.label8.Location = new Point(73, 39);
            this.label8.Name = "label8";
            this.label8.Size = new Size(14, 19);
            this.label8.TabIndex = 43;
            this.label8.Text = "4:";
            this.label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Weight3
            // 
            this.Weight3.DecimalPlaces = 1;
            this.Weight3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Weight3.Location = new Point(20, 78);
            this.Weight3.Name = "Weight3";
            this.Weight3.Size = new Size(40, 20);
            this.Weight3.TabIndex = 42;
            this.Weight3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Weight3.ValueChanged += new EventHandler(this.Weight3_ValueChanged);
            // 
            // label7
            // 
            this.label7.Location = new Point(7, 78);
            this.label7.Name = "label7";
            this.label7.Size = new Size(20, 20);
            this.label7.TabIndex = 41;
            this.label7.Text = "3:";
            this.label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Weight2
            // 
            this.Weight2.DecimalPlaces = 1;
            this.Weight2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Weight2.Location = new Point(20, 58);
            this.Weight2.Name = "Weight2";
            this.Weight2.Size = new Size(40, 20);
            this.Weight2.TabIndex = 40;
            this.Weight2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Weight2.ValueChanged += new EventHandler(this.Wieght2_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new Point(7, 58);
            this.label6.Name = "label6";
            this.label6.Size = new Size(20, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "2:";
            this.label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Weight1
            // 
            this.Weight1.DecimalPlaces = 1;
            this.Weight1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Weight1.Location = new Point(20, 39);
            this.Weight1.Name = "Weight1";
            this.Weight1.Size = new Size(40, 20);
            this.Weight1.TabIndex = 38;
            this.Weight1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Weight1.ValueChanged += new EventHandler(this.Weight1_ValueChanged);
            // 
            // label5
            // 
            this.label5.Location = new Point(7, 39);
            this.label5.Name = "label5";
            this.label5.Size = new Size(20, 19);
            this.label5.TabIndex = 37;
            this.label5.Text = "1:";
            this.label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MaxPoints
            // 
            this.MaxPoints.BorderStyle = BorderStyle.FixedSingle;
            this.MaxPoints.Location = new Point(87, 13);
            this.MaxPoints.Name = "MaxPoints";
            this.MaxPoints.Size = new Size(60, 20);
            this.MaxPoints.TabIndex = 36;
            this.MaxPoints.Text = "0";
            this.MaxPoints.TextAlign = HorizontalAlignment.Right;
            this.MaxPoints.TextChanged += new EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new Point(5, 13);
            this.label4.Name = "label4";
            this.label4.Size = new Size(82, 19);
            this.label4.TabIndex = 35;
            this.label4.Text = "Max. Punkte:";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.HeadB3B);
            this.groupBox3.Controls.Add(this.HeadB2B);
            this.groupBox3.Controls.Add(this.HeadB1B);
            this.groupBox3.Controls.Add(this.HeadTopB);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new Point(532, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(167, 359);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Beschriftungen";
            // 
            // HeadB3B
            // 
            this.HeadB3B.BorderStyle = BorderStyle.FixedSingle;
            this.HeadB3B.Location = new Point(7, 165);
            this.HeadB3B.Name = "HeadB3B";
            this.HeadB3B.Size = new Size(127, 20);
            this.HeadB3B.TabIndex = 36;
            this.HeadB3B.TextChanged += new EventHandler(this.HeadB3B_TextChanged);
            // 
            // HeadB2B
            // 
            this.HeadB2B.BorderStyle = BorderStyle.FixedSingle;
            this.HeadB2B.Location = new Point(7, 141);
            this.HeadB2B.Name = "HeadB2B";
            this.HeadB2B.Size = new Size(127, 20);
            this.HeadB2B.TabIndex = 35;
            this.HeadB2B.TextChanged += new EventHandler(this.HeadB2B_TextChanged);
            // 
            // HeadB1B
            // 
            this.HeadB1B.BorderStyle = BorderStyle.FixedSingle;
            this.HeadB1B.Location = new Point(7, 118);
            this.HeadB1B.Name = "HeadB1B";
            this.HeadB1B.Size = new Size(127, 20);
            this.HeadB1B.TabIndex = 34;
            this.HeadB1B.TextChanged += new EventHandler(this.HeadB1B_TextChanged);
            // 
            // HeadTopB
            // 
            this.HeadTopB.BorderStyle = BorderStyle.FixedSingle;
            this.HeadTopB.Location = new Point(7, 60);
            this.HeadTopB.Name = "HeadTopB";
            this.HeadTopB.Size = new Size(127, 20);
            this.HeadTopB.TabIndex = 33;
            this.HeadTopB.TextChanged += new EventHandler(this.HeadTopB_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new Point(5, 94);
            this.label15.Name = "label15";
            this.label15.Size = new Size(75, 14);
            this.label15.TabIndex = 1;
            this.label15.Text = "Informationen:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new Point(5, 32);
            this.label14.Name = "label14";
            this.label14.Size = new Size(64, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "Überschrift:";
            // 
            // DialogColumn
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.Gainsboro;
            this.ClientSize = new Size(716, 476);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.setBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "DialogColumn";
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.pictureBox3)).EndInit();
            ((ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.setBox.ResumeLayout(false);
            this.setBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((ISupportInitialize)(this.maxGapNum)).EndInit();
            ((ISupportInitialize)(this.GapStepBox)).EndInit();
            ((ISupportInitialize)(this.Weight5)).EndInit();
            ((ISupportInitialize)(this.Weight4)).EndInit();
            ((ISupportInitialize)(this.Weight3)).EndInit();
            ((ISupportInitialize)(this.Weight2)).EndInit();
            ((ISupportInitialize)(this.Weight1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void UpdateCatSelect(Category cat)
		{
			CatSelect.Items.Clear();

			foreach (Category c in column.Categories)
				CatSelect.Items.Add(c);

			CatSelect.SelectedItem = cat;
		}

		private void UpdateCatSelect()
		{
			Category cat = (Category) CatSelect.SelectedItem;
			UpdateCatSelect(cat);
		}

		private void QAdd_Click(object sender, EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				foreach (Question q in qs.SelectedQuestions)
				{
					ColumnQuestion cq = new ColumnQuestion(q);
					column.AddQuestion(cq);
					QBox.Items.Add(cq);
					QBox.SelectedItem = cq;
				}
			}
		}

		private void QRemove_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < QBox.SelectedItems.Count; i++)
			{
				column.RemoveQuestion((ColumnQuestion)QBox.SelectedItems[i]);
				QBox.Items.Remove(QBox.SelectedItems[i]);
			}
		}

		private void Weight1_ValueChanged(object sender, EventArgs e)
		{
			column.AnswerPoints[0] = (float)Weight1.Value;
		}

		private void Wieght2_ValueChanged(object sender, EventArgs e)
		{
			column.AnswerPoints[1] = (float)Weight2.Value;
		}

		private void Weight3_ValueChanged(object sender, EventArgs e)
		{
			column.AnswerPoints[2] = (float)Weight3.Value;
		}

		private void Weight4_ValueChanged(object sender, EventArgs e)
		{
			column.AnswerPoints[3] = (float)Weight4.Value;
		}

		private void Weight5_ValueChanged(object sender, EventArgs e)
		{
			column.AnswerPoints[4] = (float)Weight5.Value;
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			try
			{
				column.MaxPoints = Int32.Parse(MaxPoints.Text);
			}
			catch {	MaxPoints.Text = "0";}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void AddCat_Click(object sender, EventArgs e)
		{
			Category cat = new Category();
			
			column.AddCategory(cat);

			UpdateCatBox(cat);

			CatName.Focus();
		}

		private void UpdateCatBox(Category cat)
		{
			CatBox.Items.Clear();

			foreach (Category c in column.Categories)
				CatBox.Items.Add(c);

			CatBox.SelectedItem = cat;

			UpdateCatSelect();
		}

		private void CatWeight_TextChanged(object sender, EventArgs e)
		{
			try
			{
				float w = float.Parse(CatWeight.Text);

				if (CatBox.SelectedItem != null)
				{
					Category cat = (Category)CatBox.SelectedItem;
					cat.Weight = w;
					UpdateCatBox(cat);
				}
			}
			catch
			{
				CatWeight.Text = "0";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (CatBox.SelectedItem != null)
			{
				Category cat = (Category)CatBox.SelectedItem;
				CatBox.Items.Remove(cat);

				column.RemoveCategory(cat);
			}

		}

		private void CatBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (CatBox.SelectedItem != null)
			{
				Category cat = (Category)CatBox.SelectedItem;
				CatWeight.Text = cat.Weight.ToString();
				CatName.Text = cat.Name;
				//CatName.Focus();
				
				CatWeight.Enabled = CatName.Enabled = button1.Enabled = true;
			}
			else
				CatWeight.Enabled = CatName.Enabled = button1.Enabled = false;
		}

		private void CatName_TextChanged(object sender, EventArgs e)
		{
			if (CatBox.SelectedItem != null)
			{
				Category cat = (Category)CatBox.SelectedItem;
				cat.Name = CatName.Text;
				UpdateCatBox(cat);
			}
		}

		private void QBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool enabled = false;
			if (QBox.SelectedItem != null)
			{
				enabled = true;

				ColumnQuestion q = (ColumnQuestion) QBox.SelectedItem;

				Console.WriteLine("weight is now: " + q.Weight);

				CatSelect.SelectedItem = q.Cat;
				QWeight.Text = q.Weight.ToString();
				cpp.SetSelection(q.PersonIDs);
//				GapBox.Checked = q.IncludeGap;

				GapButton.Text = "Gaps " + "(" + q.gap.Persons.Count + ")";
				
			}

			GapButton.Enabled = CatSelect.Enabled = QWeight.Enabled = personPanel.Enabled = enabled;
		}

		private void CatSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (QBox.SelectedItem != null)
			{
				ColumnQuestion q = (ColumnQuestion) QBox.SelectedItem;
				q.Cat = (Category)CatSelect.SelectedItem;
			}
		}

		private void QWeight_TextChanged(object sender, EventArgs e)
		{
			Console.Write("weight change to ");
			try
			{
				float w = float.Parse(QWeight.Text);

				if (QBox.SelectedItem != null)
				{
					ColumnQuestion q = (ColumnQuestion) QBox.SelectedItem;
					q.Weight = w;
					Console.WriteLine(w.ToString());
				}
			}
			catch
			{
				Console.WriteLine("parse failed");
				if (QBox.SelectedItem != null)
				{
					ColumnQuestion q = (ColumnQuestion) QBox.SelectedItem;
					QWeight.Text = q.Weight.ToString();
				}
				else
					QWeight.Text = "0";
			}

		}

		private void cpp_SelectionChanged()
		{
			if (QBox.SelectedItem != null)
			{
				ColumnQuestion q = (ColumnQuestion) QBox.SelectedItem;
				q.SetPersons(cpp.SelectedPersons);
			}
		}

		private void column_CategoryRemoved(Category source)
		{
			QBox.SelectedItem = null;
		}

		private void GapBox_CheckedChanged(object sender, EventArgs e)
		{
			if (QBox.SelectedItem != null)
			{
				ColumnQuestion q = (ColumnQuestion) QBox.SelectedItem;
//				q.IncludeGap = GapBox.Checked;
			}
		}

		private void GapStepBox_ValueChanged(object sender, EventArgs e)
		{
			column.GapStep = (float)GapStepBox.Value;
		}

		private void setBox_Enter(object sender, EventArgs e)
		{
		
		}

		private void GapButton_Click(object sender, EventArgs e)
		{
			if (QBox.SelectedItem != null)
			{
				ColumnQuestion q = (ColumnQuestion) QBox.SelectedItem;
				GapForm gf = new GapForm(this.column, q, eval);
				gf.ShowDialog();

				GapButton.Text = "Gaps ("+q.gap.Persons.Count+")";
			}
		}

		private void JustGaps_CheckedChanged(object sender, EventArgs e)
		{
			column.GapOnly = JustGaps.Checked;

			Weight1.Enabled = !column.GapOnly;
			Weight2.Enabled = !column.GapOnly;
			Weight3.Enabled = !column.GapOnly;
			Weight4.Enabled = !column.GapOnly;
			Weight5.Enabled = !column.GapOnly;
		}

        private void HeadTopB_TextChanged(object sender, EventArgs e)
        {
            column.HeadTop = HeadTopB.Text;
        }

        private void HeadB1B_TextChanged(object sender, EventArgs e)
        {
            column.HeadB1 = HeadB1B.Text;
        }

        private void HeadB2B_TextChanged(object sender, EventArgs e)
        {
            column.HeadB2 = HeadB2B.Text;
        }

        private void HeadB3B_TextChanged(object sender, EventArgs e)
        {
            column.HeadB3 = HeadB3B.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            column.MaxGapVal = (double)maxGapNum.Value;
        }
	}
}

