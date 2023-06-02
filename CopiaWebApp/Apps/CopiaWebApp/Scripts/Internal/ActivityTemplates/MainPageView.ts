import { CopiaPageView } from '../CopiaPageView';
import { PortfolioMenuPanelView } from '../PortfolioMenuPanelView';
import { ActivityTemplateListPanelView } from './ActivityTemplateListPanelView';
import { ActivityTemplatePanelView } from './ActivityTemplatePanelView';
import { AddActivityTemplatePanelView } from './AddActivityTemplatePanelView';
import { EditTemplateStringPanelView } from './EditTemplateStringPanelView';

export class MainPageView extends CopiaPageView {
    readonly activityTemplateListPanelView: ActivityTemplateListPanelView;
    readonly addActivityTemplatePanelView: AddActivityTemplatePanelView;
    readonly activityTemplatePanelView: ActivityTemplatePanelView;
    readonly editTemplateStringPanelView: EditTemplateStringPanelView;
    readonly menuPanelView: PortfolioMenuPanelView;

    constructor() {                                                     
        super();
        this.activityTemplateListPanelView = this.addView(ActivityTemplateListPanelView);
        this.addActivityTemplatePanelView = this.addView(AddActivityTemplatePanelView);
        this.activityTemplatePanelView = this.addView(ActivityTemplatePanelView);
        this.editTemplateStringPanelView = this.addView(EditTemplateStringPanelView);
        this.menuPanelView = this.addView(PortfolioMenuPanelView);
    }
}