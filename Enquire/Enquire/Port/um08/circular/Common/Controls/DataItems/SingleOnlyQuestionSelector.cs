using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.Utils;
using Compucare.Enquire.Common.DataModule.Settings;
using Compucare.Enquire.Legacy.Umfrage2Lib;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public class SingleOnlyQuestionSelector
    {
        protected readonly SingleOnlyQuestionSelectorControl _control;
        private DropDownTextBoxController _questionController;
        public Int32 _questionSelectedId;
        private String _indicatorText;

        public SingleOnlyQuestionSelector(SingleOnlyQuestionSelectorControl control)
        {
            _control = control;
            _questionController = new DropDownTextBoxController(_control._questionSelect);
            
            _questionController.Images = new ImageList();
            _questionController.Images.Images.Add(Pictures.emblem_question_yellow);
            _questionController.Images.Images.Add(Pictures.emblem_question);
            _questionController.Images.Images.Add(Pictures.emblem_question_red);

            AddHandlers();
        }

        public virtual void LoadItems(IEnumerable<DropDownTextBoxItem> items, IEnumerable<DropDownTextBoxItem> items2)
        {
            _questionController.StartWait();

            foreach (DropDownTextBoxItem item in items)
            {
                _questionController.AddItem(item);
            }

            _questionController.StopWait();
        }

        public Int32 getQuestion()
        {
            return this._questionSelectedId;
        }

        public virtual void LoadItems(Evaluation eval)
        {
            _questionController.StartWait();

            _questionController.ClearItems();

            foreach (Question q in eval.Global.Questions)
            {
                _questionController.AddItem(new DropDownTextBoxQuestion(q));
            }
            foreach (QuestionCombo combo in eval.QuestionCombos)
            {
                _questionController.AddItem(new DropDownTextBoxQuestionCombo(combo));
            }
            foreach (QuestionPlaceholder ph in eval.QuestionPlaceholders)
            {
                _questionController.AddItem(new DropDownTextBoxQuestionPlaceholder(ph));
            }
            foreach (Question q in eval.QuestionConvert)
            {
                _questionController.AddItem(new DropDownTextBoxQuestion(q));
            }
            

            _questionController.StopWait();
        }

        private void AddHandlers()
        {
            _questionController.SelectionChanged += QuestionControllerSelectionChanged;
        }

       
        public void QuestionControllerSelectionChanged(object arg1)
        {
            try
            {
                Int32 q = (Int32)_questionController.SelectedItem.Value;
            }
            catch
            {

            }
            //MessageBox.Show(q.ToString());
        }


        public virtual QuestionDataItem GetDataItem()
        {
            Int32 q = (Int32) _questionController.SelectedItem.Value;

            List<PersonSetting> usergs = new List<PersonSetting>();

            /*foreach (DropDownTextBoxItem item in _usergController.SelectedItems)
            {
                PersonSetting ps = (PersonSetting) item.Value;
                usergs.Add(ps);
            }*/

            return new QuestionDataItem(q, usergs.ToArray());
        }

        public void LoadFromDataItem(QuestionDataItem item)
        {
            _questionController.SelectItem((Int32)item.QuestionId);
        }
    }
}
