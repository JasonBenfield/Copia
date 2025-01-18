import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { ListGroup } from "@jasonbenfield/sharedwebapp/Components/ListGroup";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { TextLinkListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { CopiaAppClient } from "../../Lib/Http/CopiaAppClient";
import { PortfolioListItem } from "./PortfolioListItem";
import { PortfolioListPanelView } from "./PortfolioListPanelView";

interface IResults {
    readonly add?: boolean;
}

class Result {
    static add() { return new Result({ add: true }); }

    private constructor(private readonly results: IResults) { }

    get add() { return this.results.add; }
}

export class PortfolioListPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly alert: MessageAlert;
    private readonly portfolioListGroup: ListGroup<PortfolioListItem, TextLinkListGroupItemView>;

    constructor(
        private readonly copiaClient: CopiaAppClient,
        private readonly view: PortfolioListPanelView,
        private readonly autoOpenSinglePortfolio: boolean
    ) {
        this.alert = new MessageAlert(view.alert);
        this.portfolioListGroup = new ListGroup(view.portfolioListGroup);
        new Command(this.add.bind(this)).add(view.addButton);
    }

    private add() {
        this.awaitable.resolve(Result.add());
    }

    async refresh() {
        const portfolios = await this.alert.infoAction(
            'Loading...',
            () => this.copiaClient.Portfolios.GetPortfolios()
        );
        this.portfolioListGroup.setItems(
            portfolios,
            (p, v) => new PortfolioListItem(this.copiaClient, p, v)
        );
        if (this.autoOpenSinglePortfolio && portfolios.length === 1) {
            this.copiaClient.Portfolio.Index.open({}, portfolios[0].PublicKey.Value);
        }
    }

    start() { return this.awaitable.start(); }

    activate() { this.view.show(); }

    deactivate() { this.view.hide(); }
}