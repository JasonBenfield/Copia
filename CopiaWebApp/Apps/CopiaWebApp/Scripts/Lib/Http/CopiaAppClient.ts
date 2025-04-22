// Generated code

import { AppClient } from "@jasonbenfield/sharedwebapp/Http/AppClient";
import { AppClientEvents } from "@jasonbenfield/sharedwebapp/Http/AppClientEvents";
import { AppClientQuery } from "@jasonbenfield/sharedwebapp/Http/AppClientQuery";
import { AccountGroup } from "./AccountGroup";
import { ActivitiesGroup } from "./ActivitiesGroup";
import { CounterpartiesGroup } from "./CounterpartiesGroup";
import { HomeGroup } from "./HomeGroup";
import { PortfolioGroup } from "./PortfolioGroup";
import { PortfoliosGroup } from "./PortfoliosGroup";


export class CopiaAppClient extends AppClient {
	constructor(events: AppClientEvents) {
		super(
			events, 
			'Copia', 
			pageContext.EnvironmentName === 'Production' || pageContext.EnvironmentName === 'Staging' ? 'V2' : 'Current'
		);
		this.Account = this.addGroup((evts, resourceUrl) => new AccountGroup(evts, resourceUrl));
		this.Activities = this.addGroup((evts, resourceUrl) => new ActivitiesGroup(evts, resourceUrl));
		this.Counterparties = this.addGroup((evts, resourceUrl) => new CounterpartiesGroup(evts, resourceUrl));
		this.Home = this.addGroup((evts, resourceUrl) => new HomeGroup(evts, resourceUrl));
		this.Portfolio = this.addGroup((evts, resourceUrl) => new PortfolioGroup(evts, resourceUrl));
		this.Portfolios = this.addGroup((evts, resourceUrl) => new PortfoliosGroup(evts, resourceUrl));
	}
	
	readonly Account: AccountGroup;
	readonly Activities: ActivitiesGroup;
	readonly Counterparties: CounterpartiesGroup;
	readonly Home: HomeGroup;
	readonly Portfolio: PortfolioGroup;
	readonly Portfolios: PortfoliosGroup;
}