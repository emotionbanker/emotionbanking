using System;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Frontends.Common.Command;

namespace Compucare.Frontends.Common.Identity
{
    public class CompucareSplashController
    {
        private readonly CompucareSplash _control;
        private readonly Image[] _partnerPics;
        private readonly ICommand _command;
        private readonly ICommandController _commandController;

        public String ProductSuite
        {
            set { _control._productSuiteLabel.Text = value; }
        }

        public String ProductName
        {
            set { _control._productNameLabel.Text = value; }
        }

        public String Year
        {
            set { _control._copyrightLabel.Text += @" " + value; }
        }

        public String Description
        {
            set { _control._descriptionLabel.Text = value; }
        }

        public Image PartnerPic1
        {
            set { _control._partnerPic1.Image = value; }
        }


        public CompucareSplashController(CompucareSplash control, String productSuite, String productName, String year, String description,
            ICommandController commandController, ICommand command, Image[] partnerPics)
        {
            _control = control;
            _partnerPics = partnerPics;
            _control.Icon = Icons.compucare;
            _commandController = commandController;
            _command = command;
            _control._currentOperationLabel.Text = "";

            ProductSuite = productSuite;
            Description = description;
            ProductName = productName;
            Year = year;

            if (_partnerPics.Length > 0) PartnerPic1 = _partnerPics[0];

            _control._loadingBar.Visible = command != null;
        }

        public void ShowSplash()
        {
            if (_command != null)
            {
                _command.Finished += () => ExecuteThreadSafe(() => _control.Close());

                _command.Progress += delegate(double val, String status) 
                { 
                    ExecuteThreadSafe(() => _control._currentOperationLabel.Text = _command.Identifier);
                    ExecuteThreadSafe(() => Description = "Loading.... " + status);
                    ExecuteThreadSafe(() => _control._loadingBar.Value = (int)val);
                };
                _commandController.Execute(_command, CommandThreadOptions.OwnThread);
            }

            _control.ShowDialog();
            _control.Focus();
        }

        public void ExecuteThreadSafe(Action action)
        {
            if (_control.InvokeRequired)
            {
                _control.Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

    }
}
