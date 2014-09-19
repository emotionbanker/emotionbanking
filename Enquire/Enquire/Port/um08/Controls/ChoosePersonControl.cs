using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	public delegate void CppEventHandler();

	/// <summary>
	/// Summary description for ChoosePersonControl.
	/// </summary>
	public class ChoosePersonControl : UserControl
	{
		
		public CheckedListBox PersonBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Evaluation eval;

		public event CppEventHandler SelectionChanged;

		private ArrayList selectedList;
		private ArrayList selectedCList;

		private bool combos;
		
		public Person[] SelectedPersons
		{
			get
			{
				Person[] p = new Person[selectedList.Count];

				for (int i=0; i < selectedList.Count; i++)
					p[i] = (Person)selectedList[i];
				return p;
			}
			
		}

		public PersonCombo[] SelectedCombos
		{
			get
			{
				PersonCombo[] p = new PersonCombo[selectedCList.Count];

				for (int i=0; i < selectedCList.Count; i++)
					p[i] = (PersonCombo)selectedCList[i];
				return p;
			}
		}

        public PersonSetting Selected
        {
            get
            {
                return (PersonSetting)PersonBox.SelectedItem;
            }
            set
            {
                PersonBox.SelectedItem = value;
            }
        }

		public ChoosePersonControl(Evaluation eval)
		{
			Set(eval, true);
		}

		public ChoosePersonControl(Evaluation eval, bool combos)
		{		
			Set(eval, combos);
		}

		private void Set(Evaluation eval, bool combos)
		{
			this.eval = eval;
			this.combos = combos;
		
			InitializeComponent();

			UpdateData();

			SelectionChanged+=new CppEventHandler(ChoosePersonControl_SelectionChanged);
			eval.PersonDataChanged+=new EvaluationEventHandler(eval_PersonDataChanged);
		}

		private void UpdateData()
		{
            //Console.WriteLine("eval null?" + (eval == null));
			foreach (Person p in eval.Persons)
				PersonBox.Items.Add(p);

			if (combos && eval.PersonCombos != null)
				foreach (PersonCombo combo in eval.PersonCombos)
					PersonBox.Items.Add(combo);

			selectedList = new ArrayList();
			selectedCList = new ArrayList();
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
            this.PersonBox = new CheckedListBox();
            this.SuspendLayout();
            // 
            // PersonBox
            // 
            this.PersonBox.BorderStyle = BorderStyle.FixedSingle;
            this.PersonBox.CheckOnClick = true;
            this.PersonBox.Dock = DockStyle.Fill;
            this.PersonBox.HorizontalScrollbar = true;
            this.PersonBox.Location = new Point(0, 0);
            this.PersonBox.Name = "PersonBox";
            this.PersonBox.Size = new Size(200, 74);
            this.PersonBox.TabIndex = 0;
            this.PersonBox.ItemCheck += new ItemCheckEventHandler(this.PersonBox_ItemCheck);
            // 
            // ChoosePersonControl
            // 
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.PersonBox);
            this.Font = new Font("Arial", 8F);
            this.Name = "ChoosePersonControl";
            this.Size = new Size(200, 80);
            this.ResumeLayout(false);

		}
		#endregion


		private void PersonBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if( e.NewValue == CheckState.Checked)
			{
				try
				{
					Person p = (Person)PersonBox.Items[e.Index];
					selectedList.Add(p);
				}
				catch
				{
					try
					{
						PersonCombo p = (PersonCombo)PersonBox.Items[e.Index];
						selectedCList.Add(p);
					}
					catch
					{
					}
				}
				
			}
			else
			{
				try
				{
					Person p = (Person)PersonBox.Items[e.Index];
					selectedList.Remove(p);
				}
				catch
				{
					try
					{
						PersonCombo p = (PersonCombo)PersonBox.Items[e.Index];
						selectedCList.Remove(p);
					}
					catch
					{
					}
				}
			} 

			SelectionChanged();
		}

		private void ChoosePersonControl_SelectionChanged()
		{
			//do nothing
		}

		private void eval_PersonDataChanged(object source)
		{
			UpdateData();
		}

		public void SetSelection(int[] ids)
		{
			for (int i = 0; i < PersonBox.Items.Count; i++)
			{			
				try
				{
					PersonBox.SetItemChecked(i, false);
					Person p = (Person)PersonBox.Items[i];
					foreach (int sp in ids)
						if (p.ID == sp)
							PersonBox.SetItemChecked(i, true);
				}
				catch{}
			}
		}

		public void SetSelection(Person[] s, PersonCombo[] c)
		{
			for (int i = 0; i < PersonBox.Items.Count; i++)
			{			
				try
				{
					PersonBox.SetItemChecked(i, false);
					Person p = (Person)PersonBox.Items[i];
					foreach (Person sp in s)
						if (p.ID == sp.ID)
							PersonBox.SetItemChecked(i, true);
				}
				catch
				{
					try
					{
						PersonBox.SetItemChecked(i, false);
						PersonCombo p = (PersonCombo)PersonBox.Items[i];
						foreach (PersonCombo pc in c)
							if (pc.Index == p.Index)
								PersonBox.SetItemChecked(i, true);
					}
					catch
					{
					}
				}
			}
		}
	}
}
