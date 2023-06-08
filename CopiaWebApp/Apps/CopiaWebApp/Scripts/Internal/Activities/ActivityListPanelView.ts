import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class ActivityListPanelView extends PanelView {
    readonly alertView: MessageAlertView;
    readonly menuButton: ButtonCommandView;
    readonly addButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.alertView = this.body.addView(MessageAlertView);
        this.menuButton = CopiaTheme.instance.commandToolbar.menuButton(
            this.toolbar.addButtonCommandToStart()
        );
        this.addButton = CopiaTheme.instance.commandToolbar.addButton(
            this.toolbar.addButtonCommandToEnd()
        );
    }
}