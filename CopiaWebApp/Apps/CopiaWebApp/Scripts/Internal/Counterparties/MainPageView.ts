import { CopiaPageView } from '../CopiaPageView';
import { PortfolioMenuPanelView } from '../PortfolioMenuPanelView';
import { CounterpartyListPanelView } from './CounterpartyListPanelView';

export class MainPageView extends CopiaPageView {
    readonly counterpartyListPanelView: CounterpartyListPanelView;
    readonly menuPanelView: PortfolioMenuPanelView;

    constructor() {
        super();
        this.counterpartyListPanelView = this.addView(CounterpartyListPanelView);
        this.menuPanelView = this.addView(PortfolioMenuPanelView);
    }
}