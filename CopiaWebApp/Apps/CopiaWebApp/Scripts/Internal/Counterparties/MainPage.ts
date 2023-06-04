import { SingleActivePanel } from '@jasonbenfield/sharedwebapp/Panel/SingleActivePanel';
import { CopiaPage } from '../CopiaPage';
import { PortfolioMenuPanel } from '../PortfolioMenuPanel';
import { AddCounterpartyPanel } from './AddCounterpartyPanel';
import { CounterpartyListPanel } from './CounterpartyListPanel';
import { MainPageView } from './MainPageView';

class MainPage extends CopiaPage {
    private readonly panels: SingleActivePanel;
    private readonly counterpartyListPanel: CounterpartyListPanel;
    private readonly addCounterpartyPanel: AddCounterpartyPanel;
    private readonly menuPanel: PortfolioMenuPanel;

    constructor(protected readonly view: MainPageView) {
        super(view);
        this.panels = new SingleActivePanel();
        this.counterpartyListPanel = this.panels.add(
            new CounterpartyListPanel(this.defaultApi, view.counterpartyListPanelView)
        );
        this.addCounterpartyPanel = this.panels.add(
            new AddCounterpartyPanel(this.defaultApi, view.addCounterpartyPanelView)
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
        else if (result.addRequested) {
            this.addCounterpartyPanel.reset();
            this.activateAddCounterpartyPanel();
        }
    }

    private async activateAddCounterpartyPanel() {
        this.panels.activate(this.addCounterpartyPanel);
        const result = await this.addCounterpartyPanel.start();
        if (result.cancelled) {
            this.activateCounterpartyListPanel();
        }
        else if (result.added) {
            this.activateCounterpartyListPanel();
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