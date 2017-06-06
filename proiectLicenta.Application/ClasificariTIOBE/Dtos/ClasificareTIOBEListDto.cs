using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace proiectLicenta.ClasificariTIOBE.Dtos
{
    [AutoMapFrom(typeof (ClasificareTIOBE))]
    public class ClasificareTIOBEListDto : Entity<Guid>
    {
        public string ProgrammingLanguageName { get; set; }
        public int TIOBEYear { get; set; }
        public int TIOBEMonth { get; set; }
        public decimal TIOBEPercent { get; set; }
    }
}
