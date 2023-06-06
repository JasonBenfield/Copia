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
interface IEditTemplateStringRequest {
	ID: number;
	CanEdit: boolean;
	Parts: IAddTemplateStringPartRequest[];
}
interface IAddTemplateStringPartRequest {
	PartType: number;
	ArrayType: number;
	ArrayIndex: number;
	FieldType: number;
	FixedText: string;
}
interface ITemplateStringModel {
	ID: number;
	CanEdit: boolean;
	DataType: ITemplateStringDataType;
	Parts: ITemplateStringPartModel[];
}
interface ITemplateStringPartModel {
	ID: number;
	PartType: ITemplateStringPartType;
	ArrayType: ITemplateStringArrayType;
	ArrayIndex: number;
	FieldType: ITemplateStringFieldType;
	FixedText: string;
}
interface IGetActivityTemplateRequest {
	TemplateID: number;
}
interface IActivityTemplateDetailModel {
	Template: IActivityTemplateModel;
	ActivityName: ITemplateStringModel;
	TemplateFields: IActivityTemplateFieldModel[];
}
interface IActivityTemplateModel {
	ID: number;
	TemplateName: string;
}
interface IActivityTemplateFieldModel {
	ID: number;
	FieldType: IActivityFieldType;
	FieldCaption: string;
	Accessibility: IActivityFieldAccessibility;
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
interface ITemplateStringDataType {
	Value: number;
	DisplayText: string;
}
interface ITemplateStringPartType {
	Value: number;
	DisplayText: string;
}
interface ITemplateStringArrayType {
	Value: number;
	DisplayText: string;
}
interface ITemplateStringFieldType {
	Value: number;
	DisplayText: string;
}
interface IActivityFieldType {
	Value: number;
	DisplayText: string;
}
interface IActivityFieldAccessibility {
	Value: number;
	DisplayText: string;
}