namespace XTI_Copia.Abstractions;

public sealed record ActivityModel(int ID, string ActivityName, DateOnly ActivityDate)
{
    public ActivityModel()
        : this(0, "", DateOnly.MaxValue)
    {
    }
}
