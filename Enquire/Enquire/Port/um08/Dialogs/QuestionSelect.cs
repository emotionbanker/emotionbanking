using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class QuestionSelect : DialogTemplate
	{
		private Button EndButton;
		private Button OkButton;
		private CheckedListBox QuestionList;
		
		private IContainer components = null;
		private Label label1;
		private TextBox searchBox;
		private CheckedListBox ComboList;

		private Evaluation eval;
		private Button SelectAll;
        private CheckedListBox AlternateList;
        private CheckedListBox PlaceholderList;
        private CheckedListBox ConvertList;

		private string type = string.Empty;

		public Question SelectedQuestion
		{
			get
			{
				Console.WriteLine("get selected...");

				if (QuestionList.SelectedItem != null)
				{
					return (Question)QuestionList.SelectedItem;
				}

				if (ComboList.SelectedItem != null)
				{
					return (Question)ComboList.SelectedItem;
				}

                if (AlternateList.SelectedItem != null)
                {
                    return (Question)AlternateList.SelectedItem;
                }

                if (PlaceholderList.SelectedItem != null)
                {
                    return (Question)PlaceholderList.SelectedItem;
                }

                if(ConvertList.SelectedItem != null){
                    return (Question)ConvertList.SelectedItem;
                }

				return null;
			}
		}

		public Question[] SelectedQuestions
		{
			get
			{
				if (QuestionList.CheckedItems.Count + ComboList.CheckedItems.Count + AlternateList.CheckedItems.Count + PlaceholderList.CheckedItems.Count + ConvertList.CheckedItems.Count> 0)
				{
                    Question[] qs = new Question[QuestionList.CheckedItems.Count + ComboList.CheckedItems.Count + AlternateList.CheckedItems.Count + PlaceholderList.CheckedItems.Count + ConvertList.CheckedItems.Count];

					int i = 0;
					foreach (Question q in QuestionList.CheckedItems)
						qs[i++] = q;

					foreach (Question q in ComboList.CheckedItems)
						qs[i++] = q;

                    foreach (Question q in AlternateList.CheckedItems)
                        qs[i++] = q;

                    foreach (Question q in PlaceholderList.CheckedItems)
                        qs[i++] = q;

                    foreach (Question q in ConvertList.CheckedItems)
                        qs[i++] = q;

					return qs;
				}
				
				return null;
			}
		}

		public QuestionSelect(Evaluation eval, string type)
		{
			this.type = type;
			Set(eval);
		}

		public QuestionSelect(Evaluation eval)
		{
			Set(eval);
		}

		private void Set(Evaluation eval)
		{
			this.eval = eval;

			InitializeComponent();

			this.CancelButton = EndButton;

			//fill list box



			foreach (Question q in eval.Global.Questions)
                if (type.Equals(string.Empty) || q.Display.Equals(type) || q.Display.Equals("textmore") || (type.Equals("text") && q.Display.Equals("multitext")))
					QuestionList.Items.Add(q);

            

            foreach (Question q in eval.QuestionConvert)
                if (type.Equals(string.Empty) || q.Display.Equals(type) || q.Display.Equals("textmore") || (type.Equals("text") && q.Display.Equals("multitext")))
                    ConvertList.Items.Add(q);

			foreach (QuestionCombo combo in eval.QuestionCombos)
			{
				Question q = combo.GetQuestion(eval.Global);
				if (q != null)
                    if (type.Equals(string.Empty) || q.Display.Equals(type) || q.Display.Equals("textmore") || (type.Equals("text") && q.Display.Equals("multitext")))
						ComboList.Items.Add(q);
			}

            foreach (QuestionPlaceholder ph in eval.QuestionPlaceholders)
            {
                Question q = ph.GetQuestion(eval.Global, eval);
                if (q != null)
                    if (type.Equals(string.Empty) || q.Display.Equals(type) || q.Display.Equals("textmore") || (type.Equals("text") && q.Display.Equals("multitext")))
                        PlaceholderList.Items.Add(q);
            }

            

            /*
            foreach (QuestionAlternate alt in eval.QuestionAlternates)
            {
                Question q = alt.GetQuestion(eval.Global);
                if (q != null)
                    if (type.Equals(string.Empty) || q.Display.Equals(type) || (type.Equals("text") && q.Display.Equals("multitext")))
                        AlternateList.Items.Add(q);

            }
             * */
		}

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle sizeNow = new Rectangle(0, 0, this.Width, this.Height);

            if (Enabled)
            {
                Graphics g = e.Graphics;

                Brush b = new LinearGradientBrush(sizeNow, Color.FromArgb(242, 248, 254), Color.FromArgb(194, 211, 255), 0, true);

                g.FillRectangle(b, 0, 0, this.Width, this.Height);
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
            this.QuestionList = new CheckedListBox();
            this.label1 = new Label();
            this.searchBox = new TextBox();
            this.ComboList = new CheckedListBox();
            this.SelectAll = new Button();
            this.OkButton = new Button();
            this.EndButton = new Button();
            this.AlternateList = new CheckedListBox();
            this.PlaceholderList = new CheckedListBox();
            this.ConvertList = new CheckedListBox();
            this.SuspendLayout();
            // 
            // QuestionList
            // 
            this.QuestionList.BorderStyle = BorderStyle.FixedSingle;
            this.QuestionList.CheckOnClick = true;
            this.QuestionList.HorizontalScrollbar = true;
            this.QuestionList.Location = new Point(7, 39);
            this.QuestionList.Name = "QuestionList";
            this.QuestionList.Size = new Size(615, 197);
            this.QuestionList.TabIndex = 10;
            this.QuestionList.ItemCheck += new ItemCheckEventHandler(this.QuestionList_ItemCheck);
            this.QuestionList.SelectedIndexChanged += new EventHandler(this.QuestionList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor =Color.Transparent;
            this.label1.Location = new Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(73, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Suche nach:";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // searchBox
            // 
            this.searchBox.BorderStyle = BorderStyle.FixedSingle;
            this.searchBox.Location = new Point(80, 13);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new Size(542, 20);
            this.searchBox.TabIndex = 12;
            this.searchBox.TextChanged += new EventHandler(this.searchBox_TextChanged);
            // 
            // ComboList
            // 
            this.ComboList.BorderStyle = BorderStyle.FixedSingle;
            this.ComboList.CheckOnClick = true;
            this.ComboList.HorizontalScrollbar = true;
            this.ComboList.Location = new Point(7, 282);
            this.ComboList.Name = "ComboList";
            this.ComboList.Size = new Size(272, 182);
            this.ComboList.TabIndex = 13;
            // 
            // SelectAll
            // 
            this.SelectAll.BackColor = Color.White;
            this.SelectAll.FlatStyle = FlatStyle.Popup;
            this.SelectAll.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00e7_0409;
            this.SelectAll.ImageAlign = ContentAlignment.MiddleLeft;
            this.SelectAll.Location = new Point(7, 470);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new Size(180, 33);
            this.SelectAll.TabIndex = 14;
            this.SelectAll.Text = "        Alle Fragen auswählen";
            this.SelectAll.UseVisualStyleBackColor = false;
            this.SelectAll.Click += new EventHandler(this.SelectAll_Click);
            // 
            // OkButton
            // 
            this.OkButton.BackColor = Color.White;
            this.OkButton.FlatStyle = FlatStyle.Popup;
            this.OkButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00f6_0409;
            this.OkButton.ImageAlign = ContentAlignment.MiddleLeft;
            this.OkButton.Location = new Point(509, 470);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new Size(113, 33);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "      OK";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new EventHandler(this.OkButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.BackColor = Color.White;
            this.EndButton.FlatStyle = FlatStyle.Popup;
            this.EndButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00f0_0409;
            this.EndButton.ImageAlign = ContentAlignment.MiddleLeft;
            this.EndButton.Location = new Point(390, 470);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new Size(113, 33);
            this.EndButton.TabIndex = 8;
            this.EndButton.Text = "        Keine Frage";
            this.EndButton.UseVisualStyleBackColor = false;
            this.EndButton.Click += new EventHandler(this.EndButton_Click);
            // 
            // AlternateList
            // 
            this.AlternateList.BorderStyle = BorderStyle.FixedSingle;
            this.AlternateList.CheckOnClick = true;
            this.AlternateList.HorizontalScrollbar = true;
            this.AlternateList.Location = new Point(-14, 526);
            this.AlternateList.Name = "AlternateList";
            this.AlternateList.Size = new Size(113, 32);
            this.AlternateList.TabIndex = 15;
            this.AlternateList.Visible = false;
            // 
            // PlaceholderList
            // 
            this.PlaceholderList.BorderStyle = BorderStyle.FixedSingle;
            this.PlaceholderList.CheckOnClick = true;
            this.PlaceholderList.HorizontalScrollbar = true;
            this.PlaceholderList.Location = new Point(285, 282);
            this.PlaceholderList.Name = "PlaceholderList";
            this.PlaceholderList.Size = new Size(337, 182);
            this.PlaceholderList.TabIndex = 16;
            // 
            // ConvertList
            // 
            this.ConvertList.BorderStyle = BorderStyle.FixedSingle;
            this.ConvertList.CheckOnClick = true;
            this.ConvertList.HorizontalScrollbar = true;
            this.ConvertList.Location = new Point(7, 242);
            this.ConvertList.Name = "ConvertList";
            this.ConvertList.Size = new Size(615, 32);
            this.ConvertList.TabIndex = 17;
            // 
            // QuestionSelect
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.White;
            this.ClientSize = new Size(634, 542);
            this.Controls.Add(this.ConvertList);
            this.Controls.Add(this.PlaceholderList);
            this.Controls.Add(this.AlternateList);
            this.Controls.Add(this.SelectAll);
            this.Controls.Add(this.ComboList);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QuestionList);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.EndButton);
            this.Name = "QuestionSelect";
            this.Text = "Fragenauswahl";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Search(string s)
		{
			QuestionList.Items.Clear();
			ComboList.Items.Clear();
            AlternateList.Items.Clear();
            ConvertList.Items.Clear();
            PlaceholderList.Items.Clear();

			foreach (Question q in eval.Global.Questions)
			{
				if (q.ToString().ToLower().IndexOf(s.ToLower()) != -1)
                    if (type.Equals(string.Empty) || q.Display.Equals(type) || q.Display.Equals("textmore") || (type.Equals("text") && q.Display.Equals("multitext")))
						QuestionList.Items.Add(q);
			}

            foreach (Question q in eval.QuestionConvert)
            {
                if (q.ToString().ToLower().IndexOf(s.ToLower()) != -1)
                    if (type.Equals(string.Empty) || q.Display.Equals(type) || q.Display.Equals("textmore") || (type.Equals("text") && q.Display.Equals("multitext")))
                        ConvertList.Items.Add(q);
            }
			foreach (QuestionCombo combo in eval.QuestionCombos)
			{
				if (combo.ToString().ToLower().IndexOf(s.ToLower()) != -1)
				{
					Question q = combo.GetQuestion(eval.Global);
					if (q != null)
                        if (type.Equals(string.Empty) || q.Display.Equals(type) || q.Display.Equals("textmore") || (type.Equals("text") && q.Display.Equals("multitext")))
							ComboList.Items.Add(q);
				}
			}

            foreach (QuestionPlaceholder ph in eval.QuestionPlaceholders)
            {
                if (ph.ToString().ToLower().IndexOf(s.ToLower()) != -1)
                {
                    Question q = ph.GetQuestion(eval.Global, eval);
                    if (q != null)
                        if (type.Equals(string.Empty) || q.Display.Equals(type) || q.Display.Equals("textmore") || (type.Equals("text") && q.Display.Equals("multitext")))
                            PlaceholderList.Items.Add(q);
                }
            }


            /*
            foreach (QuestionAlternate combo in eval.QuestionAlternates)
            {
                if (combo.ToString().ToLower().IndexOf(s.ToLower()) != -1)
                {
                    Question q = combo.GetQuestion(eval.Global);
                    if (q != null)
                        if (type.Equals(string.Empty) || q.Display.Equals(type) || (type.Equals("text") && q.Display.Equals("multitext")))
                            AlternateList.Items.Add(q);
                }
            }
             * */
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
            if (QuestionList.CheckedItems.Count > 0 || ComboList.CheckedItems.Count > 0 || AlternateList.CheckedItems.Count > 0 || PlaceholderList.CheckedItems.Count > 0 || ConvertList.CheckedItems.Count > 0)
				this.DialogResult = DialogResult.OK;
			else
				this.DialogResult = DialogResult.Abort;

			Close();
		}

		private void searchBox_TextChanged(object sender, EventArgs e)
		{
			Search(searchBox.Text);
		}

		private void QuestionList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
		}

		private void QuestionList_SelectedIndexChanged(object sender, EventArgs e)
		{
		
		}

		private void SelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < QuestionList.Items.Count; i++)
				QuestionList.SetItemChecked(i, true);

			for (int i = 0; i < ComboList.Items.Count; i++)
				ComboList.SetItemChecked(i, true);


            for (int i = 0; i < PlaceholderList.Items.Count; i++)
                PlaceholderList.SetItemChecked(i, true);

            for (int i = 0; i < ConvertList.Items.Count; i++)
                ConvertList.SetItemChecked(i, true);

            //for (int i = 0; i < AlternateList.Items.Count; i++)
            //    AlternateList.SetItemChecked(i, true);
		}

        private void EndButton_Click(object sender, EventArgs e)
        {

        }
	}
}

