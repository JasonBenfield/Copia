import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { FormGroupGridView, FormGroupInputView } from "@jasonbenfield/sharedwebapp/Views/FormGroup";
import { FormView } from "@jasonbenfield/sharedwebapp/Views/FormView";
import { InputView } from "@jasonbenfield/sharedwebapp/Views/InputView";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class AddActivityTemplatePanelView extends PanelView {
    readonly alert: MessageAlertView;
    private readonly form: FormView;
    readonly templateNameInputView: InputView;
    readonly cancelButton: ButtonCommandView;
    readonly saveButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.form = this.body.addView(FormView);
        this.form.addOffscreenSubmit();
        const formGroupContainer = this.form.addView(FormGroupGridView);
        const templateNameFormGroup = formGroupContainer.addFormGroup(FormGroupInputView);
        templateNameFormGroup.caption.setText('Template Name');
        this.templateNameInputView = templateNameFormGroup.input;
        this.alert = this.body.addView(MessageAlertView);
        this.cancelButton = CopiaTheme.instance.commandToolbar.cancelButton(
            this.toolbar.addButtonCommandToEnd()
        );
        this.saveButton = CopiaTheme.instance.commandToolbar.saveButton(
            this.toolbar.addButtonCommandToEnd()
        );
    }

    handleSubmit(action: (el: HTMLElement, evt: JQuery.Event) => void) {
        this.form.onSubmit()
            .preventDefault()
            .execute(action)
            .subscribe();
    }
}