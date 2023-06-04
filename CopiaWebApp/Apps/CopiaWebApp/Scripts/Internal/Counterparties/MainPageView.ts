import { CopiaPageView } from '../CopiaPageView';
import { PortfolioMenuPanelView } from '../PortfolioMenuPanelView';
import { AddCounterpartyPanelView } from './AddCounterpartyPanelView';
import { CounterpartyListPanelView } from './CounterpartyListPanelView';

export class MainPageView extends CopiaPageView {
    readonly counterpartyListPanelView: CounterpartyListPanelView;
    readonly addCounterpartyPanelView: AddCounterpartyPanelView;
    readonly menuPanelView: PortfolioMenuPanelView;

    constructor() {
        super();
        this.counterpartyListPanelView = this.addView(CounterpartyListPanelView);
        this.addCounterpartyPanelView = this.addView(AddCounterpartyPanelView);
        this.menuPanelView = this.addView(PortfolioMenuPanelView);
    }
}