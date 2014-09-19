using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Frontends.Common.Command
{
    public interface ICommandController
    {
        void Execute(ICommand command, CommandThreadOptions threadOptions);

        event CommonEventHandler<CommandResult> Finished;
    }
}
