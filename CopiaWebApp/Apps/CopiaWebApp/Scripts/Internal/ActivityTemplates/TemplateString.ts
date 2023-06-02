import { JoinedStrings } from "@jasonbenfield/sharedwebapp/JoinedStrings";
import { TemplateStringPart } from "./TemplateStringPart";

export class TemplateString {
    private readonly parts: TemplateStringPart[] = [];

    constructor(source: ITemplateStringModel | TemplateStringPart[]) {
        let parts: TemplateStringPart[];
        if (Array.isArray(source)) {
            parts = source;
        }
        else {
            parts = source.Parts.map(p => new TemplateStringPart(p));
        }
        this.parts.splice(0, this.parts.length, ...parts);
    }

    format() {
        let formatted: string;
        if (this.parts.length > 0) {
            const parts = this.parts.map(p => p.format());
            formatted = new JoinedStrings('', parts).value();
        }
        else {
            formatted = 'Free Format';
        }
        return formatted;
    }
}