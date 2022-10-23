// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class CopiaAppClient : AppClient
{
    public CopiaAppClient(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, CopiaAppClientVersion version) : base(httpClientFactory, xtiTokenAccessor, clientUrl, "Copia", version.Value)
    {
        Home = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new HomeGroup(_clientFactory, _tokenAccessor, _url, _options));
        Portfolios = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new PortfoliosGroup(_clientFactory, _tokenAccessor, _url, _options));
    }

    public CopiaRoleNames RoleNames { get; } = CopiaRoleNames.Instance;
    public string AppName { get; } = "Copia";
    public HomeGroup Home { get; }

    public PortfoliosGroup Portfolios { get; }
}