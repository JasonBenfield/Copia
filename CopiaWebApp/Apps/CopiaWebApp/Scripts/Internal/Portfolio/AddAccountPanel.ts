import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { AsyncCommand, Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { AccountType } from "../../Lib/Api/AccountType";
import { AddAccountForm } from "../../Lib/Api/AddAccountForm";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { AddAccountPanelView } from "./AddAccountPanelView";

interface IResults {
    readonly saved?: boolean;
    readonly cancelled?: boolean;
}

class Result {
    static saved() { return new Result({ saved: true }); }

    static cancelled() { return new Result({ cancelled: true }); }

    private constructor(private readonly results: IResults) { }

    get saved() { return this.results.saved; }

    get cancelled() { return this.results.saved; }
}

export class AddAccountPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly addForm: AddAccountForm;
    private readonly alert: MessageAlert;
    private readonly saveCommand: AsyncCommand;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: AddAccountPanelView) {
        this.addForm = new AddAccountForm(view.addForm);
        this.addForm.handleSubmit(this.onSubmit.bind(this));
        this.alert = new MessageAlert(view.alert);
        this.saveCommand = new AsyncCommand(this.save.bind(this));
        this.saveCommand.add(view.saveButton);
        new Command(this.cancel.bind(this)).add(view.cancelButton);
    }

    private onSubmit() {
        return this.saveCommand.execute();
    }

    private cancel() {
        this.awaitable.resolve(Result.cancelled());
    }

    private async save() {
        const result = await this.alert.infoAction(
            'Adding...',
            () => this.addForm.save(this.copiaClient.Portfolio.AddAccountAction)
        );
        if (result.succeeded()) {
            this.awaitable.resolve(Result.saved());
        }
    }

    start() {
        return this.awaitable.start();
    }

    activate() {
        this.view.show();
        this.addForm.AccountName.setValue('');
        this.addForm.AccountType.setValue(AccountType.values.Checking.Value);
        this.view.setFocus();
    }

    deactivate() { this.view.hide(); }

}