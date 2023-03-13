using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.ActivityTemplate;

public sealed class ActivityTemplateGroup : AppApiGroupWrapper
{
    public ActivityTemplateGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        EditTemplateString = source.AddAction(nameof(EditTemplateString), () => sp.GetRequiredService<EditTemplateStringAction>());
        GetActivityTemplateDetail = source.AddAction(nameof(GetActivityTemplateDetail), () => sp.GetRequiredService<GetActivityTemplateDetailAction>());
    }

    public AppApiAction<EditTemplateStringRequest, TemplateStringModel> EditTemplateString { get; }
    public AppApiAction<GetActivityTemplateRequest, ActivityTemplateDetailModel> GetActivityTemplateDetail { get; }
}