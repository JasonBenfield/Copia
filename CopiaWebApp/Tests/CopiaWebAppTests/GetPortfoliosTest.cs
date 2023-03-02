using XTI_App.Abstractions;
using XTI_Copia.Abstractions;

namespace CopiaWebAppTests;

internal sealed class GetPortfoliosTest
{
    [Test]
    public async Task ShouldGetPortfolio()
    {
        var tester = await Setup();
        tester.Login();
        const string portfolioName = "My Portfolio";
        await AddPortfolio(tester, portfolioName);
        var portfolios = await tester.Execute(new EmptyRequest());
        Assert.That
        (
            portfolios.Select(p => p.PortfolioName).ToArray(),
            Is.EquivalentTo(new[] { portfolioName }),
            "Should get portfolio"
        );
    }

    [Test]
    public async Task ShouldNotGetPortfolioAddedByAnotherUser()
    {
        var tester = await Setup();
        tester.Login(new AppUserName("user1"));
        const string portfolioName1 = "My Portfolio 1";
        await AddPortfolio(tester, portfolioName1);
        tester.Login(new AppUserName("user2"));
        const string portfolioName2 = "My Portfolio 2";
        await AddPortfolio(tester, portfolioName2);
        var portfolios = await tester.Execute(new EmptyRequest());
        Assert.That
        (
            portfolios.Select(p => p.PortfolioName).ToArray(),
            Is.EquivalentTo(new[] { portfolioName2 }),
            "Should not get portfolio added by another user"
        );
    }

    private async Task<CopiaActionTester<EmptyRequest, PortfolioModel[]>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Portfolios.GetPortfolios);
    }

    private Task<PortfolioModel> AddPortfolio(ICopiaActionTester tester, string portfolioName)
    {
        var addTester = tester.Create(api => api.Portfolios.AddPortfolio);
        return addTester.Execute
        (
            new AddPortfolioRequest
            {
                PortfolioName = portfolioName
            }
        );
    }
}