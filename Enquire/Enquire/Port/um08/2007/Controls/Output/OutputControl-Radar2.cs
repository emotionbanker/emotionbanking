using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;
using System.Collections;

namespace umfrage2._2007.Controls
{
    public partial class OutputControl_Radar2 : UserControl
    {

		public Radar2 rad;
		private Evaluation eval;
        private int ebenecounter=0;
		public bool single;
        private ListBox[] QBoxes;

		//private Crossing cross;

		public OutputControl_Radar2(Evaluation eval)
		{
            Set(eval, true, new Radar2(eval));
		}

		public OutputControl_Radar2(Evaluation eval, bool single)
		{
            Set(eval, single, new Radar2(eval));
		}

        public OutputControl_Radar2(Evaluation eval, bool single, Radar2 rad)
		{
			Set(eval, single, rad);

            
            //cpp.SetSelection(rad.PersonList, rad.ComboList);

            sizeControl.SetSize(rad.width, rad.height);

			//question lists

			Preview();
		}

        private void Set(Evaluation eval, bool single, Radar2 rad)
		{
            InitializeComponent();
            this.eval = eval;
			this.single = single;

            this.rad = rad;
            ebenecounter = rad.ebeneCounter;

            if (rad.ebeneCounter == 1)
            {
                groupBox1.Visible = true;
            }
            else if (rad.ebeneCounter == 2)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
            }
            else if (rad.ebeneCounter == 3)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
            }
            else if (rad.ebeneCounter == 4)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
            }
            else if (rad.ebeneCounter == 5)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
                groupBox5.Visible = true;
            }

			//cpp = new ChoosePersonControl(eval);
			//cpp.SelectionChanged+=new CppEventHandler(cpp_SelectionChanged);
			//cpp.Dock = DockStyle.Fill;
            //MessageBox.Show(rad.Questions.Count.ToString());

            foreach (Question q in rad.Questions)
                QBox1.Items.Add(q);
            foreach (Question q in rad.Questions2)
                QBox2.Items.Add(q);
            foreach (Question q in rad.Questions3)
                QBox3.Items.Add(q);
            foreach (Question q in rad.Questions4)
                QBox4.Items.Add(q);
            foreach (Question q in rad.Questions5)
                QBox5.Items.Add(q);

            QBoxes = new ListBox[5];
            QBoxes[0] = QBox1;
            QBoxes[1] = QBox2;
            QBoxes[2] = QBox3;
            QBoxes[3] = QBox4;
            QBoxes[4] = QBox5;

            foreach (Person p in eval.Persons)
            {
                PersonAdd1.Items.Add(p.Name);
                PersonAdd2.Items.Add(p.Name);
                PersonAdd3.Items.Add(p.Name);
                PersonAdd4.Items.Add(p.Name);
                PersonAdd5.Items.Add(p.Name);
            }

            if (eval.PersonCombos != null)
            {
                foreach (PersonCombo combo in eval.PersonCombos)
                {
                    PersonAdd1.Items.Add(combo);
                    PersonAdd2.Items.Add(combo);
                    PersonAdd3.Items.Add(combo);
                    PersonAdd4.Items.Add(combo);
                    PersonAdd5.Items.Add(combo);
                }
            }

            if (rad.person1 != null)
            {
                for (int i = 0; i < PersonAdd1.Items.Count; i++)
                {
                    if (PersonAdd1.Items[i].ToString().Equals(rad.person1))
                    {
                        PersonAdd1.SelectedIndex = i;
                    }
                }
            }
            if (rad.personcombo1!=null)
            {
                for (int i = eval.Persons.Length; i < PersonAdd1.Items.Count;i++)
                {
                    if (PersonAdd1.Items[i].ToString().Equals(rad.personcombo1.ToString()))
                    {
                        PersonAdd1.SelectedIndex = i;
                    }
                }
            }

            if (rad.person2 != null)
            {
                for (int i = 0; i < PersonAdd2.Items.Count; i++)
                {
                    if (PersonAdd2.Items[i].ToString().Equals(rad.person2.Name))
                    {
                        PersonAdd2.SelectedIndex = i;
                    }
                }
            }

            if (rad.personcombo2 != null)
            {
                for (int i = eval.Persons.Length; i < PersonAdd2.Items.Count; i++)
                {
                    if (PersonAdd2.Items[i].ToString().Equals(rad.personcombo2.ToString()))
                    {
                        PersonAdd2.SelectedIndex = i;
                    }
                }
            }
            if (rad.person3 != null)
            {
                for (int i = 0; i < PersonAdd3.Items.Count; i++)
                {
                    if (PersonAdd3.Items[i].ToString().Equals(rad.person3.Name))
                    {
                        PersonAdd3.SelectedIndex = i;
                    }
                }
            }

            if (rad.personcombo3 != null)
            {
                for (int i = eval.Persons.Length; i < PersonAdd3.Items.Count; i++)
                {
                    if (PersonAdd3.Items[i].ToString().Equals(rad.personcombo3.ToString()))
                    {
                        PersonAdd3.SelectedIndex = i;
                    }
                }
            }

            if (rad.person4 != null)
            {
                for (int i = 0; i < PersonAdd4.Items.Count; i++)
                {
                    if (PersonAdd4.Items[i].ToString().Equals(rad.person4.Name))
                    {
                        PersonAdd4.SelectedIndex = i;
                    }
                }
            }

            if (rad.personcombo4 != null)
            {
                for (int i = eval.Persons.Length; i < PersonAdd4.Items.Count; i++)
                {
                    if (PersonAdd4.Items[i].ToString().Equals(rad.personcombo4.ToString()))
                    {
                        PersonAdd4.SelectedIndex = i;
                    }
                }
            }

            if (rad.person5 != null)
            {
                for (int i = 0; i < PersonAdd5.Items.Count; i++)
                {
                    if (PersonAdd5.Items[i].ToString().Equals(rad.person5.Name))
                    {
                        PersonAdd5.SelectedIndex = i;
                    }
                }
            }

            if (rad.personcombo5 != null)
            {
                for (int i = eval.Persons.Length; i < PersonAdd5.Items.Count; i++)
                {
                    if (PersonAdd5.Items[i].ToString().Equals(rad.personcombo5.ToString()))
                    {
                        PersonAdd5.SelectedIndex = i;
                    }
                }
            }

			//cross = new Crossing(eval);
			//cross.Dock = DockStyle.Fill;
			//cross.CrossChanged+=new CrossEventHandler(cross_CrossChanged);
			//crossPanel.Controls.Add(cross);

			//cross.UpdateCross(rad.Cross);	

			sizeControl.ChosenSizeChanged+=new SizeEventHandler(sizeControl_ChosenSizeChanged);

            SetStyleControls();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>


        private void previewBox_Load(object sender, EventArgs e)
        {

        }

        private bool CheckOK(ComboBox c, ListBox l)
        {
            if(c.SelectedIndex>0 && l.Items.Count>0){
                return true;
            }
            return false;
        }

        private void Preview()
        {
            rad.ebeneCounter = ebenecounter;
            //if (ebenecounter== 1 && QBox1.Items.Count > 0 && PersonAdd1.Items.Count>0)
            
                rad.eval = eval;
                //rad.Cross = cross.Cross;
                rad.width = previewBox.Width;
                rad.height = previewBox.Height;
                //rad.PersonList = cpp.SelectedPersons;
                //rad.ComboList = cpp.SelectedCombos;

                rad.Questions = getList(QBox1);
                rad.Questions2 = getList(QBox2);
                rad.Questions3 = getList(QBox3);
                rad.Questions4 = getList(QBox4);
                rad.Questions5 = getList(QBox5);
                //MessageBox.Show("Preview: " + rad.Questions.Count.ToString() + "\n" + rad.Questions2.Count.ToString());
                
                rad.Compute();

                previewBox.SmallPreview = rad.OutputImage;

                rad.width = sizeControl.ChosenWidth;

                //rad.Compute();

                previewBox.BigPreview = rad.OutputImage;
            
        }



        private void SetStyleControls()
        {
            DesignButton.Visible = true;
        }

        private void sizeControl_ChosenSizeChanged()
        {
            Preview();
        }

        private void cpp_SelectionChanged()
        {
            Preview();
        }

        /*private Question[] getList(ListBox QBox1)
        {
            Question[] qs = new Question[QBox1.Items.Count];

            int i = 0;
            foreach (Question q in QBox1.Items)
                qs[i++] = q;

            return qs;
        }*/

        private ArrayList getList(ListBox QBox1)
        {
            ArrayList qs = new ArrayList();
            
            foreach (Question q in QBox1.Items)
                qs.Add(q);

            return qs;
        }

        private void cross_CrossChanged()
        {
            //rad.Cross = cross.cross;
        }

        private void QAdd_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    QBox1.Items.Add(q);
            }
            Preview();
        }

        private void QRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QBox1.SelectedItems.Count; i++)
            {
                QBox1.Items.Remove(QBox1.SelectedItems[i]);
            }
            Preview();
        }

        private void OverloadButton_Click(object sender, EventArgs e)
        {
            

            Question[] qs = new Question[QBox1.Items.Count + QBox2.Items.Count + QBox3.Items.Count + QBox4.Items.Count + QBox5.Items.Count];

            int i = 0;
            for (int j = 0; j < ebenecounter; j++)
            {
                ListBox l = QBoxes[j];
                
                foreach (Question q in l.Items)
                {
                    qs[i++] = q;
                }
            }

            
            DialogTextOverload dto = new DialogTextOverload(eval, qs);
            dto.ShowDialog();

            Preview();
        }


        private void GoButton_Click(object sender, EventArgs e)
        {
            rad.eval = eval;
            //rad.Cross = cross.Cross;
            rad.width = sizeControl.ChosenWidth;
            rad.height = sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(rad);
            sd.ShowDialog();
        }

        private void DesignButton_Click(object sender, EventArgs e)
        {
            ChartingSettings cs = new ChartingSettings(rad.dnc);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                rad.dnc = cs.Settings;
                Preview();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EbeneAdd_Click(object sender, EventArgs e)
        {
            ebenecounter++;
            if(ebenecounter==1){
                groupBox1.Visible = true;
            }else if(ebenecounter==2){
                groupBox2.Visible = true;
            }else if(ebenecounter==3){
                groupBox3.Visible = true;
            }else if(ebenecounter==4){
                groupBox4.Visible = true;
            }else if (ebenecounter == 5)
            {
                groupBox5.Visible = true;
            }
            else
            {
                ebenecounter--;
            }
            Preview();
        }

        private void EbeneRemove_Click(object sender, EventArgs e)
        {
            ebenecounter--;
            if(ebenecounter==0){
                groupBox1.Visible = false;
                //PersonAdd1.SelectedIndex = -1;
                QBox1.Items.Clear();
            }else if(ebenecounter==1){
                groupBox2.Visible = false;
                //PersonAdd2.SelectedItem = null;
                QBox2.Items.Clear();
            }else if(ebenecounter==2){
                groupBox3.Visible = false;
                //PersonAdd3.SelectedItem = null;
                QBox3.Items.Clear();
            }else if(ebenecounter==3){
                groupBox4.Visible = false;
                PersonAdd4.SelectedItem = null;
                QBox4.Items.Clear();
            }else if (ebenecounter == 4)
            {
                groupBox5.Visible = false;
                //PersonAdd5.SelectedItem = null;
                QBox5.Items.Clear();
            }else
            {
                ebenecounter++;
            }
            Preview();
        }

        private void QAdd2_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    QBox2.Items.Add(q);
            }
            Preview();
        }

        private void QAdd3_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    QBox3.Items.Add(q);
            }
            Preview();
        }

        private void QAdd4_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    QBox4.Items.Add(q);
            }
            Preview();
        }

        private void QRemove2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QBox2.SelectedItems.Count; i++)
            {
                QBox2.Items.Remove(QBox2.SelectedItems[i]);
            }
            Preview();
        }

        private void QRemove3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QBox3.SelectedItems.Count; i++)
            {
                QBox3.Items.Remove(QBox3.SelectedItems[i]);
            }
            Preview();
        }

        private void QRemove4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QBox4.SelectedItems.Count; i++)
            {
                QBox4.Items.Remove(QBox4.SelectedItems[i]);
            }
            Preview();
        }

        private void QAdd5_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                foreach (Question q in qs.SelectedQuestions)
                    QBox5.Items.Add(q);
            }
            Preview();
        }

        private void QRemove5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QBox5.SelectedItems.Count; i++)
            {
                QBox5.Items.Remove(QBox5.SelectedItems[i]);
            }
            Preview();
        }

        private void PersonAdd1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Person p in eval.Persons)
                {
                    if (p.Name.Equals(PersonAdd1.SelectedItem.ToString()))
                    {
                        rad.person1 = p;
                        rad.personcombo1 = null;
                        break;
                    }
                }
                foreach (PersonCombo combo in eval.PersonCombos)
                {
                    if (combo.ToString().Equals(PersonAdd1.SelectedItem.ToString()))
                    {
                        rad.person1 = null;
                        rad.personcombo1 = combo;
                        break;
                    }
                }
            }catch{

            }
            Preview();
        }


        private void PersonAdd2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Person p in eval.Persons)
                {
                    if (p.Name.Equals(PersonAdd2.SelectedItem.ToString()))
                    {
                        rad.person2 = p;
                        rad.personcombo2 = null;
                        break;
                    }
                }
                foreach (PersonCombo combo in eval.PersonCombos)
                {
                    if (combo.ToString().Equals(PersonAdd2.SelectedItem.ToString()))
                    {
                        rad.person2 = null;
                        rad.personcombo2 = combo;
                        break;
                    }
                }
            }
            catch
            {

            }
            Preview();
        }

        private void PersonAdd3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Person p in eval.Persons)
                {
                    if (p.Name.Equals(PersonAdd3.SelectedItem.ToString()))
                    {
                        rad.person3 = p;
                        rad.personcombo3 = null;
                        break;
                    }
                }
                foreach (PersonCombo combo in eval.PersonCombos)
                {
                    if (combo.ToString().Equals(PersonAdd3.SelectedItem.ToString()))
                    {
                        rad.person3 = null;
                        rad.personcombo3 = combo;
                        break;
                    }
                }
            }catch{

            }
            Preview();
        }

        private void PersonAdd4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Person p in eval.Persons)
                {
                    if (p.Name.Equals(PersonAdd4.SelectedItem.ToString()))
                    {
                        rad.person4 = p;
                        rad.personcombo5 = null;
                        break;
                    }
                }
                foreach (PersonCombo combo in eval.PersonCombos)
                {
                    if (combo.ToString().Equals(PersonAdd4.SelectedItem.ToString()))
                    {
                        rad.person4 = null;
                        rad.personcombo4 = combo;
                        break;
                    }
                }
            }
            catch
            {

            }
            Preview();
        }

        private void PersonAdd5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Person p in eval.Persons)
                {
                    if (p.Name.Equals(PersonAdd5.SelectedItem.ToString()))
                    {
                        rad.person5 = p;
                        rad.personcombo5 = null;
                        break;
                    }
                }
                foreach (PersonCombo combo in eval.PersonCombos)
                {
                    if (combo.ToString().Equals(PersonAdd5.SelectedItem.ToString()))
                    {
                        rad.person5 = null;
                        rad.personcombo5 = combo;
                        break;
                    }
                }
            }catch{

            }
            Preview();
        }








    }
}
