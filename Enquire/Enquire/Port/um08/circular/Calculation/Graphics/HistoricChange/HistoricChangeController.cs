using System;
using System.Drawing;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.HistoricChange;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2._2007.Dialogs;
using System.Collections;
using System.Collections.Generic;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.HistoricChange
{
    public class HistoricChangeController
    {
        private readonly HistoricChangeControl _control;
        private readonly Evaluation _eval;
        private readonly HistoricChangeDiagram _output;
        private Hashtable questionstable;
        public static Hashtable questionstable2;
        
        private readonly ChoosePersonControl _cpp;

        public HistoricChangeController(HistoricChangeControl control, Evaluation eval, HistoricChangeDiagram output)
        {
//          gewählte Fragen werden in eine Liste (Frage,Farbe) abgespeichert
            questionstable = new Hashtable();

            questionstable2 = new Hashtable();
            
            _control = control;
            _eval = eval;
            _output = output;

            _cpp = new ChoosePersonControl(_eval);
            _control._panelUserg.Controls.Add(_cpp);
            _cpp.Dock = DockStyle.Fill;

            _cpp.SetSelection(_output.PersonList, _output.ComboList);
            
            foreach (Question q in _output.Questions)
            {
                _control._qBox.Items.Add(q);
            }

            foreach (String hData in _output.HistoricIDs)
            {
                _control._histBox.Items.Add(hData);
            }
            
            _control._sizeControl.SetSize(_output.width, _output.height);

            _control._textBoxCurrent.Text = _output.CurrentName;

            foreach (String key in _output.Colors.Keys)
            {
                    _control._colorPicker.Add(key, _output.Colors[key], 
                    _output.Legends.ContainsKey(key) ? _output.Legends[key] : key,
                    _output.Widths.ContainsKey(key) ? _output.Widths[key] : _output.LineWidth,
                    _output.LineStyle.ContainsKey(key) ? _output.LineStyle[key] : _output.styleofLine);
            }


            _control._areaCheck.Checked = _output.ShowArea;

            /*
             * Werte 5-1-1 werden eingetragen
             */
            _control._textboxScaleMax.Text = _output.ScaleMax.ToString();
            _control._textboxScaleMin.Text = _output.ScaleMin.ToString();
            _control._textLineWidth.Text = _output.LineWidth.ToString();
            
            _control._checkInvert.Checked = _output.InvertScale;

            RegisterEventHandlers();
        }

        public void Preview()
        {
            //wenn mindestens eine Frage (qBox) gewaehlt wurde
            if (_control._qBox.Items.Count > 0)
            {
                _output.eval = _eval;
                _output.width = _control._previewControl.Width;
                _output.height = _control._previewControl.Height;
                _output.PersonList = _cpp.SelectedPersons;
                _output.ComboList = _cpp.SelectedCombos;

                _output.Colors = _control._colorPicker.GetColors();
                _output.Legends = _control._colorPicker.GetTexts();
                _output.Widths = _control._colorPicker.GetWidths();
                _output.LineStyle = _control._colorPicker.GetDashStyles();
             

                _output.ScaleMax = Double.Parse(_control._textboxScaleMax.Text);
                _output.ScaleMin = Double.Parse(_control._textboxScaleMin.Text);

                _output.LineWidth = Int32.Parse(_control._textLineWidth.Text);

                _output.InvertScale = _control._checkInvert.Checked;

                _output.Questions = GetList();
                _output.HistoricIDs = GetHistIds();
                _output.ShowArea = _control._areaCheck.Checked;

                _output.Compute();

                _control._previewControl.SmallPreview = _output.OutputImage;

                _output.width = _control._sizeControl.ChosenWidth;
                _output.height = _control._sizeControl.ChosenHeight;

                _output.Compute();

                _control._previewControl.BigPreview = _output.OutputImage;
            }
        }

        /*
         *holt alle Fragen aus der qBoxListe 
         */
        private Question[] GetList()
        {
            //Anzahl der fragen = die Groese der qBoxListe
            Question[] qs = new Question[_control._qBox.Items.Count];

            int i = 0;
            //durchlaeuft die ganze Liste uns speichert sie in einem Question Array
            foreach (Question q in _control._qBox.Items)
                qs[i++] = q;

            //retourniert die Liste zurück
            return qs;
        }


        /*
         * funktion wie Question[]GetList
         */
        private String[] GetHistIds()
        {
            String[] hs = new String[_control._histBox.Items.Count];

            int i = 0;
            foreach (String h in _control._histBox.Items)
                hs[i++] = h;

            return hs;
        }


        private void RegisterEventHandlers()
        {
            _control._buttonDnc.Click += ButtonDncClick;
            _control._buttonQAdd.Click += ButtonQAddClick;
            _control._buttonQRemove.Click += ButtonQRemoveClick;
            _cpp.SelectionChanged += CppSelectionChanged;
            _control._textBoxCurrent.TextChanged += TextBoxCurrentTextChanged;

            _control._buttonHistRemove.Click += ButtonHistRemoveClick;
            _control._buttonHistAdd.Click += ButtonHistAddClick;

            _control._buttonCompute.Click += ButtonComputeClick;
            _control._colorPicker.Changed += ColorChanged;

            _control._areaCheck.CheckedChanged += AreaCheckCheckedChanged;

            _control._textboxScaleMin.TextChanged += ScaleChanged;
            _control._textboxScaleMax.TextChanged += ScaleChanged;
            _control._textLineWidth.TextChanged += ScaleChanged;

            _control._checkInvert.CheckedChanged += ScaleChanged;
        }

      
        #region Event Handling

        private void ScaleChanged(object sender, EventArgs e)
        {
            Preview();
        }


        void AreaCheckCheckedChanged(object sender, EventArgs e)
        {
            Preview();
        }

        private void ColorChanged()
        {
            Preview();
        }

       
        void ButtonComputeClick(object sender, EventArgs e)
        {
            _output.eval = _eval;
            _output.width = _control._sizeControl.ChosenWidth;
            _output.height = _control._sizeControl.ChosenHeight;

            SaveDialog sd = new SaveDialog(_output);
            sd.ShowDialog();
        }

        void ButtonHistAddClick(String temp)
        {

        }

        void ButtonHistAddClick(object sender, EventArgs e)
        {
            ContextMenu selector = new ContextMenu();

            foreach (HistoricData hd in _eval.History)
            {
                MenuItem item = new MenuItem(hd.Name);

                item.Click += delegate
                {
                    _control._histBox.Items.Add(item.Text);
                    Preview();
                };

                selector.MenuItems.Add(item);
            }

            selector.Show(_control._buttonHistAdd, new Point(_control._buttonHistAdd.Width, 0));
        }

        void ButtonHistRemoveClick(object sender, EventArgs e)
        {
            for (int i = 0; i < _control._histBox.SelectedItems.Count; i++)
            {
                _control._histBox.Items.Remove(_control._histBox.SelectedItems[i]);
            }

            Preview();
        }

        void TextBoxCurrentTextChanged(object sender, EventArgs e)
        {
            _output.CurrentName = _control._textBoxCurrent.Text;
            Preview();
        }

        void CppSelectionChanged()
        {
            _output.PersonList = _cpp.SelectedPersons;
            _output.ComboList = _cpp.SelectedCombos;
            Befuelle();
            Preview();
        }

        void ButtonQRemoveClick(object sender, EventArgs e)
        {
            for (int i = 0; i < _control._qBox.SelectedItems.Count; i++)
            {
                _control._qBox.Items.Remove(_control._qBox.SelectedItems[i]);
            }
            Befuelle();
            Preview();
        }

        void Befuelle()
        {
            _control._colorPicker.Clear();
            
            foreach (Question q in _control._qBox.Items)
            {
                Color color = GetRandomColor();
                
                foreach (Person p in _cpp.SelectedPersons)
                {
                    if (!questionstable2.ContainsKey(q.SID + p.Short))
                    {
                        _control._colorPicker.Add(q.SID + p.Short, color, q.SID + p.Short, _output.LineWidth, _output.styleofLine);
                        HistoricChangeDiagramProperties hcdp = new HistoricChangeDiagramProperties(q.SID + p.Short, _output.styleofLine, _output.LineWidth, color);
                        questionstable2.Add(q.SID + p.Short, hcdp);
                    }
                    else
                    {
                        try
                        {
                            HistoricChangeDiagramProperties hcdp2 = (HistoricChangeDiagramProperties)questionstable2[q.SID + p.Short];
                            _control._colorPicker.Add(q.SID + p.Short, hcdp2.getDashColour(), hcdp2.getDashText(), hcdp2.getDashWidth(), hcdp2.getDashStyle());
                        }catch{}
                                                                            
                    }
                }
                
                foreach (PersonCombo p in _cpp.SelectedCombos)
                {
                    if (!questionstable2.ContainsKey(q.SID + p.Short))
                    {
                        _control._colorPicker.Add(q.SID + p.Short, color, q.SID + p.Short, _output.LineWidth, _output.styleofLine);
                        HistoricChangeDiagramProperties hcdp = new HistoricChangeDiagramProperties(q.SID + p.Short, _output.styleofLine, _output.LineWidth, color);
                        questionstable2.Add(q.SID + p.Short, hcdp);
                    }
                    else
                    {
                        try
                        {
                            HistoricChangeDiagramProperties hcdp2 = (HistoricChangeDiagramProperties)questionstable2[q.SID + p.Short];
                            _control._colorPicker.Add(q.SID + p.Short, hcdp2.getDashColour(), hcdp2.getDashText(), hcdp2.getDashWidth(), hcdp2.getDashStyle());
                        }
                        catch{   }

                    }
                }

            }//end 1st foreach
        }//end Befülle

        void ButtonQAddClick(object sender, EventArgs e)
        {
            //Fragenliste wird aufgerufen
            QuestionSelect qs = new QuestionSelect(_eval);
            if (qs.ShowDialog() == DialogResult.OK)
            {
                //selektierte Fragen aus den qs werden durchgeganen
                foreach (Question q in qs.SelectedQuestions)
                {
                    _control._qBox.Items.Add(q); //ausgewählten Fragen werden in die Frageliste eintgeragen
                }
                Befuelle();
            }
            Preview();
        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)); 
        }

        void ButtonDncClick(object sender, EventArgs e)
        {
            ChartingSettings cs = new ChartingSettings(_output.DncSettings);
            cs.ShowDialog();

            if (cs.DialogResult == DialogResult.OK)
            {
                _output.DncSettings = cs.Settings;
                Preview();
            }
        }

        #endregion Event Handling
    }
}
