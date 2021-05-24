using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.BusinessLogics;
using FlowerShopBusinessLogic.ViewModels;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace FlowerShopView
{
    public partial class FormReportOrdersAllDates : Form
    {
        [Dependency]
        private readonly ReportLogic logic;
        public FormReportOrdersAllDates(ReportLogic _logic)
        {
            InitializeComponent();
            logic = _logic;
        }
        private void buttonForm_Click(object sender, EventArgs e)
        {
            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterAllDates", "за весь период");
                reportViewer.LocalReport.SetParameters(parameter);
                MethodInfo method = logic.GetType().GetMethod("GetAllOrders");
                List<ReportOrdersViewModel> dataSource = (List<ReportOrdersViewModel>)method.Invoke(logic, new object[] { });
                ReportDataSource source = new ReportDataSource("DataSetOrdersAllDates", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        [Obsolete]
        private void buttonFormToPDF_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo method = logic.GetType().GetMethod("SaveAllOrdersToPdfFile");
                        method.Invoke(logic, new object[] { new ReportBindingModel { FileName = dialog.FileName }});
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void FormReportOrdersAllDates_Load(object sender, EventArgs e)
        {
            reportViewer.RefreshReport();
        }
    }
}