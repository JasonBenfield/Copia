import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { TextComponent } from "@jasonbenfield/sharedwebapp/Components/TextComponent";
import { CopiaAppClient } from "../../Lib/Http/CopiaAppClient";
import { ActivityTemplatePanelView } from "./ActivityTemplatePanelView";

interface IResults {
    readonly back?: boolean;
}

class Result {
    static back() { return new Result({ back: true }); }

    private constructor(private readonly results: IResults) { }

    get back() { return this.results.back; }
}

export class ActivityTemplatePanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly alert: MessageAlert;
    private readonly templateNameText: TextComponent;
    private readonly activityNameText: TextComponent;
    private templateID: number;

    constructor(private readonly copiaClient: CopiaAppClient, private readonly view: ActivityTemplatePanelView) {
        this.alert = new MessageAlert(view.alert);
        this.templateNameText = new TextComponent(view.templateNameView);
        this.activityNameText = new TextComponent(view.activityNameView);
        new Command(this.back.bind(this)).add(view.backButton);
    }

    private back() {
        this.awaitable.resolve(Result.back());
    }

    async setActivityTemplateID(templateID: number) {
        this.templateID = templateID;
        const activityTemplateDetail = await this.getActivityTemplate(templateID);
        this.setActivityTemplateDetail(activityTemplateDetail);
    }

    refresh() {
        return this.setActivityTemplateID(this.templateID);
    }

    private getActivityTemplate(templateID: number) {
        return this.alert.infoAction(
            'Loading...',
            () => this.copiaClient.ActivityTemplate.GetActivityTemplate({ TemplateID: templateID })
        );
    }

    setActivityTemplateDetail(activityTemplate: IActivityTemplateModel) {
        this.templateNameText.setText(activityTemplate.TemplateName);
        this.activityNameText.setText("");
    }

    start() { return this.awaitable.start(); }

    activate() { this.view.show(); }

    deactivate() { this.view.hide(); }

}