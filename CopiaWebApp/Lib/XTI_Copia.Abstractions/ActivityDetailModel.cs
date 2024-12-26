namespace XTI_Copia.Abstractions;

public sealed record ActivityDetailModel
(
    ActivityModel Activity, 
    ActivityTemplateModel Template
)
{
    public ActivityDetailModel()
        : this(new ActivityModel(), new ActivityTemplateModel())
    {
    }
}
