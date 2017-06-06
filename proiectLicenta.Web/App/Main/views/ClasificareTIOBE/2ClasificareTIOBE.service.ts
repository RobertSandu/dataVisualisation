module app.clasificareTIOBE {
    'use strict';

    export interface IClasificareTIOBE {
        programmingLanguageName: String,
        tiobeYear: number,
        tiobeMonth: number,
        tiobePercent: number,
        id: string;
    }

    

    export interface IClasificareTiobeItems
    {
        items: IClasificareTIOBE[]
    }

    export interface IClasificareTiobeResource
        extends angular.resource.IResource<IClasificareTiobeItems> {

    }
   
    export interface IClasificareTIOBEServiceHttp {
        
        get(): angular.IPromise<IClasificareTiobeItems>

    }

    export class ClasificareTIOBEServiceHttp implements IClasificareTIOBEServiceHttp{

        static $inject = ['$http'];
        
        constructor(private $http: angular.IHttpService) { }

        get(): angular.IPromise<IClasificareTiobeItems> {
            return this.$http.get('api/services/app/clasificareTIOBE/GetList').then((response: angular.IHttpPromiseCallbackArg<IClasificareTiobeItems>): IClasificareTiobeItems => {
                return response.data;
            });
        }

    }

    angular.module("app.clasificareTIOBE")
        .service('app.clasificareTIOBE.ClasificareTIOBEServiceHttp', ClasificareTIOBEServiceHttp);

}

