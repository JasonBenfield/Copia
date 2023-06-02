import { BasicComponent } from "@jasonbenfield/sharedwebapp/Components/BasicComponent";
import { TemplateStringDataType } from "../../Lib/Api/TemplateStringDataType";
import { EditTemplateStringPartComponent } from "./EditTemplateStringPartComponent";
import { EditTemplateStringPartListView } from "./EditTemplateStringPartListView";
import { EventSource } from '@jasonbenfield/sharedwebapp/Events';

type Events = { templateStringChanged: null };

export class EditTemplateStringPartListComponent extends BasicComponent {
    private dataType: TemplateStringDataType;
    private readonly eventSource = new EventSource<Events>(
        this,
        { templateStringChanged: null }
    );
    readonly when = this.eventSource.when;

    constructor(protected readonly view: EditTemplateStringPartListView) {
        super(view);
        view.handleTemplateStringChanged(this.onTemplateStringChanged.bind(this));
    }

    private onTemplateStringChanged() {
        this.eventSource.events.templateStringChanged.invoke();
    }

    setParts(dataType: TemplateStringDataType, parts: ITemplateStringPartModel[]) {
        this.dataType = dataType;
        this.clearComponents();
        for (const part of parts) {
            const partComponent = this.addPart();
            partComponent.load(part);
        }
    }

    addPart() {
        const partView = this.view.addPartView();
        const partComponent = new EditTemplateStringPartComponent(partView, this.dataType);
        this.addComponent(partComponent);
        return partComponent;
    }

    getAddPartRequests() {
        const partComponents = this.getComponents() as EditTemplateStringPartComponent[];
        return partComponents.map(p => p.getAddPartRequest());
    }

    getTemplateStringParts() {
        const partComponents = this.getComponents() as EditTemplateStringPartComponent[];
        return partComponents.map(p => p.toTemplateStringPart());
    }
}