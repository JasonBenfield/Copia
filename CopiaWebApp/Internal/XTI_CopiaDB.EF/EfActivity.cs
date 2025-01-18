using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfActivity
{
    private readonly ActivityEntity activity;

    internal EfActivity(ActivityEntity activity)
    {
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
