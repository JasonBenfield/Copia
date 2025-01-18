using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfActivityTemplate
{
    private readonly ActivityTemplateEntity template;

    internal EfActivityTemplate(ActivityTemplateEntity template)
    {
        this.template = template;
    }

    internal int ID { get => template.ID; }

    public ActivityTemplateModel ToModel() =>
        new
        (
            template.ID,
            template.TemplateName
        );
}
