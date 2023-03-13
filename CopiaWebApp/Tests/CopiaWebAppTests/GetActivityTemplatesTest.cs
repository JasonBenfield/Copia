using XTI_App.Abstractions;
using XTI_Copia.Abstractions;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal sealed class GetActivityTemplatesTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        await AddActivityTemplate(tester, portfolio, "Withdrawal");
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
    public async Task ShouldGetActivityTemplates()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "My Portfolio");
        await AddActivityTemplate(tester, portfolio, "Withdrawal");
        await AddActivityTemplate(tester, portfolio, "Deposit");
        var activityTemplates = await tester.Execute(new EmptyRequest(), portfolio.PublicKey);
        Assert.That
        (
            activityTemplates.Select(a => a.TemplateName),
            Is.EqualTo(new[] { "Withdrawal", "Deposit" }),
            "Should get activity templates"
        );
    }

    [Test]
    public async Task ShouldGetActivityTemplatesForThePortfolioToWhichTheyWereAdded()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio1 = await AddPortfolio(tester, "My Portfolio 1");
        await AddActivityTemplate(tester, portfolio1, "Withdrawal");
        await AddActivityTemplate(tester, portfolio1, "Deposit");
        var portfolio2 = await AddPortfolio(tester, "My Portfolio 2");
        await AddActivityTemplate(tester, portfolio2, "Transfer");
        var activityTemplates = await tester.Execute(new EmptyRequest(), portfolio1.PublicKey);
        Assert.That
        (
            activityTemplates.Select(a => a.TemplateName),
            Is.EqualTo(new[] { "Withdrawal", "Deposit" }),
            "Should get activity templates for the portfolio to which they were added"
        );
    }

    private async Task<CopiaActionTester<EmptyRequest, ActivityTemplateModel[]>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.ActivityTemplates.GetActivityTemplates);
    }

    private Task<PortfolioModel> AddPortfolio(ICopiaActionTester tester, string portfolioName)
    {
        var addTester = tester.Create(api => api.Portfolios.AddPortfolio);
        return addTester.Execute(new AddPortfolioRequest { PortfolioName = portfolioName });
    }

    private Task<ActivityTemplateDetailModel> AddActivityTemplate(ICopiaActionTester tester, PortfolioModel portfolio, string templateName)
    {
        var addTester = tester.Create(api => api.ActivityTemplates.AddActivityTemplate);
        var addRequest = new AddActivityTemplateRequest(templateName);
        return addTester.Execute(addRequest, portfolio.PublicKey);
    }

}
