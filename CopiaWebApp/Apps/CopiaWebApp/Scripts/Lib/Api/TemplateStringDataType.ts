// Generated code
import { NumericValue } from '@jasonbenfield/sharedwebapp/NumericValue';
import { NumericValues } from '@jasonbenfield/sharedwebapp/NumericValues';

export class TemplateStringDataTypes extends NumericValues<TemplateStringDataType> {
	constructor(
		public readonly NotSet: TemplateStringDataType,
		public readonly String: TemplateStringDataType,
		public readonly Decimal: TemplateStringDataType,
		public readonly DateTimeOffset: TemplateStringDataType
	) {
		super([NotSet,String,Decimal,DateTimeOffset]);
	}
}

export class TemplateStringDataType extends NumericValue implements ITemplateStringDataType {
	public static readonly values = new TemplateStringDataTypes(
		new TemplateStringDataType(0, 'Not Set'),
		new TemplateStringDataType(5, 'String'),
		new TemplateStringDataType(10, 'Decimal'),
		new TemplateStringDataType(15, 'Date Time Offset')
	);
	
	private constructor(Value: number, DisplayText: string) {
		super(Value, DisplayText);
	}
}