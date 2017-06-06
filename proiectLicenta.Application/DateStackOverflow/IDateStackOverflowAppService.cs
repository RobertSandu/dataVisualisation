using System;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using proiectLicenta.DateStackOverflow.Dtos;

namespace proiectLicenta.DateStackOverflow
{
    public interface IDateStackOverflowAppService: IApplicationService
    {
        [HttpGet]
        [DontWrapResult]
        ListResultOutput<TagAppearanceListDto> GetList();

        [HttpGet]
        [DontWrapResult]
        ListResultOutput<TagTotalAppearanceListDto> GetTagTotalAppearancesList();

        [HttpGet]
        [DontWrapResult]
        ListResultOutput<TagTotalAppearanceListDto> GetAllTagTotalAppearancesList();

        [HttpGet]
        [DontWrapResult]
        TagTotalAppearanceListDto getTagTotalAppearencesByName(string TagName);

        [HttpGet]
        [DontWrapResult]
        ListResultOutput<USAUsersCountListDto> getAllUsaStates();
        [HttpGet]
        [DontWrapResult]
        ListResultOutput<WorldUsersCountListDto> getAllWorldData();
        [HttpGet]
        [DontWrapResult]
        ListResultOutput<AnswersPerDayListDto> getAllWAnswersPerDay();
        [HttpGet]
        [DontWrapResult]
        ListResultOutput<AnswersPerHourListDto> getAllWAnswersPerHour();
        [HttpGet]
        [DontWrapResult]
        ListResultOutput<AnswersPerDayAndHourListDto> getAllWAnswersPerDayAndHour();

    }
}
