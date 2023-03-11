import { CardAlert } from "@jasonbenfield/sharedwebapp/Components/CardAlert";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { ListGroup } from "@jasonbenfield/sharedwebapp/Components/ListGroup";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { EventSource } from "@jasonbenfield/sharedwebapp/Events";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { AccountListCardView } from "./AccountListCardView";
import { AccountListItem } from "./AccountListItem";
import { AccountListItemView } from "./AccountListItemView";

type Events = { addRequested: boolean, accountSelected: IAccountModel };

export class AccountListCard {
    private readonly alert: MessageAlert;
    private readonly accountList: ListGroup<AccountListItem, AccountListItemView>;
    private readonly eventSource = new EventSource<Events>(
        this,
        { addRequested: false, accountSelected: null }
    );
    readonly when = this.eventSource.when;
    private readonly addCommand: Command;

    constructor(private readonly copiaClient: CopiaAppApi, view: AccountListCardView) {
        this.alert = new CardAlert(view.cardAlert).alert;
        this.accountList = new ListGroup(view.accountListView);
        this.accountList.registerItemClicked(this.onAccountSelected.bind(this));
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