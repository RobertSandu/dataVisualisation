module app.Github {
    'use strict';

    export interface IGithubPermissions {

        admin: boolean;
        push: boolean;
        pull: boolean;

    }

    export interface IGithubOwner {

        login: string;
        id: number;
        avatar_url: string;
        gravatar_id: string;
        url: string;
        html_url: string;
        followers_url: string;
        following_url: string;
        gists_url: string;
        starred_url: string;
        subscriptions_url: string;
        organizations_url: string;
        repos_url: string;
        events_url: string;
        received_events_url: string;
        type: string;
        site_admin: boolean;

    }

    export interface GithubStatistic {
        StatisticDateTime: Date;
        CreateEventCount: number;
        ForkEventCount: number;
        IssuesEventCount: number;
        MemberEventCount: number;
        PullRequestCount: number;
        PushEventCount: number;
        WatchEventCount: number;
        CreateEventProcentualDifference: number;
        ForkEventProcentualDifference: number;
        IssuesEventProcentualDifference: number;
        MemberEventProcentualDifference: number;
        PullRequestProcentualDifference: number;
        PushEventProcentualDifference: number;
        WatchEventProcentualDifference: number;
    }

    export interface IGithubRoot {

        owner: IGithubOwner;
        permissions: IGithubPermissions;
        id: number;
        name: string;
        full_name: string;
        private: boolean;
        html_url: string;
        description: string;
        fork: boolean;
        url: string;
        forks_url: string;
        keys_url: string;
        collaborators_url: string;
        teams_url: string;
        hooks_url: string;
        issue_events_url: string;
        events_url: string;
        assignees_url: string;
        branches_url: string;
        tags_url: string;
        blobs_url: string;
        git_tags_url: string;
        git_refs_url: string;
        trees_url: string;
        statuses_url: string;
        languages_url: string;
        stargazers_url: string;
        contributors_url: string;
        subscribers_url: string;
        subscription_url: string;
        commits_url: string;
        git_commits_url: string;
        comments_url: string;
        issue_comment_url: string;
        contents_url: string;
        compare_url: string;
        merges_url: string;
        archive_url: string;
        downloads_url: string;
        issues_url: string;
        pulls_url: string;
        milestones_url: string;
        notifications_url: string;
        labels_url: string;
        releases_url: string;
        deployments_url: string;
        created_at: string;
        updated_at: string;
        pushed_at: string;
        git_url: string;
        ssh_url: string;
        clone_url: string;
        svn_url: string;
        homepage: string;
        size: number;
        stargazers_count: number;
        watchers_count: number;
        language: string;
        has_issues: boolean;
        has_downloads: boolean;
        has_wiki: boolean;
        has_pages: boolean;
        forks_count: number;
        mirror_url: Object;
        open_issues_count: number;
        forks: number;
        open_issues: number;
        watchers: number;
        default_branch: string;
        network_count: number;
        subscribers_count: number;

    }

    export interface IGithubData {

        root: IGithubRoot;
        link: string;
        name: string;
        count: number;

    }


    export interface IGithubAppServiceResponseData {

        items: IGithubData[];

    }

    export interface IGithubService {

        getTop10MostWatchedRepos(): angular.IPromise<IGithubAppServiceResponseData>;

        getTop10MostForkedRepos(): angular.IPromise<IGithubAppServiceResponseData>;

        getTop10MostIssuesRepos(): angular.IPromise<IGithubAppServiceResponseData>;

        getTop10MostMembersRepos(): angular.IPromise<IGithubAppServiceResponseData>;

        getGithubStatistic(): angular.IPromise<GithubStatistic>;

    }

    class GithubService implements IGithubService {

        static $inject = ['$http'];

        constructor(private $http: angular.IHttpService) { }

        getTop10MostWatchedRepos(): angular.IPromise<IGithubAppServiceResponseData> {

            return this.$http.get('api/services/app/dateGithub/getTop10MostWatchedGithubRepos')
                .then((response: angular.IHttpPromiseCallbackArg<IGithubAppServiceResponseData>): IGithubAppServiceResponseData => {

                    return response.data;

                });

        }

        getTop10MostForkedRepos(): angular.IPromise<IGithubAppServiceResponseData> {

            return this.$http.get('api/services/app/dateGithub/getTop10MostForkedGithubRepos')
                .then((response: angular.IHttpPromiseCallbackArg<IGithubAppServiceResponseData>): IGithubAppServiceResponseData => {

                    return response.data;

                });

        }

        getTop10MostIssuesRepos(): angular.IPromise<IGithubAppServiceResponseData> {

            return this.$http.get('api/services/app/dateGithub/getTop10MostIssuesGithubRepos')
                .then((response: angular.IHttpPromiseCallbackArg<IGithubAppServiceResponseData>): IGithubAppServiceResponseData => {

                    return response.data;

                });

        }

        getTop10MostMembersRepos(): angular.IPromise<IGithubAppServiceResponseData> {

            return this.$http.get('api/services/app/dateGithub/getTop10MostMembersGithubRepos')
                .then((response: angular.IHttpPromiseCallbackArg<IGithubAppServiceResponseData>): IGithubAppServiceResponseData => {

                    return response.data;

                });

        }

        getGithubStatistic(): angular.IPromise<GithubStatistic> {

            return this.$http.get('api/services/app/dateGithub/getGithubStatistic')
                .then((response: angular.IHttpPromiseCallbackArg<GithubStatistic>): GithubStatistic => {

                    return response.data;

                });

        }

    }

    angular.module("app.Github")
        .service('app.Github.GithubService', GithubService);

}