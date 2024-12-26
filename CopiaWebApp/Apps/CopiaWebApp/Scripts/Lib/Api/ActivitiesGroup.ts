// Generated code

import { AppApiGroup } from "@jasonbenfield/sharedwebapp/Api/AppApiGroup";
import { AppApiAction } from "@jasonbenfield/sharedwebapp/Api/AppApiAction";
import { AppApiView } from "@jasonbenfield/sharedwebapp/Api/AppApiView";
import { AppApiEvents } from "@jasonbenfield/sharedwebapp/Api/AppApiEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Api/AppResourceUrl";

export class ActivitiesGroup extends AppApiGroup {
	constructor(events: AppApiEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Activities');
		this.CreateActivityAction = this.createAction<ICreateActivityRequest,IActivityDetailModel>('CreateActivity', 'Create Activity');
		this.Index = this.createView<IEmptyRequest>('Index');
	}
	
	readonly CreateActivityAction: AppApiAction<ICreateActivityRequest,IActivityDetailModel>;
	readonly Index: AppApiView<IEmptyRequest>;
	
	CreateActivity(model: ICreateActivityRequest, errorOptions?: IActionErrorOptions) {
		return this.CreateActivityAction.execute(model, errorOptions || {});
	}
}