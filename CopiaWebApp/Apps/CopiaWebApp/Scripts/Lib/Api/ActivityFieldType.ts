// Generated code
import { NumericValue } from '@jasonbenfield/sharedwebapp/NumericValue';
import { NumericValues } from '@jasonbenfield/sharedwebapp/NumericValues';

export class ActivityFieldTypes extends NumericValues<ActivityFieldType> {
	constructor(
		public readonly NotSet: ActivityFieldType,
		public readonly Counterparty: ActivityFieldType,
		public readonly TimeOccurred: ActivityFieldType,
		public readonly Amount: ActivityFieldType
	) {
		super([NotSet,Counterparty,TimeOccurred,Amount]);
	}
}

export class ActivityFieldType extends NumericValue implements IActivityFieldType {
	public static readonly values = new ActivityFieldTypes(
		new ActivityFieldType(0, 'Not Set'),
		new ActivityFieldType(5, 'Counterparty'),
		new ActivityFieldType(10, 'Time Occurred'),
		new ActivityFieldType(15, 'Amount')
	);
	
	private constructor(Value: number, DisplayText: string) {
		super(Value, DisplayText);
	}
}