using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.BusinessLogics;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;
using System.Collections.Generic;

namespace FlowerShopView
{
    public partial class FormAddComponent : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ComponentLogic _logic;
        private readonly StorehouseLogic _logicS;
        public FormAddComponent(ComponentLogic logic, StorehouseLogic logicS)
        {
            InitializeComponent();
            _logic = logic;
            _logicS = logicS;
            List<ComponentViewModel> _list = _logic.Read(null);

            if (_list != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = _list;
                comboBoxComponent.SelectedItem = null;
            }

            List<StorehouseViewModel> listS = _logicS.Read(null);

            if (listS != null)
            {
                comboBoxStorehouse.DisplayMember = "StorehouseName";
                comboBoxStorehouse.ValueMember = "StorehouseId";
                comboBoxStorehouse.DataSource = listS;
                comboBoxStorehouse.SelectedItem = null;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле 'Количество'", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Укажите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStorehouse.SelectedValue == null)
            {
                MessageBox.Show("Укажите склад", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                string component = comboBoxComponent.Text;
                string wareHouse = comboBoxStorehouse.Text;
                List<ComponentViewModel> listC = _logic.Read(null);

                _logicS.AddComponent(
                    new AddComponentBindingModel
                    {
                        StorehouseId = Convert.ToInt32(comboBoxStorehouse.SelectedValue),
                        ComponentId = listC[comboBoxComponent.SelectedIndex].Id,
                        Count = int.Parse(textBoxCount.Text)
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
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}