using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Frontends.Common.Wizards
{
    public class BaseWizardPage
    {
        public Control PageControl { get; set; }

        public String Header { get; set; }

        public String Description { get; set; }

        public Boolean AllowFinish { get; set; }

        public Boolean AllowNext { get; set; }

        public Boolean AllowBack { get; set; }

        public BaseWizardPage()
        {
            AllowNext = true;
            AllowBack = true;
        }

        public virtual void Validate()
        {
        }

        public virtual void Initialise()
        {
        }

        public virtual void Activate()
        {
            
        }
   }
}
