import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { GridCellView } from "@jasonbenfield/sharedwebapp/Views/Grid";
import { GridListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { TextBlockView } from "@jasonbenfield/sharedwebapp/Views/TextBlockView";
import { TextLinkView } from "@jasonbenfield/sharedwebapp/Views/TextLinkView";

export class CounterpartyListItemView extends GridListGroupItemView {
    private readonly cell1: GridCellView;

    constructor(container: BasicComponentView) {
        super(container);
        this.cell1 = this.addCell();
    }

    addTextView() {
        return this.cell1.addView(TextBlockView);
    }

    addLinkView() {
        return this.cell1.addView(TextLinkView);
    }
}