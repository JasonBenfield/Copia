using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.ActivityTemplate;

public sealed class ActivityTemplateGroup : AppApiGroupWrapper
{
    public ActivityTemplateGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        GetActivityTemplate = source.AddAction(nameof(GetActivityTemplate), () => sp.GetRequiredService<GetActivityTemplateAction>());
    }

    public AppApiAction<GetActivityTemplateRequest, ActivityTemplateModel> GetActivityTemplate { get; }
}