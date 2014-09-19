using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for DataStatusControl.
	/// </summary>
	public class SettingsStatusControl : UserControl
	{
		private GroupBox groupBox1;
		private Button SelectVirtualButton;
		private Label label4;
		private Label lastResultUpdateLabel;
		private Label label2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;
		private Label PersonCountLabel;
		private Label label3;
		private Label UserCountLabel;

		private Evaluation eval;

		public SettingsStatusControl(Evaluation eval)
		{
			this.eval = eval;

			eval.PersonDataChanged+=new EvaluationEventHandler(eval_PersonDataChanged);

			InitializeComponent();

			UpdateData();
		}

		public void UpdateData()
		{
			lastResultUpdateLabel.Text = eval.LastSettingsUpdate;
			PersonCountLabel.Text = eval.PersonCount.ToString();
			UserCountLabel.Text = eval.UserCount.ToString();
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
			this.groupBox1 = new GroupBox();
			this.SelectVirtualButton = new Button();
			this.PersonCountLabel = new Label();
			this.label4 = new Label();
			this.lastResultUpdateLabel = new Label();
			this.label2 = new Label();
			this.UserCountLabel = new Label();
			this.label3 = new Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.UserCountLabel);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.SelectVirtualButton);
			this.groupBox1.Controls.Add(this.PersonCountLabel);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.lastResultUpdateLabel);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(584, 112);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datenstatus";
			// 
			// SelectVirtualButton
			// 
			this.SelectVirtualButton.BackColor = Color.LightGray;
			this.SelectVirtualButton.FlatStyle = FlatStyle.Popup;
			this.SelectVirtualButton.Location = new Point(408, 24);
			this.SelectVirtualButton.Name = "SelectVirtualButton";
			this.SelectVirtualButton.Size = new Size(160, 32);
			this.SelectVirtualButton.TabIndex = 9;
			this.SelectVirtualButton.Text = "Daten laden...";
			this.SelectVirtualButton.Click += new EventHandler(this.SelectVirtualButton_Click);
			// 
			// PersonCountLabel
			// 
			this.PersonCountLabel.Location = new Point(248, 56);
			this.PersonCountLabel.Name = "PersonCountLabel";
			this.PersonCountLabel.Size = new Size(160, 24);
			this.PersonCountLabel.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new Point(16, 56);
			this.label4.Name = "label4";
			this.label4.Size = new Size(232, 24);
			this.label4.TabIndex = 2;
			this.label4.Text = "Anzahl der Personengruppen:";
			this.label4.TextAlign = ContentAlignment.TopRight;
			// 
			// lastResultUpdateLabel
			// 
			this.lastResultUpdateLabel.Location = new Point(248, 32);
			this.lastResultUpdateLabel.Name = "lastResultUpdateLabel";
			this.lastResultUpdateLabel.Size = new Size(160, 24);
			this.lastResultUpdateLabel.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new Point(16, 32);
			this.label2.Name = "label2";
			this.label2.Size = new Size(232, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "Letztes Einlesen aus der Datenbank:";
			this.label2.TextAlign = ContentAlignment.TopRight;
			// 
			// UserCountLabel
			// 
			this.UserCountLabel.Location = new Point(248, 80);
			this.UserCountLabel.Name = "UserCountLabel";
			this.UserCountLabel.Size = new Size(160, 24);
			this.UserCountLabel.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.Location = new Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new Size(232, 24);
			this.label3.TabIndex = 10;
			this.label3.Text = "Verwendete Zugangscodes:";
			this.label3.TextAlign = ContentAlignment.TopRight;
			// 
			// SettingsStatusControl
			// 
			this.BackColor = Color.Gainsboro;
			this.Controls.Add(this.groupBox1);
			this.Font = new Font("Arial", 8F);
			this.Name = "SettingsStatusControl";
			this.Size = new Size(584, 112);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void SelectVirtualButton_Click(object sender, EventArgs e)
		{
			DialogShortmessage loading = new DialogShortmessage("lade einstellungen...");
			this.Enabled = false;
			loading.Location = new Point(this.Location.X + this.Size.Width/2, this.Location.Y + this.Size.Height/2);
			loading.Show();
			Refresh();
			loading.Refresh();
			
			eval.LoadPersonData();

			this.Enabled = true;
			loading.Close();
		}

		private void eval_PersonDataChanged(object source)
		{
			UpdateData();
		}
	}
}
