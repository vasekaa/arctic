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
            this.dateSearchMaskedTextBoxTo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.listView1.Location = new System.Drawing.Point(1, 129);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(814, 322);
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
            this.AddProbButton.Location = new System.Drawing.Point(12, 100);
            this.AddProbButton.Name = "AddProbButton";
            this.AddProbButton.Size = new System.Drawing.Size(75, 23);
            this.AddProbButton.TabIndex = 1;
            this.AddProbButton.Text = "Добавить";
            this.AddProbButton.UseVisualStyleBackColor = true;
            this.AddProbButton.Click += new System.EventHandler(this.AddProbButton_Click);
            // 
            // RemoveProbButton
            // 
            this.RemoveProbButton.Location = new System.Drawing.Point(93, 100);
            this.RemoveProbButton.Name = "RemoveProbButton";
            this.RemoveProbButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveProbButton.TabIndex = 2;
            this.RemoveProbButton.Text = "Удалить";
            this.RemoveProbButton.UseVisualStyleBackColor = true;
            this.RemoveProbButton.Click += new System.EventHandler(this.RemoveProbButton_Click);
            // 
            // nameSearchTextBox
            // 
            this.nameSearchTextBox.Location = new System.Drawing.Point(322, 21);
            this.nameSearchTextBox.Name = "nameSearchTextBox";
            this.nameSearchTextBox.Size = new System.Drawing.Size(487, 20);
            this.nameSearchTextBox.TabIndex = 3;
            this.nameSearchTextBox.Click += new System.EventHandler(this.fileNameTextBoxOnClick);
            // 
            // keysSearchTextBox1
            // 
            this.keysSearchTextBox1.Location = new System.Drawing.Point(322, 60);
            this.keysSearchTextBox1.Multiline = true;
            this.keysSearchTextBox1.Name = "keysSearchTextBox1";
            this.keysSearchTextBox1.Size = new System.Drawing.Size(487, 66);
            this.keysSearchTextBox1.TabIndex = 5;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(12, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(152, 46);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // dateSearchMaskedTextBox
            // 
            this.dateSearchMaskedTextBox.Location = new System.Drawing.Point(196, 12);
            this.dateSearchMaskedTextBox.Mask = "00/00/0000";
            this.dateSearchMaskedTextBox.Name = "dateSearchMaskedTextBox";
            this.dateSearchMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.dateSearchMaskedTextBox.TabIndex = 7;
            this.dateSearchMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // dateSearchMaskedTextBoxTo
            // 
            this.dateSearchMaskedTextBoxTo.Location = new System.Drawing.Point(196, 38);
            this.dateSearchMaskedTextBoxTo.Mask = "00/00/0000";
            this.dateSearchMaskedTextBoxTo.Name = "dateSearchMaskedTextBoxTo";
            this.dateSearchMaskedTextBoxTo.Size = new System.Drawing.Size(100, 20);
            this.dateSearchMaskedTextBoxTo.TabIndex = 8;
            this.dateSearchMaskedTextBoxTo.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "От :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "До :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ключевые слова через пробел";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Имя файла для поиска";
            // 
            // ProbList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 451);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateSearchMaskedTextBoxTo);
            this.Controls.Add(this.dateSearchMaskedTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.keysSearchTextBox1);
            this.Controls.Add(this.nameSearchTextBox);
            this.Controls.Add(this.RemoveProbButton);
            this.Controls.Add(this.AddProbButton);
            this.Controls.Add(this.listView1);
            this.Name = "ProbList";
            this.Text = "Пробы";
            this.Load += new System.EventHandler(this.ProbList_Load);
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
        private System.Windows.Forms.MaskedTextBox dateSearchMaskedTextBoxTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}