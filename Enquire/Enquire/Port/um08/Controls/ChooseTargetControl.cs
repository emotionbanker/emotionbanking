using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Controls
{
	public delegate void CtcEventHandler();
	public delegate void MethodInvoker();

	/// <summary>
	/// Summary description for ChooseTargetControl.
	/// </summary>
	public class ChooseTargetControl : UserControl
    {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Evaluation eval;

		public event CtcEventHandler SelectionChanged;

		private ArrayList selectedList;
        private TreeView TargetView;
		
		private bool combos;

		public TargetData SelectedItem
		{
			get
			{
                return (TargetData)TargetView.SelectedNode.Tag;
				//return (TargetData)//TargetBox.SelectedItem;
			}
		}

		public TargetData[] SelectedTargets
		{
			get
			{
				TargetData[] p = new TargetData[selectedList.Count];

				for (int i=0; i < selectedList.Count; i++)
					p[i] = (TargetData)selectedList[i];

				return p;
			}
			
		}

		public ChooseTargetControl(Evaluation eval)
		{
			Set(eval, true, true);
		}

		public ChooseTargetControl(Evaluation eval, bool combos, bool check)
		{
			Set(eval, combos, check);
		}

        public bool Checkboxes
        {
            get { return TargetView.CheckBoxes; }
            set { TargetView.CheckBoxes = value; }
        }

		private void Set(Evaluation eval, bool combos, bool check)
		{
			this.eval = eval;
			this.combos = combos;

			InitializeComponent();

			SelectionChanged +=new CtcEventHandler(ChooseTargetControl_SelectionChanged);
			eval.TargetCombosChanged+=new EvaluationEventHandler(eval_TargetCombosChanged);
			eval.ResultDataChanged+=new EvaluationEventHandler(eval_ResultDataChanged);

			foreach (TargetData td in eval.CombinedTargets)
			{
				td.IncludedChanged+=new IncludedChangedEventHandler(td_IncludedChanged);
			}

			UpdateData(check);
		}

		private void UpdateData()
		{
			UpdateData(false);
		}

		private void UpdateData(bool check)
		{
			selectedList = new ArrayList();
//			//TargetBox.Items.Clear();

			//TargetBox.Items.Add(eval.Global);

			//foreach (TargetData t in eval.Targets)
				//TargetBox.Items.Add(t);

			//if (combos)
			//	foreach (TargetData c in eval.GetComboTargets())
					//TargetBox.Items.Add(c);

			//for (int i = 0; i < //TargetBox.Items.Count; i++)
				//TargetBox.SetItemChecked(i, ((TargetData)//TargetBox.Items[i]).Included);


            //new !
            TargetView.Nodes.Clear();

            /*
            if (combos)
            {
                TreeNode gnode = new TreeNode(eval.Global.ToString());
                gnode.Tag = eval.Global;
                gnode.Checked = eval.Global.Included;
                TargetView.Nodes.Add(gnode);
            }
            */
           
            /*
            if (combos)
            {
                foreach (TargetData c in eval.GetComboTargets())
                {
                    TreeNode cnode = new TreeNode(c.ToString());
                    cnode.Tag = c;
                    cnode.Checked = c.Included;
                    if (c.Included) selectedList.Add(c);
                    TargetView.Nodes.Add(cnode);
                }
            }
            */
            foreach (TargetData t in eval.CombinedTargets)
            {
                if (t.masterSplit == null)
                    if (combos || !t.WasCombo)
                        FillTarget(TargetView.Nodes, t);
            }
		}

        private void FillTarget(TreeNodeCollection nodes, TargetData td)
        {
            TreeNode tnode = new TreeNode(td.ToString());
            tnode.Tag = td;
            tnode.Checked = td.Included;
            if (td.Included) selectedList.Add(td);
            foreach (TargetData cd in td.Children)
                FillTarget(tnode.Nodes, cd);
            nodes.Add(tnode);
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
            this.TargetView = new TreeView();
            this.SuspendLayout();
            // 
            // TargetView
            // 
            this.TargetView.BorderStyle = BorderStyle.FixedSingle;
            this.TargetView.CheckBoxes = true;
            this.TargetView.Dock = DockStyle.Fill;
            this.TargetView.HideSelection = false;
            this.TargetView.HotTracking = true;
            this.TargetView.Location = new Point(0, 0);
            this.TargetView.Name = "TargetView";
            this.TargetView.Size = new Size(313, 372);
            this.TargetView.TabIndex = 2;
            this.TargetView.AfterCheck += new TreeViewEventHandler(this.TargetView_AfterCheck);
            // 
            // ChooseTargetControl
            // 
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.TargetView);
            this.Font = new Font("Arial", 8F);
            this.Name = "ChooseTargetControl";
            this.Size = new Size(313, 372);
            this.ResumeLayout(false);

		}
		#endregion

/*
		private void //TargetBox_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if( e.NewValue == CheckState.Checked)
			{
				selectedList.Add(//TargetBox.Items[e.Index]);
				((TargetData)//TargetBox.Items[e.Index]).Included = true;
			}
			else
			{
				selectedList.Remove(//TargetBox.Items[e.Index]);
				((TargetData)//TargetBox.Items[e.Index]).Included = false;
			} 

			SelectionChanged();
		}
        */
		private void ChooseTargetControl_SelectionChanged()
		{
			//do nothing
		}

		private void eval_TargetCombosChanged(object source)
		{
			UpdateData(combos);
		}

		private void eval_ResultDataChanged(object source)
		{
			MethodInvoker m = null;
			m += new MethodInvoker(UpdateData);
			m();
		}

		private void td_IncludedChanged(TargetData sender)
		{
			//Console.WriteLine("setting " + sender.Name + " ("+//TargetBox.Items.IndexOf(sender)+ ") to " + sender.Included);
			////TargetBox.SetItemChecked(//TargetBox.Items.IndexOf(sender), sender.Included);
            //UpdateData(combos);
		}

        private void TargetView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ((TargetData)e.Node.Tag).Included = e.Node.Checked;


            if (e.Node.Checked == true)
            {
                selectedList.Add(e.Node.Tag);
            }
            else
            {
                selectedList.Remove(e.Node.Tag);
            }

            Console.WriteLine("Selected List:");
            foreach (TargetData td in SelectedTargets)
            {
                Console.WriteLine("\t" + td);
            }

            SelectionChanged();
        }
	}
}
