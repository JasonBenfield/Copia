using XTI_CopiaWebAppApi.Account;
using XTI_CopiaWebAppApi.Activities;
using XTI_CopiaWebAppApi.ActivityTemplate;
using XTI_CopiaWebAppApi.ActivityTemplates;
using XTI_CopiaWebAppApi.Counterparties;
using XTI_CopiaWebAppApi.Home;
using XTI_CopiaWebAppApi.Portfolio;
using XTI_CopiaWebAppApi.Portfolios;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi;
public sealed partial class CopiaAppApi : WebAppApiWrapper
{
    internal CopiaAppApi(AppApi source, CopiaAppApiBuilder builder) : base(source)
    {
        Account = builder.Account.Build();
        Activities = builder.Activities.Build();
        ActivityTemplate = builder.ActivityTemplate.Build();
        ActivityTemplates = builder.ActivityTemplates.Build();
        Counterparties = builder.Counterparties.Build();
        Home = builder.Home.Build();
        Portfolio = builder.Portfolio.Build();
        Portfolios = builder.Portfolios.Build();
        Configure();
    }

    partial void Configure();
    public AccountGroup Account { get; }
    public ActivitiesGroup Activities { get; }
    public ActivityTemplateGroup ActivityTemplate { get; }
    public ActivityTemplatesGroup ActivityTemplates { get; }
    public CounterpartiesGroup Counterparties { get; }
    public HomeGroup Home { get; }
    public PortfolioGroup Portfolio { get; }
    public PortfoliosGroup Portfolios { get; }
}