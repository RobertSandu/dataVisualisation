module app.StackOverflow {
    'use strict';

    export interface IAnswersPerDay {

        answers: number;
        day: number;
        id: number;

    }

    export interface IAnswersPerHour {

        answers: number;
        hour: number;
        id: number;

    }

    export interface IAnswersPerDayAndHour {

        answers: number;
        hour: number;
        day: string;
        id: number;

    }

    export interface IAnswersPerDayModel {

        items: IAnswersPerDay[];

    }

    export interface IAnswersPerHourModel {

        items: IAnswersPerHour[];

    }

    export interface IAnswersPerDayAndHourModel {

        items: IAnswersPerDayAndHour[];

    }

    export interface IUsaUserModel {

        latitude: number;

        longitude: number;

        numberOfUsers: number;

        numberOfUsersBetween20And24: number;
 
        numberOfUsersBetween25And29: number;
    
        numberOfUsersBetween30And34: number;
  
        numberOfUsersBetween35And39: number;
   
        numberOfUsersBetween40And49: number;
   
        numberOfUsersBetween50And60: number;
   
        numberOfUsersOvers60: number;
    
        numberOfUsersUnder20: number;
    
        numberOfUsersWithNoAge: number;

        state: string;
   
    }

    export interface IWorldDataElement {

        locationName: string;

        numberOfUsers: number;

        numberOfUsersUnder20: number;

        numberOfUsersBetween20And24: number;

        numberOfUsersBetween25And29: number;

        numberOfUsersBetween30And34: number;

        numberOfUsersBetween35And39: number;

        numberOfUsersBetween40And49: number;

        numberOfUsersBetween50And60: number;

        numberOfUsersOvers60: number;

        numberOfUsersWithNoAge: number;

    }

    export interface IWorldDataModel {
        
        items: IWorldDataElement[];

    }

    export interface IUsaUsersModel {

        items: IUsaUserModel[];

    }

    export interface IStackOverflowSevice {

        getAllTagTotalAppearancesList(): angular.IPromise<IStackOverflowItems>;

        getTagTotalAppearencesByName(tagName: string): angular.IPromise<ITagTotalAppearance>;

        getUsaUsersList(): angular.IPromise<IUsaUsersModel>;

        getWorldUsersList(): angular.IPromise<IWorldDataModel>;

        getAllWAnswersPerDay(): angular.IPromise<IAnswersPerDayModel>;

        getAllWAnswersPerHour(): angular.IPromise<IAnswersPerHourModel>;

        getAllWAnswersPerDayAndHour(): angular.IPromise<IAnswersPerDayAndHourModel>;

    }

    export class StackOverflowService implements IStackOverflowSevice {

        static $inject = ['$http'];

        constructor(private $http: angular.IHttpService) { }

        getAllTagTotalAppearancesList(): angular.IPromise<IStackOverflowItems> {
            return this.$http.get('api/services/app/dateStackOverflow/GetAllTagTotalAppearancesList')
                .then((response: angular.IHttpPromiseCallbackArg<IStackOverflowItems>): IStackOverflowItems => {
                return response.data;
            });
        }

        getTagTotalAppearencesByName(tagName: string): angular.IPromise<ITagTotalAppearance> {
            return this.$http.get('api/services/app/dateStackOverflow/getTagTotalAppearencesByName?TagName=' + tagName)
                .then((response: angular.IHttpPromiseCallbackArg<ITagTotalAppearance>): ITagTotalAppearance => {
                    return response.data;
                });
        }

        getUsaUsersList(): angular.IPromise<IUsaUsersModel> {
            return this.$http.get('api/services/app/dateStackOverflow/getAllUsaStates')
                .then((response: angular.IHttpPromiseCallbackArg<IUsaUsersModel>): IUsaUsersModel => {
                    return response.data;
                });
        }

        getWorldUsersList(): angular.IPromise<IWorldDataModel> {
            return this.$http.get('api/services/app/dateStackOverflow/getAllWorldData')
                .then((response: angular.IHttpPromiseCallbackArg<IWorldDataModel>): IWorldDataModel => {
                    return response.data;
                });
        }

        getAllWAnswersPerDay(): angular.IPromise<IAnswersPerDayModel> {
            return this.$http.get('api/services/app/dateStackOverflow/getAllWAnswersPerDay')
                .then((response: angular.IHttpPromiseCallbackArg<IAnswersPerDayModel>): IAnswersPerDayModel => {
                    return response.data;
                });
        }

        getAllWAnswersPerHour(): angular.IPromise<IAnswersPerHourModel> {
            return this.$http.get('api/services/app/dateStackOverflow/getAllWAnswersPerHour')
                .then((response: angular.IHttpPromiseCallbackArg<IAnswersPerHourModel>): IAnswersPerHourModel => {
                    return response.data;
                });
        }

        getAllWAnswersPerDayAndHour(): angular.IPromise<IAnswersPerDayAndHourModel> {
            return this.$http.get('api/services/app/dateStackOverflow/getAllWAnswersPerDayAndHour')
                .then((response: angular.IHttpPromiseCallbackArg<IAnswersPerDayAndHourModel>): IAnswersPerDayAndHourModel => {
                    return response.data;
                });
        }

    }

    angular.module("app.StackOverflow")
        .service('app.StackOverflow.StackOverflowService', StackOverflowService);

}