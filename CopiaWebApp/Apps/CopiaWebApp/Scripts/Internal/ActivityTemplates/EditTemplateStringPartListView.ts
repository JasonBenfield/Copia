import { CssLengthUnit } from "@jasonbenfield/sharedwebapp/CssLengthUnit";
import { MarginCss } from "@jasonbenfield/sharedwebapp/MarginCss";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { GridView } from "@jasonbenfield/sharedwebapp/Views/Grid";
import { EditTemplateStringPartView } from "./EditTemplateStringPartView";

export class EditTemplateStringPartListView extends GridView {

    constructor(container: BasicComponentView) {
        super(container);
        this.layout();
        this.setTemplateColumns(
            CssLengthUnit.maxContent(),
            CssLengthUnit.flex(1)
        );
    }

    handleTemplateStringChanged(action: () => void) {
        this.on('input change')
            .execute(action)
            .subscribe();
    }

    addPartView() {
        const partView = this.addRow(EditTemplateStringPartView);
        partView.setMargin(MarginCss.bottom(3));
        return partView;
    }
}