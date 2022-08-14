// Generated Code
namespace XTI_CopiaAppClient;
public sealed class CopiaAppClientVersion
{
    public static CopiaAppClientVersion Version(string value) => new CopiaAppClientVersion(value);
    public CopiaAppClientVersion(IHostEnvironment hostEnv) : this(getValue(hostEnv))
    {
    }

    private static string getValue(IHostEnvironment hostEnv)
    {
        string value;
        if (hostEnv.IsProduction())
        {
            value = "Current";
        }
        else
        {
            value = "Current";
        }

        return value;
    }

    private CopiaAppClientVersion(string value)
    {
        Value = value;
    }

    public string Value { get; }
}