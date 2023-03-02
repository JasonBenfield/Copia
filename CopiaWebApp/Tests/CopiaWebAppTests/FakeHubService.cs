using XTI_App.Abstractions;
using XTI_App.Fakes;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal sealed class FakeHubService : IHubService
{
    private readonly FakeAppContext appContext;
    private readonly FakeUserContext userContext;

    public FakeHubService(FakeAppContext appContext, FakeUserContext userContext)
    {
        this.appContext = appContext;
        this.userContext = userContext;
    }

    public Task AddModifier(ModifierCategoryName categoryName, ModifierKey modKey, string targetKey, string displayText, CancellationToken ct)
    {
        var app = appContext.GetCurrentApp();
        appContext.AddModifier
        (
            app,
            CopiaInfo.ModCategories.Portfolio,
            modKey,
            targetKey
        );
        return Task.CompletedTask;
    }

    public Task AssignRoleToUser(AppUserName userName, ModifierCategoryName categoryName, ModifierKey modKey, AppRoleName roleName, CancellationToken ct)
    {
        userContext.AddRolesToUser(categoryName, modKey, roleName);
        return Task.CompletedTask;
    }
}
