import { CopiaPageView } from '../CopiaPageView';
import { PortfolioMenuPanelView } from '../PortfolioMenuPanelView';
import { ActivityTemplateListPanelView } from './ActivityTemplateListPanelView';
import { ActivityTemplatePanelView } from './ActivityTemplatePanelView';
import { AddActivityTemplatePanelView } from './AddActivityTemplatePanelView';

export class MainPageView extends CopiaPageView {
    readonly activityTemplateListPanelView: ActivityTemplateListPanelView;
    readonly addActivityTemplatePanelView: AddActivityTemplatePanelView;
    readonly activityTemplatePanelView: ActivityTemplatePanelView;
    readonly menuPanelView: PortfolioMenuPanelView;

    constructor() {                                                     
        super();
        this.activityTemplateListPanelView = this.addView(ActivityTemplateListPanelView);
        this.addActivityTemplatePanelView = this.addView(AddActivityTemplatePanelView);
        this.activityTemplatePanelView = this.addView(ActivityTemplatePanelView);
        this.menuPanelView = this.addView(PortfolioMenuPanelView);
    }
}