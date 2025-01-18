using XTI_CopiaWebAppApiActions.ActivityTemplate;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.ActivityTemplate;
public sealed partial class ActivityTemplateGroupBuilder
{
    private readonly AppApiGroup source;
    internal ActivityTemplateGroupBuilder(AppApiGroup source)
    {
        this.source = source;
        GetActivityTemplate = source.AddAction<GetActivityTemplateRequest, ActivityTemplateModel>("GetActivityTemplate").WithExecution<GetActivityTemplateAction>();
        Configure();
    }

    partial void Configure();
    public AppApiActionBuilder<GetActivityTemplateRequest, ActivityTemplateModel> GetActivityTemplate { get; }

    public ActivityTemplateGroup Build() => new ActivityTemplateGroup(source, this);
}