using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.Utils;
using Compucare.Enquire.Common.DataModule.Settings;
using Compucare.Enquire.Legacy.Umfrage2Lib;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public class SingleQuestionSelector
    {
        protected readonly SingleQuestionSelectorControl _control;
        private readonly DropDownTextBoxController _questionController;
        private readonly DropDownTextBoxController _usergController;

        private String _indicatorText;

        public SingleQuestionSelector(SingleQuestionSelectorControl control)
        {
            _control = control;
            _questionController = new DropDownTextBoxController(_control._questionSelect);
            _usergController = new DropDownTextBoxController(_control._usergSelect);
            //_usergController.Checkable = true;

            _questionController.Images = new ImageList();
            _questionController.Images.Images.Add(Pictures.emblem_question_yellow);
            _questionController.Images.Images.Add(Pictures.emblem_question);
            _questionController.Images.Images.Add(Pictures.emblem_question_red);

            _usergController.Images = new ImageList();
            _usergController.Images.Images.Add(Pictures.system_users_4);

            AddHandlers();
            Validate();
        }

        public virtual void LoadItems(IEnumerable<DropDownTextBoxItem> items, IEnumerable<DropDownTextBoxItem> items2)
        {
            _questionController.StartWait();
            _usergController.StartWait();

            foreach (DropDownTextBoxItem item in items)
            {
                _questionController.AddItem(item);
            }
            foreach (DropDownTextBoxItem item in items2)
            {
                _usergController.AddItem(item);
            }

            _questionController.StopWait();
            _usergController.StopWait();
        }

        public virtual void LoadItems(Evaluation eval)
        {
            _questionController.StartWait();
            _usergController.StartWait();

            _questionController.ClearItems();
            _usergController.ClearItems();

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
            

            //add usergs
            foreach (PersonSetting ps in eval.CombinedPersons)
            {
                _usergController.AddItem(new DropDownTextBoxPerson(ps));
            }

            _questionController.StopWait();
            _usergController.StopWait();
        }

        private void AddHandlers()
        {
            _control._validityIndicator.MouseHover += ValidityIndicatorMouseHover;
            _questionController.SelectionChanged += QuestionControllerSelectionChanged;
            _usergController.SelectionChanged += QuestionControllerSelectionChanged;
        }

      
        protected void QuestionControllerSelectionChanged(object arg1)
        {
           Validate();
        }

        public virtual bool Validate()
        {
            if (_questionController.SelectedItem == null)
            {
                SetIndicator(Indicator.Red, "No question selected.");
                return false;
            }
            
            if (_usergController.SelectedItem == null)// || _usergController.SelectedItems.Count == 0)
            {
                SetIndicator(Indicator.Red, "No user group selected.");
                return false;         
            }
            SetIndicator(Indicator.Green, "Selection is valid.");
            return true;
        }

        void ValidityIndicatorMouseHover(object sender, EventArgs e)
        {
            _control._toolTip.Show(_indicatorText, _control._validityIndicator);
        }

        protected void SetIndicator(Indicator i, String message)
        {
            switch (i)
            {
                case Indicator.Green:
                    _control._validityIndicator.Image = Pictures.dot_green;
                    break;

                case Indicator.Yellow:
                    _control._validityIndicator.Image = Pictures.dot_yellow;
                    break;

                case Indicator.Red:
                    _control._validityIndicator.Image = Pictures.dot_red;
                    break;

                case Indicator.None:
                    _control._validityIndicator.Image = null;
                    break;
            }

            _indicatorText = message;
        }

        public virtual QuestionDataItem GetDataItem()
        {
            Int32 q = (Int32) _questionController.SelectedItem.Value;

            List<PersonSetting> usergs = new List<PersonSetting>();

            foreach (DropDownTextBoxItem item in _usergController.SelectedItems)
            {
                PersonSetting ps = (PersonSetting) item.Value;
                usergs.Add(ps);
            }

            if (_usergController.SelectedItem != null) usergs.Add((PersonSetting)_usergController.SelectedItem.Value);
            

            return new QuestionDataItem(q, usergs.ToArray());
        }

        public void LoadFromDataItem(QuestionDataItem item)
        {
            _usergController.SelectItem(item.Persons[0]);
            _questionController.SelectItem((Int32)item.QuestionId);
        }
    }
}
