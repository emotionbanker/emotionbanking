using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Frontends.Common.Command
{
    public delegate void CommonEventHandler();

    public delegate void CommonEventHandler<T>(T arg1);
    
    public delegate void CommonEventHandler<T,U>(T arg1, U arg2);

    public delegate void CommonEventHandler<T,U,V>(T arg1, U arg2, V arg3);

    public delegate void CommonEventHandler<T,U,V,W>(T arg1, U arg2, V arg3, W arg4);

    public delegate void CommonEventHandler<T,U,V,W,X>(T arg1, U arg2, V arg3, W arg4, X arg5);
}
