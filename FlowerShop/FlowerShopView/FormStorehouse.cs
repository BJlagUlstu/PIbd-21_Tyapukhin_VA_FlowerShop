using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.BusinessLogics;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace FlowerShopView
{
    public partial class FormStorehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly StorehouseLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> storehouseComponents;
        public FormStorehouse(StorehouseLogic service)
        {
            InitializeComponent();
            logic = service;
            if (id.HasValue)
            {
                try
                {
                    StorehouseViewModel view = logic.Read(new StorehouseBindingModel { StorehouseId = id.Value })?[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                storehouseComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (storehouseComponents != null)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Columns[0].Visible = false;
                    foreach (var pc in storehouseComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxFullName.Text))
            {
                MessageBox.Show("Заполните ФИО ответственного", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new StorehouseBindingModel
                {
                    StorehouseId = id,
                    StorehouseName = textBoxName.Text,
                    FullName = textBoxFullName.Text,
                    DateCreate = DateTime.Now,
                    StorehouseComponents = storehouseComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void FormStorehouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StorehouseViewModel view = logic.Read(new StorehouseBindingModel { StorehouseId = id.Value })?[0];
                    if (view != null)
                    {
                        storehouseComponents = view.StorehouseComponents;
                        textBoxName.Text = view.StorehouseName;
                        textBoxFullName.Text = view.FullName;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                storehouseComponents = new Dictionary<int, (string, int)>();
            }
        }
    }
}