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

    public void LoginAsAdmin() => TestActions.LoginAsAdmin(Services);

    public void Login(params AppRoleName[]? roleNames) => TestActions.Login(Services, roleNames);

    public void Login(AppUserName userName, params AppRoleName[]? roleNames) => TestActions.Login(Services, userName, roleNames);

    public void Login(ModifierCategoryName categoryName, ModifierKey modifier, params AppRoleName[]? roleNames) => 
        TestActions.Login(Services, categoryName, modifier, roleNames);

    public void Login(AppUserName userName, ModifierCategoryName categoryName, ModifierKey modifier, params AppRoleName[]? roleNames) =>
        TestActions.Login(Services, userName, categoryName, modifier, roleNames);

    public Task<TResult> Execute(TModel model) =>
        Execute(model, ModifierKey.Default);

    public async Task<TResult> Execute(TModel model, ModifierKey modKey)
    {
        var appContext = Services.GetRequiredService<IAppContext>();
        var appApiFactory = Services.GetRequiredService<AppApiFactory>();
        var copiaApiForSuperUser = (CopiaAppApi)appApiFactory.CreateForSuperUser();
        var actionForSuperUser = getAction(copiaApiForSuperUser);
        var appKey = Services.GetRequiredService<AppKey>();
        var userContext = Services.GetRequiredService<ISourceUserContext>();
        var modKeyAccessor = Services.GetRequiredService<FakeModifierKeyAccessor>();
        modKeyAccessor.SetValue(modKey);
        var currentUserName = Services.GetRequiredService<ICurrentUserName>();
        var currentUserAccess = new CurrentUserAccess(userContext, appContext, currentUserName);
        var apiUser = new AppApiUser(currentUserAccess, modKeyAccessor);
        var copiaApi = (CopiaAppApi)appApiFactory.Create(apiUser);
        var action = getAction(copiaApi);
        var result = await action.Invoke(model);
        return result;
    }
}