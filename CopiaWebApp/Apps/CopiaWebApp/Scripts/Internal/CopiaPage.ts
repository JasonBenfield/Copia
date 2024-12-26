import { BasicPage } from "@jasonbenfield/sharedwebapp/Components/BasicPage";
import { CopiaAppClient } from "../Lib/Http/CopiaAppClient";
import { Apis } from "./Apis";
import { CopiaPageView } from "./CopiaPageView";

export class CopiaPage extends BasicPage {
    protected readonly copiaClient: CopiaAppClient;

    constructor(view: CopiaPageView) {
        const apis = new Apis(view.modalError);
        const copiaClient = apis.Copia();
        super(copiaClient, view);
        this.copiaClient = copiaClient;
    }
}