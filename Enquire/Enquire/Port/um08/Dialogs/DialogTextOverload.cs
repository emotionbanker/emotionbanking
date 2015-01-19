using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogTextOverload : DialogTemplate
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		private ListBox QBox;
		private Button EndButton;
		private IContainer components = null;
        private Gauge_h056 gauge;

		private Evaluation eval;
		private Label label2;
		private TextBox OverloadBox;
		private Button ResetButton;
		private Question[] list;
        private Hashtable answerList;
        private bool AnswerDialoug;

		public DialogTextOverload(Evaluation eval, Question[] list)
		{
			this.eval = eval;
			this.list = list;

			if (eval.TextOverloads == null)
				eval.TextOverloads = new Hashtable();

			InitializeComponent();

			this.CancelButton = EndButton;
            AnswerDialoug = false;
			foreach (Question q in list)
				QBox.Items.Add(q);
		}

        public DialogTextOverload(Evaluation eval, Question[] list, Gauge_h056 gauge)
        {
            this.eval = eval;
            this.list = list;
            this.gauge = gauge;
            if (eval.TextOverloads == null)
                eval.TextOverloads = new Hashtable();

            InitializeComponent();

            this.CancelButton = EndButton;

            this.answerList = gauge.answerList;
            AnswerDialoug = true;
            foreach (string q in answerList.Keys)
                QBox.Items.Add(q);
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DialogTextOverload));
            this.HeaderPanel = new Panel();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            this.QBox = new ListBox();
            this.EndButton = new Button();
            this.label2 = new Label();
            this.OverloadBox = new TextBox();
            this.ResetButton = new Button();
            this.HeaderPanel.SuspendLayout();
            ((ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.HeaderPanel.Size = new Size(490, 65);
            this.HeaderPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = Color.White;
            this.label1.Font = new Font("Arial", 18F);
            this.label1.ForeColor = Color.Gray;
            this.label1.Location = new Point(60, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(460, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Beschriftungen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(53, 52);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // QBox
            // 
            this.QBox.BorderStyle = BorderStyle.FixedSingle;
            this.QBox.HorizontalScrollbar = true;
            this.QBox.ItemHeight = 14;
            this.QBox.Location = new Point(7, 72);
            this.QBox.Name = "QBox";
            this.QBox.Size = new Size(160, 184);
            this.QBox.TabIndex = 29;
            this.QBox.SelectedIndexChanged += new EventHandler(this.QBox_SelectedIndexChanged);
            // 
            // EndButton
            // 
            this.EndButton.BackColor = Color.LightGray;
            this.EndButton.FlatStyle = FlatStyle.Popup;
            this.EndButton.Location = new Point(173, 240);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new Size(227, 26);
            this.EndButton.TabIndex = 30;
            this.EndButton.Text = "Schliessen";
            this.EndButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Location = new Point(180, 78);
            this.label2.Name = "label2";
            this.label2.Size = new Size(80, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Beschriftung:";
            // 
            // OverloadBox
            // 
            this.OverloadBox.BorderStyle = BorderStyle.FixedSingle;
            this.OverloadBox.Location = new Point(173, 104);
            this.OverloadBox.Multiline = true;
            this.OverloadBox.Name = "OverloadBox";
            this.OverloadBox.ScrollBars = ScrollBars.Both;
            this.OverloadBox.Size = new Size(227, 124);
            this.OverloadBox.TabIndex = 32;
            this.OverloadBox.TextChanged += new EventHandler(this.OverloadBox_TextChanged);
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = Color.LightGray;
            this.ResetButton.FlatStyle = FlatStyle.Popup;
            this.ResetButton.Location = new Point(280, 72);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new Size(120, 26);
            this.ResetButton.TabIndex = 33;
            this.ResetButton.Text = "Zurücksetzen";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new EventHandler(this.ResetButton_Click);
            // 
            // DialogTextOverload
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.BackColor = Color.Gainsboro;
            this.ClientSize = new Size(490, 350);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.OverloadBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.QBox);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "DialogTextOverload";
            this.Load += new EventHandler(this.DialogTextOverload_Load);
            this.HeaderPanel.ResumeLayout(false);
            ((ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void UpdateControls()
		{
            if (!AnswerDialoug)
            {
                if (QBox.SelectedItem != null)
                {
                    Question q = (Question)QBox.SelectedItem;

                    OverloadBox.Enabled = true;
                    ResetButton.Enabled = true;

                    if (eval.TextOverloads.ContainsKey(q.ID))
                        OverloadBox.Text = (string)eval.TextOverloads[q.ID];
                    else
                        OverloadBox.Text = q.Text;
                }
                else
                {
                    OverloadBox.Enabled = false;
                    ResetButton.Enabled = false;
                }
            }
            else
            {
                if (QBox.SelectedItem != null)
                {
                    string q = (string)QBox.SelectedItem;

                    OverloadBox.Enabled = true;
                    ResetButton.Enabled = true;

                    ICollection valueColl1 = this.answerList.Values;
                    ICollection valueColl2 = this.answerList.Keys;

                    if (this.answerList.ContainsKey(q))
                    {
                        OverloadBox.Text= (string) this.answerList[q];
                    }
                    /*if (eval.TextOverloads.ContainsKey(q.ID))
                        OverloadBox.Text = (string)eval.TextOverloads[q.ID];
                    else
                        OverloadBox.Text = q.Text;*/
                }
            }
		}

		private void DialogTextOverload_Load(object sender, EventArgs e)
		{
		
		}

		private void QBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
            if (!AnswerDialoug)
            {
                if (QBox.SelectedItem != null)
                {
                    Question q = (Question)QBox.SelectedItem;

                    OverloadBox.Text = q.Text;
                }
            }
            else
            {
                if (QBox.SelectedItem != null)
                {
                    string q = (string)QBox.SelectedItem;
                    OverloadBox.Text = q;
                }
            }
            
            
		}

		private void OverloadBox_TextChanged(object sender, EventArgs e)
		{
		    if (!AnswerDialoug){
                if (QBox.SelectedItem != null)
			    {
				    Question q = (Question)QBox.SelectedItem;

				    eval.TextOverloads[q.ID] = OverloadBox.Text;
			    }
            }else{
                if (QBox.SelectedItem != null)
                {
                    string q = (string)QBox.SelectedItem;
                    this.answerList[q] = OverloadBox.Text;
                    gauge.answerList = this.answerList;
                }
            }
		}//end methode
	}
}

