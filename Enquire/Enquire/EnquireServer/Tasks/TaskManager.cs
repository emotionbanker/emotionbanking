using System.Collections.Generic;
using System.Threading;
using Compucare.Frontends.Common.Command;

namespace Compucare.Enquire.EnquireServer.Tasks
{
    public class TaskManager
    {
        public const int EMPTY_QUEUE_SLEEP = 1000;

        private readonly ICommandController _commandController;
        private List<ICommand> _commandQueue;
        private bool _forceStop;

        private List<ICommand> _doneStack;

        public TaskManager(ICommandController commandController)
        {
            _commandController = commandController;
            _forceStop = false;
        }

        public void EnqueueCommand(ICommand command)
        {
            _commandQueue.Add(command);
            command.Finished += () => _doneStack.Add(command);
        }

        public void StopTaskManager()
        {
            _forceStop = true;
        }

        public void StartTaskManager()
        {
            _forceStop = false;
            new Thread(TaskThread).Start();
        }

        private void TaskThread()
        {
            while (!_forceStop)
            {
                if (_commandQueue.Count == 0)
                {
                    Thread.Sleep(EMPTY_QUEUE_SLEEP);
                    continue;
                }

                ICommand command = _commandQueue[0];
                _commandQueue.Remove(command);

                _commandController.Execute(command, CommandThreadOptions.SameThread);
            }
        }

        public void ForceParallelStart(ICommand command)
        {
            if (_commandQueue.Contains(command))
            {
                _commandQueue.Remove(command);
            }

            _commandController.Execute(command, CommandThreadOptions.OwnThread);
        }
    }
}
