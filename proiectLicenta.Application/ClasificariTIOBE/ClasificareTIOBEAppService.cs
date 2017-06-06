using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using proiectLicenta.ClasificariTIOBE.Dtos;

namespace proiectLicenta.ClasificariTIOBE
{
    public class ClasificareTIOBEAppService : proiectLicentaAppServiceBase, IClasificareTIOBEAppService
    {
        private readonly IRepository<ClasificareTIOBE,Guid> _clasificareTiobeRepository;
        private readonly ICacheManager _cacheManager;

        public ClasificareTIOBEAppService(
            IRepository<ClasificareTIOBE, Guid> clasificareTiobeRepository,
            ICacheManager cacheManager
            )
        {
            //_clasificareTiobeManager = clasificareTiobeManager;
            _cacheManager = cacheManager;
            _clasificareTiobeRepository = clasificareTiobeRepository;
        }

        public ListResultOutput<ClasificareTIOBEListDto> GetList()
        {
            return _cacheManager
                .GetCache("cacheClasificareTiobeAppService")
                .Get("ClasificariTiobeCache", GetListFromDatabase);
        }

        public ListResultOutput<ClasificareTIOBEListDto> GetListFromDatabase()
        {
            var clasificariTIOBE =
                _clasificareTiobeRepository.GetAllList().OrderBy(x => x.TIOBEYear).ThenBy(x => x.TIOBEMonth);

            return new ListResultOutput<ClasificareTIOBEListDto>(clasificariTIOBE.MapTo<List<ClasificareTIOBEListDto>>());
        }
    }
}
