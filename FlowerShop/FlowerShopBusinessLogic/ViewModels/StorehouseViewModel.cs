using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FlowerShopBusinessLogic.ViewModels
{
    public class StorehouseViewModel
    {
        public int? StorehouseId { get; set; }
        [DisplayName("Склад")]
        public string StorehouseName { get; set; }
        [DisplayName("ФИО ответственного")]
        public string FullName { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}