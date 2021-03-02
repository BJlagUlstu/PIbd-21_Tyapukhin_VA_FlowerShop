namespace FlowerShopView
{
	partial class FormFlower
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
			this.labelName = new System.Windows.Forms.Label();
			this.labelCost = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			this.groupBoxComponents = new System.Windows.Forms.GroupBox();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.currentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.currentComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBoxComponents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(15, 26);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(60, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Название:";
			// 
			// labelCost
			// 
			this.labelCost.AutoSize = true;
			this.labelCost.Location = new System.Drawing.Point(15, 60);
			this.labelCost.Name = "labelCost";
			this.labelCost.Size = new System.Drawing.Size(36, 13);
			this.labelCost.TabIndex = 1;
			this.labelCost.Text = "Цена:";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(94, 26);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(277, 20);
			this.textBoxName.TabIndex = 2;
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(94, 57);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(277, 20);
			this.textBoxPrice.TabIndex = 3;
			// 
			// groupBoxComponents
			// 
			this.groupBoxComponents.Controls.Add(this.buttonRefresh);
			this.groupBoxComponents.Controls.Add(this.buttonDelete);
			this.groupBoxComponents.Controls.Add(this.buttonUpdate);
			this.groupBoxComponents.Controls.Add(this.buttonAdd);
			this.groupBoxComponents.Controls.Add(this.dataGridView);
			this.groupBoxComponents.Location = new System.Drawing.Point(12, 102);
			this.groupBoxComponents.Name = "groupBoxComponents";
			this.groupBoxComponents.Size = new System.Drawing.Size(528, 291);
			this.groupBoxComponents.TabIndex = 4;
			this.groupBoxComponents.TabStop = false;
			this.groupBoxComponents.Text = "Компоненты";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Location = new System.Drawing.Point(422, 173);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 4;
			this.buttonRefresh.Text = "Обновить";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(422, 122);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(75, 23);
			this.buttonDelete.TabIndex = 3;
			this.buttonDelete.Text = "Удалить";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(422, 73);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
			this.buttonUpdate.TabIndex = 2;
			this.buttonUpdate.Text = "Изменить";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpd_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(422, 19);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 1;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.currentID,
			this.currentComponent,
			this.count});
			this.dataGridView.Location = new System.Drawing.Point(6, 19);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new System.Drawing.Size(388, 265);
			this.dataGridView.TabIndex = 0;
			// 
			// currentID
			// 
			this.currentID.HeaderText = "";
			this.currentID.Name = "currentID";
			this.currentID.Visible = false;
			// 
			// currentComponent
			// 
			this.currentComponent.HeaderText = "Компонент";
			this.currentComponent.Name = "currentComponent";
			this.currentComponent.Width = 200;
			// 
			// count
			// 
			this.count.HeaderText = "Количество";
			this.count.Name = "count";
			this.count.Width = 145;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(363, 415);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(462, 415);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// FormFlower
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(549, 450);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.groupBoxComponents);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelCost);
			this.Controls.Add(this.labelName);
			this.Name = "FormFlower";
			this.Text = "Растение";
			this.Load += new System.EventHandler(this.FormFlower_Load);
			this.groupBoxComponents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelCost;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxPrice;
		private System.Windows.Forms.GroupBox groupBoxComponents;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DataGridViewTextBoxColumn currentID;
		private System.Windows.Forms.DataGridViewTextBoxColumn currentComponent;
		private System.Windows.Forms.DataGridViewTextBoxColumn count;
	}
}