using FlowerShopBusinessLogic.Attributes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlowerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class FlowerViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }
        [Column(title: "Название растения", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string FlowerName { get; set; }
        [Column(title: "Цена", width: 70)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> FlowerComponents { get; set; }
    }
}