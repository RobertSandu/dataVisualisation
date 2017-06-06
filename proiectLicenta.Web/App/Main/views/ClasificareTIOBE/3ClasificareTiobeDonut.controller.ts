module app.clasificareTIOBE {
    'use strict';

    export interface IRZSliderConfigurationObject extends Object {
        value: number;
        options: {
            floor: number;
            ceil: number;
            showTicks: Boolean;
        }
    }

    import List = _.List;


    class ClasificareTiobeDonutController implements IClasificareTiobeScope {
        static $inject = ['app.clasificareTIOBE.ClasificareTIOBEServiceHttp', '$scope', '$http', '$sce'];
        listaClasificariTiobe: IClasificareTIOBE[];
        listaClasificariTiobeDistincteNume: IClasificareTIOBE[];
        listaNumeLimbajeProgramare: string[];
        data: {name: String, value: number}[];
        

        yearSlider: IRZSliderConfigurationObject;
        monthSlider: IRZSliderConfigurationObject;

        uniqYearAndMonth: string[];
        clasificationPerYearAndMonth: { [id: string]: { name: String, value: number }[] };
        hoveredPortion: { name: String, value: number, selected: Boolean };

        dateCreareGrafic: IElementGrafic[];

        wikipediaHTMLContent: string;

        
        constructor(private ClasificareTIOBEService: app.clasificareTIOBE.IClasificareTIOBEServiceHttp,
                    private scope: angular.IScope,
                    private $http: angular.IHttpService,
                    private $sce: angular.ISCEService)
        {
            this.data = [{ name: "please choose", value: 10 }, { name: "another", value: 20 }, { name: "month", value: 30 }];

            this.hoveredPortion = { name: "", value: 0, selected: false };

            this.wikipediaHTMLContent = "";

            //console.log(this.data);
            ClasificareTIOBEService
                .get()
                .then((listaClasificariTiobeServiciu: app.clasificareTIOBE.IClasificareTiobeItems): void => {

                    this.dateCreareGrafic = new Array<IElementGrafic>();

                    this.listaClasificariTiobe = listaClasificariTiobeServiciu.items;

                    //search for the uniq year and month
                    var uniqByYearAndMonth = _.uniqBy(this.listaClasificariTiobe, (obj) => {
                        return obj.tiobeYear.toString() + "-" + (obj.tiobeMonth > 10 ? obj.tiobeMonth.toString() : "0" + obj.tiobeMonth.toString());
                    });

                    //
                    this.uniqYearAndMonth = _.map(uniqByYearAndMonth, (obj) => {
                        return obj.tiobeYear.toString() + "-" + (obj.tiobeMonth > 10 ? obj.tiobeMonth.toString() : "0" + obj.tiobeMonth.toString());
                    });


                    var uniqByYear = _.uniqBy(this.listaClasificariTiobe, (obj) => {
                        return obj.tiobeYear;
                    });

                    var uniqYear = _.map(uniqByYear, (obj) => {
                        return obj.tiobeYear;
                    });

                    this.yearSlider = {
                        value: _.max(uniqYear),
                        options: {
                            floor: _.min(uniqYear),
                            ceil: _.max(uniqYear),
                            showTicks: true
                        }
                    };

                    this.monthSlider = {
                        value: 6,
                        options: {
                            floor: 1,
                            ceil: 12,
                            showTicks: true
                        }
                    };

                    this.clasificationPerYearAndMonth = {};


                    _.each(this.uniqYearAndMonth, (obj) => {

                        var filteredByYearAndMonth = _.filter(this.listaClasificariTiobe, (object) => {
                            return obj === (object.tiobeYear.toString() + "-" + (object.tiobeMonth > 10 ? object.tiobeMonth.toString() : "0" + object.tiobeMonth.toString()));
                        });

                        var mappedToDonutDirectiveData = _.map(filteredByYearAndMonth, (object) => {
                            return { name: object.programmingLanguageName, value: object.tiobePercent };
                        });
                        
                        this.clasificationPerYearAndMonth[obj] = mappedToDonutDirectiveData;


                    });

                    

                    //console.log('this.clasificationPerYearAndMonth');
                    //console.log(this.clasificationPerYearAndMonth);


                });//.then

            //we are watching for the slider change in order to update the dataset displayed by the donut chart
            scope.$watch(() => this.yearSlider, (newVal: IRZSliderConfigurationObject, oldVal: IRZSliderConfigurationObject) => {

                if (newVal && (!isNaN(newVal.value))) {

                    var currentYear = newVal.value;
                    var currentMonth = this.monthSlider.value;

                    var ceva = _.filter(this.clasificationPerYearAndMonth, (obj, key) => {
                        return key === (currentYear.toString() + '-' + (currentMonth > 10 ? currentMonth.toString() : '0' + currentMonth.toString()));
                    });

                    if (ceva && ceva[0]) {

                        this.data = ceva[0];
                        this.hoveredPortion = { name: "", value: 0, selected: false };
                        _.defer(() => {
                            scope.$apply();
                        });

                    }

                }
               
            }, true);

            scope.$watch(() => this.monthSlider, (newVal: IRZSliderConfigurationObject, oldVal: IRZSliderConfigurationObject) => {

                if (newVal && (!isNaN(newVal.value))) {

                    var currentYear = this.yearSlider.value;
                    var currentMonth = newVal.value;

                    var ceva = _.filter(this.clasificationPerYearAndMonth, (obj, key) => {
                        return key === (currentYear.toString() + '-' + (currentMonth > 10 ? currentMonth.toString() : '0' + currentMonth.toString()));
                    });

                    if (ceva && ceva[0]) {
                        
                        this.data = ceva[0];
                        this.hoveredPortion = { name: "", value: 0, selected: false };
                        _.defer(() => {
                            scope.$apply();
                        });

                    }

                }
            }, true);

            scope.$watch(() => this.hoveredPortion, (newVal: { name: String, value: number, selected: Boolean }, oldVal: { name: String, value: number, selected: Boolean }) => {
                if (newVal.selected) {
                   // 'http://es.wikipedia.org/w/api.php?titles=' + country.name.toLowerCase() + '&rawcontinue=true&action=query&format=json&prop=extracts&callback=JSON_CALLBACK'
                    var wikipediaApiAdressStart: string = "http://en.wikipedia.org/w/api.php?titles=";
                    var wikipediaApiAdressEnd: string = "&rawcontinue=true&action=query&format=json&prop=extracts&callback=JSON_CALLBACK";
                    switch (newVal.name) {
                        case 'C':
                            wikipediaApiAdressStart += 'C_(programming_language)';
                            break;
                        case 'C#':
                            wikipediaApiAdressStart += 'C_Sharp_(programming_language)';
                            break;
                        case 'C++':
                            wikipediaApiAdressStart += 'C%2B%2B';
                            break;
                        case 'Delphi/Object Pascal':
                            wikipediaApiAdressStart += 'Comparison_of_Pascal_and_Delphi';
                            break;
                        case 'Java':
                            wikipediaApiAdressStart += 'Java_(programming_language)';
                            break;
                        case 'JavaScript':
                            wikipediaApiAdressStart += 'JavaScript';
                            break;
                        case 'Perl':
                            wikipediaApiAdressStart += 'Perl';
                            break;
                        case 'PHP':
                            wikipediaApiAdressStart += 'PHP';
                            break;
                        case 'Python':
                            wikipediaApiAdressStart += 'Python_(programming_language)';
                            break;
                        case 'Visual Basic .NET':
                            wikipediaApiAdressStart += 'Visual_Basic_.NET';
                            break;
                    }

                    var wikipediaApiAdress: string = wikipediaApiAdressStart + wikipediaApiAdressEnd;
                    //console.log('adresa');
                    //console.log(wikipediaApiAdress);
                    $http.jsonp(wikipediaApiAdress, {
                            cache: true
                        })
                        .then(
                        (data) => {
                            this.wikipediaHTMLContent = $sce.trustAsHtml(data.data['query']['pages'][Object.keys(data.data['query']['pages'])[0]]['extract'].toString());
                            
                        },
                        (reason) => {
                            //console.log('a esuat');
                            //console.log(reason);
                        });
                }
            }, true);

        }//constuctor





    }//class ClasificareTiobeDonutController implements IClasificareTiobeScope

    angular.module('app.clasificareTIOBE')
        .controller('app.clasificareTIOBE.ClasificareTiobeDonutController', ClasificareTiobeDonutController);

}//module app.clasificareTIOBE