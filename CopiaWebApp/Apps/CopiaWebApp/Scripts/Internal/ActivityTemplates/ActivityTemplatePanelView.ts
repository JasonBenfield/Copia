import { ContextualClass } from "@jasonbenfield/sharedwebapp/ContextualClass";
import { CssLengthUnit } from "@jasonbenfield/sharedwebapp/CssLengthUnit";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { BasicTextComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicTextComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { FormGroupGridView, FormGroupTextView } from "@jasonbenfield/sharedwebapp/Views/FormGroup";
import { GridListGroupView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { TextHeading1View } from "@jasonbenfield/sharedwebapp/Views/TextHeadings";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";
import { ActivityTemplateFieldListItemView } from "./ActivityTemplateFieldListItemView";

export class ActivityTemplatePanelView extends PanelView {
    readonly alert: MessageAlertView;
    readonly templateNameView: BasicTextComponentView;
    readonly activityNameView: BasicTextComponentView;
    readonly editActivityNameButton: ButtonCommandView;
    readonly fieldListGroupView: GridListGroupView<ActivityTemplateFieldListItemView>;
    readonly backButton: ButtonCommandView;
    
    constructor(container: BasicComponentView) {
        super(container);
        this.alert = this.body.addView(MessageAlertView);
        this.templateNameView = this.body.addView(TextHeading1View);
        const fieldGroupContainer = this.body.addView(FormGroupGridView);
        fieldGroupContainer.setTemplateColumns(
            CssLengthUnit.maxContent(),
            CssLengthUnit.flex(1),
            CssLengthUnit.maxContent()
        );
        const activityNameFormGroup = fieldGroupContainer.addFormGroup(FormGroupTextView);
        activityNameFormGroup.caption.setText('Activity Name');
        this.activityNameView = activityNameFormGroup.textValue;
        this.editActivityNameButton = activityNameFormGroup.addCell().addView(ButtonCommandView);
        this.editActivityNameButton.icon.solidStyle('edit');
        this.editActivityNameButton.setText('Edit');
        this.editActivityNameButton.useOutlineStyle(ContextualClass.secondary);
        this.fieldListGroupView = this.body.addGridListGroup(ActivityTemplateFieldListItemView);
        this.fieldListGroupView.setTemplateColumns(
            CssLengthUnit.flex(1),
            CssLengthUnit.maxContent()
        );
        this.backButton = CopiaTheme.instance.commandToolbar.backButton(
            this.toolbar.addButtonCommandToStart()
        );
    }
}