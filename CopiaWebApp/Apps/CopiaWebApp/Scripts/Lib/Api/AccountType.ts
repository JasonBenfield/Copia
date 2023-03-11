// Generated code
import { NumericValue } from '@jasonbenfield/sharedwebapp/NumericValue';
import { NumericValues } from '@jasonbenfield/sharedwebapp/NumericValues';

export class AccountTypes extends NumericValues<AccountType> {
	constructor(
		public readonly NotSet: AccountType,
		public readonly Checking: AccountType,
		public readonly Savings: AccountType,
		public readonly CreditCard: AccountType,
		public readonly MoneyMarket: AccountType
	) {
		super([NotSet,Checking,Savings,CreditCard,MoneyMarket]);
	}
}

export class AccountType extends NumericValue implements IAccountType {
	public static readonly values = new AccountTypes(
		new AccountType(0, 'Not Set'),
		new AccountType(5, 'Checking'),
		new AccountType(10, 'Savings'),
		new AccountType(15, 'Credit Card'),
		new AccountType(20, 'Money Market')
	);
	
	private constructor(Value: number, DisplayText: string) {
		super(Value, DisplayText);
	}
}