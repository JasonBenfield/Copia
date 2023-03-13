using XTI_CopiaWebAppApi.ActivityTemplates;

namespace XTI_CopiaWebAppApi;

partial class CopiaAppApi
{
    private ActivityTemplatesGroup? _ActivityTemplates;

    public ActivityTemplatesGroup ActivityTemplates { get => _ActivityTemplates ?? throw new ArgumentNullException(nameof(_ActivityTemplates)); }

    partial void createActivityTemplatesGroup(IServiceProvider sp)
    {
        _ActivityTemplates = new ActivityTemplatesGroup
        (
            source.AddGroup
            (
                nameof(ActivityTemplates),
                CopiaInfo.ModCategories.Portfolio,
                Access.WithAllowed(CopiaInfo.Roles.PortfolioOwner)
            ),
            sp
        );
    }
}