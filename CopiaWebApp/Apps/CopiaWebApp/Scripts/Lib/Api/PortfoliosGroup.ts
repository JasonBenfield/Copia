// Generated code

import { AppApiGroup } from "@jasonbenfield/sharedwebapp/Api/AppApiGroup";
import { AppApiAction } from "@jasonbenfield/sharedwebapp/Api/AppApiAction";
import { AppApiView } from "@jasonbenfield/sharedwebapp/Api/AppApiView";
import { AppApiEvents } from "@jasonbenfield/sharedwebapp/Api/AppApiEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Api/AppResourceUrl";

export class PortfoliosGroup extends AppApiGroup {
	constructor(events: AppApiEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Portfolios');
		this.AddPortfolioAction = this.createAction<IAddPortfolioRequest,IPortfolioModel>('AddPortfolio', 'Add Portfolio');
	}
	
	readonly AddPortfolioAction: AppApiAction<IAddPortfolioRequest,IPortfolioModel>;
	
	AddPortfolio(model: IAddPortfolioRequest, errorOptions?: IActionErrorOptions) {
		return this.AddPortfolioAction.execute(model, errorOptions || {});
	}
}