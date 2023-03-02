import { CopiaPageView } from '../CopiaPageView';
import { AddPortfolioPanelView } from './AddPortfolioPanelView';
import { PortfolioListPanelView } from './PortfolioListPanelView';

export class MainPageView extends CopiaPageView {
    readonly addPortfolioPanel: AddPortfolioPanelView;
    readonly portfolioListPanel: PortfolioListPanelView;

    constructor() {
        super();
        this.addPortfolioPanel = this.addView(AddPortfolioPanelView);
        this.portfolioListPanel = this.addView(PortfolioListPanelView);
    }
}