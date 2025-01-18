// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class CopiaAppClientFactory
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly XtiTokenAccessorFactory xtiTokenAccessorFactory;
    private readonly AppClientUrl clientUrl;
    private readonly IAppClientSessionKey sessionKey;
    private readonly IAppClientRequestKey requestKey;
    private readonly CopiaAppClientVersion version;
    public CopiaAppClientFactory(IHttpClientFactory httpClientFactory, XtiTokenAccessorFactory xtiTokenAccessorFactory, AppClientUrl clientUrl, IAppClientSessionKey sessionKey, IAppClientRequestKey requestKey, CopiaAppClientVersion version)
    {
        this.httpClientFactory = httpClientFactory;
        this.xtiTokenAccessorFactory = xtiTokenAccessorFactory;
        this.clientUrl = clientUrl;
        this.sessionKey = sessionKey;
        this.requestKey = requestKey;
        this.version = version;
    }

    public CopiaAppClient Create() => new CopiaAppClient(httpClientFactory, xtiTokenAccessorFactory, clientUrl, sessionKey, requestKey, version);
}