using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output.DNCGeneric;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;
using umfrage2._2008;
using dotnetCHARTING.WinForms;


namespace umfrage2._2007.Controls
{
    public partial class OutputControl_DNCGeneric : UserControl
    {
		private Evaluation eval;
		public DNCGeneric dnc;
		private Crossing cross;
		private OutputNameControl onc;
        private ChoosePersonControl cpp;
		
		private bool single;

		public OutputControl_DNCGeneric(Evaluation eval)
		{
            Set(eval, true, new DNCGeneric(eval));
		}

		public OutputControl_DNCGeneric(Evaluation eval, bool single)
		{
            Set(eval, single, new DNCGeneric(eval));
		}

        public OutputControl_DNCGeneric(Evaluation eval, bool single, DNCGeneric dnc)
		{
            Set(eval, single, dnc);

            cpp.SetSelection(dnc.PersonList, dnc.ComboList);

            sizeControl.SetSize(dnc.width, dnc.height);

            Preview();
		}

        private void Set(Evaluation eval, bool single, DNCGeneric dnc)
		{
			this.single = single;
			this.eval = eval;
            this.dnc = dnc;

			InitializeComponent();

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_SizeChanged);

            cpp = new ChoosePersonControl(eval);
            cpp.SetSelection(dnc.PersonList, dnc.ComboList);
            cpp.SelectionChanged += new CppEventHandler(cpp_SelectionChanged);
            cpp.Dock = DockStyle.Fill;

            PersonPanel.Controls.Add(cpp);

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(dnc.Cross);


            foreach (ChartType ct in Enum.GetValues(typeof(ChartType)))
                ChartTypeSelect.Items.Add(ct);

            ChartTypeSelect.SelectedItem = dnc.DNCType;

            if (dnc.SType == DNCGeneric.SeriesType.UserGroup) UGSel.Checked = true;

            SetColBox();
		}

        private void cpp_SelectionChanged()
        {
            Preview();
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>

        private void Preview()
        {
            Preview(false);
        }

        private void Preview(bool bigOnly)
        {
            dnc.PersonList = cpp.SelectedPersons;
            dnc.ComboList = cpp.SelectedCombos;

            dnc.height = sizeControl.ChosenHeight;
            dnc.width = sizeControl.ChosenWidth;
            dnc.Compute();

            previewBox.SmallPreview = dnc.OutputImage;
            previewBox.BigPreview = dnc.OutputImage;
        }

        private void sizeControl_SizeChanged()
        {
            Preview(true);
        }

        private void cross_CrossChanged()
        {
            dnc.Cross = cross.cross;
        }

        private void colsel_ColorChanged()
        {
            Preview();
        }


        private void GoButton_Click(object sender, EventArgs e)
        {
            dnc.eval = eval;
            dnc.Cross = cross.Cross;
            dnc.width = sizeControl.ChosenWidth;
            dnc.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(dnc);
            sd.ShowDialog();
        }

        private void ChartTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            dnc.DNCType = (ChartType)ChartTypeSelect.SelectedItem;
            Preview();
        }

        private void UGSel_CheckedChanged(object sender, EventArgs e)
        {
            if (UGSel.Checked) dnc.SType = DNCGeneric.SeriesType.UserGroup;
            else dnc.SType = DNCGeneric.SeriesType.Split;
            Preview();
        }

        private void NewElemButton_Click(object sender, EventArgs e)
        {
            dnc.Elements.Add(new DNCElement());
            SetColBox();
        }

        public void SetColBox()
        {
            DataPanel.Controls.Clear();

            int pos = 0;
            foreach (DNCElement elem in dnc.Elements)
            {
                DNCElementControl sac = new DNCElementControl(dnc, eval, elem);
                sac.Location = new Point(5, pos);
                sac.SelfDestruct += new DNCElementControl.SelfDestructDelegate(sac_SelfDestruct);
                sac.Changed += new DNCElementControl.ControlChangeDelegate(sac_Changed);
                pos += sac.Height;
                DataPanel.Controls.Add(sac);
            }
        }

        void sac_Changed()
        {
            Preview();
        }

        void sac_SelfDestruct()
        {
            SetColBox();
            Preview();
        }

        private void NewElemButton_Click_1(object sender, EventArgs e)
        {
            dnc.Elements.Add(new DNCElement());
            SetColBox();
        }

        private void DesignButton_Click(object sender, EventArgs e)
        {
            ChartingSettings cs = new ChartingSettings(dnc.dnc);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                dnc.dnc = cs.Settings;
                Preview();
            }
        }
    }
}
