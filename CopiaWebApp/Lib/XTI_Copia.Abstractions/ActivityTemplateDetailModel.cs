namespace XTI_Copia.Abstractions;

public sealed record ActivityTemplateDetailModel
(
    ActivityTemplateModel Template,
    TemplateStringModel ActivityName,
    ActivityTemplateFieldModel[] TemplateFields
)
{
    public ActivityTemplateDetailModel()
        : this
        (
            new ActivityTemplateModel(), 
            new TemplateStringModel(), 
            new ActivityTemplateFieldModel[0]
        )
    {
    }
}
