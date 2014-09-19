using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	/// <summary>
	/// Summary description for ReportControl.
	/// </summary>
	public class ReportControl : UserControl
	{
		private Panel HeaderPanel;
		private Label label1;
		private PictureBox pictureBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private DataStatusControl StatusControl;
		private ListBox ReportList;
		private Button NewReportButton;
		private Button DeleteReportButton;
		private ListBox OutputList;
		private Button AddOutputButton;
		private Button DeleteOutputButton;
		private Button EditOutputButton;
		private Button StartReportButton;
		private ContextMenu AddMenu;
		private MenuItem menuItem1;
		private GroupBox ControlBox;
		private MenuItem menuItem2;
		private MenuItem menuItem3;
		private MenuItem menuItem4;
		private MenuItem menuItem5;
		private MenuItem menuItem6;
		private MenuItem menuItem7;
		private MenuItem menuItem8;
		private MenuItem menuItem9;
		private MenuItem menuItem10;
		private MenuItem menuItem11;
		private MenuItem menuItem12;
		private MenuItem menuItem13;
		private MenuItem menuItem14;
		private Button RenameReport;
		private MenuItem menuItem15;
		private Button CloneReportButton;

		private Evaluation eval;

		public ReportControl(Evaluation eval)
		{
			this.eval = eval;
			InitializeComponent();

			StatusControl = new DataStatusControl(eval);
			StatusControl.Location = new Point(8,88);

			this.Controls.Add(StatusControl);

			UpdateReportData();
			UpdateOutputData();
			UpdateControls();

			eval.ReportDataChanged+=new EvaluationEventHandler(eval_ReportDataChanged);
			eval.OutputDataChanged+=new EvaluationEventHandler(eval_OutputDataChanged);
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

		private void UpdateReportData()
		{
			if (eval.Reports == null)
				eval.Reports = new Report[0];

			ReportList.Items.Clear();
			foreach (Report r in eval.Reports)
				ReportList.Items.Add(r);

			UpdateOutputData();
		}

		private void UpdateOutputData()
		{
			OutputList.Items.Clear();
			if (ReportList.SelectedItem != null)
			{
				foreach (Output.Output o in ((Report)ReportList.SelectedItem).Outputs)
				{
					OutputList.Items.Add(o);
				}
			}
		}

		private void UpdateControls()
		{
			UpdateControls(true);
		}

		private void UpdateControls(bool outputdata)
		{
			bool val;
			if (ReportList.SelectedItem == null)
			{
				//disable all
				val = false;
				OutputList.Items.Clear();
			}
			else
			{
				//enable all
				val = true;
				//clear outputlist
				if (outputdata)
					UpdateOutputData();
			}

			DeleteReportButton.Enabled = val;
			StartReportButton.Enabled  = val;
			OutputList.Enabled = val;

			try
			{
				if (OutputList.SelectedItem == null)
				{
					//disable all
					val = false;
				}
				else
				{
					//enable all
					val = true;
				}
			}
			catch
			{
				val = true;
			}

			EditOutputButton.Enabled = val;
			DeleteOutputButton.Enabled = val;

			
			AddOutputButton.Enabled = OutputList.Enabled;

			Refresh();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			ResourceManager resources = new ResourceManager(typeof(ReportControl));
			this.HeaderPanel = new Panel();
			this.label1 = new Label();
			this.pictureBox1 = new PictureBox();
			this.ControlBox = new GroupBox();
			this.RenameReport = new Button();
			this.EditOutputButton = new Button();
			this.DeleteOutputButton = new Button();
			this.AddOutputButton = new Button();
			this.OutputList = new ListBox();
			this.StartReportButton = new Button();
			this.DeleteReportButton = new Button();
			this.NewReportButton = new Button();
			this.ReportList = new ListBox();
			this.AddMenu = new ContextMenu();
			this.menuItem1 = new MenuItem();
			this.menuItem2 = new MenuItem();
			this.menuItem3 = new MenuItem();
			this.menuItem4 = new MenuItem();
			this.menuItem5 = new MenuItem();
			this.menuItem6 = new MenuItem();
			this.menuItem7 = new MenuItem();
			this.menuItem8 = new MenuItem();
			this.menuItem9 = new MenuItem();
			this.menuItem15 = new MenuItem();
			this.menuItem10 = new MenuItem();
			this.menuItem11 = new MenuItem();
			this.menuItem12 = new MenuItem();
			this.menuItem13 = new MenuItem();
			this.menuItem14 = new MenuItem();
			this.CloneReportButton = new Button();
			this.HeaderPanel.SuspendLayout();
			this.ControlBox.SuspendLayout();
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
			this.HeaderPanel.Size = new Size(648, 80);
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
			this.label1.Text = "Berichte";
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
			// ControlBox
			// 
			this.ControlBox.Controls.Add(this.CloneReportButton);
			this.ControlBox.Controls.Add(this.RenameReport);
			this.ControlBox.Controls.Add(this.EditOutputButton);
			this.ControlBox.Controls.Add(this.DeleteOutputButton);
			this.ControlBox.Controls.Add(this.AddOutputButton);
			this.ControlBox.Controls.Add(this.OutputList);
			this.ControlBox.Controls.Add(this.StartReportButton);
			this.ControlBox.Controls.Add(this.DeleteReportButton);
			this.ControlBox.Controls.Add(this.NewReportButton);
			this.ControlBox.Controls.Add(this.ReportList);
			this.ControlBox.Location = new Point(8, 216);
			this.ControlBox.Name = "ControlBox";
			this.ControlBox.Size = new Size(632, 328);
			this.ControlBox.TabIndex = 3;
			this.ControlBox.TabStop = false;
			this.ControlBox.Text = "Berichte";
			this.ControlBox.Enter += new EventHandler(this.ControlBox_Enter);
			// 
			// RenameReport
			// 
			this.RenameReport.BackColor = Color.LightGray;
			this.RenameReport.FlatStyle = FlatStyle.Popup;
			this.RenameReport.Location = new Point(8, 160);
			this.RenameReport.Name = "RenameReport";
			this.RenameReport.Size = new Size(208, 32);
			this.RenameReport.TabIndex = 28;
			this.RenameReport.Text = "Bericht umbenennen";
			this.RenameReport.Click += new EventHandler(this.ReportList_DoubleClick);
			// 
			// EditOutputButton
			// 
			this.EditOutputButton.BackColor = Color.LightGray;
			this.EditOutputButton.FlatStyle = FlatStyle.Popup;
			this.EditOutputButton.Location = new Point(432, 112);
			this.EditOutputButton.Name = "EditOutputButton";
			this.EditOutputButton.Size = new Size(168, 32);
			this.EditOutputButton.TabIndex = 27;
			this.EditOutputButton.Text = "Auswertung bearbeiten";
			this.EditOutputButton.Click += new EventHandler(this.EditOutputButton_Click);
			// 
			// DeleteOutputButton
			// 
			this.DeleteOutputButton.BackColor = Color.LightGray;
			this.DeleteOutputButton.FlatStyle = FlatStyle.Popup;
			this.DeleteOutputButton.Location = new Point(432, 152);
			this.DeleteOutputButton.Name = "DeleteOutputButton";
			this.DeleteOutputButton.Size = new Size(168, 32);
			this.DeleteOutputButton.TabIndex = 26;
			this.DeleteOutputButton.Text = "Auswertung löschen";
			this.DeleteOutputButton.Click += new EventHandler(this.DeleteOutputButton_Click);
			// 
			// AddOutputButton
			// 
			this.AddOutputButton.BackColor = Color.LightGray;
			this.AddOutputButton.FlatStyle = FlatStyle.Popup;
			this.AddOutputButton.Location = new Point(432, 24);
			this.AddOutputButton.Name = "AddOutputButton";
			this.AddOutputButton.Size = new Size(192, 32);
			this.AddOutputButton.TabIndex = 25;
			this.AddOutputButton.Text = "Auswertung hinzufügen ->";
			this.AddOutputButton.Click += new EventHandler(this.AddOutputButton_Click);
			// 
			// OutputList
			// 
			this.OutputList.AllowDrop = true;
			this.OutputList.BorderStyle = BorderStyle.FixedSingle;
			this.OutputList.HorizontalScrollbar = true;
			this.OutputList.ItemHeight = 16;
			this.OutputList.Location = new Point(224, 24);
			this.OutputList.Name = "OutputList";
			this.OutputList.Size = new Size(200, 242);
			this.OutputList.TabIndex = 24;
			this.OutputList.MouseDown += new MouseEventHandler(this.OutputList_MouseDown);
			this.OutputList.DoubleClick += new EventHandler(this.OutputList_DoubleClick);
			this.OutputList.MouseUp += new MouseEventHandler(this.OutputList_MouseUp);
			this.OutputList.MouseMove += new MouseEventHandler(this.OutputList_MouseMove);
			this.OutputList.SelectedIndexChanged += new EventHandler(this.OutputList_SelectedIndexChanged);
			// 
			// StartReportButton
			// 
			this.StartReportButton.BackColor = Color.LightGray;
			this.StartReportButton.FlatStyle = FlatStyle.Popup;
			this.StartReportButton.Location = new Point(224, 280);
			this.StartReportButton.Name = "StartReportButton";
			this.StartReportButton.Size = new Size(200, 32);
			this.StartReportButton.TabIndex = 23;
			this.StartReportButton.Text = "Bericht auswerten...";
			this.StartReportButton.Click += new EventHandler(this.StartReportButton_Click);
			// 
			// DeleteReportButton
			// 
			this.DeleteReportButton.BackColor = Color.LightGray;
			this.DeleteReportButton.FlatStyle = FlatStyle.Popup;
			this.DeleteReportButton.Location = new Point(8, 280);
			this.DeleteReportButton.Name = "DeleteReportButton";
			this.DeleteReportButton.Size = new Size(208, 32);
			this.DeleteReportButton.TabIndex = 22;
			this.DeleteReportButton.Text = "Bericht löschen";
			this.DeleteReportButton.Click += new EventHandler(this.DeleteReportButton_Click);
			// 
			// NewReportButton
			// 
			this.NewReportButton.BackColor = Color.LightGray;
			this.NewReportButton.FlatStyle = FlatStyle.Popup;
			this.NewReportButton.Location = new Point(8, 200);
			this.NewReportButton.Name = "NewReportButton";
			this.NewReportButton.Size = new Size(208, 32);
			this.NewReportButton.TabIndex = 20;
			this.NewReportButton.Text = "Neuer Bericht";
			this.NewReportButton.Click += new EventHandler(this.NewReportButton_Click);
			// 
			// ReportList
			// 
			this.ReportList.AllowDrop = true;
			this.ReportList.BorderStyle = BorderStyle.FixedSingle;
			this.ReportList.HorizontalScrollbar = true;
			this.ReportList.ItemHeight = 16;
			this.ReportList.Location = new Point(8, 24);
			this.ReportList.Name = "ReportList";
			this.ReportList.Size = new Size(208, 130);
			this.ReportList.TabIndex = 0;
			this.ReportList.DoubleClick += new EventHandler(this.ReportList_DoubleClick);
			this.ReportList.DragOver += new DragEventHandler(this.ReportList_DragOver);
			this.ReportList.DragDrop += new DragEventHandler(this.ReportList_DragDrop);
			this.ReportList.DragEnter += new DragEventHandler(this.ReportList_DragEnter);
			this.ReportList.SelectedIndexChanged += new EventHandler(this.ReportList_SelectedIndexChanged);
			// 
			// AddMenu
			// 
			this.AddMenu.MenuItems.AddRange(new MenuItem[] {
																					this.menuItem1,
																					this.menuItem2,
																					this.menuItem3,
																					this.menuItem4,
																					this.menuItem5,
																					this.menuItem6,
																					this.menuItem7,
																					this.menuItem8,
																					this.menuItem9,
																					this.menuItem15,
																					this.menuItem10,
																					this.menuItem11,
																					this.menuItem12,
																					this.menuItem13,
																					this.menuItem14});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Prozentmatrix";
			this.menuItem1.Click += new EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Matrix";
			this.menuItem2.Click += new EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "-";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "Tortendiagramm";
			this.menuItem4.Click += new EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 4;
			this.menuItem5.Text = "Balkendiagramm";
			this.menuItem5.Click += new EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 5;
			this.menuItem6.Text = "-";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 6;
			this.menuItem7.Text = "Polaritätenprofil";
			this.menuItem7.Click += new EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 7;
			this.menuItem8.Text = "Gaps";
			this.menuItem8.Click += new EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 8;
			this.menuItem9.Text = "Mittelwerte";
			this.menuItem9.Click += new EventHandler(this.menuItem9_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 9;
			this.menuItem15.Text = "MW- Kreuzung";
			this.menuItem15.Click += new EventHandler(this.menuItem15_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 10;
			this.menuItem10.Text = "Ranking";
			this.menuItem10.Click += new EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 11;
			this.menuItem11.Text = "-";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 12;
			this.menuItem12.Text = "Offene Fragen";
			this.menuItem12.Click += new EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 13;
			this.menuItem13.Text = "-";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 14;
			this.menuItem14.Text = "Barometer";
			this.menuItem14.Click += new EventHandler(this.menuItem14_Click);
			// 
			// CloneReportButton
			// 
			this.CloneReportButton.BackColor = Color.LightGray;
			this.CloneReportButton.FlatStyle = FlatStyle.Popup;
			this.CloneReportButton.Location = new Point(8, 240);
			this.CloneReportButton.Name = "CloneReportButton";
			this.CloneReportButton.Size = new Size(208, 32);
			this.CloneReportButton.TabIndex = 29;
			this.CloneReportButton.Text = "Bericht klonen";
			this.CloneReportButton.Click += new EventHandler(this.CloneReportButton_Click);
			// 
			// ReportControl
			// 
			this.BackColor = Color.Gainsboro;
			this.Controls.Add(this.ControlBox);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "ReportControl";
			this.Size = new Size(648, 552);
			this.Load += new EventHandler(this.ReportControl_Load);
			this.HeaderPanel.ResumeLayout(false);
			this.ControlBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void TargetCountLabel_Click(object sender, EventArgs e)
		{
		
		}

		private void ReportControl_Load(object sender, EventArgs e)
		{
		
		}

		private void label2_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible == true)
				StatusControl.UpdateData();
		}

		private void ReportList_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateControls();
			UpdateOutputData();
		}

		private void NewReportButton_Click(object sender, EventArgs e)
		{
			Report n = new Report("Neuer Bericht");
			DialogReport dr = new DialogReport(n);

			if (dr.ShowDialog() == DialogResult.OK)
				eval.AddReport(n);
		}

		private void eval_ReportDataChanged(object source)
		{
			UpdateReportData();
			UpdateControls();
		}

		private void DeleteReportButton_Click(object sender, EventArgs e)
		{
			if (ReportList.SelectedItem != null)
				eval.RemoveReport((Report)ReportList.SelectedItem);
		}

		private void AddOutput(Output.Output o)
		{
			Report report;
			try
			{
				report = (Report)ReportList.SelectedItem;
			}
			catch
			{
				return;
			}

			//SingleMatrix sm = new SingleMatrix(eval);
			//sm.Name = "single matrix";

			report.AddOutput(o);

			//UpdateOutputData();
		}

		private void AddOutputButton_Click(object sender, EventArgs e)
		{
			AddMenu.Show(ControlBox, new Point(400,56));
			////
			
		}

		private void eval_OutputDataChanged(object source)
		{
			UpdateOutputData();
		}

		private void OutputList_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateControls(false);
		}

		private void DeleteOutputButton_Click(object sender, EventArgs e)
		{
			if (ReportList.SelectedItem != null)
			{
				Report r = (Report)ReportList.SelectedItem;
				Console.WriteLine(r);
				Console.WriteLine("si=" + OutputList.SelectedIndex);
				if (OutputList.SelectedIndex != -1)
					r.RemoveOutput((Output.Output)OutputList.Items[OutputList.SelectedIndex]);
			}

			UpdateOutputData();
		}

		private void ReportList_DoubleClick(object sender, EventArgs e)
		{
			if (ReportList.SelectedItem != null)
			{
				Report r = (Report)ReportList.SelectedItem;

				DialogReport dr = new DialogReport(r);
				dr.ShowDialog();

				UpdateReportData();
				
				ReportList.SelectedItem = r;

				UpdateControls();
			}
		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			OutputFormSingleMatrix ofsm = new OutputFormSingleMatrix(eval, false);
			if (ofsm.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofsm.sm);
			}
			UpdateOutputData();
		}

		private void EditOutputButton_Click(object sender, EventArgs e)
		{
			EditOutput();
		}

		private void OutputList_DoubleClick(object sender, EventArgs e)
		{
			EditOutput();
		}

		private void EditOutput()
		{
			if (OutputList.SelectedIndex != -1)
			{
				Output.Output p  = ((Output.Output)OutputList.Items[OutputList.SelectedIndex]);//.SelectedItem);

				p.EditDialog();

				UpdateOutputData();
			}
		}

		private void menuItem2_Click(object sender, EventArgs e)
		{
			OutputFormMultiMatrix ofmm = new OutputFormMultiMatrix(eval, false);
			if (ofmm.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofmm.mm);
			}
			UpdateOutputData();
		}

		private void StartReportButton_Click(object sender, EventArgs e)
		{
			if (ReportList.SelectedItem != null)
			{
				Report r = (Report)ReportList.SelectedItem;

				SaveReportDialog srd = new SaveReportDialog(eval, r);
				srd.ShowDialog();
			}
		}

		private void menuItem4_Click(object sender, EventArgs e)
		{
			OutputFormPie ofp = new OutputFormPie(eval, false);
			if (ofp.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofp.pie);
			}
			UpdateOutputData();
		}

		private void menuItem5_Click(object sender, EventArgs e)
		{
			OutputFormBar ofb = new OutputFormBar(eval, false);
			if (ofb.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofb.bar);
			}
			UpdateOutputData();
		}

		private void menuItem7_Click(object sender, EventArgs e)
		{
			OutputFormPolarity ofp = new OutputFormPolarity(eval, false);
			if (ofp.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofp.pol);
			}
			UpdateOutputData();
		}

		private void menuItem8_Click(object sender, EventArgs e)
		{
			OutputFormGaps ofg = new OutputFormGaps(eval, false);
			if (ofg.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofg.gap);
			}
			UpdateOutputData();
		}

		private void menuItem9_Click(object sender, EventArgs e)
		{
			OutputFormAverages ofa = new OutputFormAverages(eval, false);
			if (ofa.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofa.avg);
			}
			UpdateOutputData();
		}

		private void menuItem10_Click(object sender, EventArgs e)
		{
			OutputFormRank ofr = new OutputFormRank(eval, false);
			if (ofr.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofr.rank);
			}
			UpdateOutputData();
		}

		private void menuItem12_Click(object sender, EventArgs e)
		{
			OutputFormOpen ofo = new OutputFormOpen(eval, false);
			if (ofo.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofo.open);
			}
			UpdateOutputData();
		}

		private void menuItem14_Click(object sender, EventArgs e)
		{
			OutputFormBarometer ofb = new OutputFormBarometer(eval,false);
			if (ofb.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofb.bar);
			}
			UpdateOutputData();
		}

		private void ControlBox_Enter(object sender, EventArgs e)
		{
		
		}

		private void OutputList_DragDrop(object sender, DragEventArgs e)
		{
			this.Cursor = Cursors.Hand;
		}

		private Report OldDrag = null;
		private Output.Output DragOut = null;

		private void OutputList_MouseDown(object sender, MouseEventArgs e)
		{
			int indexOfItem = OutputList.IndexFromPoint(e.X, e.Y);

			Console.WriteLine("outputlist_index=" + indexOfItem);

			if (indexOfItem != -1) OutputList.SelectedIndex = indexOfItem;


			try
			{
				OldDrag = (Report)ReportList.SelectedItem;

				DragOut = (Output.Output)OutputList.Items[indexOfItem];

				if (e.Clicks < 2)
					OutputList.DoDragDrop(OutputList.Items[indexOfItem], DragDropEffects.Move );
			}
			catch
			{
			}

			
			

			this.UpdateControls(false);

			Console.WriteLine("dragout = " + DragOut);
		}

		private void ReportList_DragEnter(object sender, DragEventArgs e)
		{
			// change the drag cursor to show valid data ready

			e.Effect = DragDropEffects.Move;
		}

		private void ReportList_DragOver(object sender, DragEventArgs e)
		{
			Point p = ReportList.PointToClient(new Point(e.X,e.Y));
			
			int indexOfItem = ReportList.IndexFromPoint(p.X, p.Y);

			ReportList.SelectedIndex = indexOfItem;
		}

		private void ReportList_DragDrop(object sender, DragEventArgs e)
		{
			Console.WriteLine("dragdrop!");
			Point p = ReportList.PointToClient(new Point(e.X,e.Y));
			
			int indexOfItem = ReportList.IndexFromPoint(p.X, p.Y);

			Output.Output o = DragOut;//(Output)e.Data.GetData(typeof(Output));
			Report r = (Report)ReportList.Items[indexOfItem];

			Console.WriteLine("ioi=" + indexOfItem);
			Console.WriteLine("OldDrag=" + OldDrag);
			Console.WriteLine("r=" + r);
			Console.WriteLine("o=" + o);

			if (indexOfItem != -1 && OldDrag != null && r != null && o != null)
			{
				OldDrag.RemoveOutput(o);
				r.AddOutput(o);
			}
			else
			{
				Console.WriteLine("queries failed");
			}

			this.UpdateControls(true);
			//DragOut = null;
			//OldDrag = null;
		}

		private void OutputList_MouseMove(object sender, MouseEventArgs e)
		{
		
		}

		private void menuItem15_Click(object sender, EventArgs e)
		{
			OutputFormCrossAverages ofa = new OutputFormCrossAverages(eval, false);
			if (ofa.ShowDialog() == DialogResult.OK)
			{
				AddOutput(ofa.avg);
			}
			UpdateOutputData();
		}

		private void OutputList_MouseUp(object sender, MouseEventArgs e)
		{
			int indexOfItem = OutputList.IndexFromPoint(e.X, e.Y);
			if (indexOfItem != -1) OutputList.SelectedIndex = indexOfItem;
		}

		private void CloneReportButton_Click(object sender, EventArgs e)
		{
			if (ReportList.SelectedItem != null)
			{
				Report n = ((Report)ReportList.SelectedItem).Clone;
				DialogReport dr = new DialogReport(n);

				if (dr.ShowDialog() == DialogResult.OK)
					eval.AddReport(n);
			}
		}
	}
}
