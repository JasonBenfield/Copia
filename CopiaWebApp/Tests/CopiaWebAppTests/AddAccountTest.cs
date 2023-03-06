using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaDB;
using XTI_CopiaWebAppApi;
using XTI_Forms;

namespace CopiaWebAppTests;

internal sealed class AddAccountTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var attemptIndex = 1;
        tester.ShouldRequireAccess
        (
            () =>
            {
                var addForm = new AddAccountForm();
                addForm.AccountName.SetValue($"Test Account {attemptIndex}");
                addForm.AccountType.SetValue(AccountType.Values.Checking);
                attemptIndex++;
                return addForm;
            },
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldRequireAccountName()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var addForm = new AddAccountForm();
        addForm.AccountName.SetValue("");
        addForm.AccountType.SetValue(AccountType.Values.Checking);
        var ex = Assert.ThrowsAsync<ValidationFailedException>(() => tester.Execute(addForm, portfolio.PublicKey));
        Assert.That
        (
            ex.Errors.Select(e => new { e.Message, e.Source }).ToArray(),
            Is.EqualTo(new[] { new { Message = FormErrors.MustNotBeNullOrWhitespace, Source = "AddAccountForm_AccountName" } })
        );
    }

    [Test]
    public async Task ShouldRequireAccountType()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var addForm = new AddAccountForm();
        addForm.AccountName.SetValue("Test Account");
        addForm.AccountType.SetValue(AccountType.Values.NotSet);
        var ex = Assert.ThrowsAsync<ValidationFailedException>(() => tester.Execute(addForm, portfolio.PublicKey));
        Assert.That
        (
            ex.Errors.Select(e => e.Message).ToArray(),
            Is.EqualTo(new[] { ValidationErrors.AccountTypeIsRequired })
        );
    }

    [Test]
    public async Task ShouldAddAccount()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var addForm = new AddAccountForm();
        addForm.AccountName.SetValue("Test Account");
        addForm.AccountType.SetValue(AccountType.Values.Checking);
        await tester.Execute(addForm, portfolio.PublicKey);
        var db = tester.Services.GetRequiredService<CopiaDbContext>();
        var accounts = await db.Accounts.Retrieve().ToArrayAsync();
        Assert.That
        (
            accounts.Select(a => new { a.AccountName, a.AccountType }).ToArray(),
            Is.EqualTo(new[] { new { AccountName = "Test Account", AccountType = AccountType.Values.Checking.Value } }),
            "Should add account"
        );
    }

    [Test]
    public async Task ShouldReturnAccount()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var addForm = new AddAccountForm();
        addForm.AccountName.SetValue("Test Account");
        addForm.AccountType.SetValue(AccountType.Values.Checking);
        var addedAccount = await tester.Execute(addForm, portfolio.PublicKey);
        var db = tester.Services.GetRequiredService<CopiaDbContext>();
        var accountEntity = await db.Accounts.Retrieve()
            .Where(a => a.AccountName == addForm.AccountName.Value())
            .FirstAsync();
        Assert.That
        (
            addedAccount,
            Is.EqualTo
            (
                new AccountModel
                (
                    accountEntity.ID, 
                    accountEntity.AccountName, 
                    AccountType.Values.Value(accountEntity.AccountType)
                )
            ),
            "Should return account"
        );
    }

    private async Task<CopiaActionTester<AddAccountForm, AccountModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Portfolio.AddAccount);
    }

    private Task<PortfolioModel> AddPortfolio(ICopiaActionTester tester)
    {
        var addTester = tester.Create(api => api.Portfolios.AddPortfolio);
        return addTester.Execute(new AddPortfolioRequest { PortfolioName = "My Portfolio" });
    }

}