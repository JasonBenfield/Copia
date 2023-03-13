using XTI_CopiaWebAppApi.ActivityTemplate;

namespace XTI_CopiaWebAppApi;

partial class CopiaAppApi
{
    private ActivityTemplateGroup? _ActivityTemplate;

    public ActivityTemplateGroup ActivityTemplate { get => _ActivityTemplate ?? throw new ArgumentNullException(nameof(_ActivityTemplate)); }

    partial void createActivityTemplateGroup(IServiceProvider sp)
    {
        _ActivityTemplate = new ActivityTemplateGroup
        (
            source.AddGroup
            (
                nameof(ActivityTemplate),
                CopiaInfo.ModCategories.Portfolio,
                Access.WithAllowed(CopiaInfo.Roles.PortfolioOwner)
            ),
            sp
        );
    }
}