namespace XTI_CopiaWebAppApi.ActivityTemplates;

partial class ActivityTemplatesGroupBuilder
{
    partial void Configure()
    {
        source.WithModCategory(CopiaInfo.ModCategories.Portfolio);
        source.WithAllowed(CopiaInfo.Roles.PortfolioOwner);
    }
}
