using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Compucare.Frontends.Common.Controls
{
    public class ColorComboBox : ComboBox
    {
        public Color Color
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(Text)) return Color.FromName(Text);
                
                return Color.Black;
            }
            set
            {
                Text = value.Name;
            }
        }

        public ColorComboBox()
        {
            Text = "";
            SelectedIndex = -1;
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            Width = 120;

            // Since the colors aren't enumerated, we can use Type.GetProperties()
            // to get all colors.
            // This will return colors listed under "Web"
            Color c = Color.Black;
            Type t = c.GetType();

            PropertyInfo[] pis = t.GetProperties();
            foreach (PropertyInfo p in pis)
            {
                // Filter out all properties that aren't colors and add to the dropdownlist
                if (p.PropertyType == typeof(Color))
                    Items.Add(p.Name);
            }
        }

        // The combobox is set to OwnerDrawFixed, so we are responsible to draw all items
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            // Get the name of the current item to be drawn, and make a brush of it
            string s = (string)this.Items[e.Index];
            SolidBrush b = new SolidBrush(Color.FromName(s));
            // Draw a rectangle and fill it with the current color
            // and add the name to the right of the color
            e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
            e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
            e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
            b.Dispose();
        }
    }
}
