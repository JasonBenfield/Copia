// Generated code
import { NumericValue } from '@jasonbenfield/sharedwebapp/NumericValue';
import { NumericValues } from '@jasonbenfield/sharedwebapp/NumericValues';

export class TemplateStringFieldTypes extends NumericValues<TemplateStringFieldType> {
	constructor(
		public readonly NotSet: TemplateStringFieldType,
		public readonly Amount: TemplateStringFieldType,
		public readonly CounterpartyID: TemplateStringFieldType,
		public readonly CounterpartyName: TemplateStringFieldType,
		public readonly AccountID: TemplateStringFieldType,
		public readonly AccountName: TemplateStringFieldType
	) {
		super([NotSet,Amount,CounterpartyID,CounterpartyName,AccountID,AccountName]);
	}
}

export class TemplateStringFieldType extends NumericValue implements ITemplateStringFieldType {
	public static readonly values = new TemplateStringFieldTypes(
		new TemplateStringFieldType(0, 'Not Set'),
		new TemplateStringFieldType(5, 'Amount'),
		new TemplateStringFieldType(10, 'Counterparty ID'),
		new TemplateStringFieldType(15, 'Counterparty Name'),
		new TemplateStringFieldType(20, 'Account ID'),
		new TemplateStringFieldType(25, 'Account Name')
	);
	
	private constructor(Value: number, DisplayText: string) {
		super(Value, DisplayText);
	}
}