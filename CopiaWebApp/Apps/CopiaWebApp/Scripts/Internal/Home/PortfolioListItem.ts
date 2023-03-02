import { BasicComponent } from "@jasonbenfield/sharedwebapp/Components/BasicComponent";
import { TextLinkListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";

export class PortfolioListItem extends BasicComponent {
    constructor(copiaClient: CopiaAppApi, portfolio: IPortfolioModel, view: TextLinkListGroupItemView) {
        super(view);
        view.setText(portfolio.PortfolioName);
        view.setHref(
            copiaClient.Portfolio.Index.getModifierUrl(portfolio.PublicKey.DisplayText, {}).value()
        );
    }
}