(function () {
    'use strict';
    //console.log('in ifi');
    angular
        .module('app')
        .directive('worldDirective', usaMapDirective);
    function usaMapDirective() {
        var directive = {
            restrict: 'AE',
            link: link,
            scope: { locations: '=' }
        };
        function link(scope, instanceElement, instanceAttributes) {

            /*[width, height]*/
            var mapDimensions = [1228, 878];

            var zoomBehavior = d3.behavior.zoom()
                .scaleExtent([1, 10])
                .on('zoom', zoomBehaviorFunction);

            //appending and svg element in order to draw the map
            var svg = d3.select(instanceElement[0])
                .append('svg')
                .attr('height', mapDimensions[1])
                .attr('width', mapDimensions[0])
                .call(zoomBehavior)
                .append('g');

            //var countriesGrouping = svg.append('g');

            svg.append("g").attr("id", "map_layer");
            svg.append("g").attr("id", "circle_layer");

            var mapTip = d3.tip()
                .attr('class', 'd3-tip')
                .html(function (d) {
                    return "<strong>Utilizatori in " + d.locationName + ": </strong><span style='color:red'>" + d.numberOfUsers + "</span>";
                });

            svg.call(mapTip);

            var projection = d3.geo.mercator()
                                .scale((mapDimensions[0] + 1) / 2 / Math.PI)
                                .translate([mapDimensions[0] / 2, mapDimensions[1] / 2]);

            //convertiong coordinates into an SVG path
            var path = d3.geo.path().projection(projection);

            //reading the topo.json data in order to draw the map coordinates
            d3.json("Scripts/d3/world.json", function (error, data) {

                

                //extracting the data that we will be using to draw the countries
                var countries = topojson
                    .feature(data, data.objects.countries)
                    .features;

                //appending the path to the svg element and setting the path and fill collor
                svg
                    .select('#map_layer')
                    .selectAll('path')
                    //data.features is an array of coordinates (features)
                    .data(countries)
                    .enter()
                    .append('path')
                    .attr("class", "land")
                    .attr('d', path);

                var thereAreRendered = false;

                scope.$watch('locations', function (value) {

                    if (typeof value !== 'undefined' && scope.locations !== 'undefined' && scope.locations) {
                        
                        if (!thereAreRendered) {

                            thereAreRendered = !thereAreRendered;

                            svg
                                .select('#circle_layer')
                                .selectAll('circle')
                                .data(scope.locations)
                                .enter()
                                .append('circle')
                                .each(function (d) {
                                    var location = projection([d.longitude, d.latitude]);
                                    d3.select(this).attr({
                                        cx: location[0],
                                        cy: location[1],
                                        r: Math.sqrt(+d.numberOfUsers * 0.01)
                                    });
                                })
                                .attr("class", "bubble")
                                .on('mouseover', mapTip.show)
                                .on('mouseout', mapTip.hide)
                                .on('click', function (d) {
                                    //console.log(d);
                                })
                                .on('dblclick', function (d) {
                                    //console.log('dblclick');
                                });

                        }

                    }

                }, true);

                



            });

            function zoomBehaviorFunction() {

                var trasnalateEvent = d3.event.translate;
                var scaleEvent = d3.event.scale;

                svg.attr('transform', 'translate(' + trasnalateEvent[0] + ',' + trasnalateEvent[1] + ')scale(' + scaleEvent + ')');
                //svg.selectAll("circle").attr("d", path.projection(projection));

            }

        }
        return directive;
    }
})();
