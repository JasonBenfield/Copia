import { SingleActivePanel } from '@jasonbenfield/sharedwebapp/Panel/SingleActivePanel';
import { CopiaPage } from '../CopiaPage';
import { AddPortfolioPanel } from './AddPortfolioPanel';
import { MainPageView } from './MainPageView';
import { PortfolioListPanel } from './PortfolioListPanel';

class MainPage extends CopiaPage {
    private readonly panels: SingleActivePanel;
    private readonly addPortfolioPanel: AddPortfolioPanel;
    private readonly portfolioListPanel: PortfolioListPanel;

    constructor(protected readonly view: MainPageView) {
        super(view);
        this.panels = new SingleActivePanel();
        this.addPortfolioPanel = this.panels.add(
            new AddPortfolioPanel(this.defaultApi, view.addPortfolioPanel)
        );
        this.portfolioListPanel = this.panels.add(
            new PortfolioListPanel(this.defaultApi, view.portfolioListPanel)
        );
        this.portfolioListPanel.refresh();
        this.activatePortfolioListPanel();
    }

    private async activatePortfolioListPanel() {
        this.panels.activate(this.portfolioListPanel);
        const result = await this.portfolioListPanel.start();
        if (result.add) {
            this.activateAddPortfolioPanel();
        }
    }

    private async activateAddPortfolioPanel() {
        this.panels.activate(this.addPortfolioPanel);
        const result = await this.addPortfolioPanel.start();
        if (result.saved) {
            this.portfolioListPanel.refresh();
        }
        this.activatePortfolioListPanel();
    }
}
new MainPage(new MainPageView());