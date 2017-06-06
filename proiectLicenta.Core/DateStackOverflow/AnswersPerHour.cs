using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow
{
    public class AnswersPerHour: Entity
    {

        public virtual int Answers { get; set; }
        public virtual int Hour { get; set; }

    }
}
