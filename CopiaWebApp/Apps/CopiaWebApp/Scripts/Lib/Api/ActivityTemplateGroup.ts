// Generated code

import { AppApiGroup } from "@jasonbenfield/sharedwebapp/Api/AppApiGroup";
import { AppApiAction } from "@jasonbenfield/sharedwebapp/Api/AppApiAction";
import { AppApiView } from "@jasonbenfield/sharedwebapp/Api/AppApiView";
import { AppApiEvents } from "@jasonbenfield/sharedwebapp/Api/AppApiEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Api/AppResourceUrl";

export class ActivityTemplateGroup extends AppApiGroup {
	constructor(events: AppApiEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'ActivityTemplate');
		this.GetActivityTemplateAction = this.createAction<IGetActivityTemplateRequest,IActivityTemplateModel>('GetActivityTemplate', 'Get Activity Template');
	}
	
	readonly GetActivityTemplateAction: AppApiAction<IGetActivityTemplateRequest,IActivityTemplateModel>;
	
	GetActivityTemplate(model: IGetActivityTemplateRequest, errorOptions?: IActionErrorOptions) {
		return this.GetActivityTemplateAction.execute(model, errorOptions || {});
	}
}