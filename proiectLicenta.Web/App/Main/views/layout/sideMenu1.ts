/*
(function () {
    angular.module('app').factory('appSession', [
            function () {

                var _session = {
                    user: null,
                    tenant: null
                };

                abp.services.app.session.getCurrentLoginInformations({ async: false }).done(function (result) {
                    _session.user = result.user;
                    _session.tenant = result.tenant;
                });

                return _session;
            }
        ]);
})();
*/
declare var abp;
module app.views.layout {

    interface ISessionModel {
        
    }

    class SideMenuController {
    /*
            vm.languages = abp.localization.languages;
            vm.currentLanguage = abp.localization.currentLanguage;

            vm.menu = abp.nav.menus.MainMenu;
            vm.currentMenuName = $state.current.menu;
            */

        languges: any;
        currentLanguage: any;
        menu: any;
        currentMenuName: any;
        //export var abp;
        
        static $inject = ['$rootScope', '$state', 'appSession'];

        constructor(private $rootScope: ng.IRootScopeService, private $state: angular.ui.IState, private appSession: any) {
            var vm = this;
            //vm.abp = angular.module('');
            
            //vm.languges = abp.localization.languages || [];

        }


    }


}