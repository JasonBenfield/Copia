// Generated code

import { AppApiGroup } from "@jasonbenfield/sharedwebapp/Api/AppApiGroup";
import { AppApiAction } from "@jasonbenfield/sharedwebapp/Api/AppApiAction";
import { AppApiView } from "@jasonbenfield/sharedwebapp/Api/AppApiView";
import { AppApiEvents } from "@jasonbenfield/sharedwebapp/Api/AppApiEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Api/AppResourceUrl";
import { AddCounterpartyForm } from "./AddCounterpartyForm";
import { EditCounterpartyForm } from "./EditCounterpartyForm";

export class CounterpartiesGroup extends AppApiGroup {
	constructor(events: AppApiEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Counterparties');
		this.Index = this.createView<IEmptyRequest>('Index');
		this.AddCounterpartyAction = this.createAction<AddCounterpartyForm,ICounterpartyModel>('AddCounterparty', 'Add Counterparty');
		this.CounterpartySearchAction = this.createAction<string,ICounterpartySearchResult>('CounterpartySearch', 'Counterparty Search');
		this.EditCounterpartyAction = this.createAction<EditCounterpartyForm,ICounterpartyModel>('EditCounterparty', 'Edit Counterparty');
	}
	
	readonly Index: AppApiView<IEmptyRequest>;
	readonly AddCounterpartyAction: AppApiAction<AddCounterpartyForm,ICounterpartyModel>;
	readonly CounterpartySearchAction: AppApiAction<string,ICounterpartySearchResult>;
	readonly EditCounterpartyAction: AppApiAction<EditCounterpartyForm,ICounterpartyModel>;
	
	AddCounterparty(model: AddCounterpartyForm, errorOptions?: IActionErrorOptions) {
		return this.AddCounterpartyAction.execute(model, errorOptions || {});
	}
	CounterpartySearch(model: string, errorOptions?: IActionErrorOptions) {
		return this.CounterpartySearchAction.execute(model, errorOptions || {});
	}
	EditCounterparty(model: EditCounterpartyForm, errorOptions?: IActionErrorOptions) {
		return this.EditCounterpartyAction.execute(model, errorOptions || {});
	}
}