namespace XTI_Copia.Abstractions;

public sealed class CreateActivityRequest
{
    public CreateActivityRequest()
        : this(0)
    {
    }

    public CreateActivityRequest(int activityTemplateID)
    {
        ActivityTemplateID = activityTemplateID;
    }

    public int ActivityTemplateID { get; set; }
}
