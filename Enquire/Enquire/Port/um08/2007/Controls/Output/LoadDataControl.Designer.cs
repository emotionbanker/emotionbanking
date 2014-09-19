using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;

namespace umfrage2._2007.Controls
{
    partial class LoadDataControl
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
            this.elaps = new System.Windows.Forms.Label();
            this.TimeElapsedLabel = new System.Windows.Forms.Label();
            this.TimeRemainingLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ControlButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectTargetPanel = new System.Windows.Forms.Panel();
            this.ChooseTarget = new System.Windows.Forms.CheckedListBox();
            this.LocalStatus = new System.Windows.Forms.ProgressBar();
            this.GlobalStatus = new System.Windows.Forms.ProgressBar();
            this._selectAllButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._selectABButton = new System.Windows.Forms.Button();
            this.checkBoxDate = new System.Windows.Forms.CheckBox();
            this.groupBoxDate = new System.Windows.Forms.GroupBox();
            this.monthCalendarBis = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarVon = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SelectTargetPanel.SuspendLayout();
            this.groupBoxDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // elaps
            // 
            this.elaps.Location = new System.Drawing.Point(236, 347);
            this.elaps.Name = "elaps";
            this.elaps.Size = new System.Drawing.Size(136, 24);
            this.elaps.TabIndex = 27;
            this.elaps.Text = "Verstrichene Zeit:";
            this.elaps.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TimeElapsedLabel
            // 
            this.TimeElapsedLabel.Location = new System.Drawing.Point(380, 347);
            this.TimeElapsedLabel.Name = "TimeElapsedLabel";
            this.TimeElapsedLabel.Size = new System.Drawing.Size(208, 23);
            this.TimeElapsedLabel.TabIndex = 26;
            // 
            // TimeRemainingLabel
            // 
            this.TimeRemainingLabel.Location = new System.Drawing.Point(380, 323);
            this.TimeRemainingLabel.Name = "TimeRemainingLabel";
            this.TimeRemainingLabel.Size = new System.Drawing.Size(208, 23);
            this.TimeRemainingLabel.TabIndex = 24;
            this.TimeRemainingLabel.Text = "unbekannt";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(236, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 23;
            this.label3.Text = "Verbleibende Zeit:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ControlButton
            // 
            this.ControlButton.BackColor = System.Drawing.Color.White;
            this.ControlButton.Enabled = false;
            this.ControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ControlButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00e7_0409;
            this.ControlButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ControlButton.Location = new System.Drawing.Point(27, 323);
            this.ControlButton.Name = "ControlButton";
            this.ControlButton.Size = new System.Drawing.Size(203, 36);
            this.ControlButton.TabIndex = 19;
            this.ControlButton.Text = "      Start";
            this.ControlButton.UseVisualStyleBackColor = false;
            this.ControlButton.Click += new System.EventHandler(this.ControlButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(88, 13);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(528, 23);
            this.StatusLabel.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Status:";
            // 
            // SelectTargetPanel
            // 
            this.SelectTargetPanel.Controls.Add(this.ChooseTarget);
            this.SelectTargetPanel.Location = new System.Drawing.Point(27, 43);
            this.SelectTargetPanel.Name = "SelectTargetPanel";
            this.SelectTargetPanel.Size = new System.Drawing.Size(560, 183);
            this.SelectTargetPanel.TabIndex = 30;
            // 
            // ChooseTarget
            // 
            this.ChooseTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChooseTarget.CheckOnClick = true;
            this.ChooseTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseTarget.FormattingEnabled = true;
            this.ChooseTarget.Location = new System.Drawing.Point(0, 0);
            this.ChooseTarget.Name = "ChooseTarget";
            this.ChooseTarget.Size = new System.Drawing.Size(560, 183);
            this.ChooseTarget.Sorted = true;
            this.ChooseTarget.TabIndex = 0;
            // 
            // LocalStatus
            // 
            this.LocalStatus.Location = new System.Drawing.Point(27, 232);
            this.LocalStatus.Name = "LocalStatus";
            this.LocalStatus.Size = new System.Drawing.Size(560, 28);
            this.LocalStatus.TabIndex = 31;
            // 
            // GlobalStatus
            // 
            this.GlobalStatus.Location = new System.Drawing.Point(27, 266);
            this.GlobalStatus.Name = "GlobalStatus";
            this.GlobalStatus.Size = new System.Drawing.Size(560, 28);
            this.GlobalStatus.TabIndex = 32;
            // 
            // _selectAllButton
            // 
            this._selectAllButton.BackColor = System.Drawing.Color.White;
            this._selectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._selectAllButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._selectAllButton.Location = new System.Drawing.Point(597, 103);
            this._selectAllButton.Name = "_selectAllButton";
            this._selectAllButton.Size = new System.Drawing.Size(112, 26);
            this._selectAllButton.TabIndex = 33;
            this._selectAllButton.Text = "alle auswählen";
            this._selectAllButton.UseVisualStyleBackColor = false;
            this._selectAllButton.Click += new System.EventHandler(this._selectAllButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(597, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 34;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(594, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Suche:";
            // 
            // _selectABButton
            // 
            this._selectABButton.BackColor = System.Drawing.Color.White;
            this._selectABButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._selectABButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._selectABButton.Location = new System.Drawing.Point(597, 135);
            this._selectABButton.Name = "_selectABButton";
            this._selectABButton.Size = new System.Drawing.Size(112, 26);
            this._selectABButton.TabIndex = 36;
            this._selectABButton.Text = "alle abwählen";
            this._selectABButton.UseVisualStyleBackColor = false;
            this._selectABButton.Click += new System.EventHandler(this._selectABButton_Click);
            // 
            // checkBoxDate
            // 
            this.checkBoxDate.AutoSize = true;
            this.checkBoxDate.Location = new System.Drawing.Point(597, 189);
            this.checkBoxDate.Name = "checkBoxDate";
            this.checkBoxDate.Size = new System.Drawing.Size(94, 17);
            this.checkBoxDate.TabIndex = 37;
            this.checkBoxDate.Text = "Datum - Filter ";
            this.checkBoxDate.UseVisualStyleBackColor = true;
            this.checkBoxDate.CheckedChanged += new System.EventHandler(this.checkBoxDate_CheckedChanged);
            // 
            // groupBoxDate
            // 
            this.groupBoxDate.Controls.Add(this.monthCalendarBis);
            this.groupBoxDate.Controls.Add(this.monthCalendarVon);
            this.groupBoxDate.Location = new System.Drawing.Point(597, 210);
            this.groupBoxDate.Name = "groupBoxDate";
            this.groupBoxDate.Size = new System.Drawing.Size(389, 183);
            this.groupBoxDate.TabIndex = 38;
            this.groupBoxDate.TabStop = false;
            this.groupBoxDate.Visible = false;
            // 
            // monthCalendarBis
            // 
            this.monthCalendarBis.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.monthCalendarBis.Location = new System.Drawing.Point(198, 8);
            this.monthCalendarBis.Name = "monthCalendarBis";
            this.monthCalendarBis.ShowToday = false;
            this.monthCalendarBis.TabIndex = 1;
            this.monthCalendarBis.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarBis_DateChanged);
            // 
            // monthCalendarVon
            // 
            this.monthCalendarVon.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.monthCalendarVon.Location = new System.Drawing.Point(12, 8);
            this.monthCalendarVon.Name = "monthCalendarVon";
            this.monthCalendarVon.ShowToday = false;
            this.monthCalendarVon.TabIndex = 0;
            this.monthCalendarVon.TodayDate = new System.DateTime(2014, 6, 4, 0, 0, 0, 0);
            this.monthCalendarVon.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarVon_DateChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Ergebnisse zwischen";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(708, 406);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(771, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "und";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(792, 406);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(857, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "laden.";
            this.label8.Visible = false;
            // 
            // LoadDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBoxDate);
            this.Controls.Add(this.checkBoxDate);
            this.Controls.Add(this._selectABButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this._selectAllButton);
            this.Controls.Add(this.GlobalStatus);
            this.Controls.Add(this.LocalStatus);
            this.Controls.Add(this.SelectTargetPanel);
            this.Controls.Add(this.elaps);
            this.Controls.Add(this.TimeElapsedLabel);
            this.Controls.Add(this.TimeRemainingLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ControlButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "LoadDataControl";
            this.Size = new System.Drawing.Size(989, 485);
            this.SelectTargetPanel.ResumeLayout(false);
            this.groupBoxDate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label elaps;
        public System.Windows.Forms.Label TimeElapsedLabel;
        public System.Windows.Forms.Label TimeRemainingLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel SelectTargetPanel;
        public System.Windows.Forms.CheckedListBox ChooseTarget;
        public System.Windows.Forms.Button ControlButton;
        public System.Windows.Forms.ProgressBar LocalStatus;
        public System.Windows.Forms.ProgressBar GlobalStatus;
        public System.Windows.Forms.Button _selectAllButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button _selectABButton;
        private System.Windows.Forms.CheckBox checkBoxDate;
        private System.Windows.Forms.GroupBox groupBoxDate;
        private System.Windows.Forms.MonthCalendar monthCalendarBis;
        private System.Windows.Forms.MonthCalendar monthCalendarVon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
