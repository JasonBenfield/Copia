import { CardAlert } from "@jasonbenfield/sharedwebapp/Components/CardAlert";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { ListGroup } from "@jasonbenfield/sharedwebapp/Components/ListGroup";
import { IMessageAlert } from "@jasonbenfield/sharedwebapp/Components/Types";
import { EventSource } from "@jasonbenfield/sharedwebapp/Events";
import { CopiaAppClient } from "../../Lib/Http/CopiaAppClient";
import { AccountListCardView } from "./AccountListCardView";
import { AccountListItem } from "./AccountListItem";
import { AccountListItemView } from "./AccountListItemView";

type Events = { addRequested: boolean, accountSelected: IAccountModel };

export class AccountListCard {
    private readonly alert: IMessageAlert;
    private readonly accountList: ListGroup<AccountListItem, AccountListItemView>;
    private readonly eventSource = new EventSource<Events>(
        this,
        { addRequested: false, accountSelected: null }
    );
    readonly when = this.eventSource.when;
    private readonly addCommand: Command;

    constructor(private readonly copiaClient: CopiaAppClient, view: AccountListCardView) {
        this.alert = new CardAlert(view.cardAlert);
        this.accountList = new ListGroup(view.accountListView);
        this.accountList.when.itemClicked.then(this.onAccountSelected.bind(this));
        this.addCommand = new Command(this.add.bind(this));
        this.addCommand.hide();
        this.addCommand.add(view.addButton);
        this.getPermissions();
    }

    private onAccountSelected(accountListItem: AccountListItem) {
        this.eventSource.events.accountSelected.invoke(accountListItem.account);
    }

    private async getPermissions() {
        const permissions = await this.copiaClient.getUserAccess({
            canAdd: this.copiaClient.getAccessRequest(api => api.Portfolio.AddAccountAction)
        });
        if (permissions.canAdd) {
            this.addCommand.show();
        }
    }

    private add() {
        this.eventSource.events.addRequested.invoke(true);
    }

    async refresh() {
        const accounts = await this.alert.infoAction(
            'Loading...',
            () => this.copiaClient.Portfolio.GetAccounts()
        );
        this.accountList.setItems(
            accounts,
            (a, itemView) => new AccountListItem(a, itemView)
        );
        if (accounts.length === 0) {
            this.alert.danger('No accounts have been added');
        }
    }
}