import { BasicComponent } from "@jasonbenfield/sharedwebapp/Components/BasicComponent";
import { LinkComponent } from "@jasonbenfield/sharedwebapp/Components/LinkComponent";
import { CopiaAppApi } from "../Lib/Api/CopiaAppApi";
import { PortfolioMenuComponentView } from "./PortfolioMenuComponentView";

export class PortfolioMenuComponent extends BasicComponent {
    private readonly portfolioLink: LinkComponent;
    private readonly activityTemplatesLink: LinkComponent;
    private readonly counterpartiesLink: LinkComponent;

    constructor(private readonly copiaClient: CopiaAppApi, view: PortfolioMenuComponentView) {
        super(view);
        this.portfolioLink = new LinkComponent(view.portfolioLinkView);
        this.activityTemplatesLink = new LinkComponent(view.activityTemplatesLinkView);
        this.counterpartiesLink = new LinkComponent(view.counterpartiesLinkView);
    }

    load() {
        this.portfolioLink.setHref(this.copiaClient.Portfolio.Index.getUrl({}));
        this.activityTemplatesLink.setHref(this.copiaClient.ActivityTemplates.Index.getUrl({}));
        this.counterpartiesLink.setHref(this.copiaClient.Counterparties.Index.getUrl({}));
    }

    show() {
        this.view.show();
    }

    hide() {
        this.view.hide();
    }
}