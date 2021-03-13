using System.ComponentModel.DataAnnotations;

namespace FlowerShopDatabaseImplement.Models
{
    public class FlowerComponent
    {
        public int Id { get; set; }
        public int FlowerId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Flower Flower { get; set; }
    }
}