using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;
using Newtonsoft.Json;
using Octokit;
using proiectLicenta.DateGithub.Dtos;

namespace proiectLicenta.DateGithub
{
    public class DateGithubAppService : proiectLicentaAppServiceBase, IDateGithubAppService
    {
        private readonly ICacheManager _cacheManager;
        private readonly IRepository<GithubStatistic> _githubStatisticRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public DateGithubAppService(ICacheManager cacheManager, IRepository<GithubStatistic> githubStatisticRepository, IUnitOfWorkManager unitOfWorkManager)
        {

            _cacheManager = cacheManager;
            _githubStatisticRepository = githubStatisticRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task<string> ceva()
        {

            string githubApiToken = "9030077c0ec294b9eaed0e4b68f25afb5ce36fcf";

            var gitHubClient = new GitHubClient(ProductHeaderValue.Parse("proiectLicenta"));
            gitHubClient.Credentials = new Credentials(githubApiToken);

            var request = new SearchUsersRequest("RobertSandu");

            SearchUsersResult result = await gitHubClient.Search.SearchUsers(request);


            return "ceva";

        }

        public ListResultOutput<GithubRepoDetails> getTop10MostWatchedGithubRepos()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            IList<GithubRepoDetails> gitReposRootObjects = _cacheManager
                .GetCache("cacheDateGithubAppServiceTop10MostWatchedGithubRepos")
                .Get("getTop10MostWatchedGithubReposWithGithubApiData" + currentDate, getTop10MostWatchedGithubReposWithGithubApiData);


            return new ListResultOutput<GithubRepoDetails>(gitReposRootObjects.MapTo<List<GithubRepoDetails>>());

        }

        private IList<TableRow> getTop10MostWatchedGithubReposFromGoogleBigQuery()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            string sqlQuery = "SELECT repo.url, repo.name, COUNT(repo.name) as count FROM " +
                              "TABLE_DATE_RANGE([githubarchive:day.], " +
                              "TIMESTAMP('" + currentDate + "'), " +
                              "TIMESTAMP('" + currentDate + "') " +
                              ") " +
                              "WHERE type = 'WatchEvent' " +
                              "GROUP BY repo.id, repo.name, repo.url " +
                              "HAVING count >= 10 " +
                              "ORDER BY count DESC " +
                              "LIMIT 10 ";

            BigqueryService bigquery = CreateAuthorizedClient();
            IList<TableRow> rows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            return rows;

        }

        private IList<GithubRepoDetails> getTop10MostWatchedGithubReposWithGithubApiData()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            IList<TableRow> MostWatchedReposRows = _cacheManager
                .GetCache("cacheDateGithubAppServiceTop10MostWatchedGithubRepos")
                .Get("getTop10MostWatchedGithubReposFromGoogleBigQuery" + currentDate, getTop10MostWatchedGithubReposFromGoogleBigQuery);

            IList<GithubRepoDetails> gitReposRootObjects = new List<GithubRepoDetails>();


            foreach (TableRow row in MostWatchedReposRows)
            {
                var link = row.F[0].V.ToString();
                var name = row.F[1].V.ToString();
                var count = int.Parse(row.F[2].V.ToString());

                using (WebClient wc = new WebClient())
                {

                    try
                    {
                        wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0");

                        var githubRepoJSONData = wc.DownloadString(link + "?access_token=9030077c0ec294b9eaed0e4b68f25afb5ce36fcf");

                        var obj = JsonConvert.DeserializeObject<RootObject>(githubRepoJSONData);

                        GithubRepoDetails repoDetails = new GithubRepoDetails
                        {
                            root = obj,
                            link = link,
                            name = name,
                            count = count
                        };

                        gitReposRootObjects.Add(repoDetails);
                    }
                    catch (Exception e)
                    {

                    }

                }
            }

            return gitReposRootObjects;

        }

        public ListResultOutput<GithubRepoDetails> getTop10MostForkedGithubRepos()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            IList<GithubRepoDetails> gitReposRootObjects = _cacheManager
                .GetCache("cacheDateGithubAppServiceTop10MostWatchedGithubRepos")
                .Get("getTop10MostForkedGithubReposWithGithubApiData" + currentDate, getTop10MostForkedGithubReposWithGithubApiData);


            return new ListResultOutput<GithubRepoDetails>(gitReposRootObjects.MapTo<List<GithubRepoDetails>>());

        }


        private IList<TableRow> getTop10MostForkedGithubReposFromGoogleBigQuery()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            string sqlQuery = "SELECT repo.url, repo.name, COUNT(repo.name) as count FROM " +
                              "TABLE_DATE_RANGE([githubarchive:day.], " +
                              "TIMESTAMP('" + currentDate + "'), " +
                              "TIMESTAMP('" + currentDate + "') " +
                              ") " +
                              "WHERE type = 'ForkEvent' " +
                              "GROUP BY repo.id, repo.name, repo.url " +
                              "HAVING count >= 10 " +
                              "ORDER BY count DESC " +
                              "LIMIT 10 ";

            BigqueryService bigquery = CreateAuthorizedClient();
            IList<TableRow> rows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            return rows;

        }

        private IList<GithubRepoDetails> getTop10MostForkedGithubReposWithGithubApiData()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            IList<TableRow> MostWatchedReposRows = _cacheManager
                 .GetCache("cacheDateGithubAppServiceTop10MostWatchedGithubRepos")
                 .Get("getTop10MostForkedGithubReposFromGoogleBigQuery" + currentDate, getTop10MostForkedGithubReposFromGoogleBigQuery);

            IList<GithubRepoDetails> gitReposRootObjects = new List<GithubRepoDetails>();


            foreach (TableRow row in MostWatchedReposRows)
            {
                var link = row.F[0].V.ToString();
                var name = row.F[1].V.ToString();
                var count = int.Parse(row.F[2].V.ToString());

                using (WebClient wc = new WebClient())
                {

                    try
                    {
                        wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0");

                        var githubRepoJSONData = wc.DownloadString(link + "?access_token=9030077c0ec294b9eaed0e4b68f25afb5ce36fcf");

                        var obj = JsonConvert.DeserializeObject<RootObject>(githubRepoJSONData);

                        GithubRepoDetails repoDetails = new GithubRepoDetails
                        {
                            root = obj,
                            link = link,
                            name = name,
                            count = count
                        };

                        gitReposRootObjects.Add(repoDetails);
                    }
                    catch (Exception e)
                    {

                    }

                }
            }

            return gitReposRootObjects;

        }



        public ListResultOutput<GithubRepoDetails> getTop10MostIssuesGithubRepos()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            IList<GithubRepoDetails> gitReposRootObjects = _cacheManager
                .GetCache("cacheDateGithubAppServiceTop10MostWatchedGithubRepos")
                .Get("getTop10MostIssuesGithubReposWithGithubApiData" + currentDate, getTop10MostIssuesGithubReposWithGithubApiData);


            return new ListResultOutput<GithubRepoDetails>(gitReposRootObjects.MapTo<List<GithubRepoDetails>>());

        }


        private IList<TableRow> getTop10MostIssuesGithubReposFromGoogleBigQuery()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            string sqlQuery = "SELECT repo.url, repo.name, COUNT(repo.name) as count FROM " +
                              "TABLE_DATE_RANGE([githubarchive:day.], " +
                              "TIMESTAMP('" + currentDate + "'), " +
                              "TIMESTAMP('" + currentDate + "') " +
                              ") " +
                              "WHERE type = 'IssuesEvent' " +
                              "GROUP BY repo.id, repo.name, repo.url " +
                              "HAVING count >= 10 " +
                              "ORDER BY count DESC " +
                              "LIMIT 10 ";

            BigqueryService bigquery = CreateAuthorizedClient();
            IList<TableRow> rows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            return rows;

        }

        private IList<GithubRepoDetails> getTop10MostIssuesGithubReposWithGithubApiData()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            IList<TableRow> MostWatchedReposRows = _cacheManager
                 .GetCache("cacheDateGithubAppServiceTop10MostWatchedGithubRepos")
                 .Get("getTop10MostIssuesGithubReposFromGoogleBigQuery" + currentDate, getTop10MostIssuesGithubReposFromGoogleBigQuery);

            IList<GithubRepoDetails> gitReposRootObjects = new List<GithubRepoDetails>();


            foreach (TableRow row in MostWatchedReposRows)
            {
                var link = row.F[0].V.ToString();
                var name = row.F[1].V.ToString();
                var count = int.Parse(row.F[2].V.ToString());

                using (WebClient wc = new WebClient())
                {

                    try
                    {
                        wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0");

                        var githubRepoJSONData = wc.DownloadString(link + "?access_token=9030077c0ec294b9eaed0e4b68f25afb5ce36fcf");

                        var obj = JsonConvert.DeserializeObject<RootObject>(githubRepoJSONData);

                        GithubRepoDetails repoDetails = new GithubRepoDetails
                        {
                            root = obj,
                            link = link,
                            name = name,
                            count = count
                        };

                        gitReposRootObjects.Add(repoDetails);
                    }
                    catch (Exception e)
                    {

                    }

                }
            }

            return gitReposRootObjects;

        }

        public ListResultOutput<GithubRepoDetails> getTop10MostMembersGithubRepos()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            IList<GithubRepoDetails> gitReposRootObjects = _cacheManager
                .GetCache("cacheDateGithubAppServiceTop10MostWatchedGithubRepos")
                .Get("getTop10MostMembersGithubReposWithGithubApiData" + currentDate, getTop10MostMembersGithubReposWithGithubApiData);


            return new ListResultOutput<GithubRepoDetails>(gitReposRootObjects.MapTo<List<GithubRepoDetails>>());

        }


        private IList<TableRow> getTop10MostMembersGithubReposFromGoogleBigQuery()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            string sqlQuery = "SELECT repo.url, repo.name, COUNT(repo.name) as count FROM " +
                              "TABLE_DATE_RANGE([githubarchive:day.], " +
                              "TIMESTAMP('" + currentDate + "'), " +
                              "TIMESTAMP('" + currentDate + "') " +
                              ") " +
                              "WHERE type = 'MemberEvent' " +
                              "GROUP BY repo.id, repo.name, repo.url " +
                              "HAVING count >= 10 " +
                              "ORDER BY count DESC " +
                              "LIMIT 10 ";

            BigqueryService bigquery = CreateAuthorizedClient();
            IList<TableRow> rows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            return rows;

        }

        [UnitOfWork]
        private IList<GithubRepoDetails> getTop10MostMembersGithubReposWithGithubApiData()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            IList<TableRow> MostWatchedReposRows = _cacheManager
                 .GetCache("cacheDateGithubAppServiceTop10MostWatchedGithubRepos")
                 .Get("getTop10MostMembersGithubReposFromGoogleBigQuery" + currentDate, getTop10MostMembersGithubReposFromGoogleBigQuery);

            IList<GithubRepoDetails> gitReposRootObjects = new List<GithubRepoDetails>();


            foreach (TableRow row in MostWatchedReposRows)
            {
                var link = row.F[0].V.ToString();
                var name = row.F[1].V.ToString();
                var count = int.Parse(row.F[2].V.ToString());

                using (WebClient wc = new WebClient())
                {

                    try
                    {
                        wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0");

                        var githubRepoJSONData = wc.DownloadString(link + "?access_token=9030077c0ec294b9eaed0e4b68f25afb5ce36fcf");

                        var obj = JsonConvert.DeserializeObject<RootObject>(githubRepoJSONData);

                        GithubRepoDetails repoDetails = new GithubRepoDetails
                        {
                            root = obj,
                            link = link,
                            name = name,
                            count = count
                        };

                        gitReposRootObjects.Add(repoDetails);
                    }
                    catch (Exception e)
                    {
                        
                    }

                }
            }

            return gitReposRootObjects;

        }

        
        public GithubStatisticDto getGithubStatistic()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            var queryGithubStatistic =
                _githubStatisticRepository.GetAll()
                    .Where(x => x.StatisticDateTime.Year == currentDateTime.Year && x.StatisticDateTime.Month == currentDateTime.Month && x.StatisticDateTime.Day == currentDateTime.Day);

            if (!queryGithubStatistic.Any())
            {

                //ohterwise we must load the current day data from google big query
                //and compute the differences

                computeGithubStatisticData();

                queryGithubStatistic =
                _githubStatisticRepository.GetAll()
                    .Where(x => x.StatisticDateTime.Year == currentDateTime.Year && x.StatisticDateTime.Month == currentDateTime.Month && x.StatisticDateTime.Day == currentDateTime.Day);

            }

            var githubStatisticDataList = queryGithubStatistic.ToList().Take(1);
            GithubStatisticDto githubStatisticData = githubStatisticDataList.ElementAt(0).MapTo<GithubStatisticDto>();

            return githubStatisticData;

           // return new ListResultOutput<GithubStatisticDto>(githubStatisticData.MapTo<List<GithubStatisticDto>>());

        }

        [UnitOfWork]
        private void computeGithubStatisticData()
        {

            DateTime currentDateTime = DateTime.UtcNow.AddDays(-1);

            string currentDate = currentDateTime.Year + "-" + currentDateTime.Month + "-" + currentDateTime.Day;

            BigqueryService bigquery = CreateAuthorizedClient();

            /*  CreateEventCount
             *  ForkEventCount
             *  IssuesEventCount
             *  MemberEventCount
             *  PullRequestCount
             *  PushEventCount
             *  WatchEventCount  */

            string sqlQuery = "SELECT COUNT(*) as count FROM " +
                              "TABLE_DATE_RANGE([githubarchive:day.], " +
                              "TIMESTAMP('" + currentDate + "'), " +
                              "TIMESTAMP('" + currentDate + "') " +
                              ") " +
                              "WHERE type = 'CreateEvent' ";

            IList<TableRow> createEventRows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            int createEventCout = 0;
            double? createEventAverage =
                _githubStatisticRepository.GetAll().Average(x => x.CreateEventCount);

            if (createEventRows.Count > 0)
            {

                createEventCout = Int32.Parse(createEventRows[0].F[0].V.ToString());

            }

            double createEventChange = 0;

            if (createEventAverage.HasValue)
            {
                createEventChange = ((double)createEventCout - (double)createEventAverage) /
                                    (double)createEventAverage;

            }

            sqlQuery = "SELECT COUNT(repo.name) as count FROM " +
                       "TABLE_DATE_RANGE([githubarchive:day.], " +
                       "TIMESTAMP('" + currentDate + "'), " +
                       "TIMESTAMP('" + currentDate + "') " +
                       ") " +
                       "WHERE type = 'ForkEvent' ";

            IList<TableRow> forkEventRows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            int forkEventCout = 0;
            double? forkEventAverage = _githubStatisticRepository.GetAll().Average(x => x.ForkEventCount);

            if (forkEventRows.Count > 0)
            {

                forkEventCout = Int32.Parse(forkEventRows[0].F[0].V.ToString());

            }

            double forkEventChange = 0;

            if (forkEventAverage.HasValue)
            {
                forkEventChange = ((double)forkEventCout - (double)forkEventAverage) /
                                    (double)forkEventAverage;

            }

            sqlQuery = "SELECT COUNT(repo.name) as count FROM " +
                       "TABLE_DATE_RANGE([githubarchive:day.], " +
                       "TIMESTAMP('" + currentDate + "'), " +
                       "TIMESTAMP('" + currentDate + "') " +
                       ") " +
                       "WHERE type = 'IssuesEvent' ";

            IList<TableRow> issuesEventRows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            int issuesEventCout = 0;
            double? issuesEventAverage = _githubStatisticRepository.GetAll().Average(x => x.IssuesEventCount);

            if (issuesEventRows.Count > 0)
            {

                issuesEventCout = Int32.Parse(issuesEventRows[0].F[0].V.ToString());

            }

            double issuesEventChange = 0;

            if (issuesEventAverage.HasValue)
            {
                issuesEventChange = ((double)issuesEventCout - (double)issuesEventAverage) /
                                    (double)issuesEventAverage;

            }

            sqlQuery = "SELECT COUNT(repo.name) as count FROM " +
                       "TABLE_DATE_RANGE([githubarchive:day.], " +
                       "TIMESTAMP('" + currentDate + "'), " +
                       "TIMESTAMP('" + currentDate + "') " +
                       ") " +
                       "WHERE type = 'MemberEvent' ";

            IList<TableRow> memberEventRows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            int memberEventCout = 0;
            double? memberEventAverage = _githubStatisticRepository.GetAll().Average(x => x.MemberEventCount);

            if (memberEventRows.Count > 0)
            {

                memberEventCout = Int32.Parse(memberEventRows[0].F[0].V.ToString());

            }

            double memberEventChange = 0;

            if (memberEventAverage.HasValue)
            {
                memberEventChange = ((double)memberEventCout - (double)memberEventAverage) /
                                    (double)memberEventAverage;

            }

            /*sqlQuery = "SELECT COUNT(repo.name) as count FROM " +
                       "TABLE_DATE_RANGE(githubarchive:day.events_, " +
                       "TIMESTAMP('" + currentDate + "'), " +
                       "TIMESTAMP('" + currentDate + "') " +
                       ") " +
                       "WHERE type = 'PullRequestEvent' ";

            IList<TableRow> pullEventRows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            int pullEventCout = 0;
            double? pullEventAverage = _githubStatisticRepository.GetAll().Select(x => x.PullRequestCount).Average();

            if (pullEventRows.Count > 0)
            {

                pullEventCout = Int32.Parse(pullEventRows[0].F[0].V.ToString());

            }

            double pullEventChange = 0;

            if (pullEventAverage.HasValue)
            {
                pullEventChange = ((double)pullEventCout - (double)pullEventAverage) /
                                    (double)pullEventAverage;

            }*/

            sqlQuery = "SELECT COUNT(repo.name) as count FROM " +
                       "TABLE_DATE_RANGE([githubarchive:day.], " +
                       "TIMESTAMP('" + currentDate + "'), " +
                       "TIMESTAMP('" + currentDate + "') " +
                       ") " +
                       "WHERE type = 'PushEvent' ";

            IList<TableRow> pushEventRows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            int pushEventCout = 0;
            double? pushEventAverage = _githubStatisticRepository.GetAll().Average(x => x.PushEventCount);

            if (pushEventRows.Count > 0)
            {

                pushEventCout = int.Parse(pushEventRows[0].F[0].V.ToString());

            }

            double pushEventChange = 0;

            if (pushEventAverage.HasValue)
            {
                pushEventChange = ((double)pushEventCout - (double)pushEventAverage) /
                                    (double)pushEventAverage;

            }

            sqlQuery = "SELECT COUNT(repo.name) as count FROM " +
                       "TABLE_DATE_RANGE([githubarchive:day.], " +
                       "TIMESTAMP('" + currentDate + "'), " +
                       "TIMESTAMP('" + currentDate + "') " +
                       ") " +
                       "WHERE type = 'WatchEvent' ";

            IList<TableRow> watchEventRows = ExecuteQuery(sqlQuery, bigquery, "proiectlicentbigquerry");

            int watchEventCout = 0;
            double? watchEventAverage = _githubStatisticRepository.GetAll().Average(x => x.WatchEventCount);

            if (watchEventRows.Count > 0)
            {

                watchEventCout = Int32.Parse(watchEventRows[0].F[0].V.ToString());

            }

            double watchEventChange = 0;

            if (watchEventAverage.HasValue)
            {
                watchEventChange = ((double)watchEventCout - (double)watchEventAverage) /
                                    (double)watchEventAverage;

            }


            _githubStatisticRepository.Insert(new GithubStatistic
            {
                StatisticDateTime = DateTime.UtcNow.AddDays(-1),

                CreateEventCount = createEventCout,
                ForkEventCount = forkEventCout,
                IssuesEventCount = issuesEventCout,
                MemberEventCount = memberEventCout,
                PullRequestCount = 0,
                PushEventCount = pushEventCout,
                WatchEventCount = watchEventCout,

                CreateEventProcentualDifference = createEventChange * 100,
                ForkEventProcentualDifference = forkEventChange * 100,
                IssuesEventProcentualDifference = issuesEventChange * 100,
                MemberEventProcentualDifference = memberEventChange * 100,
                PullRequestProcentualDifference = 0 * 100,
                PushEventProcentualDifference = pushEventChange * 100,
                WatchEventProcentualDifference = watchEventChange * 100


            });

            _unitOfWorkManager.Current.SaveChanges();

        }

    }
}
