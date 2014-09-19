using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.Graves.Wizard.WizardPages
{
    public class GravesWizardPage : BaseWizardPage
    {
        private readonly Evaluation _eval;
        private readonly GravesWizardPageControl _control;

        private readonly SingleQuestionSelector _q1Selector;
        private readonly SingleQuestionSelector _q2Selector;
        private readonly SingleQuestionSelector _q3Selector;
        private readonly SingleQuestionSelector _q4Selector;

        private XmlElement _grRoot;

        public GravesWizardPage(Evaluation eval, Color markerColor, String info)
        {
            AllowFinish = true;

            _eval = eval;
            _control = new GravesWizardPageControl();
            _control._gradientPanel.EndColor = markerColor;
            _control._infoLabel.Text = info;

            _q1Selector = new SingleQuestionSelector(_control._q1Selector);
            _q2Selector = new SingleQuestionSelector(_control._q2Selector);
            _q3Selector = new SingleQuestionSelector(_control._q3Selector);
            _q4Selector = new SingleQuestionSelector(_control._q4Selector);

            _control._pic1.Image = new Bitmap(_control._pic1.Width, _control._pic1.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(_control._pic1.Image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GravesPointDrawer.DrawCircleFilled(g, GravesPointDrawer.Gray,
                                               new Point(_control._pic1.Width/2, _control._pic1.Height/2),
                                               (float)_control._pic1.Width / 4);

            _control._pic2.Image = new Bitmap(_control._pic2.Width, _control._pic2.Height);
            g = System.Drawing.Graphics.FromImage(_control._pic2.Image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GravesPointDrawer.DrawCircleOutline(g, GravesPointDrawer.Gray,
                                               new Point(_control._pic2.Width / 2, _control._pic2.Height / 2),
                                               (float)_control._pic2.Width / 4, 2);

            _control._pic3.Image = new Bitmap(_control._pic3.Width, _control._pic3.Height);
            g = System.Drawing.Graphics.FromImage(_control._pic3.Image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GravesPointDrawer.DrawRectangleFilled(g, GravesPointDrawer.Orange,
                                               new Point(_control._pic3.Width / 2, _control._pic3.Height / 2),
                                               (float)_control._pic3.Width / 4);

            _control._pic4.Image = new Bitmap(_control._pic4.Width, _control._pic4.Height);
            g = System.Drawing.Graphics.FromImage(_control._pic4.Image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            GravesPointDrawer.DrawRectangleOutline(g, GravesPointDrawer.Orange,
                                               new Point(_control._pic4.Width / 2, _control._pic4.Height / 2),
                                               (float)_control._pic2.Width / 4, 2);

            Header = "Spiral settings";
            Description = "Choose the spiral dynamics graphic you want to create.";

            _control._check1.CheckedChanged += delegate { _control._q1Selector.Enabled = _control._check1.Checked; };
            _control._check2.CheckedChanged += delegate { _control._q2Selector.Enabled = _control._check2.Checked; };
            _control._check3.CheckedChanged += delegate { _control._q3Selector.Enabled = _control._check3.Checked; };
            _control._check4.CheckedChanged += delegate { _control._q4Selector.Enabled = _control._check4.Checked; };

            PageControl = _control;
        }

        public override void Validate()
        {
            if (_control._check1.Checked && !_q1Selector.Validate()) throw new WizardValidationException("Question 1 is invalid.");
            if (_control._check2.Checked && !_q2Selector.Validate()) throw new WizardValidationException("Question 2 is invalid.");
            if (_control._check3.Checked && !_q3Selector.Validate()) throw new WizardValidationException("Question 3 is invalid.");
            if (_control._check4.Checked && !_q4Selector.Validate()) throw new WizardValidationException("Question 4 is invalid.");
        }
        
        public override void Initialise()
        {
            _q1Selector.LoadItems(_eval);
            _q2Selector.LoadItems(_eval);
            _q3Selector.LoadItems(_eval);
            _q4Selector.LoadItems(_eval);
        }

        public String GetXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("GravesLevel"));
            if (_control._check1.Checked) root.AppendChild(doc.CreateElement("Question1")).InnerXml = _q1Selector.GetDataItem().ToXml();
            if (_control._check2.Checked) root.AppendChild(doc.CreateElement("Question2")).InnerXml = _q2Selector.GetDataItem().ToXml();
            if (_control._check3.Checked) root.AppendChild(doc.CreateElement("Question3")).InnerXml = _q3Selector.GetDataItem().ToXml();
            if (_control._check4.Checked) root.AppendChild(doc.CreateElement("Question4")).InnerXml = _q4Selector.GetDataItem().ToXml();
            return root.OuterXml;
        }

        private static QuestionDataItem GetQuestion(XmlElement root, String tag, Evaluation eval)
        {
            return new QuestionDataItem(root.GetElementsByTagName(tag)[0].InnerXml, eval);
        }

        private void LoadFromXml()
        {
            if (_grRoot.GetElementsByTagName("Question1").Count > 0)
            {
                QuestionDataItem item = GetQuestion(_grRoot, "Question1", _eval);
                _q1Selector.LoadFromDataItem(item);
            }
            else
            {
                _control._check1.Checked = false;
            }

            if (_grRoot.GetElementsByTagName("Question2").Count > 0)
            {
                QuestionDataItem item = GetQuestion(_grRoot, "Question2", _eval);
                _q2Selector.LoadFromDataItem(item);
            }
            else
            {
                _control._check2.Checked = false;
            }

            if (_grRoot.GetElementsByTagName("Question3").Count > 0)
            {
                QuestionDataItem item = GetQuestion(_grRoot, "Question3", _eval);
                _q3Selector.LoadFromDataItem(item);
            }
            else
            {
                _control._check3.Checked = false;
            }

            if (_grRoot.GetElementsByTagName("Question4").Count > 0)
            {
                QuestionDataItem item = GetQuestion(_grRoot, "Question4", _eval);
                _q4Selector.LoadFromDataItem(item);
            }
            else
            {
                _control._check4.Checked = false;
            }
        }

        public void LoadFromXml(XmlElement levelRoot)
        {
            _grRoot = (XmlElement)levelRoot.GetElementsByTagName("GravesLevel")[0];
            LoadFromXml();
        }
    }
}
