using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.HistoricChange;
using Compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.HistoricChange;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace umfrage2._2007.Controls
{
    public partial class SingleControl : UserControl
    {
        Evaluation eval;

       
        
        public SingleControl(Evaluation eval)
        {
            InitializeComponent();

            this.eval = eval;

            LoadControl(new OutputControl_Star(eval));
        }

        private void LoadControl(Control c)
        {
            c.Dock = DockStyle.Fill;

            MainPane.Controls.Clear();

            MainPane.Controls.Add(c);
        }

        private void UncheckAll()
        {
            foreach (Component c in SettingsToolstrip.Items)
            {
                if (c is ToolStripButton)
                {
                    ((ToolStripButton)c).Checked = false;
                }
            }
        }

        private void PmButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_PercentMatrix(eval));
            UncheckAll();
            PmButton.Checked = true;
        }

        private void MButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_MultiMatrix(eval));
            UncheckAll();
            MButton.Checked = true;
        }

        private void BarButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Bar(eval));
            UncheckAll();
            BarButton.Checked = true; 
        }

        private void BaromButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Barometer(eval));
            UncheckAll();
            BaromButton.Checked = true;
        }

        private void AvgButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Averages(eval));
            UncheckAll();
            AvgButton.Checked = true;
        }

        private void PieButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Pie(eval));
            UncheckAll();
            PieButton.Checked = true;
        }

        private void PolButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Polarity(eval));
            UncheckAll();
            PolButton.Checked = true;
        }

        private void GapButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Gaps(eval));
            UncheckAll();
            GapButton.Checked = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Rank(eval));
            UncheckAll();
            toolStripButton1.Checked = true;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Open(eval));
            UncheckAll();
            OpenButton.Checked = true;
        }

        private void CrossButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_CrossAverages(eval));
            UncheckAll();
            CrossButton.Checked = true;
        }

        private void MainPane_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SettingsToolstrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void RadarButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Radar(eval));
            UncheckAll();
            RadarButton.Checked = true;
        }

        private void PotentialButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Potential(eval));
            UncheckAll();
            PotentialButton.Checked = true;
        }

        private void MultiGapButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_MultiGap(eval));
            UncheckAll();
            MultiGapButton.Checked = true;
        }

        private void GaugeButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Tacho(eval));
            UncheckAll();
            GaugeButton.Checked = true;
        }

        private void Pol08Button_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Polarity2008(eval));
            UncheckAll();
            Pol08Button.Checked = true;
        }

        private void StarButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Star(eval));
            UncheckAll();
            StarButton.Checked = true;
        }

        private void SplitMatrixButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_SplitMatrix(eval));
            UncheckAll();
            SplitMatrixButton.Checked = true;
        }

        private void SocioButton_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_SocioMatrix(eval));
            UncheckAll();
            SocioButton.Checked = true;
        }


        private void ButtonHistoricChartClick(object sender, EventArgs e)
        {
            HistoricChangeControl control = new HistoricChangeControl();
            HistoricChangeController controller = new HistoricChangeController(control, eval, new HistoricChangeDiagram(eval));
            LoadControl(control);
            UncheckAll();
            _buttonHistoricChart.Checked = true;
        }

        private void Gaugeh056Button_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Gauge_h056(eval));
            UncheckAll();
            GaugeButton.Checked = true;
        }

        private void RadarButton2_Click(object sender, EventArgs e)
        {
            LoadControl(new OutputControl_Radar2(eval));
            UncheckAll();
            RadarButton2.Checked = true;
        }
    }
}
