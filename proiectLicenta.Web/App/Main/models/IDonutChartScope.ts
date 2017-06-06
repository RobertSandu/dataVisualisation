module app.models {
    export interface IDonutChartScope extends angular.IScope {
        data: { name: String, value: number }[];
        hoveredPortion: { name: String, value: number, selected: Boolean };
    }
}