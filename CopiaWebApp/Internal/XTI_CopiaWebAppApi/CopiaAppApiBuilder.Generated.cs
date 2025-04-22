using XTI_CopiaWebAppApi.Account;
using XTI_CopiaWebAppApi.Activities;
using XTI_CopiaWebAppApi.Counterparties;
using XTI_CopiaWebAppApi.Home;
using XTI_CopiaWebAppApi.Portfolio;
using XTI_CopiaWebAppApi.Portfolios;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi;
public sealed partial class CopiaAppApiBuilder
{
    private readonly AppApi source;
    private readonly IServiceProvider sp;
    public CopiaAppApiBuilder(IServiceProvider sp, IAppApiUser user)
    {
        source = new AppApi(sp, CopiaAppKey.Value, user);
        this.sp = sp;
        Account = new AccountGroupBuilder(source.AddGroup("Account"));
        Activities = new ActivitiesGroupBuilder(source.AddGroup("Activities"));
        Counterparties = new CounterpartiesGroupBuilder(source.AddGroup("Counterparties"));
        Home = new HomeGroupBuilder(source.AddGroup("Home"));
        Portfolio = new PortfolioGroupBuilder(source.AddGroup("Portfolio"));
        Portfolios = new PortfoliosGroupBuilder(source.AddGroup("Portfolios"));
        Configure();
    }

    partial void Configure();
    public AccountGroupBuilder Account { get; }
    public ActivitiesGroupBuilder Activities { get; }
    public CounterpartiesGroupBuilder Counterparties { get; }
    public HomeGroupBuilder Home { get; }
    public PortfolioGroupBuilder Portfolio { get; }
    public PortfoliosGroupBuilder Portfolios { get; }

    public CopiaAppApi Build() => new CopiaAppApi(source, this);
}