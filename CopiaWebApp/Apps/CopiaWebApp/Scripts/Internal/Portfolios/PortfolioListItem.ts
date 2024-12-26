import { BasicComponent } from "@jasonbenfield/sharedwebapp/Components/BasicComponent";
import { TextLinkListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { CopiaAppClient } from "../../Lib/Http/CopiaAppClient";

export class PortfolioListItem extends BasicComponent {
    constructor(copiaClient: CopiaAppClient, portfolio: IPortfolioModel, view: TextLinkListGroupItemView) {
        super(view);
        view.setText(portfolio.PortfolioName);
        view.setHref(
            copiaClient.Portfolio.Index.getModifierUrl(portfolio.PublicKey.DisplayText, {}).value()
        );
    }
}