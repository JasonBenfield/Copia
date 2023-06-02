import { SingleActivePanel } from '@jasonbenfield/sharedwebapp/Panel/SingleActivePanel';
import { CopiaPage } from '../CopiaPage';
import { PortfolioMenuPanel } from '../PortfolioMenuPanel';
import { CounterpartyListPanel } from './CounterpartyListPanel';
import { MainPageView } from './MainPageView';

class MainPage extends CopiaPage {
    private readonly panels: SingleActivePanel;
    private readonly counterpartyListPanel: CounterpartyListPanel;
    private readonly menuPanel: PortfolioMenuPanel;

    constructor(protected readonly view: MainPageView) {
        super(view);
        this.panels = new SingleActivePanel();
        this.counterpartyListPanel = this.panels.add(
            new CounterpartyListPanel(this.defaultApi, view.counterpartyListPanelView)
        );
        this.menuPanel = this.panels.add(
            new PortfolioMenuPanel(this.defaultApi, view.menuPanelView)
        );
        this.activateCounterpartyListPanel();
    }

    private async activateCounterpartyListPanel() {
        this.panels.activate(this.counterpartyListPanel);
        const result = await this.counterpartyListPanel.start();
        if (result.menu) {
            this.activateMenuPanel();
        }
    }

    private async activateMenuPanel() {
        this.panels.activate(this.menuPanel);
        const result = await this.menuPanel.start();
        if (result.back) {
            this.activateCounterpartyListPanel();
        }
    }
}
new MainPage(new MainPageView());