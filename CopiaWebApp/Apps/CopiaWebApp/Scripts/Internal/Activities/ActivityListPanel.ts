import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { ActivityListPanelView } from "./ActivityListPanelView";

interface IResults {
    menu?: boolean;
    addRequested?: boolean;
}

class Result {
    static menu() { return new Result({ menu: true }); }

    static addRequested() { return new Result({ addRequested: true }); }

    private constructor(private readonly results: IResults) { }

    get menu() { return this.results.menu; }

    get addRequested() { return this.results.addRequested; }
}

export class ActivityListPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly alert: MessageAlert;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: ActivityListPanelView) {
        this.alert = new MessageAlert(view.alertView);
        new Command(this.menu.bind(this)).add(view.menuButton);
    }

    private menu() { return Result.menu(); }

    async refresh() {

    }

    start() {
        return this.awaitable.start();
    }

    activate() { this.view.show(); }

    deactivate() { this.view.hide(); }

}