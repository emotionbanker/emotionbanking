using compucare.Enquire.Legacy.Umfrage2Lib.Output;

namespace Compucare.Enquire.Legacy.UMXAddin3.ControlForms
{
    partial class OutputSelect
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReportList = new umfrage2._2008.Tools.ListViewEx();
            this.OutputListView = new umfrage2._2008.Tools.ListViewEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OSel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReportList
            // 
            this.ReportList.AllowDrop = true;
            this.ReportList.AllowRowReorder = true;
            this.ReportList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportList.Location = new System.Drawing.Point(8, 30);
            this.ReportList.MultiSelect = false;
            this.ReportList.Name = "ReportList";
            this.ReportList.SelectedItem = null;
            this.ReportList.Size = new System.Drawing.Size(162, 398);
            this.ReportList.Sorting = SortOrder.None;
            this.ReportList.TabIndex = 31;
            this.ReportList.UseCompatibleStateImageBehavior = false;
            this.ReportList.View = System.Windows.Forms.View.List;
            this.ReportList.SelectedIndexChanged += new System.EventHandler(this.ReportList_SelectedIndexChanged);
            // 
            // OutputListView
            // 
            this.OutputListView.AllowDrop = true;
            this.OutputListView.AllowRowReorder = true;
            this.OutputListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputListView.Location = new System.Drawing.Point(176, 30);
            this.OutputListView.MultiSelect = false;
            this.OutputListView.Name = "OutputListView";
            this.OutputListView.SelectedItem = null;
            this.OutputListView.Size = new System.Drawing.Size(183, 398);
            this.OutputListView.Sorting = SortOrder.None;
            this.OutputListView.TabIndex = 32;
            this.OutputListView.UseCompatibleStateImageBehavior = false;
            this.OutputListView.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Berichte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Auswertungen";
            // 
            // OSel
            // 
            this.OSel.Location = new System.Drawing.Point(176, 434);
            this.OSel.Name = "OSel";
            this.OSel.Size = new System.Drawing.Size(183, 28);
            this.OSel.TabIndex = 35;
            this.OSel.Text = "Auswahl einfügen";
            this.OSel.UseVisualStyleBackColor = true;
            this.OSel.Click += new System.EventHandler(this.OSel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 28);
            this.button1.TabIndex = 36;
            this.button1.Text = "Abbrechen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OutputSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 474);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OSel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputListView);
            this.Controls.Add(this.ReportList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OutputSelect";
            this.ShowInTaskbar = false;
            this.Text = "Auswertung auswählen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private umfrage2._2008.Tools.ListViewEx ReportList;
        private umfrage2._2008.Tools.ListViewEx OutputListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OSel;
        private System.Windows.Forms.Button button1;
    }
}