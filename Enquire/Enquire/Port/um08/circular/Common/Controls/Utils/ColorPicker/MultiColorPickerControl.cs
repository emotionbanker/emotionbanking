using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Frontends.Common.Command;

namespace Compucare.Enquire.Common.Controls.Utils.ColorPickerUtil
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

        public void Add(String text, Color c)
        {
            ColorPickerControl cpc = new ColorPickerControl(text, c);
            cpc.Changed += CpcChanged;
            _items.Add(text, cpc);
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

        public void Remove(String text)
        {
            _items[text].Changed -= CpcChanged;
            _items.Remove(text);
            Redo();
        }
    }
}
