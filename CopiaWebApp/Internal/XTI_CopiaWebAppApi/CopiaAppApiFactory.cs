namespace XTI_CopiaWebAppApi;

public sealed class CopiaAppApiFactory : AppApiFactory
{
    private readonly IServiceProvider sp;

    public CopiaAppApiFactory(IServiceProvider sp)
    {
        this.sp = sp;
    }

    public new CopiaAppApi Create(IAppApiUser user) => (CopiaAppApi)base.Create(user);
    public new CopiaAppApi CreateForSuperUser() => (CopiaAppApi)base.CreateForSuperUser();

    protected override IAppApi _Create(IAppApiUser user) => new CopiaAppApi(user, sp);
}