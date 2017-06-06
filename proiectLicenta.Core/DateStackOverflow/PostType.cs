using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class PostType: Entity
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
