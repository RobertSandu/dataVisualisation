using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow
{
    public class TagTotalAppearance: Entity
    {
        [StringLength(150)]
        public virtual string Tag { get; set; }
        public virtual int Appearences { get; set; }
    }
}
