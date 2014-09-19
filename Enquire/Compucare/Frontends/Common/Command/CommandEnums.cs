using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Frontends.Common.Command
{
    public enum CommandResult
    {
        Ok,
        Failed
    }

    public enum CommandThreadOptions
    {
        SameThread,
        OwnThread
    }

    public enum CommandBatchMode
    {
        SingleThreaded,
        MultiThreaded
    }
}
