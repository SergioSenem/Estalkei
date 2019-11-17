using Core.Contracts.Base;

namespace Estalkei.Contracts.Dtos
{
    public class ProductDto : DtoBase
    {
        public int ProviderId { get; set; }
        public ProviderDto Provider { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float SellPrice { get; set; }
        public float PurchasePrice { get; set; }
    }
}
