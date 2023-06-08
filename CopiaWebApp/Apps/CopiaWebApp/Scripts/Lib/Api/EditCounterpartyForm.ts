// Generated code
import { BaseForm } from '@jasonbenfield/sharedwebapp/Forms/BaseForm';
import { EditCounterpartyFormView } from './EditCounterpartyFormView';

export class EditCounterpartyForm extends BaseForm {
	protected readonly view: EditCounterpartyFormView;
	
	constructor(view: EditCounterpartyFormView) {
		super('EditCounterpartyForm', view);
		this.CounterpartyID.setCaption('Counterparty ID');
		this.CounterpartyID.constraints.mustBeAbove(0, 'Must be greater than 0');
		this.DisplayText.setCaption('Display Text');
		this.DisplayText.constraints.mustNotBeNull();
		this.DisplayText.constraints.mustNotBeWhitespace('Must not be blank');
		this.DisplayText.setMaxLength(500);
		this.Url.setCaption('Url');
		this.Url.constraints.mustNotBeNull();
		this.Url.setMaxLength(500);
	}
	readonly CounterpartyID = this.addHiddenNumberFormGroup('CounterpartyID', this.view.CounterpartyID);
	readonly DisplayText = this.addTextInputFormGroup('DisplayText', this.view.DisplayText);
	readonly Url = this.addTextInputFormGroup('Url', this.view.Url);
}