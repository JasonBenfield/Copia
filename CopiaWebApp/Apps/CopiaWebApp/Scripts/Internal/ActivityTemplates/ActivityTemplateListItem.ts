import { BasicComponent } from "@jasonbenfield/sharedwebapp/Components/BasicComponent";
import { TextComponent } from "@jasonbenfield/sharedwebapp/Components/TextComponent";
import { TextButtonListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";

export class ActivityTemplateListItem extends BasicComponent {
    constructor(readonly activityTemplate: IActivityTemplateModel, view: TextButtonListGroupItemView) {
        super(view);
        const textComponent = new TextComponent(view);
        textComponent.setText(activityTemplate.TemplateName);
        textComponent.syncTitleWithText();
    }
}