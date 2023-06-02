import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { BooleanInputControl } from "@jasonbenfield/sharedwebapp/Components/BooleanInputControl";
import { AsyncCommand, Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { SelectControl } from "@jasonbenfield/sharedwebapp/Components/SelectControl";
import { SelectOption } from "@jasonbenfield/sharedwebapp/Components/SelectOption";
import { TextComponent } from "@jasonbenfield/sharedwebapp/Components/TextComponent";
import { DebouncedAction } from "@jasonbenfield/sharedwebapp/DebouncedAction";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { TemplateStringArrayType } from "../../Lib/Api/TemplateStringArrayType";
import { TemplateStringDataType } from "../../Lib/Api/TemplateStringDataType";
import { TemplateStringFieldType } from "../../Lib/Api/TemplateStringFieldType";
import { TemplateStringPartType } from "../../Lib/Api/TemplateStringPartType";
import { EditTemplateStringPanelView } from "./EditTemplateStringPanelView";
import { EditTemplateStringPartListComponent } from "./EditTemplateStringPartListComponent";
import { TemplateString } from "./TemplateString";

interface IResults {
    readonly saved?: boolean;
    readonly cancelled?: boolean;
}

class Result {
    static saved() {
        return new Result({ saved: true });
    }

    static cancelled() { return new Result({ cancelled: true }); }

    private constructor(private readonly results: IResults) { }

    get saved() { return this.results.saved; }

    get cancelled() { return this.results.cancelled; }
}

export class EditTemplateStringPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly alert: MessageAlert;
    private readonly canEditControl: SelectControl<boolean>;
    private readonly outputTextControl: TextComponent;
    private readonly partListComponent: EditTemplateStringPartListComponent;
    private templateStringID: number;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: EditTemplateStringPanelView) {
        this.alert = new MessageAlert(view.alert);
        this.canEditControl = new SelectControl(view.canEditInputView);
        this.canEditControl.setItems(
            new SelectOption(true, 'Yes'),
            new SelectOption(false, 'No')
        );
        this.outputTextControl = new TextComponent(view.outputTextView);
        this.partListComponent = new EditTemplateStringPartListComponent(view.partListView);
        this.partListComponent.when.templateStringChanged.then(() => this.debouncedOnTemplateStringChanged.execute());
        new Command(this.addPart.bind(this)).add(view.addPartButton);
        new Command(this.cancel.bind(this)).add(view.cancelButton);
        new AsyncCommand(this.save.bind(this)).add(view.saveButton);
    }

    private cancel() {
        this.awaitable.resolve(Result.cancelled());
    }

    private async save() {
        const editRequest: IEditTemplateStringRequest = {
            ID: this.templateStringID,
            CanEdit: this.canEditControl.getValue(),
            Parts: this.partListComponent.getAddPartRequests()
        };
        await this.alert.infoAction(
            'Saving...',
            () => this.copiaClient.ActivityTemplate.EditTemplateString(editRequest)
        );
        this.awaitable.resolve(Result.saved());
    }

    private readonly debouncedOnTemplateStringChanged = new DebouncedAction(
        this.onTemplateStringChanged.bind(this),
        500
    );

    private onTemplateStringChanged() {
        const templateString = new TemplateString(this.partListComponent.getTemplateStringParts());
        this.outputTextControl.setText(templateString.format());
    }

    private addPart() {
        const partComponent = this.partListComponent.addPart();
        partComponent.load({
            ID: 0,
            PartType: TemplateStringPartType.values.FixedText,
            ArrayType: TemplateStringArrayType.values.NotSet,
            ArrayIndex: 0,
            FieldType: TemplateStringFieldType.values.NotSet,
            FixedText: ''
        });
    }

    setTemplateString(templateString: ITemplateStringModel) {
        this.templateStringID = templateString.ID;
        this.canEditControl.setValue(templateString.CanEdit);
        this.outputTextControl.setText(new TemplateString(templateString).format());
        const dataType = TemplateStringDataType.values.value(templateString.DataType.Value);
        this.partListComponent.setParts(dataType, templateString.Parts);
    }

    start() { return this.awaitable.start(); }

    activate() { this.view.show(); }

    deactivate() { this.view.hide(); }

}