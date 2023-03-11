import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { TextComponent } from "@jasonbenfield/sharedwebapp/Components/TextComponent";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { AccountPanelView } from "./AccountPanelView";

interface IResults {
    readonly menuRequested?: boolean;
}

class Result {
    static menuRequested() { return new Result({ menuRequested: true }); }

    private constructor(private readonly results: IResults) { }

    get menuRequested() { return this.results.menuRequested; }
}

export class AccountPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly alert: MessageAlert;
    private readonly accountNameText: TextComponent;
    private readonly accountTypeText: TextComponent;
    private accountID: number;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: AccountPanelView) {
        this.alert = new MessageAlert(view.alert);
        this.accountNameText = new TextComponent(view.accountNameTextView);
        this.accountTypeText = new TextComponent(view.accountTypeTextView);
        new Command(this.menu.bind(this)).add(view.menuButton);
    }

    private menu() { this.awaitable.resolve(Result.menuRequested()); }

    setAccountID(accountID: number) {
        this.accountID = accountID;
    }

    async refresh() {
        const account = await this.alert.infoAction(
            'Loading...',
            () => this.copiaClient.Account.GetAccount({ AccountID: this.accountID })
        );
        this.accountNameText.setText(account.AccountName);
        this.accountTypeText.setText(account.AccountType.DisplayText);
    }

    start() { return this.awaitable.start(); }

    activate() { this.view.show(); }

    deactivate() { this.view.hide(); }

}