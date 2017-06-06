using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow
{
    public class TagGrouping: Entity
    {
        public int Appearances { get; set; }

        [StringLength(150)]
        public string Tags { get; set; }
    }
}
