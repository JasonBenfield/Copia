// Generated code
import { NumericValue } from '@jasonbenfield/sharedwebapp/NumericValue';
import { NumericValues } from '@jasonbenfield/sharedwebapp/NumericValues';

export class ActivityFieldAccessibilitys extends NumericValues<ActivityFieldAccessibility> {
	constructor(
		public readonly Editable: ActivityFieldAccessibility,
		public readonly ReadOnly: ActivityFieldAccessibility,
		public readonly Hidden: ActivityFieldAccessibility
	) {
		super([Editable,ReadOnly,Hidden]);
	}
}

export class ActivityFieldAccessibility extends NumericValue implements IActivityFieldAccessibility {
	public static readonly values = new ActivityFieldAccessibilitys(
		new ActivityFieldAccessibility(0, 'Editable'),
		new ActivityFieldAccessibility(5, 'Read Only'),
		new ActivityFieldAccessibility(10, 'Hidden')
	);
	
	private constructor(Value: number, DisplayText: string) {
		super(Value, DisplayText);
	}
}