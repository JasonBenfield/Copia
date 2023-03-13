using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.ActivityTemplates;

internal sealed class GetActivityTemplatesAction : AppAction<EmptyRequest, ActivityTemplateModel[]>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public GetActivityTemplatesAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<ActivityTemplateModel[]> Execute(EmptyRequest model, CancellationToken stoppingToken)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efActivityTemplates = await efPortfolio.ActivityTemplates();
        return efActivityTemplates.Select(at => at.ToModel()).ToArray();
    }
}
