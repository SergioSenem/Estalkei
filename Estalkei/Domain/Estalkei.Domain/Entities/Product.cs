using Core.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Estalkei.Domain.Entities
{
    public class Product : EntityBase
    {
        [Required]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float SellPrice { get; set; }
        [Required]
        public float PurchasePrice { get; set; }
    }
}
