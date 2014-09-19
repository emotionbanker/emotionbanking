using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Frontends.Common.Command
{
    public class BaseCommand : ICommand
    {
        private double _status;

        public bool Complete { get; protected set; }

        public CommandResult Result { get; protected set; }

        public double Status
        {
            get { return _status; }
            set { _status = value; EventHelper.Fire(Progress, Status, Status + "%"); }
        }

        public object ReturnValue { get; protected set; }
        
        public String Identifier { get; protected set; }

        public void Process()
        {
            Complete = false;
            Status = 0;

            CustomProcess();

            Status = 100;
            Complete = true;
            EventHelper.Fire(Finished);
        }

        public virtual void CustomProcess()
        {
            //
        }

        public event CommonEventHandler<double, string> Progress;
        public event CommonEventHandler Finished;
    }
}
