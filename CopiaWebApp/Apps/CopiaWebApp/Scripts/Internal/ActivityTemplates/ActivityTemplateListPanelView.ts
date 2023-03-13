import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { ButtonListGroupView, TextButtonListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class ActivityTemplateListPanelView extends PanelView {
    readonly activityTemplateListGroupView: ButtonListGroupView<TextButtonListGroupItemView>;
    readonly alert: MessageAlertView;
    readonly menuButton: ButtonCommandView;
    readonly addButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.alert = this.body.addView(MessageAlertView);
        this.activityTemplateListGroupView = this.body.addButtonListGroup(TextButtonListGroupItemView);
        this.menuButton = CopiaTheme.instance.commandToolbar.menuButton(
            this.toolbar.addButtonCommandToStart()
        );
        this.addButton = CopiaTheme.instance.commandToolbar.addButton(
            this.toolbar.addButtonCommandToEnd()
        );
    }
}