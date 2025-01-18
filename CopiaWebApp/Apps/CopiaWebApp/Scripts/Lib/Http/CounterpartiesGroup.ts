// Generated code

import * as xti from "@jasonbenfield/sharedwebapp/Common";
import { AppClientGroup } from "@jasonbenfield/sharedwebapp/Http/AppClientGroup";
import { AppClientAction } from "@jasonbenfield/sharedwebapp/Http/AppClientAction";
import { AppClientView } from "@jasonbenfield/sharedwebapp/Http/AppClientView";
import { AppClientEvents } from "@jasonbenfield/sharedwebapp/Http/AppClientEvents";
import { AppResourceUrl } from "@jasonbenfield/sharedwebapp/Http/AppResourceUrl";
import { AddCounterpartyForm } from "./AddCounterpartyForm";
import { EditCounterpartyForm } from "./EditCounterpartyForm";

export class CounterpartiesGroup extends AppClientGroup {
	constructor(events: AppClientEvents, resourceUrl: AppResourceUrl) {
		super(events, resourceUrl, 'Counterparties');
		this.AddCounterpartyAction = this.createAction<AddCounterpartyForm,ICounterpartyModel>('AddCounterparty', 'Add Counterparty');
		this.CounterpartySearchAction = this.createAction<string,ICounterpartySearchResult>('CounterpartySearch', 'Counterparty Search');
		this.DeleteCounterpartyAction = this.createAction<number,IEmptyActionResult>('DeleteCounterparty', 'Delete Counterparty');
		this.EditCounterpartyAction = this.createAction<EditCounterpartyForm,ICounterpartyModel>('EditCounterparty', 'Edit Counterparty');
		this.Index = this.createView<IEmptyRequest>('Index');
	}
	
	readonly AddCounterpartyAction: AppClientAction<AddCounterpartyForm,ICounterpartyModel>;
	readonly CounterpartySearchAction: AppClientAction<string,ICounterpartySearchResult>;
	readonly DeleteCounterpartyAction: AppClientAction<number,IEmptyActionResult>;
	readonly EditCounterpartyAction: AppClientAction<EditCounterpartyForm,ICounterpartyModel>;
	readonly Index: AppClientView<IEmptyRequest>;
	
	AddCounterparty(requestData: AddCounterpartyForm, errorOptions?: IActionErrorOptions) {
		return this.AddCounterpartyAction.execute(requestData, errorOptions || {});
	}
	CounterpartySearch(requestData: string, errorOptions?: IActionErrorOptions) {
		return this.CounterpartySearchAction.execute(requestData, errorOptions || {});
	}
	DeleteCounterparty(requestData: number, errorOptions?: IActionErrorOptions) {
		return this.DeleteCounterpartyAction.execute(requestData, errorOptions || {});
	}
	EditCounterparty(requestData: EditCounterpartyForm, errorOptions?: IActionErrorOptions) {
		return this.EditCounterpartyAction.execute(requestData, errorOptions || {});
	}
}