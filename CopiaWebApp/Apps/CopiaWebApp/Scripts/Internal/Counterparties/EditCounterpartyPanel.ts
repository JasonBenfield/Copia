import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { AsyncCommand, Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { DelayedAction } from "@jasonbenfield/sharedwebapp/DelayedAction";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { EditCounterpartyForm } from "../../Lib/Api/EditCounterpartyForm";
import { EditCounterpartyPanelView } from "./EditCounterpartyPanelView";

interface IResults {
    cancelled?: boolean;
    saved?: { counterparty: ICounterpartyModel; };
}

class Result {
    static cancelled() { return new Result({ cancelled: true }); }

    static saved(counterparty: ICounterpartyModel) {
        return new Result({ saved: { counterparty: counterparty } })
    }
    private constructor(private readonly results: IResults) { }

    get cancelled() { return this.results.cancelled; }

    get saved() { return this.results.saved; }
}

export class EditCounterpartyPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly editForm: EditCounterpartyForm;
    private readonly alert: MessageAlert;
    private readonly saveCommand: AsyncCommand;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: EditCounterpartyPanelView) {
        this.editForm = new EditCounterpartyForm(view.editFormView);
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
            () => this.editForm.save(this.copiaClient.Counterparties.EditCounterpartyAction)
        );
        if (result.succeeded) {
            this.awaitable.resolve(Result.saved(result.value));
        }
    }

    setCounterparty(counterparty: ICounterpartyModel) {
        this.editForm.CounterpartyID.setValue(counterparty.ID);
        this.editForm.DisplayText.setValue(counterparty.DisplayText);
        this.editForm.Url.setValue(counterparty.Url);
    }

    start() {
        return this.awaitable.start();
    }

    activate() {
        this.view.show();
        new DelayedAction(
            () => this.editForm.DisplayText.setFocus(),
            100
        ).execute();
    }

    deactivate() { this.view.hide(); }

}