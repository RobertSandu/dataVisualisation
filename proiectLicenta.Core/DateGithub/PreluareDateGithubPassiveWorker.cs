using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace proiectLicenta.DateGithub
{
    public class PreluareDateGithubPassiveWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private IRepository<RulareJobDateGithub, Guid> _rulareJobDateGithubRepository; 

        public PreluareDateGithubPassiveWorker(AbpTimer timer, IRepository<RulareJobDateGithub, Guid> rulareJobDateGithubRepository) 
            : base(timer)
        {
            Timer.Period = 1000 * 60 * 60; //5 seconds (good for tests, but normally will be more)

            rulareJobDateGithubRepository = _rulareJobDateGithubRepository;
        }

        [UnitOfWork]
        protected override void DoWork()
        {
            using (var client = new WebClient())
            {
                string caleFisier =
                    "C:\\Users\\rober\\Documents\\Visual Studio 2015\\Projects\\proiectLicenta\\proiectLicenta.Core\\DateGithub\\date.json.gz";
                string caleFisierDecompressed =  "C:\\Users\\rober\\Documents\\Visual Studio 2015\\Projects\\proiectLicenta\\proiectLicenta.Core\\DateGithub\\date.json";

                client.DownloadFile("http://data.githubarchive.org/2015-01-01-15.json.gz", caleFisier);
                using (FileStream fileStreamGithub = new FileStream(caleFisier, FileMode.Open))
                {
                    using (FileStream fileStreamGithubDecompresat = File.Create(caleFisierDecompressed))
                    {
                        using (GZipStream streamDecompresie = new GZipStream(fileStreamGithub, CompressionMode.Decompress))
                        {
                            streamDecompresie.CopyTo(fileStreamGithubDecompresat);
                        }
                    }
                }
            }

            //using (StreamReader file = File.OpenText(@"C:\Users\rober\Documents\Visual Studio 2015\Projects\proiectLicenta\proiectLicenta.Core\DateGithub\date.json"))
            //{
            //    using (JsonTextReader reader = new JsonTextReader(file))
            //    {


            //        JObject o2 = (JObject)JToken.ReadFrom(reader);

            //        JsonSerializer se = new JsonSerializer();
            //        object parsedData = se.Deserialize(reader);

            //        o2.AsJEnumerable().Where(x => x.Value<String>(""))

            //        foreach (KeyValuePair<string, JToken> VARIABLE in o2)
            //        {
            //            int ceva = 32;
            //        }
            //    }
            //}

        }
    }
}
