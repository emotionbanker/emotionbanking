using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	public delegate void ColorChangedEvent();
	/// <summary>
	/// Summary description for ChooseColorControl.
	/// </summary>
	public class ChooseColorControl : UserControl
	{
		private Panel CPanel;
		private Label TextLabel;
		private Button ChooseButton;
		private ColorDialog colorDialog;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public event ColorChangedEvent ColorChanged;

		public Color ChosenColor
		{
			get {return ChooseButton.BackColor;}
			set {ChooseButton.BackColor = value; 
				eval.PieColors[text] = value;
				colorDialog.Color = (Color)eval.PieColors[text];
				ColorChanged();}
		}

		private Evaluation eval;
		private string text;

		public ChooseColorControl(Evaluation eval, string text)
		{
			this.eval = eval;
			this.text = text;

			if (eval.PieColors == null)
				eval.PieColors = new Hashtable();

			InitializeComponent();
			
			if (eval.PieColors.ContainsKey(text))
			{
				ChooseButton.BackColor = (Color)eval.PieColors[text];
				colorDialog.Color = (Color)eval.PieColors[text];
			}
			else
			{
				eval.PieColors[text] = Color.White;
			}

			TextLabel.Text = text;

			this.ColorChanged+=new ColorChangedEvent(ChooseColorControl_ColorChanged);
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
			this.CPanel = new Panel();
			this.TextLabel = new Label();
			this.ChooseButton = new Button();
			this.colorDialog = new ColorDialog();
			this.CPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// CPanel
			// 
			this.CPanel.Controls.Add(this.ChooseButton);
			this.CPanel.Dock = DockStyle.Right;
			this.CPanel.Location = new Point(256, 0);
			this.CPanel.Name = "CPanel";
			this.CPanel.Size = new Size(64, 26);
			this.CPanel.TabIndex = 1;
			// 
			// TextLabel
			// 
			this.TextLabel.Dock = DockStyle.Fill;
			this.TextLabel.Location = new Point(0, 0);
			this.TextLabel.Name = "TextLabel";
			this.TextLabel.Size = new Size(256, 26);
			this.TextLabel.TabIndex = 2;
			// 
			// ChooseButton
			// 
			this.ChooseButton.BackColor = Color.White;
			this.ChooseButton.FlatStyle = FlatStyle.Popup;
			this.ChooseButton.Font = new Font("Arial", 8F);
			this.ChooseButton.Location = new Point(8, 0);
			this.ChooseButton.Name = "ChooseButton";
			this.ChooseButton.Size = new Size(48, 24);
			this.ChooseButton.TabIndex = 0;
			this.ChooseButton.Click += new EventHandler(this.ChooseButton_Click);
			// 
			// colorDialog
			// 
			this.colorDialog.Color = Color.White;
			// 
			// ChooseColorControl
			// 
			this.BackColor = Color.Gainsboro;
			this.Controls.Add(this.TextLabel);
			this.Controls.Add(this.CPanel);
			this.Name = "ChooseColorControl";
			this.Size = new Size(320, 26);
			this.CPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ChooseButton_Click(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				ChooseButton.BackColor = colorDialog.Color;
				eval.PieColors[text] = colorDialog.Color;
				ColorChanged();
			}
		}

		private void ChooseColorControl_ColorChanged()
		{

		}
	}
}
