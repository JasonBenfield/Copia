using XTI_Copia.Abstractions;
using XTI_CopiaWebAppApi;

namespace CopiaWebAppTests;

internal sealed class EditTemplateStringTest
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
            () => new EditTemplateStringRequest
            {
                ID = activityTemplate.ActivityName.ID,
                CanEdit = false
            },
            CopiaInfo.ModCategories.Portfolio,
            portfolio.PublicKey,
            CopiaInfo.Roles.Admin,
            CopiaInfo.Roles.PortfolioOwner
        );
    }

    [Test]
    public async Task ShouldReturnUpdatedTemplateString()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        var activityTemplate = await AddActivityTemplate(tester, portfolio, "Withdrawal");
        var templateString = await tester.Execute
        (
            new EditTemplateStringRequest
            {
                ID = activityTemplate.ActivityName.ID,
                CanEdit = false
            },
            portfolio.PublicKey
        );
        Assert.That
        (
            templateString.ID,
            Is.EqualTo(activityTemplate.ActivityName.ID),
            "Should return updated template string"
        );
    }

    [Test]
    public async Task ShouldChangeCanEdit()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        var activityTemplate = await AddActivityTemplate(tester, portfolio, "Withdrawal");
        var expectedCanEdit = !activityTemplate.ActivityName.CanEdit;
        var templateString = await tester.Execute
        (
            new EditTemplateStringRequest
            {
                ID = activityTemplate.ActivityName.ID,
                CanEdit = expectedCanEdit
            },
            portfolio.PublicKey
        );
        Assert.That(templateString.CanEdit, Is.EqualTo(expectedCanEdit), "Should edit can edit");
    }

    [Test]
    public async Task ShouldAddParts()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        var activityTemplate = await AddActivityTemplate(tester, portfolio, "Withdrawal");
        var expectedCanEdit = !activityTemplate.ActivityName.CanEdit;
        var templateString = await tester.Execute
        (
            new EditTemplateStringRequest
            {
                ID = activityTemplate.ActivityName.ID,
                CanEdit = expectedCanEdit,
                Parts = new[]
                {
                    new AddTemplateStringPartRequest
                    {
                        PartType = TemplateStringPartType.Values.FixedText,
                        FixedText = "Test"
                    },
                    new AddTemplateStringPartRequest
                    {
                        PartType = TemplateStringPartType.Values.Field,
                        FieldType = TemplateStringFieldType.Values.Amount
                    }
                }
            },
            portfolio.PublicKey
        );
        Assert.That
        (
            templateString.Parts.Select(p => new { p.PartType, p.FieldType, p.FixedText }).ToArray(),
            Is.EqualTo
            (
                new[]
                {
                    new 
                    { 
                        PartType = TemplateStringPartType.Values.FixedText, 
                        FieldType = TemplateStringFieldType.Values.NotSet,
                        FixedText = "Test"
                    },
                    new
                    {
                        PartType = TemplateStringPartType.Values.Field,
                        FieldType = TemplateStringFieldType.Values.Amount,
                        FixedText = ""
                    }
                }
            ),
            "Should add template string parts"
        );
    }

    [Test]
    public async Task ShouldReplaceParts()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        var activityTemplate = await AddActivityTemplate(tester, portfolio, "Withdrawal");
        var expectedCanEdit = !activityTemplate.ActivityName.CanEdit;
        await tester.Execute
        (
            new EditTemplateStringRequest
            {
                ID = activityTemplate.ActivityName.ID,
                CanEdit = expectedCanEdit,
                Parts = new[]
                {
                    new AddTemplateStringPartRequest
                    {
                        PartType = TemplateStringPartType.Values.FixedText,
                        FixedText = "Test"
                    },
                    new AddTemplateStringPartRequest
                    {
                        PartType = TemplateStringPartType.Values.Field,
                        FieldType = TemplateStringFieldType.Values.Amount
                    }
                }
            },
            portfolio.PublicKey
        );
        var templateString = await tester.Execute
        (
            new EditTemplateStringRequest
            {
                ID = activityTemplate.ActivityName.ID,
                CanEdit = expectedCanEdit,
                Parts = new[]
                {
                    new AddTemplateStringPartRequest
                    {
                        PartType = TemplateStringPartType.Values.FixedText,
                        FixedText = "Test 2"
                    }
                }
            },
            portfolio.PublicKey
        );
        Assert.That
        (
            templateString.Parts.Select(p => new { p.PartType, p.FieldType, p.FixedText }).ToArray(),
            Is.EqualTo
            (
                new[]
                {
                    new
                    {
                        PartType = TemplateStringPartType.Values.FixedText,
                        FieldType = TemplateStringFieldType.Values.NotSet,
                        FixedText = "Test 2"
                    }
                }
            ),
            "Should replace template string parts"
        );
    }

    [Test]
    public async Task ShouldNotAddPart_WhenPartTypeIsFixedTextAndFixedTextIsBlank()
    {
        var tester = await Setup();
        tester.Login();
        var portfolio = await AddPortfolio(tester, "Portfolio 1");
        var activityTemplate = await AddActivityTemplate(tester, portfolio, "Withdrawal");
        var expectedCanEdit = !activityTemplate.ActivityName.CanEdit;
        var templateString = await tester.Execute
        (
            new EditTemplateStringRequest
            {
                ID = activityTemplate.ActivityName.ID,
                CanEdit = expectedCanEdit,
                Parts = new[]
                {
                    new AddTemplateStringPartRequest
                    {
                        PartType = TemplateStringPartType.Values.FixedText,
                        FixedText = "Test"
                    },
                    new AddTemplateStringPartRequest
                    {
                        PartType = TemplateStringPartType.Values.Field,
                        FieldType = TemplateStringFieldType.Values.Amount
                    },
                    new AddTemplateStringPartRequest
                    {
                        PartType = TemplateStringPartType.Values.FixedText,
                        FixedText = ""
                    }
                }
            },
            portfolio.PublicKey
        );
        Assert.That
        (
            templateString.Parts.Select(p => new { p.PartType, p.FieldType, p.FixedText }).ToArray(),
            Is.EqualTo
            (
                new[]
                {
                    new
                    {
                        PartType = TemplateStringPartType.Values.FixedText,
                        FieldType = TemplateStringFieldType.Values.NotSet,
                        FixedText = "Test"
                    },
                    new
                    {
                        PartType = TemplateStringPartType.Values.Field,
                        FieldType = TemplateStringFieldType.Values.Amount,
                        FixedText = ""
                    }
                }
            ),
            "Should add template string parts"
        );
    }

    private async Task<CopiaActionTester<EditTemplateStringRequest, TemplateStringModel>> Setup()
    {
        var host = new CopiaTestHost();
        var services = await host.Setup();
        return CopiaActionTester.Create(services, api => api.ActivityTemplate.EditTemplateString);
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
