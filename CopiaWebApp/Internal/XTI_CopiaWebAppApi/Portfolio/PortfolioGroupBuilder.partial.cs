namespace XTI_CopiaWebAppApi.Portfolio;

partial class PortfolioGroupBuilder
{
    partial void Configure()
    {
        source.WithModCategory(CopiaInfo.ModCategories.Portfolio);
        source.WithAllowed(CopiaInfo.Roles.PortfolioOwner);
    }
}
