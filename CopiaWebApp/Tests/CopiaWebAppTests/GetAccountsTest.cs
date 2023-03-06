using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal sealed class GetAccountsTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        await AddAccount(tester, portfolio, "Account 1");
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
    public async Task ShouldGetAccounts()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "My Portfolio");
        await AddAccount(tester, portfolio, "Account 1");
        await AddAccount(tester, portfolio, "Account 2");
        var accounts = await tester.Execute(new EmptyRequest(), portfolio.PublicKey);
        Assert.That
        (
            accounts.Select(a => a.AccountName),
            Is.EqualTo(new[] { "Account 1", "Account 2" }),
            "Should get accounts"
        );
    }

    [Test]
    public async Task ShouldGetAccountsForThePortfolioToWhichTheyWereAdded()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio1 = await AddPortfolio(tester, "My Portfolio 1");
        await AddAccount(tester, portfolio1, "Account 1");
        await AddAccount(tester, portfolio1, "Account 2");
        var portfolio2 = await AddPortfolio(tester, "My Portfolio 2");
        await AddAccount(tester, portfolio2, "Account 3");
        var accounts = await tester.Execute(new EmptyRequest(), portfolio1.PublicKey);
        Assert.That
        (
            accounts.Select(a => a.AccountName),
            Is.EqualTo(new[] { "Account 1", "Account 2" }),
            "Should get accounts for the portfolio to which they were added"
        );
    }

    private async Task<CopiaActionTester<EmptyRequest, AccountModel[]>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Portfolio.GetAccounts);
    }

    private Task<PortfolioModel> AddPortfolio(ICopiaActionTester tester, string portfolioName)
    {
        var addTester = tester.Create(api => api.Portfolios.AddPortfolio);
        return addTester.Execute(new AddPortfolioRequest { PortfolioName = portfolioName });
    }

    private Task<AccountModel> AddAccount(ICopiaActionTester tester, PortfolioModel portfolio, string accountName)
    {
        var addTester = tester.Create(api => api.Portfolio.AddAccount);
        var addForm = new AddAccountForm();
        addForm.AccountName.SetValue(accountName);
        addForm.AccountType.SetValue(AccountType.Values.Checking);
        return addTester.Execute(addForm, portfolio.PublicKey);
    }

}
