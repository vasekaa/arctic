namespace ArcticDB.Views
{
    partial class ObjectOfInvestigationEdit
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
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("test1");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("test2");
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem("test3");
            System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem("test4");
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem("test5");
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem("test6");
            this.OjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedCharectlistView = new System.Windows.Forms.ListView();
            this.availableCharactlistView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cancellButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.addCharact = new System.Windows.Forms.Button();
            this.removeCharact = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // OjectName
            // 
            this.OjectName.Location = new System.Drawing.Point(12, 29);
            this.OjectName.Name = "OjectName";
            this.OjectName.Size = new System.Drawing.Size(156, 20);
            this.OjectName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            // 
            // selectedCharectlistView
            // 
            this.selectedCharectlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.selectedCharectlistView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem19});
            this.selectedCharectlistView.Location = new System.Drawing.Point(12, 84);
            this.selectedCharectlistView.Name = "selectedCharectlistView";
            this.selectedCharectlistView.Size = new System.Drawing.Size(156, 184);
            this.selectedCharectlistView.TabIndex = 2;
            this.selectedCharectlistView.UseCompatibleStateImageBehavior = false;
            this.selectedCharectlistView.View = System.Windows.Forms.View.Details;
            // 
            // availableCharactlistView
            // 
            this.availableCharactlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.availableCharactlistView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem20,
            listViewItem21,
            listViewItem22,
            listViewItem23,
            listViewItem24});
            this.availableCharactlistView.Location = new System.Drawing.Point(234, 84);
            this.availableCharactlistView.Name = "availableCharactlistView";
            this.availableCharactlistView.Size = new System.Drawing.Size(156, 184);
            this.availableCharactlistView.TabIndex = 3;
            this.availableCharactlistView.UseCompatibleStateImageBehavior = false;
            this.availableCharactlistView.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Характеристики объекта";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Доступные характеристики";
            // 
            // cancellButton
            // 
            this.cancellButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancellButton.Location = new System.Drawing.Point(15, 285);
            this.cancellButton.Name = "cancellButton";
            this.cancellButton.Size = new System.Drawing.Size(75, 23);
            this.cancellButton.TabIndex = 6;
            this.cancellButton.Text = "Отмена";
            this.cancellButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(315, 285);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // addCharact
            // 
            this.addCharact.Location = new System.Drawing.Point(185, 141);
            this.addCharact.Name = "addCharact";
            this.addCharact.Size = new System.Drawing.Size(30, 23);
            this.addCharact.TabIndex = 8;
            this.addCharact.Text = "<-";
            this.addCharact.UseVisualStyleBackColor = true;
            this.addCharact.Click += new System.EventHandler(this.addCharact_Click);
            // 
            // removeCharact
            // 
            this.removeCharact.Location = new System.Drawing.Point(185, 171);
            this.removeCharact.Name = "removeCharact";
            this.removeCharact.Size = new System.Drawing.Size(30, 23);
            this.removeCharact.TabIndex = 9;
            this.removeCharact.Text = "->";
            this.removeCharact.UseVisualStyleBackColor = true;
            this.removeCharact.Click += new System.EventHandler(this.removeCharact_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Имя";
            // 
            // ObjectOfInvestigationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 320);
            this.Controls.Add(this.removeCharact);
            this.Controls.Add(this.addCharact);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.cancellButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.availableCharactlistView);
            this.Controls.Add(this.selectedCharectlistView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OjectName);
            this.Name = "ObjectOfInvestigationEdit";
            this.Text = "Добавить обьект исследования";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView selectedCharectlistView;
        private System.Windows.Forms.ListView availableCharactlistView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancellButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button addCharact;
        private System.Windows.Forms.Button removeCharact;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}