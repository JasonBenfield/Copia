import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { CounterpartyListPanelView } from "./CounterpartyListPanelView";

interface IResults {
    menu?: boolean;
}

class Result {
    static menu() { return new Result({ menu: true }); }

    private constructor(private readonly results: IResults) { }

    get menu() { return this.results.menu; }
}

export class CounterpartyListPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: CounterpartyListPanelView) {

    }

    start() {
        return this.awaitable.start();
    }

    activate() { this.view.show(); }

    deactivate() { this.view.hide(); }

}