import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { BasicTextComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicTextComponentView";
import { GridListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { TextBlockView } from "@jasonbenfield/sharedwebapp/Views/TextBlockView";

export class ActivityTemplateFieldListItemView extends GridListGroupItemView {
    readonly captionTextView: BasicTextComponentView;
    readonly accessibilityTextView: BasicTextComponentView;

    constructor(container: BasicComponentView) {
        super(container);
        const cell1 = this.addCell();
        this.captionTextView = cell1.addView(TextBlockView);
        const cell2 = this.addCell();
        this.accessibilityTextView = cell2.addView(TextBlockView);
    }
}