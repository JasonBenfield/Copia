// Generated code

import * as xti from "@jasonbenfield/sharedwebapp/Common";
import { AppClientGroup } from "@jasonbenfield/sharedwebapp/Http/AppClientGroup";
import { AppClientAction } from "@jasonbenfield/sharedwebapp/Http/AppClientAction";
import { AppClientView } from "@jasonbenfield/sharedwebapp/Http/AppClientView";
import { AppClientEvents } from "@jasonbenfield/sharedwebapp/Http/AppClientEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Http/AppResourceUrl";

export class ActivitiesGroup extends AppClientGroup {
	constructor(events: AppClientEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Activities');
		this.CreateActivityAction = this.createAction<ICreateActivityRequest,IActivityModel>('CreateActivity', 'Create Activity');
		this.Index = this.createView<IEmptyRequest>('Index');
	}
	
	readonly CreateActivityAction: AppClientAction<ICreateActivityRequest,IActivityModel>;
	readonly Index: AppClientView<IEmptyRequest>;
	
	CreateActivity(requestData: ICreateActivityRequest, errorOptions?: IActionErrorOptions) {
		return this.CreateActivityAction.execute(requestData, errorOptions || {});
	}
}