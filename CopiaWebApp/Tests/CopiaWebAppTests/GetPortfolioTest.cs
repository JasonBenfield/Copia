using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal sealed class GetPortfolioTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        tester.ShouldRequireAccess
        (
            () => new EmptyRequest(),
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldDenyAccessToAnotherPortfolio()
    {
        var tester = await Setup();
        tester.Login(new AppUserName("User 1"));
        var portfolio1 = await AddPortfolio(tester, "Portfolio 1");
        tester.Login(new AppUserName("User 2"));
        await AddPortfolio(tester, "Portfolio 2");
        Assert.ThrowsAsync<AccessDeniedException>
        (
            () => tester.Execute(new EmptyRequest(), portfolio1.PublicKey)
        );
    }

    [Test]
    public async Task ShouldGetPortfolio()
    {
        var tester = await Setup();
        tester.Login();
        var addedPortfolio = await AddPortfolio(tester, "My Portfolio");
        var portfolio = await tester.Execute(new EmptyRequest(), addedPortfolio.PublicKey);
        Assert.That
        (
            portfolio,
            Is.EqualTo(addedPortfolio),
            "Should get portfolio"
        );
    }

    private async Task<CopiaActionTester<EmptyRequest, PortfolioModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Portfolio.GetPortfolio);
    }

    private Task<PortfolioModel> AddPortfolio(ICopiaActionTester tester, string portfolioName)
    {
        var addTester = tester.Create(api => api.Portfolios.AddPortfolio);
        return addTester.Execute(new AddPortfolioRequest { PortfolioName = portfolioName });
    }
}
