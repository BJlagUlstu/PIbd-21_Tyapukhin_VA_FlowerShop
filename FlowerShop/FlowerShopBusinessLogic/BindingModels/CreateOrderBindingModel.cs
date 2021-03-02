
namespace FlowerShopBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int FlowerId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}