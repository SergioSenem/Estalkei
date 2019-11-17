using Core.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Estalkei.Domain.Entities
{
    public class Provider : EntityBase
    {
        [Required]
        public string Name { get; set; }
    }
}
