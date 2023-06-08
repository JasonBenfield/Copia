// Generated code
import { BaseFormView } from '@jasonbenfield/sharedwebapp/Views/BaseFormView';
import { SimpleFieldFormGroupInputView, SimpleFieldFormGroupSelectView } from '@jasonbenfield/sharedwebapp/Views/FormGroup';
import { IFormGroupLayout } from '@jasonbenfield/sharedwebapp/Views/Types';
import { BasicComponentView } from '@jasonbenfield/sharedwebapp/Views/BasicComponentView';

export interface IEditCounterpartyFormView {
	CounterpartyID: SimpleFieldFormGroupInputView;
	DisplayText: SimpleFieldFormGroupInputView;
	Url: SimpleFieldFormGroupInputView;
}

export class DefaultEditCounterpartyFormViewLayout implements IFormGroupLayout<IEditCounterpartyFormView> {
	addFormGroups(form: EditCounterpartyFormView) {
		return {
			CounterpartyID: form.addInputFormGroup(),
			DisplayText: form.addInputFormGroup(),
			Url: form.addInputFormGroup()
		}
	}
}

export class EditCounterpartyFormView extends BaseFormView {
	private formGroups: IEditCounterpartyFormView;
	
	constructor(container: BasicComponentView) {
		super(container);
	}
	
	addContent(layout?: IFormGroupLayout<IEditCounterpartyFormView>) {
		if (!layout) {
			layout = new DefaultEditCounterpartyFormViewLayout();
		}
		this.formGroups = layout.addFormGroups(this);
	}
	
	get CounterpartyID() { return this.formGroups.CounterpartyID; }
	get DisplayText() { return this.formGroups.DisplayText; }
	get Url() { return this.formGroups.Url; }
}