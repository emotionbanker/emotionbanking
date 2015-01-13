using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Compucare.Enquire.Legacy.Umfrage2Lib.Properties;


namespace Compucare.Enquire.Legacy.Umfrage2Lib
{
    partial class MainForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.schliessenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auswertungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.datenLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.einzelauswertungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.berichteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.benchmarkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textantwortenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antwortnummernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.fragenlisteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelDateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
            this.cSVExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anonymisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.metadatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ausfülldauerSplitHalfReliabilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antwortverteilungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMultipartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMultipartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.resultStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.user117ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.placeholdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NewButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveDataButton = new System.Windows.Forms.ToolStripButton();
            this.LoadDataButton = new System.Windows.Forms.ToolStripButton();
            this.SettingsButton = new System.Windows.Forms.ToolStripButton();
            this.SingleOutputButton = new System.Windows.Forms.ToolStripButton();
            this.ReportButton = new System.Windows.Forms.ToolStripButton();
            this.BenchmarkingButton = new System.Windows.Forms.ToolStripButton();
            this.ScoringButton = new System.Windows.Forms.ToolStripButton();
            this.HelpButton = new System.Windows.Forms.ToolStripButton();
            this.TitleLabel = new System.Windows.Forms.ToolStripLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveXlsDialog = new System.Windows.Forms.SaveFileDialog();
            this.openXlsDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveMultipartDialog = new System.Windows.Forms.SaveFileDialog();
            this.openMultipartDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(155)))), ((int)(((byte)(183)))), ((int)(((byte)(214)))));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.auswertungToolStripMenuItem,
            this.exportImportToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.hilfeToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.MainMenu.Name = "MainMenu";
            // 
            // dateiToolStripMenuItem
            // 
            resources.ApplyResources(this.dateiToolStripMenuItem, "dateiToolStripMenuItem");
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nToolStripMenuItem,
            this.toolStripMenuItem4,
            this.öffnenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.speichernUnterToolStripMenuItem,
            this.toolStripMenuItem1,
            this.schliessenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Click += new System.EventHandler(this.dateiToolStripMenuItem_Click);
            // 
            // nToolStripMenuItem
            // 
            resources.ApplyResources(this.nToolStripMenuItem, "nToolStripMenuItem");
            this.nToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I002c_0409;
            this.nToolStripMenuItem.Name = "nToolStripMenuItem";
            this.nToolStripMenuItem.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // toolStripMenuItem4
            // 
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            // 
            // öffnenToolStripMenuItem
            // 
            resources.ApplyResources(this.öffnenToolStripMenuItem, "öffnenToolStripMenuItem");
            this.öffnenToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0005_0409;
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.openMultipartToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            resources.ApplyResources(this.speichernToolStripMenuItem, "speichernToolStripMenuItem");
            this.speichernToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I4179_0409;
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // speichernUnterToolStripMenuItem
            // 
            resources.ApplyResources(this.speichernUnterToolStripMenuItem, "speichernUnterToolStripMenuItem");
            this.speichernUnterToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I4179_0409;
            this.speichernUnterToolStripMenuItem.Name = "speichernUnterToolStripMenuItem";
            this.speichernUnterToolStripMenuItem.Click += new System.EventHandler(this.saveMultipartToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // schliessenToolStripMenuItem
            // 
            resources.ApplyResources(this.schliessenToolStripMenuItem, "schliessenToolStripMenuItem");
            this.schliessenToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.schliessenToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I001c_0409;
            this.schliessenToolStripMenuItem.Name = "schliessenToolStripMenuItem";
            this.schliessenToolStripMenuItem.Click += new System.EventHandler(this.schliessenToolStripMenuItem_Click);
            // 
            // auswertungToolStripMenuItem
            // 
            resources.ApplyResources(this.auswertungToolStripMenuItem, "auswertungToolStripMenuItem");
            this.auswertungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem,
            this.toolStripMenuItem5,
            this.datenLadenToolStripMenuItem,
            this.toolStripMenuItem2,
            this.einzelauswertungToolStripMenuItem,
            this.berichteToolStripMenuItem,
            this.toolStripMenuItem3,
            this.benchmarkingToolStripMenuItem,
            this.scoringToolStripMenuItem});
            this.auswertungToolStripMenuItem.Name = "auswertungToolStripMenuItem";
            // 
            // einstellungenToolStripMenuItem
            // 
            resources.ApplyResources(this.einstellungenToolStripMenuItem, "einstellungenToolStripMenuItem");
            this.einstellungenToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell321;
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // toolStripMenuItem5
            // 
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            // 
            // datenLadenToolStripMenuItem
            // 
            resources.ApplyResources(this.datenLadenToolStripMenuItem, "datenLadenToolStripMenuItem");
            this.datenLadenToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00e7_0409;
            this.datenLadenToolStripMenuItem.Name = "datenLadenToolStripMenuItem";
            this.datenLadenToolStripMenuItem.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // einzelauswertungToolStripMenuItem
            // 
            resources.ApplyResources(this.einzelauswertungToolStripMenuItem, "einzelauswertungToolStripMenuItem");
            this.einzelauswertungToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0113_0409;
            this.einzelauswertungToolStripMenuItem.Name = "einzelauswertungToolStripMenuItem";
            this.einzelauswertungToolStripMenuItem.Click += new System.EventHandler(this.SingleOutputButton_Click);
            // 
            // berichteToolStripMenuItem
            // 
            resources.ApplyResources(this.berichteToolStripMenuItem, "berichteToolStripMenuItem");
            this.berichteToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0112_0409;
            this.berichteToolStripMenuItem.Name = "berichteToolStripMenuItem";
            this.berichteToolStripMenuItem.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // toolStripMenuItem3
            // 
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            // 
            // benchmarkingToolStripMenuItem
            // 
            resources.ApplyResources(this.benchmarkingToolStripMenuItem, "benchmarkingToolStripMenuItem");
            this.benchmarkingToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00a7_0409;
            this.benchmarkingToolStripMenuItem.Name = "benchmarkingToolStripMenuItem";
            this.benchmarkingToolStripMenuItem.Click += new System.EventHandler(this.BenchmarkingButton_Click);
            // 
            // scoringToolStripMenuItem
            // 
            resources.ApplyResources(this.scoringToolStripMenuItem, "scoringToolStripMenuItem");
            this.scoringToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I4170_0409;
            this.scoringToolStripMenuItem.Name = "scoringToolStripMenuItem";
            this.scoringToolStripMenuItem.Click += new System.EventHandler(this.ScoringButton_Click);
            // 
            // exportImportToolStripMenuItem
            // 
            resources.ApplyResources(this.exportImportToolStripMenuItem, "exportImportToolStripMenuItem");
            this.exportImportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ladenToolStripMenuItem,
            this.toolStripMenuItem7,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripMenuItem14,
            this.cSVExportToolStripMenuItem});
            this.exportImportToolStripMenuItem.Name = "exportImportToolStripMenuItem";
            // 
            // ladenToolStripMenuItem
            // 
            resources.ApplyResources(this.ladenToolStripMenuItem, "ladenToolStripMenuItem");
            this.ladenToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00e7_0409;
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // toolStripMenuItem7
            // 
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            // 
            // exportToolStripMenuItem
            // 
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textantwortenToolStripMenuItem,
            this.antwortnummernToolStripMenuItem,
            this.toolStripMenuItem6,
            this.fragenlisteToolStripMenuItem});
            this.exportToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I416d_0409;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            // 
            // textantwortenToolStripMenuItem
            // 
            resources.ApplyResources(this.textantwortenToolStripMenuItem, "textantwortenToolStripMenuItem");
            this.textantwortenToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.excel;
            this.textantwortenToolStripMenuItem.Name = "textantwortenToolStripMenuItem";
            this.textantwortenToolStripMenuItem.Click += new System.EventHandler(this.textantwortenToolStripMenuItem_Click);
            // 
            // antwortnummernToolStripMenuItem
            // 
            resources.ApplyResources(this.antwortnummernToolStripMenuItem, "antwortnummernToolStripMenuItem");
            this.antwortnummernToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.excel;
            this.antwortnummernToolStripMenuItem.Name = "antwortnummernToolStripMenuItem";
            this.antwortnummernToolStripMenuItem.Click += new System.EventHandler(this.antwortnummernToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            // 
            // fragenlisteToolStripMenuItem
            // 
            resources.ApplyResources(this.fragenlisteToolStripMenuItem, "fragenlisteToolStripMenuItem");
            this.fragenlisteToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.excel;
            this.fragenlisteToolStripMenuItem.Name = "fragenlisteToolStripMenuItem";
            this.fragenlisteToolStripMenuItem.Click += new System.EventHandler(this.fragenlisteToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelDateiToolStripMenuItem,
            this.ordnerToolStripMenuItem});
            this.importToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I416e_0409;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            // 
            // excelDateiToolStripMenuItem
            // 
            resources.ApplyResources(this.excelDateiToolStripMenuItem, "excelDateiToolStripMenuItem");
            this.excelDateiToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.excel;
            this.excelDateiToolStripMenuItem.Name = "excelDateiToolStripMenuItem";
            this.excelDateiToolStripMenuItem.Click += new System.EventHandler(this.excelDateiToolStripMenuItem_Click);
            // 
            // ordnerToolStripMenuItem
            // 
            resources.ApplyResources(this.ordnerToolStripMenuItem, "ordnerToolStripMenuItem");
            this.ordnerToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0005_0409;
            this.ordnerToolStripMenuItem.Name = "ordnerToolStripMenuItem";
            this.ordnerToolStripMenuItem.Click += new System.EventHandler(this.ordnerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem14
            // 
            resources.ApplyResources(this.toolStripMenuItem14, "toolStripMenuItem14");
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            // 
            // cSVExportToolStripMenuItem
            // 
            resources.ApplyResources(this.cSVExportToolStripMenuItem, "cSVExportToolStripMenuItem");
            this.cSVExportToolStripMenuItem.Name = "cSVExportToolStripMenuItem";
            this.cSVExportToolStripMenuItem.Click += new System.EventHandler(this.cSVExportToolStripMenuItem_Click);
            // 
            // extrasToolStripMenuItem
            // 
            resources.ApplyResources(this.extrasToolStripMenuItem, "extrasToolStripMenuItem");
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anonymisToolStripMenuItem,
            this.toolStripMenuItem9,
            this.metadatenToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            // 
            // anonymisToolStripMenuItem
            // 
            resources.ApplyResources(this.anonymisToolStripMenuItem, "anonymisToolStripMenuItem");
            this.anonymisToolStripMenuItem.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I416b_0409;
            this.anonymisToolStripMenuItem.Name = "anonymisToolStripMenuItem";
            this.anonymisToolStripMenuItem.Click += new System.EventHandler(this.anonymisToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            // 
            // metadatenToolStripMenuItem
            // 
            resources.ApplyResources(this.metadatenToolStripMenuItem, "metadatenToolStripMenuItem");
            this.metadatenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ausfülldauerSplitHalfReliabilityToolStripMenuItem,
            this.antwortverteilungToolStripMenuItem});
            this.metadatenToolStripMenuItem.Name = "metadatenToolStripMenuItem";
            // 
            // ausfьlldauerSplitHalfReliabilityToolStripMenuItem
            // 
            resources.ApplyResources(this.ausfülldauerSplitHalfReliabilityToolStripMenuItem, "ausfьlldauerSplitHalfReliabilityToolStripMenuItem");
            this.ausfülldauerSplitHalfReliabilityToolStripMenuItem.Name = "ausfьlldauerSplitHalfReliabilityToolStripMenuItem";
            this.ausfülldauerSplitHalfReliabilityToolStripMenuItem.Click += new System.EventHandler(this.ausfülldauerSplitHalfReliabilityToolStripMenuItem_Click);
            // 
            // antwortverteilungToolStripMenuItem
            // 
            resources.ApplyResources(this.antwortverteilungToolStripMenuItem, "antwortverteilungToolStripMenuItem");
            this.antwortverteilungToolStripMenuItem.Name = "antwortverteilungToolStripMenuItem";
            this.antwortverteilungToolStripMenuItem.Click += new System.EventHandler(this.antwortverteilungToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            resources.ApplyResources(this.hilfeToolStripMenuItem, "hilfeToolStripMenuItem");
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hilfeToolStripMenuItem1});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            // 
            // hilfeToolStripMenuItem1
            // 
            resources.ApplyResources(this.hilfeToolStripMenuItem1, "hilfeToolStripMenuItem1");
            this.hilfeToolStripMenuItem1.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0144_0409;
            this.hilfeToolStripMenuItem1.Name = "hilfeToolStripMenuItem1";
            this.hilfeToolStripMenuItem1.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // debugToolStripMenuItem
            // 
            resources.ApplyResources(this.debugToolStripMenuItem, "debugToolStripMenuItem");
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMultipartToolStripMenuItem,
            this.openMultipartToolStripMenuItem,
            this.toolStripMenuItem8,
            this.resultStatsToolStripMenuItem,
            this.toolStripMenuItem10,
            this.user117ToolStripMenuItem,
            this.toolStripMenuItem11,
            this.toolStripMenuItem13,
            this.toolStripMenuItem12,
            this.placeholdersToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            // 
            // saveMultipartToolStripMenuItem
            // 
            resources.ApplyResources(this.saveMultipartToolStripMenuItem, "saveMultipartToolStripMenuItem");
            this.saveMultipartToolStripMenuItem.Name = "saveMultipartToolStripMenuItem";
            this.saveMultipartToolStripMenuItem.Click += new System.EventHandler(this.saveMultipartToolStripMenuItem_Click);
            // 
            // openMultipartToolStripMenuItem
            // 
            resources.ApplyResources(this.openMultipartToolStripMenuItem, "openMultipartToolStripMenuItem");
            this.openMultipartToolStripMenuItem.Name = "openMultipartToolStripMenuItem";
            this.openMultipartToolStripMenuItem.Click += new System.EventHandler(this.openMultipartToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            // 
            // resultStatsToolStripMenuItem
            // 
            resources.ApplyResources(this.resultStatsToolStripMenuItem, "resultStatsToolStripMenuItem");
            this.resultStatsToolStripMenuItem.Name = "resultStatsToolStripMenuItem";
            this.resultStatsToolStripMenuItem.Click += new System.EventHandler(this.resultStatsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // user117ToolStripMenuItem
            // 
            resources.ApplyResources(this.user117ToolStripMenuItem, "user117ToolStripMenuItem");
            this.user117ToolStripMenuItem.Name = "user117ToolStripMenuItem";
            this.user117ToolStripMenuItem.Click += new System.EventHandler(this.user117ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            // 
            // toolStripMenuItem13
            // 
            resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem12
            // 
            resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            // 
            // placeholdersToolStripMenuItem
            // 
            resources.ApplyResources(this.placeholdersToolStripMenuItem, "placeholdersToolStripMenuItem");
            this.placeholdersToolStripMenuItem.Name = "placeholdersToolStripMenuItem";
            this.placeholdersToolStripMenuItem.Click += new System.EventHandler(this.placeholdersToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(155)))), ((int)(((byte)(183)))), ((int)(((byte)(214)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewButton,
            this.SaveButton,
            this.OpenButton,
            this.RemoveDataButton,
            this.LoadDataButton,
            this.SettingsButton,
            this.SingleOutputButton,
            this.ReportButton,
            this.BenchmarkingButton,
            this.ScoringButton,
            this.HelpButton,
            this.TitleLabel});
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.SizeChanged += new System.EventHandler(this.toolStrip1_SizeChanged);
            this.toolStrip1.Resize += new System.EventHandler(this.toolStrip1_Resize);
            // 
            // NewButton
            // 
            resources.ApplyResources(this.NewButton, "NewButton");
            this.NewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I002c_0409;
            this.NewButton.Name = "NewButton";
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OpenButton
            // 
            resources.ApplyResources(this.OpenButton, "OpenButton");
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0005_0409;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Click += new System.EventHandler(this.openMultipartToolStripMenuItem_Click);
            // 
            // RemoveDataButton
            // 
            resources.ApplyResources(this.RemoveDataButton, "RemoveDataButton");
            this.RemoveDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveDataButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00f0_0409;
            this.RemoveDataButton.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.RemoveDataButton.Name = "RemoveDataButton";
            this.RemoveDataButton.Click += new System.EventHandler(this.RemoveDataButton_Click);
            // 
            // LoadDataButton
            // 
            resources.ApplyResources(this.LoadDataButton, "LoadDataButton");
            this.LoadDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadDataButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00e7_0409;
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // SettingsButton
            // 
            resources.ApplyResources(this.SettingsButton, "SettingsButton");
            this.SettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell321;
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // SingleOutputButton
            // 
            resources.ApplyResources(this.SingleOutputButton, "SingleOutputButton");
            this.SingleOutputButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SingleOutputButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0113_0409;
            this.SingleOutputButton.Name = "SingleOutputButton";
            this.SingleOutputButton.Click += new System.EventHandler(this.SingleOutputButton_Click);
            // 
            // ReportButton
            // 
            resources.ApplyResources(this.ReportButton, "ReportButton");
            this.ReportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReportButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0112_0409;
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // BenchmarkingButton
            // 
            resources.ApplyResources(this.BenchmarkingButton, "BenchmarkingButton");
            this.BenchmarkingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BenchmarkingButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I00a7_0409;
            this.BenchmarkingButton.Name = "BenchmarkingButton";
            this.BenchmarkingButton.Click += new System.EventHandler(this.BenchmarkingButton_Click);
            // 
            // ScoringButton
            // 
            resources.ApplyResources(this.ScoringButton, "ScoringButton");
            this.ScoringButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ScoringButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I4170_0409;
            this.ScoringButton.Name = "ScoringButton";
            this.ScoringButton.Click += new System.EventHandler(this.ScoringButton_Click);
            // 
            // HelpButton
            // 
            resources.ApplyResources(this.HelpButton, "HelpButton");
            this.HelpButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HelpButton.Image = global::Compucare.Enquire.Legacy.Umfrage2Lib.Properties.Resources.shell32_dll_I0144_0409;
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // TitleLabel
            // 
            resources.ApplyResources(this.TitleLabel, "TitleLabel");
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(30, 1, 0, 2);
            this.TitleLabel.Name = "TitleLabel";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "um2";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ContentPanel_Paint);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "um2";
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // saveXlsDialog
            // 
            this.saveXlsDialog.DefaultExt = "xlsx";
            resources.ApplyResources(this.saveXlsDialog, "saveXlsDialog");
            // 
            // openXlsDialog
            // 
            this.openXlsDialog.DefaultExt = "xlsx";
            resources.ApplyResources(this.openXlsDialog, "openXlsDialog");
            // 
            // saveMultipartDialog
            // 
            this.saveMultipartDialog.DefaultExt = "um3";
            resources.ApplyResources(this.saveMultipartDialog, "saveMultipartDialog");
            // 
            // openMultipartDialog
            // 
            this.openMultipartDialog.DefaultExt = "um3";
            resources.ApplyResources(this.openMultipartDialog, "openMultipartDialog");
            this.openMultipartDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MainMenu;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem schliessenToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton SettingsButton;
        private ToolStripButton SaveButton;
        private ToolStripButton OpenButton;
        private ToolStripButton SingleOutputButton;
        private ToolStripButton ReportButton;
        private ToolStripButton BenchmarkingButton;
        private ToolStripButton ScoringButton;
        private ToolStripButton HelpButton;
        private ToolStripMenuItem öffnenToolStripMenuItem;
        private ToolStripMenuItem speichernToolStripMenuItem;
        private ToolStripMenuItem auswertungToolStripMenuItem;
        private ToolStripMenuItem einstellungenToolStripMenuItem;
        private ToolStripMenuItem einzelauswertungToolStripMenuItem;
        private ToolStripMenuItem berichteToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem benchmarkingToolStripMenuItem;
        private ToolStripMenuItem scoringToolStripMenuItem;
        private ToolStripMenuItem hilfeToolStripMenuItem;
        private ToolStripMenuItem hilfeToolStripMenuItem1;
        private ToolStripButton NewButton;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem nToolStripMenuItem;
        private ToolStripLabel TitleLabel;
        private OpenFileDialog openFileDialog1;
        private Panel ContentPanel;
        private ToolStripButton LoadDataButton;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem datenLadenToolStripMenuItem;
        private ToolStripMenuItem speichernUnterToolStripMenuItem;
        private SaveFileDialog saveFileDialog;
        private ToolStripMenuItem extrasToolStripMenuItem;
        private ToolStripMenuItem anonymisToolStripMenuItem;
        private ToolStripMenuItem exportImportToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem excelDateiToolStripMenuItem;
        private ToolStripMenuItem ordnerToolStripMenuItem;
        private ToolStripMenuItem textantwortenToolStripMenuItem;
        private ToolStripMenuItem antwortnummernToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem fragenlisteToolStripMenuItem;
        private OpenFileDialog openXlsDialog;
        private ToolStripMenuItem ladenToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem debugToolStripMenuItem;
        private ToolStripMenuItem saveMultipartToolStripMenuItem;
        private SaveFileDialog saveMultipartDialog;
        private OpenFileDialog openMultipartDialog;
        private ToolStripMenuItem openMultipartToolStripMenuItem;
        private ToolStripButton RemoveDataButton;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem resultStatsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem user117ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripMenuItem metadatenToolStripMenuItem;
        private ToolStripMenuItem ausfülldauerSplitHalfReliabilityToolStripMenuItem;
        private ToolStripMenuItem antwortverteilungToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripSeparator toolStripMenuItem12;
        private ToolStripMenuItem placeholdersToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem14;
        private ToolStripMenuItem cSVExportToolStripMenuItem;
        public SaveFileDialog saveXlsDialog;
    }
}

