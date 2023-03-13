using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.ActivityTemplate;

internal sealed class GetActivityTemplateDetailAction : AppAction<GetActivityTemplateRequest, ActivityTemplateDetailModel>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public GetActivityTemplateDetailAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<ActivityTemplateDetailModel> Execute(GetActivityTemplateRequest model, CancellationToken ct)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efActivityTemplate = await efPortfolio.ActivityTemplate(model.TemplateID);
        var detailModel = await efActivityTemplate.ToDetailModel();
        return detailModel;
    }
}