using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using proiectLicenta.ClasificariTIOBE.Dtos;

namespace proiectLicenta.ClasificariTIOBE
{
    public interface IClasificareTIOBEAppService : IApplicationService
    {
        [HttpGet]
        [DontWrapResult]
        ListResultOutput<ClasificareTIOBEListDto> GetList();
        ListResultOutput<ClasificareTIOBEListDto> GetListFromDatabase();
    }
}
