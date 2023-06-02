import { TypedFieldViewValue } from "@jasonbenfield/sharedwebapp/Forms/TypedFieldViewValue";

export class TextToNumberViewValue extends TypedFieldViewValue<string, number> {
    protected _fromView(value: string) {
        let numericValue: number = null;
        if (value) {
            value = value.replace(/[,|$]+/g, '');
            if (value) {
                numericValue = parseFloat(value);
                if (Number.isNaN(numericValue)) {
                    numericValue = null;
                }
            }
        }
        return numericValue;
    }

    protected _toView(value: number) {
        return value === undefined || value === null || Number.isNaN(value) ? '' : value.toString();
    }
}