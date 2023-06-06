using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaDB;
using XTI_CopiaDB.EF;
using XTI_CopiaWebAppApi;
using XTI_Forms;

namespace CopiaWebAppTests.Counterparties;

internal sealed class EditCounterpartyTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var counterparty = await AddCounterparty(tester, portfolio, "Counterparty 1");
        var attemptIndex = 1;
        tester.ShouldRequireAccess
        (
            () =>
            {
                var editForm = new EditCounterpartyForm();
                editForm.CounterpartyID.SetValue(counterparty.ID);
                editForm.DisplayText.SetValue("Counterparty 1");
                editForm.Url.SetValue("");
                attemptIndex++;
                return editForm;
            },
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldRequireCounterpartyID()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var counterparty = await AddCounterparty(tester, portfolio, "Counterparty 1");
        var editForm = new EditCounterpartyForm();
        editForm.CounterpartyID.SetValue(0);
        editForm.DisplayText.SetValue("Change 1");
        editForm.Url.SetValue("example.com");
        var ex = Assert.ThrowsAsync<ValidationFailedException>
        (
            () => tester.Execute
            (
                editForm,
                portfolio.PublicKey
            )
        );
        Assert.That
        (
            ex.Errors.Select(e => new { e.Message, e.Source }).ToArray(),
            Is.EqualTo(new[] { new { Message = string.Format(FormErrors.LowerRangeExclusive, 0), Source = "EditCounterpartyForm_CounterpartyID" } })
        );
    }

    [Test]
    public async Task ShouldRequireDisplayText()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var counterparty = await AddCounterparty(tester, portfolio, "Counterparty 1");
        var editForm = new EditCounterpartyForm();
        editForm.CounterpartyID.SetValue(counterparty.ID);
        editForm.DisplayText.SetValue("");
        editForm.Url.SetValue("https://example.com");
        var ex = Assert.ThrowsAsync<ValidationFailedException>
        (
            () => tester.Execute
            (
                editForm,
                portfolio.PublicKey
            )
        );
        Assert.That
        (
            ex.Errors.Select(e => new { e.Message, e.Source }).ToArray(),
            Is.EqualTo(new[] { new { Message = FormErrors.MustNotBeNullOrWhitespace, Source = "EditCounterpartyForm_DisplayText" } })
        );
    }

    [Test]
    public async Task ShouldNotAllowDuplicateDisplayText()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var counterparty1 = await AddCounterparty(tester, portfolio, "Counterparty 1");
        await AddCounterparty(tester, portfolio, "Counterparty 2");
        var editForm = new EditCounterpartyForm();
        editForm.CounterpartyID.SetValue(counterparty1.ID);
        editForm.DisplayText.SetValue("Counterparty 2");
        editForm.Url.SetValue("https://example.com");
        var ex = Assert.ThrowsAsync<AppException>
        (
            () => tester.Execute
            (
                editForm,
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
    public async Task ShouldEditCounterpartyDisplayText()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var counterparty = await AddCounterparty(tester, portfolio, "Counterparty 1");
        var editForm = new EditCounterpartyForm();
        editForm.CounterpartyID.SetValue(counterparty.ID);
        editForm.DisplayText.SetValue("Change 1");
        editForm.Url.SetValue(counterparty.Url);
        await tester.Execute(editForm, portfolio.PublicKey);
        var db = tester.Services.GetRequiredService<CopiaDbContext>();
        var updatedCounterparty = await db.Counterparties.Retrieve()
            .Where(c=>c.ID == counterparty.ID)
            .FirstOrDefaultAsync();
        Assert.That
        (
            updatedCounterparty?.DisplayText,
            Is.EqualTo("Change 1"),
            "Should edit counterparty Display Text"
        );
    }

    [Test]
    public async Task ShouldEditCounterpartyUrl()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var counterparty = await AddCounterparty(tester, portfolio, "Counterparty 1");
        var editForm = new EditCounterpartyForm();
        editForm.CounterpartyID.SetValue(counterparty.ID);
        editForm.DisplayText.SetValue(counterparty.DisplayText);
        editForm.Url.SetValue("https://google.com");
        await tester.Execute(editForm, portfolio.PublicKey);
        var db = tester.Services.GetRequiredService<CopiaDbContext>();
        var updatedCounterparty = await db.Counterparties.Retrieve()
            .Where(c => c.ID == counterparty.ID)
            .FirstOrDefaultAsync();
        Assert.That
        (
            updatedCounterparty?.Url,
            Is.EqualTo("https://google.com"),
            "Should edit counterparty URL"
        );
    }

    [Test]
    public async Task ShouldReturnUpdatedCounterparty()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var counterparty = await AddCounterparty(tester, portfolio, "Counterparty 1");
        var editForm = new EditCounterpartyForm();
        editForm.CounterpartyID.SetValue(counterparty.ID);
        editForm.DisplayText.SetValue("Change 1");
        editForm.Url.SetValue("https://google.com");
        var updatedCounterparty = await tester.Execute(editForm, portfolio.PublicKey);
        Assert.That
        (
            new { updatedCounterparty.DisplayText, updatedCounterparty.Url },
            Is.EqualTo(new { DisplayText = "Change 1", Url = "https://google.com" }),
            "Should return updated counterparty"
        );
    }

    private async Task<CopiaActionTester<EditCounterpartyForm, CounterpartyModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Counterparties.EditCounterparty);
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
