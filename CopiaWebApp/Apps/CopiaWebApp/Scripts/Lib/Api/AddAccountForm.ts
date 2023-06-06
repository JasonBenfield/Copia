// Generated code
import { BaseForm } from '@jasonbenfield/sharedwebapp/Forms/BaseForm';
import { AddAccountFormView } from './AddAccountFormView';
import { DropDownFieldItem } from "@jasonbenfield/sharedwebapp/Forms/DropDownFieldItem";

export class AddAccountForm extends BaseForm {
	protected readonly view: AddAccountFormView;
	
	constructor(view: AddAccountFormView) {
		super('AddAccountForm', view);
		this.AccountName.setCaption('Account Name');
		this.AccountName.constraints.mustNotBeNull();
		this.AccountName.constraints.mustNotBeWhitespace('Must not be blank');
		this.AccountName.setMaxLength(500);
		this.AccountType.setCaption('Account Type');
		this.AccountType.constraints.mustNotBeNull();
		this.AccountType.setItems(
			new DropDownFieldItem(5, 'Checking'),
			new DropDownFieldItem(10, 'Savings'),
			new DropDownFieldItem(15, 'Credit Card'),
			new DropDownFieldItem(20, 'Money Market')
		);
	}
	readonly AccountName = this.addTextInputFormGroup('AccountName', this.view.AccountName);
	readonly AccountType = this.addNumberDropDownFormGroup('AccountType', this.view.AccountType);
}