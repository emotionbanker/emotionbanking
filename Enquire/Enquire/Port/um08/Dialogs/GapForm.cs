using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class GapForm : DialogTemplate
	{
		private IContainer components = null;

		public Column col;
		private NumericUpDown GapStepBox;
		private Label label13;
		private Button SaveButton;
		private ListBox GapBox;
		private Button Add;
		private Button RemoveButton;
		private Label label11;
		private ComboBox ASel;
		private ComboBox BSel;
		private Label label1;
		public ColumnQuestion q;

		public GapForm(Column col, ColumnQuestion q, Evaluation eval)
		{
			this.col = col;
			this.q = q;

			InitializeComponent();

			this.Text = "Gaps für Frage " + q.QuestionID;

			GapStepBox.Value = (decimal)q.gap.Limit;

			foreach (Person person in eval.Persons)
			{
				ASel.Items.Add(person);
				BSel.Items.Add(person);
			}

			foreach (PersonV v in q.gap.Persons)
				GapBox.Items.Add(v);


		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
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

		#region Vom Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.GapStepBox = new NumericUpDown();
			this.label13 = new Label();
			this.SaveButton = new Button();
			this.GapBox = new ListBox();
			this.Add = new Button();
			this.RemoveButton = new Button();
			this.ASel = new ComboBox();
			this.label11 = new Label();
			this.BSel = new ComboBox();
			this.label1 = new Label();
			((ISupportInitialize)(this.GapStepBox)).BeginInit();
			this.SuspendLayout();
			// 
			// GapStepBox
			// 
			this.GapStepBox.DecimalPlaces = 1;
			this.GapStepBox.Increment = new Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 65536});
			this.GapStepBox.Location = new Point(152, 264);
			this.GapStepBox.Name = "GapStepBox";
			this.GapStepBox.Size = new Size(48, 23);
			this.GapStepBox.TabIndex = 50;
			this.GapStepBox.Value = new Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
			this.GapStepBox.ValueChanged += new EventHandler(this.GapStepBox_ValueChanged);
			// 
			// label13
			// 
			this.label13.Location = new Point(8, 264);
			this.label13.Name = "label13";
			this.label13.Size = new Size(160, 21);
			this.label13.TabIndex = 49;
			this.label13.Text = "Punktabzug je Gap von:";
			this.label13.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// SaveButton
			// 
			this.SaveButton.BackColor = Color.LightGray;
			this.SaveButton.FlatStyle = FlatStyle.Popup;
			this.SaveButton.Location = new Point(216, 256);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new Size(200, 32);
			this.SaveButton.TabIndex = 51;
			this.SaveButton.Text = "Schliessen";
			this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
			// 
			// GapBox
			// 
			this.GapBox.BorderStyle = BorderStyle.FixedSingle;
			this.GapBox.HorizontalScrollbar = true;
			this.GapBox.ItemHeight = 16;
			this.GapBox.Location = new Point(8, 8);
			this.GapBox.Name = "GapBox";
			this.GapBox.Size = new Size(194, 210);
			this.GapBox.TabIndex = 52;
			// 
			// Add
			// 
			this.Add.BackColor = Color.LightGray;
			this.Add.FlatStyle = FlatStyle.Popup;
			this.Add.Location = new Point(216, 184);
			this.Add.Name = "Add";
			this.Add.Size = new Size(200, 32);
			this.Add.TabIndex = 53;
			this.Add.Text = "<- Hinzufügen";
			this.Add.Click += new EventHandler(this.Add_Click);
			// 
			// RemoveButton
			// 
			this.RemoveButton.BackColor = Color.LightGray;
			this.RemoveButton.FlatStyle = FlatStyle.Popup;
			this.RemoveButton.Location = new Point(216, 144);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new Size(200, 32);
			this.RemoveButton.TabIndex = 54;
			this.RemoveButton.Text = "-> Entfernen";
			this.RemoveButton.Click += new EventHandler(this.RemoveButton_Click);
			// 
			// ASel
			// 
			this.ASel.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ASel.Location = new Point(248, 40);
			this.ASel.Name = "ASel";
			this.ASel.Size = new Size(168, 24);
			this.ASel.Sorted = true;
			this.ASel.TabIndex = 56;
			// 
			// label11
			// 
			this.label11.Location = new Point(216, 16);
			this.label11.Name = "label11";
			this.label11.Size = new Size(72, 21);
			this.label11.TabIndex = 55;
			this.label11.Text = "Zwischen:";
			this.label11.TextAlign = ContentAlignment.MiddleLeft;
			this.label11.Click += new EventHandler(this.label11_Click);
			// 
			// BSel
			// 
			this.BSel.DropDownStyle = ComboBoxStyle.DropDownList;
			this.BSel.Location = new Point(248, 96);
			this.BSel.Name = "BSel";
			this.BSel.Size = new Size(168, 24);
			this.BSel.Sorted = true;
			this.BSel.TabIndex = 58;
			// 
			// label1
			// 
			this.label1.Location = new Point(216, 72);
			this.label1.Name = "label1";
			this.label1.Size = new Size(72, 21);
			this.label1.TabIndex = 57;
			this.label1.Text = "und:";
			this.label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// GapForm
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.Gainsboro;
			this.ClientSize = new Size(426, 294);
			this.Controls.Add(this.BSel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ASel);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.RemoveButton);
			this.Controls.Add(this.Add);
			this.Controls.Add(this.GapBox);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.GapStepBox);
			this.Controls.Add(this.label13);
			this.Name = "GapForm";
			((ISupportInitialize)(this.GapStepBox)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void GapStepBox_ValueChanged(object sender, EventArgs e)
		{
			q.gap.Limit = (float)GapStepBox.Value;
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void label11_Click(object sender, EventArgs e)
		{
		
		}

		private void Add_Click(object sender, EventArgs e)
		{
			Person a = (Person)ASel.SelectedItem;
			Person b = (Person)BSel.SelectedItem;

			if (a != b)
				AddP(a,b);
		}

		private void AddP(Person a, Person b)
		{
			PersonV v = new PersonV();
			v.A = a;
			v.B = b;

			q.gap.Persons.Add(v);
			GapBox.Items.Add(v);
		}

		private void Remove(PersonV v)
		{
			GapBox.Items.Remove(v);
			q.gap.RemovePersons(v);
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			if (GapBox.SelectedItem != null)
			{
				PersonV v = (PersonV)GapBox.SelectedItem;

				Remove(v);
			}
		}
	}
}

