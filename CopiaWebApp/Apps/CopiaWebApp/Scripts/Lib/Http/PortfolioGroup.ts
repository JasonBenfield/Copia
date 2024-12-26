// Generated code

import * as xti from "@jasonbenfield/sharedwebapp/Common";
import { AppClientGroup } from "@jasonbenfield/sharedwebapp/Http/AppClientGroup";
import { AppClientAction } from "@jasonbenfield/sharedwebapp/Http/AppClientAction";
import { AppClientView } from "@jasonbenfield/sharedwebapp/Http/AppClientView";
import { AppClientEvents } from "@jasonbenfield/sharedwebapp/Http/AppClientEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Http/AppResourceUrl";
import { AddAccountForm } from "./AddAccountForm";

export class PortfolioGroup extends AppClientGroup {
	constructor(events: AppClientEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Portfolio');
		this.Index = this.createView<IEmptyRequest>('Index');
		this.AddAccountAction = this.createAction<AddAccountForm,IAccountModel>('AddAccount', 'Add Account');
		this.GetAccountsAction = this.createAction<IEmptyRequest,IAccountModel[]>('GetAccounts', 'Get Accounts');
		this.GetPortfolioAction = this.createAction<IEmptyRequest,IPortfolioModel>('GetPortfolio', 'Get Portfolio');
	}
	
	readonly Index: AppClientView<IEmptyRequest>;
	readonly AddAccountAction: AppClientAction<AddAccountForm,IAccountModel>;
	readonly GetAccountsAction: AppClientAction<IEmptyRequest,IAccountModel[]>;
	readonly GetPortfolioAction: AppClientAction<IEmptyRequest,IPortfolioModel>;
	
	AddAccount(requestData: AddAccountForm, errorOptions?: IActionErrorOptions) {
		return this.AddAccountAction.execute(requestData, errorOptions || {});
	}
	GetAccounts(errorOptions?: IActionErrorOptions) {
		return this.GetAccountsAction.execute({}, errorOptions || {});
	}
	GetPortfolio(errorOptions?: IActionErrorOptions) {
		return this.GetPortfolioAction.execute({}, errorOptions || {});
	}
}