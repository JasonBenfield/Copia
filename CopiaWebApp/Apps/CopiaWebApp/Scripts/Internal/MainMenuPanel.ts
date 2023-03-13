import { XtiUrl } from "@jasonbenfield/sharedwebapp/Api/XtiUrl";
import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MenuComponent } from "@jasonbenfield/sharedwebapp/Components/MenuComponent";
import { Url } from "@jasonbenfield/sharedwebapp/Url";
import { CopiaAppApi } from "../Lib/Api/CopiaAppApi";
import { MainMenuPanelView } from "./MainMenuPanelView";
import { PortfolioMenuComponent } from "./PortfolioMenuComponent";

interface IResult {
    back?: boolean;
}

class Result {
    static back() { return new Result({ back: true }); }

    private constructor(private readonly results: IResult) { }

    get back() { return this.results.back; }
}

export class MainMenuPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly portfolioMenuComponent: PortfolioMenuComponent;
            
    constructor(copiaClient: CopiaAppApi, private readonly view: MainMenuPanelView) {
        const menu = new MenuComponent(copiaClient, 'main', view.menu);
        menu.refresh();
        this.portfolioMenuComponent = new PortfolioMenuComponent(copiaClient, view.portfolioMenu);
        new Command(this.back.bind(this)).add(view.backButton);
    }

    private back() { this.awaitable.resolve(Result.back()); }

    start() { return this.awaitable.start(); }

    activate() {
        this.view.show();
        if (XtiUrl.current().path.modifier) {
            this.portfolioMenuComponent.load();
            this.portfolioMenuComponent.show();
        }
        else {
            this.portfolioMenuComponent.hide();
        }
    }

    deactivate() { this.view.hide(); }
}