module app.StackOverflow {
    'use strict';

    import List = _.List;

    export interface ICharJsColor {

        fillColor: string;
        strokeColor: string;
        pointColor: string;
        pointStrokeColor: string;
        pointHighlightFill: string;
        pointHighlightStroke: string;

    }

    interface IStackOverflowUsaMapController {

        usaUsersStatisticDictionary: Array<any[]>;
        leftBarChartData: IUsaUserModel;
        rightBarCharData: IUsaUserModel;
        barChartLabes: string[];
        barChartSeries: string[];
        barChartData: any[][];
        currentSelectedStates: string[];
        chartJsColors: ICharJsColor[];

    }

    class StackOverflowUsaMapController implements IStackOverflowUsaMapController {

        static $inject = ['app.StackOverflow.StackOverflowService', '$scope'];

        usaUsersStatisticDictionary: Array<any[]>;
        leftBarChartData: IUsaUserModel;
        rightBarCharData: IUsaUserModel;
        barChartLabes: string[];
        barChartSeries: string[];
        barChartData: Array<Array<any>>;
        currentSelectedStates: string[];
        chartJsColors: ICharJsColor[];

        constructor(private StackOverflowSevice: app.StackOverflow.IStackOverflowSevice, private scope: angular.IScope) {
            StackOverflowSevice
                .getUsaUsersList()
                .then((AllUsaUsersList: app.StackOverflow.IUsaUsersModel): void => {

                    this.currentSelectedStates = [];
                    this.chartJsColors = [];

                    var usaUsersStatistic: IUsaUserModel[];
                    usaUsersStatistic = AllUsaUsersList.items;

                    this.barChartLabes = _.filter(Object.keys(usaUsersStatistic[0]), (obj): any => {
                        return (obj !== 'state' && obj !== 'longitude' && obj !== 'latitude');
                    });
                   
                    this.barChartSeries = [];
                    this.barChartSeries.push(usaUsersStatistic[0].state);
                    

                    this.barChartData = new Array<Array<any>>();
                    var firstDataElement = new Array<any>();
                    
                    for (var o in usaUsersStatistic[0]) {

                        if (o !== 'state' && o !== 'longitude' && o !== 'latitude')
                            firstDataElement.push(usaUsersStatistic[0][o]);
                        
                    }

                    this.barChartData.push(firstDataElement);

                   // console.log('this.barChartData');
                    //console.log(this.barChartData);

                    this.usaUsersStatisticDictionary = Array<any[]>();

                    this.leftBarChartData = usaUsersStatistic[0];
                    this.rightBarCharData = usaUsersStatistic[usaUsersStatistic.length - 1];

                    _.each(usaUsersStatistic, (obj: IUsaUserModel): void => {

                        this.usaUsersStatisticDictionary[obj.state] = [];

                        for (var o in obj) {

                            if (o !== 'state' && o !== 'longitude' && o !== 'latitude')
                                this.usaUsersStatisticDictionary[obj.state].push(obj[o]);

                        }


                    });

                    //console.log('this.usaUsersStatisticDictionary');
                    //console.log(this.usaUsersStatisticDictionary);

                    var d3RandomColors = d3.scale.category20();

                    for (var i = 0; i <= 20; i++) {

                        var currentD3Color = d3.rgb(d3RandomColors(i.toString()));

                        var rgbaColor = 'rgba(' + currentD3Color.r.toString() + ', ' + currentD3Color.g.toString() + ', ' + currentD3Color.b.toString() + ',';

                        var newColor = {
                            fillColor: rgbaColor + ' 0.2)',
                            strokeColor: rgbaColor + ' 1)',
                            pointColor: rgbaColor + ' 1)',
                            pointStrokeColor: '#fff',
                            pointHighlightFill: '#fff',
                            pointHighlightStroke: rgbaColor + ' 0.8)'
                        }

                        this.chartJsColors.push(newColor);

                    }


                });

            scope.$watch(() => this.currentSelectedStates, (newVal: string[], oldVal: string[]) => {

                //console.log('here');

                console.log('newVal');
                console.log(newVal);

                if (typeof newVal !== "undefined" && angular.isArray(newVal) && newVal.length > 0) {

                    this.barChartData = new Array<Array<any>>();

                    for (var i = 0; i < this.currentSelectedStates.length; i++) {

                        //console.log('here');

                        //console.log('this.usaUsersStatisticDictionary[this.currentSelectedStates[i]]');
                        //console.log(this.usaUsersStatisticDictionary[this.currentSelectedStates[i]]);
                        
                        this.barChartData.push(angular.copy(this.usaUsersStatisticDictionary[this.currentSelectedStates[i]]));

                        //console.log('this.barChartData');
                        //console.log(this.barChartData);

                    }

                    angular.copy(this.currentSelectedStates, this.barChartSeries);

                }
                



            }, true);
        }

    }

    angular.module('app.StackOverflow')
        .controller('app.StackOverflow.StackOverflowUsaMapController', StackOverflowUsaMapController);

}