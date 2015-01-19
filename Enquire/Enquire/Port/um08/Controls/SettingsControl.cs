using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using Compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for SettingsControl.
	/// </summary>
	/// 

	public class SettingsControl : UserControl
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private SettingsStatusControl StatusControl;
		private Label label2;
		private ComboBox PersonBox;
		private Panel PersonSettingsPanel;
		private TabControl SettingsTabs;
		private TabPage ColorTab;
		private TabPage PersonTab;
		private ListBox PersonList;
		
		private Evaluation eval;
		private Panel ChoosePersonPanel;
		private Button AddButton;
		private Button DeleteButton;
		private TabPage targetTab;
		private Button RemoveTarget;
		private Button AddTarget;
		private Panel ChooseTargetPanel;

		private ChoosePersonControl cpc;
		private ListBox TargetList;
		private TextBox ComboName;
		private Label label3;
		private TabPage questionTab;
		private ListBox QuestionComboList;
		private ListBox ComboView;
		private Button NewComboButton;
		private Button DeleteComboButton;
		private Button AddQuestionButton;
		private Button RemoveQuestionButton;
		private Label label4;
		private TextBox ComboTextBox;
		private TabPage HistoryTab;
		private ListBox HistoryList;
		private Button button1;
		private Button button2;
		private Button button3;
		private Label label5;
		private NumericUpDown IVal;
		private RadioButton ComboButton;
		private RadioButton IValButton;
		private Button button4;
		private ChooseTargetControl ctc;

		public SettingsControl(Evaluation eval)
		{
			this.eval = eval;

			eval.PersonDataChanged += new EvaluationEventHandler(eval_PersonDataChanged);

			InitializeComponent();

			StatusControl = new SettingsStatusControl(eval);
			StatusControl.Location = new Point(8,88);

			this.Controls.Add(StatusControl);

			cpc = new ChoosePersonControl(eval, false);
			cpc.Dock = DockStyle.Fill;
			ChoosePersonPanel.Controls.Add(cpc);

			ctc = new ChooseTargetControl(eval, false, false);
			ctc.Dock = DockStyle.Fill;
			ctc.SelectionChanged+=new CtcEventHandler(ctc_SelectionChanged);
			ChooseTargetPanel.Controls.Add(ctc);

			UpdateControls();

			this.UpdateQCombo();
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
			ResourceManager resources = new ResourceManager(typeof(SettingsControl));
			this.HeaderPanel = new Panel();
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.PersonSettingsPanel = new Panel();
			this.PersonBox = new ComboBox();
			this.label2 = new Label();
			this.SettingsTabs = new TabControl();
			this.PersonTab = new TabPage();
			this.DeleteButton = new Button();
			this.AddButton = new Button();
			this.ChoosePersonPanel = new Panel();
			this.PersonList = new ListBox();
			this.targetTab = new TabPage();
			this.label3 = new Label();
			this.ComboName = new TextBox();
			this.RemoveTarget = new Button();
			this.AddTarget = new Button();
			this.ChooseTargetPanel = new Panel();
			this.TargetList = new ListBox();
			this.questionTab = new TabPage();
			this.IValButton = new RadioButton();
			this.ComboButton = new RadioButton();
			this.IVal = new NumericUpDown();
			this.label5 = new Label();
			this.label4 = new Label();
			this.ComboTextBox = new TextBox();
			this.RemoveQuestionButton = new Button();
			this.AddQuestionButton = new Button();
			this.DeleteComboButton = new Button();
			this.NewComboButton = new Button();
			this.ComboView = new ListBox();
			this.QuestionComboList = new ListBox();
			this.ColorTab = new TabPage();
			this.HistoryTab = new TabPage();
			this.button3 = new Button();
			this.button1 = new Button();
			this.button2 = new Button();
			this.HistoryList = new ListBox();
			this.button4 = new Button();
			this.HeaderPanel.SuspendLayout();
			this.SettingsTabs.SuspendLayout();
			this.PersonTab.SuspendLayout();
			this.targetTab.SuspendLayout();
			this.questionTab.SuspendLayout();
			((ISupportInitialize)(this.IVal)).BeginInit();
			this.ColorTab.SuspendLayout();
			this.HistoryTab.SuspendLayout();
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
			this.HeaderPanel.Size = new Size(608, 80);
			this.HeaderPanel.TabIndex = 1;
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
			this.label1.Text = "Einstellungen";
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
			// PersonSettingsPanel
			// 
			this.PersonSettingsPanel.Location = new Point(8, 56);
			this.PersonSettingsPanel.Name = "PersonSettingsPanel";
			this.PersonSettingsPanel.Size = new Size(560, 168);
			this.PersonSettingsPanel.TabIndex = 2;
			// 
			// PersonBox
			// 
			this.PersonBox.Location = new Point(136, 16);
			this.PersonBox.Name = "PersonBox";
			this.PersonBox.Size = new Size(272, 24);
			this.PersonBox.TabIndex = 1;
			this.PersonBox.SelectedIndexChanged += new EventHandler(this.PersonBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new Size(112, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "Personengruppe:";
			this.label2.TextAlign = ContentAlignment.MiddleRight;
			// 
			// SettingsTabs
			// 
			this.SettingsTabs.Controls.Add(this.PersonTab);
			this.SettingsTabs.Controls.Add(this.targetTab);
			this.SettingsTabs.Controls.Add(this.questionTab);
			this.SettingsTabs.Controls.Add(this.ColorTab);
			this.SettingsTabs.Controls.Add(this.HistoryTab);
			this.SettingsTabs.Location = new Point(8, 216);
			this.SettingsTabs.Name = "SettingsTabs";
			this.SettingsTabs.SelectedIndex = 0;
			this.SettingsTabs.Size = new Size(584, 264);
			this.SettingsTabs.TabIndex = 3;
			this.SettingsTabs.SelectedIndexChanged += new EventHandler(this.SettingsTabs_SelectedIndexChanged);
			// 
			// PersonTab
			// 
			this.PersonTab.BackColor = Color.Gainsboro;
			this.PersonTab.Controls.Add(this.DeleteButton);
			this.PersonTab.Controls.Add(this.AddButton);
			this.PersonTab.Controls.Add(this.ChoosePersonPanel);
			this.PersonTab.Controls.Add(this.PersonList);
			this.PersonTab.Location = new Point(4, 25);
			this.PersonTab.Name = "PersonTab";
			this.PersonTab.Size = new Size(576, 235);
			this.PersonTab.TabIndex = 1;
			this.PersonTab.Text = "Personen";
			this.PersonTab.Click += new EventHandler(this.PersonTab_Click);
			// 
			// DeleteButton
			// 
			this.DeleteButton.BackColor = Color.LightGray;
			this.DeleteButton.FlatStyle = FlatStyle.Popup;
			this.DeleteButton.Location = new Point(176, 184);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new Size(216, 32);
			this.DeleteButton.TabIndex = 21;
			this.DeleteButton.Text = "Kombination löschen";
			this.DeleteButton.Click += new EventHandler(this.DeleteButton_Click);
			// 
			// AddButton
			// 
			this.AddButton.BackColor = Color.LightGray;
			this.AddButton.FlatStyle = FlatStyle.Popup;
			this.AddButton.Location = new Point(176, 8);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new Size(216, 32);
			this.AddButton.TabIndex = 20;
			this.AddButton.Text = "<- Kombination hinzufügen <-";
			this.AddButton.Click += new EventHandler(this.AddButton_Click);
			// 
			// ChoosePersonPanel
			// 
			this.ChoosePersonPanel.Location = new Point(408, 8);
			this.ChoosePersonPanel.Name = "ChoosePersonPanel";
			this.ChoosePersonPanel.Size = new Size(160, 224);
			this.ChoosePersonPanel.TabIndex = 1;
			// 
			// PersonList
			// 
			this.PersonList.BorderStyle = BorderStyle.FixedSingle;
			this.PersonList.HorizontalScrollbar = true;
			this.PersonList.ItemHeight = 16;
			this.PersonList.Location = new Point(8, 8);
			this.PersonList.Name = "PersonList";
			this.PersonList.Size = new Size(160, 210);
			this.PersonList.TabIndex = 0;
			// 
			// targetTab
			// 
			this.targetTab.BackColor = Color.Gainsboro;
			this.targetTab.Controls.Add(this.button4);
			this.targetTab.Controls.Add(this.label3);
			this.targetTab.Controls.Add(this.ComboName);
			this.targetTab.Controls.Add(this.RemoveTarget);
			this.targetTab.Controls.Add(this.AddTarget);
			this.targetTab.Controls.Add(this.ChooseTargetPanel);
			this.targetTab.Controls.Add(this.TargetList);
			this.targetTab.Location = new Point(4, 25);
			this.targetTab.Name = "targetTab";
			this.targetTab.Size = new Size(576, 235);
			this.targetTab.TabIndex = 2;
			this.targetTab.Text = "Ziele";
			// 
			// label3
			// 
			this.label3.Location = new Point(176, 64);
			this.label3.Name = "label3";
			this.label3.TabIndex = 27;
			this.label3.Text = "Bezeichnung:";
			// 
			// ComboName
			// 
			this.ComboName.BorderStyle = BorderStyle.FixedSingle;
			this.ComboName.Location = new Point(176, 88);
			this.ComboName.Name = "ComboName";
			this.ComboName.Size = new Size(216, 23);
			this.ComboName.TabIndex = 26;
			this.ComboName.Text = "";
			// 
			// RemoveTarget
			// 
			this.RemoveTarget.BackColor = Color.LightGray;
			this.RemoveTarget.FlatStyle = FlatStyle.Popup;
			this.RemoveTarget.Location = new Point(176, 144);
			this.RemoveTarget.Name = "RemoveTarget";
			this.RemoveTarget.Size = new Size(216, 32);
			this.RemoveTarget.TabIndex = 25;
			this.RemoveTarget.Text = "Kombination löschen";
			this.RemoveTarget.Click += new EventHandler(this.RemoveTarget_Click);
			// 
			// AddTarget
			// 
			this.AddTarget.BackColor = Color.LightGray;
			this.AddTarget.FlatStyle = FlatStyle.Popup;
			this.AddTarget.Location = new Point(176, 8);
			this.AddTarget.Name = "AddTarget";
			this.AddTarget.Size = new Size(216, 32);
			this.AddTarget.TabIndex = 24;
			this.AddTarget.Text = "<- Kombination hinzufügen <-";
			this.AddTarget.Click += new EventHandler(this.AddTarget_Click);
			// 
			// ChooseTargetPanel
			// 
			this.ChooseTargetPanel.Location = new Point(408, 8);
			this.ChooseTargetPanel.Name = "ChooseTargetPanel";
			this.ChooseTargetPanel.Size = new Size(160, 224);
			this.ChooseTargetPanel.TabIndex = 23;
			// 
			// TargetList
			// 
			this.TargetList.BorderStyle = BorderStyle.FixedSingle;
			this.TargetList.HorizontalScrollbar = true;
			this.TargetList.ItemHeight = 16;
			this.TargetList.Location = new Point(8, 8);
			this.TargetList.Name = "TargetList";
			this.TargetList.Size = new Size(160, 210);
			this.TargetList.TabIndex = 22;
			// 
			// questionTab
			// 
			this.questionTab.BackColor = Color.Gainsboro;
			this.questionTab.Controls.Add(this.IValButton);
			this.questionTab.Controls.Add(this.ComboButton);
			this.questionTab.Controls.Add(this.IVal);
			this.questionTab.Controls.Add(this.label5);
			this.questionTab.Controls.Add(this.label4);
			this.questionTab.Controls.Add(this.ComboTextBox);
			this.questionTab.Controls.Add(this.RemoveQuestionButton);
			this.questionTab.Controls.Add(this.AddQuestionButton);
			this.questionTab.Controls.Add(this.DeleteComboButton);
			this.questionTab.Controls.Add(this.NewComboButton);
			this.questionTab.Controls.Add(this.ComboView);
			this.questionTab.Controls.Add(this.QuestionComboList);
			this.questionTab.Location = new Point(4, 25);
			this.questionTab.Name = "questionTab";
			this.questionTab.Size = new Size(576, 235);
			this.questionTab.TabIndex = 3;
			this.questionTab.Text = "Fragen";
			// 
			// IValButton
			// 
			this.IValButton.Location = new Point(344, 192);
			this.IValButton.Name = "IValButton";
			this.IValButton.TabIndex = 34;
			this.IValButton.Text = "Aufteilung";
			this.IValButton.CheckedChanged += new EventHandler(this.IValButton_CheckedChanged);
			// 
			// ComboButton
			// 
			this.ComboButton.Location = new Point(344, 168);
			this.ComboButton.Name = "ComboButton";
			this.ComboButton.TabIndex = 33;
			this.ComboButton.Text = "Kombination";
			this.ComboButton.CheckedChanged += new EventHandler(this.ComboButton_CheckedChanged);
			// 
			// IVal
			// 
			this.IVal.Location = new Point(400, 144);
			this.IVal.Name = "IVal";
			this.IVal.Size = new Size(40, 23);
			this.IVal.TabIndex = 32;
			this.IVal.Value = new Decimal(new int[] {
															   1,
															   0,
															   0,
															   0});
			this.IVal.ValueChanged += new EventHandler(this.IVal_ValueChanged);
			// 
			// label5
			// 
			this.label5.Location = new Point(344, 144);
			this.label5.Name = "label5";
			this.label5.Size = new Size(64, 23);
			this.label5.TabIndex = 31;
			this.label5.Text = "Intervall:";
			this.label5.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new Point(344, 88);
			this.label4.Name = "label4";
			this.label4.TabIndex = 30;
			this.label4.Text = "Text:";
			// 
			// ComboTextBox
			// 
			this.ComboTextBox.BorderStyle = BorderStyle.FixedSingle;
			this.ComboTextBox.Location = new Point(344, 112);
			this.ComboTextBox.Name = "ComboTextBox";
			this.ComboTextBox.Size = new Size(216, 23);
			this.ComboTextBox.TabIndex = 29;
			this.ComboTextBox.Text = "";
			this.ComboTextBox.TextChanged += new EventHandler(this.ComboTextBox_TextChanged);
			// 
			// RemoveQuestionButton
			// 
			this.RemoveQuestionButton.BackColor = Color.LightGray;
			this.RemoveQuestionButton.FlatStyle = FlatStyle.Popup;
			this.RemoveQuestionButton.Location = new Point(344, 48);
			this.RemoveQuestionButton.Name = "RemoveQuestionButton";
			this.RemoveQuestionButton.Size = new Size(160, 32);
			this.RemoveQuestionButton.TabIndex = 28;
			this.RemoveQuestionButton.Text = "Frage löschen";
			this.RemoveQuestionButton.Click += new EventHandler(this.RemoveQuestionButton_Click);
			// 
			// AddQuestionButton
			// 
			this.AddQuestionButton.BackColor = Color.LightGray;
			this.AddQuestionButton.FlatStyle = FlatStyle.Popup;
			this.AddQuestionButton.Location = new Point(344, 8);
			this.AddQuestionButton.Name = "AddQuestionButton";
			this.AddQuestionButton.Size = new Size(160, 32);
			this.AddQuestionButton.TabIndex = 27;
			this.AddQuestionButton.Text = "Frage hinzufügen";
			this.AddQuestionButton.Click += new EventHandler(this.AddQuestionButton_Click);
			// 
			// DeleteComboButton
			// 
			this.DeleteComboButton.BackColor = Color.LightGray;
			this.DeleteComboButton.FlatStyle = FlatStyle.Popup;
			this.DeleteComboButton.Location = new Point(176, 184);
			this.DeleteComboButton.Name = "DeleteComboButton";
			this.DeleteComboButton.Size = new Size(160, 32);
			this.DeleteComboButton.TabIndex = 26;
			this.DeleteComboButton.Text = "Kombination löschen";
			this.DeleteComboButton.Click += new EventHandler(this.DeleteComboButton_Click);
			// 
			// NewComboButton
			// 
			this.NewComboButton.BackColor = Color.LightGray;
			this.NewComboButton.FlatStyle = FlatStyle.Popup;
			this.NewComboButton.Location = new Point(176, 144);
			this.NewComboButton.Name = "NewComboButton";
			this.NewComboButton.Size = new Size(160, 32);
			this.NewComboButton.TabIndex = 25;
			this.NewComboButton.Text = "Neue Kombination";
			this.NewComboButton.Click += new EventHandler(this.NewComboButton_Click);
			// 
			// ComboView
			// 
			this.ComboView.BorderStyle = BorderStyle.FixedSingle;
			this.ComboView.HorizontalScrollbar = true;
			this.ComboView.ItemHeight = 16;
			this.ComboView.Location = new Point(176, 8);
			this.ComboView.Name = "ComboView";
			this.ComboView.Size = new Size(160, 130);
			this.ComboView.TabIndex = 24;
			// 
			// QuestionComboList
			// 
			this.QuestionComboList.BorderStyle = BorderStyle.FixedSingle;
			this.QuestionComboList.HorizontalScrollbar = true;
			this.QuestionComboList.ItemHeight = 16;
			this.QuestionComboList.Location = new Point(8, 8);
			this.QuestionComboList.Name = "QuestionComboList";
			this.QuestionComboList.Size = new Size(160, 210);
			this.QuestionComboList.TabIndex = 23;
			this.QuestionComboList.SelectedIndexChanged += new EventHandler(this.QuestionComboList_SelectedIndexChanged);
			// 
			// ColorTab
			// 
			this.ColorTab.BackColor = Color.Gainsboro;
			this.ColorTab.Controls.Add(this.label2);
			this.ColorTab.Controls.Add(this.PersonSettingsPanel);
			this.ColorTab.Controls.Add(this.PersonBox);
			this.ColorTab.Location = new Point(4, 25);
			this.ColorTab.Name = "ColorTab";
			this.ColorTab.Size = new Size(576, 235);
			this.ColorTab.TabIndex = 0;
			this.ColorTab.Text = "Visualisierung";
			// 
			// HistoryTab
			// 
			this.HistoryTab.BackColor = Color.Gainsboro;
			this.HistoryTab.Controls.Add(this.button3);
			this.HistoryTab.Controls.Add(this.button1);
			this.HistoryTab.Controls.Add(this.button2);
			this.HistoryTab.Controls.Add(this.HistoryList);
			this.HistoryTab.Location = new Point(4, 25);
			this.HistoryTab.Name = "HistoryTab";
			this.HistoryTab.Size = new Size(576, 235);
			this.HistoryTab.TabIndex = 4;
			this.HistoryTab.Text = "Historische Daten";
			// 
			// button3
			// 
			this.button3.BackColor = Color.LightGray;
			this.button3.FlatStyle = FlatStyle.Popup;
			this.button3.Location = new Point(336, 88);
			this.button3.Name = "button3";
			this.button3.Size = new Size(160, 32);
			this.button3.TabIndex = 29;
			this.button3.Text = "Auswertung bearbeiten";
			this.button3.Click += new EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.BackColor = Color.LightGray;
			this.button1.FlatStyle = FlatStyle.Popup;
			this.button1.Location = new Point(336, 48);
			this.button1.Name = "button1";
			this.button1.Size = new Size(160, 32);
			this.button1.TabIndex = 28;
			this.button1.Text = "Auswertung löschen";
			this.button1.Click += new EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = Color.LightGray;
			this.button2.FlatStyle = FlatStyle.Popup;
			this.button2.Location = new Point(336, 8);
			this.button2.Name = "button2";
			this.button2.Size = new Size(160, 32);
			this.button2.TabIndex = 27;
			this.button2.Text = "Auswertung Hinzufügen";
			this.button2.Click += new EventHandler(this.button2_Click);
			// 
			// HistoryList
			// 
			this.HistoryList.BorderStyle = BorderStyle.FixedSingle;
			this.HistoryList.HorizontalScrollbar = true;
			this.HistoryList.ItemHeight = 16;
			this.HistoryList.Location = new Point(8, 8);
			this.HistoryList.Name = "HistoryList";
			this.HistoryList.Size = new Size(320, 210);
			this.HistoryList.TabIndex = 24;
			this.HistoryList.DoubleClick += new EventHandler(this.HistoryList_DoubleClick);
			// 
			// button4
			// 
			this.button4.BackColor = Color.LightGray;
			this.button4.FlatStyle = FlatStyle.Popup;
			this.button4.Location = new Point(176, 184);
			this.button4.Name = "button4";
			this.button4.Size = new Size(216, 32);
			this.button4.TabIndex = 28;
			this.button4.Text = "Als Testbank markieren";
			this.button4.Click += new EventHandler(this.button4_Click_1);
			// 
			// SettingsControl
			// 
			this.BackColor = Color.Gainsboro;
			this.Controls.Add(this.SettingsTabs);
			this.Controls.Add(this.HeaderPanel);
			this.Font = new Font("Arial", 8F);
			this.Name = "SettingsControl";
			this.Size = new Size(608, 512);
			this.VisibleChanged += new EventHandler(this.SettingsControl_VisibleChanged);
			this.HeaderPanel.ResumeLayout(false);
			this.SettingsTabs.ResumeLayout(false);
			this.PersonTab.ResumeLayout(false);
			this.targetTab.ResumeLayout(false);
			this.questionTab.ResumeLayout(false);
			((ISupportInitialize)(this.IVal)).EndInit();
			this.ColorTab.ResumeLayout(false);
			this.HistoryTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void SettingsControl_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible == true)
				StatusControl.Update();
		}

		private void eval_PersonDataChanged(object source)
		{
			UpdateControls();
			cpc = new ChoosePersonControl(eval, false);
			cpc.Dock = DockStyle.Fill;
			ChoosePersonPanel.Controls.Clear();
			ChoosePersonPanel.Controls.Add(cpc);
		}

		private void UpdateControls()
		{
			PersonBox.Items.Clear();
			PersonList.Items.Clear();
			TargetList.Items.Clear();

			foreach (Person p in eval.Persons)
			{
				PersonBox.Items.Add(p);
			}

			if (eval.PersonCombos != null)
				foreach (PersonCombo combo in eval.PersonCombos)
				{
					PersonList.Items.Add(combo);
					PersonBox.Items.Add(combo);
				}

			if (eval.TargetCombos != null)
				foreach (TargetCombo combo in eval.TargetCombos)
				{
					TargetList.Items.Add(combo);
				}

			HistoryList.Items.Clear();

			foreach (HistoricData hd in eval.History)
			{
				HistoryList.Items.Add(hd);
			}
		}

		private void PersonBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				PersonSetting person = (PersonSetting)PersonBox.SelectedItem;
				
				PersonSettingsControl pss = new PersonSettingsControl(person);

				PersonSettingsPanel.Controls.Clear();

				PersonSettingsPanel.Controls.Add(pss);
			}
			catch
			{
			}
		}

		private void PersonTab_Click(object sender, EventArgs e)
		{
		
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			if (cpc.SelectedPersons.Length > 1)
			{
				PersonCombo combo = new PersonCombo();
				combo.Persons = cpc.SelectedPersons;

				eval.AddPersonCombo(combo);

				UpdateControls();
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			PersonCombo todel;

			try
			{
				todel = (PersonCombo)PersonList.SelectedItem;
			}
			catch
			{
				return;
			}

			eval.RemovePersonCombo(todel);

			UpdateControls();
		}

		private void RemoveTarget_Click(object sender, EventArgs e)
		{
			TargetCombo todel;

			try
			{
				todel = (TargetCombo)TargetList.SelectedItem;
			}
			catch
			{
				return;
			}

			eval.RemoveTargetCombo(todel);

			UpdateControls();
		}

		private void AddTarget_Click(object sender, EventArgs e)
		{
			if (ctc.SelectedTargets.Length > 1)
			{
				TargetCombo combo = new TargetCombo(ComboName.Text);
				combo.SetTargets(ctc.SelectedTargets);

				eval.AddTargetCombo(combo);

				UpdateControls();
			}
		}

		private void ctc_SelectionChanged()
		{
			TargetCombo combo = new TargetCombo(ComboName.Text);
			combo.SetTargets(ctc.SelectedTargets);

			ComboName.Text = combo.LongName;
		}

		private void SettingsTabs_SelectedIndexChanged(object sender, EventArgs e)
		{
		
		}

		private void NewComboButton_Click(object sender, EventArgs e)
		{
			QuestionCombo qc = new QuestionCombo(eval);
			eval.AddQuestionCombo(qc);

			UpdateQCombo();

			QuestionComboList.SelectedItem = qc;
		}

		private void UpdateQCombo()
		{
			QuestionComboList.Items.Clear();
			
			foreach (QuestionCombo qc in eval.QuestionCombos)
			{
				QuestionComboList.Items.Add(qc);
//				Console.WriteLine(qc.ID + "");
			}

			QuestionComboList.Refresh();
		}

		private void UpdateQComboList()
		{
			ComboView.Items.Clear();
			if (QuestionComboList.SelectedItem != null)
			{
				QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

				foreach (int id in qc.QuestionList)
				{
					Question q = eval.Global.GetQuestion(id, eval);

					if (q != null)
					ComboView.Items.Add(q);
				}

				ComboTextBox.Text = qc.Text;
				IVal.Value = qc.SplitInterval;
			}
		}

		private void UpdateComboListText(QuestionCombo qc)
		{
			UpdateQCombo();
			QuestionComboList.SelectedItem = qc;
		}

		private void ReCombo()
		{
			bool enable = false;

			if (QuestionComboList.SelectedItem != null)
			{
				UpdateQComboList();
				enable = true;

				QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

				label5.Visible = IVal.Visible = true;

				if (qc.Type == QuestionCombo.TYPE_COMBO)
				{
					ComboButton.Checked = true;
					label5.Visible = IVal.Visible = false;
				}
				else if (qc.Type == QuestionCombo.TYPE_SPLIT)
				{
					IValButton.Checked = true;
				}
			}
			
			ComboView.Enabled = enable;
			//NewComboButton.Enabled = enable;
			DeleteComboButton.Enabled = enable;
			AddQuestionButton.Enabled = enable;
			RemoveQuestionButton.Enabled = enable;
			ComboTextBox.Enabled = enable;
		}

		private void QuestionComboList_SelectedIndexChanged(object sender, EventArgs e)
		{
			ReCombo();
		}

		private void DeleteComboButton_Click(object sender, EventArgs e)
		{
			if (QuestionComboList.SelectedItem != null)
			{
				eval.RemoveQuestionCombo((QuestionCombo)QuestionComboList.SelectedItem);
				UpdateQCombo();
			}
		}

		private void AddQuestionButton_Click(object sender, EventArgs e)
		{
			if (QuestionComboList.SelectedItem != null)
			{
				QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

				QuestionSelect qs = new QuestionSelect(eval);
				if (qs.ShowDialog() == DialogResult.OK  && qs.SelectedQuestions != null)
				{
					foreach (Question q in qs.SelectedQuestions)
					{
						qc.AddID(q.ID);
					}
					UpdateQComboList();
				}
			}
		}

		private void RemoveQuestionButton_Click(object sender, EventArgs e)
		{
			if (QuestionComboList.SelectedItem != null)
			{
				QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

				if (ComboView.SelectedItem != null)
				{
					qc.RemoveID(((Question)ComboView.SelectedItem).ID);
					UpdateQComboList();
				}
			}
		}

		private void ComboTextBox_TextChanged(object sender, EventArgs e)
		{
			if (QuestionComboList.SelectedItem != null)
			{
				QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;
				qc.Text = ComboTextBox.Text;
				UpdateComboListText(qc);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogHistoricData dhd = new DialogHistoricData();
			if (dhd.ShowDialog() == DialogResult.OK)
			{
				HistoricData hd = dhd.Historic;
				eval.AddHistoricData(hd);
				HistoryList.Items.Add(hd);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (HistoryList.SelectedItem != null)
			{
				HistoryList.Items.Remove(HistoryList.SelectedItem);
				eval.RemoveHistoricData((HistoricData)HistoryList.SelectedItem);
			}

			HistoryList.Items.Clear();

			foreach (HistoricData hd in eval.History)
			{
				HistoryList.Items.Add(hd);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (HistoryList.SelectedItem != null)
			{
				DialogHistoricData dhd = new DialogHistoricData((HistoricData)HistoryList.SelectedItem);
				dhd.ShowDialog();
			}
		}

		private void HistoryList_DoubleClick(object sender, EventArgs e)
		{
			if (HistoryList.SelectedItem != null)
			{
				DialogHistoricData dhd = new DialogHistoricData((HistoricData)HistoryList.SelectedItem);
				if (dhd.ShowDialog() == DialogResult.OK)
				{
					HistoryList.Items.Remove(HistoryList.SelectedItem);
					eval.RemoveHistoricData((HistoricData)HistoryList.SelectedItem);
					HistoricData hd = dhd.Historic;
					eval.AddHistoricData(hd);
					HistoryList.Items.Add(hd);
				}
			}
		}

		private void ComboButton_CheckedChanged(object sender, EventArgs e)
		{
			if (ComboButton.Checked)
			{
				IValButton.Checked = false;

				if (QuestionComboList.SelectedItem != null)
				{
					QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

					qc.Type = QuestionCombo.TYPE_COMBO;
				}
				ReCombo();
			}
		}

		private void IValButton_CheckedChanged(object sender, EventArgs e)
		{
			if (IValButton.Checked)
			{
				ComboButton.Checked = false;

				if (QuestionComboList.SelectedItem != null)
				{
					QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

					qc.Type = QuestionCombo.TYPE_SPLIT;
				}
				ReCombo();
			}
		}

		private void IVal_ValueChanged(object sender, EventArgs e)
		{
			if (QuestionComboList.SelectedItem != null)
			{
				QuestionCombo qc = (QuestionCombo)QuestionComboList.SelectedItem;

				qc.SplitInterval = (int)IVal.Value;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			eval.RemoveTarget(ctc.SelectedItem);
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			try
			{
				ctc.SelectedItem.Test = !ctc.SelectedItem.Test;
				eval.ResetGlobal();
				eval.targetCombosChanged(this);
			}
			catch
			{
				
			}
		}
	}
}
