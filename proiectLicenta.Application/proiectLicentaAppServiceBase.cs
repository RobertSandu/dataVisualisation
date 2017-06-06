using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;
using Google.Apis.Services;
using proiectLicenta.MultiTenancy;
using proiectLicenta.Users;
using Microsoft.AspNet.Identity;

namespace proiectLicenta
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class proiectLicentaAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected proiectLicentaAppServiceBase()
        {
            LocalizationSourceName = proiectLicentaConsts.LocalizationSourceName;
        }

        // [START build_service]
        /// <summary>
        /// Creates an authorized Bigquery client service using Application
        /// Default Credentials.
        /// </summary>
        /// <returns>an authorized Bigquery client</returns>
        public BigqueryService CreateAuthorizedClient()
        {
            GoogleCredential credential =
                GoogleCredential.GetApplicationDefaultAsync().Result;

            // Inject the Bigquery scope if required.
            if (credential.IsCreateScopedRequired)
            {
                credential = credential.CreateScoped(new[]
                {
                    BigqueryService.Scope.Bigquery
                });
            }
            return new BigqueryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "DotNet Bigquery Samples",
            });
        }
        // [END build_service]

        public IList<TableRow> ExecuteQuery(string querySql, BigqueryService bigquery, string projectId)
        {
            var request = new Google.Apis.Bigquery.v2.JobsResource.QueryRequest(
                bigquery, new Google.Apis.Bigquery.v2.Data.QueryRequest()
                {
                    Query = querySql,
                }, projectId);
            var query = request.Execute();
            GetQueryResultsResponse queryResult = bigquery.Jobs.GetQueryResults(
                projectId, query.JobReference.JobId).Execute();
            return queryResult.Rows;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}