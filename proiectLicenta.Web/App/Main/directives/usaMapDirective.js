(function () {
    'use strict';
    //console.log('in ifi');
    angular
        .module('app')
        .directive('usaDirective', usaMapDirective);
    function usaMapDirective() {
        var directive = {
            restrict: 'AE',
            link: link,
            scope: { currentSelectedStates : '=' }
        };
        function link(scope, instanceElement, instanceAttributes) {

            /*[width, height]*/
            var mapDimensions = [1024, 728];

            //appending and svg element in order to draw the map
            var svg = d3.select(instanceElement[0])
                .append('svg')
                .attr('height', mapDimensions[1])
                .attr('width', mapDimensions[0]);

            var mapTip = d3.tip()
                .attr('class', 'd3-tip')
                .html(function(d) {
                    return "<strong>Utilizatori in " + d.state + ": </strong><span style='color:red'>" + d.numberOfUsers + "</span>";
                });

            svg.call(mapTip);


            //reading the topo.json data in order to draw the map coordinates
            d3.json("Scripts/d3/us-states.json", function (error, data) {

                d3.json("api/services/app/dateStackOverflow/getAllUsaStates", function (err, cities) {
                
                    cities = cities.items;

                    var projection = d3.geo.albersUsa();

                    //convertiong coordinates into an SVG path
                    var path = d3.geo.path().projection(projection);

                    //appending the path to the svg element and setting the path and fill collor
                    svg.selectAll('path')
                        //data.features is an array of coordinates (features)
                        .data(data.features)
                        .enter()
                        .append('path')
                        .attr("class", "land")
                        .attr('d', path)
                        .on('dblclick', function(d) {

                            if (d3.select(this).attr("class") === "selectedLand") {

                                d3.select(this).attr("class", "land");

                                _.defer(() => {
                                    scope.$apply(() => {

                                        var index = scope.currentSelectedStates.indexOf(d.properties.name);

                                        console.log('index');
                                        console.log(index);

                                        if (index !== -1) {

                                            scope.currentSelectedStates.splice(index, 1);

                                        }
                                        

                                    });
                                });

                            } else if (d3.select(this).attr("class") === "land") {

                                d3.select(this).attr("class", "selectedLand");

                                _.defer(() => {
                                    scope.$apply(() => {

                                        scope.currentSelectedStates.push(d.properties.name);

                                    });
                                });
                                

                            }

                        });

                    svg.selectAll('text')
                        .data(data.features)
                        .enter()
                        .append('text')
                        .text(function (d) {
                            return d.properties.name;
                        })
                        //puts the text in the middle of the state (of the polygon)
                        //by finding its centroid
                        .attr({
                            x: function (d) {
                                //console.log(path.centroid(d)[0]);
                                return path.centroid(d)[0];
                            },
                            y: function (d) {
                                return path.centroid(d)[1];
                            }
                        })
                        //scg attribute for setting the position of the text
                        .attr("text-anchor", "middle");

                   

                    svg.selectAll('circle')
                        .data(cities)
                        .enter()
                        .append('circle')
                        .each(function(d) {
                            var location = projection([d.longitude, d.latitude]);
                            d3.select(this).attr({
                                cx: location[0],
                                cy: location[1],
                                r: Math.sqrt(+d.numberOfUsers * 0.1)
                            });
                        })
                        .attr("class", "bubble")
                        .on('mouseover', mapTip.show)
                        .on('mouseout', mapTip.hide)
                        .on('click', function(d) {
                            //console.log(d);
                        })
                        .on('dblclick', function (d) {
                            //console.log('dblclick');
                        });
                });

            });
        }
        return directive;
    }
})();
