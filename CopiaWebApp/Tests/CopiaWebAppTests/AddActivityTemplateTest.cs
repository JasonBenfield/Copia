using Microsoft.Extensions.DependencyInjection;
using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaDB;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal sealed class AddActivityTemplateTest
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
                var addRequest = new AddActivityTemplateRequest($"Template {attemptIndex}");
                attemptIndex++;
                return addRequest;
            },
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldRequireTemplateName()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var addRequest = new AddActivityTemplateRequest("");
        var ex = Assert.ThrowsAsync<ValidationFailedException>(() => tester.Execute(addRequest, portfolio.PublicKey));
        Assert.That
        (
            ex.Errors.Select(e => e.Message).ToArray(),
            Is.EqualTo(new[] { ValidationErrors.ActivityTemplateNameIsRequired })
        );
    }

    [Test]
    public async Task ShouldAddActivityTemplate()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        await tester.Execute(new AddActivityTemplateRequest("Withdrawal"), portfolio.PublicKey);
        var db = tester.Services.GetRequiredService<CopiaDbContext>();
        var templates = db.ActivityTemplates.Retrieve();
        Assert.That
        (
            templates.Select(templ => templ.TemplateName).ToArray(),
            Is.EqualTo(new[] { "Withdrawal" }),
            "Should add activity template"
        );
    }

    [Test]
    public async Task ShouldReturnNewActivityTemplate()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var activityTemplateDetail = await tester.Execute(new AddActivityTemplateRequest("Withdrawal"), portfolio.PublicKey);
        Assert.That(activityTemplateDetail.Template.TemplateName, Is.EqualTo("Withdrawal"), "Should return new activity template");
    }

    [Test]
    public async Task ShouldAddFieldsForEachFieldType()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var activityTemplateDetail = await tester.Execute(new AddActivityTemplateRequest("Withdrawal"), portfolio.PublicKey);
        Assert.That
        (
            activityTemplateDetail.TemplateFields.Select(tf => tf.FieldType).ToArray(),
            Is.EquivalentTo
            (
                new[]
                {
                    ActivityFieldType.Values.Amount,
                    ActivityFieldType.Values.Counterparty,
                    ActivityFieldType.Values.TimeOccurred
                }
            ),
            "Should add template fields"
        );
    }

    [Test]
    public async Task ShouldAddActivityNameTemplateString()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester);
        var activityTemplateDetail = await tester.Execute(new AddActivityTemplateRequest("Withdrawal"), portfolio.PublicKey);
        Assert.That(activityTemplateDetail.ActivityName.ID, Is.GreaterThan(0), "Should add activity name template string");
        Assert.That(activityTemplateDetail.ActivityName.DataType, Is.EqualTo(TemplateStringDataType.Values.String), "Should add activity name template string");
        Assert.That(activityTemplateDetail.ActivityName.CanEdit, Is.True, "Should add activity name template string");
        Assert.That(activityTemplateDetail.ActivityName.Parts.Length, Is.EqualTo(0), "Should add activity name template string");
    }

    private async Task<CopiaActionTester<AddActivityTemplateRequest, ActivityTemplateDetailModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.ActivityTemplates.AddActivityTemplate);
    }

    private Task<PortfolioModel> AddPortfolio(ICopiaActionTester tester)
    {
        var addTester = tester.Create(api => api.Portfolios.AddPortfolio);
        return addTester.Execute(new AddPortfolioRequest { PortfolioName = "My Portfolio" });
    }
}
