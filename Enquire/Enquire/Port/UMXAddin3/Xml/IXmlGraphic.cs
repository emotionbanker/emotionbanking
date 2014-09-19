using System;
using System.Drawing;

namespace Compucare.Enquire.Legacy.UMXAddin3.Xml
{
    public interface IXmlGraphic
    {
        Size Size { get; }

        String Store();
    }
}
