using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compucare.Frontends.Common.Command
{
    public static class EventHelper
    {
        public static void Fire(Delegate eventToFire, params Object[] args)
        {
            if (eventToFire != null)
            {
                eventToFire.DynamicInvoke(args);
            }
        }

        public static void Fire(Delegate eventToFire, object arg)
        {
            Fire(eventToFire, new[] {arg});
        }

        public static void Fire(Delegate eventToFire)
        {
            Fire(eventToFire, new object[] {});
        }
    }
}
