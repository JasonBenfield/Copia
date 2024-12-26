// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class CopiaAppClientFactory
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly XtiTokenAccessorFactory xtiTokenAccessorFactory;
    private readonly AppClientUrl clientUrl;
    private readonly AppClientOptions options;
    private readonly CopiaAppClientVersion version;
    public CopiaAppClientFactory(IHttpClientFactory httpClientFactory, XtiTokenAccessorFactory xtiTokenAccessorFactory, AppClientUrl clientUrl, AppClientOptions options, CopiaAppClientVersion version)
    {
        this.httpClientFactory = httpClientFactory;
        this.xtiTokenAccessorFactory = xtiTokenAccessorFactory;
        this.clientUrl = clientUrl;
        this.options = options;
        this.version = version;
    }

    public CopiaAppClient Create() => new CopiaAppClient(httpClientFactory, xtiTokenAccessorFactory, clientUrl, options, version);
}