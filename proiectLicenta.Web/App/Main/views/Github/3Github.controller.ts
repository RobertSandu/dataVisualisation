module app.Github {

    'use strict';

    /*
        
    */
    interface IMostRepos {

        items: IGithubData[];
        
    }

    interface IGithubStatisticsController {

        githubStatisticsData: GithubStatistic

    }

    class GithubStatisticsController implements IGithubStatisticsController {

        static $inject = [
            'app.Github.GithubService'
            , '$scope'
        ];

        githubStatisticsData: GithubStatistic;

        constructor(private GithubService: app.Github.IGithubService,
            private scope: angular.IScope
        ) {

            GithubService.getGithubStatistic()
                .then((data: app.Github.GithubStatistic): void => {

                    this.githubStatisticsData = data;
                    console.log('data');
                    console.log(data);

                });

        }

    }

    class MostWatchedRepos implements IMostRepos{

        static $inject = [
            'app.Github.GithubService'
            , '$scope'
        ];

        items: IGithubData[];

        constructor(private GithubService: app.Github.IGithubService,
            private scope: angular.IScope
        ) {

            GithubService.getTop10MostWatchedRepos()
                .then((data: app.Github.IGithubAppServiceResponseData):void => {

                    this.items = data.items;

                });

        }

    }

    class MostForkedRepos implements IMostRepos {

        static $inject = [
            'app.Github.GithubService'
            , '$scope'
        ];

        items: IGithubData[];

        constructor(private GithubService: app.Github.IGithubService,
            private scope: angular.IScope
        ) {

            GithubService.getTop10MostForkedRepos()
                .then((data: app.Github.IGithubAppServiceResponseData): void => {

                    console.log('data.items');
                    console.log(data.items);

                    this.items = data.items;

                });

        }

    }

    class MostIssuesRepos implements IMostRepos {

        static $inject = [
            'app.Github.GithubService'
            , '$scope'
        ];

        items: IGithubData[];

        constructor(private GithubService: app.Github.IGithubService,
            private scope: angular.IScope

        ) {

            GithubService.getTop10MostIssuesRepos()
                .then((data: app.Github.IGithubAppServiceResponseData): void => {

                    this.items = data.items;

                });

        }

    }

    class MostMembersRepos implements IMostRepos {

        static $inject = [
            'app.Github.GithubService'
            , '$scope'
        ];

        items: IGithubData[];

        constructor(private GithubService: app.Github.IGithubService,
            private scope: angular.IScope
        ) {

            GithubService.getTop10MostMembersRepos()
                .then((data: app.Github.IGithubAppServiceResponseData): void => {

                    this.items = data.items;

                });

        }

    } 

    angular.module('app.Github')
        .controller('app.Github.MostWatchedRepos', MostWatchedRepos);

    angular.module('app.Github')
        .controller('app.Github.MostForkedRepos', MostForkedRepos);

    angular.module('app.Github')
        .controller('app.Github.MostIssuesRepos', MostIssuesRepos);

    angular.module('app.Github')
        .controller('app.Github.MostMembersRepos', MostMembersRepos);

    angular.module('app.Github')
        .controller('app.Github.GithubStatisticsController', GithubStatisticsController);

}