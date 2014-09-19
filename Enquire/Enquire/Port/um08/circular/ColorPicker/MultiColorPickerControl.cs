using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Frontends.Common.Command;
using System.Drawing.Drawing2D;

namespace Compucare.Enquire.Common.Controls.Utils.ColorPicker
{
    public partial class MultiColorPickerControl : UserControl
    {
        public event CommonEventHandler Changed;

        private readonly Dictionary<String, ColorPickerControl> _items;

        public MultiColorPickerControl()
        {
            InitializeComponent();

            _items = new Dictionary<string, ColorPickerControl>();
        }

        public void Add(String key, Color c, String text, Int32 width, DashStyle dash)
        {
            ColorPickerControl cpc = new ColorPickerControl(text, c, width, dash, key);
            cpc.Changed += CpcChanged;
            _items.Add(key, cpc);
            Redo();
        }

        void CpcChanged()
        {
 	        EventHelper.Fire(Changed);
        }


        public void Clear()
        {
            _items.Clear();
            Redo();
        }

        private void Redo()
        {
            _scrollPane.Controls.Clear();
            int ypos = 0;
            foreach (String key in _items.Keys)
            {
                Control c = _items[key];
                c.Location = new Point(0, ypos);
                c.Width = _scrollPane.Width;
                _scrollPane.Controls.Add(c);
                ypos += c.Height;
            }
        }

        public Dictionary<String,Color> GetColors()
        {
            Dictionary<String,Color> retVal = new Dictionary<string, Color>();
            foreach (String key in _items.Keys)
            {
                retVal.Add(key, _items[key].GetColor());
            }
            return retVal;
        }

        public Dictionary<String,String> GetTexts()
        {
            Dictionary<String, String> retVal = new Dictionary<string, String>();
            foreach (String key in _items.Keys)
            {
                retVal.Add(key, _items[key].GetText());
            }
            return retVal;
        }

        public Dictionary<String,Int32> GetWidths()
        {
            Dictionary<String, Int32> retVal = new Dictionary<String, Int32>();
            foreach (String key in _items.Keys)
            {
                retVal.Add(key, _items[key].GetWidth());
            }
            return retVal;
        }

        public Dictionary<String, DashStyle> GetDashStyles()
        {
            Dictionary<String, DashStyle> retVal = new Dictionary<String, DashStyle>();
            foreach (String key in _items.Keys)
            {
                retVal.Add(key, _items[key].GetDashStyle());
            }
            return retVal;
        }

        public void Remove(String text)
        {
            _items[text].Changed -= CpcChanged;
            _items.Remove(text);
            Redo();
        }
    }
}
