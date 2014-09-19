using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Frontends.Common.Wizards
{
    public class WizardValidationException : Exception
    {
        public WizardValidationException(String message)
            : base(message)
        {
        }

        public WizardValidationException(String message, Exception cause)
            : base(message, cause)
        {
            
        }
    }
}
