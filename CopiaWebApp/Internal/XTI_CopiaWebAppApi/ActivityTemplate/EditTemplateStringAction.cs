using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi.ActivityTemplate;

internal sealed class EditTemplateStringAction : AppAction<EditTemplateStringRequest, TemplateStringModel>
{
    private readonly CopiaDbContext db;
    private readonly PortfolioFromModifier portfolioFromModifier;

    public EditTemplateStringAction(CopiaDbContext db, PortfolioFromModifier portfolioFromModifier)
    {
        this.db = db;
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<TemplateStringModel> Execute(EditTemplateStringRequest model, CancellationToken stoppingToken)
    {
        var efTemplateString = await db.Transaction(() => EditTemplateString(model));
        var templateStringModel = await efTemplateString.ToModel();
        return templateStringModel;
    }

    private async Task<EfTemplateString> EditTemplateString(EditTemplateStringRequest model)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efTemplateString = await efPortfolio.TemplateString(model.ID);
        await efTemplateString.Edit(model.CanEdit, model.Parts);
        return efTemplateString;
    }
}
