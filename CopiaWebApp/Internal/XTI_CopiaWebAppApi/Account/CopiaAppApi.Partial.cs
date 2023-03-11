using XTI_CopiaWebAppApi.Account;

namespace XTI_CopiaWebAppApi;

partial class CopiaAppApi
{
    private AccountGroup? _Account;

    public AccountGroup Account { get => _Account ?? throw new ArgumentNullException(nameof(_Account)); }

    partial void createAccountGroup(IServiceProvider sp)
    {
        _Account = new AccountGroup
        (
            source.AddGroup
            (
                nameof(Account), 
                CopiaInfo.ModCategories.Portfolio, 
                Access.WithAllowed(CopiaInfo.Roles.PortfolioOwner)
            ),
            sp
        );
    }
}