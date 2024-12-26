using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi.ActivityTemplates;

internal sealed class AddActivityTemplateAction : AppAction<AddActivityTemplateRequest, ActivityTemplateModel>
{
    private readonly CopiaDbContext db;
    private readonly PortfolioFromModifier portfolioFromModifier;

    public AddActivityTemplateAction(CopiaDbContext db, PortfolioFromModifier portfolioFromModifier)
    {
        this.db = db;
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<ActivityTemplateModel> Execute(AddActivityTemplateRequest model, CancellationToken stoppingToken)
    {
        var portfolio = await portfolioFromModifier.Value();
        var efActivityTemplate = await db.Transaction(() => AddActivityTemplate(portfolio, model));
        var activityTemplate = efActivityTemplate.ToModel();
        return activityTemplate;
    }

    private async Task<EfActivityTemplate> AddActivityTemplate(EfPortfolio efPortfolio, AddActivityTemplateRequest model)
    {
        var efActivityTemplate = await efPortfolio.AddActivityTemplate(model.TemplateName);
        return efActivityTemplate;
    }
}
