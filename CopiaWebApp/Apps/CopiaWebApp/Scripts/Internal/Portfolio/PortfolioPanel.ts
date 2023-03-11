import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { TextComponent } from "@jasonbenfield/sharedwebapp/Components/TextComponent";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { AccountListCard } from "./AccountListCard";
import { PortfolioPanelView } from "./PortfolioPanelView";

interface IResults {
    readonly addAccountRequested?: boolean;
    readonly menuRequested?: boolean;
    readonly accountSelected?: { account: IAccountModel };
}

class Result {
    static addAccountRequested() { return new Result({ addAccountRequested: true }); }

    static menuRequested() { return new Result({ menuRequested: true }); }

    static accountSelected(account: IAccountModel) {
        return new Result({ accountSelected: { account: account } });
    }

    private constructor(private readonly results: IResults) { }

    get addAccountRequested() { return this.results.addAccountRequested; }

    get menuRequested() { return this.results.menuRequested; }

    get accountSelected() { return this.results.accountSelected; }
}

export class PortfolioPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly alert: MessageAlert;
    private readonly portfolioNameText: TextComponent;
    private readonly accountListCard: AccountListCard;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: PortfolioPanelView) {
        this.alert = new MessageAlert(view.alert);
        this.portfolioNameText = new TextComponent(view.portfolioNameTextView);
        this.accountListCard = new AccountListCard(copiaClient, view.accountListCardView);
        this.accountListCard.when.addRequested.then(this.onAddAccountRequested.bind(this));
        this.accountListCard.when.accountSelected.then(this.onAccountSelected.bind(this));
        new Command(this.menu.bind(this)).add(view.menuButton);
    }

    private menu() { this.awaitable.resolve(Result.menuRequested()); }

    private onAddAccountRequested() { this.awaitable.resolve(Result.addAccountRequested()); }

    private onAccountSelected(account: IAccountModel) {
        this.awaitable.resolve(Result.accountSelected(account));
    }

    refresh() {
        const promises = [
            this.refreshPortfolio(),
            this.accountListCard.refresh()
        ];
        return Promise.all(promises);
    }

    private async refreshPortfolio() {
        const portfolio = await this.alert.infoAction(
            'Loading...',
            () => this.copiaClient.Portfolio.GetPortfolio()
        );
        this.portfolioNameText.setText(portfolio.PortfolioName);
    }

    start() { return this.awaitable.start(); }

    activate() { this.view.show(); }

    deactivate() { this.view.hide(); }

}