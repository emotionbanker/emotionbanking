using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Dialogs
{
	public class DialogImport : DialogTemplate
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		private Button EndButton;
		private Button SaveButton;
		private Button BrowseButton;
		private TextBox PathBox;
		private Label label2;
		private IContainer components = null;


		private Evaluation eval;
		private Label label3;
		private ComboBox PersonBox;
		private ComboBox TargetBox;
		private Label label4;
		private OpenFileDialog openFileDialog;
		private FolderBrowserDialog folderBrowserDialog;

		private bool folder;

		public string Filename
		{
			get {return PathBox.Text;}
		}

		public DialogImport(Evaluation eval, bool folder)
		{
			InitializeComponent();

			this.CancelButton = EndButton;

			this.eval = eval;
			this.folder = folder;

			foreach (Person p in eval.Persons)
				PersonBox.Items.Add(p);

			foreach (TargetData td in eval.Targets)
				TargetBox.Items.Add(td);
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
			ResourceManager resources = new ResourceManager(typeof(DialogImport));
			this.HeaderPanel = new Panel();
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.EndButton = new Button();
			this.SaveButton = new Button();
			this.BrowseButton = new Button();
			this.PathBox = new TextBox();
			this.label2 = new Label();
			this.label3 = new Label();
			this.PersonBox = new ComboBox();
			this.TargetBox = new ComboBox();
			this.label4 = new Label();
			this.openFileDialog = new OpenFileDialog();
			this.folderBrowserDialog = new FolderBrowserDialog();
			this.HeaderPanel.SuspendLayout();
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
			this.HeaderPanel.Size = new Size(538, 80);
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
			this.label1.Text = "Ergebnisimport";
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
			// EndButton
			// 
			this.EndButton.BackColor = Color.LightGray;
			this.EndButton.FlatStyle = FlatStyle.Popup;
			this.EndButton.Location = new Point(176, 224);
			this.EndButton.Name = "EndButton";
			this.EndButton.Size = new Size(168, 32);
			this.EndButton.TabIndex = 25;
			this.EndButton.Text = "Abbrechen";
			// 
			// SaveButton
			// 
			this.SaveButton.BackColor = Color.LightGray;
			this.SaveButton.FlatStyle = FlatStyle.Popup;
			this.SaveButton.Location = new Point(352, 224);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new Size(168, 32);
			this.SaveButton.TabIndex = 24;
			this.SaveButton.Text = "Importieren";
			this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
			// 
			// BrowseButton
			// 
			this.BrowseButton.BackColor = Color.LightGray;
			this.BrowseButton.FlatStyle = FlatStyle.Popup;
			this.BrowseButton.Location = new Point(456, 96);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new Size(64, 24);
			this.BrowseButton.TabIndex = 21;
			this.BrowseButton.Text = "ändern...";
			this.BrowseButton.Click += new EventHandler(this.BrowseButton_Click);
			// 
			// PathBox
			// 
			this.PathBox.BorderStyle = BorderStyle.FixedSingle;
			this.PathBox.Location = new Point(80, 96);
			this.PathBox.Name = "PathBox";
			this.PathBox.Size = new Size(360, 23);
			this.PathBox.TabIndex = 20;
			this.PathBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new Point(-16, 96);
			this.label2.Name = "label2";
			this.label2.Size = new Size(88, 24);
			this.label2.TabIndex = 19;
			this.label2.Text = "Datei:";
			this.label2.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new Point(0, 136);
			this.label3.Name = "label3";
			this.label3.Size = new Size(128, 24);
			this.label3.TabIndex = 26;
			this.label3.Text = "Personengruppe:";
			this.label3.TextAlign = ContentAlignment.MiddleRight;
			// 
			// PersonBox
			// 
			this.PersonBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.PersonBox.Location = new Point(128, 136);
			this.PersonBox.Name = "PersonBox";
			this.PersonBox.Size = new Size(208, 24);
			this.PersonBox.TabIndex = 27;
			// 
			// TargetBox
			// 
			this.TargetBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TargetBox.Location = new Point(128, 168);
			this.TargetBox.Name = "TargetBox";
			this.TargetBox.Size = new Size(208, 24);
			this.TargetBox.TabIndex = 29;
			// 
			// label4
			// 
			this.label4.Location = new Point(0, 168);
			this.label4.Name = "label4";
			this.label4.Size = new Size(128, 24);
			this.label4.TabIndex = 28;
			this.label4.Text = "Ziel:";
			this.label4.TextAlign = ContentAlignment.MiddleRight;
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "xls";
			this.openFileDialog.Filter = "Excel Dateien|*.xls";
			this.openFileDialog.Title = "Importieren";
			// 
			// DialogImport
			// 
			this.AutoScaleBaseSize = new Size(6, 16);
			this.BackColor = Color.Gainsboro;
			this.ClientSize = new Size(538, 270);
			this.Controls.Add(this.TargetBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.PersonBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.EndButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.BrowseButton);
			this.Controls.Add(this.PathBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "DialogImport";
			this.HeaderPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void SaveButton_Click(object sender, EventArgs e)
		{
			ImportExcel ei = new ImportExcel(eval);

			TargetData td = null;
			Person p = null;
			try
			{
				td = (TargetData)TargetBox.SelectedItem;
				p = (Person)PersonBox.SelectedItem;
			}
			catch
			{
				MessageBox.Show("Bitte Personengruppe und Ziel auswählen", "Eingabefehler");
				return;
			}

			if (td == null || p == null)
			{
				MessageBox.Show("Bitte Personengruppe und Ziel auswählen", "Eingabefehler");
				return;
			}

			if (!folder)
			{
				if (ei.ImportFile(this.Filename, td, p))
				{
					MessageBox.Show("Daten für 1 neuen Benutzer hinzugefügt", "Import abgeschlossen");
				}
				else
				{
					MessageBox.Show("Fehler beim importieren!", "Import nicht abgeschlossen");
				}
			}
			else
			{
				int num = ei.ImportFolder(this.Filename, td, p);
				
				MessageBox.Show("Daten für "+num+" neue(n) Benutzer hinzugefügt", "Import abgeschlossen");
			}
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			if (!folder)
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
					PathBox.Text = openFileDialog.FileName;
			}
			else
			{
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
					PathBox.Text = folderBrowserDialog.SelectedPath;
			}
		}
	}
}