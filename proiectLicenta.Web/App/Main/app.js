(function () {
    'use strict';
    
    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'LocalStorageModule',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',
        'rzModule',
        'isteven-multi-select',

        'abp'
        , 'app.clasificareTIOBE'
        , 'app.StackOverflow'
        , 'app.Github'
        , 'chart.js'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', 'ChartJsProvider', 'localStorageServiceProvider',
        function ($stateProvider, $urlRouterProvider, ChartJsProvider, localStorageServiceProvider) {
            $urlRouterProvider.otherwise('/');

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in proiectLicentaNavigationProvider
                    });
                $urlRouterProvider.otherwise('/tenants');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in proiectLicentaNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in proiectLicentaNavigationProvider
                })
                .state('vizualizareClasificareTIOBEMultilineSeries', {
                    url: '/vizualizareClasificareTIOBEMultilineSeries',
                    templateUrl: '/App/Main/views/ClasificareTIOBE/ClasificareTIOBE.cshtml',
                    menu: 'Clasificare TIOBE Multiline Series' //Matches to name of 'Clasificare TIOBE Multiline Series' menu in proiectLicentaNavigationProvider
                })
                .state('vizualizareClasificareTIOBEDonutChart', {
                    url: '/vizualizareClasificareTIOBEDonutChart',
                    templateUrl: '/App/Main/views/ClasificareTIOBE/ClasificareTIOBEDonut.cshtml',
                    menu: 'Clasificare TIOBE Donut Chart' //Matches to name of 'Clasificare TIOBE Multiline Series' menu in proiectLicentaNavigationProvider
                }).state('vizualizareClasificareTaguriStackOverflow', {
                    url: '/vizualizareClasificareTaguriStackOverflow',
                    templateUrl: '/App/Main/views/StackOverflow/clasificareTaguri.cshtml',
                    menu: 'Clasificare Tag-uri' //Matches to name of 'Clasificare Tag-uri' menu in proiectLicentaNavigationProvider
                }).state('vizualizareRelatiiTaguriStackOverflow', {
                    url: '/vizualizareRelatiiTaguriStackOverflow',
                    templateUrl: '/App/Main/views/StackOverflow/relatiiTaguri.cshtml',
                    menu: 'Relatii Tag-uri' //Matches to name of 'Relatii Tag-uri' menu in proiectLicentaNavigationProvider
                }).state('vizualizareUtilizatoriStateleUnite', {
                    url: '/vizualizareUtilizatoriStateleUnite',
                    templateUrl: '/App/Main/views/StackOverflow/usaUsers.cshtml',
                    menu: 'Vizualizare utilizatori Statele Unite' //Matches to name of 'Vizualizare utilizatori Statele Unite' menu in proiectLicentaNavigationProvider
                }).state('vizualizareUtilizatoriGlobal', {
                    url: '/vizualizareUtilizatoriGlobal',
                    templateUrl: '/App/Main/views/StackOverflow/worldUsers.cshtml',
                    menu: 'Vizualizare utilizatori global' //Matches to name of 'Vizualizare utilizatori global' menu in proiectLicentaNavigationProvider
                }).state('mostWatchedGithubRepos', {
                    url: '/mostWatchedGithubRepos',
                    templateUrl: '/App/Main/views/Github/watchedGithubRepos.cshtml',
                    menu: 'Cele mai urmarite repouri' //Matches to name of 'Cele mai urmarite repouri' menu in proiectLicentaNavigationProvider
                }).state('mostForkedGithubRepos', {
                    url: '/mostForkedGithubRepos',
                    templateUrl: '/App/Main/views/Github/forkedGithubRepos.cshtml',
                    menu: 'Cele mai ramificate (forked) repouri' //Matches to name of 'Cele mai urmarite repouri' menu in proiectLicentaNavigationProvider
                }).state('mostIssuesGithubRepos', {
                    url: '/mostIssuesGithubRepos',
                    templateUrl: '/App/Main/views/Github/issuesGithubRepos.cshtml',
                    menu: 'Cele mai multe tichete' //Matches to name of 'Cele mai urmarite repouri' menu in proiectLicentaNavigationProvider
                }).state('mostMembersGithubRepos', {
                    url: '/mostMembersGithubRepos',
                    templateUrl: '/App/Main/views/Github/membersGithubRepos.cshtml',
                    menu: 'Cei mai multi membri' //Matches to name of 'Cele mai urmarite repouri' menu in proiectLicentaNavigationProvider
                }).state('githubStatistics', {
                    url: '/githubStatistics',
                    templateUrl: '/App/Main/views/Github/githubStatistics.cshtml',
                    menu: 'Statistici Github' //Matches to name of 'Cele mai urmarite repouri' menu in proiectLicentaNavigationProvider
                }).state('userKnownLanguages', {
                    url: '/userKnownLanguages',
                    templateUrl: '/App/Main/views/Github/userKnownLanguages.cshtml',
                    menu: 'Limbajele folosite de utilizatori' //Matches to name of 'Cele mai urmarite repouri' menu in proiectLicentaNavigationProvider
                }).state('answersPerHour', {
                    url: '/answersPerHour',
                    templateUrl: '/App/Main/views/StackOverflow/answersPerHour.cshtml',
                    menu: 'Raspunsuri per ora' //Matches to name of 'Cele mai urmarite repouri' menu in proiectLicentaNavigationProvider
                }).state('answersPerDay', {
                    url: '/answersPerDay',
                    templateUrl: '/App/Main/views/StackOverflow/answersPerDay.cshtml',
                    menu: 'Raspunsuri per zi' //Matches to name of 'Cele mai urmarite repouri' menu in proiectLicentaNavigationProvider
                }).state('answersPerDayAndHour', {
                    url: '/answersPerDayAndHour',
                    templateUrl: '/App/Main/views/StackOverflow/answersPerDayAndHour.cshtml',
                    menu: 'Raspunsuri per zi si ora' //Matches to name of 'Cele mai urmarite repouri' menu in proiectLicentaNavigationProvider
                });

                ChartJsProvider.setOptions({
                    colours: ['#97BBCD', '#DCDCDC', '#F7464A', '#46BFBD', '#FDB45C', '#949FB1', '#4D5360'],
                    responsive: true
                });

            localStorageServiceProvider.setPrefix('proiectLicenta');
        }
    ]);
})();