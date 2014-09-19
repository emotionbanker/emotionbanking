using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Compucare.Enquire.Common.Calculation.Graphics.Common.ColorRanges;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
    [Serializable]
    public class SocioMatrix : Output
    {
        public enum NodeMode
        {
            All,
            Single,
            SingleIn,
            SingleOut
        }

        public Question _nodeQuestion;
        public Question _edgeQuestion;

        public double _edgeMinSize = 1;
        public double _edgeMaxSize = 5;

        public Font _nodeFont;

        public Size _nodeSize;

        public int _startAngle = 0;

        public MultiColorRange _colorRange;

        private Size _size;

        public Boolean _invert;
        public Boolean _relativeWeighting;

        public NodeMode _nodeMode;

        public String _singleNode;

        public SocioMatrix(Evaluation eval)
        {
            this.eval = eval;
            _nodeFont = new Font("Arial", 10);
            _nodeSize = new Size(120,60);
            this.width = 500;
            this.height = 300;

            _colorRange = new MultiColorRange(new SingleColorRange(100, 80, Color.Green),
                new SingleColorRange(80, 20, Color.Black),
                new SingleColorRange(20, 0, Color.Red));

        }

        #region Serialization methods

        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            LoadSerData(info, ctxt);
            
            Question.SetMultipart(_nodeQuestion, Multipart);
            Question.SetMultipart(_edgeQuestion, Multipart);

            info.AddValue("nodeQuestion", _nodeQuestion);
            info.AddValue("edgeQuestion", _edgeQuestion);

            info.AddValue("edgeMinSize", _edgeMinSize);
            info.AddValue("edgeMaxSize", _edgeMaxSize);

            info.AddValue("nodeFont", _nodeFont);

            info.AddValue("nodeSize", _nodeSize);

            info.AddValue("size", _size);

            info.AddValue("startAngle", _startAngle);
            info.AddValue("colorRange", _colorRange);

            info.AddValue("invert", _invert);
            info.AddValue("relativeWeighting", _relativeWeighting);

            info.AddValue("nodeMode", _nodeMode);
            info.AddValue("singleNode", _singleNode);
        }

        public SocioMatrix(SerializationInfo info, StreamingContext ctxt)
        {
            ReadSerData(info, ctxt);

            _nodeQuestion = (Question)info.GetValue("nodeQuestion", typeof(Question));
            _edgeQuestion = (Question)info.GetValue("edgeQuestion", typeof(Question));

            _edgeMinSize = info.GetDouble("edgeMinSize");
            _edgeMaxSize = info.GetDouble("edgeMaxSize");

            _nodeFont = (Font) info.GetValue("nodeFont", typeof (Font));

            _nodeSize = (Size) info.GetValue("nodeSize", typeof (Size));

            _size = (Size) info.GetValue("size", typeof (Size));

            _startAngle = info.GetInt32("startAngle");
            try
            {
                _colorRange = (MultiColorRange)info.GetValue("colorRange", typeof(MultiColorRange));                
            }
            catch (Exception)
            {
                _colorRange = new MultiColorRange(new SingleColorRange(100, 0, Color.Black));
            }

            try
            {
                _invert = info.GetBoolean("invert");
                _relativeWeighting = info.GetBoolean("relativeWeighting");
            }
            catch (Exception)
            {
                _invert = false;
                _relativeWeighting = false;
            }

            try
            {
                _nodeMode = (NodeMode) info.GetValue("nodeMode", typeof (NodeMode));
                _singleNode = info.GetString("singleNode");
            }
            catch (Exception)
            {
                _nodeMode = NodeMode.All;
                _singleNode = null;
            }
        }

        #endregion Serialization methods

        #region Loading methods

        public override void LoadGlobalQ()
        {
            LoadQ(_nodeQuestion);
            LoadQ(_edgeQuestion);
        }

        public override void LoadTargetQ(TargetData td)
        {
            Console.WriteLine("load target q");
            LoadTQ(td, _nodeQuestion);
            LoadTQ(td, _edgeQuestion);
        }

        #endregion Loading methods



        public override void Compute()
        {

            _size = new Size(width*2, height*2);
            //create bitmap, get graphics handle

            OutputImage = new Bitmap(_size.Width, _size.Height);
            Graphics g = Graphics.FromImage(OutputImage);

            if (_nodeQuestion == null || _edgeQuestion == null)
            {
                g.DrawString("keine Daten.", new Font("Arial", 12), new SolidBrush(Color.Red), 0, 0);
                return;
            }
            //text bubble size defined in _nodeSize

            //build "circle"

            PointF center = new PointF((float) _size.Width/2, (float) _size.Height/2);

            double angleStep = 2*Math.PI/_nodeQuestion.AnswerList.Length;
            double radiusX = _size.Width/2 - _nodeSize.Width;
            double radiusY = _size.Height/2 - _nodeSize.Height;

            List<SocioNode> nodes = new List<SocioNode>();

            for (double i = 0; i < _nodeQuestion.AnswerList.Length; i++)
            {
                SocioNode node = new SocioNode();

                double angleDeg = (i*angleStep)*(180.0/Math.PI);

                angleDeg += _startAngle;

                if (angleDeg > 360) angleDeg -= 360;

                double angle = Math.PI*angleDeg/180.0;

                node.Center = new PointF((float) (Math.Cos(angle)*radiusX) + _size.Width/2f,
                                         (float) (Math.Sin(angle)*radiusY) + _size.Height/2f);

                node.Text = _nodeQuestion.AnswerList[(int) i];

                nodes.Add(node);
            }

            int PID;
            foreach (Result from in _nodeQuestion.Results)
            {
                PID = Eval.GetPersonIdByUser(from.UserID);
                bool add = false;

                foreach (Person p in PersonList)
                    if (p.ID == PID)
                        add = true;

                foreach (PersonCombo c in ComboList)
                    if (c.ContainsID(PID))
                        add = true;

                if (!add) continue;

                Result to = _edgeQuestion.GetResultByUserID(from.UserID);

                if (to == null) continue;

                String fromAnswer;
                String toAnswer;

                if (from.SelectedAnswer == -1 || to.SelectedAnswer == -1)
                {
                    fromAnswer = from.TextAnswer;
                    toAnswer = to.TextAnswer;
                }
                else
                {
                    fromAnswer = _nodeQuestion.AnswerList[from.SelectedAnswer];
                    toAnswer = _edgeQuestion.AnswerList[to.SelectedAnswer];
                }

                // multi support 

                List<String> fromAnswers = new List<string>();
                List<String> toAnswers = new List<string>();

                if (_nodeQuestion.IsMulti) fromAnswers.AddRange(fromAnswer.Split(';'));
                else fromAnswers.Add(fromAnswer);

                if (_edgeQuestion.IsMulti) toAnswers.AddRange(toAnswer.Split(';'));
                else toAnswers.Add(toAnswer);

                foreach (String fa in fromAnswers)
                {
                    SocioNode master = GetNode(fa, nodes);
                    if (master == null) continue;

                    foreach (String ta in toAnswers)
                    {
                        if (fa.Equals(ta)) //own
                        {
                            master.Weight++;
                        }
                        else
                        {
                            if (master.Edges.ContainsKey(ta)) master.Edges[ta]++;
                            else master.Edges.Add(ta, 0);
                        }
                    }

                    master.RelMax += toAnswers.Count;
                }
            }

            //compute weights

            float maxNode = float.MinValue, minNode = float.MaxValue;
            float maxEdge = float.MinValue, minEdge = float.MaxValue;

            foreach (SocioNode sn in nodes)
            {
                if (sn.Weight > maxNode) maxNode = sn.Weight;
                if (sn.Weight < minNode) minNode = sn.Weight;

                foreach (String edge in sn.Edges.Keys)
                {
                    if (sn.Edges[edge] > maxEdge) maxEdge = sn.Edges[edge];
                    if (sn.Edges[edge] < minEdge) minEdge = sn.Edges[edge];
                }
            }

            double nodeFact = (maxNode - minNode)/(_edgeMaxSize - _edgeMinSize);
            double edgeFact = (maxEdge - minEdge)/(_edgeMaxSize - _edgeMinSize);

          

            Console.WriteLine("edge fact: " + edgeFact);

            foreach (SocioNode sn in nodes)
            {
                if (!_relativeWeighting)
                {
                    sn.Weight = GetWeight(minNode, maxNode, sn.Weight);
                    //sn.Weight = sn.Weight/(float) nodeFact;
                }
                else
                {
                    //relative weighting!
                    sn.Weight = GetWeight(0, sn.RelMax, sn.Weight);
                }
                List<String> edges = new List<string>();
                foreach (String edge in sn.Edges.Keys)
                {
                    edges.Add(edge);
                }
                foreach (String edge in edges)
                {
                    if (!_relativeWeighting)
                    {
                        sn.Edges[edge] = GetWeight(minEdge, maxEdge, sn.Edges[edge]);
                        //sn.Edges[edge] = sn.Edges[edge]/(float) edgeFact;
                    }
                    else
                    {
                        sn.Edges[edge] = GetWeight(0, sn.RelMax, sn.Edges[edge]);
                    }

                    if (float.IsNaN(sn.Edges[edge])) sn.Edges[edge] = (float) _edgeMinSize;

                    if (sn.Edges[edge] < _edgeMinSize)
                        sn.Edges[edge] = (float)_edgeMinSize;

                    if (sn.Edges[edge] > _edgeMaxSize)
                        sn.Edges[edge] = (float)_edgeMaxSize;
                }
            }

            //draw!

            g.SmoothingMode = SmoothingMode.AntiAlias;

            //centers
            foreach (SocioNode sn in nodes)
            {
                //draw only depending on node mode
                if (!CheckNodeMode(sn, nodes)) continue;

                float rad = 2;
                Console.WriteLine(sn.Text + ":" + sn.Center);
                g.FillEllipse(new SolidBrush(Color.Blue), sn.Center.X - rad, sn.Center.Y - rad, 2*rad, 2*rad);

            }

            Console.WriteLine("[dimensions]\t" + OutputImage.Size);
            Console.WriteLine("clip: " + g.VisibleClipBounds);


            //edges
            foreach (SocioNode sn in nodes)
            {
                //draw only depending on node mode
                if (!CheckNodeMode(sn, nodes)) continue;

                if (_nodeMode == NodeMode.SingleOut && sn.Text != _singleNode)
                    continue;
                    
                foreach (String edge in sn.Edges.Keys)
                {
                    
                    if (_nodeMode == NodeMode.SingleIn && edge != _singleNode)
                        continue;
                    
                    SocioNode target = GetNode(edge, nodes);

                    if (target == null) continue;

                    Pen p = new Pen(GetRangeColor(sn.Edges[edge]), sn.Edges[edge]);

                    PointF p1, p2;
                    if (NodeOrder(sn, target, nodes) > 0)
                    {
                        //g.DrawLine(p, sn.CenterTop, target.CenterTop);

                        p1 = sn.CenterTop;
                        p2 = target.CenterTop;
                    }
                    else
                    {
                        //g.DrawLine(p, sn.CenterBottom, target.CenterBottom);

                        p1 = sn.CenterBottom;
                        p2 = target.CenterBottom;
                    }

                    if (sn.Weight == float.NaN || float.IsNaN(sn.Weight)) sn.Weight = 1;
                    else if (sn.Weight <= 0) sn.Weight = 1;


                    PointF p0 = sn.Center;
                    float rx = _nodeSize.Width/2f;
                    float ry = _nodeSize.Height/2f;

                    PointF arrowhead = SPt(p0, rx, ry, p1, p2);
                    PointF arrowheadInv = SPt(target.Center, rx, ry, p1, p2);

                    PointF arrowass = SPt(p0, rx + (sn.Weight/2f), ry + (sn.Weight/2f), p1, p2);

                    p.EndCap = LineCap.Custom;
                    
                    float wid = Math.Max(4f, p.Width * 0.1f);
                    p.CustomEndCap = new AdjustableArrowCap(wid, wid, true);
                    
                    Console.WriteLine("Pen wid: " + p.Width);
                    Console.WriteLine(edge + " to " + sn.Text);
                    Console.WriteLine("draw line from [" + p2 + "] to [" + arrowhead + "]");
                    
                    if (_invert)
                    {
                        g.DrawLine(p,  p2, arrowhead);
                    }
                    else
                    {
                        g.DrawLine(p, p1, arrowheadInv);                        
                    }
                    
                    //g.FillEllipse(Brushes.Red, arrowhead.X - 5, arrowhead.Y - 5, 10, 10);
                    //g.FillEllipse(Brushes.Blue, arrowass.X - 5, arrowass.Y - 5, 10, 10);
                }
            }

            //blank ellipses, border
            
            foreach (SocioNode sn in nodes)
            {
                //draw only depending on node mode
                if (!CheckNodeMode(sn, nodes)) continue;

                RectangleF bounds = new RectangleF(
                    sn.Center.X - (_nodeSize.Width/2f),
                    sn.Center.Y - (_nodeSize.Height/2f),
                    _nodeSize.Width,
                    _nodeSize.Height);

                RectangleF textBounds = new RectangleF(
                    sn.Center.X - (_nodeSize.Width/2f) + _nodeSize.Width/6f,
                    sn.Center.Y - (_nodeSize.Height/2f) + 5,
                    _nodeSize.Width - _nodeSize.Width/3f,
                    _nodeSize.Height - 10);

                g.FillEllipse(new SolidBrush(Color.White), bounds);

                if (sn.Weight == float.NaN || float.IsNaN(sn.Weight)) sn.Weight = 1;
                else if (sn.Weight <= 0) sn.Weight = 1;

                Console.WriteLine(sn.Weight);
                g.DrawEllipse(new Pen(GetRangeColor(sn.Weight), sn.Weight), bounds);

                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;

                g.DrawString(sn.Text, _nodeFont, new SolidBrush(Color.Black), textBounds, drawFormat);
            }
        }

        private bool CheckNodeMode(SocioNode node, List<SocioNode> nodes)
        {
            if (_nodeMode == NodeMode.All) return true;

            if (_singleNode == null || !_nodeQuestion.Answers.Contains(_singleNode)) return false;

            if (_singleNode == node.Text) return true;

            bool incoming = false;
            bool outgoing = false;

            if (node.Edges.ContainsKey(_singleNode) && node.Edges[_singleNode] > 0) incoming = true;

            foreach (SocioNode other in nodes)
            {
                if (other.Text != _singleNode) continue;
                if (other.Edges.ContainsKey(node.Text) && other.Edges[node.Text] > 0) outgoing = true;
            }

            if (_nodeMode == NodeMode.Single && (incoming || outgoing)) return true;

            if (_nodeMode == NodeMode.SingleIn && incoming) return true;
            if (_nodeMode == NodeMode.SingleOut && outgoing) return true;

            return false;
        }

        private float GetWeight(double minVal, double maxVal, double val)
        {
            return (float) ((  ((_edgeMaxSize - _edgeMinSize)/  (maxVal - minVal)) *(val - minVal)) + _edgeMinSize);
        }

        private Color GetRangeColor(float val)
        {
            try
            {
                double range = _edgeMaxSize - _edgeMinSize;

                double rval = Math.Max(val - _edgeMinSize, 0);

                double tval = (rval / range) * 100;

                if (tval == 100) tval = 99.99999;

                return _colorRange.GetColor(tval);
            }
            catch (Exception)
            {
                return Color.Black;
            }
            
        }


        private PointF SPt(PointF p0, float rx, float ry, PointF p1, PointF p2)
        {
            PointF ary = new PointF();

            float rrx = rx*rx, rry = ry*ry;

            float x21 = p2.X-p1.X, y21 = p2.Y-p1.Y;
            float x10 = p1.X-p0.X, y10 = p1.Y-p0.Y;

            float a = x21*x21/rrx+y21*y21/rry;
            float b = x21*x10/rrx+y21*y10/rry;
            float c = x10*x10/rrx+y10*y10/rry;

            float d = b*b-a*(c-1);
  
            if (d>=0)
            { 
                float e = (float)Math.Sqrt(d);
    
                float u1 = (-b-e)/a, u2 = (-b+e)/a;
    
                if (0<=u1 && u1<=1)
                {
                    ary.X = p1.X + x21*u1;
                    ary.Y = p1.Y + y21*u1;
                }
                if (0<=u2 && u2<=1)
                {
                    ary.X = p1.X + x21*u2;
                    ary.Y = p1.Y + y21*u2;
                }
            }
            return ary;
        }

        public int NodeOrder (SocioNode a, SocioNode b, List<SocioNode> nodes)
        {
            int posa = -1;
            int posb = -1;

            int i = 0;
            foreach (SocioNode n in nodes)
            {
                if (n == a) posa = i;
                if (n == b) posb = i;
                i++;
            }

            if (posa == -1 || posb == -1) return -1;

            return posb - posa;

        }

        public SocioNode GetNode(String text, List<SocioNode> nodes)
        {
            
            foreach (SocioNode sn in nodes)
            {
                if (sn.Text.Equals(text)) return sn;
            }

            return null;
        }

        public override void Save(string name, string path)
        {
            //
            Question BaseHorizontal = _edgeQuestion;
            Question BaseVertical = _nodeQuestion;

            Question[] all = new Question[2];
            all[0] = _edgeQuestion;
            all[1] = _nodeQuestion;

            //cross?
            Evaluation seval;
            if (CrossTargets(all))
            {
                seval = this.CrEval;
            }
            else if (this.OvEval != null)
            {
                seval = OvEval;
            }
            else
            {
                seval = this.eval;
            }
            //Targets

            foreach (TargetData td in seval.CombinedTargets)
            {
                if (!td.Included)
                    continue;

                //				Console.WriteLine("td=" + td.Name + "; rcount=" + td.ResultCount);

                _edgeQuestion = td.GetQuestion(BaseHorizontal, Eval);
                _nodeQuestion = td.GetQuestion(BaseVertical, Eval);

                //Console.WriteLine("h=" + h + ";v=" + v);

                Compute();

                FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").png"), FileMode.Create);
                OutputImage.Save(myFileOut, ImageFormat.Png);
                myFileOut.Close();
            }

            seval = null;
            OutputImage = null;

        }

        #region Edit methods

        public override void EditDialog()
        {
            throw new NotImplementedException();
        }

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_SocioMatrix(eval, this);
        }

        #endregion Edit methods

        public class SocioNode
        {
            private static float SUBNODE_RADIUS = 5f;

            public PointF Center;

            public PointF CenterTop
            {
                get
                {
                    return new PointF(Center.X, Center.Y - SUBNODE_RADIUS);
                }
            }

            public PointF CenterBottom
            {
                get
                {
                    return new PointF(Center.X, Center.Y + SUBNODE_RADIUS);
                }
            }

            public String Text;

            public float Weight = 0;

            public float RelMax = 0;

            public Dictionary<String,float> Edges;

            public SocioNode()
            {
                Edges = new Dictionary<string, float>();
            }
        }
    }
}
