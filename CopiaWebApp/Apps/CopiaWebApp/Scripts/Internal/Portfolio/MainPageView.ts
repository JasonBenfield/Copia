import { CopiaPageView } from '../CopiaPageView';
import { MainMenuPanelView } from '../MainMenuPanelView';
import { AddAccountPanelView } from './AddAccountPanelView';
import { PortfolioPanelView } from './PortfolioPanelView';

export class MainPageView extends CopiaPageView {
    readonly portfolioPanelView: PortfolioPanelView;
    readonly addAccountPanelView: AddAccountPanelView;
    readonly mainMenuPanelView: MainMenuPanelView;

    constructor() {                                                     
        super();
        this.portfolioPanelView = this.addView(PortfolioPanelView);
        this.addAccountPanelView = this.addView(AddAccountPanelView);
        this.mainMenuPanelView = this.addView(MainMenuPanelView);
    }
}