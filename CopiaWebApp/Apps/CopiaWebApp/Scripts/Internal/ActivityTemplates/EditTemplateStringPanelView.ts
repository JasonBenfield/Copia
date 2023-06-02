import { MarginCss } from "@jasonbenfield/sharedwebapp/MarginCss";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { BasicTextComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicTextComponentView";
import { BooleanInputView } from "@jasonbenfield/sharedwebapp/Views/BooleanInputView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { FormGroupGridView, FormGroupTextView, FormGroupView } from "@jasonbenfield/sharedwebapp/Views/FormGroup";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { SelectView } from "@jasonbenfield/sharedwebapp/Views/SelectView";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";
import { EditTemplateStringPartListView } from "./EditTemplateStringPartListView";

export class EditTemplateStringPanelView extends PanelView {
    readonly canEditInputView: SelectView;
    readonly outputTextView: BasicTextComponentView;
    readonly partListView: EditTemplateStringPartListView;
    readonly addPartButton: ButtonCommandView;
    readonly alert: MessageAlertView;
    readonly cancelButton: ButtonCommandView;
    readonly saveButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        const formGroupContainer = this.body.addView(FormGroupGridView);
        const canEditFormGroup = formGroupContainer.addFormGroup(FormGroupView);
        canEditFormGroup.caption.setText('Can Edit?');
        this.canEditInputView = canEditFormGroup.valueCell.addView(SelectView);
        this.canEditInputView.styleAsFormControl();
        const outputFormGroup = formGroupContainer.addFormGroup(FormGroupTextView);
        outputFormGroup.caption.setText('Output');
        this.outputTextView = outputFormGroup.textValue;
        this.partListView = this.body.addView(EditTemplateStringPartListView);
        this.partListView.setMargin(MarginCss.bottom(3));
        this.addPartButton = this.body.addView(ButtonCommandView);
        this.addPartButton.icon.solidStyle('plus');
        this.addPartButton.setText('Add Part');
        this.addPartButton.setMargin(MarginCss.bottom(3));
        this.alert = this.body.addView(MessageAlertView);
        this.cancelButton = CopiaTheme.instance.commandToolbar.cancelButton(
            this.toolbar.addButtonCommandToEnd()
        );
        this.cancelButton.setMargin(MarginCss.end(1));
        this.saveButton = CopiaTheme.instance.commandToolbar.saveButton(
            this.toolbar.addButtonCommandToEnd()
        );
    }

}