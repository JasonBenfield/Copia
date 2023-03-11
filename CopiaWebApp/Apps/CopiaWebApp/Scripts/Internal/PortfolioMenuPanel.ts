import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { LinkComponent } from "@jasonbenfield/sharedwebapp/Components/LinkComponent";
import { CopiaAppApi } from "../Lib/Api/CopiaAppApi";
import { PortfolioMenuPanelView } from "./PortfolioMenuPanelView";

interface IResult {
    back?: boolean;
}

class Result {
    static back() { return new Result({ back: true }); }

    private constructor(private readonly results: IResult) { }

    get back() { return this.results.back; }
}

export class PortfolioMenuPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly portfolioLink: LinkComponent;
            
    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: PortfolioMenuPanelView) {
        this.portfolioLink = new LinkComponent(view.portfolioLinkView);
        new Command(this.back.bind(this)).add(view.backButton);
    }

    private back() { this.awaitable.resolve(Result.back()); }

    start() { return this.awaitable.start(); }

    activate() {
        this.view.show();
        this.portfolioLink.setHref(this.copiaClient.Portfolio.Index.getUrl({}));
    }

    deactivate() { this.view.hide(); }
}