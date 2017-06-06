using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Abp.Web.Models;
using Google.Apis.Bigquery.v2.Data;
using proiectLicenta.DateGithub.Dtos;

namespace proiectLicenta.DateGithub
{
    public interface IDateGithubAppService : IApplicationService
    {

        [HttpGet]
        [DontWrapResult]
        ListResultOutput<GithubRepoDetails> getTop10MostWatchedGithubRepos();

        [HttpGet]
        [DontWrapResult]
        ListResultOutput<GithubRepoDetails> getTop10MostForkedGithubRepos();

        [HttpGet]
        [DontWrapResult]
        ListResultOutput<GithubRepoDetails> getTop10MostIssuesGithubRepos();

        [HttpGet]
        [DontWrapResult]
        ListResultOutput<GithubRepoDetails> getTop10MostMembersGithubRepos();

        [HttpGet]
        [DontWrapResult]
        [UnitOfWork]
        GithubStatisticDto getGithubStatistic();

        [HttpGet]
        [DontWrapResult]
        Task<string> ceva();

    }
}
