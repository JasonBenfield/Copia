// Generated code
import { BaseFormView } from '@jasonbenfield/sharedwebapp/Views/BaseFormView';
import * as views from '@jasonbenfield/sharedwebapp/Views/FormGroup';
import { IFormGroupLayout } from '@jasonbenfield/sharedwebapp/Views/Types';
import { BasicComponentView } from '@jasonbenfield/sharedwebapp/Views/BasicComponentView';
import { InputView } from '@jasonbenfield/sharedwebapp/Views/InputView';

export interface IAddCounterpartyFormView {
	DisplayText: views.SimpleFieldFormGroupInputView;
	Url: views.SimpleFieldFormGroupInputView;
}

export class DefaultAddCounterpartyFormViewLayout implements IFormGroupLayout<IAddCounterpartyFormView> {
	addFormGroups(form: AddCounterpartyFormView) {
		return {
			DisplayText: form.addInputFormGroup(),
			Url: form.addInputFormGroup()
		}
	}
}

export class AddCounterpartyFormView extends BaseFormView {
	private formGroups: IAddCounterpartyFormView;
	
	constructor(container: BasicComponentView) {
		super(container);
	}
	
	addContent(layout?: IFormGroupLayout<IAddCounterpartyFormView>) {
		if (!layout) {
			layout = new DefaultAddCounterpartyFormViewLayout();
		}
		this.formGroups = layout.addFormGroups(this);
	}
	
	get DisplayText() { return this.formGroups.DisplayText; }
	get Url() { return this.formGroups.Url; }
}