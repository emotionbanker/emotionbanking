using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace Compucare.Enquire.Common.DataModule.Xml
{
    public interface IXmlTransformable
    {
        String ToXml();
        void FromXml(String xmlString, Evaluation eval);
    }
}
