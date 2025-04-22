using XTI_Copia.Abstractions;
using XTI_Core;

namespace XTI_CopiaWebAppApiActions.Activities;

public sealed class CreateActivityAction : AppAction<CreateActivityRequest, ActivityModel>
{
    private readonly PortfolioFromModifier portfolioFromModifier;
    private readonly IClock clock;

    public CreateActivityAction(PortfolioFromModifier portfolioFromModifier, IClock clock)
    {
        this.portfolioFromModifier = portfolioFromModifier;
        this.clock = clock;
    }

    public async Task<ActivityModel> Execute(CreateActivityRequest createRequest, CancellationToken stoppingToken)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efActivity = await efPortfolio.CreateActivity(createRequest.ActivityName, clock.Now());
        return efActivity.ToModel();
    }
}
