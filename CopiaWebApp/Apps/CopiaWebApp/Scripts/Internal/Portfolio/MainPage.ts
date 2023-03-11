import { SingleActivePanel } from '@jasonbenfield/sharedwebapp/Panel/SingleActivePanel';
import { CopiaPage } from '../CopiaPage';
import { MainMenuPanel } from '../MainMenuPanel';
import { AddAccountPanel } from './AddAccountPanel';
import { MainPageView } from './MainPageView';
import { PortfolioPanel } from './PortfolioPanel';

class MainPage extends CopiaPage {
    private readonly panels: SingleActivePanel;
    private readonly portfolioPanel: PortfolioPanel;
    private readonly addAccountPanel: AddAccountPanel;
    private readonly mainMenuPanel: MainMenuPanel;

    constructor(protected readonly view: MainPageView) {
        super(view);
        this.panels = new SingleActivePanel();
        this.portfolioPanel = this.panels.add(
            new PortfolioPanel(this.defaultApi, view.portfolioPanelView)
        );
        this.addAccountPanel = this.panels.add(
            new AddAccountPanel(this.defaultApi, view.addAccountPanelView)
        );
        this.mainMenuPanel = this.panels.add(
            new MainMenuPanel(this.defaultApi, view.mainMenuPanelView)
        );
        this.portfolioPanel.refresh();
        this.activatePortfolioPanel();
    }

    private async activatePortfolioPanel() {
        this.panels.activate(this.portfolioPanel);
        const result = await this.portfolioPanel.start();
        if (result.addAccountRequested) {
            this.activateAddAccountPanel();
        }
        else if (result.accountSelected) {
            this.defaultApi.Account.Index.open({ AccountID: result.accountSelected.account.ID });
        }
        else if (result.menuRequested) {
            this.activateMainMenuPanel();
        }
    }

    private async activateAddAccountPanel() {
        this.panels.activate(this.addAccountPanel);
        const result = await this.addAccountPanel.start();
        if (result.saved) {
            this.portfolioPanel.refresh();
        }
        this.activatePortfolioPanel();
    }

    private async activateMainMenuPanel() {
        this.panels.activate(this.mainMenuPanel);
        await this.mainMenuPanel.start();
        this.activatePortfolioPanel();
    }
}
new MainPage(new MainPageView());