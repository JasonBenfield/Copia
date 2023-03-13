import { BasicComponent } from "@jasonbenfield/sharedwebapp/Components/BasicComponent";
import { TextComponent } from "@jasonbenfield/sharedwebapp/Components/TextComponent";
import { ActivityTemplateFieldListItemView } from "./ActivityTemplateFieldListItemView";

export class ActivityTemplateFieldListItem extends BasicComponent {
    constructor(activityField: IActivityTemplateFieldModel, view: ActivityTemplateFieldListItemView) {
        super(view);
        const captionText = new TextComponent(view.captionTextView);
        captionText.setText(activityField.FieldCaption);
        const accessibilityText = new TextComponent(view.accessibilityTextView);
        accessibilityText.setText(activityField.Accessibility.DisplayText);
    }
}