import { BasicPage } from "@jasonbenfield/sharedwebapp/Components/BasicPage";
import { CopiaAppApi } from "../Lib/Api/CopiaAppApi";
import { Apis } from "./Apis";
import { CopiaPageView } from "./CopiaPageView";

export class CopiaPage extends BasicPage {
    protected readonly defaultApi: CopiaAppApi;

    constructor(view: CopiaPageView) {
        super(new Apis(view.modalError).Copia(), view);
    }
}