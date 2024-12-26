import { AppClientFactory } from "@jasonbenfield/sharedwebapp/Http/AppClientFactory";
import { ModalErrorView } from "@jasonbenfield/sharedwebapp/Views/ModalError";
import { CopiaAppClient } from "../Lib/Http/CopiaAppClient";

export class Apis {
    private readonly apiFactory: AppClientFactory;

    constructor(modalError: ModalErrorView) {
        this.apiFactory = new AppClientFactory(modalError)
    }

    Copia() {
        return this.apiFactory.create(CopiaAppClient);
    }
}