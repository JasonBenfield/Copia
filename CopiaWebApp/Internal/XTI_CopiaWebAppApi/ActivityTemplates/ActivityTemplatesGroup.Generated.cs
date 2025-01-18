using XTI_CopiaWebAppApiActions.ActivityTemplates;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.ActivityTemplates;
public sealed partial class ActivityTemplatesGroup : AppApiGroupWrapper
{
    internal ActivityTemplatesGroup(AppApiGroup source, ActivityTemplatesGroupBuilder builder) : base(source)
    {
        AddActivityTemplate = builder.AddActivityTemplate.Build();
        GetActivityTemplates = builder.GetActivityTemplates.Build();
        Index = builder.Index.Build();
        Configure();
    }

    partial void Configure();
    public AppApiAction<AddActivityTemplateRequest, ActivityTemplateModel> AddActivityTemplate { get; }
    public AppApiAction<EmptyRequest, ActivityTemplateModel[]> GetActivityTemplates { get; }
    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
}