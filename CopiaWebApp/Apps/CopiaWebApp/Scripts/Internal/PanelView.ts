import { CssLengthUnit } from "@jasonbenfield/sharedwebapp/CssLengthUnit";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { BlockView } from "@jasonbenfield/sharedwebapp/Views/BlockView";
import { GridView } from "@jasonbenfield/sharedwebapp/Views/Grid";
import { ToolbarView } from "@jasonbenfield/sharedwebapp/Views/ToolbarView";
import { CopiaTheme } from "./CopiaTheme";

export class PanelView extends GridView {
    readonly body: BlockView;
    readonly toolbar: ToolbarView;

    constructor(container: BasicComponentView) {
        super(container);
        this.height100();
        this.layout();
        this.setTemplateRows(CssLengthUnit.flex(1), CssLengthUnit.auto());
        this.body = CopiaTheme.instance.mainContent(this.addCell());
        this.toolbar = CopiaTheme.instance.commandToolbar.toolbar(this.addCell().addView(ToolbarView));
    }
}