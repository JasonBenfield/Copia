using Microsoft.Extensions.DependencyInjection;
using XTI_App.Abstractions;
using XTI_App.Fakes;

namespace CopiaWebAppTests;

internal static class AccessAssertions
{
    public static void ShouldRequireAccess<TModel, TResult>(this CopiaActionTester<TModel, TResult> tester, Func<TModel> createModel, ModifierCategoryName modCategoryName, ModifierKey modKey, params AppRoleName[] allowedRoleNames)
    {
        foreach (var allowedRoleName in allowedRoleNames)
        {
            tester.Login
            (
                new AppUserName(allowedRoleName.DisplayText),
                modCategoryName,
                modKey,
                allowedRoleName
            );
            var model = createModel(); 
            Assert.DoesNotThrowAsync(() => tester.Execute(model, modKey));
        }
        var appContext = tester.Services.GetRequiredService<FakeAppContext>();
        var appContextModel = appContext.GetCurrentApp();
        var deniedRoleNames = appContextModel.Roles.Select(r => r.Name).Except(allowedRoleNames).ToArray();
        foreach(var deniedRoleName in deniedRoleNames)
        {
            tester.Login
            (
                new AppUserName(deniedRoleName.DisplayText),
                modCategoryName,
                modKey,
                deniedRoleName
            );
            var model = createModel();
            Assert.ThrowsAsync<AccessDeniedException>(() => tester.Execute(model, modKey));
        }
    }
}
