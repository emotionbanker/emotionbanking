namespace Compucare.Enquire.Common.Calculation.Texts.Script.Wizard.WizardPages
{
    partial class ExpressionWizardPageControl
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
            this.label1 = new System.Windows.Forms.Label();
            this._personBox = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this._expression = new System.Windows.Forms.TextBox();
            this._testButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User group:";
            // 
            // _personBox
            // 
            this._personBox.InitString = null;
            this._personBox.Location = new System.Drawing.Point(96, 3);
            this._personBox.Name = "_personBox";
            this._personBox.Size = new System.Drawing.Size(253, 19);
            this._personBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Expression:";
            // 
            // _expression
            // 
            this._expression.Location = new System.Drawing.Point(96, 38);
            this._expression.Name = "_expression";
            this._expression.Size = new System.Drawing.Size(253, 20);
            this._expression.TabIndex = 3;
            // 
            // _testButton
            // 
            this._testButton.Location = new System.Drawing.Point(355, 36);
            this._testButton.Name = "_testButton";
            this._testButton.Size = new System.Drawing.Size(75, 23);
            this._testButton.TabIndex = 4;
            this._testButton.Text = "Test";
            this._testButton.UseVisualStyleBackColor = true;
            // 
            // ExpressionWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._testButton);
            this.Controls.Add(this._expression);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._personBox);
            this.Controls.Add(this.label1);
            this.Name = "ExpressionWizardPageControl";
            this.Size = new System.Drawing.Size(461, 263);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal Controls.Utils.DropDownTextbox _personBox;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox _expression;
        internal System.Windows.Forms.Button _testButton;
    }
}
