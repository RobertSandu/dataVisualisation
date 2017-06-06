module app.StackOverflow {
    'use strict';

    import List = _.List;

    export interface ITagTotalAppearance {
        tag: string;
        appearences: number;
    }

    export interface IStackOverflowItems {
        items: ITagTotalAppearance[];
    }

    export interface ITagTotalAppearanceTicked {
        tag: string;
        appearences: number;
        ticked: Boolean;
    }

    interface IStackOverflowDonutController {
        StackOverflowItems: ITagTotalAppearance[];
        StackOverflowItemsInputModel: ITagTotalAppearanceTicked[];
        StackOverflowItemsOutputModel: ITagTotalAppearanceTicked[];
        data: { name: String, value: number }[];
        hoveredPortion: { name: String, value: number, selected: Boolean };
    }

    class StackOverflowDonutController implements IStackOverflowDonutController {
        static $inject = ['app.StackOverflow.StackOverflowService', '$scope'];
        StackOverflowItems: ITagTotalAppearance[];
        StackOverflowItemsInputModel: ITagTotalAppearanceTicked[];
        StackOverflowItemsOutputModel: ITagTotalAppearanceTicked[];
        data: { name: String, value: number }[];
        hoveredPortion: { name: String, value: number, selected: Boolean };

        constructor(private StackOverflowSevice: app.StackOverflow.IStackOverflowSevice , private scope: angular.IScope) {
            StackOverflowSevice
                .getAllTagTotalAppearancesList()
                .then((AllTagTotalAppearancesList: app.StackOverflow.IStackOverflowItems): void => {
                    this.StackOverflowItems = AllTagTotalAppearancesList.items;
                    //console.log(this.StackOverflowItems);

                    this.StackOverflowItemsInputModel = _.map(this.StackOverflowItems, (obj: ITagTotalAppearance): ITagTotalAppearanceTicked => {
                        return { tag: obj.tag, appearences: obj.appearences, ticked: false}
                    });
                    this.StackOverflowItemsOutputModel = _.map(this.StackOverflowItems, (obj: ITagTotalAppearance): ITagTotalAppearanceTicked => {
                        return { tag: obj.tag, appearences: obj.appearences, ticked: false }
                    });

                });

            scope.$watch(() => this.StackOverflowItemsOutputModel, (newVal: ITagTotalAppearanceTicked[], oldVal: ITagTotalAppearanceTicked[]) => {

                //var newSelectedTags = _.difference(newVal, oldVal);

                this.data = _.map(newVal, (obj: ITagTotalAppearanceTicked): { name: String, value: number } => {
                    return { name: obj.tag, value: obj.appearences };
                });

            }, true);
        }

        


        

    }

    angular.module('app.StackOverflow')
        .controller('app.StackOverflow.StackOverflowDonutController', StackOverflowDonutController);


}