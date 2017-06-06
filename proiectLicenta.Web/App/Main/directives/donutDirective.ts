((): void => {
    'use strict';

    //console.log('in ifi');

    angular
        .module('app')
        .directive('donutDirective', donutDirective);

    function donutDirective(): angular.IDirective {

        //console.log('in functia de directiva');

        var directive = <angular.IDirective>{
            restrict: 'AE',
            link: link,
            scope: { data: '=', hoveredPortion: '='}
            
        };

        function link(scope: app.models.IDonutChartScope, instanceElement: angular.IAugmentedJQuery, instanceAttributes: angular.IAttributes): void {

            //console.log('in functia link');
            var color: d3.scale.Ordinal<string, string> = d3.scale.category20c();

            

            var data = scope.data;

            //console.log('data');
            //console.log(data);

            var width: number = 600;
            var height: number = 600;
            var radius: number = Math.min(width, height);

            //the size of the legend size square (wich has the same color as the element)
            var legendSize: number = 30;
            //the space between two legend items
            var legendSpaceSize: number = 6;

            //creating the svg where I will draw the data
            var svg = d3.select(instanceElement[0]).append('svg');

            var pie = d3.layout.pie<{ name: String, value: number }>()
                .value((d) => {
                    return d.value;
                })
                .sort(null);

            var arc = d3.svg.arc<d3.layout.pie.Arc<{ name: String, value: number }>>()
                .outerRadius(radius / 2 * 0.9)
                .innerRadius(radius / 2 * 0.5);

            //in the future this sould be modified based on the window dimension
            svg.attr({ width: width, height: height });

            var g = svg.append('g')
                .attr('transform', 'translate(' + width / 2 + ',' + height / 2 + ')');
        
            var path = g.selectAll('path');
            
                
            scope.$watch('data', (data: { name: String, value: number }[]) => {

                if (!data)
                    return;

                color = d3.scale.category20c();
                g.selectAll('path').remove();

                var newPath = path.data(pie(data));
                newPath.exit().remove();
                newPath.enter().append('path')
                    .style('stroke', 'white')
                    .attr('d', (d, i) => {
                        return arc(d, i);
                    })
                    .attr('fill', (d, i) => {
                        //we choose the name value to generate the color
                        return color(d.data.name.toString());
                    })
                    .on('mouseover', (d) => {

                        //when the user is hovering over a portion of the donut chart
                        //we set the scope.hoveredPortion to the hovered  portion
                        //and the controller will decide what to do with that data
                        _.defer(() => {
                            scope.$apply(() => {

                                scope.hoveredPortion = { name: d.data.name, value: d.data.value, selected: true };

                            });
                        });

                    });

                svg.selectAll(".legendElement").remove();

                var legendElementsArray = svg
                    //we select all the elements with the legendElement css class
                    .selectAll(".legendElement")
                    .data(color.domain());

                var legendElements = legendElementsArray
                    .enter()
                    .append('g')
                    .attr('class','legendElement')
                    .attr('transform', function(d, i) {
                        var height = legendSize + legendSpaceSize;
                        var offset = height * color.domain().length / 2;
                        var horz = 9.5 * legendSize;
                        var vert = 330 - offset + i * 30;
                        return 'translate(' + horz + ',' + vert + ')';
                    });

                legendElementsArray.exit().remove();
                
                legendElements.append('rect')
                    .attr('width', 20)
                    .attr('height', 20)
                    .style('fill', color)
                    .style('stroke', color);

                legendElements.append('text')
                    .attr('x', legendSize - 8)
                    .attr('y', legendSize - 15)
                    .text(function (d) { return d; });

            }, true);

        }



        return directive;
    }

})();