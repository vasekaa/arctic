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
            this.ObjectsOfInvestigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.доступныеХарактеристикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AvailableCharacteristicsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProbeView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProbeView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пробыToolStripMenuItem,
            this.ObjectsOfInvestigationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.AvailableCharacteristicsToolStripMenuItem1,
            this.ExportToolStripMenuItem,
            this.PrintToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(523, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // пробыToolStripMenuItem
            // 
            this.пробыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddProbeToolStripMenuItem});
            this.пробыToolStripMenuItem.Name = "пробыToolStripMenuItem";
            this.пробыToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.пробыToolStripMenuItem.Text = "Пробы";
            // 
            // AddProbeToolStripMenuItem
            // 
            this.AddProbeToolStripMenuItem.Name = "AddProbeToolStripMenuItem";
            this.AddProbeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.AddProbeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.AddProbeToolStripMenuItem.Text = "Добавить пробу";
            this.AddProbeToolStripMenuItem.Click += new System.EventHandler(this.AddProbeToolStripMenuItem_Click);
            // 
            // ObjectsOfInvestigationToolStripMenuItem
            // 
            this.ObjectsOfInvestigationToolStripMenuItem.Name = "ObjectsOfInvestigationToolStripMenuItem";
            this.ObjectsOfInvestigationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.ObjectsOfInvestigationToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.ObjectsOfInvestigationToolStripMenuItem.Text = "Обьекты исследования";
            this.ObjectsOfInvestigationToolStripMenuItem.Click += new System.EventHandler(this.ObjectsOfInvestigationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.доступныеХарактеристикиToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // доступныеХарактеристикиToolStripMenuItem
            // 
            this.доступныеХарактеристикиToolStripMenuItem.Name = "доступныеХарактеристикиToolStripMenuItem";
            this.доступныеХарактеристикиToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.доступныеХарактеристикиToolStripMenuItem.Text = "Доступные Характеристики";
            // 
            // AvailableCharacteristicsToolStripMenuItem1
            // 
            this.AvailableCharacteristicsToolStripMenuItem1.Name = "AvailableCharacteristicsToolStripMenuItem1";
            this.AvailableCharacteristicsToolStripMenuItem1.Size = new System.Drawing.Size(171, 20);
            this.AvailableCharacteristicsToolStripMenuItem1.Text = "Доступные Характеристики";
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.ExportToolStripMenuItem.Text = "Экспорт";
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.PrintToolStripMenuItem.Text = "Печать";
            // 
            // ProbeView
            // 
            this.ProbeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProbeView.Location = new System.Drawing.Point(0, 27);
            this.ProbeView.Name = "ProbeView";
            this.ProbeView.Size = new System.Drawing.Size(523, 292);
            this.ProbeView.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 320);
            this.Controls.Add(this.ProbeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Основное окно";
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AddProbeToolStripMenuItem;
        private System.Windows.Forms.DataGridView ProbeView;
        private System.Windows.Forms.ToolStripMenuItem доступныеХарактеристикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AvailableCharacteristicsToolStripMenuItem1;
    }
}

