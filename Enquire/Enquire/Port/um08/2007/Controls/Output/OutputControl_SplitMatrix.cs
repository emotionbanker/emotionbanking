using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;


namespace umfrage2._2007.Controls
{
    public partial class OutputControl_SplitMatrix : UserControl
    {
        public SplitMatrix mm;
        

        private Evaluation eval;
       

        private ChoosePersonControl cpp;
        private Crossing cross;
        
        

        private bool single;

        public OutputControl_SplitMatrix(Evaluation eval)
        {
            Set(eval, true, new SplitMatrix(eval));
        }

        public OutputControl_SplitMatrix(Evaluation eval, bool single)
        {
            Set(eval, single, new SplitMatrix(eval));
        }

        public OutputControl_SplitMatrix(Evaluation eval, bool single, SplitMatrix mmatrix)
        {
            Set(eval, single, mmatrix);


            cpp.SetSelection(mmatrix.PersonList, mmatrix.ComboList);

            sizeControl.SetSize(mmatrix.width, mmatrix.height);

            //question lists

            SmallButton.Checked = mmatrix.Small;

            if (mmatrix.Format == Output.FORMAT_BASIC)
                BasicButton.Checked = true;
            else
                ScaleButton.Checked = true;

            foreach (Question q in mm.xq)
                XBox.Items.Add(q);
            foreach (Question q in mm.yq)
                YBox.Items.Add(q);

            Preview(false);
        }

        private void UpdateColSel()
        {
            ColorPanel.Controls.Clear();
            if (cross.cross != null)
            {
                ColorSelector colsel = new ColorSelector(eval, cross.cross.AnswerList);
                colsel.Dock = DockStyle.Fill;
                ColorPanel.Controls.Add(colsel);
                colsel.ColorChanged += new ColorChangedEvent(colsel_ColorChanged);
            }
        }

        void colsel_ColorChanged()
        {
            Preview();
        }

        public void Set(Evaluation eval, bool single, SplitMatrix mmatrix)
        {
            this.single = single;
            this.eval = eval;
            mm = mmatrix;

            InitializeComponent();          

            cpp = new ChoosePersonControl(eval);
            cpp.SelectionChanged += new CppEventHandler(cpp_SelectionChanged);
            cpp.Dock = DockStyle.Fill;

            PersonPanel.Controls.Add(cpp);

            cross = new Crossing(eval);
            cross.Dock = DockStyle.Fill;
            cross.CrossChanged += new CrossEventHandler(cross_CrossChanged);
            crossPanel.Controls.Add(cross);

            cross.UpdateCross(mm.Cross);

            OutputNameControl onc = new OutputNameControl(mm);
            onc.Location = new Point(380, 16);

            sizeControl.ChosenSizeChanged += new SizeEventHandler(sizeControl_ChosenSizeChanged);

/*            MasterDesignBox.Items.Clear();
            MasterDesignBox.Items.Add("Victor 2006");
            MasterDesignBox.Items.Add("Victor 2007");
            MasterDesignBox.SelectedIndex = mmatrix.Design;
            */
            ArrowColorButton.BackColor = mm.ArrowColor;

            InvertBox.Checked = mm.Invert;
            InvertLogBox.Checked = mm.InvertLog;

            SetStyleControls();

            //UpdateColSel();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void OutputControl_MultiMatrix_Load(object sender, EventArgs e)
        {

        }

        private void cpp_SelectionChanged()
        {
            Preview(false);
        }

        private void sizeControl_ChosenSizeChanged()
        {
            Preview(true);
        }

        private void cross_CrossChanged()
        {
            mm.Cross = cross.cross;
            UpdateColSel();
            Preview();
        }

        private void Preview(bool bigonly)
        {
            if (XBox.Items.Count > 0 && XBox.Items.Count == YBox.Items.Count)
            {
                foreach (TargetData td in eval.CombinedTargets)
                {
                    if (!td.ToString().Equals("Global"))
                    {
                        try { td.Included = false; }
                        catch { }
                    }
                }

                mm.eval = eval;
                mm.Cross = cross.Cross;
                mm.width = previewBox.Width;
                mm.height = previewBox.Height - 20;
                mm.PersonList = cpp.SelectedPersons;
                mm.ComboList = cpp.SelectedCombos;
                if (ScaleButton.Checked) mm.Format = Output.FORMAT_SCALED;
                if (BasicButton.Checked) mm.Format = Output.FORMAT_BASIC;
                mm.Small = SmallButton.Checked;

                Question[] xq = new Question[XBox.Items.Count];
                Question[] yq = new Question[YBox.Items.Count];

                int i = 0;
                foreach (Question q in XBox.Items)
                    xq[i++] = q;

                i = 0;
                foreach (Question q in YBox.Items)
                    yq[i++] = q;

                mm.xq = xq;
                mm.yq = yq;

                if (!bigonly)
                {
                    mm.width = Math.Min(previewBox.Width, previewBox.Height - 20);
                    mm.height = Math.Min(previewBox.Width, previewBox.Height - 20);
                    mm.Compute();

                    previewBox.SmallPreview = mm.OutputImage;
                }

                mm.width = sizeControl.ChosenWidth;
                mm.height = sizeControl.ChosenHeight;

                mm.Compute();

                previewBox.BigPreview = mm.FullImage;
            }
        }

        private void SetStyleControls()
        {
            //disable all

            
            

            DesignButton.Visible = false;

            //enable
            if (mm.Design == MultiMatrix.Victor2006)
            {
                
                            }
            else if (mm.Design == MultiMatrix.Victor2007)
            {
                //ShadingBox.Visible = true;
                DesignButton.Visible = true;
            }
        }

        private void Preview()
        {
            Preview(false);
        }

        private void DesignButton_Click(object sender, EventArgs e)
        {

            ChartingSettings cs = new ChartingSettings(mm.dnc);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                mm.dnc = cs.Settings;
                Preview();
            }
        }

        private void previewBox_Load(object sender, EventArgs e)
        {

        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            mm.eval = eval;
            mm.Cross = cross.Cross;
            mm.width = sizeControl.ChosenWidth;
            mm.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(mm);
            sd.ShowDialog();
        }

        private void XAdd_Click(object sender, System.EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    XBox.Items.Add(q);
            }
            Preview(false);
        }

        private void YAdd_Click(object sender, System.EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    YBox.Items.Add(q);
            }
            Preview(false);
        }

        private void XRemove_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < XBox.SelectedItems.Count; i++)
            {
                XBox.Items.Remove(XBox.SelectedItems[i]);
            }
            Preview(false);
        }

        private void YRemove_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < YBox.SelectedItems.Count; i++)
            {
                YBox.Items.Remove(YBox.SelectedItems[i]);
            }
            Preview(false);
        }

        private void ScaleButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ScaleButton.Checked)
            {
                BasicButton.Checked = false;
                Preview(false);
            }
        }

        private void BasicButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (BasicButton.Checked)
            {
                ScaleButton.Checked = false;
                Preview(false);
            }
        }

        private void SmallButton_CheckedChanged_1(object sender, System.EventArgs e)
        {
            Preview(false);
        }

        private void OverloadButton_Click(object sender, System.EventArgs e)
        {
            Question[] xq = new Question[XBox.Items.Count + YBox.Items.Count];

            int i = 0;
            foreach (Question q in XBox.Items)
                xq[i++] = q;

            foreach (Question q in YBox.Items)
                xq[i++] = q;

            DialogTextOverload dto = new DialogTextOverload(eval, xq);
            dto.ShowDialog();

            Preview(true);
        }

        private void SmallButton_CheckedChanged(object sender, EventArgs e)
        {
            Preview();
        }

           
        private void ArrowColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = mm.ArrowColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                mm.ArrowColor = colorDialog1.Color;
                ArrowColorButton.BackColor = mm.ArrowColor;
                Preview();
            }
        }

        private void InvertBox_CheckedChanged(object sender, EventArgs e)
        {
            mm.Invert = InvertBox.Checked;
            Preview();
        }

        private void InvertLogBox_CheckedChanged(object sender, EventArgs e)
        {
            mm.InvertLog = InvertLogBox.Checked;
            Preview();
        }
    }
}