using FlowerShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.ViewModels
{
    public class StorehouseViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int? StorehouseId { get; set; }
        [Column(title: "Склад", width: 120)]
        public string StorehouseName { get; set; }
        [Column(title: "ФИО ответственного", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string FullName { get; set; }
        [Column(title: "Дата создания", width: 120, format: "D")]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}