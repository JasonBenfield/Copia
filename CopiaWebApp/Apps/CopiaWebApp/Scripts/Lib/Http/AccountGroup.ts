// Generated code

import * as xti from "@jasonbenfield/sharedwebapp/Common";
import { AppClientGroup } from "@jasonbenfield/sharedwebapp/Http/AppClientGroup";
import { AppClientAction } from "@jasonbenfield/sharedwebapp/Http/AppClientAction";
import { AppClientView } from "@jasonbenfield/sharedwebapp/Http/AppClientView";
import { AppClientEvents } from "@jasonbenfield/sharedwebapp/Http/AppClientEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Http/AppResourceUrl";

export class AccountGroup extends AppClientGroup {
	constructor(events: AppClientEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Account');
		this.GetAccountAction = this.createAction<IGetAccountRequest,IAccountModel>('GetAccount', 'Get Account');
		this.Index = this.createView<IGetAccountRequest>('Index');
	}
	
	readonly GetAccountAction: AppClientAction<IGetAccountRequest,IAccountModel>;
	readonly Index: AppClientView<IGetAccountRequest>;
	
	GetAccount(requestData: IGetAccountRequest, errorOptions?: IActionErrorOptions) {
		return this.GetAccountAction.execute(requestData, errorOptions || {});
	}
}