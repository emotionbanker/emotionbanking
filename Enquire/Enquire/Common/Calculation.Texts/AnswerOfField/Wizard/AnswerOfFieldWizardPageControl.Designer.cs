namespace Compucare.Enquire.Common.Calculation.Texts.Sokd.Wizard
{
    partial class AnswerOfFieldWizardPageControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this._groupBoxSokd = new System.Windows.Forms.GroupBox();
            this._questionSelect = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            this._lb_Frage = new System.Windows.Forms.Label();
            this._personSelect = new Compucare.Enquire.Common.Controls.Utils.DropDownTextbox();
            this._lb_Person = new System.Windows.Forms.Label();
            this._groupBoxSokd.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBoxSokd
            // 
            this._groupBoxSokd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._groupBoxSokd.Controls.Add(this._personSelect);
            this._groupBoxSokd.Controls.Add(this._lb_Person);
            this._groupBoxSokd.Controls.Add(this._questionSelect);
            this._groupBoxSokd.Controls.Add(this._lb_Frage);
            this._groupBoxSokd.Location = new System.Drawing.Point(8, 3);
            this._groupBoxSokd.Name = "_groupBoxSokd";
            this._groupBoxSokd.Size = new System.Drawing.Size(549, 321);
            this._groupBoxSokd.TabIndex = 0;
            this._groupBoxSokd.TabStop = false;
            // 
            // _questionSelect
            // 
            this._questionSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._questionSelect.InitString = "choose question...";
            this._questionSelect.Location = new System.Drawing.Point(27, 96);
            this._questionSelect.Name = "_questionSelect";
            this._questionSelect.Size = new System.Drawing.Size(430, 20);
            this._questionSelect.TabIndex = 28;
            // 
            // _lb_Frage
            // 
            this._lb_Frage.AutoSize = true;
            this._lb_Frage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lb_Frage.Location = new System.Drawing.Point(24, 78);
            this._lb_Frage.Name = "_lb_Frage";
            this._lb_Frage.Size = new System.Drawing.Size(42, 15);
            this._lb_Frage.TabIndex = 1;
            this._lb_Frage.Text = "Frage:";
            // 
            // _personSelect
            // 
            this._personSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._personSelect.InitString = "choose question...";
            this._personSelect.Location = new System.Drawing.Point(27, 161);
            this._personSelect.Name = "_personSelect";
            this._personSelect.Size = new System.Drawing.Size(430, 20);
            this._personSelect.TabIndex = 32;
            // 
            // _lb_Person
            // 
            this._lb_Person.AutoSize = true;
            this._lb_Person.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lb_Person.Location = new System.Drawing.Point(24, 143);
            this._lb_Person.Name = "_lb_Person";
            this._lb_Person.Size = new System.Drawing.Size(102, 15);
            this._lb_Person.TabIndex = 31;
            this._lb_Person.Text = "Personengruppe:";
            // 
            // SokdWizardPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._groupBoxSokd);
            this.Name = "SokdWizardPageControl";
            this.Size = new System.Drawing.Size(560, 327);
            this._groupBoxSokd.ResumeLayout(false);
            this._groupBoxSokd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.GroupBox _groupBoxSokd;
        internal System.Windows.Forms.Label _lb_Frage;
        internal Controls.Utils.DropDownTextbox _questionSelect;
        internal Controls.Utils.DropDownTextbox _personSelect;
        internal System.Windows.Forms.Label _lb_Person;
    }
}
