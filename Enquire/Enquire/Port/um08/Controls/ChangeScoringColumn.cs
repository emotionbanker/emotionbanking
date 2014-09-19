using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Zusammenfassung für ChangeScoringColumn.
	/// </summary>
	public class ChangeScoringColumn : UserControl
	{
		private TextBox ValBox;
		private Label NameLabel;
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private Container components = null;

		private string name;
        private CheckBox IncBox;
		private float val;


        public bool Included
        {
            get
            {
                return IncBox.Checked;
            }
        }

		public string Txt
		{
			get
			{
				return name;
			}
		}

		public float Value
		{
			get
			{
				try
				{
					return float.Parse(ValBox.Text);
				}
				catch
				{
					return val;
				}
			}
		}

		public ChangeScoringColumn(string name, float val)
		{
			this.name = name;
			this.val = val;

			InitializeComponent();

			NameLabel.Text = name;
			ValBox.Text = val.ToString();
		}

		/// <summary> 
		/// Die verwendeten Ressourcen bereinigen.
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

		#region Vom Komponenten-Designer generierter Code
		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.ValBox = new TextBox();
            this.NameLabel = new Label();
            this.IncBox = new CheckBox();
            this.SuspendLayout();
            // 
            // ValBox
            // 
            this.ValBox.BorderStyle = BorderStyle.FixedSingle;
            this.ValBox.Dock = DockStyle.Right;
            this.ValBox.Location = new Point(416, 0);
            this.ValBox.Name = "ValBox";
            this.ValBox.Size = new Size(80, 22);
            this.ValBox.TabIndex = 1;
            this.ValBox.Leave += new EventHandler(this.ValBox_Leave);
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = DockStyle.Fill;
            this.NameLabel.Location = new Point(13, 0);
            this.NameLabel.Margin = new Padding(0, 3, 0, 3);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new Size(403, 24);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // IncBox
            // 
            this.IncBox.AutoSize = true;
            this.IncBox.Checked = true;
            this.IncBox.CheckState = CheckState.Checked;
            this.IncBox.Dock = DockStyle.Left;
            this.IncBox.FlatStyle = FlatStyle.Popup;
            this.IncBox.Location = new Point(0, 0);
            this.IncBox.Margin = new Padding(3, 3, 3, 30);
            this.IncBox.Name = "IncBox";
            this.IncBox.Size = new Size(13, 24);
            this.IncBox.TabIndex = 3;
            this.IncBox.UseVisualStyleBackColor = true;
            // 
            // ChangeScoringColumn
            // 
            this.BackColor = Color.Gainsboro;
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IncBox);
            this.Controls.Add(this.ValBox);
            this.Name = "ChangeScoringColumn";
            this.Size = new Size(496, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ValBox_Leave(object sender, EventArgs e)
		{
			try
			{
				float.Parse(ValBox.Text);
			}
			catch
			{
				MessageBox.Show("Der eingegebene Wert ist keine gültige Zahl!", "Fehler");
				ValBox.Text = val.ToString();
			}
		}
	}
}
