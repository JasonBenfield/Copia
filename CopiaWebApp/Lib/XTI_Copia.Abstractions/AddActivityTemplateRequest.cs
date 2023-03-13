namespace XTI_Copia.Abstractions;

public sealed class AddActivityTemplateRequest
{
    public AddActivityTemplateRequest()
        : this("")
    {
    }

    public AddActivityTemplateRequest(string templateName)
    {
        TemplateName = templateName;
    }

    public string TemplateName { get; set; }
}
