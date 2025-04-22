using Microsoft.Extensions.DependencyInjection;
using XTI_App.Abstractions;
using XTI_App.Fakes;
using XTI_Copia.Abstractions;

namespace CopiaWebAppTests;

internal static class TestActions
{
    internal static Task<IServiceProvider> Setup(string envName = "Test")
    {
        var host = new CopiaTestHost();
        return host.Setup(envName);
    }

    internal static void LoginAsAdmin(this IServiceProvider sp)
    {
        var currentUserName = sp.GetRequiredService<FakeCurrentUserName>();
        currentUserName.SetUserName(new AppUserName("admin.user"));
    }

    internal static void Login(this IServiceProvider sp, params AppRoleName[]? roleNames) =>
        sp.Login(new AppUserName("loggedInUser"), roleNames);

    internal static void Login(this IServiceProvider sp, AppUserName userName, params AppRoleName[]? roleNames) =>
        sp.Login(userName, ModifierCategoryName.Default, ModifierKey.Default, roleNames);

    internal static void Login(this IServiceProvider sp, ModifierCategoryName categoryName, ModifierKey modifier, params AppRoleName[]? roleNames) =>
        sp.Login(new AppUserName("loggedInUser"), categoryName, modifier, roleNames);

    internal static void Login(this IServiceProvider sp, AppUserName userName, ModifierCategoryName categoryName, ModifierKey modifier, params AppRoleName[]? roleNames)
    {
        var userContext = sp.GetRequiredService<FakeUserContext>();
        userContext.AddUser(userName);
        userContext.SetCurrentUser(userName);
        userContext.SetUserRoles(categoryName, modifier, roleNames ?? []);
    }

    internal static Task<PortfolioModel> AddPortfolio(IServiceProvider sp, string portfolioName = "Portfolio")
    {
        var tester = CopiaActionTester.Create(sp, api => api.Portfolios.AddPortfolio);
        return tester.Execute(new AddPortfolioRequest(portfolioName: portfolioName));
    }

    internal static Task<ActivityModel> CreateActivity(IServiceProvider sp, PortfolioModel portfolio, string activityName)
    {
        var tester = CopiaActionTester.Create(sp, api => api.Activities.CreateActivity);
        return tester.Execute(new CreateActivityRequest(activityName: activityName), portfolio.PublicKey);
    }
}
