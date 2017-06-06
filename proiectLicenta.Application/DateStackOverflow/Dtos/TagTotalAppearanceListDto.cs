using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow.Dtos
{
    [AutoMapFrom(typeof(TagTotalAppearance))]
    public class TagTotalAppearanceListDto: IDto
    {
        public string Tag { get; set; }
        public int Appearences { get; set; }
    }
}
