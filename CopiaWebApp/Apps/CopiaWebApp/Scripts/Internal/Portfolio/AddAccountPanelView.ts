import { DelayedAction } from "@jasonbenfield/sharedwebapp/DelayedAction";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { AddAccountFormView } from "../../Lib/Api/AddAccountFormView";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class AddAccountPanelView extends PanelView {
    readonly addForm: AddAccountFormView;
    readonly alert: MessageAlertView;
    readonly cancelButton: ButtonCommandView;
    readonly saveButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.addForm = this.body.addView(AddAccountFormView);
        this.addForm.addOffscreenSubmit();
        this.addForm.addContent();
        this.alert = this.body.addView(MessageAlertView);
        this.cancelButton = CopiaTheme.instance.commandToolbar.cancelButton(
            this.toolbar.addButtonCommandToEnd()
        );
        this.saveButton = CopiaTheme.instance.commandToolbar.saveButton(
            this.toolbar.addButtonCommandToEnd()
        );
    }

    setFocus() {
        new DelayedAction(() => {
            this.addForm.AccountName.input.setFocus();
        }, 100).execute();
    }
}