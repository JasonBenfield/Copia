using XTI_CopiaWebAppApi.Portfolios;

namespace XTI_CopiaWebAppApi;

partial class CopiaAppApi
{
    private PortfoliosGroup? _Portfolios;

    public PortfoliosGroup Portfolios { get => _Portfolios ?? throw new ArgumentNullException(nameof(_Portfolios)); }

    partial void createPortfoliosGroup(IServiceProvider sp)
    {
        _Portfolios = new PortfoliosGroup
        (
            source.AddGroup(nameof(Portfolios), ResourceAccess.AllowAuthenticated()),
            sp
        );
    }
}