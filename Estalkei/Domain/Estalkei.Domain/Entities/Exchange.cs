﻿using Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estalkei.Domain.Entities
{
    public class Exchange : EntityBase
    {
        [Required]
        public int ExchangeTypeId { get; set; }
        public ExchangeType ExchangeType { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public IEnumerable<ExchangeProduct> ExchangeProducts { get; set; }
    }
}
