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
            this.probTypeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.AddCharacteristic = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.CharacteristicsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // probTypeCombo
            // 
            this.probTypeCombo.FormattingEnabled = true;
            this.probTypeCombo.Location = new System.Drawing.Point(13, 26);
            this.probTypeCombo.Name = "probTypeCombo";
            this.probTypeCombo.Size = new System.Drawing.Size(121, 21);
            this.probTypeCombo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбор типа пробы";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(16, 320);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AddCharacteristic
            // 
            this.AddCharacteristic.Location = new System.Drawing.Point(171, 320);
            this.AddCharacteristic.Name = "AddCharacteristic";
            this.AddCharacteristic.Size = new System.Drawing.Size(149, 23);
            this.AddCharacteristic.TabIndex = 3;
            this.AddCharacteristic.Text = "Добавить характеристику";
            this.AddCharacteristic.UseVisualStyleBackColor = true;
            this.AddCharacteristic.Click += new System.EventHandler(this.AddCharacteristic_Click);
            // 
            // Save
            // 
            this.Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Save.Location = new System.Drawing.Point(399, 320);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 4;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // CharacteristicsTableLayout
            // 
            this.CharacteristicsTableLayout.AutoScroll = true;
            this.CharacteristicsTableLayout.ColumnCount = 2;
            this.CharacteristicsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CharacteristicsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CharacteristicsTableLayout.Location = new System.Drawing.Point(12, 53);
            this.CharacteristicsTableLayout.Name = "CharacteristicsTableLayout";
            this.CharacteristicsTableLayout.RowCount = 1;
            this.CharacteristicsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CharacteristicsTableLayout.Size = new System.Drawing.Size(462, 261);
            this.CharacteristicsTableLayout.TabIndex = 5;
            // 
            // AddProbe
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 355);
            this.Controls.Add(this.CharacteristicsTableLayout);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.AddCharacteristic);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.probTypeCombo);
            this.Name = "AddProbe";
            this.Text = "Новая проба";
            this.Load += new System.EventHandler(this.AddProbe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox probTypeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button AddCharacteristic;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TableLayoutPanel CharacteristicsTableLayout;
    }
}