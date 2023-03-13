import { JoinedStrings } from "@jasonbenfield/sharedwebapp/JoinedStrings";
import { TemplateStringPart } from "./TemplateStringPart";

export class TemplateString {
    constructor(private readonly source: ITemplateStringModel) {
    }

    format() {
        let formatted: string;
        if (this.source.Parts.length > 0) {
            const parts = this.source.Parts.map(p => new TemplateStringPart(p));
            formatted = new JoinedStrings('', parts).value();
        }
        else {
            formatted = 'Free Format';
        }
        return formatted;
    }
}