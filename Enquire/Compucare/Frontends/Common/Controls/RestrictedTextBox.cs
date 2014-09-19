using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Frontends.Common.Controls
{
    public enum RestrictionMode
    {
        Restrict,
        AllowOnly
    }

    public class RestrictedTextBox : TextBox
    {
        protected List<char> CharacterList { get; set; }

        protected RestrictionMode Mode { get; set; }

        public RestrictedTextBox()
        {
            CharacterList = new List<char>();
            Mode = RestrictionMode.Restrict;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (Mode == RestrictionMode.AllowOnly && !CharacterList.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Mode == RestrictionMode.Restrict && CharacterList.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyPress(e);
            }
        }
    }
}
