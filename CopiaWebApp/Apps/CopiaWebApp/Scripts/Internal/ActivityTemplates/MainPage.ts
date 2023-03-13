import { SingleActivePanel } from '@jasonbenfield/sharedwebapp/Panel/SingleActivePanel';
import { CopiaPage } from '../CopiaPage';
import { PortfolioMenuPanel } from '../PortfolioMenuPanel';
import { ActivityTemplateListPanel } from './ActivityTemplateListPanel';
import { ActivityTemplatePanel } from './ActivityTemplatePanel';
import { AddActivityTemplatePanel } from './AddActivityTemplatePanel';
import { MainPageView } from './MainPageView';

class MainPage extends CopiaPage {
    private readonly panels: SingleActivePanel;
    private readonly activityTemplateListPanel: ActivityTemplateListPanel;
    private readonly addActivityTemplatePanel: AddActivityTemplatePanel;
    private readonly activityTemplatePanel: ActivityTemplatePanel;
    private readonly menuPanel: PortfolioMenuPanel;

    constructor(protected readonly view: MainPageView) {
        super(view);
        this.panels = new SingleActivePanel();
        this.activityTemplateListPanel = this.panels.add(
            new ActivityTemplateListPanel(this.defaultApi, view.activityTemplateListPanelView)
        );
        this.addActivityTemplatePanel = this.panels.add(
            new AddActivityTemplatePanel(this.defaultApi, view.addActivityTemplatePanelView)
        );
        this.activityTemplatePanel = this.panels.add(
            new ActivityTemplatePanel(this.defaultApi, view.activityTemplatePanelView)
        );
        this.menuPanel = this.panels.add(
            new PortfolioMenuPanel(this.defaultApi, view.menuPanelView)
        );
        this.activityTemplateListPanel.refresh();
        this.activateActivityTemplateListPanel();
    }

    private async activateActivityTemplateListPanel() {
        this.panels.activate(this.activityTemplateListPanel);
        const result = await this.activityTemplateListPanel.start();
        if (result.menuRequested) {
            this.activateMenuPanel();
        }
        else if (result.addRequested) {
            this.activateAddActivityTemplatePanel();
        }
        else if (result.activityTemplateSelected) {
            this.activityTemplatePanel.setActivityTemplateID(result.activityTemplateSelected.activityTemplate.ID);
            this.activateActivityTemplatePanel();
        }
    }

    private async activateAddActivityTemplatePanel() {
        this.panels.activate(this.addActivityTemplatePanel);
        const result = await this.addActivityTemplatePanel.start();
        if (result.added) {
            this.activityTemplateListPanel.refresh();
            this.activityTemplatePanel.setActivityTemplateDetail(result.added.activityTemplateDetail);
            this.activateActivityTemplatePanel();
        }
        else {
            this.activateActivityTemplateListPanel();
        }
    }

    private async activateActivityTemplatePanel() {
        this.panels.activate(this.activityTemplatePanel);
        const result = await this.activityTemplatePanel.start();
        if (result.back) {
            this.activateActivityTemplateListPanel();
        }
        else if (result.editTemplateStringRequested) {

        }
    }

    private async activateMenuPanel() {
        this.panels.activate(this.menuPanel);
        const result = await this.menuPanel.start();
        if (result.back) {
            this.activateActivityTemplateListPanel();
        }
    }
}
new MainPage(new MainPageView());