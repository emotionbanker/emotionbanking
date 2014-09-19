using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Compucare.Enquire.Common.Calculation.Graphics.Common.ColorRanges;
using Compucare.Frontends.Common.Command;

namespace Compucare.Enquire.Common.Calculation.Graphics.Common.Controls.ColorRanges
{
    public partial class TripleColorRangeControl : UserControl
    {
        public event CommonEventHandler<TripleColorRangeControl> SettingsChanged;

        private Double _maxVal;
        private Double _minVal;

        public MultiColorRange ColorRange { get { return GetRange(); } set {SetRange(value);}}

        public Double MaxValue { set { _labelMaxValue.Text = value.ToString(); _maxVal = value; EventHelper.Fire(SettingsChanged, this); } get { return _maxVal; } }
        public Double MinValue { set { _labelMinValue.Text = value.ToString(); _minVal = value; EventHelper.Fire(SettingsChanged, this); } get { return _minVal; } }

        public Double RangeHigh
        {
            set { _textRangeHigh.DoubleValue = value; EventHelper.Fire(SettingsChanged, this); }
            get { return _textRangeHigh.DoubleValue; }
        }

        public Double RangeMid
        {
            set { _textRangeMid.DoubleValue = value; EventHelper.Fire(SettingsChanged, this); }
            get { return _textRangeMid.DoubleValue; }
        }

        public Color ColorHigh { get { return _colorHighRange.Color; } set { _colorHighRange.Color = value; EventHelper.Fire(SettingsChanged, this); } }
        public Color ColorMid { get { return _colorMidRange.Color; } set { _colorMidRange.Color = value; EventHelper.Fire(SettingsChanged, this); } }
        public Color ColorLow { get { return _colorLowRange.Color; } set { _colorLowRange.Color = value; EventHelper.Fire(SettingsChanged, this); } }


        public TripleColorRangeControl()
        {
            InitializeComponent();

            _textRangeHigh.TextChanged +=
               delegate { _labelHighValue.Text = _textRangeHigh.Text; };

            _textRangeMid.TextChanged +=
                delegate { _labelMidValue.Text = _textRangeMid.Text; };

            _colorHighRange.ColorChanged += delegate { Changed(); };
            _colorMidRange.ColorChanged += delegate { Changed(); };
            _colorLowRange.ColorChanged += delegate { Changed(); };
            _textRangeHigh.TextChanged += delegate { Changed(); };
            _textRangeMid.TextChanged += delegate { Changed(); };
        }

        private void Changed()
        {
            EventHelper.Fire(SettingsChanged, this);
        }

        public bool IsValid()
        {
            return (_textRangeHigh.IsValid && _textRangeMid.IsValid
                && _textRangeHigh.DoubleValue < MaxValue &&
                _textRangeMid.DoubleValue > MinValue);
        }

        private MultiColorRange GetRange()
        {
            return new MultiColorRange(
                new []
                    {
                        new SingleColorRange(MaxValue, RangeHigh, ColorHigh), 
                        new SingleColorRange(RangeHigh, RangeMid, ColorMid), 
                        new SingleColorRange(RangeMid, MinValue, ColorLow)
                    });
        }

        private void SetRange(MultiColorRange range)
        {
            MaxValue = GetHigh(range).From;
            MinValue = GetLow(range).To;

            RangeHigh = GetHigh(range).To;
            RangeMid = GetLow(range).From;

            ColorHigh = GetHigh(range).Color;
            ColorMid = GetMid(range).Color;
            ColorLow = GetLow(range).Color;
        }

        private SingleColorRange GetHigh(MultiColorRange range)
        {
            SingleColorRange max = range.Ranges[0];

            foreach (SingleColorRange sr in range.Ranges)
            {
                if ((Math.Max(sr.From, sr.To)) > Math.Max(max.From, max.To))
                {
                    max = sr;
                }
            }

            return max;
        }

        private SingleColorRange GetLow(MultiColorRange range)
        {
            SingleColorRange min = range.Ranges[0];

            foreach (SingleColorRange sr in range.Ranges)
            {
                if ((Math.Max(sr.From, sr.To)) < Math.Max(min.From, min.To))
                {
                    min = sr;
                }
            }

            return min;
        }

        private SingleColorRange GetMid(MultiColorRange range)
        {
            foreach (SingleColorRange sr in range.Ranges)
            {
                if (sr != GetHigh(range) && sr != GetLow(range)) return sr;
            }

            return null;
        }

        public const String TagRoot = "TripleColorRange";

        public String ToXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement(TagRoot));

            root.AppendChild(doc.CreateElement("MaxValue")).InnerText = MaxValue.ToString();
            root.AppendChild(doc.CreateElement("MinValue")).InnerText = MinValue.ToString();
            root.AppendChild(doc.CreateElement("RangeHigh")).InnerText = RangeHigh.ToString();
            root.AppendChild(doc.CreateElement("RangeMid")).InnerText = RangeMid.ToString();
            
            root.AppendChild(doc.CreateElement("ColorHigh")).InnerText = ColorHigh.ToArgb().ToString();
            root.AppendChild(doc.CreateElement("ColorMid")).InnerText = ColorMid.ToArgb().ToString();
            root.AppendChild(doc.CreateElement("ColorLow")).InnerText = ColorLow.ToArgb().ToString();

            return doc.OuterXml;
        }

        public void FromXml(String xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            XmlElement root = doc.DocumentElement;

            MaxValue = double.Parse(root.GetElementsByTagName("MaxValue")[0].InnerText);
            MinValue = double.Parse(root.GetElementsByTagName("MinValue")[0].InnerText);
            RangeHigh = double.Parse(root.GetElementsByTagName("RangeHigh")[0].InnerText);
            RangeMid = double.Parse(root.GetElementsByTagName("RangeMid")[0].InnerText);

            ColorHigh = Color.FromArgb(int.Parse(root.GetElementsByTagName("ColorHigh")[0].InnerText));
            ColorMid = Color.FromArgb(int.Parse(root.GetElementsByTagName("ColorMid")[0].InnerText));
            ColorLow = Color.FromArgb(int.Parse(root.GetElementsByTagName("ColorLow")[0].InnerText));
        }
    }
}
