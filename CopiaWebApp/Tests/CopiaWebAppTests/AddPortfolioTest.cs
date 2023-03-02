using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace CopiaWebAppTests;

internal sealed class AddPortfolioTest
{
    [Test]
    public async Task ShouldAddPortfolio()
    {
        var tester = await Setup();
        tester.Login();
        var addRequest = new AddPortfolioRequest { PortfolioName = "My Portfolio" };
        await tester.Execute(addRequest);
        var db = tester.Services.GetRequiredService<CopiaDbContext>();
        var portfolios = await db.Portfolios.Retrieve().ToArrayAsync();
        Assert.That
        (
            portfolios.Select(p => p.PortfolioName).ToArray(),
            Is.EquivalentTo(new[] { addRequest.PortfolioName }),
            "Should add portfolio"
        );
    }

    [Test]
    public async Task ShouldReturnPortfolio()
    {
        var tester = await Setup();
        tester.Login();
        var addRequest = new AddPortfolioRequest { PortfolioName = "My Portfolio" };
        var portfolio = await tester.Execute(addRequest);
        Assert.That
        (
            portfolio.PortfolioName,
            Is.EqualTo(addRequest.PortfolioName),
            "Should return portfolio"
        );
    }

    private async Task<CopiaActionTester<AddPortfolioRequest, PortfolioModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Portfolios.AddPortfolio);
    }
}