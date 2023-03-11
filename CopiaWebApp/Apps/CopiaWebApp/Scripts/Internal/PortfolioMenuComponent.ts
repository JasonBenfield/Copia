import { MenuComponent } from "@jasonbenfield/sharedwebapp/Components/MenuComponent";
import { MenuItemComponent } from "@jasonbenfield/sharedwebapp/Components/MenuItemComponent";
import { LinkCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { NavView } from "@jasonbenfield/sharedwebapp/Views/NavView";
import { CopiaAppApi } from "../Lib/Api/CopiaAppApi";

export class PortfolioMenuComponent extends MenuComponent {
    constructor(private readonly copiaClient: CopiaAppApi, view: NavView) {
        super(copiaClient, 'portfolio', view);
    }

    protected configureMenuItem(menuItem: MenuItemComponent, itemView: LinkCommandView) {
        if (menuItem.isNamed('portfolio')) {
            itemView.setHref(this.copiaClient.Portfolio.Index.getUrl({}).value());
        }
    }
}