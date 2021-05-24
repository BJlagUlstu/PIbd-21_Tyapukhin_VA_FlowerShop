using FlowerShopBusinessLogic.Attributes;
using FlowerShopBusinessLogic.Enums;
using System;
using System.Runtime.Serialization;

namespace FlowerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int FlowerId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [Column(title: "Исполнитель", width: 150)]
        [DataMember]
        public string ImplementerFIO { get; set; }
        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }
        [Column(title: "Растение", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string FlowerName { get; set; }
        [Column(title: "Количество", width: 100)]
        [DataMember]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 70)]
        [DataMember]
        public decimal Sum { get; set; }
        [Column(title: "Статус", width: 100)]
        [DataMember]
        public OrderStatus Status { get; set; }
        [Column(title: "Дата создания", width: 120, format: "R")]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата выполнения", width: 120, format: "D")]
        [DataMember]
        public DateTime? DateImplement { get; set; }
    }
}