using FlowerShopBusinessLogic.Attributes;
using System.Runtime.Serialization;

namespace FlowerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int? Id { get; set; }
        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ClientFIO { get; set; }
        [Column(title: "Логин", width: 120)]
        [DataMember]
        public string Email { get; set; }
        [Column(title: "Пароль", width: 120)]
        [DataMember]
        public string Password { get; set; }
    }
}