using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace proiectLicenta.DateGithub
{
    public class RulareJobDateGithub : Entity<Guid>, IHasCreationTime
    {
        public virtual DateTime CreationTime { get; set; }

        public RulareJobDateGithub()
        {
            CreationTime = DateTime.Now;
        }
    }
}
