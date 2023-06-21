using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XTI_Copia.Abstractions;
using XTI_CopiaDB;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests.Activities;

internal sealed class CreateActivityTest
{
    [Test]
    public async Task ShouldRequireAccess()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        var activityTemplate = await AddActivityTemplate(tester, portfolio, "Withdrawal");
        tester.ShouldRequireAccess
        (
            () => new CreateActivityRequest(activityTemplateID: activityTemplate.Template.ID),
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldCreateActivity()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "My Portfolio");
        var activityTemplate = await AddActivityTemplate(tester, portfolio, "Withdrawal");
        await tester.Execute
        (
            new CreateActivityRequest(activityTemplateID: activityTemplate.Template.ID),
            portfolio.PublicKey
        );
        var db = tester.Services.GetRequiredService<CopiaDbContext>();
        var activityEntity = await db.Activities.Retrieve()
            .FirstOrDefaultAsync(a => a.ActivityTemplateID == activityTemplate.Template.ID);
        Assert.That(activityEntity, Is.Not.Null, "Should create activity");
    }

    private async Task<CopiaActionTester<CreateActivityRequest, ActivityDetailModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.Activities.CreateActivity);
    }

    private Task<PortfolioModel> AddPortfolio(ICopiaActionTester tester, string portfolioName)
    {
        var addTester = tester.Create(api => api.Portfolios.AddPortfolio);
        return addTester.Execute(new AddPortfolioRequest { PortfolioName = portfolioName });
    }

    private Task<ActivityTemplateDetailModel> AddActivityTemplate(ICopiaActionTester tester, PortfolioModel portfolio, string templateName)
    {
        var addTester = tester.Create(api => api.ActivityTemplates.AddActivityTemplate);
        return addTester.Execute
        (
            new AddActivityTemplateRequest(templateName: templateName),
            portfolio.PublicKey
        );
    }

}
