// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class CopiaAppClient : AppClient
{
    public CopiaAppClient(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, CopiaAppClientVersion version) : base(httpClientFactory, xtiTokenAccessor, clientUrl, "Copia", version.Value)
    {
        Account = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new AccountGroup(_clientFactory, _tokenAccessor, _url, _options));
        ActivityTemplate = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new ActivityTemplateGroup(_clientFactory, _tokenAccessor, _url, _options));
        ActivityTemplates = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new ActivityTemplatesGroup(_clientFactory, _tokenAccessor, _url, _options));
        Home = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new HomeGroup(_clientFactory, _tokenAccessor, _url, _options));
        Portfolio = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new PortfolioGroup(_clientFactory, _tokenAccessor, _url, _options));
        Portfolios = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new PortfoliosGroup(_clientFactory, _tokenAccessor, _url, _options));
    }

    public CopiaRoleNames RoleNames { get; } = CopiaRoleNames.Instance;
    public string AppName { get; } = "Copia";
    public AccountGroup Account { get; }

    public ActivityTemplateGroup ActivityTemplate { get; }

    public ActivityTemplatesGroup ActivityTemplates { get; }

    public HomeGroup Home { get; }

    public PortfolioGroup Portfolio { get; }

    public PortfoliosGroup Portfolios { get; }
}