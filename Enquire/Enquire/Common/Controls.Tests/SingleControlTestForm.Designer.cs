﻿namespace Compucare.Enquire.Common.Controls.Tests
{
    partial class SingleControlTestForm
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
            this.singleQuestionSelectorControl1 = new Compucare.Enquire.Common.Controls.DataItems.SingleQuestionSelectorControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // singleQuestionSelectorControl1
            // 
            this.singleQuestionSelectorControl1.Header = "Select Question";
            this.singleQuestionSelectorControl1.Location = new System.Drawing.Point(47, 30);
            this.singleQuestionSelectorControl1.Name = "singleQuestionSelectorControl1";
            this.singleQuestionSelectorControl1.Size = new System.Drawing.Size(424, 49);
            this.singleQuestionSelectorControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(461, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SingleControlTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(594, 248);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.singleQuestionSelectorControl1);
            this.Name = "SingleControlTestForm";
            this.Text = "SingleControlTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DataItems.SingleQuestionSelectorControl singleQuestionSelectorControl1;
        private System.Windows.Forms.Button button1;

    }
}