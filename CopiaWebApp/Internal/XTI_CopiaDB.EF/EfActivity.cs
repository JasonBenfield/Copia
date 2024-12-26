using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfActivity
{
    private readonly CopiaDbContext db;
    private readonly ActivityEntity activity;

    internal EfActivity(CopiaDbContext db, ActivityEntity activity)
    {
        this.db = db;
        this.activity = activity;
    }

    public ActivityModel ToModel() =>
        new ActivityModel
        (
            ID: activity.ID,
            ActivityName: activity.ActivityName,
            ActivityDate: DateOnly.FromDateTime(activity.ActivityDate.LocalDateTime)
        );
}
