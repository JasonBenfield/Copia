// Generated code

import { AppApiGroup } from "@jasonbenfield/sharedwebapp/Api/AppApiGroup";
import { AppApiAction } from "@jasonbenfield/sharedwebapp/Api/AppApiAction";
import { AppApiView } from "@jasonbenfield/sharedwebapp/Api/AppApiView";
import { AppApiEvents } from "@jasonbenfield/sharedwebapp/Api/AppApiEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Api/AppResourceUrl";

export class ActivityTemplatesGroup extends AppApiGroup {
	constructor(events: AppApiEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'ActivityTemplates');
		this.AddActivityTemplateAction = this.createAction<IAddActivityTemplateRequest,IActivityTemplateDetailModel>('AddActivityTemplate', 'Add Activity Template');
		this.GetActivityTemplatesAction = this.createAction<IEmptyRequest,IActivityTemplateModel[]>('GetActivityTemplates', 'Get Activity Templates');
		this.Index = this.createView<IEmptyRequest>('Index');
	}
	
	readonly AddActivityTemplateAction: AppApiAction<IAddActivityTemplateRequest,IActivityTemplateDetailModel>;
	readonly GetActivityTemplatesAction: AppApiAction<IEmptyRequest,IActivityTemplateModel[]>;
	readonly Index: AppApiView<IEmptyRequest>;
	
	AddActivityTemplate(model: IAddActivityTemplateRequest, errorOptions?: IActionErrorOptions) {
		return this.AddActivityTemplateAction.execute(model, errorOptions || {});
	}
	GetActivityTemplates(errorOptions?: IActionErrorOptions) {
		return this.GetActivityTemplatesAction.execute({}, errorOptions || {});
	}
}