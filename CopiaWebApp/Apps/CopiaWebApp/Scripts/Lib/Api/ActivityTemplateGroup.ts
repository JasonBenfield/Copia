// Generated code

import { AppApiGroup } from "@jasonbenfield/sharedwebapp/Api/AppApiGroup";
import { AppApiAction } from "@jasonbenfield/sharedwebapp/Api/AppApiAction";
import { AppApiView } from "@jasonbenfield/sharedwebapp/Api/AppApiView";
import { AppApiEvents } from "@jasonbenfield/sharedwebapp/Api/AppApiEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Api/AppResourceUrl";

export class ActivityTemplateGroup extends AppApiGroup {
	constructor(events: AppApiEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'ActivityTemplate');
		this.EditTemplateStringAction = this.createAction<IEditTemplateStringRequest,ITemplateStringModel>('EditTemplateString', 'Edit Template String');
		this.GetActivityTemplateDetailAction = this.createAction<IGetActivityTemplateRequest,IActivityTemplateDetailModel>('GetActivityTemplateDetail', 'Get Activity Template Detail');
	}
	
	readonly EditTemplateStringAction: AppApiAction<IEditTemplateStringRequest,ITemplateStringModel>;
	readonly GetActivityTemplateDetailAction: AppApiAction<IGetActivityTemplateRequest,IActivityTemplateDetailModel>;
	
	EditTemplateString(model: IEditTemplateStringRequest, errorOptions?: IActionErrorOptions) {
		return this.EditTemplateStringAction.execute(model, errorOptions || {});
	}
	GetActivityTemplateDetail(model: IGetActivityTemplateRequest, errorOptions?: IActionErrorOptions) {
		return this.GetActivityTemplateDetailAction.execute(model, errorOptions || {});
	}
}