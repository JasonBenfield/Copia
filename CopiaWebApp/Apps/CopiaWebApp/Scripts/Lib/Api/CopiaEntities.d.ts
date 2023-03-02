// Generated code

interface ILinkModel {
	LinkName: string;
	DisplayText: string;
	Url: string;
}
interface IAddPortfolioRequest {
	PortfolioName: string;
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