import { CssLengthUnit } from "@jasonbenfield/sharedwebapp/CssLengthUnit";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { GridView } from "@jasonbenfield/sharedwebapp/Views/Grid";
import { ToolbarView } from "@jasonbenfield/sharedwebapp/Views/ToolbarView";
import { CopiaTheme } from "./CopiaTheme";
import { PortfolioMenuComponentView } from "./PortfolioMenuComponentView";

export class PortfolioMenuPanelView extends GridView {
    readonly portfolioMenuView: PortfolioMenuComponentView;
    private readonly toolbar: ToolbarView;
    readonly backButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.setViewName(PortfolioMenuPanelView.name);
        this.height100();
        this.layout();
        this.setTemplateRows(CssLengthUnit.flex(1), CssLengthUnit.auto());
        const mainContent = CopiaTheme.instance.mainContent(this.addCell());
        this.portfolioMenuView = mainContent.addView(PortfolioMenuComponentView);
        this.toolbar = CopiaTheme.instance.commandToolbar.toolbar(
            this.addCell().addView(ToolbarView)
        );
        this.backButton = CopiaTheme.instance.commandToolbar.backButton(
            this.toolbar.columnStart.addView(ButtonCommandView)
        );
    }

    hideToolbar() { this.toolbar.hide(); }
}