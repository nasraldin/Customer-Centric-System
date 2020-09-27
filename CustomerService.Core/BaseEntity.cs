using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerService.Core
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        [Key]
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

        // you can add audited info in this class
    }
}