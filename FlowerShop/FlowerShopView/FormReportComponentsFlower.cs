﻿using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.BusinessLogics;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace FlowerShopView
{
    public partial class FormReportComponentsFlower : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportComponentsFlower(ReportLogic _logic)
        {
            InitializeComponent();
            logic = _logic;
        }
        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveComponentFlowerToExcelFile");
                        method.Invoke(logic, new object[] { new ReportBindingModel { FileName = dialog.FileName }});
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void FormReportComponentsFlower_Load(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = logic.GetType().GetMethod("GetComponentsFlower");
                List<ReportFlowerComponentViewModel> dict = (List<ReportFlowerComponentViewModel>)method.Invoke(logic, new object[] { });
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.FlowerName, "", "" });
                        foreach (var listElem in elem.Components)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}