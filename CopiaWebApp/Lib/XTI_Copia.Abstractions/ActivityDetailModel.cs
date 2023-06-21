namespace XTI_Copia.Abstractions;

public sealed record ActivityDetailModel(ActivityModel Activity, ActivityTemplateDetailModel TemplateDetail)
{
    public ActivityDetailModel()
        : this(new ActivityModel(), new ActivityTemplateDetailModel())
    {
    }
}
