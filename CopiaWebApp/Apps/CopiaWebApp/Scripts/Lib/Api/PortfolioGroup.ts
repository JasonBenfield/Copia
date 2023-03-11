// Generated code

import { AppApiGroup } from "@jasonbenfield/sharedwebapp/Api/AppApiGroup";
import { AppApiAction } from "@jasonbenfield/sharedwebapp/Api/AppApiAction";
import { AppApiView } from "@jasonbenfield/sharedwebapp/Api/AppApiView";
import { AppApiEvents } from "@jasonbenfield/sharedwebapp/Api/AppApiEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Api/AppResourceUrl";
import { AddAccountForm } from "./AddAccountForm";

export class PortfolioGroup extends AppApiGroup {
	constructor(events: AppApiEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Portfolio');
		this.Index = this.createView<IEmptyRequest>('Index');
		this.AddAccountAction = this.createAction<AddAccountForm,IAccountModel>('AddAccount', 'Add Account');
		this.GetAccountsAction = this.createAction<IEmptyRequest,IAccountModel[]>('GetAccounts', 'Get Accounts');
		this.GetPortfolioAction = this.createAction<IEmptyRequest,IPortfolioModel>('GetPortfolio', 'Get Portfolio');
	}
	
	readonly Index: AppApiView<IEmptyRequest>;
	readonly AddAccountAction: AppApiAction<AddAccountForm,IAccountModel>;
	readonly GetAccountsAction: AppApiAction<IEmptyRequest,IAccountModel[]>;
	readonly GetPortfolioAction: AppApiAction<IEmptyRequest,IPortfolioModel>;
	
	AddAccount(model: AddAccountForm, errorOptions?: IActionErrorOptions) {
		return this.AddAccountAction.execute(model, errorOptions || {});
	}
	GetAccounts(errorOptions?: IActionErrorOptions) {
		return this.GetAccountsAction.execute({}, errorOptions || {});
	}
	GetPortfolio(errorOptions?: IActionErrorOptions) {
		return this.GetPortfolioAction.execute({}, errorOptions || {});
	}
}