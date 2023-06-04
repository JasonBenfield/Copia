// Generated code
import { BaseForm } from '@jasonbenfield/sharedwebapp/Forms/BaseForm';
import { AddCounterpartyFormView } from './AddCounterpartyFormView';

export class AddCounterpartyForm extends BaseForm {
	protected readonly view: AddCounterpartyFormView;
	
	constructor(view: AddCounterpartyFormView) {
		super('AddCounterpartyForm', view);
		this.DisplayText.setCaption('Display Text');
		this.DisplayText.constraints.mustNotBeNull();
		this.DisplayText.constraints.mustNotBeWhitespace('Must not be blank');
		this.DisplayText.setMaxLength(500);
		this.Url.setCaption('Url');
		this.Url.constraints.mustNotBeNull();
		this.Url.setMaxLength(500);
	}
	readonly DisplayText = this.addTextInputFormGroup('DisplayText', this.view.DisplayText);
	readonly Url = this.addTextInputFormGroup('Url', this.view.Url);
}