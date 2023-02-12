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
		this.GetPortfoliosAction = this.createAction<IEmptyRequest,IPortfolioModel[]>('GetPortfolios', 'Get Portfolios');
	}
	
	readonly AddPortfolioAction: AppApiAction<IAddPortfolioRequest,IPortfolioModel>;
	readonly GetPortfoliosAction: AppApiAction<IEmptyRequest,IPortfolioModel[]>;
	
	AddPortfolio(model: IAddPortfolioRequest, errorOptions?: IActionErrorOptions) {
		return this.AddPortfolioAction.execute(model, errorOptions || {});
	}
	GetPortfolios(errorOptions?: IActionErrorOptions) {
		return this.GetPortfoliosAction.execute({}, errorOptions || {});
	}
}