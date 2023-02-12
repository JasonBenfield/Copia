using XTI_CopiaWebAppApi.Portfolio;

namespace XTI_CopiaWebAppApi;

partial class CopiaAppApi
{
    private PortfolioGroup? _Portfolio;

    public PortfolioGroup Portfolio { get => _Portfolio ?? throw new ArgumentNullException(nameof(_Portfolio)); }

    partial void createPortfolioGroup(IServiceProvider sp)
    {
        _Portfolio = new PortfolioGroup
        (
            source.AddGroup(nameof(Portfolio)),
            sp
        );
    }
}