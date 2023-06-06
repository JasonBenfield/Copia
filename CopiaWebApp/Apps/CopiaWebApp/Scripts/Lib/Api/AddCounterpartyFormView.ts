// Generated code
import { BaseFormView } from '@jasonbenfield/sharedwebapp/Views/BaseFormView';
import { SimpleFieldFormGroupInputView, SimpleFieldFormGroupSelectView } from '@jasonbenfield/sharedwebapp/Views/FormGroup';
import { IFormGroupLayout } from '@jasonbenfield/sharedwebapp/Views/Types';
import { BasicComponentView } from '@jasonbenfield/sharedwebapp/Views/BasicComponentView';

export interface IAddCounterpartyFormView {
	DisplayText: SimpleFieldFormGroupInputView;
	Url: SimpleFieldFormGroupInputView;
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