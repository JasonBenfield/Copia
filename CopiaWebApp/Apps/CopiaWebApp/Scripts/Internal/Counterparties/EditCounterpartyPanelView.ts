import { MarginCss } from "@jasonbenfield/sharedwebapp/MarginCss";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { EditCounterpartyFormView } from "../../Lib/Api/EditCounterpartyFormView";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class EditCounterpartyPanelView extends PanelView {
    readonly editFormView: EditCounterpartyFormView;
    readonly alertView: MessageAlertView;
    readonly cancelButton: ButtonCommandView;
    readonly saveButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.editFormView = this.body.addView(EditCounterpartyFormView);
        this.editFormView.addOffscreenSubmit();
        this.editFormView.addContent();
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
        this.editFormView
            .onSubmit()
            .preventDefault()
            .execute(action)
            .subscribe();
    }
}