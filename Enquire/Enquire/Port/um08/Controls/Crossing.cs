using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	public delegate void CrossEventHandler();

	/// <summary>
	/// Summary description for Crossing.
	/// </summary>
	public class Crossing : UserControl
	{
		private Button SelectButton;
		private Label CrossLabel;
		private Label label2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Evaluation eval;

		public Question cross;

		public Question Cross
		{
			get{return cross;}
			set
			{
				if (cross != value)
				{
					cross = value; 
					CrossChanged();
				}
			}
		}

		public event CrossEventHandler CrossChanged;

		public Crossing(Evaluation eval)
		{
			InitializeComponent();

			this.eval = eval;
			Cross = null;

			CrossChanged+=new CrossEventHandler(Crossing_CrossChanged);
		}

		public void UpdateCross(Question c)
		{
			Cross = c;
			if (Cross != null)
				CrossLabel.Text = Cross.ID.ToString();
			else
				CrossLabel.Text = "nein";
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
            this.SelectButton = new Button();
            this.CrossLabel = new Label();
            this.label2 = new Label();
            this.SuspendLayout();
            // 
            // SelectButton
            // 
            this.SelectButton.BackColor = Color.White;
            this.SelectButton.FlatStyle = FlatStyle.Popup;
            this.SelectButton.Location = new Point(128, 3);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new Size(104, 26);
            this.SelectButton.TabIndex = 13;
            this.SelectButton.Text = "ändern...";
            this.SelectButton.UseVisualStyleBackColor = false;
            this.SelectButton.Click += new EventHandler(this.SelectButton_Click);
            // 
            // CrossLabel
            // 
            this.CrossLabel.Location = new Point(80, 8);
            this.CrossLabel.Name = "CrossLabel";
            this.CrossLabel.Size = new Size(40, 23);
            this.CrossLabel.TabIndex = 14;
            this.CrossLabel.Text = "nein";
            // 
            // label2
            // 
            this.label2.Location = new Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new Size(72, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kreuzen:";
            // 
            // Crossing
            // 
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.CrossLabel);
            this.Controls.Add(this.label2);
            this.Font = new Font("Arial", 8F);
            this.Name = "Crossing";
            this.Size = new Size(232, 32);
            this.ResumeLayout(false);

		}
		#endregion

		private void SelectButton_Click(object sender, EventArgs e)
		{
			QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				Cross = qs.SelectedQuestion;
				CrossLabel.Text = Cross.SID;
			}
			else
			{
				Cross = null;
				CrossLabel.Text = "nein";
			}
		}

		private void Crossing_CrossChanged()
		{
			// do nothing
		}
	}
}
