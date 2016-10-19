namespace ArcticDB.Views
{
    partial class Characteriscics
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
            this.characteristicsListView = new System.Windows.Forms.ListView();
            this.charactNameTextFiled = new System.Windows.Forms.TextBox();
            this.charactTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addCharactButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // characteristicsListView
            // 
            this.characteristicsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.characteristicsListView.Location = new System.Drawing.Point(-2, 104);
            this.characteristicsListView.Name = "characteristicsListView";
            this.characteristicsListView.Size = new System.Drawing.Size(287, 228);
            this.characteristicsListView.TabIndex = 0;
            this.characteristicsListView.UseCompatibleStateImageBehavior = false;
            this.characteristicsListView.View = System.Windows.Forms.View.Details;
            // 
            // charactNameTextFiled
            // 
            this.charactNameTextFiled.Location = new System.Drawing.Point(12, 26);
            this.charactNameTextFiled.Name = "charactNameTextFiled";
            this.charactNameTextFiled.Size = new System.Drawing.Size(100, 20);
            this.charactNameTextFiled.TabIndex = 1;
            // 
            // charactTypeComboBox
            // 
            this.charactTypeComboBox.FormattingEnabled = true;
            this.charactTypeComboBox.Location = new System.Drawing.Point(151, 25);
            this.charactTypeComboBox.Name = "charactTypeComboBox";
            this.charactTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.charactTypeComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Тип";
            // 
            // addCharactButton
            // 
            this.addCharactButton.Location = new System.Drawing.Point(12, 52);
            this.addCharactButton.Name = "addCharactButton";
            this.addCharactButton.Size = new System.Drawing.Size(75, 23);
            this.addCharactButton.TabIndex = 5;
            this.addCharactButton.Text = "Добавить";
            this.addCharactButton.UseVisualStyleBackColor = true;
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(105, 52);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 6;
            this.changeButton.Text = "Изменить";
            this.changeButton.UseVisualStyleBackColor = true;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(195, 52);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 7;
            this.RemoveButton.Text = "Удалить";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Тип";
            this.columnHeader2.Width = 140;
            // 
            // Characteriscics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.addCharactButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.charactTypeComboBox);
            this.Controls.Add(this.charactNameTextFiled);
            this.Controls.Add(this.characteristicsListView);
            this.Name = "Characteriscics";
            this.Text = "Характеристики";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView characteristicsListView;
        private System.Windows.Forms.TextBox charactNameTextFiled;
        private System.Windows.Forms.ComboBox charactTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addCharactButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}