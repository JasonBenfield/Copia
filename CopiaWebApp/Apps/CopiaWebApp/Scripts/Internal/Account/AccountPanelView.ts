import { MarginCss } from "@jasonbenfield/sharedwebapp/MarginCss";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { BasicTextComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicTextComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { TextHeading1View } from "@jasonbenfield/sharedwebapp/Views/TextHeadings";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class AccountPanelView extends PanelView {
    readonly accountNameTextView: BasicTextComponentView;
    readonly accountTypeTextView: BasicTextComponentView;
    readonly alert: MessageAlertView;
    readonly menuButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.alert = this.body.addView(MessageAlertView);
        this.accountNameTextView = this.body.addView(TextHeading1View);
        this.accountNameTextView.setMargin(MarginCss.bottom(3));
        this.menuButton = CopiaTheme.instance.commandToolbar.menuButton(
            this.toolbar.addButtonCommandToStart()
        );
    }
}