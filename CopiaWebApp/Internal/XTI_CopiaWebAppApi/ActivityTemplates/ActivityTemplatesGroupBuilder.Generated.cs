using XTI_CopiaWebAppApiActions.ActivityTemplates;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.ActivityTemplates;
public sealed partial class ActivityTemplatesGroupBuilder
{
    private readonly AppApiGroup source;
    internal ActivityTemplatesGroupBuilder(AppApiGroup source)
    {
        this.source = source;
        AddActivityTemplate = source.AddAction<AddActivityTemplateRequest, ActivityTemplateModel>("AddActivityTemplate").WithExecution<AddActivityTemplateAction>().WithValidation<AddActivityTemplateValidation>();
        GetActivityTemplates = source.AddAction<EmptyRequest, ActivityTemplateModel[]>("GetActivityTemplates").WithExecution<GetActivityTemplatesAction>();
        Index = source.AddAction<EmptyRequest, WebViewResult>("Index").WithExecution<IndexAction>();
        Configure();
    }

    partial void Configure();
    public AppApiActionBuilder<AddActivityTemplateRequest, ActivityTemplateModel> AddActivityTemplate { get; }
    public AppApiActionBuilder<EmptyRequest, ActivityTemplateModel[]> GetActivityTemplates { get; }
    public AppApiActionBuilder<EmptyRequest, WebViewResult> Index { get; }

    public ActivityTemplatesGroup Build() => new ActivityTemplatesGroup(source, this);
}