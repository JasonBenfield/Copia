// Generated code

import * as xti from "@jasonbenfield/sharedwebapp/Common";
import { AppClientGroup } from "@jasonbenfield/sharedwebapp/Http/AppClientGroup";
import { AppClientAction } from "@jasonbenfield/sharedwebapp/Http/AppClientAction";
import { AppClientView } from "@jasonbenfield/sharedwebapp/Http/AppClientView";
import { AppClientEvents } from "@jasonbenfield/sharedwebapp/Http/AppClientEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Http/AppResourceUrl";

export class PortfoliosGroup extends AppClientGroup {
	constructor(events: AppClientEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Portfolios');
		this.AddPortfolioAction = this.createAction<IAddPortfolioRequest,IPortfolioModel>('AddPortfolio', 'Add Portfolio');
		this.GetPortfoliosAction = this.createAction<IEmptyRequest,IPortfolioModel[]>('GetPortfolios', 'Get Portfolios');
		this.Index = this.createView<IEmptyRequest>('Index');
	}
	
	readonly AddPortfolioAction: AppClientAction<IAddPortfolioRequest,IPortfolioModel>;
	readonly GetPortfoliosAction: AppClientAction<IEmptyRequest,IPortfolioModel[]>;
	readonly Index: AppClientView<IEmptyRequest>;
	
	AddPortfolio(requestData: IAddPortfolioRequest, errorOptions?: IActionErrorOptions) {
		return this.AddPortfolioAction.execute(requestData, errorOptions || {});
	}
	GetPortfolios(errorOptions?: IActionErrorOptions) {
		return this.GetPortfoliosAction.execute({}, errorOptions || {});
	}
}