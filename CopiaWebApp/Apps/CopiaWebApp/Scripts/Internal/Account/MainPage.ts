import { SingleActivePanel } from '@jasonbenfield/sharedwebapp/Panel/SingleActivePanel';
import { Url } from '@jasonbenfield/sharedwebapp/Url';
import { CopiaPage } from '../CopiaPage';
import { PortfolioMenuPanel } from '../PortfolioMenuPanel';
import { AccountPanel } from './AccountPanel';
import { MainPageView } from './MainPageView';

class MainPage extends CopiaPage {
    private readonly panels: SingleActivePanel;
    private readonly accountPanel: AccountPanel;
    private readonly menuPanel: PortfolioMenuPanel;

    constructor(protected readonly view: MainPageView) {
        super(view);
        const accountIDText = Url.current().getQueryValue('AccountID');
        const accountID = accountIDText ? Number(accountIDText) : 0;
        if (accountID) {
            this.panels = new SingleActivePanel();
            this.accountPanel = this.panels.add(
                new AccountPanel(this.defaultApi, view.accountPanelView)
            );
            this.menuPanel = this.panels.add(
                new PortfolioMenuPanel(this.defaultApi, view.menuPanelView)
            );
            this.accountPanel.setAccountID(accountID);
            this.accountPanel.refresh();
            this.activateAccountPanel();
        }
        else {
            this.defaultApi.Portfolio.Index.open({});
        }
    }

    private async activateAccountPanel() {
        this.panels.activate(this.accountPanel);
        const result = await this.accountPanel.start();
        if (result.menuRequested) {
            this.activateMenuPanel();
        }
    }

    private async activateMenuPanel() {
        this.panels.activate(this.menuPanel);
        const result = await this.menuPanel.start();
        if (result.back) {
            this.activateAccountPanel();
        }
    }
}
new MainPage(new MainPageView());