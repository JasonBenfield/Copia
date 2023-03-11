import { MarginCss } from "@jasonbenfield/sharedwebapp/MarginCss";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { BasicTextComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicTextComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { TextHeading1View } from "@jasonbenfield/sharedwebapp/Views/TextHeadings";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";
import { AccountListCardView } from "./AccountListCardView";

export class PortfolioPanelView extends PanelView {
    readonly portfolioNameTextView: BasicTextComponentView;
    readonly alert: MessageAlertView;
    readonly accountListCardView: AccountListCardView;
    readonly menuButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.portfolioNameTextView = this.body.addView(TextHeading1View);
        this.portfolioNameTextView.setMargin(MarginCss.bottom(3));
        this.alert = this.body.addView(MessageAlertView);
        this.accountListCardView = this.body.addView(AccountListCardView);
        this.accountListCardView.setMargin(MarginCss.bottom(3));
        this.menuButton = CopiaTheme.instance.commandToolbar.menuButton(
            this.toolbar.addButtonCommandToStart()
        );
    }
}