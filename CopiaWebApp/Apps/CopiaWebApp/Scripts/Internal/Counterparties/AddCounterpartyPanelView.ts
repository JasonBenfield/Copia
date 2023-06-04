import { MarginCss } from "@jasonbenfield/sharedwebapp/MarginCss";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { AddCounterpartyFormView } from "../../Lib/Api/AddCounterpartyFormView";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class AddCounterpartyPanelView extends PanelView {
    readonly addFormView: AddCounterpartyFormView;
    readonly alertView: MessageAlertView;
    readonly cancelButton: ButtonCommandView;
    readonly saveButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.addFormView = this.body.addView(AddCounterpartyFormView);
        this.addFormView.addOffscreenSubmit();
        this.addFormView.addContent();
        this.alertView = this.body.addView(MessageAlertView);
        this.cancelButton = CopiaTheme.instance.commandToolbar.cancelButton(
            this.toolbar.addButtonCommandToEnd()
        );
        this.cancelButton.setMargin(MarginCss.end(1));
        this.saveButton = CopiaTheme.instance.commandToolbar.saveButton(
            this.toolbar.addButtonCommandToEnd()
        );
    }

    handleFormSubmit(action: () => void) {
        this.addFormView
            .onSubmit()
            .preventDefault()
            .execute(action)
            .subscribe();
    }
}