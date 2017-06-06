using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace proiectLicenta.ClasificariTIOBE
{
    public class ClasificareTIOBE: Entity<Guid>
    {
        public virtual string ProgrammingLanguageName { get; set; }
        public virtual int TIOBEYear { get; set; }
        public virtual int TIOBEMonth { get; set; }
        public virtual decimal TIOBEPercent { get; set; }
    }
}
