using XTI_Copia.Abstractions;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests.Counterparties;

internal sealed class CounterpartySearchTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        tester.ShouldRequireAccess
        (
            () => "",
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldReturnAllCounterparties_WhenSearchTextIsEmptyString()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        foreach (var i in Enumerable.Range(1, 10))
        {
            await AddCounterparty(tester, portfolio, $"Counterparty {i:00}");
        }
        var searchResult = await tester.Execute("", portfolio.PublicKey);
        Assert.That
        (
            searchResult.Counterparties.Select(c => c.DisplayText),
            Is.EqualTo(Enumerable.Range(1, 10).Select(i => $"Counterparty {i:00}"))
        );
    }

    [Test]
    public async Task ShouldReturnAllCounterpartiesThatStartWithTheSearchText()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        foreach (var i in Enumerable.Range(1, 10))
        {
            await AddCounterparty(tester, portfolio, $"First {i:00}");
        }
        foreach (var i in Enumerable.Range(1, 10))
        {
            await AddCounterparty(tester, portfolio, $"Second {i:00}");
        }
        var searchResult = await tester.Execute("Second", portfolio.PublicKey);
        Assert.That
        (
            searchResult.Counterparties.Select(c => c.DisplayText),
            Is.EqualTo(Enumerable.Range(1, 10).Select(i => $"Second {i:00}"))
        );
    }

    [Test]
    public async Task CounterpartySearchShouldBeCaseInsensitive()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        foreach (var i in Enumerable.Range(1, 10))
        {
            await AddCounterparty(tester, portfolio, $"First {i:00}");
        }
        foreach (var i in Enumerable.Range(1, 10))
        {
            await AddCounterparty(tester, portfolio, $"Second {i:00}");
        }
        var searchResult = await tester.Execute("SeConD", portfolio.PublicKey);
        Assert.That
        (
            searchResult.Counterparties.Select(c => c.DisplayText),
            Is.EqualTo(Enumerable.Range(1, 10).Select(i => $"Second {i:00}"))
        );
    }

    [Test]
    public async Task ShouldNotReturnMoreThan50Results()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        foreach (var i in Enumerable.Range(1, 60))
        {
            await AddCounterparty(tester, portfolio, $"Counterparty {i:00}");
        }
        var searchResult = await tester.Execute("", portfolio.PublicKey);
        Assert.That
        (
            searchResult.Counterparties.Select(c => c.DisplayText),
            Is.EqualTo(Enumerable.Range(1, 50).Select(i => $"Counterparty {i:00}"))
        );
    }

    [Test]
    public async Task ShouldReturnSearchTotal()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        foreach (var i in Enumerable.Range(1, 60))
        {
            await AddCounterparty(tester, portfolio, $"Counterparty {i:00}");
        }
        var searchResult = await tester.Execute("", portfolio.PublicKey);
        Assert.That
        (
            searchResult.Total,
            Is.EqualTo(60)
        );
    }

    private async Task<CopiaActionTester<string, CounterpartySearchResult>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Counterparties.CounterpartySearch);
    }

    private Task<PortfolioModel> AddPortfolio(ICopiaActionTester tester)
    {
        var addTester = tester.Create(api => api.Portfolios.AddPortfolio);
        return addTester.Execute(new AddPortfolioRequest { PortfolioName = "My Portfolio" });
    }

    private Task<CounterpartyModel> AddCounterparty(ICopiaActionTester tester, PortfolioModel portfolio, string displayText)
    {
        var addTester = tester.Create(api => api.Counterparties.AddCounterparty);
        var addForm = new AddCounterpartyForm();
        addForm.DisplayText.SetValue(displayText);
        addForm.Url.SetValue("");
        return addTester.Execute(addForm, portfolio.PublicKey);
    }
}
