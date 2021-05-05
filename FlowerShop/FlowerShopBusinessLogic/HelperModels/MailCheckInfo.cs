using FlowerShopBusinessLogic.Interfaces;

namespace FlowerShopBusinessLogic.HelperModels
{
    public class MailCheckInfo
    {
        public string PopHost { get; set; }
        public int PopPort { get; set; }
        public IMessageInfoStorage MessageStorage { get; set; }
        public IClientStorage ClientStorage { get; set; }
    }
}