// Generated code
import { NumericValue } from '@jasonbenfield/sharedwebapp/NumericValue';
import { NumericValues } from '@jasonbenfield/sharedwebapp/NumericValues';

export class TemplateStringArrayTypes extends NumericValues<TemplateStringArrayType> {
	constructor(
		public readonly NotSet: TemplateStringArrayType,
		public readonly Transactions: TemplateStringArrayType
	) {
		super([NotSet,Transactions]);
	}
}

export class TemplateStringArrayType extends NumericValue implements ITemplateStringArrayType {
	public static readonly values = new TemplateStringArrayTypes(
		new TemplateStringArrayType(0, 'Not Set'),
		new TemplateStringArrayType(5, 'Transactions')
	);
	
	private constructor(Value: number, DisplayText: string) {
		super(Value, DisplayText);
	}
}