using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow.Dtos
{
    [AutoMapFrom(typeof(TagAppearance))]
    public class TagAppearanceListDto: Entity
    {
        //[AutoMapFromAttribute()]
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public int Appearences { get; set; }
    }
}
