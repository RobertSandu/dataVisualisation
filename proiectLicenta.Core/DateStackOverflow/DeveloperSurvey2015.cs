using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow
{
    public class DeveloperSurvey2015: Entity
    {
        public virtual string Country { get; set; }
        public virtual int Age { get; set; }
        public virtual string Gender { get; set; }
        public virtual string TabsOrSpaces { get; set; }
        public virtual int Experience { get; set; }
        public virtual string Occupation { get; set; }
 
    }
}
