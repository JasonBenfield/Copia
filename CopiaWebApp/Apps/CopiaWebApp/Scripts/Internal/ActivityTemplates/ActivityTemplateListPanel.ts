import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { ListGroup } from "@jasonbenfield/sharedwebapp/Components/ListGroup";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { TextButtonListGroupItemView } from "@jasonbenfield/sharedwebapp/Views/ListGroup";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { ActivityTemplateListItem } from "./ActivityTemplateListItem";
import { ActivityTemplateListPanelView } from "./ActivityTemplateListPanelView";

interface IResults {
    readonly menuRequested?: boolean;
    readonly addRequested?: boolean;
    readonly activityTemplateSelected?: { activityTemplate: IActivityTemplateModel };
}

class Result {
    static menuRequested() { return new Result({ menuRequested: true }); }

    static addRequested() { return new Result({ addRequested: true }); }

    static activityTemplateSelected(activityTemplate: IActivityTemplateModel) {
        return new Result({ activityTemplateSelected: { activityTemplate: activityTemplate } });
    }

    private constructor(private readonly results: IResults) { }

    get menuRequested() { return this.results.menuRequested; }

    get addRequested() { return this.results.addRequested; }

    get activityTemplateSelected() { return this.results.activityTemplateSelected; }
}

export class ActivityTemplateListPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly alert: MessageAlert;
    private readonly activityTemplateListGroup: ListGroup<ActivityTemplateListItem, TextButtonListGroupItemView>;
    private isActive = false;
    private isRefreshRequired = false;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: ActivityTemplateListPanelView) {
        this.alert = new MessageAlert(view.alert);
        this.activityTemplateListGroup = new ListGroup(view.activityTemplateListGroupView);
        this.activityTemplateListGroup.registerItemClicked(this.onActivityTemplateSelected.bind(this));
        new Command(this.menu.bind(this)).add(view.menuButton);
        new Command(this.add.bind(this)).add(view.addButton);
    }

    private onActivityTemplateSelected(activityTemplateListItem: ActivityTemplateListItem) {
        this.awaitable.resolve(Result.activityTemplateSelected(activityTemplateListItem.activityTemplate));
    }

    private menu() { this.awaitable.resolve(Result.menuRequested()); }

    private add() { this.awaitable.resolve(Result.addRequested()); }

    async refresh() {
        this.isRefreshRequired = true;
        if (this.isActive) {
            this._refresh();
        }
    }

    private async _refresh() {
        const activityTemplates = await this.alert.infoAction(
            'Loading...',
            () => this.copiaClient.ActivityTemplates.GetActivityTemplates({})
        );
        this.activityTemplateListGroup.setItems(
            activityTemplates,
            (activityTemplate, itemView) => new ActivityTemplateListItem(activityTemplate, itemView)
        );
        if (activityTemplates.length === 0) {
            this.alert.danger('No activity templates have been added.');
        }
        this.isRefreshRequired = false;
    }

    start() {
        if (this.isRefreshRequired) {
            this._refresh();
        }
        return this.awaitable.start();
    }

    activate() {
        this.view.show();
        this.isActive = true;
    }

    deactivate() {
        this.view.hide();
        this.isActive = false;
    }

}