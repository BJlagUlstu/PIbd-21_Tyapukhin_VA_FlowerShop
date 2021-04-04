using System.Runtime.Serialization;

namespace FlowerShopBusinessLogic.BindingModels
{
    [DataContract]
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int FlowerId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}