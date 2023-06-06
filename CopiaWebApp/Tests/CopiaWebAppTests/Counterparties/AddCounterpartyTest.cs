using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaDB;
using XTI_CopiaWebAppApi;
using XTI_Forms;

namespace CopiaWebAppTests.Counterparties;

internal sealed class AddCounterpartyTest
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
                var addForm = new AddCounterpartyForm();
                addForm.DisplayText.SetValue($"Counterparty {attemptIndex}");
                addForm.Url.SetValue("");
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
    public async Task ShouldRequireDisplayText()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var addForm = new AddCounterpartyForm();
        addForm.DisplayText.SetValue("");
        addForm.Url.SetValue("https://example.com");
        var ex = Assert.ThrowsAsync<ValidationFailedException>
        (
            () => tester.Execute
            (
                addForm,
                portfolio.PublicKey
            )
        );
        Assert.That
        (
            ex.Errors.Select(e => new { e.Message, e.Source }).ToArray(),
            Is.EqualTo(new[] { new { Message = FormErrors.MustNotBeNullOrWhitespace, Source = "AddCounterpartyForm_DisplayText" } })
        );
    }

    [Test]
    public async Task ShouldNotAllowDuplicateDisplayText()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var addForm = new AddCounterpartyForm();
        addForm.DisplayText.SetValue("Counterparty 1");
        addForm.Url.SetValue("https://example.com");
        await tester.Execute(addForm, portfolio.PublicKey);
        var ex = Assert.ThrowsAsync<AppException>
        (
            () => tester.Execute
            (
                addForm,
                portfolio.PublicKey
            )
        );
        Assert.That
        (
            ex.DisplayMessage,
            Is.EqualTo(ValidationErrors.CounterpartyAlreadyExists)
        );
    }

    [Test]
    public async Task ShouldAddCounterparty()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var addForm = new AddCounterpartyForm();
        addForm.DisplayText.SetValue("Counterparty 1");
        addForm.Url.SetValue("https://example.com");
        await tester.Execute(addForm, portfolio.PublicKey);
        var db = tester.Services.GetRequiredService<CopiaDbContext>();
        var counterparties = await db.Counterparties.Retrieve()
            .Where(c => !string.IsNullOrWhiteSpace(c.DisplayText))
            .ToArrayAsync();
        Assert.That
        (
            counterparties.Select(c => new { c.DisplayText, c.Url }).ToArray(),
            Is.EqualTo(new[] { new { DisplayText = "Counterparty 1", Url = "https://example.com" } }),
            "Should add counterparty"
        );
    }

    [Test]
    public async Task ShouldReturnNewCounterparty()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var addForm = new AddCounterpartyForm();
        addForm.DisplayText.SetValue("Counterparty 1");
        addForm.Url.SetValue("https://example.com");
        var counterparty = await tester.Execute(addForm, portfolio.PublicKey);
        Assert.That
        (
            new { counterparty.DisplayText, counterparty.Url },
            Is.EqualTo(new { DisplayText = "Counterparty 1", Url = "https://example.com" }),
            "Should return new counterparty"
        );
    }

    private async Task<CopiaActionTester<AddCounterpartyForm, CounterpartyModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Counterparties.AddCounterparty);
    }

    private Task<PortfolioModel> AddPortfolio(ICopiaActionTester tester)
    {
        var addTester = tester.Create(api => api.Portfolios.AddPortfolio);
        return addTester.Execute(new AddPortfolioRequest { PortfolioName = "My Portfolio" });
    }
}
