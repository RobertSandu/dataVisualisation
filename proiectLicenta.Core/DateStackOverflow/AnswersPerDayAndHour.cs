using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow
{
    public class AnswersPerDayAndHour: Entity
    {

        public virtual int Answers { get; set; }
        public virtual int Hour { get; set; }
        public virtual string Day { get; set; }

    }
}
