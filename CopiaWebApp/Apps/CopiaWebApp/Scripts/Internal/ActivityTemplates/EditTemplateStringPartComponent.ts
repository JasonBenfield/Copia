import { BasicComponent } from "@jasonbenfield/sharedwebapp/Components/BasicComponent";
import { InputControl } from "@jasonbenfield/sharedwebapp/Components/InputControl";
import { SelectControl } from "@jasonbenfield/sharedwebapp/Components/SelectControl";
import { SelectOption } from "@jasonbenfield/sharedwebapp/Components/SelectOption";
import { TextToNumberViewValue } from "./TextToNumberViewValue";
import { TextToTextViewValue } from "@jasonbenfield/sharedwebapp/Forms/TextToTextViewValue";
import { TemplateStringArrayType } from "../../Lib/Api/TemplateStringArrayType";
import { TemplateStringDataType } from "../../Lib/Api/TemplateStringDataType";
import { TemplateStringFieldType } from "../../Lib/Api/TemplateStringFieldType";
import { TemplateStringPartType } from "../../Lib/Api/TemplateStringPartType";
import { EditTemplateStringPartView } from "./EditTemplateStringPartView";
import { TemplateStringPart } from "./TemplateStringPart";

type PartType = TemplateStringPartType | TemplateStringArrayType | TemplateStringFieldType;

export class EditTemplateStringPartComponent extends BasicComponent {
    private readonly partTypeSelectControl: SelectControl<PartType>;
    private readonly arrayIndexInputControl: InputControl<number>;
    private readonly fieldTypeSelectControl: SelectControl<TemplateStringFieldType>;
    private readonly fixedTextInputControl: InputControl<string>;

    constructor(protected readonly view: EditTemplateStringPartView, dataType: TemplateStringDataType) {
        super(view);
        const partTypes: PartType[] = [];
        if (dataType.equals(TemplateStringDataType.values.String)) {
            partTypes.push(TemplateStringPartType.values.FixedText);
            partTypes.push(TemplateStringArrayType.values.Transactions);
            partTypes.push(TemplateStringFieldType.values.Amount);
        }
        else if (dataType.equals(TemplateStringDataType.values.Decimal)) {
            partTypes.push(TemplateStringPartType.values.Negative);
            partTypes.push(TemplateStringFieldType.values.Amount);
            partTypes.push(TemplateStringPartType.values.FixedText);
        }
        const partTypeOptions = partTypes.map(pt => new SelectOption(pt, pt.DisplayText));
        this.partTypeSelectControl = new SelectControl(view.partTypeSelectView);
        this.partTypeSelectControl.setItems(...partTypeOptions);
        this.partTypeSelectControl.when.valueChanged.then(this.onPartTypeChanged.bind(this));
        this.arrayIndexInputControl = new InputControl(view.arrayIndexInputView, new TextToNumberViewValue());
        this.fieldTypeSelectControl = new SelectControl(view.fieldTypeSelectView);
        this.fixedTextInputControl = new InputControl(view.fixedTextInputView, new TextToTextViewValue());
    }

    private onPartTypeChanged(partType: PartType) {
        if (partType.equals(TemplateStringPartType.values.FixedText)) {
            this.fixedTextInputControl.show();
            this.fixedTextInputControl.setFocus();
        }
        else {
            this.fixedTextInputControl.hide();
        }
        if (partType instanceof TemplateStringArrayType) {
            this.view.showArrayControls();
            this.arrayIndexInputControl.setFocus();
            if (partType.equals(TemplateStringArrayType.values.Transactions)) {
                const fieldTypeOptions = [
                    TemplateStringFieldType.values.AccountID,
                    TemplateStringFieldType.values.AccountName
                ].map(f => new SelectOption(f, f.DisplayText));
                this.fieldTypeSelectControl.setItems(...fieldTypeOptions);
            }
        }
        else {
            this.view.hideArrayControls();
        }
    }

    load(part: ITemplateStringPartModel) {
        const partType = TemplateStringPartType.values.value(part.PartType.Value);
        const arrayType = TemplateStringArrayType.values.value(part.ArrayType.Value);
        const fieldType = TemplateStringFieldType.values.value(part.FieldType.Value);
        if (partType.equals(TemplateStringPartType.values.Field)) {
            if (arrayType.equals(TemplateStringArrayType.values.NotSet)) {
                this.partTypeSelectControl.setValue(fieldType);
            }
            else {
                this.partTypeSelectControl.setValue(arrayType);
                this.arrayIndexInputControl.setValue(part.ArrayIndex);
                this.fieldTypeSelectControl.setValue(fieldType);
            }
        }
        else if (partType.equals(TemplateStringPartType.values.FixedText)) {
            this.partTypeSelectControl.setValue(partType);
            this.fixedTextInputControl.setValue(part.FixedText);
        }
        else {
            this.partTypeSelectControl.setValue(partType);
        }
        this.onPartTypeChanged(partType);
    }

    getAddPartRequest() {
        const part = this.toTemplateStringPartModel();
        return <IAddTemplateStringPartRequest>{
            PartType: part.PartType.Value,
            ArrayType: part.ArrayType.Value,
            ArrayIndex: part.ArrayIndex,
            FieldType: part.FieldType.Value,
            FixedText: part.FixedText
        };
    }

    toTemplateStringPart() {
        const part = this.toTemplateStringPartModel();
        return new TemplateStringPart(part);
    }

    private toTemplateStringPartModel() {
        let partType = TemplateStringPartType.values.FixedText;
        let arrayType = TemplateStringArrayType.values.NotSet;
        let arrayIndex = 0;
        let fieldType = TemplateStringFieldType.values.NotSet;
        let fixedText = '';
        const selectedPartType = this.partTypeSelectControl.getValue();
        if (selectedPartType instanceof TemplateStringPartType) {
            partType = selectedPartType;
            if (selectedPartType.equals(TemplateStringPartType.values.FixedText)) {
                fixedText = this.fixedTextInputControl.getValue();
            }
        }
        else if (selectedPartType instanceof TemplateStringFieldType) {
            partType = TemplateStringPartType.values.Field;
            fieldType = selectedPartType;
        }
        else if (selectedPartType instanceof TemplateStringArrayType) {
            partType = TemplateStringPartType.values.Field;
            arrayType = selectedPartType;
            arrayIndex = this.arrayIndexInputControl.getValue();
            fieldType = this.fieldTypeSelectControl.getValue();
        }
        return <ITemplateStringPartModel>{
            ID: 0,
            PartType: partType,
            ArrayType: arrayType,
            ArrayIndex: arrayIndex,
            FieldType: fieldType,
            FixedText: fixedText
        };
    }

}