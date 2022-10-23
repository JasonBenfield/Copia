import { BasicPage } from '@jasonbenfield/sharedwebapp/Components/BasicPage';
import { SingleActivePanel } from '@jasonbenfield/sharedwebapp/Panel/SingleActivePanel';
import { Apis } from '../Apis';
import { AddPortfolioPanel } from './AddPortfolioPanel';
import { MainPageView } from './MainPageView';

class MainPage extends BasicPage {
    protected readonly view: MainPageView;
    private readonly panels: SingleActivePanel;
    private readonly addPortfolioPanel: AddPortfolioPanel;

    constructor() {
        super(new MainPageView());
        this.panels = new SingleActivePanel();
        const copiaApi = new Apis(this.view.modalError).Copia();
        this.addPortfolioPanel = this.panels.add(
            new AddPortfolioPanel(copiaApi, this.view.addPortfolioPanel)
        );
        this.activateAddPortfolioPanel();
    }

    private async activateAddPortfolioPanel() {
        this.panels.activate(this.addPortfolioPanel);
        const result = await this.addPortfolioPanel.start();
        if (result.cancelled) {
            alert('Not Added');
        }
        else if (result.saved) {
            alert(`Added portfolio '${result.saved.portfolio.PortfolioName}'`);
        }
        this.addPortfolioPanel.reset();
    }
}
new MainPage();