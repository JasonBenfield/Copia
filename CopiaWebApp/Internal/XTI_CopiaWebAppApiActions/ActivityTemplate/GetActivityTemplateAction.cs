using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApiActions.ActivityTemplate;

public sealed class GetActivityTemplateAction : AppAction<GetActivityTemplateRequest, ActivityTemplateModel>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public GetActivityTemplateAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<ActivityTemplateModel> Execute(GetActivityTemplateRequest model, CancellationToken ct)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efActivityTemplate = await efPortfolio.ActivityTemplate(model.TemplateID);
        var activityTemplate = efActivityTemplate.ToModel();
        return activityTemplate;
    }
}