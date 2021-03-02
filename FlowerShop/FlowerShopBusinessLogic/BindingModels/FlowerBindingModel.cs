using System.Collections.Generic;

namespace FlowerShopBusinessLogic.BindingModels
{
    public class FlowerBindingModel
    {
        public int? Id { get; set; }
        public string FlowerName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}