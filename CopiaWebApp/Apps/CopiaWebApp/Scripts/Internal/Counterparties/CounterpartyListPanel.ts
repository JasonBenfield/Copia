import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { InputControl } from "@jasonbenfield/sharedwebapp/Components/InputControl";
import { ListGroup } from "@jasonbenfield/sharedwebapp/Components/ListGroup";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { DebouncedAction } from "@jasonbenfield/sharedwebapp/DebouncedAction";
import { TextToTextViewValue } from "@jasonbenfield/sharedwebapp/Forms/TextToTextViewValue";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { CounterpartyListItem } from "./CounterpartyListItem";
import { CounterpartyListItemView } from "./CounterpartyListItemView";
import { CounterpartyListPanelView } from "./CounterpartyListPanelView";

interface IResults {
    menu?: boolean;
    addRequested?: boolean;
    editRequested?: { counterparty: ICounterpartyModel };
}

class Result {
    static menu() { return new Result({ menu: true }); }

    static addRequested() { return new Result({ addRequested: true }); }

    static editRequested(counterparty: ICounterpartyModel) {
        return new Result({ editRequested: { counterparty: counterparty } });
    }

    private constructor(private readonly results: IResults) { }

    get menu() { return this.results.menu; }

    get addRequested() { return this.results.addRequested; }

    get editRequested() { return this.results.editRequested; }
}

export class CounterpartyListPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly searchInputControl: InputControl<string>;
    private readonly alert: MessageAlert;
    private readonly counterpartyListGroup: ListGroup<CounterpartyListItem, CounterpartyListItemView>;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: CounterpartyListPanelView) {
        view.hideMoreAlert();
        this.searchInputControl = new InputControl(view.searchInputView, new TextToTextViewValue());
        this.searchInputControl.when.valueChanged.then(this.onSearchInputChanged.bind(this));
        this.alert = new MessageAlert(view.alertView);
        this.counterpartyListGroup = new ListGroup(view.counterpartyListView);
        view.handleEditButton(this.onEditCounterpartyClicked.bind(this));
        view.handleDeleteButton(this.onDeleteCounterpartyClicked.bind(this));
        new Command(this.menu.bind(this)).add(view.menuButton);
        new Command(this.add.bind(this)).add(view.addButton);
    }

    private onSearchInputChanged() { this.debouncedRefresh.execute(); }

    private add() { this.awaitable.resolve(Result.addRequested()); }

    private menu() { this.awaitable.resolve(Result.menu()); }

    private onEditCounterpartyClicked(el: HTMLElement, evt: JQuery.Event) {
        const counterpartyItem = this.counterpartyListGroup.getItemByElement(el);
        this.awaitable.resolve(Result.editRequested(counterpartyItem.counterparty));
    }

    private async onDeleteCounterpartyClicked(el: HTMLElement, evt: JQuery.Event) {
        const counterpartyItem = this.counterpartyListGroup.getItemByElement(el);
    }

    start() {
        return this.awaitable.start();
    }

    private debouncedRefresh = new DebouncedAction(
        this.refresh.bind(this),
        700
    );

    private async refresh() {
        this.view.hideMoreAlert();
        const searchText = this.searchInputControl.getValue();
        const searchResult = await this.alert.infoAction(
            'Loading...',
            () => this.copiaClient.Counterparties.CounterpartySearch(searchText)
        );
        this.counterpartyListGroup.setItems(
            searchResult.Counterparties,
            (c, itemView) => new CounterpartyListItem(c, itemView)
        );
        if (searchResult.Counterparties.length === 0) {
            this.alert.danger('No counterparties were found.');
        }
        else if (searchResult.Total > searchResult.Counterparties.length) {
            this.view.showMoreAlert();
        }
        this.searchInputControl.setFocus();
    }

    activate() {
        this.view.show();
        this.debouncedRefresh.execute();
    }

    deactivate() { this.view.hide(); }

}