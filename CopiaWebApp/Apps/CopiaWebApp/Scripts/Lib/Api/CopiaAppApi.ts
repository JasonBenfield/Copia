// Generated code

import { AppApi } from "@jasonbenfield/sharedwebapp/Api/AppApi";
import { AppApiEvents } from "@jasonbenfield/sharedwebapp/Api/AppApiEvents";
import { AppApiQuery } from "@jasonbenfield/sharedwebapp/Api/AppApiQuery";
import { HomeGroup } from "./HomeGroup";
import { PortfolioGroup } from "./PortfolioGroup";
import { PortfoliosGroup } from "./PortfoliosGroup";


export class CopiaAppApi extends AppApi {
	constructor(events: AppApiEvents) {
		super(events, 'Copia');
		this.Home = this.addGroup((evts, resourceUrl) => new HomeGroup(evts, resourceUrl));
		this.Portfolio = this.addGroup((evts, resourceUrl) => new PortfolioGroup(evts, resourceUrl));
		this.Portfolios = this.addGroup((evts, resourceUrl) => new PortfoliosGroup(evts, resourceUrl));
	}
	
	readonly Home: HomeGroup;
	readonly Portfolio: PortfolioGroup;
	readonly Portfolios: PortfoliosGroup;
}