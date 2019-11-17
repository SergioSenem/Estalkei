using Core.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Estalkei.Domain.Entities
{
    public class ExchangeProduct : EntityBase
    {
        [Required]
        public int ExchangeId { get; set; }
        public Exchange Exchange { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
