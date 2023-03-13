namespace XTI_Copia.Abstractions;

public sealed record ActivityTemplateModel(int ID, string TemplateName)
{
    public ActivityTemplateModel()
        : this(0, "")
    {
    }
}
