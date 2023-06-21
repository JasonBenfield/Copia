using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfActivityTemplate
{
    private readonly CopiaDbContext db;
    private readonly EfPortfolio efPortfolio;
    private readonly ActivityTemplateEntity template;

    internal EfActivityTemplate(CopiaDbContext db, EfPortfolio efPortfolio, ActivityTemplateEntity template)
    {
        this.db = db;
        this.efPortfolio = efPortfolio;
        this.template = template;
    }

    internal int ID { get => template.ID; }

    public ActivityTemplateModel ToModel() =>
        new
        (
            template.ID,
            template.TemplateName
        );

    public async Task<EfActivityTemplateField> AddTemplateField(int templateID, ActivityFieldType fieldType)
    {
        var field = new ActivityTemplateFieldEntity
        {
            TemplateID = templateID,
            FieldType = fieldType.Value,
            FieldCaption = fieldType.DisplayText,
            Accessibility = ActivityFieldAccessibility.Values.Editable.Value
        };
        await db.ActivityTemplateFields.Create(field);
        return new EfActivityTemplateField(field);
    }

    public Task<EfActivityTemplateField[]> TemplateFields() =>
        db.ActivityTemplateFields.Retrieve()
            .Where(tf => tf.TemplateID == template.ID)
            .Select(tf => new EfActivityTemplateField(tf))
            .ToArrayAsync();

    public Task<EfTemplateString> ActivityName() =>
        efPortfolio.TemplateString(template.ActivityNameTemplateStringID);

    public async Task<ActivityTemplateDetailModel> ToDetailModel()
    {
        var efActivityTemplateFields = await TemplateFields();
        var efActivityName = await ActivityName();
        var activityNameModel = await efActivityName.ToModel();
        return new
        (
            ToModel(),
            activityNameModel,
            efActivityTemplateFields.Select(tf => tf.ToModel()).ToArray()
        );
    }
}
