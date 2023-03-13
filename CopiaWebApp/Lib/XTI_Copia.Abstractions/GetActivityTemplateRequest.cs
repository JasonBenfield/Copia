namespace XTI_Copia.Abstractions;

public sealed class GetActivityTemplateRequest
{
    public GetActivityTemplateRequest()
    {
    }

    public GetActivityTemplateRequest(int templateID)
    {
        TemplateID = templateID;
    }

    public int TemplateID { get; set; }
}
