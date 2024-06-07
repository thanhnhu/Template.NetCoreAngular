using System;
using System.ComponentModel.DataAnnotations;

namespace Template.NetCore.Domain
{
    public abstract class Entity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
