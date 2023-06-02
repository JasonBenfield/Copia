import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { ListGroup } from "@jasonbenfield/sharedwebapp/Components/ListGroup";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { TextComponent } from "@jasonbenfield/sharedwebapp/Components/TextComponent";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { ActivityTemplateFieldListItem } from "./ActivityTemplateFieldListItem";
import { ActivityTemplateFieldListItemView } from "./ActivityTemplateFieldListItemView";
import { ActivityTemplatePanelView } from "./ActivityTemplatePanelView";
import { TemplateString } from "./TemplateString";

interface IResults {
    readonly back?: boolean;
    readonly editTemplateStringRequested?: { templateString: ITemplateStringModel };
}

class Result {
    static back() { return new Result({ back: true }); }

    static editTemplateStringRequested(templateString: ITemplateStringModel) {
        return new Result({ editTemplateStringRequested: { templateString: templateString } });
    }

    private constructor(private readonly results: IResults) { }

    get back() { return this.results.back; }

    get editTemplateStringRequested() { return this.results.editTemplateStringRequested; }
}

export class ActivityTemplatePanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly alert: MessageAlert;
    private readonly templateNameText: TextComponent;
    private readonly activityNameText: TextComponent;
    private readonly fieldListGroup: ListGroup<ActivityTemplateFieldListItem, ActivityTemplateFieldListItemView>;
    private activityName: ITemplateStringModel;
    private templateID: number;

    constructor(private readonly copiaClient: CopiaAppApi, private readonly view: ActivityTemplatePanelView) {
        this.alert = new MessageAlert(view.alert);
        this.templateNameText = new TextComponent(view.templateNameView);
        this.activityNameText = new TextComponent(view.activityNameView);
        this.fieldListGroup = new ListGroup(view.fieldListGroupView);
        new Command(this.back.bind(this)).add(view.backButton);
        new Command(this.editActivityName.bind(this)).add(view.editActivityNameButton);
    }

    private back() {
        this.awaitable.resolve(Result.back());
    }

    private editActivityName() {
        this.awaitable.resolve(Result.editTemplateStringRequested(this.activityName));
    }

    async setActivityTemplateID(templateID: number) {
        this.templateID = templateID;
        const activityTemplateDetail = await this.getActivityTemplateDetail(templateID);
        this.setActivityTemplateDetail(activityTemplateDetail);
    }

    refresh() {
        return this.setActivityTemplateID(this.templateID);
    }

    private getActivityTemplateDetail(templateID: number) {
        return this.alert.infoAction(
            'Loading...',
            () => this.copiaClient.ActivityTemplate.GetActivityTemplateDetail({ TemplateID: templateID })
        );
    }

    setActivityTemplateDetail(activityTemplateDetail: IActivityTemplateDetailModel) {
        this.activityName = activityTemplateDetail.ActivityName;
        this.templateNameText.setText(activityTemplateDetail.Template.TemplateName);
        const activityName = new TemplateString(activityTemplateDetail.ActivityName).format();
        this.activityNameText.setText(activityName);
        this.fieldListGroup.setItems(
            activityTemplateDetail.TemplateFields,
            (field, itemView) => new ActivityTemplateFieldListItem(field, itemView)
        );
    }

    start() { return this.awaitable.start(); }

    activate() { this.view.show(); }

    deactivate() { this.view.hide(); }

}