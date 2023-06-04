import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { AsyncCommand, Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { DelayedAction } from "@jasonbenfield/sharedwebapp/DelayedAction";
import { AddCounterpartyForm } from "../../Lib/Api/AddCounterpartyForm";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { AddCounterpartyPanelView } from "./AddCounterpartyPanelView";

interface IResults {
    cancelled?: boolean;
    added?: { counterparty: ICounterpartyModel; };
}

class Result {
    static cancelled() { return new Result({ cancelled: true }); }

    static added(counterparty: ICounterpartyModel) {
        return new Result({ added: { counterparty: counterparty } })
    }
    private constructor(private readonly results: IResults) { }

    get cancelled() { return this.results.cancelled; }

    get added() { return this.results.added; }
}

export class AddCounterpartyPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly addForm: AddCounterpartyForm;
    private readonly alert: MessageAlert;
    private readonly saveCommand: AsyncCommand;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: AddCounterpartyPanelView) {
        this.addForm = new AddCounterpartyForm(view.addFormView);
        this.alert = new MessageAlert(view.alertView);
        view.handleFormSubmit(this.onFormSubmit.bind(this));
        new Command(this.cancel.bind(this)).add(view.cancelButton);
        this.saveCommand = new AsyncCommand(this.save.bind(this));
        this.saveCommand.add(view.saveButton);
    }

    private onFormSubmit() { return this.saveCommand.execute(); }

    private cancel() { this.awaitable.resolve(Result.cancelled()); }

    private async save() {
        const result = await this.alert.infoAction(
            'Saving...',
            () => this.addForm.save(this.copiaClient.Counterparties.AddCounterpartyAction)
        );
        if (result.succeeded) {
            this.awaitable.resolve(Result.added(result.value));
        }
    }

    reset() {
        this.addForm.DisplayText.setValue('');
        this.addForm.Url.setValue('');
    }

    start() {
        return this.awaitable.start();
    }

    activate() {
        this.view.show();
        new DelayedAction(
            () => this.addForm.DisplayText.setFocus(),
            100
        ).execute();
    }

    deactivate() { this.view.hide(); }

}