// Generated code

interface IGetAccountRequest {
	AccountID: number;
}
interface IAccountModel {
	ID: number;
	AccountName: string;
	AccountType: IAccountType;
}
interface ICreateActivityRequest {
	ActivityName: string;
}
interface IActivityModel {
	ID: number;
	ActivityName: string;
	ActivityDate: import('@jasonbenfield/sharedwebapp/Common').DateOnly;
}
interface ICounterpartyModel {
	ID: number;
	DisplayText: string;
	Url: string;
}
interface ICounterpartySearchResult {
	Counterparties: ICounterpartyModel[];
	Total: number;
}
interface IPortfolioModel {
	ID: number;
	PortfolioName: string;
	PublicKey: IModifierKey;
}
interface IModifierKey {
	Value: string;
	DisplayText: string;
}
interface IAddPortfolioRequest {
	PortfolioName: string;
}
interface ILinkModel {
	LinkName: string;
	DisplayText: string;
	Url: string;
	IsAuthenticationRequired: boolean;
}
interface IAccountType {
	Value: number;
	DisplayText: string;
}