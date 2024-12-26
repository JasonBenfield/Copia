// Generated code

import * as xti from "@jasonbenfield/sharedwebapp/Common";
import { AppClientGroup } from "@jasonbenfield/sharedwebapp/Http/AppClientGroup";
import { AppClientAction } from "@jasonbenfield/sharedwebapp/Http/AppClientAction";
import { AppClientView } from "@jasonbenfield/sharedwebapp/Http/AppClientView";
import { AppClientEvents } from "@jasonbenfield/sharedwebapp/Http/AppClientEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Http/AppResourceUrl";

export class ActivityTemplateGroup extends AppClientGroup {
	constructor(events: AppClientEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'ActivityTemplate');
		this.GetActivityTemplateAction = this.createAction<IGetActivityTemplateRequest,IActivityTemplateModel>('GetActivityTemplate', 'Get Activity Template');
	}
	
	readonly GetActivityTemplateAction: AppClientAction<IGetActivityTemplateRequest,IActivityTemplateModel>;
	
	GetActivityTemplate(requestData: IGetActivityTemplateRequest, errorOptions?: IActionErrorOptions) {
		return this.GetActivityTemplateAction.execute(requestData, errorOptions || {});
	}
}