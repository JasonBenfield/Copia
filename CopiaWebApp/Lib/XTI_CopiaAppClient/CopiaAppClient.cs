// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class CopiaAppClient : AppClient
{
    public CopiaAppClient(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, CopiaAppClientVersion version) : base(httpClientFactory, xtiTokenAccessor, clientUrl, "Copia", version.Value)
    {
        User = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new UserGroup(_clientFactory, _tokenAccessor, _url, _options));
        UserCache = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new UserCacheGroup(_clientFactory, _tokenAccessor, _url, _options));
        Home = CreateGroup((_clientFactory, _tokenAccessor, _url, _options) => new HomeGroup(_clientFactory, _tokenAccessor, _url, _options));
    }

    public CopiaRoleNames RoleNames { get; } = CopiaRoleNames.Instance;
    public string AppName { get; } = "Copia";
    public UserGroup User { get; }

    public UserCacheGroup UserCache { get; }

    public HomeGroup Home { get; }
}