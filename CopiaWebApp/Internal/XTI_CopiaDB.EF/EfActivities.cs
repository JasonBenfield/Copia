using Microsoft.EntityFrameworkCore;

namespace XTI_CopiaDB.EF;

public sealed class EfActivities
{
    private readonly CopiaDbContext db;

    public EfActivities(CopiaDbContext db)
    {
        this.db = db;
    }

    internal async Task<EfActivity> Create(PortfolioEntity portfolio, EfActivityTemplate efTemplate, EfCounterparty efCounterparty, DateTimeOffset timeCreated)
    {
        var activity = new ActivityEntity
        {
            PortfolioID = portfolio.ID,
            ActivityTemplateID = efTemplate.ID,
            CounterpartyID = efCounterparty.ID,
            TimeCreated = timeCreated,
            ActivityDate = timeCreated.Date
        };
        await db.Activities.Create(activity);
        return new EfActivity(db, activity);
    }

    internal async Task<EfActivity[]> GetActivities(PortfolioEntity portfolio, int max)
    {
        var activities = await db.Activities.Retrieve()
            .Where(a => a.PortfolioID == portfolio.ID)
            .OrderByDescending(a => a.ActivityDate)
            .Take(max)
            .ToArrayAsync();
        return activities.Select(a => new EfActivity(db, a)).ToArray();
    }
}
