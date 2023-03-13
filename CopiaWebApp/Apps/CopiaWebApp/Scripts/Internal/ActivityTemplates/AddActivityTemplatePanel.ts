import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { AsyncCommand, Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { InputControl } from "@jasonbenfield/sharedwebapp/Components/InputControl";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { DelayedAction } from "@jasonbenfield/sharedwebapp/DelayedAction";
import { TextToTextViewValue } from "@jasonbenfield/sharedwebapp/Forms/TextToTextViewValue";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { AddActivityTemplatePanelView } from "./AddActivityTemplatePanelView";

interface IResults {
    readonly added?: { activityTemplateDetail: IActivityTemplateDetailModel };
    readonly cancelled?: boolean;
}

class Result {
    static added(activityTemplateDetail: IActivityTemplateDetailModel) {
        return new Result({ added: { activityTemplateDetail: activityTemplateDetail } });
    }

    static cancelled() { return new Result({ cancelled: true }); }

    private constructor(private readonly results: IResults) { }

    get added() { return this.results.added; }

    get cancelled() { return this.results.cancelled; }
}

export class AddActivityTemplatePanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly alert: MessageAlert;
    private readonly templateNameInput: InputControl<string>;
    private readonly saveCommand: AsyncCommand;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: AddActivityTemplatePanelView) {
        this.alert = new MessageAlert(view.alert);
        this.templateNameInput = new InputControl(view.templateNameInputView, new TextToTextViewValue());
        this.saveCommand = new AsyncCommand(this.save.bind(this));
        this.saveCommand.add(view.saveButton);
        view.handleSubmit(this.onSubmit.bind(this));
        new Command(this.cancel.bind(this)).add(view.cancelButton);
    }

    private onSubmit() {
        return this.saveCommand.execute();
    }

    private async save() {
        const addRequest: IAddActivityTemplateRequest = {
            TemplateName: this.templateNameInput.getValue()
        };
        const activityTemplateDetail = await this.alert.infoAction(
            'Adding...',
            () => this.copiaClient.ActivityTemplates.AddActivityTemplate(addRequest)
        );
        this.awaitable.resolve(Result.added(activityTemplateDetail));
    }

    private cancel() { this.awaitable.resolve(Result.cancelled()); }

    start() { return this.awaitable.start(); }

    activate() {
        this.view.show();
        new DelayedAction(
            () => this.templateNameInput.setFocus(),
            500
        ).execute();
    }

    deactivate() { this.view.hide(); }

}