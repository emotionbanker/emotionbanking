using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Compucare.Frontends.Common.Command
{
    public class CommandController : ICommandController
    {
        public void Execute(ICommand command, CommandThreadOptions threadOptions)
        {
            if (threadOptions == CommandThreadOptions.SameThread)
            {
                command.Process();
                EventHelper.Fire(Finished, command.Result);
            }
            else if (threadOptions == CommandThreadOptions.OwnThread)
            {
                command.Finished += () => EventHelper.Fire(Finished, command.Result);

                Thread t = new Thread(command.Process);
                t.Start();
            }
        }

        public event CommonEventHandler<CommandResult> Finished;
    }
}
