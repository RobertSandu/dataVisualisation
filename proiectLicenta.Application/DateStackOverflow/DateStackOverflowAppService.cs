using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.BackgroundJobs;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Abp.UI;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;
using Google.Apis.Services;
using proiectLicenta.DateStackOverflow.Dtos;

namespace proiectLicenta.DateStackOverflow
{
    public class DateStackOverflowAppService: proiectLicentaAppServiceBase, IDateStackOverflowAppService
    {
        private readonly IRepository<TagAppearance> _tagAppearancesRepository;
        private readonly IRepository<TagTotalAppearance> _tagTotalAppearanceRepository;
        private readonly IRepository<USAUsersCount> _usaUsersCountsRepository;
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly IRepository<WorldUsersCount> _worldUsersCountsRepository;
        private readonly IRepository<AnswersPerDay> _answersPerDayRepository;
        private readonly IRepository<AnswersPerHour> _answersPerHourRepository;
        private readonly IRepository<AnswersPerDayAndHour> _answersPerDayAndHourRepository;

        public DateStackOverflowAppService(
            IRepository<TagAppearance> tagAppearancesRepository
            , IRepository<TagTotalAppearance> tagTotalAppearanceRepository
            , IBackgroundJobManager backgroundJobManager
            , IRepository<USAUsersCount> usaUsersCountsRepository
            , IRepository<WorldUsersCount> worldUsersCountsRepository
            , IRepository<AnswersPerDay> answersPerDayRepository
            , IRepository<AnswersPerHour> answersPerHourRepository
            , IRepository<AnswersPerDayAndHour> answersPerDayAndHourRepository)
        {

            _tagAppearancesRepository = tagAppearancesRepository;
            _tagTotalAppearanceRepository = tagTotalAppearanceRepository;
            _backgroundJobManager = backgroundJobManager;
            _usaUsersCountsRepository = usaUsersCountsRepository;
            _worldUsersCountsRepository = worldUsersCountsRepository;
            _answersPerDayRepository = answersPerDayRepository;
            _answersPerHourRepository = answersPerHourRepository;
            _answersPerDayAndHourRepository = answersPerDayAndHourRepository;

        }

        public ListResultOutput<TagAppearanceListDto> GetList()
        {
            
            if (_tagAppearancesRepository.GetAll().Any())
            {
                var rezultate = _tagAppearancesRepository.GetAll().OrderByDescending(x => x.Appearences).Take(40).ToList();
                return new ListResultOutput<TagAppearanceListDto>(rezultate.MapTo<List<TagAppearanceListDto>>());

            }
            else
            {
                _backgroundJobManager.Enqueue<CalculateTagAppearancesJob, int>(12);
                return new ListResultOutput<TagAppearanceListDto>();
            }
        }

        public ListResultOutput<TagTotalAppearanceListDto> GetTagTotalAppearancesList()
        {
            var result = _tagTotalAppearanceRepository.GetAll().OrderByDescending(x => x.Appearences).Take(20).ToList();
            return new ListResultOutput<TagTotalAppearanceListDto>(result.MapTo<List<TagTotalAppearanceListDto>>());
        }

        public ListResultOutput<TagTotalAppearanceListDto> GetAllTagTotalAppearancesList()
        {
            var result = _tagTotalAppearanceRepository.GetAll().OrderByDescending(x => x.Appearences).ToList();
            return new ListResultOutput<TagTotalAppearanceListDto>(result.MapTo<List<TagTotalAppearanceListDto>>());
        }

        public TagTotalAppearanceListDto getTagTotalAppearencesByName(string TagName)
        {
            var result = _tagTotalAppearanceRepository.FirstOrDefault(x => string.Equals(x.Tag, TagName));
            return result.MapTo<TagTotalAppearanceListDto>();
        }

        public ListResultOutput<USAUsersCountListDto> getAllUsaStates()
        {
            var usaStates =  _usaUsersCountsRepository.GetAll().ToList();
            return new ListResultOutput<USAUsersCountListDto>(usaStates.MapTo<List<USAUsersCountListDto>>());
        }

        public ListResultOutput<WorldUsersCountListDto> getAllWorldData()
        {
            var worldData = _worldUsersCountsRepository.GetAll().ToList();
            return new ListResultOutput<WorldUsersCountListDto>(worldData.MapTo<List<WorldUsersCountListDto>>());
        }

        public ListResultOutput<AnswersPerDayListDto> getAllWAnswersPerDay()
        {
            var answersPerDay = _answersPerDayRepository.GetAll().OrderBy(x => x.Day).ToList();
            return new ListResultOutput<AnswersPerDayListDto>(answersPerDay.MapTo<List<AnswersPerDayListDto>>());
        }

        public ListResultOutput<AnswersPerHourListDto> getAllWAnswersPerHour()
        {
            var answersPerHour = _answersPerHourRepository.GetAll().OrderBy(x => x.Hour).ToList();
            return new ListResultOutput<AnswersPerHourListDto>(answersPerHour.MapTo<List<AnswersPerHourListDto>>());
        }

        public ListResultOutput<AnswersPerDayAndHourListDto> getAllWAnswersPerDayAndHour()
        {
            var answersPerDayAndHour = _answersPerDayAndHourRepository.GetAll().OrderBy(x => x.Day).ThenBy(x => x.Hour).ToList();

            return new ListResultOutput<AnswersPerDayAndHourListDto>(answersPerDayAndHour.MapTo<List<AnswersPerDayAndHourListDto>>());
        }
    }
}
