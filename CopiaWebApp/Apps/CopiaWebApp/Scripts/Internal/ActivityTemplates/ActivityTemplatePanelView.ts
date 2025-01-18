import { ContextualClass } from "@jasonbenfield/sharedwebapp/ContextualClass";
import { CssLengthUnit } from "@jasonbenfield/sharedwebapp/CssLengthUnit";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { BasicTextComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicTextComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { FormGroupTextView } from "@jasonbenfield/sharedwebapp/Views/FormGroup";
import { FormGroupContainerView } from "@jasonbenfield/sharedwebapp/Views/FormGroupContainerView";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { TextHeading1View } from "@jasonbenfield/sharedwebapp/Views/TextHeadings";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class ActivityTemplatePanelView extends PanelView {
    readonly alert: MessageAlertView;
    readonly templateNameView: BasicTextComponentView;
    readonly activityNameView: BasicTextComponentView;
    readonly editActivityNameButton: ButtonCommandView;
    readonly backButton: ButtonCommandView;
    
    constructor(container: BasicComponentView) {
        super(container);
        this.alert = this.body.addView(MessageAlertView);
        this.templateNameView = this.body.addView(TextHeading1View);
        const fieldGroupContainer = this.body.addView(FormGroupContainerView);
        fieldGroupContainer.setTemplateColumns(
            CssLengthUnit.maxContent(),
            CssLengthUnit.flex(1),
            CssLengthUnit.maxContent()
        );
        const activityNameFormGroup = fieldGroupContainer.addFormGroup(FormGroupTextView);
        activityNameFormGroup.caption.setText("Activity Name");
        this.activityNameView = activityNameFormGroup.valueTextView;
        this.editActivityNameButton = activityNameFormGroup.addCell().addView(ButtonCommandView);
        this.editActivityNameButton.icon.solidStyle("edit");
        this.editActivityNameButton.setText("Edit");
        this.editActivityNameButton.useOutlineStyle(ContextualClass.secondary);
        this.backButton = CopiaTheme.instance.commandToolbar.backButton(
            this.toolbar.addButtonCommandToStart()
        );
    }
}