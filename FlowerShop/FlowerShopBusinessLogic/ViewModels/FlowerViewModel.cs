using System.Collections.Generic;
using System.ComponentModel;

namespace FlowerShopBusinessLogic.ViewModels
{
    public class FlowerViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название растения")]
        public string FlowerName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}