using Microsoft.Extensions.DependencyInjection;
using XTI_App.Abstractions;
using XTI_App.Fakes;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal static class CopiaActionTester
{
    public static CopiaActionTester<TModel, TResult> Create<TModel, TResult>(IServiceProvider services, Func<CopiaAppApi, AppApiAction<TModel, TResult>> getAction)
    {
        return new CopiaActionTester<TModel, TResult>(services, getAction);
    }
}

internal interface ICopiaActionTester
{
    IServiceProvider Services { get; }
    CopiaActionTester<TOtherModel, TOtherResult> Create<TOtherModel, TOtherResult>(Func<CopiaAppApi, AppApiAction<TOtherModel, TOtherResult>> getAction);
}

internal sealed class CopiaActionTester<TModel, TResult> : ICopiaActionTester
{
    private readonly Func<CopiaAppApi, AppApiAction<TModel, TResult>> getAction;

    public CopiaActionTester
    (
        IServiceProvider services,
        Func<CopiaAppApi, AppApiAction<TModel, TResult>> getAction
    )
    {
        Services = services;
        this.getAction = getAction;
    }

    public CopiaActionTester<TOtherModel, TOtherResult> Create<TOtherModel, TOtherResult>
    (
        Func<CopiaAppApi, AppApiAction<TOtherModel, TOtherResult>> getAction
    )
    {
        return CopiaActionTester.Create(Services, getAction);
    }

    public IServiceProvider Services { get; }

    public void Logout()
    {
        var currentUserName = Services.GetRequiredService<FakeCurrentUserName>();
        currentUserName.SetUserName(AppUserName.Anon);
    }

    public void LoginAsAdmin()
    {
        var currentUserName = Services.GetRequiredService<FakeCurrentUserName>();
        currentUserName.SetUserName(new AppUserName("admin.user"));
    }

    public void Login(params AppRoleName[]? roleNames) => Login(new AppUserName("loggedInUser"), roleNames);

    public void Login(AppUserName userName, params AppRoleName[]? roleNames) => Login(userName, ModifierCategoryName.Default, ModifierKey.Default, roleNames);

    public void Login(ModifierCategoryName categoryName, ModifierKey modifier, params AppRoleName[]? roleNames) => Login(new AppUserName("loggedInUser"), categoryName, modifier, roleNames);

    public void Login(AppUserName userName, ModifierCategoryName categoryName, ModifierKey modifier, params AppRoleName[]? roleNames)
    {
        var userContext = Services.GetRequiredService<FakeUserContext>();
        userContext.AddUser(userName);
        userContext.SetCurrentUser(userName);
        userContext.SetUserRoles(categoryName, modifier, roleNames ?? new AppRoleName[0]);
    }

    public Task<TResult> Execute(TModel model) =>
        Execute(model, ModifierKey.Default);

    public async Task<TResult> Execute(TModel model, ModifierKey modKey)
    {
        var appContext = Services.GetRequiredService<IAppContext>();
        var appApiFactory = Services.GetRequiredService<AppApiFactory>();
        var copiaApiForSuperUser = (CopiaAppApi)appApiFactory.CreateForSuperUser();
        var actionForSuperUser = getAction(copiaApiForSuperUser);
        var modKeyPath = modKey.Equals(ModifierKey.Default) ? "" : $"/{modKey.Value}";
        var appKey = Services.GetRequiredService<AppKey>();
        var userContext = Services.GetRequiredService<ISourceUserContext>();
        var pathAccessor = Services.GetRequiredService<FakeXtiPathAccessor>();
        var path = actionForSuperUser.Path.WithModifier(modKey ?? ModifierKey.Default);
        pathAccessor.SetPath(path);
        var currentUserName = Services.GetRequiredService<ICurrentUserName>();
        var currentUserAccess = new CurrentUserAccess(userContext, appContext, currentUserName);
        var apiUser = new AppApiUser(currentUserAccess, pathAccessor);
        var copiaApi = (CopiaAppApi)appApiFactory.Create(apiUser);
        var action = getAction(copiaApi);
        var result = await action.Invoke(model);
        return result;
    }
}