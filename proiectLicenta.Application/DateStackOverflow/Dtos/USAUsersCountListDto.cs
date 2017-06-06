using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace proiectLicenta.DateStackOverflow.Dtos
{
    [AutoMapFrom(typeof(USAUsersCount))]
    public class USAUsersCountListDto
    {
        public virtual string State { get; set; }
        public virtual int NumberOfUsers { get; set; }
        public virtual decimal Longitude { get; set; }
        public virtual decimal Latitude { get; set; }
        public virtual int? NumberOfUsersUnder20 { get; set; }
        public virtual int? NumberOfUsersBetween20And24 { get; set; }
        public virtual int? NumberOfUsersBetween25And29 { get; set; }
        public virtual int? NumberOfUsersBetween30And34 { get; set; }
        public virtual int? NumberOfUsersBetween35And39 { get; set; }
        public virtual int? NumberOfUsersBetween40And49 { get; set; }
        public virtual int? NumberOfUsersBetween50And60 { get; set; }
        public virtual int? NumberOfUsersOvers60 { get; set; }
        public virtual int? NumberOfUsersWithNoAge { get; set; }
    }
}
