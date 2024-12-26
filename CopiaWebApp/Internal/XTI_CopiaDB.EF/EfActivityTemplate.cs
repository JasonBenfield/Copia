using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfActivityTemplate
{
    private readonly CopiaDbContext db;
    private readonly ActivityTemplateEntity template;

    internal EfActivityTemplate(CopiaDbContext db, ActivityTemplateEntity template)
    {
        this.db = db;
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
