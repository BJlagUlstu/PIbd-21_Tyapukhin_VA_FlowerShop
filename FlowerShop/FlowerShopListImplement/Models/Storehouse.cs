using System;
using System.Collections.Generic;

namespace FlowerShopListImplement.Models
{
    public class Storehouse
    {
        public int? StorehouseId { get; set; }
        public string StorehouseName { get; set; }
        public string FullName { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, int> StorehouseComponents { get; set; }
    }
}