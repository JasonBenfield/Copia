using XTI_CopiaWebAppApi.Counterparties;

namespace XTI_CopiaWebAppApi;

partial class CopiaAppApi
{
    private CounterpartiesGroup? _Counterparties;

    public CounterpartiesGroup Counterparties { get => _Counterparties ?? throw new ArgumentNullException(nameof(_Counterparties)); }

    partial void createCounterpartiesGroup(IServiceProvider sp)
    {
        _Counterparties = new CounterpartiesGroup
        (
            source.AddGroup
            (
                nameof(Counterparties),
                CopiaInfo.ModCategories.Portfolio,
                Access.WithAllowed(CopiaInfo.Roles.PortfolioOwner)
            ),
            sp
        );
    }
}