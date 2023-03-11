import { CssLengthUnit } from "@jasonbenfield/sharedwebapp/CssLengthUnit";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { CardAlertView, CardView } from "@jasonbenfield/sharedwebapp/Views/Card";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { GridView } from "@jasonbenfield/sharedwebapp/Views/Grid";
import { GridListGroupView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { TextHeading3View } from "@jasonbenfield/sharedwebapp/Views/TextHeadings";
import { CopiaTheme } from "../CopiaTheme";
import { AccountListItemView } from "./AccountListItemView";

export class AccountListCardView extends CardView {
    readonly accountListView: GridListGroupView<AccountListItemView>;
    readonly addButton: ButtonCommandView;
    readonly cardAlert: CardAlertView;

    constructor(container: BasicComponentView) {
        super(container);
        const header = this.addCardHeader();
        const headerGrid = header.addView(GridView);
        headerGrid.layout();
        headerGrid.setTemplateColumns(
            CssLengthUnit.flex(1),
            CssLengthUnit.auto()
        );
        const titleView = headerGrid.addCell().addView(TextHeading3View);
        titleView.setText('Accounts');
        this.addButton = CopiaTheme.instance.cardHeader.addButton(
            headerGrid.addCell().addView(ButtonCommandView)
        );
        this.cardAlert = this.addCardAlert();
        this.accountListView = this.addGridListGroup(AccountListItemView);
        this.accountListView.setTemplateColumns(
            CssLengthUnit.flex(1),
            CssLengthUnit.auto()
        );
    }
}