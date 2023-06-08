import { ContextualClass } from "@jasonbenfield/sharedwebapp/ContextualClass";
import { CssLengthUnit } from "@jasonbenfield/sharedwebapp/CssLengthUnit";
import { MarginCss } from "@jasonbenfield/sharedwebapp/MarginCss";
import { AlertView } from "@jasonbenfield/sharedwebapp/Views/AlertView";
import { ButtonCommandView } from "@jasonbenfield/sharedwebapp/Views/Command";
import { FaIconView } from "@jasonbenfield/sharedwebapp/Views/FaIconView";
import { InputGroupView } from "@jasonbenfield/sharedwebapp/Views/InputGroupView";
import { InputView } from "@jasonbenfield/sharedwebapp/Views/InputView";
import { GridListGroupView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { MessageAlertView } from "@jasonbenfield/sharedwebapp/Views/MessageAlertView";
import { ModalConfirmView } from "@jasonbenfield/sharedwebapp/Views/Modal";
import { SpanView } from "@jasonbenfield/sharedwebapp/Views/SpanView";
import { TextBlockView } from "@jasonbenfield/sharedwebapp/Views/TextBlockView";
import { CopiaTheme } from "../CopiaTheme";
import { PanelView } from "../PanelView";
import { CounterpartyListItemView } from "./CounterpartyListItemView";

export class CounterpartyListPanelView extends PanelView {
    readonly searchInputView: InputView;
    readonly alertView: MessageAlertView;
    readonly counterpartyListView: GridListGroupView<CounterpartyListItemView>;
    private readonly moreAlert: AlertView;
    readonly modalConfirmView: ModalConfirmView;
    readonly menuButton: ButtonCommandView;
    readonly addButton: ButtonCommandView;

    constructor(container) {
        super(container);
        const inputGroup = this.body.addView(InputGroupView);
        inputGroup.setMargin(MarginCss.bottom(3));
        this.searchInputView = inputGroup.appendFormControl(InputView);
        const searchIcon = inputGroup.appendText(SpanView).addView(FaIconView);
        searchIcon.solidStyle('magnifying-glass');
        this.alertView = this.body.addView(MessageAlertView);
        this.counterpartyListView = this.body.addGridListGroup(CounterpartyListItemView);
        this.counterpartyListView.setTemplateColumns(CssLengthUnit.flex(1), CssLengthUnit.auto());
        this.counterpartyListView.setMargin(MarginCss.bottom(3));
        this.moreAlert = this.body.addView(AlertView);
        this.moreAlert.setContext(ContextualClass.info);
        const moreAlertText = this.moreAlert.addView(TextBlockView);
        moreAlertText.setText('More counterparties were found. Try to narrow your search.');
        this.modalConfirmView = this.body.addView(ModalConfirmView);
        this.menuButton = CopiaTheme.instance.commandToolbar.menuButton(
            this.toolbar.addButtonCommandToStart()
        );
        this.addButton = CopiaTheme.instance.commandToolbar.addButton(
            this.toolbar.addButtonCommandToEnd()
        );
        this.addButton.setContext(ContextualClass.primary);
    }

    showMoreAlert() { this.moreAlert.show(); }

    hideMoreAlert() { this.moreAlert.hide(); }

    handleEditButton(action: (el: HTMLElement, evt: JQuery.Event) => void) {
        this.counterpartyListView.on('click')
            .preventDefault()
            .execute(action)
            .select('.editCounterpartyButton')
            .subscribe();
    }

    handleDeleteButton(action: (el: HTMLElement, evt: JQuery.Event) => void) {
        this.counterpartyListView.on('click')
            .preventDefault()
            .execute(action)
            .select('.deleteCounterpartyButton')
            .subscribe();
    }
}