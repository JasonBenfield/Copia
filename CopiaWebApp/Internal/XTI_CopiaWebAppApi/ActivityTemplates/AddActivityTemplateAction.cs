using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi.ActivityTemplates;

internal sealed class AddActivityTemplateAction : AppAction<AddActivityTemplateRequest, ActivityTemplateDetailModel>
{
    private readonly CopiaDbContext db;
    private readonly PortfolioFromModifier portfolioFromModifier;

    public AddActivityTemplateAction(CopiaDbContext db, PortfolioFromModifier portfolioFromModifier)
    {
        this.db = db;
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<ActivityTemplateDetailModel> Execute(AddActivityTemplateRequest model, CancellationToken stoppingToken)
    {
        var portfolio = await portfolioFromModifier.Value();
        var efActivityTemplate = await db.Transaction(() => AddActivityTemplate(portfolio, model));
        var detailModel = await efActivityTemplate.ToDetailModel();
        return detailModel;
    }

    private async Task<EfActivityTemplate> AddActivityTemplate(EfPortfolio portfolio, AddActivityTemplateRequest model)
    {
        var efActivityTemplate = await portfolio.AddActivityTemplate(model.TemplateName);
        return efActivityTemplate;
    }
}
