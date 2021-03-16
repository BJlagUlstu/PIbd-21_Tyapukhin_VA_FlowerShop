using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerShopDatabaseImplement.Models
{
    public class Storehouse
    {
        public int StorehouseId { get; set; }
        [Required]
        public string StorehouseName { get; set; }
        [Required]
        public string FullName { get; set; }
        public DateTime DateCreate { get; set; }
        [ForeignKey("StorehouseId")]
        public virtual List<StorehouseComponent> StorehouseComponents { get; set; }
    }
}