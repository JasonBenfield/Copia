// Generated code

import * as xti from "@jasonbenfield/sharedwebapp/Common";
import { AppClientGroup } from "@jasonbenfield/sharedwebapp/Http/AppClientGroup";
import { AppClientAction } from "@jasonbenfield/sharedwebapp/Http/AppClientAction";
import { AppClientView } from "@jasonbenfield/sharedwebapp/Http/AppClientView";
import { AppClientEvents } from "@jasonbenfield/sharedwebapp/Http/AppClientEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Http/AppResourceUrl";

export class ActivityTemplatesGroup extends AppClientGroup {
	constructor(events: AppClientEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'ActivityTemplates');
		this.AddActivityTemplateAction = this.createAction<IAddActivityTemplateRequest,IActivityTemplateModel>('AddActivityTemplate', 'Add Activity Template');
		this.GetActivityTemplatesAction = this.createAction<IEmptyRequest,IActivityTemplateModel[]>('GetActivityTemplates', 'Get Activity Templates');
		this.Index = this.createView<IEmptyRequest>('Index');
	}
	
	readonly AddActivityTemplateAction: AppClientAction<IAddActivityTemplateRequest,IActivityTemplateModel>;
	readonly GetActivityTemplatesAction: AppClientAction<IEmptyRequest,IActivityTemplateModel[]>;
	readonly Index: AppClientView<IEmptyRequest>;
	
	AddActivityTemplate(requestData: IAddActivityTemplateRequest, errorOptions?: IActionErrorOptions) {
		return this.AddActivityTemplateAction.execute(requestData, errorOptions || {});
	}
	GetActivityTemplates(errorOptions?: IActionErrorOptions) {
		return this.GetActivityTemplatesAction.execute({}, errorOptions || {});
	}
}