using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Frontends.Common.Controls
{
    public class IntegerTextBox : RestrictedTextBox
    {
        public bool IsValid
        {
            get
            {
                try
                {
                    Int32.Parse(Text, CultureInfo.InvariantCulture);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public Int32 Int32Value
        {
            get { if (IsValid) return Int32.Parse(Text, CultureInfo.InvariantCulture); return 0; }
            set { Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public IntegerTextBox()
        {
            Mode = RestrictionMode.AllowOnly;

            TextAlign = HorizontalAlignment.Right;

            CharacterList = new List<char> {'0','1','2','3','4','5','6','7','8','9',
                                            '-'};
        }
    }
}
