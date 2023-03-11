import { BasicComponent } from "@jasonbenfield/sharedwebapp/Components/BasicComponent";
import { TextComponent } from "@jasonbenfield/sharedwebapp/Components/TextComponent";
import { AccountListItemView } from "./AccountListItemView";

export class AccountListItem extends BasicComponent {
    constructor(readonly account: IAccountModel, view: AccountListItemView) {
        super(view);
        const nameText = new TextComponent(view.nameTextView);
        nameText.setText(account.AccountName);
        const typeText = new TextComponent(view.typeTextView);
        typeText.setText(account.AccountType.DisplayText);
        view.styleAsClickable();
    }
}