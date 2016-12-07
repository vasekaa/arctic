namespace ArcticDB.Views
{
    partial class AddProbe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProbe));
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SaveSampleButton = new System.Windows.Forms.Button();
            this.addFileButton = new System.Windows.Forms.Button();
            this.keyWordTextBox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteFileButton = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteKeyword = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вводите ключевые слова через Enter";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(12, 320);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveSampleButton
            // 
            this.SaveSampleButton.Location = new System.Drawing.Point(363, 320);
            this.SaveSampleButton.Name = "SaveSampleButton";
            this.SaveSampleButton.Size = new System.Drawing.Size(105, 23);
            this.SaveSampleButton.TabIndex = 4;
            this.SaveSampleButton.Text = "Сохранить";
            this.SaveSampleButton.UseVisualStyleBackColor = true;
            this.SaveSampleButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // addFileButton
            // 
            this.addFileButton.Location = new System.Drawing.Point(363, 202);
            this.addFileButton.Name = "addFileButton";
            this.addFileButton.Size = new System.Drawing.Size(105, 24);
            this.addFileButton.TabIndex = 6;
            this.addFileButton.Text = "Добавить файл";
            this.addFileButton.UseVisualStyleBackColor = true;
            this.addFileButton.Click += new System.EventHandler(this.addFile_Click);
            // 
            // keyWordTextBox
            // 
            this.keyWordTextBox.Location = new System.Drawing.Point(12, 55);
            this.keyWordTextBox.Name = "keyWordTextBox";
            this.keyWordTextBox.Size = new System.Drawing.Size(358, 20);
            this.keyWordTextBox.TabIndex = 7;
            this.keyWordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.catchEnter);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Location = new System.Drawing.Point(12, 81);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(456, 115);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ключевое слово";
            this.columnHeader1.Width = 450;
            // 
            // deleteFileButton
            // 
            this.deleteFileButton.Location = new System.Drawing.Point(363, 232);
            this.deleteFileButton.Name = "deleteFileButton";
            this.deleteFileButton.Size = new System.Drawing.Size(105, 24);
            this.deleteFileButton.TabIndex = 9;
            this.deleteFileButton.Text = "Удалить файл";
            this.deleteFileButton.UseVisualStyleBackColor = true;
            this.deleteFileButton.Click += new System.EventHandler(this.deleteFileButton_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listView2.Location = new System.Drawing.Point(12, 202);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(345, 111);
            this.listView2.TabIndex = 10;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.DoubleClick += new System.EventHandler(this.fileListDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Файл";
            this.columnHeader2.Width = 350;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(52, 8);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 11;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(256, 9);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(212, 20);
            this.NameTextBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Дата";
            // 
            // deleteKeyword
            // 
            this.deleteKeyword.Location = new System.Drawing.Point(385, 53);
            this.deleteKeyword.Name = "deleteKeyword";
            this.deleteKeyword.Size = new System.Drawing.Size(83, 23);
            this.deleteKeyword.TabIndex = 15;
            this.deleteKeyword.Text = "Удалить";
            this.deleteKeyword.UseVisualStyleBackColor = true;
            this.deleteKeyword.Click += new System.EventHandler(this.button1_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(363, 263);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(105, 23);
            this.exportButton.TabIndex = 16;
            this.exportButton.Text = "Выгрузить";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddProbe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 355);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.deleteKeyword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.deleteFileButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.keyWordTextBox);
            this.Controls.Add(this.addFileButton);
            this.Controls.Add(this.SaveSampleButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddProbe";
            this.Text = "Новое исследование";
            this.Load += new System.EventHandler(this.AddProbe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button SaveSampleButton;
        private System.Windows.Forms.Button addFileButton;
        private System.Windows.Forms.TextBox keyWordTextBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button deleteFileButton;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button deleteKeyword;
        private System.Windows.Forms.Button exportButton;
    }
}