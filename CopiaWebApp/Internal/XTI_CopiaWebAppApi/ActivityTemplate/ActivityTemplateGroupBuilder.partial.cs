namespace XTI_CopiaWebAppApi.ActivityTemplate;

partial class ActivityTemplateGroupBuilder
{
    partial void Configure()
    {
        source.WithModCategory(CopiaInfo.ModCategories.Portfolio);
        source.WithAllowed(CopiaInfo.Roles.PortfolioOwner);
    }
}
