import { CopiaPageView } from '../CopiaPageView';
import { AddPortfolioPanelView } from '../Portfolios/AddPortfolioPanelView';
import { PortfolioListPanelView } from '../Portfolios/PortfolioListPanelView';

export class MainPageView extends CopiaPageView {
    readonly addPortfolioPanel: AddPortfolioPanelView;
    readonly portfolioListPanel: PortfolioListPanelView;

    constructor() {
        super();
        this.addPortfolioPanel = this.addView(AddPortfolioPanelView);
        this.portfolioListPanel = this.addView(PortfolioListPanelView);
    }
}