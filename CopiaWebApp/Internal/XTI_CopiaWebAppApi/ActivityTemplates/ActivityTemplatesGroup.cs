using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.ActivityTemplates;

public sealed class ActivityTemplatesGroup : AppApiGroupWrapper
{
    public ActivityTemplatesGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        AddActivityTemplate = source.AddAction
        (
            nameof(AddActivityTemplate),
            () => sp.GetRequiredService<AddActivityTemplateAction>(),
            () => sp.GetRequiredService<AddActivityTemplateValidation>()
        );
        GetActivityTemplates = source.AddAction(nameof(GetActivityTemplates), () => sp.GetRequiredService<GetActivityTemplatesAction>());
        Index = source.AddAction(nameof(Index), () => sp.GetRequiredService<IndexAction>());
    }

    public AppApiAction<AddActivityTemplateRequest, ActivityTemplateDetailModel> AddActivityTemplate { get; }
    public AppApiAction<EmptyRequest, ActivityTemplateModel[]> GetActivityTemplates { get; }
    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
}