using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow.Dtos
{
    [AutoMapFrom(typeof(AnswersPerDayAndHour))]
    public class AnswersPerDayAndHourListDto: Entity
    {

        public virtual int Answers { get; set; }
        public virtual int Hour { get; set; }
        public virtual string Day { get; set; }

    }
}
