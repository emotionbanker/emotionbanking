using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Compucare.Frontends.Common.Command;

namespace Compucare.Frontends.Common.Identity
{
    public class WaitCommand : ICommand
    {
        private readonly double _waitTime;
        private String _identifier;

        public WaitCommand(double waitTimeInSeconds)
        {
            _waitTime = waitTimeInSeconds;
        }

        public bool Complete { get; private set; }

        public CommandResult Result { get; private set; }

        public double Status { get; private set; }

        public string Identifier
        {
            get { return _identifier ?? "Waiting..."; }
            set { _identifier = value; }
        }

        public object ReturnValue
        {
            get { return null; }
        }

        public void Process()
        {
            Complete = false;
            Status = 0;

            double step = _waitTime/100d;
            int progressCounter = 0;
            
            for (double i = 0; i < _waitTime; i+= step )
            {
                Status = progressCounter;

                Thread.Sleep(new TimeSpan( (long)(TimeSpan.TicksPerSecond * step)));
                EventHelper.Fire(Progress, Status, Status + "%");

                progressCounter++;
            }

            Result = CommandResult.Ok;
            Status = 100;
            Complete = true;
            EventHelper.Fire(Finished);
        }

        public event CommonEventHandler<double,String> Progress;
        public event CommonEventHandler Finished;
    }
}
