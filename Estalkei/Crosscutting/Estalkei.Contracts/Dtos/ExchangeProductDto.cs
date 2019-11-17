using Core.Contracts.Base;

namespace Estalkei.Contracts.Dtos
{
    public class ExchangeProductDto : DtoBase
    {
        public int ExchangeId { get; set; }
        public ExchangeDto Exchange { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
