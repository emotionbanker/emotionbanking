using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Compucare.Frontends.Common.Command
{
    public class CommandBatch : ICommand
    {
        protected IList<ICommand> _commands;
        protected CommandBatchMode _mode;

        public CommandBatch()
        {
            
        }

        public CommandBatch(IList<ICommand> batch, CommandBatchMode mode)
        {
            _commands = batch;
            _mode = mode;
        }

        public bool Complete
        {
            get { return !_commands.Any(command => !command.Complete); }
        }

        public CommandResult Result
        {
            get
            {
                if (_commands.Any(command => command.Result == CommandResult.Failed))
                {
                    return CommandResult.Failed;
                }
                return CommandResult.Ok;
            }
        }

        public double Status
        {
            get
            {
                return _commands.Average(command => command.Status);
            }
        }

        public string Identifier { get; private set; }

        public object ReturnValue
        {
            get 
            { 
                Dictionary<Type,Object> dict = new Dictionary<Type, object>();

                foreach (ICommand command in _commands)
                {
                    dict.Add(command.GetType(), command.ReturnValue);
                }

                return dict;
            }
        }

        public void Process()
        {
            foreach (ICommand command in _commands)
            {
                command.Finished += delegate
                                        { 
                                            if (Complete) EventHelper.Fire(Finished); 
                                        };
                command.Progress += delegate
                                        {
                                            EventHelper.Fire(Progress, Status, Math.Round(Status) + "%");
                                        };
            }

            if (_mode == CommandBatchMode.SingleThreaded)
            {
                foreach (ICommand command in _commands)
                {
                    Identifier = command.Identifier;
                    command.Process();
                }
            }
            else if (_mode == CommandBatchMode.MultiThreaded)
            {
                Identifier = "Multiple commands";
                foreach (ICommand command in _commands)
                {
                    new Thread(command.Process).Start();
                }
            }
        }

        public event CommonEventHandler<double, string> Progress;
        public event CommonEventHandler Finished;
    }
}
