using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests.Counterparties;

internal sealed class DeleteCounterpartyTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var counterparty = await AddCounterparty(tester, portfolio, "Counterparty 1");
        tester.ShouldRequireAccess
        (
            () => counterparty.ID,
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldDeleteCounterparty()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var counterparty = await AddCounterparty(tester, portfolio, "Counterparty 1");
        await tester.Execute(counterparty.ID, portfolio.PublicKey);
        var searchTester = tester.Create(api => api.Counterparties.CounterpartySearch);
        var searchResult = await searchTester.Execute("Counterparty 1", portfolio.PublicKey);
        Assert.That
        (
            searchResult.Counterparties.Length,
            Is.EqualTo(0),
            "Should delete counterparty"
        );
    }

    private async Task<CopiaActionTester<int, EmptyActionResult>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Counterparties.DeleteCounterparty);
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
