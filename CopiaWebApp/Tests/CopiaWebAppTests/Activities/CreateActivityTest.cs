using XTI_Copia.Abstractions;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests.Activities;

internal sealed class CreateActivityTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var sp = await TestActions.Setup();
        sp.Login();
        var portfolio = await TestActions.AddPortfolio(sp, "Portfolio 1");
        var tester = CopiaActionTester.Create(sp, api => api.Activities.CreateActivity);
        tester.ShouldRequireAccess
        (
            () => new CreateActivityRequest(activityName: ""),
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldCreateActivity()
    {
        var sp = await TestActions.Setup();
        sp.Login();
        var portfolio = await TestActions.AddPortfolio(sp, "My Portfolio");
        var activity = await TestActions.CreateActivity(sp, portfolio, "Withdrawal");
        Assert.That(activity.ID, Is.GreaterThan(0), "Should create activity");
        Assert.That(activity.ActivityName, Is.EqualTo("Withdrawal"), "Should create activity");
    }
}
