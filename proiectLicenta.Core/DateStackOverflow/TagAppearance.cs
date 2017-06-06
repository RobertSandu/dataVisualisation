using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow
{
    public class TagAppearance: Entity
    {
        [StringLength(150)]
        public virtual string Tag1 { get; set; }
        [StringLength(150)]
        public virtual string Tag2 { get; set; }
        public virtual int Appearences { get; set; }
    }
}
