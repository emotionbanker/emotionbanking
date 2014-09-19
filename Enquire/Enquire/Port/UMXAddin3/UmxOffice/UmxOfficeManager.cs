using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace Compucare.Enquire.Legacy.UMXAddin3.UmxOffice
{
    public abstract class UmxOfficeManager
    {
        public Evaluation eval;

        public Evaluation[] multiEvals = new Evaluation[5];
        public string[] multiTargets = new string[5];


        public abstract void OnSave();
    }
}
