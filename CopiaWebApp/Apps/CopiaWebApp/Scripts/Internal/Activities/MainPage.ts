import { SingleActivePanel } from '@jasonbenfield/sharedwebapp/Panel/SingleActivePanel';
import { CopiaPage } from '../CopiaPage';
import { PortfolioMenuPanel } from '../PortfolioMenuPanel';
import { ActivityListPanel } from './ActivityListPanel';
import { MainPageView } from './MainPageView';

class MainPage extends CopiaPage {
    private readonly panels: SingleActivePanel;
    private readonly activityListPanel: ActivityListPanel;
    private readonly menuPanel: PortfolioMenuPanel;

    constructor(protected readonly view: MainPageView) {
        super(view);
        this.panels = new SingleActivePanel();
        this.activityListPanel = this.panels.add(
            new ActivityListPanel(this.defaultApi, view.activityListPanelView)
        );
        this.menuPanel = this.panels.add(
            new PortfolioMenuPanel(this.defaultApi, view.menuPanelView)
        );
        this.activityListPanel.refresh();
        this.activateActivityListPanel();
    }

    private async activateActivityListPanel() {
        this.panels.activate(this.activityListPanel);
        const result = await this.activityListPanel.start();
        if (result.menu) {
            this.activateMenuPanel();
        }
        else if (result.addRequested) {

        }
    }

    private async activateMenuPanel() {
        this.panels.activate(this.menuPanel);
        const result = await this.menuPanel.start();
        if (result.back) {
            this.activateActivityListPanel();
        }
    }
}
new MainPage(new MainPageView());