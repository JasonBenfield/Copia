using XTI_CopiaWebAppApiActions.ActivityTemplate;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.ActivityTemplate;
public sealed partial class ActivityTemplateGroup : AppApiGroupWrapper
{
    internal ActivityTemplateGroup(AppApiGroup source, ActivityTemplateGroupBuilder builder) : base(source)
    {
        GetActivityTemplate = builder.GetActivityTemplate.Build();
        Configure();
    }

    partial void Configure();
    public AppApiAction<GetActivityTemplateRequest, ActivityTemplateModel> GetActivityTemplate { get; }
}