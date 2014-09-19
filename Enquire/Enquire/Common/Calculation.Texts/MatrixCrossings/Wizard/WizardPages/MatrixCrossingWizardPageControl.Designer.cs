namespace Compucare.Enquire.Common.Calculation.Texts.MatrixCrossings.Wizard.WizardPages
{
    partial class MatrixCrossingWizardPageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._qSelectHorizontal = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorControl();
            this._qSelectVertical = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorControl();
            this._radio2 = new System.Windows.Forms.RadioButton();
            this._radio3 = new System.Windows.Forms.RadioButton();
            this._radio5 = new System.Windows.Forms.RadioButton();
            this._valueSelectionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // _qSelectHorizontal
            // 
            this._qSelectHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._qSelectHorizontal.Header = "Horizontal";
            this._qSelectHorizontal.Location = new System.Drawing.Point(3, 3);
            this._qSelectHorizontal.Name = "_qSelectHorizontal";
            this._qSelectHorizontal.Size = new System.Drawing.Size(458, 51);
            this._qSelectHorizontal.TabIndex = 0;
            // 
            // _qSelectVertical
            // 
            this._qSelectVertical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._qSelectVertical.Header = "Vertical";
            this._qSelectVertical.Location = new System.Drawing.Point(3, 60);
            this._qSelectVertical.Name = "_qSelectVertical";
            this._qSelectVertical.Size = new System.Drawing.Size(458, 51);
            this._qSelectVertical.TabIndex = 1;
            // 
            // _radio2
            // 
            this._radio2.AutoSize = true;
            this._radio2.Checked = true;
            this._radio2.Location = new System.Drawing.Point(12, 130);
            this._radio2.Name = "_radio2";
            this._radio2.Size = new System.Drawing.Size(42, 17);
            this._radio2.TabIndex = 2;
            this._radio2.TabStop = true;
            this._radio2.Text = "2x2";
            this._radio2.UseVisualStyleBackColor = true;
            // 
            // _radio3
            // 
            this._radio3.AutoSize = true;
            this._radio3.Location = new System.Drawing.Point(12, 153);
            this._radio3.Name = "_radio3";
            this._radio3.Size = new System.Drawing.Size(42, 17);
            this._radio3.TabIndex = 3;
            this._radio3.TabStop = true;
            this._radio3.Text = "3x3";
            this._radio3.UseVisualStyleBackColor = true;
            // 
            // _radio5
            // 
            this._radio5.AutoSize = true;
            this._radio5.Location = new System.Drawing.Point(12, 176);
            this._radio5.Name = "_radio5";
            this._radio5.Size = new System.Drawing.Size(42, 17);
            this._radio5.TabIndex = 4;
            this._radio5.TabStop = true;
            this._radio5.Text = "5x5";
            this._radio5.UseVisualStyleBackColor = true;
            // 
            // _valueSelectionPanel
            // 
            this._valueSelectionPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this._valueSelectionPanel.ColumnCount = 2;
            this._valueSelectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._valueSelectionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._valueSelectionPanel.Location = new System.Drawing.Point(80, 117);
            this._valueSelectionPanel.Name = "_valueSelectionPanel";
            this._valueSelectionPanel.RowCount = 2;
            this._valueSelectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._valueSelectionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._valueSelectionPanel.Size = new System.Drawing.Size(125, 108);
            this._valueSelectionPanel.TabIndex = 6;
            // 
            // MatrixCrossingWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._valueSelectionPanel);
            this.Controls.Add(this._radio5);
            this.Controls.Add(this._radio3);
            this.Controls.Add(this._radio2);
            this.Controls.Add(this._qSelectVertical);
            this.Controls.Add(this._qSelectHorizontal);
            this.Name = "MatrixCrossingWizardPageControl";
            this.Size = new System.Drawing.Size(464, 258);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RadioButton _radio5;
        internal System.Windows.Forms.RadioButton _radio3;
        internal System.Windows.Forms.RadioButton _radio2;
        internal Controls.DataItems.SingleQuestionSelectorControl _qSelectHorizontal;
        internal Controls.DataItems.SingleQuestionSelectorControl _qSelectVertical;
        internal System.Windows.Forms.TableLayoutPanel _valueSelectionPanel;
    }
}
