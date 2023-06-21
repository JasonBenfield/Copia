using XTI_Copia.Abstractions;
using XTI_Core;

namespace XTI_CopiaWebAppApi.Activities;

internal sealed class CreateActivityAction : AppAction<CreateActivityRequest, ActivityDetailModel>
{
    private readonly PortfolioFromModifier portfolioFromModifier;
    private readonly IClock clock;

    public CreateActivityAction(PortfolioFromModifier portfolioFromModifier, IClock clock)
    {
        this.portfolioFromModifier = portfolioFromModifier;
        this.clock = clock;
    }

    public async Task<ActivityDetailModel> Execute(CreateActivityRequest createRequest, CancellationToken stoppingToken)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efTemplate = await efPortfolio.ActivityTemplate(createRequest.ActivityTemplateID);
        var efActivity = await efPortfolio.CreateActivity(efTemplate, clock.Now());
        return new ActivityDetailModel();
    }
}
