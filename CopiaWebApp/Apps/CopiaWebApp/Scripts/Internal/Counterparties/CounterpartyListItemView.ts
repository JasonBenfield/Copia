import { ContextualClass } from "@jasonbenfield/sharedwebapp/ContextualClass";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonGroupView } from "@jasonbenfield/sharedwebapp/Views/ButtonGroupView";
import { GridCellView } from "@jasonbenfield/sharedwebapp/Views/Grid";
import { GridListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { TextBlockView } from "@jasonbenfield/sharedwebapp/Views/TextBlockView";
import { TextLinkView } from "@jasonbenfield/sharedwebapp/Views/TextLinkView";

export class CounterpartyListItemView extends GridListGroupItemView {
    private readonly cell1: GridCellView;

    constructor(container: BasicComponentView) {
        super(container);
        this.cell1 = this.addCell();
        const buttonGroup = this.addCell().addView(ButtonGroupView)
        const editButton = buttonGroup.addButtonCommand();
        editButton.icon.solidStyle('edit');
        editButton.setContext(ContextualClass.primary);
        editButton.addCssName('editCounterpartyButton');
        const deleteButton = buttonGroup.addButtonCommand();
        deleteButton.icon.solidStyle('times');
        deleteButton.setContext(ContextualClass.danger);
        deleteButton.addCssName('deleteCounterpartyButton');
    }

    addTextView() {
        return this.cell1.addView(TextBlockView);
    }

    addLinkView() {
        return this.cell1.addView(TextLinkView);
    }
}