namespace Compucare.Enquire.Common.Controls.DataItems
{
    partial class SingleQuestionSelectorCrossingControl
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
            this._crossingPanel = new System.Windows.Forms.Panel();
            this._answerSelect = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            this._crossQuestion = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this._crossingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _headGroup
            // 
            this._headGroup.Size = new System.Drawing.Size(472, 165);
            // 
            // _crossingPanel
            // 
            this._crossingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._crossingPanel.Controls.Add(this._answerSelect);
            this._crossingPanel.Controls.Add(this._crossQuestion);
            this._crossingPanel.Controls.Add(this.label1);
            this._crossingPanel.Location = new System.Drawing.Point(6, 45);
            this._crossingPanel.Name = "_crossingPanel";
            this._crossingPanel.Size = new System.Drawing.Size(460, 31);
            this._crossingPanel.TabIndex = 4;
            // 
            // _answerSelect
            // 
            this._answerSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._answerSelect.InitString = null;
            this._answerSelect.Location = new System.Drawing.Point(246, 3);
            this._answerSelect.Name = "_answerSelect";
            this._answerSelect.Size = new System.Drawing.Size(191, 20);
            this._answerSelect.TabIndex = 2;
            // 
            // _crossQuestion
            // 
            this._crossQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._crossQuestion.InitString = null;
            this._crossQuestion.Location = new System.Drawing.Point(45, 3);
            this._crossQuestion.Name = "_crossQuestion";
            this._crossQuestion.Size = new System.Drawing.Size(195, 20);
            this._crossQuestion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cross:";
            // 
            // SingleQuestionSelectorCrossingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._crossingPanel);
            this.Name = "SingleQuestionSelectorCrossingControl";
            this.Size = new System.Drawing.Size(472, 165);
            this.Controls.SetChildIndex(this._headGroup, 0);
            this.Controls.SetChildIndex(this._crossingPanel, 0);
            this._crossingPanel.ResumeLayout(false);
            this._crossingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _crossingPanel;
        private System.Windows.Forms.Label label1;
        internal Utils.DropDownTextbox _crossQuestion;
        internal Utils.DropDownTextbox _answerSelect;
    }
}
