import { AppApiFactory } from "@jasonbenfield/sharedwebapp/Api/AppApiFactory";
import { ModalErrorView } from "@jasonbenfield/sharedwebapp/Views/ModalError";
import { CopiaAppApi } from "../Lib/Api/CopiaAppApi";

export class Apis {
    private readonly apiFactory: AppApiFactory;

    constructor(modalError: ModalErrorView) {
        this.apiFactory = new AppApiFactory(modalError)
    }

    Copia() {
        return this.apiFactory.api(CopiaAppApi);
    }
}