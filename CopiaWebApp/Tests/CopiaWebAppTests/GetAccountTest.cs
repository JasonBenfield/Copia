using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaDB.EF;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal sealed class GetAccountTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        var addedAccount = await AddAccount(tester, portfolio, "Account 1");
        tester.ShouldRequireAccess
        (
            () => new GetAccountRequest(addedAccount.ID),
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldNotAllowAccessToDifferentPortfolio()
    {
        var tester = await Setup();
        tester.Login(new AppUserName("User 1"));
        var portfolio1 = await AddPortfolio(tester, "Portfolio 1");
        var addedAccount1 = await AddAccount(tester, portfolio1, "Account 1");
        tester.Login(new AppUserName("User 2"));
        var portfolio2 = await AddPortfolio(tester, "Portfolio 2");
        var addedAccount2 = await AddAccount(tester, portfolio2, "Account 1");
        Assert.ThrowsAsync<AccessDeniedException>
        (
            () => tester.Execute(new GetAccountRequest(addedAccount1.ID), portfolio1.PublicKey)
        );
    }

    [Test]
    public async Task ShouldGetAccount()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "My Portfolio");
        await AddAccount(tester, portfolio, "Account 1");
        var addedAccount = await AddAccount(tester, portfolio, "Account 2");
        var account = await tester.Execute(new GetAccountRequest(addedAccount.ID), portfolio.PublicKey);
        Assert.That
        (
            account,
            Is.EqualTo(addedAccount),
            "Should get account"
        );
    }

    [Test]
    public async Task ShouldThrowError_WhenAccountDoesNotBelongToPortfolio()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio1 = await AddPortfolio(tester, "My Portfolio 1");
        await AddAccount(tester, portfolio1, "Account 1");
        await AddAccount(tester, portfolio1, "Account 2");
        var portfolio2 = await AddPortfolio(tester, "My Portfolio 2");
        var addedAccount = await AddAccount(tester, portfolio2, "Account 3");
        var ex = Assert.ThrowsAsync<Exception>
        (
            () => tester.Execute(new GetAccountRequest(addedAccount.ID), portfolio1.PublicKey)
        );
        Assert.That
        (
            ex.Message,
            Is.EqualTo(string.Format(CopiaDBErrors.AccountDoesNotBelongToPortfolio, addedAccount.ID, portfolio1.ID)),
            "Should throw error when account does not belong to portfolio"
        );
    }

    private async Task<CopiaActionTester<GetAccountRequest, AccountModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Account.GetAccount);
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
