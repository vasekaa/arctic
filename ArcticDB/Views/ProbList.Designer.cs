namespace ArcticDB.Views
{
    partial class ProbList
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.keysHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddProbButton = new System.Windows.Forms.Button();
            this.RemoveProbButton = new System.Windows.Forms.Button();
            this.nameSearchTextBox = new System.Windows.Forms.TextBox();
            this.keysSearchTextBox1 = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.dateSearchMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.dateHeader,
            this.keysHeader,
            this.id});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(1, 113);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(814, 338);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.doubleClickAction);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Название";
            this.nameHeader.Width = 170;
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Дата";
            this.dateHeader.Width = 100;
            // 
            // keysHeader
            // 
            this.keysHeader.Text = "Ключевые слова";
            this.keysHeader.Width = 400;
            // 
            // id
            // 
            this.id.Text = "id";
            // 
            // AddProbButton
            // 
            this.AddProbButton.Location = new System.Drawing.Point(12, 12);
            this.AddProbButton.Name = "AddProbButton";
            this.AddProbButton.Size = new System.Drawing.Size(75, 23);
            this.AddProbButton.TabIndex = 1;
            this.AddProbButton.Text = "Добавить";
            this.AddProbButton.UseVisualStyleBackColor = true;
            this.AddProbButton.Click += new System.EventHandler(this.AddProbButton_Click);
            // 
            // RemoveProbButton
            // 
            this.RemoveProbButton.Location = new System.Drawing.Point(103, 12);
            this.RemoveProbButton.Name = "RemoveProbButton";
            this.RemoveProbButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveProbButton.TabIndex = 2;
            this.RemoveProbButton.Text = "Удалить";
            this.RemoveProbButton.UseVisualStyleBackColor = true;
            this.RemoveProbButton.Click += new System.EventHandler(this.RemoveProbButton_Click);
            // 
            // nameSearchTextBox
            // 
            this.nameSearchTextBox.Location = new System.Drawing.Point(315, 12);
            this.nameSearchTextBox.Name = "nameSearchTextBox";
            this.nameSearchTextBox.Size = new System.Drawing.Size(487, 20);
            this.nameSearchTextBox.TabIndex = 3;
            this.nameSearchTextBox.Text = "Имя файла";
            // 
            // keysSearchTextBox1
            // 
            this.keysSearchTextBox1.Location = new System.Drawing.Point(315, 38);
            this.keysSearchTextBox1.Multiline = true;
            this.keysSearchTextBox1.Name = "keysSearchTextBox1";
            this.keysSearchTextBox1.Size = new System.Drawing.Size(487, 66);
            this.keysSearchTextBox1.TabIndex = 5;
            this.keysSearchTextBox1.Text = "Ключевые слова для поиска";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(209, 46);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 49);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // dateSearchMaskedTextBox
            // 
            this.dateSearchMaskedTextBox.Location = new System.Drawing.Point(209, 14);
            this.dateSearchMaskedTextBox.Mask = "00/00/0000";
            this.dateSearchMaskedTextBox.Name = "dateSearchMaskedTextBox";
            this.dateSearchMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.dateSearchMaskedTextBox.TabIndex = 7;
            this.dateSearchMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // ProbList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 451);
            this.Controls.Add(this.dateSearchMaskedTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.keysSearchTextBox1);
            this.Controls.Add(this.nameSearchTextBox);
            this.Controls.Add(this.RemoveProbButton);
            this.Controls.Add(this.AddProbButton);
            this.Controls.Add(this.listView1);
            this.Name = "ProbList";
            this.Text = "Пробы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button AddProbButton;
        private System.Windows.Forms.Button RemoveProbButton;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ColumnHeader keysHeader;
        private System.Windows.Forms.TextBox nameSearchTextBox;
        private System.Windows.Forms.TextBox keysSearchTextBox1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.MaskedTextBox dateSearchMaskedTextBox;
        private System.Windows.Forms.ColumnHeader id;
    }
}