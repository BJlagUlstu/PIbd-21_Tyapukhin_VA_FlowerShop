using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace FlowerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class FlowerViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название растения")]
        public string FlowerName { get; set; }
        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}