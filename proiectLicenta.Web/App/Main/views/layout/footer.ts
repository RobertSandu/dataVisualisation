module app.views.layout {
    'use strict'; 

    interface IFooterScope {
        year: number;
        projectName: string;
    }

    class FooterController implements IFooterScope{
        year: number;
        projectName: string;

        //static $inject = [''];

        constructor() {

            var vm = this;
            vm.projectName = "Proiect Licenta";
            vm.year = 2016;
        }
         
    }

    angular
        .module('app')
        .controller('app.views.layout.footer', FooterController);

}