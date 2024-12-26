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
interface ICreateActivityRequest {
	ActivityTemplateID: number;
}
interface IActivityDetailModel {
	Activity: IActivityModel;
	Template: IActivityTemplateModel;
}
interface IActivityModel {
	ID: number;
	ActivityName: string;
	ActivityDate: IDateOnly;
}
interface IActivityTemplateModel {
	ID: number;
	TemplateName: string;
}
interface IGetActivityTemplateRequest {
	TemplateID: number;
}
interface IAddActivityTemplateRequest {
	TemplateName: string;
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
interface IAccountType {
	Value: number;
	DisplayText: string;
}