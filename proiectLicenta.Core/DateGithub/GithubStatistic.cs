using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace proiectLicenta.DateGithub
{
    public class GithubStatistic: Entity
    {
        public DateTime StatisticDateTime { get; set; }

        public int? CreateEventCount { get; set; }

        public int? ForkEventCount { get; set; }

        public int? IssuesEventCount { get; set; }

        public int? MemberEventCount { get; set; }

        public int? PullRequestCount { get; set; }

        public int? PushEventCount { get; set; }

        public int? WatchEventCount { get; set; }


        public double? CreateEventProcentualDifference { get; set; }

        public double? ForkEventProcentualDifference { get; set; }

        public double? IssuesEventProcentualDifference { get; set; }

        public double? MemberEventProcentualDifference { get; set; }

        public double? PullRequestProcentualDifference { get; set; }

        public double? PushEventProcentualDifference { get; set; }

        public double? WatchEventProcentualDifference { get; set; }

    }
}
