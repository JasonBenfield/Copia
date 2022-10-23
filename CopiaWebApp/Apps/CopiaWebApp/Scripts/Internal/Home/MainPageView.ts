import { BasicPageView } from '@jasonbenfield/sharedwebapp/Views/BasicPageView';
import { AddPortfolioPanelView } from './AddPortfolioPanelView';

export class MainPageView extends BasicPageView {
    readonly addPortfolioPanel: AddPortfolioPanelView;

    constructor() {
        super();
        this.addPortfolioPanel = this.addView(AddPortfolioPanelView);
    }
}