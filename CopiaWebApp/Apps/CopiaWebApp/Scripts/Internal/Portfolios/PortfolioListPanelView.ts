import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { ButtonListGroupView, TextLinkListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class PortfolioListPanelView extends PanelView {
    readonly alert: MessageAlertView;
    readonly portfolioListGroup: ButtonListGroupView<TextLinkListGroupItemView>;
    readonly addButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.alert = this.body.addView(MessageAlertView);
        this.portfolioListGroup = this.body.addButtonListGroup(TextLinkListGroupItemView);
        this.addButton = CopiaTheme.instance.commandToolbar.addButton(
            this.toolbar.columnEnd.addView(ButtonCommandView)
        );
    }
}