namespace XTI_Copia.Abstractions;

public sealed class CreateActivityRequest
{
    public CreateActivityRequest()
        : this("")
    {
    }

    public CreateActivityRequest(string activityName)
    {
        ActivityName = activityName;
    }

    public string ActivityName { get; set; }
}
