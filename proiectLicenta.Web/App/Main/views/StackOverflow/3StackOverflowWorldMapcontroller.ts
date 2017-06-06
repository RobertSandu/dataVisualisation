module app.StackOverflow {
    'use strict';

    import List = _.List;

    interface IStackOverflowWorldMapController {

        worldUsersLocations: IWorldDataElementWithCoordinates[];
        
    }

    interface IOpenStreetMapCoordinates {

        lat: string;
        lon: string;

    }

    interface IWorldDataElementWithCoordinates extends IWorldDataElement {

        latitude: number;
        longitude: number;

    }

    class StackOverflowWorldMapController implements IStackOverflowWorldMapController {

        static $inject = ['app.StackOverflow.StackOverflowService', '$scope', '$q', '$http', 'localStorageService'];

        worldUsersLocations: IWorldDataElementWithCoordinates[];

        constructor(private StackOverflowSevice: app.StackOverflow.IStackOverflowSevice
            , private scope: angular.IScope
            , private $q: angular.IQService, $http: angular.IHttpService
            , private localStorageService: angular.local.storage.ILocalStorageService) {

            if (localStorageService.isSupported) {

                this.worldUsersLocations = localStorageService.get<IWorldDataElementWithCoordinates[]>('proiectLicenta-worldUsersLocations');

                if (typeof this.worldUsersLocations !== 'undefined' && angular.isArray(this.worldUsersLocations)) {

                    console.log('a fost luat din local storage');
                   

                } else {

                    console.log('nu este prezent in local storage');
                    StackOverflowSevice
                        .getWorldUsersList()
                        .then((AllWorldUsersList: app.StackOverflow.IWorldDataModel): void => {

                            //$q.all();


                            $q.all<IWorldDataElementWithCoordinates>(_.map(AllWorldUsersList.items, (obj: IWorldDataElement): angular.IPromise<IWorldDataElementWithCoordinates> => {
                                return $http
                                    .get('http://nominatim.openstreetmap.org/search/' + obj.locationName + '?format=json&limit=1')
                                    .then((response: angular.IHttpPromiseCallbackArg<IOpenStreetMapCoordinates[]>): IWorldDataElementWithCoordinates => {

                                        if (response.data.length > 0) {

                                            var location: IWorldDataElementWithCoordinates = {

                                                locationName: obj.locationName,

                                                numberOfUsers: obj.numberOfUsers,

                                                numberOfUsersUnder20: obj.numberOfUsersUnder20,

                                                numberOfUsersBetween20And24: obj.numberOfUsersBetween20And24,

                                                numberOfUsersBetween25And29: obj.numberOfUsersBetween25And29,

                                                numberOfUsersBetween30And34: obj.numberOfUsersBetween30And34,

                                                numberOfUsersBetween35And39: obj.numberOfUsersBetween35And39,

                                                numberOfUsersBetween40And49: obj.numberOfUsersBetween40And49,

                                                numberOfUsersBetween50And60: obj.numberOfUsersBetween50And60,

                                                numberOfUsersOvers60: obj.numberOfUsersOvers60,

                                                numberOfUsersWithNoAge: obj.numberOfUsersWithNoAge,

                                                latitude: parseFloat(response.data[0].lat),

                                                longitude: parseFloat(response.data[0].lon)

                                            };

                                            return location;

                                        } else {

                                            var location: IWorldDataElementWithCoordinates = {

                                                locationName: obj.locationName,

                                                numberOfUsers: obj.numberOfUsers,

                                                numberOfUsersUnder20: obj.numberOfUsersUnder20,

                                                numberOfUsersBetween20And24: obj.numberOfUsersBetween20And24,

                                                numberOfUsersBetween25And29: obj.numberOfUsersBetween25And29,

                                                numberOfUsersBetween30And34: obj.numberOfUsersBetween30And34,

                                                numberOfUsersBetween35And39: obj.numberOfUsersBetween35And39,

                                                numberOfUsersBetween40And49: obj.numberOfUsersBetween40And49,

                                                numberOfUsersBetween50And60: obj.numberOfUsersBetween50And60,

                                                numberOfUsersOvers60: obj.numberOfUsersOvers60,

                                                numberOfUsersWithNoAge: obj.numberOfUsersWithNoAge,

                                                latitude: 0,

                                                longitude: 0

                                            };

                                            return location;

                                        }


                                    });
                            }))
                                .then((obj: IWorldDataElementWithCoordinates[]) => {

                                    console.log('rezultate');
                                    console.log(obj);

                                    this.worldUsersLocations = obj;

                                    localStorageService.set<IWorldDataElementWithCoordinates[]>('proiectLicenta-worldUsersLocations', obj);

                                });

                        });

                }

            }

           


        }

    }

    interface IAnswersPerDayController {

        answersPerDayData: IAnswersPerDay[];
        labels: string[];
        data: number[];
        series: string[];

    }

    class AnswersPerDayController implements IAnswersPerDayController {

        static $inject = [
            'app.StackOverflow.StackOverflowService'
            , '$scope'
        ];

        answersPerDayData: IAnswersPerDay[];
        labels: string[];
        data: number[];
        series: string[];

        constructor(private StackOverflowService: app.StackOverflow.IStackOverflowSevice,
            private scope: angular.IScope
        ) {

            this.labels = ["Luni", "Marți", "Miercuri", "Joi", "Vineri", "Sâmbătă", "Duminică"];
            this.series = ["Răspunsuri per zi"];
            this.data = new Array<number>();

            StackOverflowService.getAllWAnswersPerDay()
                .then((data: app.StackOverflow.IAnswersPerDayModel): void => {

                    this.answersPerDayData = data.items;

                    _.forEach(this.answersPerDayData, (value: IAnswersPerDay) => {

                        this.data.push(value.answers);

                    });

                });

        }

    }

    interface IAnswersPerHourController {

        answersPerHourData: IAnswersPerHour[];
        labels: number[];
        data: number[];
        series: string[];

    }

    class AnswersPerHourController implements IAnswersPerHourController {

        static $inject = [
            'app.StackOverflow.StackOverflowService'
            , '$scope'
        ];

        answersPerHourData: IAnswersPerHour[];
        labels: number[];
        data: number[];
        series: string[];

        constructor(private StackOverflowService: app.StackOverflow.IStackOverflowSevice,
            private scope: angular.IScope
        ) {

            //this.labels = _.range(0, 23);

            this.labels = new Array<number>();
            this.data = new Array<number>();
            this.series = ["Raspunsuri per ora"];


            StackOverflowService.getAllWAnswersPerHour()
                .then((data: app.StackOverflow.IAnswersPerHourModel): void => {

                    this.answersPerHourData = data.items;

                    _.forEach(this.answersPerHourData, (value: IAnswersPerHour) => {
                        this.labels.push(value.hour);
                        this.data.push(value.answers);
                    });
                });

        }

    }

    interface IAnswersPerDayAndHourController {

        answersPerDayAndHourData: IAnswersPerDayAndHour[];
        labels: number[];
        data: number[][];
        series: string[];

    }

    class AnswersPerDayAndHourController implements IAnswersPerDayAndHourController {

        static $inject = [
            'app.StackOverflow.StackOverflowService'
            , '$scope'
        ];

        answersPerDayAndHourData: IAnswersPerDayAndHour[];
        labels: number[];
        data: number[][];
        series: string[];

        constructor(private StackOverflowService: app.StackOverflow.IStackOverflowSevice,
            private scope: angular.IScope
        ) {

            this.series = ["duminică", "joi", "luni", "marţi", "miercuri", "sîmbătă", "vineri"];
            this.labels = _.range(0, 23);
            this.data = new Array<Array<number>>();

            StackOverflowService.getAllWAnswersPerDayAndHour()
                .then((data: app.StackOverflow.IAnswersPerDayAndHourModel): void => {

                    this.answersPerDayAndHourData = data.items;

                    _.forEach(this.series, (value: string) => {

                        var dayAndHourValues: IAnswersPerDayAndHour[] = _.filter(this.answersPerDayAndHourData, (dayAndHourValue: IAnswersPerDayAndHour) => {

                            return dayAndHourValue.day === value;

                        });

                        var newData = new Array<number>();

                        _.forEach(dayAndHourValues, (dayAndHourValue: IAnswersPerDayAndHour) => {

                            newData.push(dayAndHourValue.answers);

                        });

                        this.data.push(newData);

                    });

                });

            console.log(this.data[1]);

        }

    }

    angular.module('app.StackOverflow')
        .controller('app.StackOverflow.StackOverflowWorldMapController', StackOverflowWorldMapController);

    angular.module('app.StackOverflow')
        .controller('app.StackOverflow.AnswersPerDayAndHourController', AnswersPerDayAndHourController);

    angular.module('app.StackOverflow')
        .controller('app.StackOverflow.AnswersPerHourController', AnswersPerHourController);

    angular.module('app.StackOverflow')
        .controller('app.StackOverflow.AnswersPerDayController', AnswersPerDayController);

}