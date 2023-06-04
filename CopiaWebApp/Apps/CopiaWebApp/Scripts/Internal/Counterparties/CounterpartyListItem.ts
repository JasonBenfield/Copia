import { BasicComponent } from "@jasonbenfield/sharedwebapp/Components/BasicComponent";
import { TextComponent } from "@jasonbenfield/sharedwebapp/Components/TextComponent";
import { TextLinkComponent } from "@jasonbenfield/sharedwebapp/Components/TextLinkComponent";
import { CounterpartyListItemView } from "./CounterpartyListItemView";

export class CounterpartyListItem extends BasicComponent {
    constructor(readonly counterparty: ICounterpartyModel, view: CounterpartyListItemView) {
        super(view);
        if (counterparty.Url) {
            const linkComponent = new TextLinkComponent(view.addLinkView());
            linkComponent.setText(counterparty.DisplayText);
            linkComponent.setHref(counterparty.Url);
            linkComponent.setTargetToBlank();
        }
        else {
            const textComponent = new TextComponent(view.addTextView());
            textComponent.setText(counterparty.DisplayText);
        }
    }
}