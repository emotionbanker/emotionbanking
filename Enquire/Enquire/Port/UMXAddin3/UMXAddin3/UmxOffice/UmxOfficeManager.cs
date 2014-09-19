using System;
using System.Collections.Generic;
using System.Text;
using umfrage2;

namespace UMXAddin3
{
    public abstract class UmxOfficeManager
    {
        public Evaluation eval;

        public Evaluation[] multiEvals = new Evaluation[5];
        public string[] multiTargets = new string[5];


        public abstract void OnSave();
    }
}
