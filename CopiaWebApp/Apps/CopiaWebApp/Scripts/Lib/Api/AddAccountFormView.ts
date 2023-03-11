// Generated code
import { BaseFormView } from '@jasonbenfield/sharedwebapp/Views/BaseFormView';
import { SimpleFieldFormGroupInputView, SimpleFieldFormGroupSelectView } from '@jasonbenfield/sharedwebapp/Views/FormGroup';
import { IFormGroupLayout } from '@jasonbenfield/sharedwebapp/Views/Types';
import { BasicComponentView } from '@jasonbenfield/sharedwebapp/Views/BasicComponentView';

export interface IAddAccountFormView {
	AccountName: SimpleFieldFormGroupInputView;
	AccountType: SimpleFieldFormGroupSelectView;
}

export class DefaultAddAccountFormViewLayout implements IFormGroupLayout<IAddAccountFormView> {
	addFormGroups(form: AddAccountFormView) {
		return {
			AccountName: form.addInputFormGroup(),
			AccountType: form.addDropDownFormGroup()
		}
	}
}

export class AddAccountFormView extends BaseFormView {
	private formGroups: IAddAccountFormView;
	
	constructor(container: BasicComponentView) {
		super(container);
	}
	
	addContent(layout?: IFormGroupLayout<IAddAccountFormView>) {
		if (!layout) {
			layout = new DefaultAddAccountFormViewLayout();
		}
		this.formGroups = layout.addFormGroups(this);
	}
	
	get AccountName() { return this.formGroups.AccountName; }
	get AccountType() { return this.formGroups.AccountType; }
}