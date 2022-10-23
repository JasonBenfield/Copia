import { Awaitable } from "@jasonbenfield/sharedwebapp/Awaitable";
import { AsyncCommand, Command } from "@jasonbenfield/sharedwebapp/Components/Command";
import { MessageAlert } from "@jasonbenfield/sharedwebapp/Components/MessageAlert";
import { DelayedAction } from "@jasonbenfield/sharedwebapp/DelayedAction";
import { TextInputFormGroup } from "@jasonbenfield/sharedwebapp/Forms/TextInputFormGroup";
import { CopiaAppApi } from "../../Lib/Api/CopiaAppApi";
import { AddPortfolioPanelView } from "./AddPortfolioPanelView";

interface IResults {
    readonly cancelled?: boolean;
    readonly saved?: { portfolio: IPortfolioModel };
}

class Result {
    static cancelled() { return new Result({ cancelled: true }); }

    static saved(portfolio: IPortfolioModel) {
        return new Result({ saved: { portfolio: portfolio } });
    }

    private constructor(private readonly results: IResults) { }

    get cancelled() { return this.results.cancelled; }

    get saved() { return this.results.saved; }
}

export class AddPortfolioPanel implements IPanel {
    private readonly awaitable = new Awaitable<Result>();
    private readonly portfolioName: TextInputFormGroup;
    private readonly alert: MessageAlert;
    private readonly saveCommand: AsyncCommand;

    constructor(private readonly copiaApi: CopiaAppApi, private readonly view: AddPortfolioPanelView) {
        this.portfolioName = new TextInputFormGroup('', '', view.portfolioName);
        this.alert = new MessageAlert(view.alert);
        view.handleFormSubmit(this.onFormSubmit.bind(this));
        new Command(this.cancel.bind(this)).add(view.cancelButton);
        this.saveCommand = new AsyncCommand(this.save.bind(this));
        this.saveCommand.add(view.saveButton);
    }

    private onFormSubmit(el: HTMLElement, evt: JQueryEventObject) {
        evt.preventDefault();
        this.saveCommand.execute();
    }

    private cancel() {
        this.awaitable.resolve(Result.cancelled());
    }

    private async save() {
        return this.alert.infoAction(
            'Saving...',
            async () => {
                const addRequest: IAddPortfolioRequest = {
                    PortfolioName: this.portfolioName.getValue()
                };
                const portfolio = await this.copiaApi.Portfolios.AddPortfolio(addRequest);
                this.awaitable.resolve(Result.saved(portfolio));
            }
        );
    }

    reset() {
        this.portfolioName.setValue('');
    }

    start() { return this.awaitable.start(); }

    activate() {
        this.view.show();
        new DelayedAction(
            () => this.portfolioName.setFocus(),
            700
        ).execute();
    }

    deactivate() { this.view.hide(); }
}