using Core.Contracts.Base;
using System;

namespace Estalkei.Contracts.Dtos
{
    public class ExchangeDto : DtoBase
    {
        public int ExchangeTypeId { get; set; }
        public ExchangeTypeDto ExchangeType { get; set; }
        public DateTime Date { get; set; }
    }
}
