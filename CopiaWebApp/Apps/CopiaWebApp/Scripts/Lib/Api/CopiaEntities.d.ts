// Generated code

interface ILinkModel {
	LinkName: string;
	DisplayText: string;
	Url: string;
}
interface IGetAccountRequest {
	AccountID: number;
}
interface IAccountModel {
	ID: number;
	AccountName: string;
	AccountType: IAccountType;
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
interface IAccountType {
	Value: number;
	DisplayText: string;
}