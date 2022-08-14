using XTI_App.Abstractions;

namespace CopiaSetupApp;

internal sealed class CopiaAppSetup : IAppSetup
{
    public Task Run(AppVersionKey versionKey)
    {
        return Task.CompletedTask;
    }
}
