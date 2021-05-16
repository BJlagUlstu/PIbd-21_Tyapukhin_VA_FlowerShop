namespace FlowerShopView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.растенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнениеСкладаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыСКомпонентамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокВсехЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокРастенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.растенияСКомпонентамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonOrderPaid = new System.Windows.Forms.Button();
            this.buttonUpdateList = new System.Windows.Forms.Button();
            this.письмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнениеСкладаToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.запускРаботToolStripMenuItem,
            this.письмаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.растенияToolStripMenuItem,
            this.складыToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
            // 
            // растенияToolStripMenuItem
            // 
            this.растенияToolStripMenuItem.Name = "растенияToolStripMenuItem";
            this.растенияToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.растенияToolStripMenuItem.Text = "Растения";
            this.растенияToolStripMenuItem.Click += new System.EventHandler(this.РастенияToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // пополнениеСкладаToolStripMenuItem
            // 
            this.пополнениеСкладаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пополнитьToolStripMenuItem});
            this.пополнениеСкладаToolStripMenuItem.Name = "пополнениеСкладаToolStripMenuItem";
            this.пополнениеСкладаToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.пополнениеСкладаToolStripMenuItem.Text = "Пополнение склада";
            // 
            // пополнитьToolStripMenuItem
            // 
            this.пополнитьToolStripMenuItem.Name = "пополнитьToolStripMenuItem";
            this.пополнитьToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.пополнитьToolStripMenuItem.Text = "Пополнить";
            this.пополнитьToolStripMenuItem.Click += new System.EventHandler(this.пополнитьToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокСкладовToolStripMenuItem,
            this.складыСКомпонентамиToolStripMenuItem,
            this.списокВсехЗаказовToolStripMenuItem,
            this.списокРастенийToolStripMenuItem,
            this.растенияСКомпонентамиToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокСкладовToolStripMenuItem
            // 
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.списокСкладовToolStripMenuItem_Click);
            // 
            // складыСКомпонентамиToolStripMenuItem
            // 
            this.складыСКомпонентамиToolStripMenuItem.Name = "складыСКомпонентамиToolStripMenuItem";
            this.складыСКомпонентамиToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.складыСКомпонентамиToolStripMenuItem.Text = "Склады с компонентами";
            this.складыСКомпонентамиToolStripMenuItem.Click += new System.EventHandler(this.складыСКомпонентамиToolStripMenuItem_Click);
            // 
            // списокВсехЗаказовToolStripMenuItem
            // 
            this.списокВсехЗаказовToolStripMenuItem.Name = "списокВсехЗаказовToolStripMenuItem";
            this.списокВсехЗаказовToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.списокВсехЗаказовToolStripMenuItem.Text = "Список всех заказов";
            this.списокВсехЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // списокРастенийToolStripMenuItem
            // 
            this.списокРастенийToolStripMenuItem.Name = "списокРастенийToolStripMenuItem";
            this.списокРастенийToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.списокРастенийToolStripMenuItem.Text = "Список растений";
            this.списокРастенийToolStripMenuItem.Click += new System.EventHandler(this.списокРастенийToolStripMenuItem_Click);
            // 
            // растенияСКомпонентамиToolStripMenuItem
            // 
            this.растенияСКомпонентамиToolStripMenuItem.Name = "растенияСКомпонентамиToolStripMenuItem";
            this.растенияСКомпонентамиToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.растенияСКомпонентамиToolStripMenuItem.Text = "Растения с компонентами";
            this.растенияСКомпонентамиToolStripMenuItem.Click += new System.EventHandler(this.растенияСКомпонентамиToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem1_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(990, 320);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(1020, 100);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(150, 23);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonOrderPaid
            // 
            this.buttonOrderPaid.Location = new System.Drawing.Point(1020, 180);
            this.buttonOrderPaid.Name = "buttonOrderPaid";
            this.buttonOrderPaid.Size = new System.Drawing.Size(150, 23);
            this.buttonOrderPaid.TabIndex = 5;
            this.buttonOrderPaid.Text = "Заказ оплачен";
            this.buttonOrderPaid.UseVisualStyleBackColor = true;
            this.buttonOrderPaid.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // buttonUpdateList
            // 
            this.buttonUpdateList.Location = new System.Drawing.Point(1020, 260);
            this.buttonUpdateList.Name = "buttonUpdateList";
            this.buttonUpdateList.Size = new System.Drawing.Size(150, 23);
            this.buttonUpdateList.TabIndex = 6;
            this.buttonUpdateList.Text = "Обновить список";
            this.buttonUpdateList.UseVisualStyleBackColor = true;
            this.buttonUpdateList.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // письмаToolStripMenuItem
            // 
            this.письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            this.письмаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.письмаToolStripMenuItem.Text = "Письма";
            this.письмаToolStripMenuItem.Click += new System.EventHandler(this.письмаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 361);
            this.Controls.Add(this.buttonUpdateList);
            this.Controls.Add(this.buttonOrderPaid);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Магазин растений";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem растенияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonOrderPaid;
        private System.Windows.Forms.Button buttonUpdateList;
        private System.Windows.Forms.ToolStripMenuItem пополнениеСкладаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокВсехЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыСКомпонентамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокРастенийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem растенияСКомпонентамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem письмаToolStripMenuItem;
    }
}