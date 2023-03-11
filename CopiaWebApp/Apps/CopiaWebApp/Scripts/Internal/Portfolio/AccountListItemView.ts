import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { BasicTextComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicTextComponentView";
import { GridListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { TextBlockView } from "@jasonbenfield/sharedwebapp/Views/TextBlockView";

export class AccountListItemView extends GridListGroupItemView {
    readonly nameTextView: BasicTextComponentView;
    readonly typeTextView: BasicTextComponentView;

    constructor(container: BasicComponentView) {
        super(container);
        const cell1 = this.addCell();
        this.nameTextView = cell1.addView(TextBlockView);
        const cell2 = this.addCell();
        this.typeTextView = cell2.addView(TextBlockView);
    }

    styleAsClickable() {
        this.addCssName('clickable');
    }
}