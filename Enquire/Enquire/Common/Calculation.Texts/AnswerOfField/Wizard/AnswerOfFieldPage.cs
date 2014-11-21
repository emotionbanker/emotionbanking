using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Frontends.Common.Wizards;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using compucare.Enquire.Legacy.Umfrage2Lib.circular;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using Compucare.Frontends.Common.Forms;
using System.Threading;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using Microsoft.SqlServer;
using umfrage2._2008;
using MySQLDriverCS;
using Compucare.Enquire.Legacy.Umfrage2Lib;
using Compucare.Enquire.Common.Controls.Utils;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.DataModule.Settings;
using Compucare.Enquire.Common.Calculation.Texts.AnswerOfField;

namespace Compucare.Enquire.Common.Calculation.Texts.Sokd.Wizard
{
    class AnswerOfFieldPage : BaseWizardPage
    {
        private readonly AnswerOfFieldWizardPageControl _control;
        private DropDownTextBoxController _questionController;
        private DropDownTextBoxController _personController;
        private readonly Evaluation _eval;
        private readonly AnswerOfFieldValues _answerOfField;


        public AnswerOfFieldPage(Evaluation eval)
        {
            this._eval = eval;
            _answerOfField = new AnswerOfFieldValues();
            _control = new AnswerOfFieldWizardPageControl();
            PageControl = _control;
            Header = "Antworttext von Fragen";
            Description = "Frage, Personengruppe auswählen und anschließend auf Finish klicken.";
            _questionController = new DropDownTextBoxController(_control._questionSelect);
            _questionController.Images = new ImageList();
            _questionController.Images.Images.Add(Pictures.emblem_question_yellow);
            _personController = new DropDownTextBoxController(_control._personSelect);

            _questionController.Images = new ImageList();
            _questionController.Images.Images.Add(Pictures.emblem_question_yellow);
            /*_questionController.Images.Images.Add(Pictures.emblem_question);
            _questionController.Images.Images.Add(Pictures.emblem_question_red);*/

            _personController.Images = new ImageList();
            _personController.Images.Images.Add(Pictures.system_users_4);
            AddListeners();

            LoadItems(_eval);
        }

        public virtual void LoadItems(Evaluation eval)
        {
            _questionController.StartWait();
            _personController.StartWait();

            _questionController.ClearItems();
            _personController.ClearItems();

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

            foreach (PersonSetting ps in eval.CombinedPersons)
            {
                _personController.AddItem(new DropDownTextBoxPerson(ps));
            }

            _questionController.StopWait();
            _personController.StopWait();
        }

        void AddListeners()
        {
            _questionController.SelectionChanged += QuestionControllerSelectionChanged;
            _personController.SelectionChanged += PersonnControllerSelectionChanged;
        }

        void QuestionControllerSelectionChanged(object arg1)
        {
            Int32 q = (Int32)_questionController.SelectedItem.Value;
            _answerOfField.setFrage(q);         
        }

        void PersonnControllerSelectionChanged(object arg1)
        {
            PersonSetting p = (PersonSetting)_personController.SelectedItem.Value;
            _answerOfField.setPersonengruppe(p.ToString());
            //MessageBox.Show(p.ToString());
        }

        public string GetItem()
        {
            return _answerOfField.ToXml();
        }
    }
}