namespace ArcticDB
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.пробыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddProbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.probListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AvailableCharacteristicsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectsOfInvestigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.администрированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWarningMsgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьМестоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProbeView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProbeView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пробыToolStripMenuItem,
            this.AvailableCharacteristicsToolStripMenuItem1,
            this.ObjectsOfInvestigationToolStripMenuItem,
            this.администрированиеToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ImportDBToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(558, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // пробыToolStripMenuItem
            // 
            this.пробыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddProbeToolStripMenuItem,
            this.probListToolStripMenuItem});
            this.пробыToolStripMenuItem.Name = "пробыToolStripMenuItem";
            this.пробыToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.пробыToolStripMenuItem.Text = "Исследования";
            // 
            // AddProbeToolStripMenuItem
            // 
            this.AddProbeToolStripMenuItem.Name = "AddProbeToolStripMenuItem";
            this.AddProbeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.AddProbeToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.AddProbeToolStripMenuItem.Text = "Добавить исследование";
            this.AddProbeToolStripMenuItem.Click += new System.EventHandler(this.AddProbeToolStripMenuItem_Click);
            // 
            // probListToolStripMenuItem
            // 
            this.probListToolStripMenuItem.Name = "probListToolStripMenuItem";
            this.probListToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.probListToolStripMenuItem.Text = "Список исследований";
            this.probListToolStripMenuItem.Click += new System.EventHandler(this.probListToolStripMenuItem_Click);
            // 
            // AvailableCharacteristicsToolStripMenuItem1
            // 
            this.AvailableCharacteristicsToolStripMenuItem1.Enabled = false;
            this.AvailableCharacteristicsToolStripMenuItem1.Name = "AvailableCharacteristicsToolStripMenuItem1";
            this.AvailableCharacteristicsToolStripMenuItem1.Size = new System.Drawing.Size(107, 20);
            this.AvailableCharacteristicsToolStripMenuItem1.Text = "Характеристики";
            this.AvailableCharacteristicsToolStripMenuItem1.Click += new System.EventHandler(this.AvailableCharacteristicsToolStripMenuItem1_Click);
            // 
            // ObjectsOfInvestigationToolStripMenuItem
            // 
            this.ObjectsOfInvestigationToolStripMenuItem.Enabled = false;
            this.ObjectsOfInvestigationToolStripMenuItem.Name = "ObjectsOfInvestigationToolStripMenuItem";
            this.ObjectsOfInvestigationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.ObjectsOfInvestigationToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ObjectsOfInvestigationToolStripMenuItem.Text = "Обьекты";
            this.ObjectsOfInvestigationToolStripMenuItem.Click += new System.EventHandler(this.ObjectsOfInvestigationToolStripMenuItem_Click);
            // 
            // администрированиеToolStripMenuItem
            // 
            this.администрированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.changeWarningMsgToolStripMenuItem,
            this.очиститьМестоToolStripMenuItem,
            this.ExportToolStripMenuItem});
            this.администрированиеToolStripMenuItem.Name = "администрированиеToolStripMenuItem";
            this.администрированиеToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.администрированиеToolStripMenuItem.Text = "Администрирование";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.changePasswordToolStripMenuItem.Text = "Сменить пароль";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // changeWarningMsgToolStripMenuItem
            // 
            this.changeWarningMsgToolStripMenuItem.Name = "changeWarningMsgToolStripMenuItem";
            this.changeWarningMsgToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.changeWarningMsgToolStripMenuItem.Text = "Задать информационное сообщение";
            this.changeWarningMsgToolStripMenuItem.Click += new System.EventHandler(this.changeWarningMsgToolStripMenuItem_Click);
            // 
            // очиститьМестоToolStripMenuItem
            // 
            this.очиститьМестоToolStripMenuItem.Name = "очиститьМестоToolStripMenuItem";
            this.очиститьМестоToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.очиститьМестоToolStripMenuItem.Text = "Очистить место";
            this.очиститьМестоToolStripMenuItem.Click += new System.EventHandler(this.cleanSpaceToolStripMenuItem_Click);
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.ExportToolStripMenuItem.Text = "Выгрузить БД";
            this.ExportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 20);
            // 
            // ImportDBToolStripMenuItem
            // 
            this.ImportDBToolStripMenuItem.Name = "ImportDBToolStripMenuItem";
            this.ImportDBToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.ImportDBToolStripMenuItem.Text = "Загрузить БД";
            this.ImportDBToolStripMenuItem.Click += new System.EventHandler(this.ImportDBToolStripMenuItem_Click);
            // 
            // ProbeView
            // 
            this.ProbeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProbeView.Location = new System.Drawing.Point(0, 27);
            this.ProbeView.Name = "ProbeView";
            this.ProbeView.Size = new System.Drawing.Size(558, 292);
            this.ProbeView.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 320);
            this.Controls.Add(this.ProbeView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Арктика";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProbeView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem пробыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ObjectsOfInvestigationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddProbeToolStripMenuItem;
        private System.Windows.Forms.DataGridView ProbeView;
        private System.Windows.Forms.ToolStripMenuItem AvailableCharacteristicsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem probListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem администрированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeWarningMsgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьМестоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ImportDBToolStripMenuItem;
    }
}

