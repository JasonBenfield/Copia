namespace XTI_CopiaWebAppApi.Account;

partial class AccountGroupBuilder
{
    partial void Configure()
    {
        source.WithModCategory(CopiaInfo.ModCategories.Portfolio);
        source.WithAllowed(CopiaInfo.Roles.PortfolioOwner);
    }
}
