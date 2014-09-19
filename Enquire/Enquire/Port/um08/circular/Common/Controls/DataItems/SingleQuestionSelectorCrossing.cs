using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.Utils;
using Compucare.Enquire.Common.DataModule.Settings;
using Compucare.Enquire.Legacy.Umfrage2Lib;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Common.Controls.DataItems
{
    public class SingleQuestionSelectorCrossing : SingleQuestionSelector
    {
        private readonly DropDownTextBoxController _crossQController;
        private readonly DropDownTextBoxController _answerSelectController;

        private readonly TargetData _target;
        private readonly Evaluation _eval;

        public SingleQuestionSelectorCrossing(SingleQuestionSelectorCrossingControl control, TargetData target, Evaluation eval) 
            : base(control)
        {
            _target = target;
            _eval = eval;
            _crossQController = new DropDownTextBoxController(control._crossQuestion);

            _crossQController.Images = new ImageList();
            _crossQController.Images.Images.Add(Pictures.emblem_question_yellow);
            _crossQController.Images.Images.Add(Pictures.emblem_question);
            _crossQController.Images.Images.Add(Pictures.emblem_question_red);

            _answerSelectController = new DropDownTextBoxController(control._answerSelect);

            AddHandlers();
        }

        private void AddHandlers()
        {
            _crossQController.SelectionChanged += QuestionControllerSelectionChanged;
            _crossQController.SelectionChanged += CrossQControllerSelectionChanged;           
        }

        private void CrossQControllerSelectionChanged(object arg1)
        {
            _answerSelectController.ClearItems();

            _answerSelectController.Control.Enabled = _crossQController.SelectedItem != null;

            _answerSelectController.StartWait();

            if (_crossQController.SelectedItem != null)
            {
                Question q = _target.GetQuestion((Int32) _crossQController.SelectedItem.Value, _eval);

                foreach (String answer in q.AnswerList)
                {
                    _answerSelectController.AddItem(new DropDownTextBoxText(answer));
                }
            }
           

            _answerSelectController.StopWait();
        }

        public override bool Validate()
        {
            bool valid = true;

            if (_crossQController != null && _answerSelectController != null)
            {
                if (_crossQController.SelectedItem != null && _answerSelectController.SelectedItem == null)
                {
                    valid = false;
                    SetIndicator(Indicator.Red, "A crossing answer must be selected.");
                }
            }

            return base.Validate() && valid;
        }

        public override QuestionDataItem GetDataItem()
        {
            QuestionDataItem item = base.GetDataItem();

            if (_crossQController.SelectedItem != null)
            {
                item.Cross = true;
                item.QuestionCrossing = (Int32) _crossQController.SelectedItem.Value;
                item.CrossAnswer = (String)_answerSelectController.SelectedItem.Value;
            }

            return item;
        }

        public override void LoadItems(IEnumerable<DropDownTextBoxItem> items, IEnumerable<DropDownTextBoxItem> items2)
        {
            base.LoadItems(items, items2);

            _crossQController.StartWait();

            foreach (DropDownTextBoxItem item in items)
            {
                _crossQController.AddItem(item);
            }

            _crossQController.StopWait();
        }

        public override void LoadItems(Evaluation eval)
        {
            base.LoadItems(eval);

            _crossQController.StartWait();
            _crossQController.ClearItems();

            foreach (Question q in eval.Global.Questions)
            {
                _crossQController.AddItem(new DropDownTextBoxQuestion(q));
            }
            foreach (Question q in eval.QuestionConvert)
            {
                _crossQController.AddItem(new DropDownTextBoxQuestion(q));
            }
            foreach (QuestionCombo combo in eval.QuestionCombos)
            {
                _crossQController.AddItem(new DropDownTextBoxQuestionCombo(combo));
            }
            foreach (QuestionPlaceholder ph in eval.QuestionPlaceholders)
            {
                _crossQController.AddItem(new DropDownTextBoxQuestionPlaceholder(ph));
            }
            _crossQController.StopWait();
        }
    }
}
