// Generated code
import { NumericValue } from '@jasonbenfield/sharedwebapp/NumericValue';
import { NumericValues } from '@jasonbenfield/sharedwebapp/NumericValues';

export class TemplateStringPartTypes extends NumericValues<TemplateStringPartType> {
	constructor(
		public readonly FixedText: TemplateStringPartType,
		public readonly Negative: TemplateStringPartType,
		public readonly Field: TemplateStringPartType
	) {
		super([FixedText,Negative,Field]);
	}
}

export class TemplateStringPartType extends NumericValue implements ITemplateStringPartType {
	public static readonly values = new TemplateStringPartTypes(
		new TemplateStringPartType(0, 'Fixed Text'),
		new TemplateStringPartType(5, 'Negative'),
		new TemplateStringPartType(10, 'Field')
	);
	
	private constructor(Value: number, DisplayText: string) {
		super(Value, DisplayText);
	}
}