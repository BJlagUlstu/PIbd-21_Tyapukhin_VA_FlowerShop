﻿namespace FlowerShopView
{
    partial class FormAddComponent
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelComponent = new System.Windows.Forms.Label();
            this.comboBoxStorehouse = new System.Windows.Forms.ComboBox();
            this.labelStorehouse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(267, 135);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(158, 135);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(123, 59);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(219, 21);
            this.comboBoxComponent.TabIndex = 9;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(123, 95);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(219, 20);
            this.textBoxCount.TabIndex = 8;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(18, 98);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 7;
            this.labelCount.Text = "Количество:";
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(18, 62);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(66, 13);
            this.labelComponent.TabIndex = 6;
            this.labelComponent.Text = "Компонент:";
            // 
            // comboBoxStorehouse
            // 
            this.comboBoxStorehouse.FormattingEnabled = true;
            this.comboBoxStorehouse.Location = new System.Drawing.Point(123, 20);
            this.comboBoxStorehouse.Name = "comboBoxStorehouse";
            this.comboBoxStorehouse.Size = new System.Drawing.Size(219, 21);
            this.comboBoxStorehouse.TabIndex = 13;
            // 
            // labelStorehouse
            // 
            this.labelStorehouse.AutoSize = true;
            this.labelStorehouse.Location = new System.Drawing.Point(18, 23);
            this.labelStorehouse.Name = "labelStorehouse";
            this.labelStorehouse.Size = new System.Drawing.Size(41, 13);
            this.labelStorehouse.TabIndex = 12;
            this.labelStorehouse.Text = "Склад:";
            // 
            // FormAddComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 181);
            this.Controls.Add(this.comboBoxStorehouse);
            this.Controls.Add(this.labelStorehouse);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelComponent);
            this.Name = "FormAddComponent";
            this.Text = "Добавление компонента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.ComboBox comboBoxStorehouse;
        private System.Windows.Forms.Label labelStorehouse;
    }
}