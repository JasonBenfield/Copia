using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaDB;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal sealed class AddPortfolioTest
{
    [Test]
    public async Task ShouldRequiredPortfolioName()
    {
        var tester = await Setup();
        tester.Login();
        var addRequest = new AddPortfolioRequest { PortfolioName = "" };
        var ex = Assert.ThrowsAsync<ValidationFailedException>(() => tester.Execute(addRequest));
        Assert.That
        (
            ex.Errors.Select(e => e.Message).ToArray(),
            Is.EqualTo(new[] { ValidationErrors.PortfolioNameIsRequired })
        );
    }

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

    [Test]
    public async Task ShouldAddBlankCounterparty()
    {
        var tester = await Setup();
        tester.Login();
        var addRequest = new AddPortfolioRequest { PortfolioName = "My Portfolio" };
        var portfolio = await tester.Execute(addRequest);
        var db = tester.Services.GetRequiredService<CopiaDbContext>();
        var defaultCounterparty = await db.Counterparties.Retrieve()
            .Where(c => c.PortfolioID == portfolio.ID && c.DisplayText == "")
            .FirstOrDefaultAsync();
        Assert.That
        (
            defaultCounterparty,
            Is.Not.Null,
            "Should add blank counterparty to Portfolio"
        );
    }

    private async Task<CopiaActionTester<AddPortfolioRequest, PortfolioModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Portfolios.AddPortfolio);
    }
}