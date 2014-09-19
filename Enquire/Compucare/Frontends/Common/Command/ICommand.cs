using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Frontends.Common.Command
{
    public interface ICommand
    {
        bool Complete { get; }
        CommandResult Result { get;  }
        double Status { get;  }
        String Identifier { get; }

        object ReturnValue { get; }

        void Process();

        event CommonEventHandler<double,String> Progress;
        event CommonEventHandler Finished;
    }
}
