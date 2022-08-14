using XTI_CopiaWebAppApi.Home;

namespace XTI_CopiaWebAppApi;

partial class CopiaAppApi
{
    private HomeGroup? home;

    public HomeGroup Home { get => home ?? throw new ArgumentNullException(nameof(home)); }

    partial void createHomeGroup(IServiceProvider sp)
    {
        home = new HomeGroup
        (
            source.AddGroup(nameof(Home), ResourceAccess.AllowAuthenticated()),
            sp
        );
    }
}