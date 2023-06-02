import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { GridRowView } from "@jasonbenfield/sharedwebapp/Views/Grid";
import { InputGroupView } from "@jasonbenfield/sharedwebapp/Views/InputGroupView";
import { InputView } from "@jasonbenfield/sharedwebapp/Views/InputView";
import { SelectView } from "@jasonbenfield/sharedwebapp/Views/SelectView";
import { TextSpanView } from "@jasonbenfield/sharedwebapp/Views/TextSpanView";

export class EditTemplateStringPartView extends GridRowView {
    readonly partTypeSelectView: SelectView;
    private readonly arrayInputGroup: InputGroupView;
    readonly arrayIndexInputView: InputView;
    readonly fieldTypeSelectView: SelectView;
    readonly fixedTextInputView: InputView;

    constructor(container: BasicComponentView) {
        super(container);
        const cell1 = this.addCell();
        this.partTypeSelectView = cell1.addView(SelectView);
        this.partTypeSelectView.styleAsFormControl();
        const cell2 = this.addCell();
        this.arrayInputGroup = cell2.addView(InputGroupView);
        const arrayLabel = this.arrayInputGroup.appendText(TextSpanView);
        arrayLabel.setText('Index');
        this.arrayIndexInputView = this.arrayInputGroup.appendFormControl(InputView);
        this.fieldTypeSelectView = this.arrayInputGroup.appendFormControl(SelectView);
        this.fixedTextInputView = cell2.addView(InputView);
        this.fixedTextInputView.styleAsFormControl();
    }

    showArrayControls() {
        this.arrayInputGroup.show();
    }

    hideArrayControls() {
        this.arrayInputGroup.hide();
    }
}