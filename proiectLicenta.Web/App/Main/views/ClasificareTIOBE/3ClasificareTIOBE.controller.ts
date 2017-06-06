module app.clasificareTIOBE {
    'use strict';

    import List = _.List;

    export interface IClasificareTiobeScope {
        listaClasificariTiobe: IClasificareTIOBE[];
    }

    export interface IElementGrafic {
        name: string,
        data: (string | number)[][]
    }

    class ClasificareTiobeController implements IClasificareTiobeScope {
        static $inject = ['app.clasificareTIOBE.ClasificareTIOBEServiceHttp'];
        listaClasificariTiobe: IClasificareTIOBE[];
        listaClasificariTiobeDistincteNume: IClasificareTIOBE[];
        listaNumeLimbajeProgramare: string[];

        dateCreareGrafic: IElementGrafic[];

        constructor(private ClasificareTIOBEService: app.clasificareTIOBE.IClasificareTIOBEServiceHttp) {

            ClasificareTIOBEService.get().then((listaClasificariTiobeServiciu: app.clasificareTIOBE.IClasificareTiobeItems): void => {

                this.dateCreareGrafic = new Array <IElementGrafic>();

                this.listaClasificariTiobe = listaClasificariTiobeServiciu.items;
                
                //iau numele distincte ale limbajelor de programare existente in baza de date
                this.listaClasificariTiobeDistincteNume = _.uniqBy(this.listaClasificariTiobe, (obj) => {
                     return obj.programmingLanguageName;
                });

                //returnez doar numele distincte ale limbajelor de programare
                this.listaNumeLimbajeProgramare = _.map(this.listaClasificariTiobeDistincteNume, (value) => {
                     return value.programmingLanguageName.toString();
                });

                _.each(this.listaNumeLimbajeProgramare, (value, index) => {

                    var tmp: IClasificareTIOBE[] = _.filter(this.listaClasificariTiobe, (obj) => {
                        return obj.programmingLanguageName === value;
                    });

                    var tmp2: (string|number)[][] = _.map(tmp, (object) => {
                        return [(new Date(object.tiobeYear, object.tiobeMonth,1)).getTime(), object.tiobePercent];
                    });

                    this.dateCreareGrafic[index] = { name: value, data: tmp2 };


                });

                window.createChart(this.dateCreareGrafic);


            });

            
        }

    }

    angular.module('app.clasificareTIOBE')
        .controller('app.clasificareTIOBE.ClasificareTiobeController', ClasificareTiobeController);

}