import { FlexCss } from "@jasonbenfield/sharedwebapp/FlexCss";
import { MarginCss } from "@jasonbenfield/sharedwebapp/MarginCss";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { LinkCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { NavView } from "@jasonbenfield/sharedwebapp/Views/NavView";

export class PortfolioMenuComponentView extends NavView {
    readonly portfolioLinkView: LinkCommandView;
    readonly activityTemplatesLinkView: LinkCommandView;
    readonly counterpartiesLinkView: LinkCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.pills();
        this.setFlexCss(new FlexCss().column());
        this.configListItem(li => li.setMargin(MarginCss.bottom(3)));
        this.portfolioLinkView = this.addMenuItem();
        this.portfolioLinkView.setText('Portfolio');
        this.activityTemplatesLinkView = this.addMenuItem();
        this.activityTemplatesLinkView.setText('Activity Templates');
        this.counterpartiesLinkView = this.addMenuItem();
        this.counterpartiesLinkView.setText('Counterparties');
    }
}