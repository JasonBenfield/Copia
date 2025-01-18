namespace XTI_CopiaWebAppApi.Counterparties;

partial class CounterpartiesGroupBuilder
{
    partial void Configure()
    {
        source.WithModCategory(CopiaInfo.ModCategories.Portfolio);
        source.WithAllowed(CopiaInfo.Roles.PortfolioOwner);
    }
}
