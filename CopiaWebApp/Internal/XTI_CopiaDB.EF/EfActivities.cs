using Microsoft.EntityFrameworkCore;

namespace XTI_CopiaDB.EF;

public sealed class EfActivities
{
    private readonly EfCopiaDB db;

    internal EfActivities(EfCopiaDB db)
    {
        this.db = db;
    }

    internal async Task<EfActivity> Create(PortfolioEntity portfolio, string activityName, EfCounterparty efCounterparty, DateTimeOffset timeCreated)
    {
        var activity = new ActivityEntity
        {
            PortfolioID = portfolio.ID,
            ActivityName = activityName,
            CounterpartyID = efCounterparty.ID,
            TimeCreated = timeCreated,
            ActivityDate = timeCreated.Date
        };
        await db.Context.Activities.Create(activity);
        return new EfActivity(activity);
    }

    internal async Task<EfActivity[]> GetActivities(PortfolioEntity portfolio, int max)
    {
        var activities = await db.Context.Activities.Retrieve()
            .Where(a => a.PortfolioID == portfolio.ID)
            .OrderByDescending(a => a.ActivityDate)
            .Take(max)
            .ToArrayAsync();
        return activities.Select(a => new EfActivity(a)).ToArray();
    }
}
