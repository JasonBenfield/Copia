import { MarginCss } from "@jasonbenfield/sharedwebapp/MarginCss";
import { BasicComponentView } from "@jasonbenfield/sharedwebapp/Views/BasicComponentView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { FormGroupGridView, SimpleFieldFormGroupInputView } from "@jasonbenfield/sharedwebapp/Views/FormGroup";
import { FormView } from "@jasonbenfield/sharedwebapp/Views/FormView";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { TextHeading1View } from "@jasonbenfield/sharedwebapp/Views/TextHeadings";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";

export class AddPortfolioPanelView extends PanelView {
    private readonly form: FormView;
    readonly portfolioName: SimpleFieldFormGroupInputView;
    readonly alert: MessageAlertView;
    readonly saveButton: ButtonCommandView;
    readonly cancelButton: ButtonCommandView;

    constructor(container: BasicComponentView) {
        super(container);
        this.body.addView(TextHeading1View)
            .configure(h => h.setText('Add Portfolio'));
        this.form = this.body.addView(FormView);
        const formGroupContainer = this.form.addView(FormGroupGridView);
        this.portfolioName = formGroupContainer.addFormGroup(SimpleFieldFormGroupInputView);
        this.portfolioName.caption.setText('Portfolio Name');
        this.form.addOffscreenSubmit();
        this.alert = this.body.addView(MessageAlertView);
        this.cancelButton = CopiaTheme.instance.commandToolbar.cancelButton(
            this.toolbar.columnEnd.addView(ButtonCommandView)
        );
        this.cancelButton.setMargin(MarginCss.end(1));
        this.saveButton = CopiaTheme.instance.commandToolbar.saveButton(
            this.toolbar.columnEnd.addView(ButtonCommandView)
        );
    }

    handleFormSubmit(action: (el: HTMLElement, evt: JQuery.Event) => void) {
        this.form.onSubmit()
            .execute(action)
            .subscribe();
    }
}