import { TemplateStringArrayType } from "../../Lib/Api/TemplateStringArrayType";
import { TemplateStringFieldType } from "../../Lib/Api/TemplateStringFieldType";
import { TemplateStringPartType } from "../../Lib/Api/TemplateStringPartType";

export class TemplateStringPart {
    constructor(private readonly source: ITemplateStringPartModel) {
    }

    format() {
        let formatted = '';
        const partType = TemplateStringPartType.values.value(this.source.PartType.Value);
        if (partType.equals(TemplateStringPartType.values.Field)) {
            const arrayType = TemplateStringArrayType.values.value(this.source.ArrayType.Value);
            const fieldType = TemplateStringFieldType.values.value(this.source.FieldType.Value);
            if (!arrayType.equals(TemplateStringArrayType.values.NotSet)) {
                formatted += `${arrayType.DisplayText}[${this.source.ArrayIndex}].`;
            }
            if (!fieldType.equals(TemplateStringFieldType.values.NotSet)) {
                formatted += `${fieldType.DisplayText}`;
            }
            formatted = `{${formatted}}`;
        }
        else if (partType.equals(TemplateStringPartType.values.FixedText)) {
            formatted += this.source.FixedText;
        }
        else if (partType.equals(TemplateStringPartType.values.Negative)) {
            formatted += '-';
        }
        else {
            formatted += partType.DisplayText;
        }
        return formatted;
    }
}