using System;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.BindingModels
{
    public class StorehouseBindingModel
    {
        public int? StorehouseId { get; set; }
        public string StorehouseName { get; set; }
        public string FullName { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}