using XTI_CopiaWebAppApi.Activities;

namespace XTI_CopiaWebAppApi;

partial class CopiaAppApi
{
    private ActivitiesGroup? _Activities;

    public ActivitiesGroup Activities { get => _Activities ?? throw new ArgumentNullException(nameof(_Activities)); }

    partial void createActivitiesGroup(IServiceProvider sp)
    {
        _Activities = new ActivitiesGroup
        (
            source.AddGroup
            (
                nameof(Activities),
                CopiaInfo.ModCategories.Portfolio,
                Access.WithAllowed(CopiaInfo.Roles.PortfolioOwner)
            ),
            sp
        );
    }
}