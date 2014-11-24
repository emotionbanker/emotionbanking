using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2008.Tools;
using Compucare.Enquire.Legacy.Umfrage2Lib.SystemExtensions;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Enquire.Legacy.Umfrage2Lib._2007.Controls.Settings;
using System.Collections;

namespace umfrage2._2007.Controls
{
    public partial class SettingsControl_Splits : UserControl
    {
        private Evaluation eval;
        private ChooseTargetControl ctc;

        private Question splitQuestion;
        private EvaluationSaver save;

        public SettingsControl_Splits(Evaluation eval)
        {
            this.eval = eval;

            InitializeComponent();

            ctc = new ChooseTargetControl(eval);
            ctc.Checkboxes = false;

            ChooseTargetPanel.Controls.Add(ctc);

            splitQuestion = null;
            save = new EvaluationSaver(eval);
        }


        private void ChooseQuestion_Click(object sender, EventArgs e)
        {
            QuestionSelect dql = new QuestionSelect(eval);

            if (dql.ShowDialog() == DialogResult.OK)
            {
                splitQuestion = dql.SelectedQuestion;
                ChooseQuestion.Text = splitQuestion.SID;
            }
        }

        private void Split_Click(object sender, EventArgs e)
        {
            ctc.SelectedItem.Splits.Add(new TargetSplit(ctc.SelectedItem, splitQuestion));

            eval.ComputeTargetSplits2(eval, ctc.SelectedItem.Name.ToString());

            ChooseTargetPanel.Controls.Clear();

            bool checkboxes = ctc.Checkboxes;
            ctc = new ChooseTargetControl(eval);
            ctc.Checkboxes = checkboxes;

            ChooseTargetPanel.Controls.Add(ctc);

            save.SaveThreadBefore(false,null);

            /*String tmp = "";
            foreach (TargetAndSplitQuestion tdParent in eval.TargetChildsParent)
                tmp += tdParent.getQuestionId() + " -- " + tdParent.getTargetData().Name+"\n";

            if(!tmp.Equals("")) MessageBox.Show(tmp);*/
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Alle Zielteilungen nach dem ausgewählten Schema werden gelöscht (alle nach der ausgewählten Frage geteilten Ziele in der aktuellen Hierarchieebene). Fortfahren?", "Achtung!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                TargetSplit master = ctc.SelectedItem.masterSplit;
                bool found = false;
                foreach (TargetAndSplitQuestion tdParent in eval.TargetChildsParent)
                {
                    if (tdParent.getQuestionId() == master.splitter.ID && tdParent.getTargetData().Name.Equals(master.master.name))
                    {
                        found = true;
                        break;
                    }else{
                        found = false;
                    }
                }

                string targetAndQuestion = "";
                if (found == false)
                {
                    master.master.Splits.Remove(master);

                    eval.ComputeTargetSplits(eval);

                    ChooseTargetPanel.Controls.Clear();

                    ctc = new ChooseTargetControl(eval);

                    ChooseTargetPanel.Controls.Add(ctc);
                    save.SaveThreadBefore(false, targetAndQuestion);
                }
                else
                {
                    int index = 0;
                    
                    foreach (TargetAndSplitQuestion tdParent in eval.TargetChildsParent)
                    {
                        if (tdParent.getQuestionId() == master.splitter.ID && tdParent.getTargetData().Name.Equals(master.master.name))
                        {
                            targetAndQuestion = tdParent.getTargetData().Name + "_" + tdParent.getQuestionId();
                            break;
                        }
                        else
                        {
                            index++;
                        }
                    }


                    eval.TargetChildsParent.RemoveAt(index);

                    save.SaveThreadBefore(true, targetAndQuestion);
                    ChooseTargetPanel.Controls.Clear();

                    ctc = new ChooseTargetControl(eval);

                    ChooseTargetPanel.Controls.Add(ctc);
                    /*ArrayList oldTargetsArrayList = new ArrayList();
                    ArrayList kopieoldTargetsArrayList = new ArrayList();
                    
                    foreach (TargetData targets in eval.CombinedTargets)
                    {
                        oldTargetsArrayList.Add(targets);
                        kopieoldTargetsArrayList.Add(targets);
                    }

                    ArrayList newTargetsArrayList = new ArrayList();
                    ArrayList Answers = new ArrayList();
                    foreach (string answer in master.splitter.AnswerList)//durchlaufe alle Antworten
                    {
                        string x = master.master.name + "_" + master.splitter.ID + "_" + answer;
                        foreach (TargetData targets in oldTargetsArrayList)
                        {
                            if (targets.Name.Equals(x))
                            {
                                //eval.RemoveTarget(targets);
                                kopieoldTargetsArrayList.Remove(targets);
                            }
                        }
                    }//end 1st foreach

                    

                    TargetData[] targett = new TargetData[kopieoldTargetsArrayList.Count];
                    int i = 0;
                    foreach (TargetData targets in kopieoldTargetsArrayList)
                        targett[i++] = targets;*/
                    

                }
                
            }
            
            
        }//end zielteilungenlöschen

        private void _btn_rename_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Zielteilung unbenennen?", "Achtung!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ctc.SelectedItem.name = _txt_rename.Text;
                ChooseTargetPanel.Controls.Clear();
                ctc = new ChooseTargetControl(eval);
                ChooseTargetPanel.Controls.Add(ctc);
            }              
        }//end zielteilungunbenennen
    }
}
