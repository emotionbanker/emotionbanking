using System;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.Utils;
using Compucare.Enquire.Legacy.Umfrage2Lib;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public class QuestionAnswerSelector
    {
        private readonly SingleQuestionSelectorControl _control;
        private readonly Evaluation _eval;

        private readonly DropDownTextBoxController _questionController;
        private readonly DropDownTextBoxController _answerController;

        private String _indicatorText;

        public QuestionAnswerSelector(SingleQuestionSelectorControl control, Evaluation eval)
        {
            _control = control;
            _eval = eval;
            _questionController = new DropDownTextBoxController(_control._questionSelect);
            _answerController = new DropDownTextBoxController(_control._usergSelect);

            _questionController.Images = new ImageList();
            _questionController.Images.Images.Add(Pictures.emblem_question_yellow);
            _questionController.Images.Images.Add(Pictures.emblem_question);
            _questionController.Images.Images.Add(Pictures.emblem_question_red);

            _answerController.Images = new ImageList();
            _answerController.Images.Images.Add(Pictures.checkbox_2);

            AddHandlers();
            Validate();
        }

        private void AddHandlers()
        {
            _control._validityIndicator.MouseHover += ValidityIndicatorMouseHover;
            _questionController.SelectionChanged += QuestionControllerSelectionChanged;
            _answerController.SelectionChanged += AnswerControllerSelectionChanged;
        }

        protected void QuestionControllerSelectionChanged(object arg1)
        {
            LoadAnswers();
            Validate();
        }

        protected void AnswerControllerSelectionChanged(object arg1)
        {
            Validate();
        }

        void ValidityIndicatorMouseHover(object sender, EventArgs e)
        {
            _control._toolTip.Show(_indicatorText, _control._validityIndicator);
        }

        private void SetIndicator(Indicator i, String message)
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

        public bool Validate()
        {
            if (_questionController.SelectedItem == null)
            {
                SetIndicator(Indicator.Red, "No question selected.");
                return false;
            }

            if (_answerController.SelectedItem == null)
            {
                SetIndicator(Indicator.Red, "No answer selected.");
                return false;
            }

            SetIndicator(Indicator.Green, "Selection is valid.");
            return true;
        }


        private void LoadAnswers()
        {
            _answerController.StartWait();
            _answerController.ClearItems();

            if (_answerController.SelectedItem != null)
            {
                Int32 id = (Int32)_questionController.SelectedItem.Value;

                Question q = _eval.Global.GetQuestionById(id);

                foreach (String answer in q.AnswerList)
                {
                    _answerController.AddItem(new DropDownTextBoxAnswer(answer));
                }
            }

            _answerController.StopWait();
        }

        public void LoadItems()
        {
            _questionController.StartWait();
            _questionController.ClearItems();

            foreach (Question q in _eval.Global.Questions)
            {
                _questionController.AddItem(new DropDownTextBoxQuestion(q));
            }
            foreach (QuestionCombo combo in _eval.QuestionCombos)
            {
                _questionController.AddItem(new DropDownTextBoxQuestionCombo(combo));
            }
            foreach (QuestionPlaceholder ph in _eval.QuestionPlaceholders)
            {
                _questionController.AddItem(new DropDownTextBoxQuestionPlaceholder(ph));
            }

            _questionController.StopWait();

            LoadAnswers();
        }

    
    }
}
