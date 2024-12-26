import { CopiaPageView } from '../CopiaPageView';
import { PortfolioMenuPanelView } from '../PortfolioMenuPanelView';
import { ActivityListPanelView } from './ActivityListPanelView';

export class MainPageView extends CopiaPageView {
    readonly activityListPanelView: ActivityListPanelView;
    readonly menuPanelView: PortfolioMenuPanelView;

    constructor() {
        super();
        this.activityListPanelView = this.addView(ActivityListPanelView);
        this.menuPanelView = this.addView(PortfolioMenuPanelView)
    }
}