using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output.Polarity2008;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;


namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Polarity2008 : UserControl
    {
        
		private System.ComponentModel.IContainer components = null;

		public Polarity2008 pol;
		private Evaluation eval;
		public bool single;

		private ChoosePersonControl cpp;
		private Crossing cross;

        GroupPersonControl gpc;

        [NonSerialized]
        private bool initP = false;

		public OutputControl_Polarity2008(Evaluation eval)
		{
            Set(eval, true, new Polarity2008(eval));
		}

		public OutputControl_Polarity2008(Evaluation eval, bool single)
		{
            Set(eval, single, new Polarity2008(eval));
		}

        public OutputControl_Polarity2008(Evaluation eval, bool single, Polarity2008 pol)
		{
			Set(eval, single, pol);

			
			cpp.SetSelection(pol.PersonList, pol.ComboList);

			sizeControl.SetSize(pol.width, pol.height);

			//question lists
            try
            {
                foreach (Question q in pol.Questions)
                    QBox.Items.Add(q);
            }
            catch { }

			Preview();
		}

		private void Set(Evaluation eval, bool single, Polarity2008 pol)
		{
			this.eval = eval;
			this.single = single;

			this.pol = pol;

			InitializeComponent();

			sizeControl.SetDefaultSize(1000, 100);

			cpp = new ChoosePersonControl(eval);
			cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			cpp.Dock = DockStyle.Fill;

			cross = new Crossing(eval);
			cross.Dock = DockStyle.Fill;
			cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			crossPanel.Controls.Add(cross);

			cross.UpdateCross(pol.Cross);

			OutputNameControl onc = new OutputNameControl(pol);
			onc.Location = new Point(380,16);
			

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_ChosenSizeChanged);


			ValueFontDialog.Font = pol.ValueFont;
			QFontDialog.Font = pol.QFont;

            BColorAPanel.BackColor = pol.BackColorA;
            BColorBPanel.BackColor = pol.BackColorB;

		    _textLineWidth.Text = pol.LineWidth.ToString();

            SetStyleControls();

            textSlider.BackColor = Color.White;
            textSlider.SliderColor = Color.Black;
            textSlider.Value = pol.SizePercentText;
            textSlider.Slided += new SlideEventHandler(textSlider_Slided);

            valueSlider.BackColor = Color.White;
            valueSlider.SliderColor = Color.Blue;
            valueSlider.Value = pol.SizePercentValues;
            valueSlider.Slided += new SlideEventHandler(valueSlider_Slided);

            ConnBox.Checked = pol.ConnectTheDots;

            foreach (DashStyle style in Enum.GetValues(typeof(DashStyle)))
            {
                if (style != DashStyle.Custom)
                {
                    _strokeStyle.Items.Add(style);
                }
            }

		    _strokeStyle.SelectedItem = pol.LineStyle;

            SetColBox();

            SetGroupControl();
        }

        public void SetColBox()
        {
            ColBox.Controls.Clear();

            int pos = 0;
            foreach (PolarityUGSplit split in pol.Cols)
            {
                Polarity2008ColBoxControl con = new Polarity2008ColBoxControl(pol, split, eval);
                con.Location = new Point(5, pos);
                con.SelfDestruct += new SelfDestructDelegate(con_SelfDestruct);
                con.Changed += new ControlChangeDelegate(con_Changed);
                pos += con.Height;
                ColBox.Controls.Add(con);
            }
        }

        void con_Changed()
        {
            Preview();
        }

        void con_SelfDestruct()
        {
            SetColBox();
        }

        void valueSlider_Slided()
        {
            pol.SizePercentValues = valueSlider.Value;
            Preview();
        }

        void textSlider_Slided()
        {
            pol.SizePercentText = textSlider.Value;
            Preview();
        }

        public void SetGroupControl()
        {
            gpc = new GroupPersonControl(pol.PersonOrder, pol.PersonGroups);

            gpc.GroupsChanged += new GroupPersonControlHandler(gpc_GroupsChanged);

            gpc.Dock = DockStyle.Fill;
        }

        void gpc_GroupsChanged()
        {
            pol.PersonGroups = gpc.groups;
            Preview();
        }
		
		private Question[] getList()
		{
			Question[] qs = new Question[QBox.Items.Count];				

			int i = 0;
			foreach (Question q in QBox.Items)
				qs[i++] = q;

			return qs;
		}

		private void Preview()
		{
			if (QBox.Items.Count > 0)
			{
				pol.imagesonly = true;
				pol.eval = eval;
				pol.Cross = cross.Cross;
				pol.width = previewBox.Width;
				pol.height = previewBox.Height - 30;
				pol.PersonList = cpp.SelectedPersons;
				pol.ComboList = cpp.SelectedCombos;
				
				pol.Questions = getList();

				pol.Compute();

				previewBox.SmallPreview = pol.OutputImage;
                

				pol.imagesonly = false;
				pol.width = sizeControl.ChosenWidth;
				pol.height = sizeControl.ChosenHeight;

				pol.Compute();
                pol.StoreHeight();

				previewBox.BigPreview = pol.OutputImage;
			}
			else
				previewBox.SmallPreview = null;
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

        private void sizeControl_ChosenSizeChanged()
		{
			Preview();
		}

		private void cpp_SelectionChanged()
		{
            if (!initP)
            {
                pol.PersonList = cpp.SelectedPersons;
                pol.ComboList = cpp.SelectedCombos;

                ArrayList nlist = new ArrayList();

                SetGroupControl();
            }

            Preview();

            Console.WriteLine("[Output][Polarity] - Person Selection Changed");
		}

        private void cross_CrossChanged()
        {
            pol.Cross = cross.cross;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            pol.eval = eval;
            pol.Cross = cross.Cross;
            pol.width = sizeControl.ChosenWidth;
            pol.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(pol);
            sd.ShowDialog();
        }

        private void QAdd_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
			if (qs.ShowDialog() == DialogResult.OK)
			{
				foreach (Question q in qs.SelectedQuestions)
					QBox.Items.Add(q);
			}
			Preview();
        }

        private void QRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QBox.SelectedItems.Count; i++)
			{
				QBox.Items.Remove(QBox.SelectedItems[i]);
			}
			Preview();
        }

        private void OverloadButton_Click(object sender, EventArgs e)
        {
            DialogTextOverload dto = new DialogTextOverload(eval, getList());
			dto.ShowDialog();

			Preview();
        }

        private void ValueFontButton_Click(object sender, EventArgs e)
        {
            if (ValueFontDialog.ShowDialog() == DialogResult.OK)
				pol.ValueFont = ValueFontDialog.Font;

			Preview();
        }

        private void QFontButton_Click(object sender, EventArgs e)
        {
            if (QFontDialog.ShowDialog() == DialogResult.OK)
				pol.QFont = QFontDialog.Font;

			Preview();
        }

        private void BColorAButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = pol.BackColorA;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pol.BackColorA = colorDialog.Color;
                BColorAPanel.BackColor = pol.BackColorA;
                Preview();
            }
        }

        private void BColorBButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = pol.BackColorB;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pol.BackColorB = colorDialog.Color;
                BColorBPanel.BackColor = pol.BackColorB;
                Preview();
            }
        }

        private void OutputControl_Polarity_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void SetStyleControls()
        {
          textSlider.Visible = valueSlider.Visible = label1.Visible = true;
        }


 

        private void button1_Click(object sender, EventArgs e)
        {
            pol.Cols.Add(new PolarityUGSplit(null));
            SetColBox();
        }

        private void ConnBox_CheckedChanged(object sender, EventArgs e)
        {
            pol.ConnectTheDots = ConnBox.Checked;
            Preview();
        }

        private void ShortFontButton_Click(object sender, EventArgs e)
        {
            ShortFontDialog.Font = pol.ShortFont;

            if (ShortFontDialog.ShowDialog() == DialogResult.OK)
                pol.ShortFont = ShortFontDialog.Font;

            Preview();
        }

        private void _textLineWidth_TextChanged(object sender, EventArgs e)
        {
            pol.LineWidth = Int32.Parse(_textLineWidth.Text);
            Preview();
        }

        private void _strokeStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            pol.LineStyle = (DashStyle)_strokeStyle.SelectedItem;
            Preview();
        }

    }
}