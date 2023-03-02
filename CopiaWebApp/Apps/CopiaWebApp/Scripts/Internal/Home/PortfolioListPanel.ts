import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { AsyncCommand, Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { ListGroup } from "@jasonbenfield/sharedwebapp/Components/ListGroup";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { DelayedAction } from "@jasonbenfield/sharedwebapp/DelayedAction";
import { TextInputFormGroup } from "@jasonbenfield/sharedwebapp/Forms/TextInputFormGroup";
import { TextLinkListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { AddPortfolioPanelView } from "./AddPortfolioPanelView";
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

    constructor(private readonly copiaApi: CopiaAppApi, private readonly view: PortfolioListPanelView) {
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
            () => this.copiaApi.Portfolios.GetPortfolios()
        );
        this.portfolioListGroup.setItems(
            portfolios,
            (p, v) => new PortfolioListItem(this.copiaApi, p, v)
        );
    }

    start() { return this.awaitable.start(); }

    activate() { this.view.show(); }

    deactivate() { this.view.hide(); }
}