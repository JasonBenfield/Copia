import { CopiaPageView } from '../CopiaPageView';
import { PortfolioMenuPanelView } from '../PortfolioMenuPanelView';
import { AccountPanelView } from './AccountPanelView';

export class MainPageView extends CopiaPageView {
    readonly accountPanelView: AccountPanelView;
    readonly menuPanelView: PortfolioMenuPanelView;

    constructor() {                                                     
        super();
        this.accountPanelView = this.addView(AccountPanelView);
        this.menuPanelView = this.addView(PortfolioMenuPanelView);
    }
}