// Generated code

import { AppApiGroup } from "@jasonbenfield/sharedwebapp/Api/AppApiGroup";
import { AppApiAction } from "@jasonbenfield/sharedwebapp/Api/AppApiAction";
import { AppApiView } from "@jasonbenfield/sharedwebapp/Api/AppApiView";
import { AppApiEvents } from "@jasonbenfield/sharedwebapp/Api/AppApiEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Api/AppResourceUrl";

export class AccountGroup extends AppApiGroup {
	constructor(events: AppApiEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Account');
		this.GetAccountAction = this.createAction<IGetAccountRequest,IAccountModel>('GetAccount', 'Get Account');
		this.Index = this.createView<IGetAccountRequest>('Index');
	}
	
	readonly GetAccountAction: AppApiAction<IGetAccountRequest,IAccountModel>;
	readonly Index: AppApiView<IGetAccountRequest>;
	
	GetAccount(model: IGetAccountRequest, errorOptions?: IActionErrorOptions) {
		return this.GetAccountAction.execute(model, errorOptions || {});
	}
}