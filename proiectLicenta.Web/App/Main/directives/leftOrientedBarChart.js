(function () {
    'use strict';
    //console.log('in ifi');
    angular
        .module('app')
        .directive('leftChart', usaMapDirective);

    function usaMapDirective() {
        var directive = {
            restrict: 'AE',
            link: link,
            scope: { data: '=', hoveredPortion: '=' }
        };
        function link(scope, instanceElement, instanceAttributes) {

            var betweenBarsPagging = 5;
            var barHeight = 40;

            var data = scope.data;

            var svg = d3.select(instanceElement[0])
                     .append('svg')
                     .attr({ width: 450, height: Object.keys(data).length * (betweenBarsPagging + barHeight) });




        }
        return directive;
    }
})();